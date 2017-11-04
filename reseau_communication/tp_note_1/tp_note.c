#include <stdlib.h>
#include <stdio.h>
#include <pthread.h>
#include <unistd.h>

void* treatment(void*);

void treatment_1(int);
void treatment_2(int);
void treatment_3(int);

typedef struct N_VERROU
{
     int a_count_maximum_threads;

     int a_count_current_threads;

     pthread_mutex_t a_mutex;

     pthread_cond_t a_cond;

} N_VERROU;

N_VERROU g_n_verrou;

int n_verrou_init(N_VERROU* p_n_verrou, int p_count_maximum_threads)
{
     p_n_verrou->a_count_maximum_threads = p_count_maximum_threads; //Nombre maximum de thread sur la section critique

     p_n_verrou->a_count_current_threads = 0;

     if(pthread_mutex_init(&p_n_verrou->a_mutex, NULL) != 0)
     {
          perror("error on pthread_mutex_init");
          return -EXIT_FAILURE;
     }

     if(pthread_cond_init(&p_n_verrou->a_cond, NULL) != 0)
     {
          perror("error on pthread_cond_init");
          return -EXIT_FAILURE;
     }

     return 0;
}

int n_verrou_lock(N_VERROU* p_n_verrou, int p_index)
{
     if(pthread_mutex_lock(&p_n_verrou->a_mutex) != 0)
     {
          perror("pthread_mutex_lock : ");
          return -EXIT_FAILURE;
     }

     while(p_n_verrou->a_count_maximum_threads == p_n_verrou->a_count_current_threads)
     {
          fprintf(stdout, "Thread %d is waiting for treatment_2\n", p_index);
          pthread_cond_wait(&p_n_verrou->a_cond, &p_n_verrou->a_mutex);
     }

     p_n_verrou->a_count_current_threads++;

     if(pthread_mutex_unlock(&p_n_verrou->a_mutex) != 0)
     {
          perror("error on pthread_mutex_unlock : ");
          return -EXIT_FAILURE;
     }

     return 0;
}

int n_verrou_unlock(N_VERROU* p_n_verrou)
{
     if(pthread_mutex_lock(&p_n_verrou->a_mutex) != 0)
     {
          perror("pthread_mutex_lock : ");
          return -EXIT_FAILURE;
     }

     p_n_verrou->a_count_current_threads--;

     if(pthread_mutex_unlock(&p_n_verrou->a_mutex) != 0)
     {
          perror("pthread_mutex_unlock : ");
          return -EXIT_FAILURE;
     }

     if(pthread_cond_broadcast(&g_n_verrou.a_cond) != 0)
          return -EXIT_FAILURE;

     return 0;
}

int n_verrou_destroy(N_VERROU* p_n_verrou)
{
     if(pthread_mutex_destroy(&p_n_verrou->a_mutex) != 0)
     {
          perror("pthread_mutex_destroy : ");
          return -EXIT_FAILURE;
     }

     if(pthread_cond_destroy(&p_n_verrou->a_cond) != 0)
     {
          perror("pthread_mutex_destroy : ");
          return -EXIT_FAILURE;
     }

     return 0;
}

void* treatment(void* p_index)
{
     int t_index = (intptr_t) p_index;

     treatment_1(t_index);

     if(n_verrou_lock(&g_n_verrou, t_index) != 0)
     {
          perror("error n_verrou_lock : ");
          exit(EXIT_FAILURE);
     }

     treatment_2(t_index);

     if(n_verrou_unlock(&g_n_verrou) != 0)
     {
          perror("error n_verrou_unlock : ");
          exit(EXIT_FAILURE);
     }

     treatment_3(t_index);

     pthread_exit(NULL);
}

void treatment_1(int p_index)
{
     fprintf(stdout, "Thread %d start treatment 1\n", p_index);
     sleep(1);
     fprintf(stdout, "Thread %d end treatment 1\n", p_index);
}

void treatment_2(int p_index)
{
     fprintf(stdout, "\tThread %d start treatment 2\n", p_index);
     sleep(2);
     fprintf(stdout, "\tThread %d end treatment 2\n", p_index);
}

void treatment_3(int p_index)
{
     fprintf(stdout, "\t\tThread %d start treatment 3\n", p_index);
     sleep(3);
     fprintf(stdout, "\t\tThread %d end treatment 3\n", p_index);
}

/*
*    argv[1] : Number of threads
*    argv[2] : Number of maximum threads on treatment_2
*/
int main(int argc, char** argv)
{
     if(argc < 3)
     {
          fprintf(stderr, "Mauvais argument(s) : nombre_total_threads, nombre_maximum_threads_section_critique\n");

          return EXIT_FAILURE;
     }

     if(n_verrou_init(&g_n_verrou, atoi(argv[2])) != 0)
     {
          fprintf(stderr, "Error on n_verrou_init\n");
          return EXIT_FAILURE;
     }

     pthread_t t_threads[atoi(argv[EXIT_FAILURE])];

     fprintf(stdout, "--- BEGIN ---\n\n");

     for(int t_index = 0; t_index < atoi(argv[EXIT_FAILURE]); t_index++)
          if(pthread_create(&t_threads[t_index], NULL, treatment, (void*) (intptr_t) t_index) != 0)
          {
               perror("pthread_create : ");
               return EXIT_FAILURE;
          }

     for(int t_index = 0; t_index < atoi(argv[EXIT_FAILURE]); t_index++)
          if(pthread_join(t_threads[t_index], NULL) != 0)
          {
               perror("pthread_join : ");
               return EXIT_FAILURE;
          }

     if(n_verrou_destroy(&g_n_verrou) != 0)
     {
          fprintf(stderr, "Error on n_verrou_destroy\n");
          return EXIT_FAILURE;
     }

     fprintf(stdout, "\n--- END ---\n");

     return EXIT_SUCCESS;
}

/*
     gcc ./tp_note.c -W -O3 -o ./tp_note.out -lpthread;
*/

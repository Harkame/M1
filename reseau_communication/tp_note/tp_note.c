#include <stdlib.h>
#include <stdio.h>
#include <pthread.h>
#include <unistd.h>

void* traitement_1(void*);
void  traitement_2(int);
void  traitement_3(int);

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
          return -1;
     }

     if(pthread_cond_init(&p_n_verrou->a_cond, NULL) != 0)
     {
          perror("error on pthread_cond_init");
          return -1;
     }

     return 0;
}

int n_verrou_lock(N_VERROU* p_n_verrou, int p_index)
{
     if(pthread_mutex_lock(&p_n_verrou->a_mutex) != 0)
     {
          perror("pthread_mutex_lock : ");
          return -1;
     }

     while(p_n_verrou->a_count_maximum_threads == p_n_verrou->a_count_current_threads)
     {
          fprintf(stdout, "Thread %d is waiting for traitement_2\n", p_index);
          pthread_cond_wait(&p_n_verrou->a_cond, &p_n_verrou->a_mutex);
     }

     p_n_verrou->a_count_current_threads++;

     if(pthread_mutex_unlock(&p_n_verrou->a_mutex) != 0)
     {
          perror("error on pthread_mutex_unlock : ");
          return -1;
     }

     return 0;
}

int n_verrou_unlock(N_VERROU* p_n_verrou)
{
     if(pthread_mutex_lock(&p_n_verrou->a_mutex) != 0)
     {
          perror("pthread_mutex_lock : ");
          return -1;
     }

     p_n_verrou->a_count_current_threads--;

     if(pthread_mutex_unlock(&p_n_verrou->a_mutex) != 0)
     {
          perror("pthread_mutex_unlock : ");
          return -1;
     }

     if(pthread_cond_broadcast(&g_n_verrou.a_cond) != 0)
          return -1;

     return 0;
}

int n_verrou_destroy(N_VERROU* p_n_verrou)
{
     if(pthread_mutex_destroy(&p_n_verrou->a_mutex) != 0)
     {
          perror("pthread_mutex_destroy : ");
          return -1;
     }

     if(pthread_cond_destroy(&p_n_verrou->a_cond) != 0)
     {
          perror("pthread_mutex_destroy : ");
          return -1;
     }

     return 0;
}

void* traitement_1(void* p_index)
{
     int t_index = (intptr_t) p_index;

     fprintf(stdout, "Thread %d start traitement 1\n", t_index);
     sleep(1);
     fprintf(stdout, "Thread %d end traitement 1\n", t_index);

     if(n_verrou_lock(&g_n_verrou, t_index) != 0)
     {
          perror("error n_verrou_lock : ");
          exit(1);
     }

     traitement_2(t_index);
}

void traitement_2(int p_index)
{
     fprintf(stdout, "\tThread %d start traitement 2\n", p_index);
     sleep(2);
     fprintf(stdout, "\tThread %d end traitement 2\n", p_index);

     if(n_verrou_unlock(&g_n_verrou) != 0)
     {
          perror("error n_verrou_unlock : ");
          exit(1);
     }

     traitement_3(p_index);
}

void traitement_3(int p_index)
{
     fprintf(stdout, "\t\tThread %d start traitement 3\n", p_index);
     sleep(3);
     fprintf(stdout, "\t\tThread %d end traitement 3\n", p_index);
}

/*
*    argv[1] : Nombre total de threads
*    argv[2] : Nombre maximum de threads sur le traitement 2 en meme temps
*/
int main(int argc, char** argv)
{
     if(argc < 3)
     {
          fprintf(stderr, "Mauvais argument(s) : nombre_total_threads, nombre_maximum_threads_section_critique\n");

          return 1;
     }

     if(n_verrou_init(&g_n_verrou, atoi(argv[2])) != 0)
     {
          fprintf(stderr, "Error on n_verrou_init\n");
          return 1;
     }

     pthread_t t_threads[atoi(argv[1])];

     for(int t_index = 0; t_index < atoi(argv[1]); t_index++)
          if(pthread_create(&t_threads[t_index], NULL, traitement_1, (void*) (intptr_t) t_index) != 0)
          {
               perror("pthread_create : ");
               return 1;
          }

     for(int t_index = 0; t_index < atoi(argv[1]); t_index++)
          if(pthread_join(t_threads[t_index], NULL) != 0)
          {
               perror("pthread_join : ");
               return 1;
          }

     if(n_verrou_destroy(&g_n_verrou) != 0)
     {
          fprintf(stderr, "Error on n_verrou_destroy\n");
          return 1;
     }

     fprintf(stdout, "\n--- END ---\n");

     return 0;
}

/*
     gcc ./tp_note.c -W -O3 -o ./tp_note.out -lpthread;
*/

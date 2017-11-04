#include <stdlib.h>
#include <stdio.h>
#include <pthread.h>
#include <unistd.h>

#define MESSAGE_START "\n--- START ---\n\n"
#define MESSAGE_END "\n --- END ---\n\n"

#define MESSAGE_WAITING_TREATMENT_2 "Thread %d is waiting for treatment_2\n"

#define MESSAGE_START_TREATMENT "Thread %d start treatment %d\n"
#define MESSAGE_END_TREATMENT    "Thread %d end treatment %d\n"

#define ERROR_MESSAGE_ARGUMENTS "Wrong argument(s) : [number_total_threads] [number_maxium_threads_treatment_2]\n"

#define ERROR_MESSAGE_PTHREAD_MUTEX_INIT        "pthread_mutex_init : "
#define ERROR_MESSAGE_PTHREAD_COND_INIT          "pthread_cond_init : "

#define ERROR_MESSAGE_PTHREAD_MUTEX_LOCK       "pthread_mutex_lock : "
#define ERROR_MESSAGE_PTHREAD_MUTEX_UNLOCK "pthread_mutex_unlock : "

#define ERROR_MESSAGE_PTHREAD_MUTEX_DESTROY "pthread_mutex_destroy : "
#define ERROR_MESSAGE_PTHREAD_COND_DESTROY  "pthread_cond_destroy : "

#define ERROR_MESSAGE_PTHREAD_CREATE "pthread_create : "
#define ERROR_MESSAGE_PTHREAD_JOIN      "pthread_join : "

#define ERROR_MESSAGE_N_LOCKER_INITIALIZE "error on n_locker_initialize\n"
#define ERROR_MESSAGE_N_LOCKER_DESTROY "error on n_locker_destroy\n"

typedef struct N_LOCKER
{
     int a_number_maximum_threads;

     int a_number_current_threads;

     pthread_mutex_t a_mutex;

     pthread_cond_t a_cond;

} N_LOCKER;

N_LOCKER g_n_locker;

int n_locker_initialize(N_LOCKER* p_n_locker, int p_number_maximum_threads)
{
     p_n_locker->a_number_maximum_threads = p_number_maximum_threads;

     p_n_locker->a_number_current_threads = 0;

     if(pthread_mutex_init(&p_n_locker->a_mutex, NULL) != 0)
     {
          perror(ERROR_MESSAGE_PTHREAD_MUTEX_INIT);
          return EXIT_FAILURE;
     }

     if(pthread_cond_init(&p_n_locker->a_cond, NULL) != 0)
     {
          perror(ERROR_MESSAGE_PTHREAD_COND_INIT);
          return EXIT_FAILURE;
     }

     return EXIT_SUCCESS;
}

int n_locker_lock(N_LOCKER* p_n_locker, int p_index)
{
     if(pthread_mutex_lock(&p_n_locker->a_mutex) != 0)
     {
          perror(ERROR_MESSAGE_PTHREAD_MUTEX_LOCK);
          return EXIT_FAILURE;
     }

     while(p_n_locker->a_number_maximum_threads == p_n_locker->a_number_current_threads)
     {
          fprintf(stdout, MESSAGE_WAITING_TREATMENT_2, p_index);
          pthread_cond_wait(&p_n_locker->a_cond, &p_n_locker->a_mutex);
     }

     p_n_locker->a_number_current_threads++;

     if(pthread_mutex_unlock(&p_n_locker->a_mutex) != 0)
     {
          perror(ERROR_MESSAGE_PTHREAD_MUTEX_UNLOCK);
          return EXIT_FAILURE;
     }

     return EXIT_SUCCESS;
}

int n_locker_unlock(N_LOCKER* p_n_locker)
{
     if(pthread_mutex_lock(&p_n_locker->a_mutex) != 0)
     {
          perror(ERROR_MESSAGE_PTHREAD_MUTEX_LOCK);
          return EXIT_FAILURE;
     }

     p_n_locker->a_number_current_threads--;

     if(pthread_mutex_unlock(&p_n_locker->a_mutex) != 0)
     {
          perror(ERROR_MESSAGE_PTHREAD_MUTEX_UNLOCK);
          return EXIT_FAILURE;
     }

     if(pthread_cond_broadcast(&g_n_locker.a_cond) != 0)
          return EXIT_FAILURE;

     return EXIT_SUCCESS;
}

int n_locker_destroy(N_LOCKER* p_n_locker)
{
     if(pthread_mutex_destroy(&p_n_locker->a_mutex) != 0)
     {
          perror(ERROR_MESSAGE_PTHREAD_MUTEX_DESTROY);
          return EXIT_FAILURE;
     }

     if(pthread_cond_destroy(&p_n_locker->a_cond) != 0)
     {
          perror(ERROR_MESSAGE_PTHREAD_COND_DESTROY);
          return EXIT_FAILURE;
     }

     return EXIT_SUCCESS;
}

void treatment_1(int p_index)
{
     fprintf(stdout, MESSAGE_START_TREATMENT, p_index, 1);
     sleep(1);
     fprintf(stdout, MESSAGE_END_TREATMENT, p_index, 1);
}

void treatment_2(int p_index)
{
     fprintf(stdout, "\t"MESSAGE_START_TREATMENT, p_index, 2);
     sleep(2);
     fprintf(stdout, "\t"MESSAGE_END_TREATMENT, p_index, 2);
}

void treatment_3(int p_index)
{
     fprintf(stdout, "\t\t"MESSAGE_START_TREATMENT, p_index, 3);
     sleep(3);
     fprintf(stdout, "\t\t"MESSAGE_END_TREATMENT, p_index, 3);
}

void* treatment(void* p_index)
{
     int t_index = (intptr_t) p_index;

     treatment_1(t_index);

     if(n_locker_lock(&g_n_locker, t_index) != 0)
     {
          perror("error n_locker_lock : ");
          exit(EXIT_FAILURE);
     }

     treatment_2(t_index);

     if(n_locker_unlock(&g_n_locker) != 0)
     {
          perror("error n_locker_unlock : ");
          exit(EXIT_FAILURE);
     }

     treatment_3(t_index);

     pthread_exit(NULL);
}

/*
*    argv[1] : Number of threads
*    argv[2] : Number of maximum threads on treatment_2
*/
int main(int argc, char** argv)
{
     if(argc < 3)
     {
          fprintf(stderr, ERROR_MESSAGE_ARGUMENTS);

          return EXIT_FAILURE;
     }

     if(n_locker_initialize(&g_n_locker, atoi(argv[2])) == EXIT_FAILURE)
     {
          fprintf(stderr, ERROR_MESSAGE_N_LOCKER_INITIALIZE);
          return EXIT_FAILURE;
     }

     pthread_t t_threads[atoi(argv[EXIT_FAILURE])];

     fprintf(stdout, MESSAGE_START);

     for(int t_index = 0; t_index < atoi(argv[EXIT_FAILURE]); t_index++)
          if(pthread_create(&t_threads[t_index], NULL, treatment, (void*) (intptr_t) t_index) == EXIT_FAILURE)
          {
               perror(ERROR_MESSAGE_PTHREAD_CREATE);
               return EXIT_FAILURE;
          }

     for(int t_index = 0; t_index < atoi(argv[EXIT_FAILURE]); t_index++)
          if(pthread_join(t_threads[t_index], NULL) == EXIT_FAILURE)
          {
               perror(ERROR_MESSAGE_PTHREAD_JOIN);
               return EXIT_FAILURE;
          }

     if(n_locker_destroy(&g_n_locker) == EXIT_FAILURE)
     {
          fprintf(stderr, ERROR_MESSAGE_N_LOCKER_DESTROY);
          return EXIT_FAILURE;
     }

     fprintf(stdout, MESSAGE_END);

     return EXIT_SUCCESS;
}

/*
     gcc ./tp_note.c -W -O3 -o ./tp_note.out -lpthread;
*/

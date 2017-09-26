#include <stdlib.h>
#include <stdio.h>
#include <pthread.h>

pthread_mutex_t g_mutex = PTHREAD_MUTEX_INITIALIZER;

pthread_cond_t g_cond = PTHREAD_COND_INITIALIZER;

int g_event = 0;


void* foo(void* p_param)
{
     //int t_time = rand();

     sleep(2);

     pthread_mutex_lock(&g_mutex);

     g_event = 1;

     pthread_mutex_unlock(&g_mutex);

     pthread_cond_broadcast(&g_cond);
}

int main()
{
     pthread_t t_threads[2];

     for(int t_index = 0; t_index < 2; t_index++)
          pthread_create(&t_threads[t_index], NULL, foo, t_index);

     pthread_mutex_lock(&g_mutex);

     while(g_event == 0)
     {
          fprintf(stdout, "Debut attente\n");
          pthread_cond_wait(&g_cond, &g_mutex);
     }

     pthread_mutex_unlock(&g_mutex);

     fprintf(stdout, "Attente finie\n");

     return 0;
}

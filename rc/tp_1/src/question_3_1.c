#include <stdlib.h>
#include <stdio.h>
#include <pthread.h>

int g_event = 0;

void* foo(void* p_param)
{
     pthread_mutex_t t_mutex = *(pthread_mutex_t*) p_param;

     for(int t_index = 0; t_index < 10; t_index++)
          fprintf(stdout, "%d\n", t_index);

     pthread_mutex_lock(&t_mutex);

     g_event = 1;

     pthread_mutex_unlock(&t_mutex);
}

int main()
{
     pthread_t t_thread;

     pthread_mutex_t t_mutex;

     pthread_create(&t_thread, NULL, foo, &t_mutex);

     pthread_mutex_lock(&t_mutex);

     while(g_event == 0)
     {
          pthread_mutex_unlock(&t_mutex);
          fprintf(stdout, "En attente\n");
          pthread_mutex_lock(&t_mutex);
     }

     pthread_mutex_unlock(&t_mutex);

     fprintf(stdout, "Attente finie\n");

     return 0;
}

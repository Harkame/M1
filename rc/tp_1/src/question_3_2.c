#include <stdlib.h>
#include <stdio.h>
#include <pthread.h>

typedef struct LOCKER
{
     pthread_mutex_t a_mutex;

     pthread_cond_t a_cond;

} LOCKER;

int g_event = 0;


void* foo(void* p_param)
{
     LOCKER t_locker = *(struct LOCKER*) p_param;

     for(int t_index = 0; t_index < 10; t_index++)
          fprintf(stdout, "%d\n", t_index);

     //pthread_mutex_lock(&t_locker.a_mutex);

     g_event = 1;

     //pthread_mutex_unlock(&t_locker.a_mutex);

     pthread_cond_broadcast(&t_locker.a_cond);
}

int main()
{
     pthread_t t_thread;

     struct LOCKER t_locker;

     pthread_mutex_init(&t_locker.a_mutex, NULL);

     pthread_cond_init(&t_locker.a_cond, NULL);

     pthread_create(&t_thread, NULL, foo, &t_locker);

     pthread_mutex_lock(&t_locker.a_mutex);

     pthread_cond_wait(&t_locker.a_cond, &t_locker.a_mutex);

     fprintf(stdout, "Attente finie\n");

     return 0;
}

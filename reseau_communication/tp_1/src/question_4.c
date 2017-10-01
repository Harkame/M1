#include <stdlib.h>
#include <stdio.h>
#include <pthread.h>
#include <unistd.h>

int g_positions[3] = {0};

pthread_mutex_t g_mutex = PTHREAD_MUTEX_INITIALIZER;
pthread_cond_t g_cond   = PTHREAD_COND_INITIALIZER;

void* foo(void* p_param)
{
     int t_index = (intptr_t) p_param;

     while(g_positions[t_index] < 4)
     {
          if(t_index == 0)
          {
               fprintf(stdout, "Activity (%d) start work on %d\n", t_index, g_positions[t_index]);

               sleep(0.1);

               fprintf(stdout, "Activity (%d) end work on %d\n", t_index, g_positions[t_index]);

               pthread_mutex_lock(&g_mutex);

               g_positions[t_index]++;

               pthread_mutex_unlock(&g_mutex);

               pthread_cond_broadcast(&g_cond);
          }
          else
          {
               pthread_mutex_lock(&g_mutex);

               while(g_positions[t_index - 1] < g_positions[t_index] + 2)
                    pthread_cond_wait(&g_cond, &g_mutex);

               pthread_mutex_unlock(&g_mutex);

               fprintf(stdout, "Activity (%d) start work on %d\n", t_index, g_positions[t_index]);

               sleep(0.1);

               fprintf(stdout, "Activity (%d) end work on %d\n", t_index, g_positions[t_index]);

               pthread_mutex_lock(&g_mutex);

               g_positions[t_index]++;

               pthread_mutex_unlock(&g_mutex);

               pthread_cond_broadcast(&g_cond);
          }
     }

     pthread_exit(NULL);
}

int main()
{
     pthread_t t_threads[3];

     for(int t_index = 0; t_index < 3; t_index++)
          pthread_create(&t_threads[t_index], NULL, foo, (void*) (intptr_t) t_index);

     for(int t_index = 0; t_index < 3; t_index++)
          pthread_join(t_threads[t_index], NULL);

     return 0;
}

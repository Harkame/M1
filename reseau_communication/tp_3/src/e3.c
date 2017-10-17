#include "./tp_3.h"

int main(int argc, char** argv)
{
     if(argc < 1)
     {
          fprintf(stderr, "Mauvais argument(s)\n");
     }

     int t_id = atoi(argv[1]);

     key_t t_key = ftok(SEMAPHORE_PATH, IPC_KEY);

     int* t_semaphore_id = semget(t_key, 3, IPC_CREAT|0666);

     for(int t_index = 0; t_index < 3; t_index++)
     {
          while(!g_positions[t_index] >= g_positions[t_index - 1])
               pthread_cond_wait(&g_cond, &g_mutex);

          g_positions[t_index]++;

          fprintf(stdout, "Activity (%d) start work on %d\n", t_index, g_positions[t_index]);

          sleep(1);

          fprintf(stdout, "Activity (%d) end work on %d\n", t_index, g_positions[t_index]);
     }

     return 0;
}

#include "../tp_3.h"

int main(int argc, char** argv)
{
     fprintf(stdout, "FALIRE : %d\n", -11);
     if(argc < 2)
     {
          fprintf(stderr, ERROR_MESSAGE_WRONG_ARGUMENTS);
          fprintf(stderr, "(process_id)\n");
          return EXIT_FAILURE;
     }

     int t_id = atoi(argv[1]);

     key_t t_key = ftok(SEMAPHORE_PATH, IPC_KEY);

     if(t_key == -1)
     {
          perror(ERROR_MESSAGE_FTOK);
          return EXIT_FAILURE;
     }

     int t_semaphore_id = semget(t_key, NUMBER_AREAS, IPC_FLAG);

     if(t_semaphore_id == -1)
     {
          perror(ERROR_MESSAGE_SEMGET);
          return EXIT_FAILURE;
     }

     fprintf(stdout, MESSAGE_START);
     int t_value;

     for(int t_index = 0; t_index < NUMBER_AREAS; t_index++)
     {
          while(t_value != t_id)
          {
               t_value = semctl(t_semaphore_id, t_index, GETVAL, NULL);

               if(t_value == -1)
               {
                    perror(ERROR_MESSAGE_SEMCTL);
                    return EXIT_FAILURE;
               }
               fprintf(stdout, "Activity (%d) is waiting for treatment %d\n", t_id, t_index);
               sleep(1);
          }

          fprintf(stdout, "Semaphore (%d) start work on %d\n", t_id, t_index);

          sleep(2);

          fprintf(stdout, "Semaphore (%d) end work on %d\n", t_id, t_index);

          if(semop(t_semaphore_id, &g_sembuf_3[t_index], 1) != 0)
          {
               perror(ERROR_MESSAGE_SEMOP);
               return EXIT_FAILURE;
          }
     }

     fprintf(stdout, MESSAGE_END);

     return EXIT_SUCCESS;
}

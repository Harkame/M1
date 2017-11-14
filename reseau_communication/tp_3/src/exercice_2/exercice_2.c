#include "../tp_3.h"

int main()
{
     key_t t_key = ftok(SEMAPHORE_PATH, IPC_KEY);

     if(t_key == -1)
     {
          perror(ERROR_MESSAGE_FTOK);
          return EXIT_FAILURE;
     }

     int t_semaphore_id = semget(t_key, 1, IPC_FLAG);

     if(t_semaphore_id == -1)
     {
          perror(ERROR_MESSAGE_SEMGET);
          return EXIT_FAILURE;
     }

     if(semop(t_semaphore_id, &g_sembuf_2[0], 1) == -1)
     {
          perror(ERROR_MESSAGE_SEMOP);
          return EXIT_FAILURE;
     }

     fprintf(stdout, "Is waiting for other process\n");
     fprintf(stdout, "Remaining : %d\n", semctl(t_semaphore_id, 0, GETVAL, NULL));

     if(semop(t_semaphore_id, &g_sembuf_2[1], 1) == -1)
     {
          perror(ERROR_MESSAGE_SEMOP);
          return EXIT_FAILURE;
     }

     fprintf(stdout, MESSAGE_START);

     return EXIT_SUCCESS;
}

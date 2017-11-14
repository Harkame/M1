#include "../tp_3.h"

int main(int argc, char** argv)
{
     if(argc < 2)
     {
               fprintf(stderr, ERROR_MESSAGE_WRONG_ARGUMENTS);
               fprintf(stderr, "(number_waiting_process");
               return EXIT_FAILURE;
     }

     key_t t_key = ftok(SEMAPHORE_PATH, IPC_KEY);

     if(t_key == -1)
     {
          perror(ERROR_MESSAGE_FTOK);
          return EXIT_FAILURE;
     }

     int t_semaphore_id = semget(t_key, 1, IPC_CREAT | IPC_FLAG);

     if(t_semaphore_id == -1)
     {
          perror(ERROR_MESSAGE_SEMGET);
          return EXIT_FAILURE;
     }

     SEMUN t_semun;
     t_semun.val = atoi(argv[1]);

     if(semctl(t_semaphore_id, 0, SETVAL, t_semun) == -1)
     {
          perror(ERROR_MESSAGE_SEMCTL);
          return EXIT_FAILURE;
     }

     fprintf(stdout, MESSAGE_SEMAPHORE_CREATION);

     fprintf(stdout, MESSAGE_INTERACTION_CONTINUE);

     getchar();

     if(semctl(t_semaphore_id, 0, IPC_RMID) == -1)
     {
          perror(ERROR_MESSAGE_SEMCTL);
          return EXIT_FAILURE;
     }

     fprintf(stdout, MESSAGE_SEMAPHORE_DESTRUCTION);

     return EXIT_SUCCESS;
}

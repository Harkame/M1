#include "../tp_3.h"

int main()
{
     key_t t_key = ftok(SEMAPHORE_PATH, IPC_KEY);

     if(t_key == EXIT_FAILURE)
     {
          perror(ERROR_MESSAGE_FTOK);
          return EXIT_FAILURE;
     }

     int t_semaphore_id = semget(t_key, NUMBER_AREAS, IPC_CREAT | IPC_FLAG);

     if(t_semaphore_id == EXIT_FAILURE)
     {
          perror(ERROR_MESSAGE_SEMGET);
          return EXIT_FAILURE;
     }

     fprintf(stdout, MESSAGE_SEMAPHORE_CREATION);

     SEMUN t_semun;

     //t_semun.val = SEMAPHORE_DEFAULT_VALUE; //setval

     ushort t_array[NUMBER_AREAS] = SEMAPHORE_DEFAULT_VALUES;
     t_semun.array = t_array;

     if(semctl(t_semaphore_id, 0, SETALL, t_semun) != 0)
     {
          perror(ERROR_MESSAGE_SEMCTL);
          return EXIT_FAILURE;
     }

     fprintf(stdout, MESSAGE_SEMAPHORE_INITIALIZATION);

     fprintf(stdout, MESSAGE_INTERACTION_CONTINUE);

     getchar();

     if(semctl(t_semaphore_id, 0, IPC_RMID) != 0)
     {
          perror(ERROR_MESSAGE_SEMCTL);
          return EXIT_FAILURE;
     }

     fprintf(stdout, MESSAGE_SEMAPHORE_DESTRUCTRUCTION);

     return EXIT_SUCCESS;
}

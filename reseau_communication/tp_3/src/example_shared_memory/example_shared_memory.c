#include "../tp_3.h"

int main(void)
{
     key_t t_key = ftok(SEMAPHORE_PATH, IPC_KEY);

     if(t_key == EXIT_FAILURE)
     {
          perror(ERROR_MESSAGE_FTOK);
          return EXIT_FAILURE;
     }

     int t_shared_memory_id = shmget(t_key, sizeof(char) * 10, IPC_CREAT | IPC_FLAG);

     if(t_shared_memory_id == EXIT_FAILURE)
     {
          perror(ERROR_MESSAGE_SEMGET);
          return EXIT_FAILURE;
     }

     char* t_shared_memory = shmat(t_key, NULL, IPC_FLAG);

     if(*t_shared_memory == -1)
     {
          perror("shmat : ");
          return EXIT_FAILURE;
     }

     //TODO

     if(shmdt(t_shared_memory) == -1)
     {
          perror("shmdt :");
          return EXIT_FAILURE;
     }

     return EXIT_SUCCESS;
}

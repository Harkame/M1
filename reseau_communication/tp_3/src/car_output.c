#include "./tp_3.h"

int main()
{
     key_t t_key = ftok(SEMAPHORE_PATH, IPC_KEY);

     int t_semaphore_id = semget(t_key, 1, IPC_CREAT|0666);

     if(t_semaphore_id == -1)
     {
          perror("semget");
          return 1;
     }

     while(1)
     {
          if(semop(t_semaphore_id, &t_sembuf[1], 1) != 0)
          {
               perror("semop");
               return 1;
          }
          fprintf(stdout, "Car leave\n");

          sleep(1);
     }

     return 0;
}

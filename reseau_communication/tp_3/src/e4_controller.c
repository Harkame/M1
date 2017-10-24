#include "tp_3.h"

int main()
{
     key_t t_key = ftok(SEMAPHORE_PATH, IPC_KEY);

     if(t_key == -1)
     {
          perror("ftok");
          return 1;
     }

     int t_semaphore_id = semget(t_key, 7, IPC_FLAG);

     if(t_semaphore_id == -1)
     {
          perror("semget");
          return 1;
     }

     fprintf(stdout, "Creation OK\n");

     union semun t_semun;

     ushort t_array[7] = {50, 50, 50, 50, 0, 0, 0};
     t_semun.array = t_array;

     if(semctl(t_semaphore_id, 0, SETALL, t_semun) != 0)
     {
          perror("semctl");
          return 1;
     }

     fprintf(stdout, "Initialization OK\n");

     getchar();

     if(semctl(t_semaphore_id, 0, IPC_RMID) != 0)
     {
          perror("semctl");
          return 1;
     }

     fprintf(stdout, "Destruction OK\n");

     return 0;
}

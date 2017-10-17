#include "./tp_3.h"

int main()
{
     key_t t_key = ftok(SEMAPHORE_PATH, IPC_KEY);

     int* t_semaphore_id = semget(t_key, 3, IPC_CREAT|0666);

     if(t_semaphore_id == -1)
     {
          perror("semget");
          return 1;
     }

     union semun t_semun;
     t_semun.val = 0;

     if(semctl(t_semaphore_id, 0, SETALL, t_semun) == -1)
     {
          perror("semctl");
          return 1;
     }

     fprintf(stdout, "Creation OK\n");

     getchar();

     if(semctl(t_semaphore_id, 0, IPC_RMID) != 0)
     {
          perror("shmctl");
          return 1;
     }

     fprintf(stdout, "Destruction OK\n");

     return 0;
}

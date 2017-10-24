#include "./tp_3.h"

int main(int argc, char** argv)
{
     if(argc < 2)
     {
          fprintf(stderr, "Mauvais argument(s)\n");
          return 1;
     }

     int t_id = atoi(argv[1]);

     key_t t_key = ftok(SEMAPHORE_PATH, IPC_KEY);

     if(t_key == -1)
     {
          perror("ftok");
          return 1;
     }

     int t_semaphore_id = semget(t_key, 3, 0666);

     if(t_semaphore_id == -1)
     {
          perror("semget");
          return 1;
     }

     fprintf(stdout, "\n--- BEGIN ---\n");

     for(int t_index = 0; t_index < 3; t_index++)
     {
          while(semctl(t_semaphore_id, t_index, GETVAL, NULL) != t_id)
          {
               fprintf(stdout, "Activity (%d) is waiting for treatment %d\n", t_id, t_index);
               sleep(1);
          }

          fprintf(stdout, "Semaphore (%d) start work on %d\n", t_id, t_index);

          sleep(2);

          fprintf(stdout, "Semaphore (%d) end work on %d\n", t_id, t_index);

          if(semop(t_semaphore_id, &t_sembuf[1], 1) != 0)
          {
               perror("semop");
               return 1;
          }
     }

     fprintf(stdout, "--- END ---\n");

     return 0;
}

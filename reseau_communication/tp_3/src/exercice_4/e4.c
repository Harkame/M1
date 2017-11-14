#include "./tp_3.h"

int main()
{
     int t_id;

     key_t t_key = ftok(SEMAPHORE_PATH, IPC_KEY);

     if(t_key == -1)
     {
          perror("ftok");
          return 1;
     }

     int t_semaphore_id = semget(t_key, 7, 0666);

     if(t_semaphore_id == -1)
     {
          perror("semget");
          return 1;
     }

     int t_saved_pid = getpid();

     int fd[2];
     char read_buffer[10];
     char t_buffer[10];

     for(int t_index = 0; t_index < 4; t_index++)
     {
          if(getpid() == t_saved_pid)
          {
               if(pipe(fd) != 0)
               {
                    perror("pipe");
                    return 1;
               }

               if(fork() == 0)
               {
                    read(fd[0], read_buffer, 10);
                    t_id = atoi(read_buffer);
                    close(fd[1]);
               }
               else
               {
                    sprintf(t_buffer, "%d", t_index);
                    write(fd[1], t_buffer, 1);
                    close(fd[0]);
               }
          }
     }

     if(getpid() != t_saved_pid)
     {
          fprintf(stdout, "ID : %d\n", t_id);
     }
     else
          wait(NULL);

     return 0;
}

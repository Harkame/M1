#include <stdio.h>
#include <stdlib.h>
#include <unistd.h>
#include <sys/wait.h>
#include <string.h>

char g_message[BUFSIZ];

void foo(int p_length, int p_width)
{
     int t_pipe[2];

     pipe(t_pipe);

     if(p_length > 0)
          for(int t_index = 0; t_index < p_width; t_index++)
               if(fork() == 0)
               {
                   char t_message[BUFSIZ];

                   read(t_pipe[0], t_message, strlen(g_message));

                   fprintf(stdout, "PPID : %d - PID : %d - ", getppid(), getpid());
                   fprintf(stdout, "Message du pere : %s\n", t_message);

                   foo(p_length - 1, p_width);
                }
               else
                    write(t_pipe[1], g_message, strlen(g_message));

     sleep(1000);
}

int main(int argc, char** argv)
{
    fprintf(stdout, "Le message : ");

    scanf("%s", &g_message);

    fprintf(stdout, "\n");

    foo(atoi(argv[1]), atoi(argv[2]));

    return 0;
}

#include <stdio.h>
#include <stdlib.h>

#include <sys/sem.h> //semaphore

#define SEMAPHORE_PATH "./semaphore" //Don't forget to create this file

#define IPC_FLAG 0600
#define IPC_KEY  42

#define MESSAGE_START "\n--- START ---\n"
#define MESSAGE_END "\n--- END ---\n"

#define MESSAGE_SEMAPHORE_CREATION       "Semaphore creation [OK]\n"
#define MESSAGE_SEMAPHORE_INITIALIZATION "Semaphore initialization [OK]\n"
#define MESSAGE_SEMAPHORE_DESTRUCTION   "Semaphore destruction [OK]\n"

#define MESSAGE_INTERACTION_CONTINUE "Please, press enter to continue (destroy semaphore)\n"

#define ERROR_MESSAGE_WRONG_ARGUMENTS "Wrong arguments\n"

#define ERROR_MESSAGE_FTOK "ftok : "

/* ERROR_MESSAGE_SEMAPHORE */
#define ERROR_MESSAGE_SEMGET "semget : "
#define ERROR_MESSAGE_SEMCTL "semctl : "
#define ERROR_MESSAGE_SEMOP "semop : "

typedef union SEMUN
{
     int val; //setval
     struct semid_ds *buf;
     ushort* array; //setall, getall
     struct seminfo *__buf;
     void *__pad;
} SEMUN;

int main(int argc, char** argv)
{
     if(argc < 2)
     {
          fprintf(stderr, ERROR_MESSAGE_WRONG_ARGUMENTS);
          return EXIT_FAILURE;
     }

     key_t t_key = ftok(SEMAPHORE_PATH, IPC_CREAT | IPC_KEY);

     if(t_key == -1)
     {
          perror(ERROR_MESSAGE_FTOK);
          return EXIT_FAILURE;
     }

     int t_semaphore_id = semget(t_key, 3, IPC_CREAT | IPC_FLAG);

     if(t_semaphore_id == -1)
     {
          perror(ERROR_MESSAGE_SEMGET);
          return EXIT_FAILURE;
     }

     fprintf(stdout, MESSAGE_SEMAPHORE_CREATION);

     SEMUN t_semun;

     ushort t_array[3] = {atoi(argv[1]), 0, 1};
     t_semun.array = t_array;

     if(semctl(t_semaphore_id, 0, SETALL, t_semun) == -1)
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

     fprintf(stdout, MESSAGE_SEMAPHORE_DESTRUCTION);

     return EXIT_SUCCESS;
}

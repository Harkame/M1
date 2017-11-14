#include <stdio.h>
#include <stdlib.h>

#include <sys/sem.h> //semaphore
#include <sys/types.h> //getpid
#include <unistd.h>

#define SEMAPHORE_PATH "./semaphore" //Don't forget to create this file

#define IPC_FLAG 0600
#define IPC_KEY  42

#define MESSAGE_PASSENGER_WAITING "The passenger [%d] wait the bus\n"
#define MESSAGE_PASSENGER_ENTER "The passenger [%d] go in the bus\n"
#define MESSAGE_PASSENGER_DROP "The passenger [%d] drop of the bus\n"

#define ERROR_MESSAGE_FTOK "ftok : "

/* ERROR_MESSAGE_SEMAPHORE */
#define ERROR_MESSAGE_SEMGET "semget : "
#define ERROR_MESSAGE_SEMCTL "semctl : "
#define ERROR_MESSAGE_SEMOP "semop : "

struct sembuf t_sembuf[] =
{
     {0, -1, 0},//Take place
     {1, +1, 0},
     {0, +1, 0}, //Free place
     {1, -1, 0},
     {2, 0, 0}
};

int main(void)
{
     key_t t_key = ftok(SEMAPHORE_PATH, IPC_KEY);

     if(t_key == -1)
     {
          perror(ERROR_MESSAGE_FTOK);
          return EXIT_FAILURE;
     }

     int t_semaphore_id = semget(t_key, 3, IPC_FLAG);

     if(t_semaphore_id == -1)
     {
          perror(ERROR_MESSAGE_SEMGET);
          return EXIT_FAILURE;
     }

     fprintf(stdout, MESSAGE_PASSENGER_WAITING, getpid());

     sleep(1);

     if(semop(t_semaphore_id, &t_sembuf[0], 2) == -1)
     {
          perror(ERROR_MESSAGE_SEMOP);
          return EXIT_FAILURE;
     }

     fprintf(stdout, MESSAGE_PASSENGER_ENTER, getpid());

     sleep(1);

     if(semop(t_semaphore_id, &t_sembuf[4], 1) == -1)
     {
          perror(ERROR_MESSAGE_SEMOP);
          return EXIT_FAILURE;
     }

     fprintf(stdout, MESSAGE_PASSENGER_DROP, getpid());

     sleep(1);

     if(semop(t_semaphore_id, &t_sembuf[2], 2) == -1)
     {
          perror(ERROR_MESSAGE_SEMOP);
          return EXIT_FAILURE;
     }

     return EXIT_SUCCESS;
}

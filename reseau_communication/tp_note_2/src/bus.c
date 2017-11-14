#include <stdio.h>
#include <stdlib.h>

#include <sys/sem.h> //semaphore
#include <unistd.h> //sleep

#define SEMAPHORE_PATH "./semaphore" //Don't forget to create this file

#define IPC_FLAG 0600
#define IPC_KEY  42

#define NUMBER_AREAS 4
#define SEMAPHORE_DEFAULT_VALUE 0
#define SEMAPHORE_DEFAULT_VALUES {0, 0, 0, 0}

#define MESSAGE_START "\n--- START ---\n"
#define MESSAGE_END "\n--- END ---\n"

#define MESSAGE_SEMAPHORE_CREATION       "Semaphore creation [OK]\n"
#define MESSAGE_SEMAPHORE_INITIALIZATION "Semaphore initialization [OK]\n"
#define MESSAGE_SEMAPHORE_DESTRUCTION   "Semaphore destruction [OK]\n"

#define MESSAGE_INTERACTION_CONTINUE "Please, press enter to continue (destroy semaphore)\n"
#define MESSAGE_OPEN_DOORS "Open the doors\n"
#define MESSAGE_CLOSE_DOORS "Close the doors\n"
#define MESSAGE_WAITING_PASSENGERS_ENTER "Is waiting for passegers : %d places\n"
#define MESSAGE_WAITING_PASSENGERS_DROPING "Waiting for all passengers drop the bus\n"

#define ERROR_MESSAGE_WRONG_ARGUMENTS "Wrong arguments : <number_total_places>\n"

#define ERROR_MESSAGE_FTOK "ftok : "

/* ERROR_MESSAGE_SEMAPHORE */
#define ERROR_MESSAGE_SEMGET "semget : "
#define ERROR_MESSAGE_SEMCTL "semctl : "
#define ERROR_MESSAGE_SEMOP "semop : "

int main(int argc, char** argv)
{
     if(argc < 2)
     {
          fprintf(stderr, ERROR_MESSAGE_WRONG_ARGUMENTS);
          return EXIT_FAILURE;
     }

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

     struct sembuf t_sembuf[] =
     {
          {0, 0, 0}, //No available places
          {1, 0, 0}, //No Taked places
          {2, +1, 0},
          {2, -1, 0}
     };

     int t_number_total_places = atoi(argv[1]);

     while(1)
     {
          fprintf(stdout, MESSAGE_WAITING_PASSENGERS_ENTER, t_number_total_places);

          if(semop(t_semaphore_id, &t_sembuf[0], 1) == -1)
          {
               perror(ERROR_MESSAGE_SEMOP);
               return EXIT_FAILURE;
          }

          fprintf(stdout, MESSAGE_CLOSE_DOORS);

          fprintf(stdout, MESSAGE_START);

          sleep(3);

          fprintf(stdout, MESSAGE_END);

          fprintf(stdout, MESSAGE_OPEN_DOORS);

          sleep(1);

          if(semop(t_semaphore_id, &t_sembuf[3], 1) == -1)
          {
               perror(ERROR_MESSAGE_SEMOP);
               return EXIT_FAILURE;
          }

          fprintf(stdout, MESSAGE_WAITING_PASSENGERS_DROPING);

          if(semop(t_semaphore_id, &t_sembuf[1], 1) == -1)
          {
               perror(ERROR_MESSAGE_SEMOP);
               return EXIT_FAILURE;
          }

          if(semop(t_semaphore_id, &t_sembuf[2], 1) == -1)
          {
               perror(ERROR_MESSAGE_SEMOP);
               return EXIT_FAILURE;
          }
     }

     return EXIT_SUCCESS;
}

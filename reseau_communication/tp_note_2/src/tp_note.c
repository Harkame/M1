#include <stdio.h>
#include <stdlib.h>

#include <sys/shm.h> //shared_memory
#include <sys/sem.h> //semaphore
#include <sys/msg.h> //queue
#include <unistd.h> //getpid, sleep

#define SEMAPHORE_PATH "./semaphore" //Don't forget to create this file

#define IPC_FLAG 0600
#define IPC_KEY  42

#define NUMBER_AREAS 4
#define SEMAPHORE_DEFAULT_VALUE 0
#define SEMAPHORE_DEFAULT_VALUES {0, 0, 0, 0}

#define MESSAGE_START "\n--- START ---\n"
#define MESSAGE_END "\n--- END ---\n"

#define MESSAGE_SEMAPHORE_CREATION           "Semaphore creation [OK]\n"
#define MESSAGE_SEMAPHORE_INITIALIZATION "Semaphore initialization [OK]\n"
#define MESSAGE_SEMAPHORE_DESTRUCTION   "Semaphore destruction [OK]\n"

#define MESSAGE_INTERACTION_CONTINUE "Please, press enter to continue (destroy semaphore)\n"

#define ERROR_MESSAGE_WRONG_ARGUMENTS "Wrong arguments\n"

#define ERROR_MESSAGE_FTOK "ftok : "

/* ERROR_MESSAGE_QUEUE */
#define ERROR_MESSAGE_MSGGET "msgget :"
#define ERROR_MESSAGE_MSGSND "msgsnd :"
#define ERROR_MESSAGE_MSGRCV "msgrcv :"

/* ERROR_MESSAGE_SHARED_MEMORY */
#define ERROR_MESSAGE_SHMGET "shmget :"
#define ERROR_MESSAGE_SHMAT "shmat :"
#define ERROR_MESSAGE_SHMDT "shmdt :"

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

struct sembuf g_sembuf[] =
{
     {0, -1, 0},
     {0, +1, 0},
     {0, 0, 0} //Wait for 0
};

typedef struct DATA
{
 int a_value;
} DATA;

int main(int argc, char** argv)
{
     if(argc < 3) //To change
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

     //Avoid controller using
     /*
     int t_semaphore_id = semget(t_key, 2, IPC_FLAG | IPC_CREAT | IPC_EXCL );
	if (t_semaphore_id < 0)
	{
		fprintf(stdout, "Semaphore alreadt created\n");

		t_semaphore_id = semget(t_key, 2, IPC_FLAG);

		if(sem_id < 0)
          {
			fprintf(stderr, ERROR_MESSAGE_SEMGET);
			return EXIT_FAILURE;
		}
	}
     else
     {
		printf("Creation Semaphore\n");
		//intialise les semaphores
		int sarray[2]={0,nbProcessusEmploye};
		semctl(sem_id, 0, SETALL, sarray);
	}
     */

     return EXIT_SUCCESS;
}

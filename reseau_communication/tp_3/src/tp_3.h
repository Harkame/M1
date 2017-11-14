#ifndef TP_3_H_
#define TP_3_H_

#include <stdio.h>
#include <stdlib.h>

#include <sys/shm.h> //shared_memory
#include <sys/sem.h> //semaphore
#include <unistd.h> //sleep

#define SEMAPHORE_PATH "./semaphore"

#define IPC_FLAG 0600
#define IPC_KEY  42

#define NUMBER_AREAS 4
#define SEMAPHORE_DEFAULT_VALUE 0
#define SEMAPHORE_DEFAULT_VALUES {0, 0, 0, 0}

#define MESSAGE_START "\n--- START ---\n"
#define MESSAGE_END "\n--- END ---\n"

#define MESSAGE_SEMAPHORE_CREATION                  "Semaphore creation [OK]\n"
#define MESSAGE_SEMAPHORE_INITIALIZATION        "Semaphore initialization [OK]\n"
#define MESSAGE_SEMAPHORE_DESTRUCTION "Semaphore destruction [OK]\n"

#define MESSAGE_INTERACTION_CONTINUE "Please, press enter to continue (destroy semaphore)\n"

#define ERROR_MESSAGE_WRONG_ARGUMENTS "Wrong arguments\n"

#define ERROR_MESSAGE_FTOK "ftok : "
#define ERROR_MESSAGE_SEMGET "semget : "
#define ERROR_MESSAGE_SEMCTL "semctl : "
#define ERROR_MESSAGE_SEMOP "semop : "

struct sembuf g_sembuf_2[] =
{
     {0, -1, 0},
     {0, 0, 0},
};

struct sembuf g_sembuf_3[] =
{
     {0, +1,  0},
     {1, +1,  0},
     {2, +1,  0}
};

typedef union SEMUN
{
     int val; //setval
     struct semid_ds *buf;
     ushort* array; //setall, getall
     struct seminfo *__buf;
     void *__pad;
} SEMUN;

#endif

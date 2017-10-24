#ifndef TP_3_H_
#define TP_3_H_

#include <stdio.h>
#include <stdlib.h>
#include <sys/ipc.h>
#include <sys/stat.h>
#include <sys/types.h>
#include <sys/msg.h>
#include <unistd.h>
#include <sys/ipc.h>
#include <sys/shm.h>
#include <sys/sem.h>
#include <sys/wait.h>
#include <unistd.h>
#include <sys/types.h>

#define IPC_PATH "/auto_home/ldaviaud/tp_3"
#define SEMAPHORE_PATH "/auto_home/ldaviaud/tp_3_semaphore"

#define IPC_FLAG IPC_CREAT | 0666
#define IPC_KEY  42

struct sembuf t_sembuf[] =
{
     {(u_short) 0, (short) +1,  0},
     {(u_short) 1, (short) +1,  0},
     {(u_short) 2, (short) +1,  0}
};

union semun
{
     int val;                /* value for SETVAL */
     struct semid_ds *buf;   /* buffer for IPC_STAT & IPC_SET */
     ushort *array;          /* array for GETALL & SETALL */
     struct seminfo *__buf;  /* buffer for IPC_INFO */
     void *__pad;
};

#endif

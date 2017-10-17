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

#define IPC_PATH "/auto_home/ldaviaud/tp_3"
#define SEMAPHORE_PATH "/auto_home/ldaviaud/tp_3.txt"

#define IPC_FLAG IPC_CREAT | 0600
#define IPC_KEY  42

struct sembuf t_sembuf[] =
{
     {0, -1,  SEM_UNDO},
     {0, +1,  SEM_UNDO},
     {0, 0,  SEM_UNDO}
};

union semun
{
     int val;
};

#endif

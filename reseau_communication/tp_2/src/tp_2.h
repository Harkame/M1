#ifndef TP_2_H
#define TP_2_H

#include <stdio.h>
#include <stdlib.h>

#include <sys/msg.h> //queue
#include <unistd.h> //getpid, sleep

#define IPC_PATH "/auto_home/ldaviaud/calculatrice"
#define IPC_KEY  42
#define IPC_FLAG 0600

#define LABEL_REQUEST 43
#define LABEL_RESPONSE 44

typedef struct CALCULATRICE_REQUEST
{
          long a_label;

          long a_pid;

          char a_operator;

          int a_operand_a;
          int a_operand_b;
} CALCULATRICE_REQUEST;

typedef struct CALCULATRICE_RESPONSE
{
          long a_label;

          int a_result;
} CALCULATRICE_RESPONSE;

#endif

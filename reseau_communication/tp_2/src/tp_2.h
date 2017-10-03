#ifndef TP_2_H
#define TP_2_H

#include <stdio.h>
#include <stdlib.h>
#include <sys/ipc.h>
#include <sys/stat.h>
#include <sys/types.h>
#include <sys/msg.h>
#include <unistd.h>

#define IPC_PATH "/auto_home/ldaviaud/calculatrice"
#define IPC_KEY  42
#define IPC_FLAG 0600

#define LABEL_REQUEST 43
#define LABEL_RESPONSE 44

struct CALCULATRICE_REQUEST
{
          long a_label;

          long a_pid;

          char a_operator;

          int a_operand_a;
          int a_operand_b;
};

struct CALCULATRICE_RESPONSE
{
          long a_label;

          int a_result;
};

#endif

#ifndef TP_4_H
#define TP_4_H

#include <stdlib.h>
#include <stdio.h>
#include <sys/socket.h>
#include <netinet/in.h>
#include <arpa/inet.h>
#include <sys/types.h>
#include <netdb.h>
#include <string.h>

#define PROMPT_MESSAGE "> "

#define MESSAGE_WAITING "Wait message\n"
#define MESSAGE_RECEIVED "Message received\n"

#define MESSAGE_DATA_VALUE "DATA : - %d - %d - %s"

#define SUCCESS_SENTO "Message sended\n"

#define ERROR_MISSING_ARGUMENTS "Missing argument(s)\n"
#define ERROR_SOCKET_CREATION   "socket\n"
#define ERROR_SOCKET_SENTO      "sento\n"
#define ERROR_SOCKET_BIND       "bind\n"

typedef struct DATA
{
     int a_value_a;
     int a_value_b;

     char a_value_c[50];

} DATA;

#endif

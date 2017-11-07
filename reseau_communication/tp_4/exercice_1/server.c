#include "../tp_4.h"

int main(int argc, char** argv)
{
     if(argc < 2)
     {
          fprintf(stderr, ERROR_MISSING_ARGUMENTS);
          return EXIT_FAILURE;
     }

     int t_socket = socket(AF_INET, SOCK_DGRAM, 0);

     if(t_socket == EXIT_FAILURE)
     {
          fprintf(stderr, ERROR_SOCKET_CREATION);
          return EXIT_FAILURE;
     }

     struct sockaddr_in t_sockaddr_in;

     t_sockaddr_in.sin_addr.s_addr = INADDR_ANY;
     t_sockaddr_in.sin_family      = AF_INET;
     t_sockaddr_in.sin_port        = htons(atoi(argv[1]));

     if(bind(t_socket, (struct sockaddr*) &t_sockaddr_in, sizeof(t_sockaddr_in)) != EXIT_SUCCESS)
     {
          fprintf(stderr, ERROR_SOCKET_BIND);
          return EXIT_FAILURE;
     }

     char t_buffer[50];

     struct sockaddr_in addr;
     socklen_t fromlen = sizeof(struct sockaddr_in);

     fprintf(stdout, MESSAGE_WAITING);

     ssize_t t_received_bytes = recvfrom(t_socket, t_buffer, sizeof(t_buffer), 0, (struct sockaddr*)&addr, &fromlen);

     if(t_received_bytes == EXIT_FAILURE)
     {
          fprintf(stderr, ERROR_SOCKET_SENTO);
          return EXIT_FAILURE;
     }

     fprintf(stdout, "t_buffer : %s\n", t_buffer);

     fprintf(stdout, PROMPT_MESSAGE);
     if(fgets(t_buffer, 50, stdin) == NULL)
     {
          return EXIT_FAILURE;
     }

     ssize_t t_sended_bytes = sendto(t_socket, t_buffer, strlen(t_buffer), 0, (struct sockaddr *)&addr, sizeof(struct sockaddr_in));

     if(t_sended_bytes == EXIT_FAILURE)
     {
          fprintf(stdout, ERROR_SOCKET_SENTO);
          return EXIT_FAILURE;
     }

     fprintf(stdout, "Sended : %lu\n", t_sended_bytes);

     fprintf(stdout, PROMPT_MESSAGE);
     if(fgets(t_buffer, 50, stdin) == NULL)
     {
          return EXIT_FAILURE;
     }
     t_sended_bytes = sendto(t_socket, t_buffer, strlen(t_buffer), 0, (struct sockaddr *)&addr, sizeof(struct sockaddr_in));

     if(t_sended_bytes == EXIT_FAILURE)
     {
          fprintf(stdout, ERROR_SOCKET_SENTO);
          return EXIT_FAILURE;
     }

     fprintf(stdout, "Sended : %lu\n", t_sended_bytes);

     fprintf(stdout, PROMPT_MESSAGE);
     if(fgets(t_buffer, 50, stdin) == NULL)
     {
          return EXIT_FAILURE;
     }
     t_sended_bytes = sendto(t_socket, t_buffer, strlen(t_buffer), 0, (struct sockaddr *)&addr, sizeof(struct sockaddr_in));

     if(t_sended_bytes == EXIT_FAILURE)
     {
          fprintf(stdout, ERROR_SOCKET_SENTO);
          return EXIT_FAILURE;
     }

     fprintf(stdout, "Sended : %lu\n", t_sended_bytes);

     return EXIT_SUCCESS;
}

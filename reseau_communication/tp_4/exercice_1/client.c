#include "../tp_4.h"

int main(int argc, char** argv)
{
     if(argc < 3)
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

     struct sockaddr_in t_sockaddr_in_client;

     t_sockaddr_in_client.sin_addr.s_addr = inet_addr(argv[1]);
     t_sockaddr_in_client.sin_family      = AF_INET;
     t_sockaddr_in_client.sin_port        = htons(atoi(argv[2]));

     char t_buffer[50];

     fprintf(stdout, PROMPT_MESSAGE);
     if(fgets(t_buffer, 50, stdin) == NULL)
     {
          return EXIT_FAILURE;
     }

     ssize_t t_sended_bytes = sendto(t_socket, t_buffer, strlen(t_buffer), 0, (struct sockaddr *)&t_sockaddr_in_client, sizeof(t_sockaddr_in_client));

     if(t_sended_bytes == EXIT_FAILURE)
     {
          fprintf(stderr, ERROR_SOCKET_SENTO);
          return EXIT_FAILURE;
     }

     fprintf(stdout, "Sended : %lu\n", t_sended_bytes);

     fprintf(stdout, SUCCESS_SENTO);

     DATA t_data;
     struct sockaddr_in addr;
     socklen_t fromlen = sizeof(struct sockaddr_in);

     ssize_t t_received_bytes = recvfrom(t_socket, t_buffer, sizeof(t_buffer), 0, (struct sockaddr*)&addr, &fromlen);

     if(t_received_bytes == EXIT_FAILURE)
     {
          fprintf(stderr, ERROR_SOCKET_SENTO);
          return EXIT_FAILURE;
     }

     t_data.a_value_a = atoi(t_buffer);

     t_received_bytes = recvfrom(t_socket, t_buffer, sizeof(t_buffer), 0, (struct sockaddr*)&addr, &fromlen);

     if(t_received_bytes == EXIT_FAILURE)
     {
          fprintf(stderr, ERROR_SOCKET_SENTO);
          return EXIT_FAILURE;
     }

     t_data.a_value_b = atoi(t_buffer);

     t_received_bytes = recvfrom(t_socket, t_buffer, sizeof(t_buffer), 0, (struct sockaddr*)&addr, &fromlen);

     if(t_received_bytes == EXIT_FAILURE)
     {
          fprintf(stderr, ERROR_SOCKET_SENTO);
          return EXIT_FAILURE;
     }

     strcpy(t_data.a_value_c, t_buffer);

     fprintf(stdout, MESSAGE_DATA_VALUE, t_data.a_value_a, t_data.a_value_b, t_data.a_value_c);

     return EXIT_SUCCESS;
}

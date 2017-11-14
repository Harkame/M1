#include "./tp_2.h"

int main(int argc, char** argv)
{
     if(argc < 4)
     {
          fprintf(stderr, "Mauvais arguments\n");
          return EXIT_SUCCESS;
     }

     CALCULATRICE_REQUEST t_calculatrice_request;
     CALCULATRICE_RESPONSE t_calculatrice_response;

     key_t t_key = ftok(IPC_PATH, IPC_KEY);

     int t_queue_id = msgget(t_key, IPC_FLAG);

     t_calculatrice_request.a_label = argv[2][0];
     t_calculatrice_request.a_pid = getpid();
     t_calculatrice_request.a_operand_a = atoi(argv[1]);
     t_calculatrice_request.a_operand_b = atoi(argv[3]);

     fprintf(stdout, "Send request\n");
     sleep(2);

     if(msgsnd(t_queue_id, &t_calculatrice_request, sizeof(CALCULATRICE_REQUEST), 0) == -1)
     {
          perror("msgsnd : ");
          return EXIT_FAILURE;
     }

     fprintf(stdout, "Wait response\n");
     if(msgrcv(t_queue_id, &t_calculatrice_response, sizeof(CALCULATRICE_RESPONSE), getpid(), 0) == -1)
     {
          perror("msgsnd : ");
          return EXIT_FAILURE;
     }

     fprintf(stdout, "Result : %d\n", t_calculatrice_response.a_result);

     return EXIT_SUCCESS;
}

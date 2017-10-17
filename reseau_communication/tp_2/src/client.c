#include "./tp_2.h"

int main(int argc, char** argv)
{
     if(argc < 4)
     {
                    fprintf(stderr, "Mauvais arguments\n");
                    return 1;
     }

     struct CALCULATRICE_REQUEST t_calculatrice_request;
     struct CALCULATRICE_RESPONSE t_calculatrice_response;

     key_t t_key = ftok(IPC_PATH, IPC_KEY);

     int t_queue_id = msgget(t_key, IPC_FLAG);

     t_calculatrice_request.a_label = argv[2][0];
     t_calculatrice_request.a_pid = getpid();
     t_calculatrice_request.a_operand_a = atoi(argv[1]);
     t_calculatrice_request.a_operand_b = atoi(argv[3]);

     fprintf(stdout, "Send request\n");
     sleep(2);
     if(msgsnd(t_queue_id, &t_calculatrice_request, sizeof(struct CALCULATRICE_REQUEST), 0) == -1)
     {
          perror("msgsnd : ");
          exit(1);
     }

     fprintf(stdout, "Wait response\n");
     if(msgrcv(t_queue_id, &t_calculatrice_response, sizeof(struct CALCULATRICE_RESPONSE), getpid(), 0) == -1)
     {
          perror("msgsnd : ");
          exit(1);
     }

     fprintf(stdout, "Result : %d\n", t_calculatrice_response.a_result);

     return 0;
}

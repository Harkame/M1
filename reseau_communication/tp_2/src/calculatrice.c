#include "./tp_2.h"

int main(int argc, char** argv)
{
     if(argc < 2)
     {
               fprintf(stderr, "Pas d'operateur\n");
               return 1;
     }

     char t_char = argv[1][0];

     CALCULATRICE_REQUEST t_calculatrice_request;
     CALCULATRICE_RESPONSE t_calculatrice_response;

     key_t t_key = ftok(IPC_PATH, IPC_KEY);
     int t_queue_id = msgget(t_key, IPC_CREAT | 0666);

     while(1)
     {
          fprintf(stdout, "Wait request\n");
          if(msgrcv(t_queue_id, &t_calculatrice_request, sizeof(CALCULATRICE_REQUEST), t_char, 0) == -1)
          {
               perror("mesgrcv : ");
               return EXIT_FAILURE;
          }

          fprintf(stdout, "Request acquiered : start calcul\n");
          sleep(2);

          t_calculatrice_response.a_label = t_calculatrice_request.a_pid;

          fprintf(stdout, "%d %c %d\n", t_calculatrice_request.a_operand_a,
          t_char,
          t_calculatrice_request.a_operand_b);

          switch(t_char)
          {
               case '+':
                    t_calculatrice_response.a_result = t_calculatrice_request.a_operand_a + t_calculatrice_request.a_operand_b;
               break;

               case '-':
                    t_calculatrice_response.a_result = t_calculatrice_request.a_operand_a - t_calculatrice_request.a_operand_b;
               break;

               case '*':
                    t_calculatrice_response.a_result = t_calculatrice_request.a_operand_a * t_calculatrice_request.a_operand_b;
               break;

               case '/':
                    t_calculatrice_response.a_result = t_calculatrice_request.a_operand_a / t_calculatrice_request.a_operand_b;
               break;
          }

          fprintf(stdout, "Send response\n");
          sleep(2);
          if(msgsnd(t_queue_id, &t_calculatrice_response, sizeof(CALCULATRICE_RESPONSE), 0) == -1)
          {
               perror("mesgrcv : ");
               return EXIT_FAILURE;
          }
     }

     if(msgctl(t_queue_id, IPC_RMID, NULL) == -1)
     {
               perror("msgctl : ");
               return EXIT_FAILURE;
     }

     return EXIT_SUCCESS;
}

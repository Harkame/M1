#include "./tp_2.h"

int main(int argc, char** argv)
{
     char t_char = argv[1][0];

     struct CALCULATRICE_REQUEST t_calculatrice_request;
     struct CALCULATRICE_RESPONSE t_calculatrice_response;

     key_t t_key = ftok(IPC_PATH, IPC_KEY);
     int t_queue_id = msgget(t_key, IPC_CREAT | 0666);


     while(1)
     {
          fprintf(stdout, "Wait request\n");
          if(msgrcv(t_queue_id, &t_calculatrice_request, sizeof(struct CALCULATRICE_REQUEST), t_char, 0) == -1)
          {
               perror("mesgrcv : ");
               exit(1);
          }

          fprintf(stdout, "Request acquiered : start calcul\n");
          sleep(2);

          t_calculatrice_response.a_label = t_calculatrice_request.a_pid;

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
          if(msgsnd(t_queue_id, &t_calculatrice_response, sizeof(struct CALCULATRICE_RESPONSE), 0) == -1)
          {
               perror("mesgrcv : ");
               exit(1);
          }
     }

     if(msgctl(t_queue_id, IPC_RMID, NULL) == -1)
     {
               perror("msgctl : ");
               return -1;
     }

     return 0;
}

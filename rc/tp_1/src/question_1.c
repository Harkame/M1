#include <stdlib.h>
#include <stdio.h>
#include <pthread.h>

void* foo_1(void* p_param)
{
     //exit(0); //Stop the process

     for(int t_index = 0; t_index < 100; t_index++)
          fprintf(stdout, "1 : i = %d\n", ++(*(int* )p_param));
}

void* foo_2(void* p_param)
{
     for(int t_index = 0; t_index < 100; t_index++)
          fprintf(stdout, "2 : i = %d\n", ++(*(int* )p_param));
}

int main()
{
     pthread_t t_thread_1;
     pthread_t t_thread_2;

     int t_value = 42;

     pthread_create(&t_thread_1, NULL, foo_1, &t_value);
     pthread_create(&t_thread_2, NULL, foo_2, &t_value);

     pthread_join(t_thread_1, NULL);
     pthread_join(t_thread_2, NULL);

     fprintf(stdout, "\nValeur final de i : %d\n", t_value);

     return 0;
}

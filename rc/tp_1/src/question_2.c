#include <stdlib.h>
#include <stdio.h>
#include <pthread.h>

#define SIZE 3
#define VALUES_A {0, 3, 6}
#define VALUES_B {0, 2, 5}

void* vector_operation(void* p_param)
{
     int* t_param = p_param;

     int* r_result = malloc(sizeof(int));

     fprintf(stdout, "%d * %d\n", t_param[0], t_param[1]);

     *r_result = t_param[0] * t_param[1];

     pthread_exit(r_result);
}

int main()
{
     pthread_t t_threads[SIZE];

     int t_array_a[SIZE] = VALUES_A;
     int t_array_b[SIZE] = VALUES_B;

     for(int t_index = 0; t_index < SIZE; t_index++)
     {
          int* t = malloc(2 * sizeof(int));
          t[0] = t_array_a[t_index];
          t[1] = t_array_b[t_index];

          pthread_create(&t_threads[t_index], NULL, vector_operation, t);
     }

     int t_sum_vectors_operation = 0;

     int* t_result_vectors_operation;

     for(int t_index = 0; t_index < SIZE; t_index++)
     {
          pthread_join(t_threads[t_index], (void**) &t_result_vectors_operation);

          t_sum_vectors_operation += *t_result_vectors_operation;

          free(t_result_vectors_operation);
     }

     fprintf(stdout, "Produit scalaire : %d\n", t_sum_vectors_operation);

     return 0;
}

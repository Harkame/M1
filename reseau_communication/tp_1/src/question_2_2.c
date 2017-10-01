#include <stdlib.h>
#include <stdio.h>
#include <pthread.h>

#define SIZE 3
#define VALUES_A {0, 3, 6}
#define VALUES_B {0, 2, 5}

pthread_mutex_t g_mutex = PTHREAD_MUTEX_INITIALIZER;
int g_sum = 0;

void* vector_operation(void* p_param)
{
     int* t_param = p_param;

     fprintf(stdout, "%d * %d\n", t_param[0], t_param[1]);

     pthread_mutex_lock(&g_mutex);
     g_sum += t_param[0] * t_param[1];
     pthread_mutex_unlock(&g_mutex);
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

     for(int t_index = 0; t_index < SIZE; t_index++)
          pthread_join(t_threads[t_index], NULL);

     fprintf(stdout, "Produit scalaire : %d\n", g_sum);

     return 0;
}

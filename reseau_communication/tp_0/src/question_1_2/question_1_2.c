#include <stdio.h>
#include <stdlib.h>

#define ARRAY_VALUES {1, 3, 5, 7, 9}
#define ARRAY_SIZE 5

int* extract(int p_array_int[], int p_array_size, int p_born_min, int p_born_max)
{
     int t_count_between_born = 0;

     for(int t_index = 0; t_index < p_array_size; t_index++)
          if(p_array_int[t_index] >= p_born_min &&
          p_array_int[t_index] <= p_born_max)
               t_count_between_born++;

     int* r_array_filtred = malloc(sizeof(int) * t_count_between_born);

     int t_count_insertion = 0;

     for(int t_index = 0; t_index < p_array_size; t_index++)
          if(p_array_int[t_index] >= p_born_min &&
          p_array_int[t_index] <= p_born_max)
               r_array_filtred[t_count_insertion++] = p_array_int[t_index];

     p_array_size = t_count_between_born;

     return r_array_filtred;
}

int main()
{
     int t_array_int[ARRAY_SIZE] = ARRAY_VALUES;
     int t_array_size = 5;

     int t_born_min = 2;
     int t_born_max = 5;

     int* t_array_filtred = extract(t_array_int, t_array_size, t_born_min, t_born_max);

     for(int t_index = 0; t_index < t_array_size; t_index++)
          fprintf(stdout, "%d\n", t_array_filtred[t_index]);

     free(t_array_filtred);

     return 0;
}

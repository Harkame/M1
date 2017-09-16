#include <stdio.h>
#include <stdlib.h>

#define ARRAY_VALUES {1, 3, 5, 7, 9}
#define ARRAY_SIZE 5

int array_sum(int p_array[], int p_index)
{
     if(p_index == 0)
          return p_array[p_index];
     else
          return p_array[p_index] + array_sum(p_array, p_index - 1);
}

int main()
{
     int t_array_size;

     fprintf(stdout, "La taille du tableau : ");

     scanf("%d", &t_array_size);

     fprintf(stdout, "\n");

     int t_array[t_array_size];

     for(int t_index = 0; t_index < t_array_size; t_index++)
     {
          fprintf(stdout, "Element(s) restant(s) : %d\n", t_array_size - t_index);
          scanf("%d", &t_array[t_index]);
     }

     int t_array_sum = array_sum(t_array, t_array_size);

     fprintf(stdout, "Somme : %d\n", t_array_sum);

     return 0;
}

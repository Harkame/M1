#include <stdio.h>
#include <stdlib.h>
#include <unistd.h>

void foo(int p_length, int p_width)
{
     if(p_length > 0)
          for(int t_index = 0; t_index < p_width; t_index++)
               if(fork() == 0)
                    foo(p_length - 1, p_width);

     sleep(1000);
}

int main(int argc, char** argv)
{
     foo(atoi(argv[1]), atoi(argv[2]));

     return 0;
}

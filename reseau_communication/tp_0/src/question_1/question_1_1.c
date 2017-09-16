#include <stdio.h>
#include <stdlib.h>

int main()
{
     int a = 10 ;
     int b = 25 ;

     int* p  = &b ;
     int* pp = &a ;

     fprintf(stdout, "1. %d\n", *(&(*(*(&p)))));

     fprintf(stdout, "2. %d\n", *(p - 1));

     fprintf(stdout, "3. %d\n", *(*(&p) -1));

     fprintf(stdout, "4. %d\n", *(*(&pp) + 1));

     fprintf(stdout, "5. %d\n", *(&(*(*(&p))) - 1));


     return 0;
}

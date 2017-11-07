#include <stdlib.h>
#include <stdio.h>

void main(void)
{
	int i = 2;

	if((i = 3 == 3))
		fprintf(stdout, "Oui %d\n", i);
	else
		fprintf(stdout, "Non %d\n", i);
}

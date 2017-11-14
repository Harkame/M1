GCC = gcc -ansi -Wpedantic -pedantic -pedantic-errors -W -Wall -Wextra -Werror -Wfatal-errors  -std=gnu99 -O3

main: e1

e1:
	${GCC} ./example_shared_memory/example_shared_memory.c -o ./example_shared_memory/example_shared_memory.out
	${GCC} ./exercice_2/exercice_2_controller.c -o ./exercice_2/exercice_2_controller.out;
	${GCC} ./exercice_2/exercice_2.c -o ./exercice_2/exercice_2.out;
	${GCC} ./exercice_3/exercice_3_controller.c -o ./exercice_3/exercice_3_controller.out;
	${GCC} ./exercice_3/exercice_3.c -o ./exercice_3/exercice_3.out;

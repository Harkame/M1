.data
	g_array: .space 12

.text
	main:
		la $t0, g_array
		
	initialize_array:		
		li $t1, 1
		sw $t1, 0($t0)
		li $t1, 2
		sw $t1, 4($t0)
		li $t1, 3
		sw $t1, 8($t0)
		
		li $t1, 1
		sw $t1, 0($t0)
		li $t1, 2
		sw $t1, 4($t0)
		li $t1, 3
		sw $t1, 8($t0)
		
	reverse_array:
		lw $t1, 0($t0)
		lw $t2, 4($t0)
		lw $t3, 8($t0)
		
		sw $t1, 8($t0)
		sw $t2, 4($t0)
		sw $t3, 0($t0)
		
	end:
		li $v0, 10
		syscall

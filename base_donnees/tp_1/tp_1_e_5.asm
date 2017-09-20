.data
	value_1: .word 1
	value_2: .word 2
	
.text
	main:
	
	swap:
		addi $sp, $sp, -4
		
		la $t0, value_1
		sw $t0, 4($sp)
		
		la $t0, value_2
		lw $t0, value_1
		
		la $t0, 0($sp)
		lw $t0, value_2
		
		addi $sp, $sp, 4
		
		

	end:
		li $v0, 10
		syscall
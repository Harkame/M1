.text
	main:
		li $v0, 5
		syscall
		
		move $t0, $v0
		
		li $t1, 0
		
	loop:
		addi $t1, $t1, 1
		move $a0,  $t1
		li $v0, 1
		syscall
		blt $t1, $t0, loop
		
	end:
		li $v0, 10
		syscall

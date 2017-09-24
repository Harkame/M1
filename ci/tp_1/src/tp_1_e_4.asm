.data
	message_paire: .asciiz "Paire\n"
	message_impaire: .asciiz "Impaire\n"

.text
	main:
		li $v0, 5
		syscall
		
		move $t0, $v0
		
		li $t1, 2
		
		div $t0, $t1
		
		mfhi $t3
		
		bnez $t3, paire
		
	paire:
		la $a0, message_paire
		li $v0, 4
		syscall
		j end
	
	impaire:
		la $a0, message_impaire
		li $v0, 4
		syscall
		
	end:
		li $v0, 10
		syscall
	

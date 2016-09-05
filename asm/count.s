# компилируем и линкуем
#gcc -o libc_at_t libc_at_t.S
.data
	printf_format:
		.string "EAX=%d\n"
.text
.globl main
main:
	mov $0, %rdi /* в %eax будет результат, поэтому в начале его нужно обнулить*/
	mov $10, %rcx /* 10 шагов цикла */
sum:
	.p2align 2
	add %rcx, %rdi
	loop sum /* %eax = %eax + %ecx */
	/* %eax = 55, %ecx = 0 */

	/*
	* следующий код выводит число в %eax на экран и завершает программу
	*/
	mov $0, %rax
	mov %rdi, %rdi
	mov $printf_format, %rsi
	mov $0, %rdx
	call printf

	mov $0, %rax
	ret


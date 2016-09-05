.data
msg: .ascii "hello!"
.text
  .globl main
main:
	mov $4, %rax
	pushq %rax
	ret

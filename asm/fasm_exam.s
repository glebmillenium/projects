;вызов системных функций на ассемблере Unix64
format ELF64 executable 3
entry start
include 'import64.inc'
interpreter '/lib64/ld-linux-x86-64.so.2'
needed 'libc.so.6'
import exit, gets, printf
segment readable executable
start:
;в начале организуем стек
push rbp
mov  rbp,rsp
;выделить стек, чтобы в дальнейшем передать через него параметры
sub  rsp,32
;получить строку
mov rdx,1
mov  rsi,100
mov  rdi, buf
call [gets]
;вывод данных с помощью функции printf
;в начале выделим стек для стековых параметров (их будет три)
;параметры
mov  rdi,frmt
mov  rsi,buf
mov  rdx,32
mov  rcx,64
mov  r8,128
mov  r9,256
mov rax,512
mov  [rsp],rax
mov rax,1024
mov [rsp+8],rax
mov rax,2048
mov [rsp+16],rax
call [printf]
;восстановить стек
mov rsp,rbp
pop rbp
;выход из программы
mov  rdi,0
call [exit]
segment readable writeable
buf   db 100 dup(0)
frmt  db "%s %d %d %d %d %d %d %d ",10,0



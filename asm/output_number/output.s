# компилируем и линкуем
#gcc -o libc_at_t libc_at_t.S
.include "gnumacro.S"
.text
 
# объявляем глобальную метку main
.global main
main:
    cinvoke puts, $msg      # выводим "Enter A:"
    cinvoke scanf, $tpi, $varA  # вводим varA
    incb    msg1                    # превращаем A в B
    cinvoke scanf, $tpi, $varB  # выводим "Enter B:"
    movl    varA, %eax      
    addl    varB, %eax              # eax = varA + varB
    mov %eax, varC      # varC = eax
    cinvoke printf, $tpt, varC      # выводим на экран
    call    getchar         # ждём <ANY key>
    invoke  exit, $0        # выход, код 0
    
.data
varA:   .long   0
varB:   .long   0
varC:   .long   0
msg:    .asciz  "Enter A:"
msg1    = .-3
tpi:    .asciz  "%d"        # шаблон для ввода
tpt:    .asciz  "varC=%d\n\r"   # шаблон для вывода
    

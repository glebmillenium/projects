# компилируем и линкуем
#gcc -o libc_at_t libc_at_t.S
.code32 
.text
 
# объявляем глобальную метку main
.global main
main:
    push    $msg
    call    puts        # выводим "Enter A:"
    add $4, %esp
    push    $varA
    push    $tpi
    call    scanf       # вводим varA
    add $8, %esp
    incb    msg1
    push    $msg
    call    puts        # выводим "Enter B:"
    add $4, %esp
    push    $varB
    push    $tpi
    call    scanf       # вводим varB
    add $8, %esp
 
    mov varA,%eax
    add varB,%eax   # eax = varA + varB
    mov %eax, varC  # varC = eax
    pushl    %eax        # значение
    push    $tpt        # указатель на шаблон
    call    printf      # функция форматированного вывода на консоль
    add $8,%esp     # выталкиваем аргументы из стека
    call    getchar     # ждём <ANY key>
    pushl   $0
    call    exit            # выход, код 0
    
.data
varA:   .long   0
varB:   .long   0
varC:   .long   0
msg:    .asciz  "Enter A:"
msg1    = .-3
tpi:    .asciz  "%d"        # шаблон для ввода
tpt:    .asciz  "EAX=%d\n\r"    # шаблон для вывода

.altmacro
/*
; (c) 2008-2009 by MichaelW.
; some kludges (#) 2014 by Charles Kludge.
; _*requres GNU as 2.20 or later.*_
; For irp the statements are assembled at least once, so in
; the ifnc blocks that count the arguments detecting a
; no-args condition requires a check for a null argument.
;
; The clumsy double-loop arrangement is the only compact and
; flexible method that I could find to push the arguments in
; right to left order.
;
; These macros are coded to minimize the number of loops (an
; exitm directive in a loop exits the innermost loop only).
;
; These macros work correctly with no optional arguments.
;
; The cinvoke macro assumes 32-bit arguments. Byte or word
; arguments can be passed by zero or sign extending them
; into a 32-bit register and passing the register. Qword
; arguments can be passed as two dword arguments, with the
; low-order dword on the left and the high-order dword on
; the right, as they appear in the cinvoke statement.
;
; Because the cinvoke macro calls the invoke macro, certain
; types of errors in the cinvoke macro arguments will cause
; errors to be reported for both macros.
*/
 
.macro invoke, func:req, args:vararg
    n=0
    .irp arg,\args
      .ifnc \arg,
        n=n+1
      .endif
    .endr
    .if n>0
      i=n
      .irp junk,\args
        j=0
        .irp arg,\args
          j=j+1
          .if j==i
            push \arg
            .exitm
          .endif
        .endr
        i=i-1
      .endr
    .endif
    call \func
.endm
 
.macro cinvoke, func:req, args:vararg
    n=0
    .irp arg,\args
      .ifnc \arg,
        n=n+1
      .endif
    .endr
    invoke \func, \args
    .if n>0
      add %esp, n*4
    .endif
.endm

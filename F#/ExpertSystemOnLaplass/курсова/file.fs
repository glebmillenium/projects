#light
module MyNamespace.MyModule
open System.Windows.Forms

(** Описание функций
  * для реализации
  * работы системы экспертной 
  * оценки
  *)
(* Расчет общей суммы списка *)
let rec sum_list = function
    | [] -> 0;
    | h :: t -> h + sum_list t;

(* Расчет числа элементов в списке *)
let rec count_list = function
    | [] -> 0;
    | h :: t -> 1 + count_list t;

(* Мультипликативная функция 3-х переменных.
 * При 9 входящих переменных на выход будет выдано (9/3) = 3, значений функции*)
let rec multyplicate_function(list1: float list, list2: float list) = 
    match list1 with
    | [] -> []
    | a::b::c::t -> a*list2.Item(0)*b*list2.Item(1)*c*list2.Item(2) :: multyplicate_function(t, list2);
    
(* Функция вычисляющая критерий Лапласа (тоже самое ср. значение списка) *)    
let rec laplas_function(list1: int list list) = 
    match list1 with
    | [] -> []
    | h::t -> (float (sum_list(h)))/(float (count_list(h))) :: laplas_function(t);


(* Ввод в список размерности ixj , т.е. создание двумерной матрицы *)
let rec input_values(i:int, j:int) =
    if (i < 1 || j < 1) then [[]]
    else
        if (i = 1) then [[ for _ in 1 ..1.. j -> (int (System.Console.ReadLine())) ]];
        else input_values(1, j) @ input_values(i-1 , j);


(*Работа программы, точка старта main() *)
printfn "Введите название продуктов, которые будут обработаны экспертизой";
let p1 = System.Console.ReadLine()
let p2 = System.Console.ReadLine()
let p3 = System.Console.ReadLine()

printfn "Введите название критериев, которые будут обработаны экспертизой";
let k1 = System.Console.ReadLine()
let k2 = System.Console.ReadLine()
let k3 = System.Console.ReadLine()

printfn "Введите оценочные показатели каждого критерия в сравении с другими 
			(по 5-ти бальной шкале)\n
		 Пример: 	%s - %s, %s\n
		 		 %s - %s, %s\n
		 		 %s - %s, %s\n" k1 k2 k3 k2 k1 k3 k3 k1 k2;
let oc_krit = input_values (3, 2);// Ввод оценочных показателей критериев
let sr_znach_krit = laplas_function(oc_krit);//Определяем ср. значимость каждого критерия

let mutable krit_tovar = []
printf "Введите оценку каждой операционной системы: %s
		(по 5-ти бальной шкале)\n
		 Пример: 	%s - %s, %s\n
		 		 %s - %s, %s\n
		 		 %s - %s, %s\n" k1 p1 p2 p3 p2 p1 p3 p3 p1 p2;
krit_tovar <- krit_tovar @ input_values(3, 2);//Ввод критериеhв товара

printf "Введите оценку каждой операционной системы: %s
		(по 5-ти бальной шкале)\n
		 Пример: 	%s - %s, %s\n
		 		 %s - %s, %s\n
		 		 %s - %s, %s\n" k2 p1 p2 p3 p2 p1 p3 p3 p1 p2;
krit_tovar <- krit_tovar @ input_values(3, 2);//Ввод критериеhв товара

printf "Введите оценку каждой операционной системы: %s
		(по 5-ти бальной шкале)\n
		 Пример: 	%s - %s, %s\n
		 		 %s - %s, %s\n
		 		 %s - %s, %s\n" k3 p1 p2 p3 p2 p1 p3 p3 p1 p2;
krit_tovar <- krit_tovar @ input_values(3, 2);//Ввод критериеhв товара


let sr_znach_tovar = laplas_function(krit_tovar);
let sr_znach_tovar2 = sr_znach_tovar.Item(0) :: sr_znach_tovar.Item(3) :: sr_znach_tovar.Item(6) :: sr_znach_tovar.Item(1) :: sr_znach_tovar.Item(4) :: sr_znach_tovar.Item(7) :: sr_znach_tovar.Item(2) :: sr_znach_tovar.Item(5) :: sr_znach_tovar.Item(8) :: [];

let multi = multyplicate_function(sr_znach_tovar2, sr_znach_krit)
let maximum = Seq.max (multi);
let mutable p = "";

if(maximum=multi.Item(0)) then p <- p1
if(maximum=multi.Item(1)) then p <- p2
if(maximum=multi.Item(2)) then p <- p3

printfn "%s является наилучшим выбором в вашем случае!" p

System.Console.ReadKey() |> ignore
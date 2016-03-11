#light
namespace LAB1_TI
module count_entropy

let count_entropy(list_probability : float list) = 
  let list_not_probability : float list = List.map (fun i -> 1.0 - i) list_probability
  let result = 0
  let mutable state = []
  let mutable high : int = 0
  let mutable current_result : float = 1.0
  for i = 1 to list_probability.Length do
    for j = 1 to list_probability.Length + 1 - i do
      high <- i - 2 + j
      current_result <- 1.0
      for k = 0 to list_probability.Length - 1 do
        if ( (k >= (j - 1)) && (k <= high) ) then
          current_result <- current_result * list_not_probability.Item(k)
        else
          current_result <- current_result * list_probability.Item(k)
      state <- current_result :: state
  state <- (multiply list_probability) :: state
  summ (List.map(fun i -> - i * log(i)/log(2.0)) state);;

let rec multiply (lst : float list) = 
  match lst with
    [x] -> x
    | x :: t -> x * multiply t
 
 let rec summ (lst : float list) = 
  match lst with
    [x] -> x
    | x :: t -> x + summ t
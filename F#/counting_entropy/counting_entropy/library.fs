#light
namespace counting_entropy

module Entropy = 
  let rec summ (lst : float list) = 
    match lst with
      [] -> 0.0
      | x :: t -> x + summ t

  let rec multiply (lst : float list) = 
    match lst with
      [] -> 1.0
      | x :: t -> x * multiply t

  let count_entropy1(list_probability : float list) = 
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
    summ (List.map(fun i -> - i * log(i)/log(2.0)) state)

  let rec count_probability(conditional_probability : float list list, 
                            probability : float list) =
    if (conditional_probability = [] || probability = []) then []
    else
      probability.Head * (summ (List.map(fun i -> - i * log(i)/log(2.0)) 
         conditional_probability.Head)) :: 
         count_probability(conditional_probability.Tail, probability.Tail)

  let count_entropy2(conditional_probability : float list list, probability : float list) =
    let lst = count_probability(conditional_probability, probability)
    (summ [(summ lst);(summ (List.map(fun i -> - i * log(i)/log(2.0)) probability))]);;
     
#light

module Graph

let rec search_short_way(start : int, 
                         finish : int, 
                         probably_way : (int * int) list list, 
                         current_way : int list, 
                         S : int) = 
  if (start = finish) then [(current_way, S)]
  else
    let count_branch = probably_way.Item(start).Length
    if (count_branch = 0) then 
      []
    else
      let mutable lst = []
      for i = 1 to count_branch do
        let (x, y) = probably_way.Item(start).Item(i-1)
        if ((fun number -> (List.exists (fun elem -> elem = number) current_way)) x) then lst <- lst @ []
        else 
          lst <- lst @ search_short_way(x, finish, probably_way, current_way @ [x], S+y)
      lst

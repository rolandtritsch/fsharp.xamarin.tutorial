[<EntryPoint>]
let main (args) = begin
    let size = (int32) args.[0]
        
    let list = 
        [ 0..size ]
        |> List.filter (fun x -> x % 2 = 0)
        |> List.map (fun x -> x * 2)
    
    let sum = list |> List.sum
    printfn "sum(%d) of %A -> %d" size list sum
    0
end
[<EntryPoint>]
let main (args) = begin
    let a = (int32) args.[0]
    let b = (int32) args.[1]

    let sum a b = a + b
    let inc = sum 1
    let double a = sum a a
    let addTwo a = inc (inc a)

    printfn "sum(%d %d): %d" a b (sum a b) 
    printfn "inc(%d): %d" a (inc a) 
    printfn "double(%d): %d" a (double a) 
    printfn "incTwo(%d): %d" a (addTwo a)

    let filterEven = Seq.filter (fun x -> x % 2 = 0)
    let even = [1..10] |> filterEven
    printfn "Even: %A" even
    0 
end
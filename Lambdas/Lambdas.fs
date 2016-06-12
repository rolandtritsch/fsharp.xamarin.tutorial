[<EntryPoint>]
let main (args) = begin
    let x = (int32) args.[0]
    let invert f x = f x
    printfn "invert(%d) -> %d" x (invert (fun x -> x * -1) x)
    0
end
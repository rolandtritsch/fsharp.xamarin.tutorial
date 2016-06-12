[<EntryPoint>]
let main (args) = begin
    let a = (int32) args.[0]
    let b = (int32) args.[1]
    let isBigger test a b = test a b
    let myTest a b = a > b
    printf "%d isbigger than %d: %b" a b (isBigger myTest a b)
    0
end
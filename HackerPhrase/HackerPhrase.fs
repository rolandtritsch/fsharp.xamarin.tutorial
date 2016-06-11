[<EntryPoint>]
let main (args) = begin
    let phrase = args.[0]
    let hacker = phrase.Replace('o', '0').Replace('l', '1').Replace('e', '3')
    printfn "%s" hacker
    0
end
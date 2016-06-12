type State =
    | Up
    | Down
    | GoingUp
    | GoingDown
    | Unknown

[<EntryPoint>]
let main (args) = begin
    let allStates = [| Up; Down; GoingUp; GoingDown; Unknown |]
    let currentState = allStates.[ System.Random().Next() % allStates.Length ]
    match currentState with 
    | Up -> printfn "Up"
    | Down -> printfn "Down"
    | GoingUp -> printfn "GoingUp"
    | GoingDown -> printfn "GoingDown"
    | Unknown -> printfn "Unkown"
    0
end
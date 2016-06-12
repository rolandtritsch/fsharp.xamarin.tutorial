let numbers = [1..10]

type Colors =
    | Red
    | Green
    | Blue

[<EntryPoint>]
let main args = begin
    let colors = [| Red; Green; Blue |]
    let currentColor = colors.[System.Random().Next() % colors.Length]
    let strColor =
        match currentColor with
        | Red -> "Red"
        | Green -> "Green"
        | Blue -> "Blue"
    printfn "Color: %A %s" currentColor strColor
    0
end
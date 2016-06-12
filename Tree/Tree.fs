type Tree =
    | Node of left: Tree option * right: Tree option * key: int

[<EntryPoint>]
let main (args) = begin
    let tree = Node(Some(Node(Some(Node(None, None, 1)), Some(Node (None, None, 3)), 2)), Some(Node (None, None, 5)), 4)
    let rec traverse tree = 
        match tree with 
        | Node (Some(left), Some(right), key) -> traverse left; traverse right; printfn "Node (%d)" key
        | Node (None, None, key) -> printfn "Leaf [%d]" key
        | _ -> printfn "ERROR"
    traverse tree
    0
end
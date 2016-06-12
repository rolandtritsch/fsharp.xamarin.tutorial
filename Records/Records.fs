type Book = {
    Name: string
    Author : string
    Rating : int 
}

[<EntryPoint>]
let main (args) = begin
    let myBook = { 
        Name = "J2EE"
        Author = "Roland Tritsch"
        Rating = 0 
    }
    printfn "%s by %s got %d points" myBook.Name myBook.Author myBook.Rating
    let books = [ 1..5 ] |> List.map (fun x -> x * 10) |> List.map (fun x -> { myBook with Rating = x })
    printfn "All Books %A" books
    0
end
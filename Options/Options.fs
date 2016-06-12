type Book = { 
    Name: string
    Author: string
    Rating: int option 
}

[<EntryPoint>]
let main (args) = begin
    let numOfBooks = (int32) args.[0]

    let myBook = { 
        Name = "J2EE"
        Author = "Roland Tritsch"
        Rating = None 
    }
    
    let books = [ 1..numOfBooks ] |> List.map (fun r -> 
      if (r % 2 = 0) then { myBook with Rating = None }
      else { myBook with Rating = Some r }
    )    
    printfn "All Books: %A" books

    let matchRating b = begin
        match b.Rating with
        | Some rating -> rating
        | None -> 0
    end
    let sumOfRatings = books |> List.map matchRating |> List.sum
    printfn "Sum of all ratings: %d" sumOfRatings
    0
end
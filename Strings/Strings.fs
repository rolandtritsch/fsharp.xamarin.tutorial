let head (word: string) = (string) word.[0]

let tail (word: string) = word.[1..]
    
let rec reverse (word: string): string =
    match word.Length > 0 with
    | true -> reverse (tail word) + head word
    | false -> ""

let reverse2 (word: string) = begin
    System.String(Array.rev(word.ToCharArray()))
end

let isPalindrom word = begin
    if reverse2 word = word then true else false
end

[<EntryPoint>]
let main args = begin
    let word = args.[0]
    printfn "The reverse of %s is %s and is a palindrom: %b" word (reverse2 word) (isPalindrom word)
    0
end
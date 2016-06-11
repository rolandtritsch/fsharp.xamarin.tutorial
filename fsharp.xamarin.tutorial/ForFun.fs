// From https://fsharpforfunandprofit.com/posts/fsharp-in-60-seconds/

// single line comments use a double slash
(* multi line comments use (* . . . *) pair

-end of multi line comment- *)

// ======== "Variables" (but not really) ==========
// The "let" keyword defines an (immutable) value
let myInt = 5
let myFloat = 3.14
let myString = "hello"   //note that no types needed
printfn("%s world with %d and %f")(myString)(myInt)(myFloat)

// ======== Lists ============
let twoToFive = [2;3;4;5]        // Square brackets create a list with
                                 // semicolon delimiters.
let oneToFive = 1 :: twoToFive   // :: creates list with new 1st element
printfn("OneToFive: %A")(oneToFive)
let zeroToFive = [0;1] @ twoToFive   // @ concats two lists
printfn("ZeroToFive: %A")(zeroToFive)

// IMPORTANT: commas are never used as delimiters, only semicolons!

// ======== Functions ========
// The "let" keyword also defines a named function.
let square(x) = x * x                   // Note that no parens are used.
printfn("Square(3): %d")(square(3))     // Now run the function. Again, no parens.

let add(x, y) = x + y                   // don't use add (x,y)! It means something
                                        // completely different.
printfn("Add(2, 3): %d")(add(2, 3))     // Now run the function.

// to define a multiline function, just use indents. No semicolons needed.
let evens(list) = begin
   let isEven x = (x % 2 = 0)     // Define "isEven" as an inner ("nested") function
   List.filter(isEven)(list)      // List.filter is a library function
                                  // with two parameters: a boolean function
                                  // and a list to work on
end
printfn("Even numvers: %A")(evens(oneToFive))               // Now run the function

// You can use parens to clarify precedence. In this example,
// do "map" first, with two args, then do "sum" on the result.
// Without the parens, "List.map" would be passed as an arg to List.sum
let sumOfSquaresTo100 = List.sum(List.map(square)([1..100]))
printfn("SumOfSquaresTo100: %d")(sumOfSquaresTo100)

// You can pipe the output of one operation to the next using "|>"
// Here is the same sumOfSquares function written using pipes
let sumOfSquaresTo100piped = [1..100] |> List.map square |> List.sum
printfn("SumOfSquaresTo100piped: %d")(sumOfSquaresTo100piped)

// you can define lambdas (anonymous functions) using the "fun" keyword
let sumOfSquaresTo100withFun = [1..100] |> List.map (fun x -> x * x) |> List.sum
printfn("SumOfSquaresTo100withFun: %d")(sumOfSquaresTo100withFun)

// In F# returns are implicit -- no "return" needed. A function always
// returns the value of the last expression used.

// ======== Pattern Matching ========
// Match..with.. is a supercharged case/switch statement.
let simplePatternMatch(x) = begin
   match x with
    | "a" -> printfn("x is a")
    | "b" -> printfn("x is b")
    | _ -> printfn("x is something else")
end
simplePatternMatch("c")

// Some(..) and None are roughly analogous to Nullable wrappers
let validValue = Some(99)
let invalidValue = None

// In this example, match..with matches the "Some" and the "None",
// and also unpacks the value in the "Some" at the same time.
let optionPatternMatch(input) = begin
   match input with
    | Some(i) -> printfn("input is an int: %d")(i)
    | None -> printfn("input is missing")
end

optionPatternMatch(validValue)
optionPatternMatch(invalidValue)

// ========= Complex Data Types =========

// Tuple types are pairs, triples, etc. Tuples use commas.
let twoTuple = 1,2
let threeTuple = "a",2,true

// Record types have named fields. Semicolons are separators.
type Person = {First:string; Last:string}
let person1 = {First="john"; Last="Doe"}

// Union types have choices. Vertical bars are separators.
type Temp = 
    | DegreesC of float
    | DegreesF of float
let temp = DegreesF 98.6

// Types can be combined recursively in complex ways.
// E.g. here is a union type that contains a list of the same type:
type Employee = 
  | Worker of Person
  | Manager of Employee list
let jdoe = {First="John";Last="Doe"}
let worker = Worker jdoe

// ========= Printing =========
// The printf/printfn functions are similar to the
// Console.Write/WriteLine functions in C#.
printfn "Printing an int %i, a float %f, a bool %b" 1 2.0 true
printfn "A string %s, and something generic %A" "hello" [1;2;3;4]

// all complex types have pretty printing built in
printfn "twoTuple=%A,\nPerson=%A,\nTemp=%A,\nEmployee=%A" 
         twoTuple person1 temp worker

// There are also sprintf/sprintfn functions for formatting data
// into a string, similar to String.Format.


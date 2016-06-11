// This sample will guide you through elements of the F# language. 

//
// *******************************************************************************************************
//   To execute the code in F# Interactive, highlight a section of code and press Alt-Enter in Windows or 
//   Ctrl-Enter Mac, or right-click and select "Send Selection to F# Interactive".  
//   You can open the F# Interactive Window from the "View" menu.
// *******************************************************************************************************

// For more about F#, see:
//     http://fsharp.org
//
// For additional templates to use with F#, see the 'Online Templates' in Visual Studio,
//     'New Project' --> 'Online Templates'
//
// For specific F# topics, see:
//     http://fsharp.org (F# Open Organization)
//     http://tryfsharp.org (F# Learning Portal)
//     http://go.microsoft.com/fwlink/?LinkID=234174 (Visual F# Development Portal)
//     http://go.microsoft.com/fwlink/?LinkID=124614 (Visual F# Code Gallery)
//     http://go.microsoft.com/fwlink/?LinkId=235173 (Visual F# Math/Stats Programming)
//     http://go.microsoft.com/fwlink/?LinkId=235176 (Visual F# Charting)


// Contents:

//    - Integers and basic functions
//    - Booleans
//    - Strings
//    - Tuples
//    - Lists and list processing
//    - Classes
//    - Generic classes
//    - Implementing interfaces
//    - Arrays
//    - Sequences
//    - Recursive functions
//    - Record types
//    - Union types
//    - Option types           
//    - Pattern matching       
//    - Units of measure       
//    - Parallel array programming
//    - Using events
//    - Database access using type providers
//    - OData access using type providers
 

// ---------------------------------------------------------------
// Integers
// ---------------------------------------------------------------

module Integers = begin
    // Define integer value
    let sampleInteger = 176
 
    // Do some arithmetic starting with the first integer
    let sampleInteger2 = (sampleInteger/4 + 5 - 7) * 4

    // A list of the numbers from 0 to 99
    let sampleNumbers = [ 0 .. 99 ]
 
    // The next line prints the list of numbers, using %A for generic printing
    printfn "The list of numbers from 0 to 99 is:\n%A" sampleNumbers
 
    // A list of tuples containing the numbers from 0 to 99 and their squares
    let sampleTableOfSquares = [ for i in 0 .. 99 -> (i, i*i) ]
 
    // The next line prints the list of tuples, using %A for generic printing
    printfn "The list of squares from 0 to 99 is:\n%A" sampleTableOfSquares
end
 
// ---------------------------------------------------------------
// Basic functions
// ---------------------------------------------------------------

module BasicFunctions = begin
    // Use 'let' to define a function that accepts an integer argument and returns an integer.
    let func1 x = x * x + 3            

    // Parenthesis are optional for function arguments
    let func1a (x) = x * x + 3            

    // Apply the function, naming the function return result using 'let'.
    // The variable type is inferred from the function return type.
    let result1 = func1 4573
    printfn "The result of squaring the integer 4573 and adding 3 is %d" result1
    printfn "The result of squaring the integer 4573 and adding 3 is %d" (func1a 4573)

    // When needed, annotate the type of a parameter name using '(argument:type)'
    let func2 (x:int) = 2 * x * x - x/5 + 3
    let result2 = func2 (7 + 4)
    printfn "The result of applying the 1st sample function to (7 + 4) is %d" result2

    // if (and for) return(s) (a) value(s)
    let func3 x =
        if x < 100.0 then
            2.0 * x * x - x/5.0 + 3.0
        else
            2.0 * x * x + x/5.0 - 37.0
    let result3 = func3 (6.5 + 4.5)   
    printfn "The result of applying the 2nd sample function to (6.5 + 4.5) is %f" result3
end

// ---------------------------------------------------------------
// Booleans
// ---------------------------------------------------------------

module SomeBooleanValues = begin
    // Some boolean values
    let boolean1 = true
    let boolean2 = false
    let boolean3 = not boolean1 && (boolean2 || false)
    printfn "The expression 'not boolean1 && (boolean2 || false)' is %A" boolean3

    // Build and print tuples to express if number is even
    let evenNumbers = [for i in 0 .. 9 -> (i, if i % 2 = 0 then true else false)]
    printfn "Tuples of to express if number is even\n%A" evenNumbers
end

// ---------------------------------------------------------------
// Strings
// ---------------------------------------------------------------

module StringManipulation = begin
    // Some strings
    let string1 = "Hello"
    let string2  = "world"

    // Use @ to create a verbatim string literal
    let string3 = @"c:\Program Files\"

    // Using a triple-quote string literal
    let helloWorld = string1 + " " + string2 
    let string4 = """He said "hello world" after you did""" + " " + helloWorld
    printfn "%s" string4

    // A string formed by taking the first 7 characters of one of the result strings
    let substring = helloWorld.[0..6]
    printfn "%s" substring

    // Lots of string functions available
    // printfn "%s" helloWorld.ToUpper
    printfn "%b" (helloWorld.Contains "world")
end

// ---------------------------------------------------------------
// Tuples (ordered sets of values)
// ---------------------------------------------------------------

module Tuples = begin
    // A simple tuple of integers
    let tuple1 = (1, 2, 3)

    // A function that swaps the order of two values in a tuple.
    // QuickInfo shows that the function is inferred to have a generic type.
    let swapElems(a, b) = (b, a)
    printfn "The result of swapping (1, 2) is %A" (swapElems (1, 2))

    /// A tuple consisting of an integer, a string, and a double-precision floating point number
    let tuple2 = (1, "fred", 3.1415)
    printfn "tuple1: %A    tuple2: %A" tuple1 tuple2
end

// ---------------------------------------------------------------
// Lists and list processing
// ---------------------------------------------------------------

module Lists = begin
    // A couple of lists
    let list1 = []
    let list2 = [1; 2; 3]
    let list3 = 42 :: list2
    let list4 = list2 @ list3
    let numberList = [1 .. 1000]

    // A list containing all the days of the year
    let daysList = [
        for month in 1 .. 12 do
            for day in 1 .. System.DateTime.DaysInMonth(2012, month) do
                yield System.DateTime(2012, month, day)
            done
        done
    ]

    // A list containing the tuples which are the coordinates of the black squares on a chess board.
    let blackSquares = [ 
        for i in 0 .. 7 do
            for j in 0 .. 7 do
                if (i+j) % 2 = 1 then yield (i, j)
            done
        done
    ]

    // Square the numbers in numberList, using the pipeline operator to pass an argument to List.map   
    let squares = numberList |> List.map(fun x -> x * x)

    // Computes the sum of the squares of the numbers divisible by 3.
    let sumOfSquaresUpTo n = numberList |> List.filter(fun x -> x % 3 = 0) |> List.sumBy(fun x -> x * x)
end

// ---------------------------------------------------------------
// Classes
// ---------------------------------------------------------------

module DefiningClasses = begin
    // The class's constructor takes two arguments: dx and dy, both of type 'float'.
    type Vector2D(dx: float, dy: float) = class
        // The length of the vector, computed when the object is constructed
        let length = sqrt(dx * dx + dy * dy)

        // 'this' specifies a name for the object's self identifier
        // In instance methods, it must appear before the member name.       
        member this.DX = dx
        member this.DY = dy
        member this.Length = length
        member this.Scale(k) = Vector2D(k * this.DX, k * this.DY)
    end
   
    // An instance of the Vector2D class
    let vector1 = Vector2D(3.0, 4.0)

    // Get a new scaled vector object, without modifying the original object
    let vector2 = vector1.Scale(10.0)
    printfn "Length of vector1: %f      Length of vector2: %f" vector1.Length vector2.Length
end

// ---------------------------------------------------------------
// Generic classes
// ---------------------------------------------------------------

module DefiningGenericClasses = begin
    type StateTracker<'T>(initialElement: 'T) = class
        // Store the states in an array
        let mutable states = [ initialElement ]

        // Add a new element to the list of states
        member this.UpdateState newState = states <- newState :: states

        // Get the entire list of historical states
        member this.History = states

        /// Get the latest state
        member this.Current = states.Head
    end

    // An 'int' instance of the state tracker class. Note that the type parameter is inferred.
    let tracker = StateTracker(10)
   
    // Add a state
    tracker.UpdateState(17)

    printfn "Tracker history: %A" tracker.History
end

// ---------------------------------------------------------------
// Implementing interfaces
// ---------------------------------------------------------------

module ImplementingInterfaces = begin
    type ReadFile() = class
        let file = new System.IO.StreamReader("./readme.txt")
        member this.ReadLine() = file.ReadLine()

        // this class's implementation of IDisposable members
        interface System.IDisposable with   
            member this.Dispose() = file.Close()
        end
    end

    let reader = new ReadFile()
    printfn "Line: %A" reader.ReadLine
end 

// ---------------------------------------------------------------
// Arrays
// ---------------------------------------------------------------

module Arrays = begin
    // A couple of arrays
    let array1 = [| |]
    let array2 = [| "hello"; "world"; "and"; "hello"; "world"; "again"|]
    let array3 = [|1 .. 10|]

    // modify an array element using the left arrow assignment operator
    array2.[1] <- "WORLD"
    printfn "Array of words: %A" array2

    /// Calculates the sum of the lengths of the words that start with 'h'
    let sumOfLengthsOfWords = array2 |> Array.filter(fun x -> x.StartsWith "h") |> Array.sumBy(fun x -> x.Length)
    printfn "Sum up the length of all words start with 'h': %d" sumOfLengthsOfWords

    // An array containing only the words "hello" and "world"
    let array4 = [| 
        for word in array2 do
            if word.Contains("l") then yield word 
        done
    |]
    for word in array4 do printfn "Word: %s" word

    // An array initialized by index and containing the even numbers from 0 to 18
    let evenNumbers = Array.init(10)(fun n -> n * 2)
    printfn "Even numbers: %A" evenNumbers

    // Sub-array extracted using slicing notation
    let evenNumbersSlice = evenNumbers.[0..5]
    printfn "Even numbers slice: %A" evenNumbersSlice
 end

// ---------------------------------------------------------------
// Sequences
// ---------------------------------------------------------------

module Sequences = begin
    // Sequences are evaluated on-demand and are re-evaluated each time they are iterated.
    // An F# sequence is an instance of a System.Collections.Generic.IEnumerable<'T>,
    // so Seq functions can be applied to Lists and Arrays as well.

    // The empty sequence
    let seq1 = Seq.empty
    let seq2 = seq { 
        yield "hello"
        yield "world"
        yield "and"
        yield "hello"
        yield "world"
        yield "again" 
    }

    // another array containing only the words "hello" and "world"
    let seq3 = seq { 
        for word in seq2 do
            if word.Contains("l") then yield word
        done
    }
    printfn "Seq of words: %A" seq2
    printfn "Seq of words with an 'l' in it: %A" seq3

    let numbersSeq = seq { 1 .. 10 }
    let evenNumbers = Seq.init(10)(fun n -> n * 2)
    printfn "Even numbers: %A" evenNumbers

    // An infinite sequence which is a random walk
    // Use yield! to return each element of a subsequence, similar to IEnumerable.SelectMany.
    let rnd = System.Random()
    let rec randomWalk(x) = seq { 
        yield x
        yield! randomWalk(x + rnd.NextDouble() - 0.5) 
    }
 
    let first100ValuesOfRandomWalk = begin
        randomWalk 5.0
        |> Seq.truncate 100
        |> Seq.toList
    end
end

// ---------------------------------------------------------------
// Recursive functions
// ---------------------------------------------------------------

module RecursiveFunctions = begin 
    // Compute the factorial of an integer. Use 'let rec' to define a recursive function
    let rec factorial(n) = begin
        if n = 0 then 1 else n * factorial(n-1)
    end
    printfn("Factorial(100): %d")(factorial(10))
 
    // Computes the greatest common factor of two integers.
    //  Since all of the recursive calls are tail calls, the compiler will turn the function into a loop,
    //  which improves performance and reduces memory consumption.
    let rec greatestCommonFactor(a, b) = begin                      
        if a = 0 then b
        elif a < b then greatestCommonFactor(a, (b - a))          
        else greatestCommonFactor((a - b), b)
    end
    printfn("GCF(100): %d")(factorial(10))

    // Computes the sum of a list of integers using recursion.
    let rec sumList(xs) = begin
        match xs with
        | []    -> 0
        | y::ys -> y + sumList ys
    end
    printfn("Recursive Sum: %d")(sumList())

    // Make the function tail recursive, using a helper function with a result accumulator
    let rec private sumListTailRecHelper(accumulator, xs) = begin
        match xs with
        | [] -> accumulator
        | y::ys -> sumListTailRecHelper((accumulator+y), ys)
    end
    let sumListTailRecursive(xs) = sumListTailRecHelper(0, xs)
    printfn("TailRecursive Sum: %d")(sumListTailRecursive(10000))
end

// ---------------------------------------------------------------
// Record types
// ---------------------------------------------------------------

module RecordTypes = begin
    // Define a record type
    type ContactCard = { 
        Name: string
        Phone: string
        Verified: bool
        Planet: string 
    }

    let contact1 = { 
        Name = "Alf"
        Phone = "(206) 555-0157"
        Verified = false
        Planet = "Melmac"
    }
    printfn "Alf: %A" contact1

    // Create a new record that is a copy of contact1,
    // but has different values for the 'Phone' and 'Verified' fields
    let contact2 = { contact1 with Name = "Sarek"; Planet = "Vulcan" }
    printfn "Sarek: %A" contact2

    // Converts a 'ContactCard' object to a string
    let showCard(c) = 
        c.Name 
        + " Phone: " 
        + c.Phone 
        + (if not c.Verified then " (unverified)" else "")
    printfn "vcard: %A" (showCard(contact2))
end

// ---------------------------------------------------------------
// Union types
// ---------------------------------------------------------------

module UnionTypes = begin
    // Represents the suit of a playing card
    type Suit =
        | Hearts
        | Clubs
        | Diamonds
        | Spades

    // Represents the rank of a playing card
    type Rank = 
        // Represents the rank of cards 2 .. 10
        | Value of int
        | Ace
        | King
        | Queen
        | Jack

        static member GetAllRanks() = [ 
            yield Ace
            for i in 2 .. 10 do yield Value i
            yield Jack
            yield Queen
            yield King 
        ]
    
    type Card = { 
        Suit: Suit
        Rank: Rank 
    }

    // Returns a list representing all the cards in the deck
    let fullDeck = [ 
        for suit in [ Hearts; Diamonds; Clubs; Spades] do
            for rank in Rank.GetAllRanks() do 
                yield { 
                    Suit=suit
                    Rank=rank 
                }
            done
        done
    ]
    printfn "Full deck: %A" fullDeck

    // Converts a 'Card' object to a string
    let showCard(c) = begin
        let rankString =
            match c.Rank with
            | Ace -> "Ace"
            | King -> "King"
            | Queen -> "Queen"
            | Jack -> "Jack"
            | Value n -> string n

        let suitString =
            match c.Suit with
            | Clubs -> "clubs"
            | Diamonds -> "diamonds"
            | Spades -> "spades"
            | Hearts -> "hearts"

        rankString  + " of " + suitString
    end

    let printAllCards() = begin
        for card in fullDeck do
            printfn "%s" (showCard card)
        done
    end
end

// ---------------------------------------------------------------
// Option types
// ---------------------------------------------------------------

module OptionTypes = 
    /// Option values are any kind of value tagged with either 'Some' or 'None'.
    /// They are used extensively in F# code to represent the cases where many other
    /// languages would use null references.

    type Customer = { zipCode : decimal option }

    /// Abstract class that computes the shipping zone for the customer's zip code,
    /// given implementations for the 'GetState' and 'GetShippingZone' abstract methods.

    [<AbstractClass>]

    type ShippingCalculator =

        abstract GetState : decimal -> string option

        abstract GetShippingZone : string -> int

        /// Return the shipping zone corresponding to the customer's ZIP code
        /// Customer may not yet have a ZIP code or the ZIP code may be invalid
        member this.CustomerShippingZone(customer : Customer) =

            customer.zipCode |> Option.bind this.GetState |> Option.map this.GetShippingZone

 
// ---------------------------------------------------------------
//         Pattern matching
// ---------------------------------------------------------------

module PatternMatching =

    /// A record for a person's first and last name

    type Person =   
        { First : string
          Last  : string }


    /// Define a discriminated union of 3 different kinds of employees

    type Employee =
        /// Engineer is just herself
        | Engineer  of Person
        /// Manager has list of reports
        | Manager   of Person * list<Employee>            
        /// Executive also has an assistant
        | Executive of Person * list<Employee> * Employee 

    /// Count everyone underneath the employee in the management hierarchy, including the employee
    let rec countReports(emp : Employee) =
        1 + match emp with
            | Engineer(id) ->
                0
            | Manager(id, reports) ->
                reports |> List.sumBy countReports
            | Executive(id, reports, assistant) ->
                (reports |> List.sumBy countReports) + countReports assistant

    /// Find all managers/executives named "Dave" who do not have any reports
    let rec findDaveWithOpenPosition(emps : Employee list) =
        emps
        |> List.filter(function
                       | Manager({First = "Dave"}, []) -> true       // [] matches the empty list
                       | Executive({First = "Dave"}, [], _) -> true
                       | _ -> false)                                 // '_' is a wildcard pattern that matches anything
                                                                     // this handles the "or else" case


// ---------------------------------------------------------------
//         Units of measure
// ---------------------------------------------------------------

module UnitsOfMeasure =
    // Code can be annotated with units of measure when using F# arithmetic over numeric types

    open Microsoft.FSharp.Data.UnitSystems.SI.UnitNames

    [<Measure>]
    type mile =

        /// Conversion factor mile to meter: meter is defined in SI.UnitNames

        static member asMeter = 1600.<meter/mile>

 
    let d  = 50.<mile>          // Distance expressed using imperial units
    let d' = d * mile.asMeter   // Same distance expressed using metric system

    printfn "%A = %A" d d'
    // let error = d + d'       // Compile error: units of measure do not match


 

// ---------------------------------------------------------------
//         Parallel array programming
// ---------------------------------------------------------------
 

module ParallelArrayProgramming =

    let oneBigArray = [| 0 .. 100000 |]

    // do some CPU intensive computation
    let rec computeSomeFunction x =
        if x <= 2 then 1
        else computeSomeFunction (x - 1) + computeSomeFunction (x - 2)

    // Do a parallel map over a large input array
    let computeResults() = oneBigArray |> Array.Parallel.map (fun x -> computeSomeFunction (x % 20))

    printfn "Parallel computation results: %A" (computeResults())

 

// ---------------------------------------------------------------
//         Using events
// ---------------------------------------------------------------

module Events =

    open System

    // Create instance of Event object that consists of subscription point (event.Publish) and event trigger (event.Trigger)
    let simpleEvent = new Event<int>()

    // Add handler
    simpleEvent.Publish.Add(fun x -> printfn "this is handler was added with Publish.Add: %d" x)

    // Trigger event
    simpleEvent.Trigger(5)

    // Create instance of Event that follows standard .NET convention: (sender, EventArgs)
    let eventForDelegateType = new Event<EventHandler, EventArgs>()   

 
    // Add handler
    eventForDelegateType.Publish.AddHandler(
        EventHandler(fun _ _ -> printfn "this is handler was added with Publish.AddHandler"))

 
    // Trigger event (note that sender argument should be set)
    eventForDelegateType.Trigger(null, EventArgs.Empty)



// ---------------------------------------------------------------
//         Database access using type providers
// ---------------------------------------------------------------

module DatabaseAccess =

    // The easiest way to access a SQL database from F# is to use F# type providers.
    // Add references to System.Data, System.Data.Linq, and FSharp.Data.TypeProviders.dll.
    // You can use Server Explorer to build your ConnectionString.

    (*

    #r "System.Data"
    #r "System.Data.Linq"
    #r "FSharp.Data.TypeProviders"

    open Microsoft.FSharp.Data.TypeProviders

    type SqlConnection = SqlDataConnection<ConnectionString = @"Data Source=.\sqlexpress;Initial Catalog=tempdb;Integrated Security=True">
    let db = SqlConnection.GetDataContext()

    let table =
        query { for r in db.Table do
                select r }

    *)


    // You can also use SqlEntityConnection instead of SqlDataConnection, which accesses the database using Entity Framework.

    ()

 

// ---------------------------------------------------------------
//         OData access using type providers
// ---------------------------------------------------------------

module OData =

    (*

    open System.Data.Services.Client
    open Microsoft.FSharp.Data.TypeProviders

    // Consume demographics population and income OData service from Azure Marketplace.
    // For more information, see http://go.microsoft.com/fwlink/?LinkId=239712

    type Demographics = Microsoft.FSharp.Data.TypeProviders.ODataService<ServiceUri = "https://api.datamarket.azure.com/Esri/KeyUSDemographicsTrial/">
    let ctx = Demographics.GetDataContext()

    // Sign up for a Azure Marketplace account at https://datamarket.azure.com/account/info
    ctx.Credentials <- System.Net.NetworkCredential ("<your liveID>", "<your Azure Marketplace Key>")

    let cities = 
        query { for c in ctx.demog1 do
                where (c.StateName = "Washington") }

    for c in cities do
        printfn "%A - %A" c.GeographyId c.PerCapitaIncome2010.Value

    *)

    ()

 
#if COMPILED

module BoilerPlateForForm =
    [<System.STAThread>]
    do ()
//    do System.Windows.Forms.Application.Run()

#endif


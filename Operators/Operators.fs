type Point (x: int, y: int) = class
    member this.X = x
    member this.Y = y

    static member (+) (p1: Point, p2: Point) = begin
        new Point (p1.X + p2.X, p1.Y + p2.Y)
    end

    override this.ToString() = begin
        sprintf "%d/%d" this.X this.Y
    end
end

[<EntryPoint>]
let main (args) = begin
    let p1, p2 = new Point ((int32) args.[0], (int32) args.[1]), new Point ((int32) args.[2], (int32) args.[3])
    printfn "%A + %A = %A" p1 p2 (p1 + p2)
    0
end
open System.IO

type Movement  = {
    Direction: string
    Amount: int
}

type Point = {
    X: int
    Z: int
}

let moveSequence = 
    File.ReadLines "./input"
    |> Seq.map (fun x -> x.Split(' ')) 
    |> Seq.map (fun x -> { Direction = x.[0]; Amount = int x.[1]})

let movePoint p m =
    match m with
    | { Direction = "forward"; Amount = amount} -> { X = p.X + amount; Z = p.Z }
    | { Direction = "up"; Amount = amount} -> { X = p.X; Z = p.Z - amount }
    | { Direction = "down"; Amount = amount} -> { X = p.X; Z = p.Z + amount }
    | _ -> p

let startingPoint = { X = 0; Z = 0 } 

let result = 
    moveSequence
    |> Seq.fold movePoint startingPoint
    |> fun p -> p.X * p.Z

printfn "Result: %i" result

open System.IO

type Movement  = {
    Direction: string
    Amount: int
}

type Point = {
    Horiz: int
    Depth: int
    Aim: int
}

let moveSequence = 
    File.ReadLines "./input"
    |> Seq.map (fun x -> x.Split(' ')) 
    |> Seq.map (fun x -> { Direction = x.[0]; Amount = int x.[1]})

let movePoint p m =
    match m with
    | { Direction = "forward"; Amount = amount} -> { Horiz = p.Horiz + amount; Depth = p.Depth + (p.Aim * amount); Aim = p.Aim }
    | { Direction = "up"; Amount = amount} -> { Horiz = p.Horiz; Depth = p.Depth; Aim = p.Aim - amount }
    | { Direction = "down"; Amount = amount} -> { Horiz = p.Horiz; Depth = p.Depth; Aim = p.Aim + amount }
    | _ -> p

let startingPoint = { Horiz = 0; Depth = 0; Aim = 0 } 

let result = 
    moveSequence
    |> Seq.fold movePoint startingPoint
    |> fun p -> p.Horiz * p.Depth

printfn "Result: %i" result

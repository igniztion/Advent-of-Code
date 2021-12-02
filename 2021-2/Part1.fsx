open System.IO

type Movement  = {
    Direction: string
    Amount: int
}

let moveSequence = 
    File.ReadLines "./input"
    |> Seq.map (fun x -> x.Split(' ')) 
    |> Seq.map (fun x -> { Direction = x.[0]; Amount = int x.[1]})

let movePoint (x,y) (m : Movement) =
    match m with
    | { Direction = "forward"; Amount = a} -> (x + a, y)
    | { Direction = "up"; Amount = a} -> (x, y - a)
    | { Direction = "down"; Amount = a} -> (x, y + a)
    | _ -> (x,y)

moveSequence
|> Seq.fold movePoint (0,0)
|> fun (x,y) -> x * y
|> printfn "Result: %i"
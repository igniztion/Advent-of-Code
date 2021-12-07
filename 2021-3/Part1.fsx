open System.IO
open System

let transposedList =
    File.ReadLines "./input"
    |> Seq.map List.ofSeq
    |> List.transpose

let convertToInt (s : string[]) = 
    Convert.ToInt32(s |> String.Concat, 2)

let bitsToInt (b : seq<int>) = 
    b
    |> Seq.map (fun x -> x.ToString())
    |> Array.ofSeq
    |> convertToInt

let gammarate =
    transposedList
    |> Seq.map (Seq.countBy id)
    |> Seq.map (Seq.maxBy (fun (_,y) -> y))
    |> Seq.map (fun (x,_) -> x)
    |> Seq.map Char.GetNumericValue 
    |> Seq.map int

let epsilonrate = 
    gammarate
    |> Seq.map ( fun x -> 
        match x 
            with 
            |0 -> 1
            |1 -> 0
            |_ -> 2)//crap

printfn "RESULT: %i" ((gammarate |> bitsToInt) * (epsilonrate |> bitsToInt))
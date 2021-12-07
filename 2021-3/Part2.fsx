open System.IO
open System

let inputlist =
    File.ReadLines "./input"

let convertToInt (s : string[]) = 
    Convert.ToInt32(s |> String.Concat, 2)

let bitsToInt (b : seq<int>) = 
    b
    |> Seq.map (fun x -> x.ToString())
    |> Array.ofSeq
    |> convertToInt

let o2Rating = 
    inputlist
    |> Seq.countBy id
    |> Seq.map (fun x -> printfn "%A" x)

o2Rating
open System.IO

File.ReadLines "./input.txt"
|> Seq.map (fun x -> x |> int)
|> Seq.pairwise 
|> Seq.countBy (fun (x,y) -> y > x)
|> Seq.choose (fun (x,y) -> if x = true then Some y else None) 
|> Seq.head
|> printfn "%i"
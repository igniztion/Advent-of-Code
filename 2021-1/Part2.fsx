open System.IO

File.ReadLines "./input.txt"
|> Seq.map (fun x -> x |> int)
|> Seq.windowed 3
|> Seq.map (fun x -> Seq.sum x)
|> Seq.pairwise 
|> Seq.countBy (fun (x,y) -> y > x) 
|> Seq.choose (fun (x,y) -> if x = true then Some y else None) 
|> Seq.head
|> printfn "%i"
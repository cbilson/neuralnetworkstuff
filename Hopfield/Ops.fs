#light

open Microsoft.FSharp.Math

let toBipolar x = if x then 1.0 else -1.0

let inverseMultiply (m:matrix) : matrix = (Matrix.transpose m) * m
    
let subtractIdentity (m:matrix) : matrix = m - Matrix.identity (m.NumRows) 

let contribution =  inverseMultiply >> subtractIdentity

let column i m = 
    matrix [ [ Matrix.get m 0 i ]; [ Matrix.get m 1 i ]; 
             [ Matrix.get m 2 i ]; [ Matrix.get m 3 i ] ]

let present (pattern:bool list) (weights:matrix) : bool list =
    let input = seq { yield pattern |> Seq.map toBipolar } |> Matrix.of_seq
    seq {
        for i = 0 to (Seq.length pattern) - 1 do
            let dp = column i weights |> Matrix.transpose |> Matrix.dot input
            yield dp > 0.
    } |> List.of_seq
    
let train (pattern:bool list) (weights:matrix) : matrix =
    let m2 = seq { yield pattern |> Seq.map toBipolar } |> Matrix.of_seq
    let m1 = Matrix.transpose m2
    let m3 = m1 * m2
    let identity = Matrix.identity m3.NumRows
    let m4 = m3 - identity
    weights + m4
    
    
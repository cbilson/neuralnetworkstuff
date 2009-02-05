#light

open Microsoft.FSharp.Math

let browvec l = RowVector.Generic.of_list l

let bmatrix l = Matrix.Generic.of_list l

let toBipolar x = if x then 1.0 else -1.0

let toBoolean x = 
    let bipolar = (x + 1.0) / 2.0
    if x = 1.0 then true else false
    
let toBipolarM m =
    m |> Matrix.Generic.to_array2 |> Array2.map toBipolar |> Matrix.of_array2
    
let toBooleanM m =
    m |> Matrix.to_array2 |> Array2.map toBoolean |> Matrix.Generic.of_array2
    
let inverseMultiply (m:matrix) : matrix = (Matrix.transpose m) * m
    
let subtractIdentity (m:matrix) : matrix = m - Matrix.identity (m.NumRows) 

let contribution() =  inverseMultiply >> subtractIdentity

let column i m = 
    matrix [ [ Matrix.get m 0 i ]; 
             [ Matrix.get m 1 i ]; 
             [ Matrix.get m 2 i ]; 
             [ Matrix.get m 3 i ] ]

let present (pattern:bool seq) (weights:matrix) : bool seq =
    let n = pattern |> Seq.map toBipolar
    seq { yield false; yield false; yield false; yield false }
    
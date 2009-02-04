#light

open Microsoft.FSharp.Math

let toBipolar x = if x then 1.0 else -1.0

let toBoolean x = 
    let bipolar = (x + 1.0) / 2.0
    if x = 1.0 then true else false
    
let toBipolarM m =
    m |> Matrix.Generic.to_array2 |> Array2.map toBipolar |> Matrix.of_array2
    
let toBooleanM m =
    m |> Matrix.to_array2 |> Array2.map toBoolean |> Matrix.Generic.of_array2
    
let inverseMultiply m = (Matrix.transpose m) * m
    
let subtractIdentity m = m - Matrix.identity (m.NumRows) 

(*
    I wanted:
        let contribution = inverseMultiply >> subtractIdentity
        
    but when I do this, contribution is null when used from other modules,
    like the test fixtures
    
*)

let contribution m =  m |> (inverseMultiply >> subtractIdentity)

#light

open Microsoft.FSharp.Math
open Xunit
open FsxUnit.Syntax
open Ops

[<Fact>]
let it_computes_contribution =
    matrix [[ -1.0; 1.0; -1.0; 1.0 ]] 
        |> contribution 
        |> should equal (matrix [[ 0.0; -1.0;  1.0; -1.0];
                                 [-1.0;  0.0; -1.0;  1.0];
                                 [ 1.0; -1.0;  0.0; -1.0];
                                 [-1.0;  1.0; -1.0;  0.0]])
    
                                           
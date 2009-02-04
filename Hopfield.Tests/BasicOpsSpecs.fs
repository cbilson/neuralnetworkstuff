#light

open Microsoft.FSharp.Math
open Xunit
open FsxUnit.Syntax
open Ops

[<Fact>]
let it_converts_true_to_bipolar_1 =
    toBipolar true |> should equal 1.0

[<Fact>]
let it_converts_false_to_bipolar_negative_1 =
    toBipolar false |> should equal -1.0

[<Fact>]
let it_converts_1_to_boolean_true = 
    toBoolean 1.0 |> should equal true
    
[<Fact>]
let it_converts_0_to_boolean_false = 
    toBoolean 0.0 |> should equal false
    
[<Fact>]
let it_converts_boolean_matrices_to_bipolar =
    let m = Matrix.Generic.of_list [[ false; true; false; true ]]
    toBipolarM m |> should equal (matrix [[ -1.0; 1.0; -1.0; 1.0 ]])

[<Fact>]
let it_converts_bipolar_matrices_to_boolean =
    let m = matrix [[ -1.0; 1.0; -1.0; 1.0 ]]
    toBooleanM m |> should equal (Matrix.Generic.of_list [[ false; true; false; true ]])

[<Fact>]
let it_inverse_multiplies_matrices =
    let m = matrix [[ -1.0; 1.0; -1.0; 1.0 ]]
    inverseMultiply m |> should equal (matrix [[ 1.0; -1.0;  1.0; -1.0];
                                          [-1.0;  1.0; -1.0;  1.0];
                                          [ 1.0; -1.0;  1.0; -1.0];
                                          [-1.0;  1.0; -1.0;  1.0]]);
                                          
[<Fact>]
let it_subtracts_identity =
    let m = matrix [[ -1.0; 1.0; -1.0; 1.0 ]] |> inverseMultiply
    subtractIdentity m |> should equal (matrix [[ 0.0; -1.0;  1.0; -1.0];
                                                [-1.0;  0.0; -1.0;  1.0];
                                                [ 1.0; -1.0;  0.0; -1.0];
                                                [-1.0;  1.0; -1.0;  0.0]]);

[<Fact>]
let it_computes_contribution =
    matrix [[ -1.0; 1.0; -1.0; 1.0 ]] 
        |> contribution 
        |> should equal (matrix [[ 0.0; -1.0;  1.0; -1.0];
                                 [-1.0;  0.0; -1.0;  1.0];
                                 [ 1.0; -1.0;  0.0; -1.0];
                                 [-1.0;  1.0; -1.0;  0.0]])
    
                                           
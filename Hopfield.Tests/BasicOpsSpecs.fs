#light

open Microsoft.FSharp.Math
open Xunit
open FsxUnit.Syntax
open Ops

[<Fact>]
let it_converts_true_to_bipolar_1() =
    toBipolar true |> should equal 1.0

[<Fact>]
let it_converts_false_to_bipolar_negative_1() =
    toBipolar false |> should equal -1.0

[<Fact>]
let it_inverse_multiplies_matrices() =
    matrix [[ -1.0; 1.0; -1.0; 1.0 ]]
        |> inverseMultiply 
        |> should equal (matrix [[ 1.0; -1.0;  1.0; -1.0];
                                 [-1.0;  1.0; -1.0;  1.0];
                                 [ 1.0; -1.0;  1.0; -1.0];
                                 [-1.0;  1.0; -1.0;  1.0]]);
                                          
[<Fact>]
let it_subtracts_identity() =
    matrix [[ -1.0; 1.0; -1.0; 1.0 ]] 
        |> inverseMultiply
        |> subtractIdentity
        |> should equal (matrix [[ 0.0; -1.0;  1.0; -1.0];
                                 [-1.0;  0.0; -1.0;  1.0];
                                 [ 1.0; -1.0;  0.0; -1.0];
                                 [-1.0;  1.0; -1.0;  0.0]]);

[<Fact>]
let it_computes_contribution() =
    matrix [[ -1.0; 1.0; -1.0; 1.0 ]] 
        |> contribution 
        |> should equal (matrix [[ 0.0; -1.0;  1.0; -1.0];
                                 [-1.0;  0.0; -1.0;  1.0];
                                 [ 1.0; -1.0;  0.0; -1.0];
                                 [-1.0;  1.0; -1.0;  0.0]])

[<Fact>]
let it_can_get_the_columns_of_a_matrix() =
    let m = matrix [ [  1.0;  2.0;  3.0;  4.0 ];
                     [  5.0;  6.0;  7.0;  8.0 ];
                     [  9.0; 10.0; 11.0; 12.0 ];
                     [ 13.0; 14.0; 15.0; 16.0 ] ]
    m |> column 0 |> should equal (matrix [ [1.0];  [5.0];  [9.0]; [13.0] ])
    m |> column 1 |> should equal (matrix [ [2.0];  [6.0]; [10.0]; [14.0] ])
    m |> column 2 |> should equal (matrix [ [3.0];  [7.0]; [11.0]; [15.0] ])
    m |> column 3 |> should equal (matrix [ [4.0];  [8.0]; [12.0]; [16.0] ])

[<Fact>]
let it_can_be_presented_a_pattern() =
     Matrix.zero 4 4
        |> present [ false; true; false; true ]
        |> should equal [ false; false; false; false ]
        
[<Fact>]
let it_can_be_trained_to_recognize_the_same_patterns_its_trained_with() =
    let p1 = [ true; true; false; false ]
    Matrix.zero 4 4 |> train p1 |> present p1 |> should equal p1
        
[<Fact>]
let it_can_be_trained_to_recognize_patterns_simmilar_to_what_its_trained_with() =
    let p1 = [ true; true; false; false ]
    let p2 = [ true; false; false; false ]
    
    let weights = Matrix.zero 4 4 |> train p1
    weights |> present p1 |> should equal p1
    weights |> present p2 |> should equal p1
        
#light

open System.Windows.Controls
open System.Windows.Input
open Microsoft.FSharp.Math
open Hopfield
open Graphs

let makeModel n w p =
    new ViewModel(n, w, p, (makeGraph w)) 

let initView v : unit =
    ignore()

let getModel (view:obj) = 
    let v = view :?> UserControl
    v.DataContext :?> ViewModel
    
let setModel (s:obj) (oldModel:ViewModel) pattern : unit =
    let view = s :?> UserControl
    view.DataContext <- makeModel oldModel.NumberOfNodes oldModel.Weights pattern

let identify (s:obj) (e:ExecutedRoutedEventArgs) : unit = 
    let model = getModel s
    Ops.present (List.of_seq model.Pattern) model.Weights 
        |> Array.of_list 
        |> setModel s model

let train (s:obj) (e:ExecutedRoutedEventArgs) : unit =
    let model = getModel s
    let w = Ops.train (List.of_seq model.Pattern) model.Weights
    let graph = makeGraph w
    setModel s model model.Pattern


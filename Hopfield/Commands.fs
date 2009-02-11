#light

namespace Hopfield

    open System.Collections.Generic
    open System.Windows
    open System.Windows.Controls
    open System.Windows.Input
    open System.Windows.Threading
    open Microsoft.FSharp.Math
    open ApplicationCore.XamlHelpers

    type Commands() =

        static let _dispatcher = Dispatcher.CurrentDispatcher
        static let trainCommand = new RoutedUICommand("Train", "train", typeof<Commands>)
        static let identifyCommand = new RoutedUICommand("Identify", "identify", typeof<Commands>)
        
        static let identify (s:obj) (e:ExecutedRoutedEventArgs) : unit = 
            let view = s :?> UserControl
            let model = view.DataContext :?> HopfieldViewModel
            let p = Ops.present (List.of_seq model.Pattern) model.Weights |> Array.of_list
            view.DataContext <- new HopfieldViewModel(model.NumberOfNodes, model.Weights, p)
        
        static let canIdentify s e = true

        static let train (s:obj) (e:ExecutedRoutedEventArgs) : unit =
            let view = s :?> UserControl
            let model = view.DataContext :?> HopfieldViewModel
            let w = Ops.train (List.of_seq model.Pattern) model.Weights
            view.DataContext <- new HopfieldViewModel(model.NumberOfNodes, w, model.Pattern)
        
        static let canTrain s e = true

        static member public Train with get() = trainCommand
        
        static member public Identify with get() = identifyCommand

        static member public AddCommands view = 
            command view identifyCommand identify canIdentify
            command view trainCommand train canTrain
                        

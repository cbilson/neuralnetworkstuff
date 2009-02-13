#light

namespace Hopfield

    open System.Windows.Input
    open System.Windows.Threading
    open ApplicationCore.XamlHelpers

    type Commands() =

        static let _dispatcher = Dispatcher.CurrentDispatcher
        static let trainCommand = new RoutedUICommand("Train", "train", typeof<Commands>)
        static let identifyCommand = new RoutedUICommand("Identify", "identify", typeof<Commands>)
                
        static member public Train with get() = trainCommand
        
        static member public Identify with get() = identifyCommand

        static member public AddCommands view = 
            command view identifyCommand Controller.identify (fun _ _ -> true)
            command view trainCommand Controller.train (fun _ _ -> true)
                        

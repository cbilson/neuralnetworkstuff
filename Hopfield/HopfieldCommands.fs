#light

namespace Hopfield

    open System.Windows
    open System.Windows.Input
    open System.Windows.Threading

    type HopfieldCommands() =

        static let _dispatcher = Dispatcher.CurrentDispatcher
        static let trainCommand = new RoutedUICommand("Train", "train", typeof<HopfieldCommands>)
        static let identifyCommand = new RoutedUICommand("Identify", "identify", typeof<HopfieldCommands>)

        static member public Train with get = trainCommand
        
        static member public Identify with get = identifyCommand
        
            

#light

open System.Windows.Input
open System.Windows.Threading


type HopfieldCommands() =

    static let _dispatcher = Dispatcher.CurrentDispatcher
    static let trainCommand = new RoutedUICommand("Train", "train", typeof<HopfieldCommands>)
    static let identifyCommand = new RoutedUICommand("Identify", "identify", typeof<HopfieldCommands>)

    static member public Train with get = trainCommand
    
    static member public CanExecuteTrainCommand _ (args:CanExecuteRoutedEventArgs) : unit = 
        args.Handled <- true

    //static member public ExecuteTrainCommand _ (args:ExecuteRoutedEventArgs) : unit = ()
    
    static member public Identify with get = identifyCommand
    
        

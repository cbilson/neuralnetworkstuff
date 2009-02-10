#light

#r "PresentationCore"
#r "PresentationFramework"
#r "WindowsBase"

open System.Windows.Input

let handler (f:obj -> ExecutedRoutedEventArgs -> unit) = 
    new ExecutedRoutedEventHandler(f)

let canExecute (f:obj -> CanExecuteRoutedEventArgs -> unit) =
    new CanExecuteRoutedEventHandler(f)
    
let copyHandler s e = ()

let canCopy s (e:CanExecuteRoutedEventArgs) = e.CanExecute <- true

let causeCompilerError = 
    new CommandBinding(ApplicationCommands.Copy, handler copyHandler, canExecute canCopy)
    
    
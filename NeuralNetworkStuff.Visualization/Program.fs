#light

open System
open System.Windows
open System.Windows.Controls
open XamlHelpers

let mainWin =
    let win = loadXaml<Window> "MainWindow"
    win.Title <- "Neural Network Stuff :: Visualization"
    win

let showView n (w:Window) =
    let va = w.FindName("viewArea") :?> ContentControl
    let v = loadXaml<Control> n :> obj
    va.Content <- v

#if COMPILED
[<STAThread>]
do
    let w = mainWin
    showView "HopfieldView" w
    
    w.Show()

    let app = new Application() in
        app.Run() |> ignore
        
#endif
#light

open System
open System.Windows
open XamlHelpers

#if COMPILED
[<STAThread>]
do
    let win = loadXamlWindow "MainWindow"
    win.Title <- "Neural Network Stuff :: Visualization"
    win.Show()

    let app = new Application() in
        app.Run() |> ignore
        
#endif
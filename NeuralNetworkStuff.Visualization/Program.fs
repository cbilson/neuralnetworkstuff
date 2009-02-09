#light

open System
open System.Reflection
open System.Windows
open System.Windows.Controls
open ApplicationCore.XamlHelpers
open Hopfield

let mainWin =
    let win = loadXaml<Window> "MainWindow" <| Assembly.GetExecutingAssembly()
    win.Title <- "Neural Network Stuff :: Visualization"
    win

let showView n (w:Window) asm =
    let va = w.FindName("viewArea") :?> ContentControl
    let v = loadXaml<Control> n asm :> obj
    va.Content <- v

#if COMPILED
[<STAThread>]
do
    let w = mainWin
    showView "HopfieldView" w <| Assembly.GetAssembly(typeof<Hopfield.HopfieldModule>)
    
    w.Show()

    let app = new Application() in
        app.Run() |> ignore
        
#endif
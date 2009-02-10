#light

open System
open System.Reflection
open System.Windows
open System.Windows.Controls
open ApplicationCore.App
open ApplicationCore.XamlHelpers
open Hopfield.Module

let mainWin =
    let win = loadXaml<Window> "MainWindow" <| Assembly.GetExecutingAssembly()
    win.Title <- "Neural Network Stuff :: Visualization"
    win

#if COMPILED
[<STAThread>]
do
    let w = mainWin
    showHopfieldView w
    
    w.Show()

    let app = new Application() in
        app.Run() |> ignore
        
#endif
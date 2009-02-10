﻿#light

namespace Hopfield

    open System.Reflection
    open System.Windows.Controls
    open System.Windows.Input
    open ApplicationCore.App
    open ApplicationCore.XamlHelpers

    module Module =

        let ModuleName = "Hopfield Network"
        
        let showHopfieldView w =
            let view = showView "HopfieldView" w 
                            <| Assembly.GetExecutingAssembly() 
                            :?> UserControl
            
            Commands.AddCommands view
            view.DataContext <- new HopfieldViewModel() :> obj
                
            
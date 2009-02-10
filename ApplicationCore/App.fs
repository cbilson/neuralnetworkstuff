#light

namespace ApplicationCore

open System
open System.Reflection
open System.Windows
open System.Windows.Controls
open ApplicationCore.XamlHelpers

module App =

    let showView n (w:Window) asm =
        let va = w.FindName("viewArea") :?> ContentControl
        let v = loadXaml<Control> n asm :> obj
        va.Content <- v
        v


#light

open System
open System.IO
open System.Reflection
open System.Windows
open System.Windows.Markup

let getResourceName name = sprintf "%s.xaml" name

let getResourceStream name = 
    Assembly.GetExecutingAssembly().GetManifestResourceStream
    <| getResourceName name
    
let loadXamlWindow name =
    use stream = getResourceStream name
    stream |> XamlReader.Load :?> Window


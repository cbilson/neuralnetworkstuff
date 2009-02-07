#light

open System
open System.IO
open System.Reflection
open System.Windows
open System.Windows.Controls
open System.Windows.Markup

let getResourceName name = sprintf "%s.xaml" name

let getResourceStream name = 
    Assembly.GetExecutingAssembly().GetManifestResourceStream
    <| getResourceName name

let loadXaml<'a> name =
    use stream = getResourceStream name
    if null = stream then failwith (sprintf "Couldn't find a resource named %s" name)
    stream |> XamlReader.Load :?> 'a
    

#light

namespace ApplicationCore

module XamlHelpers =

    open System
    open System.IO
    open System.Reflection
    open System.Windows
    open System.Windows.Controls
    open System.Windows.Markup

    let getResourceName name = sprintf "%s.xaml" name

    let getResourceStream name (asm:Assembly) = 
        asm.GetManifestResourceStream <| getResourceName name

    let loadXaml<'a> name asm =
        use stream = getResourceStream name asm
        if null = stream then failwith (sprintf "Couldn't find a resource named %s" name)
        stream |> XamlReader.Load :?> 'a
        

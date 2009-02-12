#light

namespace Hopfield

    open System.Collections.Generic
    open System.Drawing
    open System.Windows
    open System.Windows.Controls
    open System.Windows.Input
    open System.Windows.Media.Imaging
    open System.Windows.Threading
    open Microsoft.Glee.Drawing
    open Microsoft.FSharp.Math
    open ApplicationCore.XamlHelpers

    type Commands() =

        static let _dispatcher = Dispatcher.CurrentDispatcher
        static let trainCommand = new RoutedUICommand("Train", "train", typeof<Commands>)
        static let identifyCommand = new RoutedUICommand("Identify", "identify", typeof<Commands>)
        
        static let identify (s:obj) (e:ExecutedRoutedEventArgs) : unit = 
            let view = s :?> UserControl
            let model = view.DataContext :?> HopfieldViewModel
            let p = Ops.present (List.of_seq model.Pattern) model.Weights |> Array.of_list
            view.DataContext <- new HopfieldViewModel(model.NumberOfNodes, model.Weights, p)
        
        static let canIdentify s e = true
        
        static let addNodes (w:matrix) (g:Graph) =
            let n = w.NumCols
            for i = 0 to (n-1) do
                g.AddNode (sprintf "n%d" i) |> ignore
                
        static let addEdges (w:matrix) (g:Graph) =
            let n = w.NumCols
            for i = 0 to (n-1) do
                for j = 0 to (n-1) do
                    if j <> i then
                        let n1 = sprintf "n%d" i
                        let n2 = sprintf "n%d" j
                        let label = sprintf "%e" (w.[i,j])
                        g.AddEdge(n1, n2, label) |> ignore
                        
                        
        static let makeGraph (w:matrix) = 
            let g = new Microsoft.Glee.Drawing.Graph("Network")
            addNodes w g
            addEdges w g
            let r = new Microsoft.Glee.GraphViewerGdi.GraphRenderer(g)
            let bmp = new Bitmap(400, 300, System.Drawing.Imaging.PixelFormat.Format32bppArgb)
            r.Render(bmp)
            bmp.Save(@"C:\Temp\tmp.png")
            let hbmp = bmp.GetHbitmap()
            let rect = new Int32Rect(0, 0, bmp.Width, bmp.Height)
            
            System.Windows.Interop.Imaging.CreateBitmapSourceFromHBitmap(hbmp, 
                                                                         System.IntPtr.Zero,
                                                                         rect, 
                                                                         BitmapSizeOptions.FromEmptyOptions())

        static let train (s:obj) (e:ExecutedRoutedEventArgs) : unit =
            let view = s :?> UserControl
            let model = view.DataContext :?> HopfieldViewModel
            let w = Ops.train (List.of_seq model.Pattern) model.Weights
            
            let graph = makeGraph w
            
            view.DataContext <- new HopfieldViewModel(model.NumberOfNodes, w, model.Pattern, graph)
        
        static let canTrain s e = true

        static member public Train with get() = trainCommand
        
        static member public Identify with get() = identifyCommand

        static member public AddCommands view = 
            command view identifyCommand identify canIdentify
            command view trainCommand train canTrain
                        

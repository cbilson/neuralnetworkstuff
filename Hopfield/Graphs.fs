#light

open System.Drawing
open System.Drawing.Imaging
open System.Windows
open System.Windows.Interop
open System.Windows.Media.Imaging
open Microsoft.FSharp.Math
open Microsoft.Glee.Drawing

let addNodes (w:matrix) (g:Graph) =
    let n = w.NumCols
    for i = 0 to (n-1) do
        g.AddNode (sprintf "n%d" i) |> ignore
        
let addEdges (w:matrix) (g:Graph) =
    let n = w.NumCols
    for i = 0 to (n-1) do
        for j = 0 to (n-1) do
            if j <> i then
                let n1 = sprintf "n%d" i
                let n2 = sprintf "n%d" j
                let label = sprintf "%e" (w.[i,j])
                g.AddEdge(n1, n2, label) |> ignore
                
let makeGraph (w:matrix) = 
    let g = new Microsoft.Glee.Drawing.Graph("Network")
    addNodes w g
    addEdges w g
    let r = new Microsoft.Glee.GraphViewerGdi.GraphRenderer(g)
    let bmp = new Bitmap(400, 300, PixelFormat.Format32bppArgb)
    r.Render(bmp)
    let hbmp = bmp.GetHbitmap()
    let rect = new Int32Rect(0, 0, bmp.Width, bmp.Height)
    
    Imaging.CreateBitmapSourceFromHBitmap(hbmp, 
                                          System.IntPtr.Zero,
                                          rect, 
                                          BitmapSizeOptions.FromEmptyOptions())

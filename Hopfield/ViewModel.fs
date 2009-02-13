#light

namespace Hopfield

    open System.Windows.Media
    open Microsoft.FSharp.Math

    type ViewModel(n,w,p:bool array,graph:Imaging.BitmapSource) =
        let mutable pattern = p
        
        new(n, m, a) = ViewModel(n, m, a, null)
        new(n) = ViewModel(n, Matrix.zero n n, Array.init n (fun x -> false), null)
        new() = ViewModel(4)
        
        member public x.NumberOfNodes with get() = n
        member public x.Weights with get() = w
        member public x.Pattern with get() = pattern
        member public x.Graph with get() = graph

        member public x.p1  
            with get() = pattern.[0]
            and  set(v) = pattern.[0] <- v

        member public x.p2 
            with get() = pattern.[1]
            and  set(v) = pattern.[1] <- v

        member public x.p3 
            with get() = pattern.[2]
            and  set(v) = pattern.[2] <- v

        member public x.p4 
            with get() = pattern.[3]
            and  set(v) = pattern.[3] <- v
            
        member public x.w11 with get() = w.[0,0]
        member public x.w21 with get() = w.Item(1,0)
        member public x.w31 with get() = w.Item(2,0)
        member public x.w41 with get() = w.Item(3,0)
        
        member public x.w12 with get() = w.Item(0,1)
        member public x.w22 with get() = w.Item(1,1)
        member public x.w32 with get() = w.Item(2,1)
        member public x.w42 with get() = w.Item(3,1)

        member public x.w13 with get() = w.Item(0,2)
        member public x.w23 with get() = w.Item(1,2)
        member public x.w33 with get() = w.Item(2,2)
        member public x.w43 with get() = w.Item(3,2)

        member public x.w14 with get() = w.Item(0,3)
        member public x.w24 with get() = w.Item(1,3)
        member public x.w34 with get() = w.Item(2,3)
        member public x.w44 with get() = w.Item(3,3)

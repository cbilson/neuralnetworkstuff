#light

namespace Hopfield

    open Microsoft.FSharp.Math

    type HopfieldViewModel(n,w,p) =
        new(n) = HopfieldViewModel(n, Matrix.zero n n, List.init n (fun _ -> true))
        new() = HopfieldViewModel(4)
        member public x.NumberOfNodes with get() = n
        member public x.Weights with get() = w
        member public x.Pattern with get() = p

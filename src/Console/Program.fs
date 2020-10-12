// Learn more about F# at http://docs.microsoft.com/dotnet/fsharp

module MyForgeConsoleApp

open MyLib

[<EntryPoint>]
let main (argv:string []) =
    let x = Say.hello "new"
    printfn "%s" x
    0
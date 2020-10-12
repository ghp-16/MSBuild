#r "paket:
nuget Fake.IO.FileSystem
nuget Fake.DotNet.MSBuild
nuget Fake.Core.Target //"
#load ".fake/build.fsx/intellisense.fsx"

open Fake.IO
open Fake.Core
open Fake.IO.Globbing.Operators //enables !! and globbing
open Fake.DotNet
open Fake.IO.FileSystemOperators
open Fake.Core.TargetOperators

// Properties
let buildDir = "./build/"
let sln = "mydemo.sln"

// Targets
Target.create "Clean" (fun _ ->
  Shell.cleanDir buildDir
  Trace.trace "Finish Clean Operator"
)

// Target.create "BuildApp" (fun _ ->
//   MSBuild.build id "*.sln"
// )

let setParams (defaults:MSBuildParams) =
        { defaults with
            DisableInternalBinLog = true
         }

Target.create "BuildApp" (fun _ ->
    // [sln]
    !! "src/**/*.fsproj"
    // |> MSBuild.runRelease setParams buildDir "Build"
    |> MSBuild.runDebug setParams buildDir "Build"
    |> Trace.logItems "AppBuild-Output: "
)

Target.create "Default" (fun _ ->
  Trace.trace "Hello World from FAKE"
)

// open Fake.Core.TargetOperators

// "Clean"
//   ==> "BuildApp"
//   ==> "Default"

// start build
Target.runOrDefault "BuildApp"
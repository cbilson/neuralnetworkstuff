#light

open Microsoft.FSharp.Math

let inverseMultiply m = (Matrix.transpose m) * m
    
let subtractIdentity m = m - Matrix.identity (m.NumRows) 

(*
    I want to use the code below, but I get the following exception 
    in BasicOpsSpecs.it_computes_contribution:
    
    ------ Test started: Assembly: Hopfield.Tests.dll ------

Gallio TestDriven.Net Runner - Version 3.0.5 build 546

Test Assemblies:
	C:\Projects\neuralnetworkstuff\Hopfield.Tests\bin\Debug\Hopfield.Tests.dll

Start time: 12:42 PM
Verifying assembly names.
Initializing the test runner.
Loading the test package.
Exploring the tests.
Running the tests.
Unloading the test package.
Disposing the test runner.
Stop time: 12:42 PM (Total execution time: 1.330 seconds)

Test Report: file:///C:/Documents%20and%20Settings/cbilson/Local%20Settings/Temp/Gallio.TDNetRunner/Hopfield.Tests.dll.html
** NO TESTS WERE RUN (No tests found) **
TestCase 'P:BasicOpsSpecs.it_computes_contribution' failed: The type initializer for 'BasicOpsSpecs' threw an exception.
	System.TypeInitializationException: The type initializer for 'BasicOpsSpecs' threw an exception. ---> System.TypeInitializationException: The type initializer for '<StartupCode$Hopfield.Tests>.$BasicOpsSpecs' threw an exception. ---> System.NullReferenceException: Object reference not set to an instance of an object.
	C:\Projects\neuralnetworkstuff\Hopfield.Tests\BasicOpsSpecs.fs(9,0): at <StartupCode$Hopfield.Tests>.$BasicOpsSpecs..cctor()
	   --- End of inner exception stack trace ---
	at BasicOpsSpecs..cctor()
	   --- End of inner exception stack trace ---
	at BasicOpsSpecs.get_it_computes_contribution()


0 passed, 1 failed, 0 skipped, took 2.20 seconds (Ad hoc).

*)
let contribution =  inverseMultiply >> subtractIdentity


(*
    The work-around is simple:
    
    let contribution() =  inverseMultiply >> subtractIdentity
    
    -or-
    
    let contribution m =  m |> (inverseMultiply >> subtractIdentity)
    
    But the other people in the mailing list I am on thought I should report this.
*)
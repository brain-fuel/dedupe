module Tests

open System
open Xunit
open System.Text

[<Fact>]
let ``This test should pass`` () =
    let byteArray = Encoding.UTF8.GetBytes("foo")
    Xunit.Assert.True(true)
open SingleBunny.DeDuplicator
open System
open System.Text
open System.Text.RegularExpressions

module Program =
    [<EntryPoint>]
    let main _ =
        let GuidString = Guid.NewGuid().ToString()
        printfn "%s{GuidString}" |> ignore
        //let UniqueString = "bar" + GuidString + "foo"
        //let UniqueString = GuidString + "foo"
        //let UniqueString = "foo"
        //let UniqueString = "bar" + GuidString
        //let UniqueString = "bar" + "foo"
        let UniqueString = "foobar"

        let UniqueStringToBytesAndBackAgain =
            Encoding.UTF8.GetBytes(UniqueString)
            |> Encoding.UTF8.GetString

        0

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
        let TestString = "foobar"

        let UniqueString =
            TestString
            |> Encoding.UTF8.GetBytes
            |> ToUniqueByteArray
            |> Encoding.UTF8.GetString

        let PlainString =
            TestString
            |> Encoding.UTF8.GetBytes
            |> ToPlainByteArray
            |> Encoding.UTF8.GetString

        printfn "Unique String: %s" UniqueString |> ignore
        printfn "Plain String : %s" PlainString |> ignore
        0

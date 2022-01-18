namespace SingleBunny

open System
open System.Text
open System.Text.RegularExpressions

module DeDuplicator =

    let private GuidRegexString =
        @"(?im)^[{(]?[0-9A-F]{8}[-]?(?:[0-9A-F]{4}[-]?){3}[0-9A-F]{12}[)}]?$"

    type private UniqueContents = { guid: Guid; contents: byte [] }

    let private ExtractGuidStringFromString (input: string) =
        (Regex.Match(input, GuidRegexString)).ToString()

    let private RemoveGuidFromString (input: string) =
        let GuidRegex = Regex GuidRegexString
        GuidRegex.Replace(input, "")

    let private MakeUniqueContentsFromByteArray (input: byte []) : UniqueContents =
        let inputString = Encoding.UTF8.GetString(input)
        let inputGuidString = ExtractGuidStringFromString(inputString)
        let inputGuid = Guid.TryParse(inputGuidString)

        let contents =
            inputString
            |> RemoveGuidFromString
            |> Encoding.UTF8.GetBytes

        match inputGuid with
        | true, guid -> { guid = guid; contents = contents }
        | false, _ ->
            { guid = Guid.NewGuid()
              contents = contents }

    let private RetrieveUniqueByteArrayFromUniqueContents (input: UniqueContents) : byte [] =
        let guidString = input.guid.ToString()
        let contentsString = Encoding.UTF8.GetString(input.contents)

        (guidString + contentsString)
        |> Encoding.UTF8.GetBytes

    let private RetrievePlainByteArrayFromUniqueContents (input: UniqueContents) : byte [] =
        let contentsString = Encoding.UTF8.GetString(input.contents)
        contentsString |> Encoding.UTF8.GetBytes

    let ToUniqueByteArray (input: byte []) : byte [] =
        input
        |> MakeUniqueContentsFromByteArray
        |> RetrieveUniqueByteArrayFromUniqueContents

    let ToPlainByteArray (input: byte []) : byte [] =
        input
        |> MakeUniqueContentsFromByteArray
        |> RetrievePlainByteArrayFromUniqueContents

// TODO: Make functions to convert any type to byte array

open System.IO
open Keywords
open Tokens
open VariableParser

let path = "../test" // eventually this will be a CLArg
let lines = try File.ReadAllLines path with | _ -> [|""|]
let linesInWords = lines |> Array.map splitIntoWords
let foundKeywords = Array.map findKeywords lines
let convertedKeywords = 
    Array.map (fun words -> 
        convertKeywordsToTokens words
    ) linesInWords
let test = convertVarLinesToTokens(convertedKeywords)

Array.iter (fun x -> printfn $"%A{x}") test

open System.IO
open Keywords
open Tokens

let path = "../test" // eventually this will be a CLArg
let lines = try File.ReadAllLines path with | _ -> [|""|]
let linesAsWords = lines |> Array.map splitIntoTokens
let foundKeywords = Array.map findKeywords lines
let convertedKeywords = 
    Array.map (fun words -> 
        convertKeywordsToTokens words
    ) linesAsWords

Array.iter (fun x -> printfn $"%A{x}") convertedKeywords
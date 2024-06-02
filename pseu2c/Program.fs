open System.IO

let keywords =
    [|
        "is"
        "as"
        "if"
        "else"
        "end"
        "loop"
        "to"
        "downTo"
        "while"
        "until"
        "by"
        "print"
        "puts"
    |]

let path = "../test" // eventually this will be a CLArg
let lines = try File.ReadAllLines path with | _ -> [|""|]
let splitEachLineIntoTokens (line : string) =
    line.Split(" ")

let findKeywords (line : string) =
    let words = line.Split(" ")
    words
    |> Array.filter (fun word ->
        Array.contains word keywords
    )

let linesInTokens =
    lines
    |> Array.map splitEachLineIntoTokens
let foundKeywords = Array.map findKeywords lines

Array.iter (fun x -> printfn $"Line: %A{x}") linesInTokens
Array.iter (fun x -> printfn $"Keywords: %A{x}") foundKeywords

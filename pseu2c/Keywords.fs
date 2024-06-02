module Keywords

let keywords =
    [|
        "is"
        "as"
        "if"
        "else"
        "end"
        "loop"
        "to"
        "downto"
        "while"
        "until"
        "by"
        "print"
        "puts"
    |]

let splitIntoWords (line : string) : string array =
    line.Split(" ")

let findKeywords (line : string) : string array =
    let words = line.Split(" ")
    words
    |> Array.filter (fun word ->
        Array.contains word keywords
    )
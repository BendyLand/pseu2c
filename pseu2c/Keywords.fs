module Keywords

open Tokens

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

/// <summary>Coverts any found keywords into tokens.</summary>
/// <param name="words">The lines of the source file, split into words.</param>
/// <returns>A new Tokens array array, with the keywords converted to tokens.</returns>
let convertKeywordsToTokens words =
    Array.map (fun word ->
        match word with
        | "is" -> IS
        | "as" -> AS
        | "if" -> IF
        | "else" -> ELSE
        | "end" -> END
        | "loop" -> LOOP
        | "to" -> TO
        | "downto" -> DOWNTO
        | "while" -> WHILE
        | "until" -> UNTIL
        | "by" -> BY
        | "print" -> PRINT
        | "puts" -> PUTS
        | "//" -> COMMENT
        | _ -> T(word)
    ) words

let split (line: string): string array =
    line.Split(" ")

/// <summary>Checks a given line for keywords, and returns any if found</summary>
/// <param name="line">The line of text to check for a keyword</param>
/// <returns>A new string array containing any keywords found in the argument</returns>
let findKeywords (line: string): string array =
    let words = line.Split(" ")
    words
    |> Array.filter (fun word ->
        Array.contains word keywords
    )

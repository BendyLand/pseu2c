module Tokens

type Types =
    | INT
    | DOUBLE
    | BOOL
    | CHAR
    | STRING
    | NULL

type VarTokens =
    | NAME of string
    | CTYPE of Types
    | VAL of string

type Tokens =
    | IS
    | AS
    | IF
    | ELSE
    | END
    | LOOP
    | TO
    | DOWNTO
    | WHILE
    | UNTIL
    | BY
    | PRINT
    | PUTS
    | COMMENT
    | T of string
    | VAR of VarTokens
    | VALUE of VarTokens
    | TYPE of VarTokens

let assignVarTypeToken token =
    match token with
    | "int" -> INT
    | "double" -> DOUBLE
    | "bool" -> BOOL
    | "char" -> CHAR
    | "string" -> STRING
    | _ -> NULL

let getValFromToken token =
    let opt =
        match token with
        | T value -> Some value
        | _ -> None
    match opt with
    | Some res -> res
    | None -> ""

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

module VariableParser

open System.Text.RegularExpressions
open Tokens

let hasImplicitType line = 
    not (Array.contains AS line)

let extractExplicitType line = 
    let idx = Array.findIndex (fun x -> x = AS) line
    let varType = 
        line[idx+1..] 
        |> Array.map getValFromToken 
        |> String.concat " " 
    match varType.ToLower() with
    | "int"    -> INT
    | "double" -> DOUBLE
    | "bool"   -> BOOL
    | "char"   -> CHAR
    | _        -> STRING

let inferType (value: string): Types = 
    let numericOnly    = Regex "[0-9]+"
    let numWithDecimal = Regex "[0-9]*\\.[0-9]+"
    let bool           = Regex "true|false"
    let stringChars    = Regex "..+"
    let singleChar     = Regex "^.?$"
    match value with
    | _ when numWithDecimal.IsMatch(value) -> DOUBLE
    | _ when numericOnly.IsMatch(value)    -> INT
    | _ when bool.IsMatch(value)           -> BOOL
    | _ when singleChar.IsMatch(value)     -> CHAR
    | _ when stringChars.IsMatch(value)    -> STRING
    | _  (* when none of the above *)      -> NULL

let extractVarName line = 
    let name = line |> Array.head
    let result = getValFromToken name
    result

let extractImplicitVariable (line: Tokens array) =
    let temp = 
        line 
        |> Array.tail 
        |> Array.tail
    let result = 
        temp 
        |> Array.map getValFromToken 
        |> String.concat " "
    result

let extractExplicitVariable line = 
    let temp = 
        line 
        |> Array.tail 
        |> Array.tail
    let idx = Array.findIndex (fun c -> c = AS) temp
    let varVal = 
        temp[..idx-1] 
        |> Array.map getValFromToken 
        |> String.concat " "
    varVal

let extractVariable line = 
    if hasImplicitType line then
        extractImplicitVariable line
    else
        extractExplicitVariable line

let convertVarLinesToTokens lines = 
    lines
    |> Array.map (fun line -> 
        if not (Array.contains IS line) then
            line
        else
            let varName = NAME(extractVarName line)
            let varValue = extractVariable line
            let varValueToken = VALUE(VAL(varValue))
            let mutable varType: Tokens = IS
            if hasImplicitType line then
                varType <- TYPE(CTYPE(inferType varValue)) 
            else
                varType <- TYPE(CTYPE(extractExplicitType line))
            [|VAR(varName); varType; varValueToken|]
    )

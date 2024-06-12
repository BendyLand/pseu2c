module VariableParser

open System.Text.RegularExpressions
open Tokens

/// <summary>Checks the given line for an explicit type.</summary>
/// <param name="line">The line to check for an explicit type.</param>
/// <returns>A boolean value of whether or not the line has an implicit type *(no AS token)*.</returns>
let hasImplicitType line = 
    not (Array.contains AS line)

/// <summary>Extracts the type from the given line.
/// This function assumes that you have already checked that the type is explicitly given.
/// **Do not call this before validation.**</summary>
/// <param name="line">The line to extract the type from.</param>
/// <returns>The explicit type from the line.</returns>
/// <exception cref="System.Collections.Generic.KeyNotFoundException">(From Array.findIndex): Thrown if `predicate` never returns true.</exception>
/// <exception cref="System.ArgumentNullException">(From Array.findIndex): Thrown when the input array is null.</exception>
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

/// <summary>Infers the type of the given value based on its contents.</summary>
/// <param name="value">The value to assess.</param>
/// <returns>The inferred type of the value.</returns>
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

/// <summary>Gets the future name of the variable from the given line.</summary>
/// <param name="line">The line to extract the variable name's token from.</param>
/// <returns>The name of the variable extracted from the line</returns>
let extractVarName line = 
    let name = line |> Array.head
    let result = getValFromToken name
    result

/// <summary>Extracts the value of the variable for implicitly typed lines.</summary>
/// <param name="line">The line to extract the value from.</param>
/// <returns>The value of the variable, as a string.</returns>
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

/// <summary>Extracts the value of the variable for explicitly typed lines.</summary>
/// <param name="line">The line to extract the value from.</param>
/// <returns>The value of the variable, as a string.</returns>
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

/// <summary>Extracts the variable from the given line</summary>
/// <param name="line">The line to extract the value from.</param>
/// <returns>The value of the variable, as a string.</returns>
let extractVariable line = 
    if hasImplicitType line then
        extractImplicitVariable line
    else
        extractExplicitVariable line

/// <summary>Coverts any variable declarations into tokens.</summary>
/// <param name="line">The line of text to convert.</param>
/// <returns>A new Tokens array array, with the variable lines fully converted to tokens.</returns>
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

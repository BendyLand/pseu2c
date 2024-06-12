module Tokens

/// <summary>Types to correspond to their eventual C types. 
/// 'Strings' will translate to either a char* or char[], 
/// depending on the context it is coming from.</summary>
type Types =
    | INT
    | DOUBLE
    | BOOL
    | CHAR
    | STRING
    | NULL

/// <summary>The pieces that make up a variable declaration.</summary>
type VarTokens =
    | NAME of string
    | CTYPE of Types
    | VAL of string

/// <summary>The general tokens which will make up the intermediate representation of the data.</summary> 
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

/// <summary>Extracts the value contained inside of a given token.</summary>
/// <param name="token">The token to get the value from.</param>
/// <returns>The internal value of the original token, or None.</returns>
let getValFromToken token =
    let opt =
        match token with
        | T value -> Some value
        | _ -> None
    match opt with
    | Some res -> res
    | None -> ""


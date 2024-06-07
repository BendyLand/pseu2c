module Tokens

type Types = 
    | INT 
    | DOUBLE
    | BOOL
    | CHAR 
    | STRING

type Tokens = 
    | ID of string 
    | VALUE of Types
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

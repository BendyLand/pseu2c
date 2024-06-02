# pseu2c

*`pseu2c` is currently in early stages of development and is non-functional*

This is a transpiler tool which takes pseudocode-like syntax and generates roughly equivalent C code. 

This is a basic tool which can handle the fundamental constructs of programming; variable declaration, conditionals, and loops. There will also be keywords for printing. 

There is no abstraction built into this tool (e.g. you cannot group these constructs into functions and name them). The entire point is that this tool will take the legwork out of manually typing out the constructs themselves, but not more than that. You can chain them together, but the intended purpose of this tool is to generate the boilerplate. It is not meant to write entire programs. 

## Usage

TODO

## Keywords

Certain keywords will trigger certain corresponding C constructs. These keywords can be roughly grouped into four categories: variable declaration, conditionals, loops, and logging. 

 - **Variable Declaration**:
    - `is`
    - `as`
 - **Conditionals**:
    - `if`
    - `else`
    - `end`
 - **Loops**:
    - `for`
    - `down`
    - `to`
    - `until`
    - `end`
 - **Logging**:
    - `print`
    - `puts`

**Logic is separated by newlines.** 

**Comments**
Comments can only be included at the start of lines. Using "//" beyond the first two columns will not be recognized and will cause an error. 
```
// Correct
x is 25 // Incorrect

if x > 10
// Correct
    // Incorrect
```

## Examples

```
// Variable Declaration

num is 42                      -> int num = 42;
line is an example of a string -> char line[] = "an example of a string";
text is 25 as string           -> char text[] = "25";
text2 is 26 as char ptr        -> char* text2 = "26";
```
```
// Conditionals

if num > 10 
// do something
else num > 0
// do something different
else
// do a third thing
end

Translates to...

if num > 10  -> if (num > 10) {}
else num > 0 -> else if (num > 10) {}
else         -> else {}
end

// Notice that there is no "else if". 
// The possible options are: 
//    `if <condition>`
//    `else <condition>`
//    `else\n`
//    `end`
// The code to be placed inside each conditional block will be separated by newlines. 
// In short, whitespace does not matter, but newlines do. 
```
```
// Loops
TODO
```
```
// Logging
TODO
```

## Installation

TODO

## Future Plans

TODO
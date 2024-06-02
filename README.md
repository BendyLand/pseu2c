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
    - `loop`
    - `to`
    - `downTo`
    - `while`
    - `until`
    - `by`
    - `end`
 - **Logging**:
    - `print`
    - `puts`

*Logic is separated by newlines.*

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

**Variable Declaration**
```
num is 42
num2 is 3.14
line is an example of a string
text is 25 as str
text2 is 26 as char ptr
```
*Translates to...*
```
int num = 42;
double num2 = 3.14;
char line[] = "an example of a string";
char text[] = "25";
char* text2 = "26";
```

**Conditionals**
```
if num > 10
// do something
else num > 0
// do something different
else
// do a third thing
end
```
*Translates to...*
```
if (num > 10) {
    // do something; (allowed to be indented here)
}
else if (num > 0) {
    // do something different
}
else {
    // do a third thing
}

// Notice that there is no "else if".
// The possible options are:
//    `if <condition>`
//    `else <condition>`
//    `else\n`
//    `end`
// The code to be placed inside each conditional block will be separated by newlines.
// In short, whitespace does not matter, but newlines do.
```

**Loops**
**For loops**
```
loop i; 0 to 10
// do something 11 times
end

loop j; 10 downTo 1 by -3
// do something 4 times
end
```
*Translates to...*
```
for (int i = 0; i <= 10; i++) {
    // do something 11 times
}

for (int j = 10; j >= 1; j -= 3) {
    // do something 4 times
}
```
**While loops**
```
loop num is 0; while num <= 10
// this one includes an increment by default
end

loop num is 0; until num > 10
// this is the inverse of the last one
end
```
*Translates to...*
```
int num = 0;
while (num <= 10) {
    // this one includes an increment by default
    num++;
}

int num = 0;
while (!(num > 10)) {
    // this is the inverse of the last one
    num++;
}
```
**Unsafe while loops**
```
loop _ ; while <condition>
// this one doesn't include an increment;
// it relies on the existing condition parameters.
// (e.g. variables need to be initialized).
end

loop _
// purposeful infinite loop
end
```
*Translates to...*
```
while (<condition>) {
    // this one doesn't include an increment;
    // it relies on the existing condition parameters.
    // (e.g. variables need to be initialized).
}

while (1) {
    // purposeful infinite loop
}
```

**Logging**
```
TODO
```

## Installation

TODO

## Future Plans

TODO
# pseu2c

*`pseu2c` is currently in early stages of development and is non-functional*

This is a transpiler tool which takes pseudocode-like syntax and generates roughly equivalent C code. 

This is a basic tool which can handle the fundamental constructs of programming; variable declaration, conditionals, and loops. There will also be keywords for printing. 

There is no abstraction built into this tool (e.g. you cannot group these constructs into functions and name them). The entire point is that this tool will take the legwork out of manually typing out the constructs themselves, but not more than that. You can chain them together, but the intended purpose of this tool is to generate the boilerplate. It is not meant to write entire programs. 

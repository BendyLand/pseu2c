# pseu2c

This is a transpiler tool which takes pseudocode-like syntax and generates roughly equivalent C code. 

This is a basic tool which can handle the fundamental constructs of programming; variable declaration, conditionals, and loops. 

There is no abstraction built into this tool (e.g. you cannot group these constructs into functions and name them). The entire point is that this tool will take the legwork out of manually typing out the constructs themselves, but not more than that. 
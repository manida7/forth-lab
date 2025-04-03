\ =========================================================
\ Forth Lab File
\ =========================================================
\
\ This file will introduce some basic Forth concepts:
\   - Defining words
\   - Stack operations
\   - Conditionals (if ... else ... then)
\   - Comparison operators (<)
\   - Negation (my-negate)
\ Then, at the end, you have tasks to complete and tests to run.

\ ---------------------------------------------------------
\ Intro: Defining Words
\ ---------------------------------------------------------
\ In Forth, we define a new word like this:
\   : <name> ( <stack-comment> )
\       <Forth code>
\   ;
\
\ The part in parentheses is just a comment describing
\ what the word consumes and produces on the stack.
\ Example:  ( n -- 2n ) means this word takes one number n
\ from the stack and leaves 2n on the stack.

\ ---------------------------------------------------------
\ Example 1: hello
\ ---------------------------------------------------------
\ This word prints "Hello, World!" followed by a newline.
\ We'll call this at the end as a demo.
: hello ( -- )
  ." Hello, World!" cr
;

\ ---------------------------------------------------------
\ Example 2: double
\ ---------------------------------------------------------
\ This word takes a single number n from the stack
\ and leaves 2n on the stack.
\ Usage:
\   5 double .  ( prints 10 )
: double ( n -- 2n )
  2 *
;

\ ---------------------------------------------------------
\ Example 3: sum2
\ ---------------------------------------------------------
\ This word takes two numbers (n1, n2) from the stack,
\ sums them, prints the result, and prints a newline.
\ Usage:
\   4 7 sum2    ( prints 11 )
: sum2 ( n1 n2 -- )
  + .
  cr
;

\ ---------------------------------------------------------
\ Example 4: squared
\ ---------------------------------------------------------
\ This word takes one number n and leaves n^2 on the stack.
\ We use DUP (duplicate top of stack) and * (multiply).
: squared ( n -- n^2 )
  dup *
;

\ ----------------------------------------------------------
\     Now let's introduce conditionals and comparisons
\ ----------------------------------------------------------
\ In Forth, we often compare two numbers ( n1 n2 ) using words
\ like < (less than). This leaves a "flag" (true/false) on the stack.
\ In Forth:
\   TRUE = -1
\   FALSE = 0
\ So:
\   1 2 < .   \ prints -1 (true)
\   2 1 < .   \ prints 0  (false)
\   1 1 < .   \ prints 0  (false)
\
\ The conditional syntax is:
\   <flag> IF
\       <code if true>
\   ELSE
\       <code if false>
\   THEN
\
\ Forth consumes the flag from the stack when doing IF.
\ If the flag is nonzero (-1), the IF-part runs,
\ otherwise the ELSE-part runs.

\ ----------------------------------------------------------
\ Tasks Section
\ ----------------------------------------------------------
\ Below are tasks for you. Fill in the definitions where indicated.
\ Then scroll down to the "Test calls" at the end to see
\ how they should behave when you run gforth.

\ Task 0: Define a word cubed ( n -- n^3 )
\         using DUP and * to compute n^3
\ Example usage:
\   3 cubed .   -> prints 27
: cubed ( n -- n^3 )
  \ TODO: fill in the code. One approach:
  \   dup dup * *
  \ or  dup dup * swap *   (there are multiple ways)
  \ Replace what's below with actual code:
." no solution "
  cr
;

\ Task 1: Define a word is-less? ( n1 n2 -- )
\         that compares n1 < n2 using <, and prints
\         "YES" if true or " no" if false, then a newline.
\ Example:
\   1 2 is-less?   -> prints YES
\   2 1 is-less?   -> prints NO
: is-less? ( n1 n2 -- )
." no solution "
  cr
;

\ Task 2: Define a word my-negate ( n -- -n )
\         that leaves -n on the stack, but does NOT print.
\ Usage:
\   5 my-negate .  -> prints -5
\   -3 my-negate . -> prints 3
: my-negate ( n -- -n )
." no solution "
  cr
;

\ ----------------------------------------------------------
\ Task 3: a^2 + b^2
\ ----------------------------------------------------------
\   a^2 + b^2
\
\ We already have a word 'squared' that takes one number and
\ leaves its square on the stack.

\ Task: Define squaresum ( a b -- a^2+b^2 )
\   - Takes two numbers a and b from the stack
\   - Leaves a^2 + b^2 on the stack (but does not print)
\   - Use the 'squared' word to make this simpler.

\ Example usage:
\   3 4 squaresum . cr   \ should print 25
\

: squaresum ( a b -- a^2+b^2 )
  \ HINT:
  \   You can rearrange the stack and call 'squared' twice,
  \   then add the results.
." no solution "
;

\ ----------------------------------------------------------
\ Task 4: (a + b)^2
\ ----------------------------------------------------------
\ We know that (a + b)^2 = a^2 + 2ab + b^2.
\ But we can simply do:
\    - add a + b
\    - then square the result
\ using our existing word 'squared', or define a direct approach.

\ Task: Define square-of-sum ( a b -- (a+b)^2 )
\       Takes two numbers a and b from the stack,
\       sums them, and squares the result, leaving (a+b)^2 on the stack.

: square-of-sum
\ ( a b -- (a+b)^2 )
." no solution "
  cr
;

\ ----------------------------------------------------------
\ Test calls (execution)
\ ----------------------------------------------------------
\ Below we actually call the words we defined above.
\ When you run:
\    gforth lab.fs > out.txt
\ you'll see the output of these calls in out.txt.

cr
." -- Running Tests --" cr

\ Hello world test
." 1) hello ->" cr
hello

\ Double test
." 2) double 5 ->" cr
5 double . cr
\ expect 10

\ sum2 test
." 3) sum2 (4 + 7) ->" cr
4 7 sum2
\ expect 11

\ squared test (given example)
." 4) squared 5 ->" cr
5 squared . cr
\ expect 25

\ cubed test (Task 0)
." 5) cubed 3 ->" cr
3 cubed . cr
\ expect 27

\ is-less? test (Task 1)
." 6) is-less? ->" cr
1 2 is-less?      \ expect YES
2 1 is-less?      \ expect NO
1 1 is-less?      \ expect NO

\ my-negate test (Task 2)
." 7) my-negate ->" cr
5 my-negate . cr  \ expect -5
-3 my-negate . cr \ expect 3

\ ----------------------------------------------------------
\ Test for squaresum
\ ----------------------------------------------------------
\ We'll just run a couple of examples to show that squaresum
\ leaves the correct result on the stack. Then we print it.

cr
." squaresum tests:" cr

3 4 squaresum . cr   \ expect 25
5 0 squaresum . cr   \ expect 25
1 1 squaresum . cr   \ expect 2
2 1 squaresum . cr   \ expect 5

\ ----------------------------------------------------------
\ Test for square-of-sum
\ ----------------------------------------------------------
\ We'll run a few examples:

cr
." square-of-sum tests:" cr

1 1 square-of-sum . cr    \ (1+1)^2 = 4
2 3 square-of-sum . cr    \ (2+3)^2 = 25
5 0 square-of-sum . cr    \ (5+0)^2 = 25
3 4 square-of-sum . cr    \ (3+4)^2 = 49




\ End the interpreter after tests:
bye

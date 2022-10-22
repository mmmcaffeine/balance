# Balance

## Challenge

Write a program to determine if the parentheses `()`, the brackets `[]`, and the braces `{}`, in a string are balanced.

## Examples

* `{{)(}}` is not balanced because `)` comes before `(`
* `({)}` is not balanced because `)` is not balanced between `{}` (and the `{` is not balanced between `()`)
* `[({})]` is balanced
* `{}([])` is balanced
* `{()}[[{}]]` is balanced

## Mark's "Extra Credit"

The initial challenge and examples were as I found them on [Cyber Dojo](https://cyber-dojo.org/creator/choose_problem?). As they were a bit too easy I decided to knock it up a notch and see if I could deal with the following scenarios:

* Allow the caller to specify their own delimiters
* Handle text between the delimiters e.g. `{1, 2, 3}`
* Handle the starting and ending values being the same e.g. `"my string"`
* Handle the starting and ending values consisting of multiple characters e.g. `<!--` and `-->`

## To Do

There is currently no parameter validation, and some combinations wouldn't make much sense to use. We should validate for:

1. No delimiters being supplied; we must have _at least_ one start and end pair
1. When one pair consists of a start value that is the subset of the end value, or vice versa e.g. `<!--` and `!`
1. When multiple pairs use the same values e.g. the first pair is `<!--` and `-->` and the second pair is `<!--` and `!>`

It _might_ be possible to make scenarios 2 and 3 work. For example, in scenario 2 _how_ we interpret the `!` character could be determined by what else is around it in the string.

# FizzBuzz

## Challenge

* How many ways can you find to solve this classic problem?
* How fast can you make an algorithm?
* How little memory do you need to consume?
* Can you make the game configurable, but still perform quickly?
    * Allow the user pass in any number of pairs of divisor and string values e.g. `var fizzBuzz = GetFizzBuzz(37, (3, "Fizz), (5, "Buzz"));` or similar

# Add Digits

## Challenge

Given a non-negative integer, repeatedly add all its digits until the result has only one digit.

## Examples

* An input of `38` gives an output of `2`
    * `3 + 8 = 11`
    * `1 + 1 = 2`
* An input of `1337` gives an output `5`
    * `1 + 3 + 3 + 7 = 14`
    * `1 + 4 = 5`

## Links

* There is a [JSFiddle](https://jsfiddle.net/ryanaiimi/dv1y6gf9/5/)
* There is a [.NET Fiddle](https://dotnetfiddle.net/DSdjYX)

# Optimisations

This project is not a programming challenge per se; it is a location to practice with micro-optimisations and thus learn more about low-level memory management in C#, which APIs are slow, which are fast, and so forth.
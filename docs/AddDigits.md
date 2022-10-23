# AddDigits

## Performance Observations

* Treating the input as numeric and performing math operations against it was almost always faster than treating the input as a `string` and iterating the individual characters
* Maintaining a running total of individual digits rather than maintaining a `List<T>` and then summing it was orders of magnitude faster
  * This also had the advantage of eliminating any heap allocations and therefore garbage collection
* Using `Math.DivRem` was marginally faster than using a combination of the modulo and division operators
  * Presumably Microsoft have done some work to optimise the performance of `Math.DivRem`
* Using nested loops to eliminate tail recursion made no statistically significant difference to exection time
* Using a guard clause at the beginning of the method, eliminating the ternary operator at the end of the method and performing the tail-recursive call was marginally slower
  * Presumably this was because except in the trivial case (input less than 10) there is _always_ an extra frame added to the stack
* Using `Enumerable<T>.Aggregate` was significantly faster than using an `Enumerable.Select` to get the transformed values, and then a `Sum` operation to add them
* Using the ASCII values of individual characters and then offsetting by -48 was significantly faster than using `char.GetNumericValue`

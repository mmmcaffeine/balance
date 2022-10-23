const input = 987654321;

console.log('addDigitsUsingMath = ' + addDigitsUsingMath(input));
console.log('addDigitsUsingChars = ' + addDigitsUsingChars(input))

function addDigitsUsingMath(input) {
    let remaining = input;
    let runningTotal = 0;

    while(remaining > 0) {
        runningTotal += remaining % 10;
        remaining = Math.floor(remaining / 10);
    }

    runningTotal += remaining;

    return runningTotal < 10 ? runningTotal : addDigitsUsingMath(runningTotal);
}

function addDigitsUsingChars(input) {
    const digits = Array.from(input.toString());
    const reduced = digits.reduce((runningTotal, digit) => runningTotal + Number(digit), 0);

    return reduced < 10 ? reduced : addDigitsUsingChars(reduced);
}
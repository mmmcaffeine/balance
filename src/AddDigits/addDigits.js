const input = 987654321;

console.log('addDigitsUsingChars = ' + addDigitsUsingChars(input));

function addDigitsUsingChars(input) {
    const digits = Array.from(input.toString());
    const reduced = digits.reduce((runningTotal, digit) => runningTotal + Number(digit), 0);

    return reduced < 10 ? reduced : addDigitsUsingChars(reduced);
}
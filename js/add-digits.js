function addDigits(value) {
    let remaining = Number.parseInt(value);

    if (remaining.toString() !== value.toString()) throw Error('Must be a non-negative integer');
    if (remaining < 0) throw Error('Must be a non-negative integer');

    let total = 0;

    while (remaining > 0) {
        total += remaining % 10;
        remaining = Math.floor(remaining / 10);
    }

    return total <= 9
        ? total
        : addDigits(total);
}

exports.addDigits = addDigits;
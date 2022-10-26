const { addDigits } = require('./add-digits');

describe('addDigits', () => {
    const expectedErrorMessage = 'Must be a non-negative integer';

    // Test data taken from my C# tests, and does not yet account for JavaScript handling numbers differently
    it.each([
        [0, 0],
        [38, 2],
        [1337, 5],
        [1999999999, 1],
        [2147483647, 1],
        [3999999999, 3],
        [4199999999, 5],
        [4294967295, 3]
    ])('should recursively add digits of %p expecting %p', (value, expected) => {
        const actual = addDigits(value);
        expect(actual).toBe(expected);
    });

    // Test data taken from my C# tests, and does not yet account for JavaScript handling numbers differently
    it.each`
        value           | expected
        ${'0'}          | ${0}
        ${'38'}         | ${2}
        ${'1337'}       | ${5}
        ${'1999999999'} | ${1}
        ${'2147483647'} | ${1}
        ${'3999999999'} | ${3}
        ${'4199999999'} | ${5}
        ${'4294967295'} | ${3}
    `('should recursively add digits of string \'$value\' expecting $expected', ({ value, expected }) => {
        // Obviously we don't _really_ need this but it does serve to prove we're genuinely getting a string
        // value out of our table
        expect(typeof value === 'string').toBeTruthy();
        const actual = addDigits(value);
        expect(actual).toBe(expected);
    });

    it('should error when value is a negative integer', () => {
        expect(() => addDigits(-4)).toThrowError(expectedErrorMessage);
    });

    it('should error when value is not an integer', () => {
        expect(() => addDigits(83.5)).toThrowError(expectedErrorMessage);
    });

    it('should error when value cannot be parsed into a non-negative integer', () => {
        expect(() => addDigits('83.5')).toThrow(expectedErrorMessage);
    });

    it('should error when value cannot be parsed into a number', () => {
        expect(() => addDigits('this cannot be parsed to an integer')).toThrow(expectedErrorMessage);
    });
});
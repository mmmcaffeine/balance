const { addDigits } = require('./add-digits');

describe('addDigits', () => {
    const expectedErrorMessage = 'Must be a non-negative integer';

    it('should recursively add digits for a non-negative integer', () => {
        // 83 -> 8 + 3 = 11
        // 11 -> 1 + 1 = 2
        const actual = addDigits(83);
        expect(actual).toBe(2);
    });

    it('should recursively add digits for something that can be parsed to a non-negative integer', () => {
        const actual = addDigits('83');
        expect(actual).toBe(2);
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
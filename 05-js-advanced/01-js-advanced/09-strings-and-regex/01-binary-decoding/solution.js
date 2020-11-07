function solve()
{
    /**
     * @param {string} binary
     */
    function convertBinaryToText(binary)
    {
        const segmentLength = 8;
        const onesCount = binary.split('1').length - 1;
        let weight = onesCount;

        while (weight >= 10)
        {
            weight = Array.from(weight.toString()).reduce((sum, x) => sum + parseInt(x), 0);
        }

        let text = '';

        for (let current = 0; current < binary.length; ++current)
        {
            const segmentStart = current * segmentLength + weight;
            const binarySegment = binary.substr(segmentStart, segmentLength);
            const charCode = parseInt(binarySegment, 2);

            const isValidUppercaseChar = 65 <= charCode && charCode <= 90
            const isValidLowercaseChar = 97 <= charCode && charCode <= 122
            const isSpace = charCode === 32;

            if (isSpace
                || isValidUppercaseChar
                || isValidLowercaseChar)
            {
                text += String.fromCharCode(charCode);
            }
        }

        return text.toString();
    }

    const input = document.getElementById('input').value;

    const resultSpan = document.getElementById('resultOutput');

    resultSpan.textContent = convertBinaryToText(input);
}
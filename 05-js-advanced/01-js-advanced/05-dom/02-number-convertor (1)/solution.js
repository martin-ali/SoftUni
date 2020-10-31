function solve()
{
    const convertButton = document.getElementsByTagName('button')[0];
    const convertToSelect = document.getElementById('selectMenuTo');

    for (const radix of ['Binary', 'Decimal', 'Hexadecimal'])
    {
        const option = document.createElement('option');
        option.value = radix.toLowerCase();
        option.innerText = radix;

        convertToSelect.appendChild(option);
    }

    convertButton.addEventListener('click', event =>
    {
        const convertToDecimalFrom = {
            binary: number => parseInt(number, 2),
            decimal: number => parseInt(number, 10),
            hexadecimal: number => parseInt(number, 16)

        }

        const convertFromDecimalTo = {
            binary: number => number.toString(2),
            decimal: number => number.toString(10),
            hexadecimal: number => number.toString(16).toUpperCase()
        }

        const fromRadix = document.getElementById('selectMenuFrom').value;
        const toRadix = document.getElementById('selectMenuTo').value;

        const number = parseInt(document.getElementById('input').value);
        const numberInDecimal = convertToDecimalFrom[fromRadix](number);
        const convertedNumber = convertFromDecimalTo[toRadix](numberInDecimal);

        const resultInput = document.getElementById('result');
        resultInput.value = convertedNumber;
    });
}
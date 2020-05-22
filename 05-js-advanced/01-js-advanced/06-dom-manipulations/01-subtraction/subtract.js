function subtract()
{
    const firstNumber = parseFloat(document.getElementById('firstNumber').value);
    const secondNumber = parseFloat(document.getElementById('secondNumber').value);
    const resultDiv = document.getElementById('result');

    resultDiv.textContent = firstNumber - secondNumber;
}
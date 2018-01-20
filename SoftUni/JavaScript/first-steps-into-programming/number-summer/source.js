function calculateResult()
{
    let firstNumber = +document.getElementById('firstNumber').value;
    let secondNumber = +document.getElementById('secondNumber').value;

    document.getElementById('result').value = firstNumber + secondNumber;
}
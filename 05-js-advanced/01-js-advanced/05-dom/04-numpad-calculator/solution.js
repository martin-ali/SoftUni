function solve()
{
    /**
     * @param {string} expression
     */
    function spaceOutOperators(expression)
    {
        return expression.replace(/([/*\-+])/g, ' $& ').replace(/ +/g, ' ');
    }

    /**
     * @param {string} expression
     */
    function processExpression(expression)
    {
        // const parameters = expression.split(/[/*\-+ ]+/);
        // if (parameters.length !== 2)
        // {
        //     return NaN;
        // }

        const result = eval(expression).toString();
        return result;
    }

    const clearButton = document.getElementsByClassName('clear')[0];
    const expressionP = document.getElementById('expressionOutput');
    const resultP = document.getElementById('resultOutput');
    const keysDiv = document.getElementsByClassName('keys')[0];

    keysDiv.addEventListener('click', event =>
    {
        const clickedButton = event.target.value;

        if (clickedButton === '=')
        {
            resultP.textContent = processExpression(expressionP.textContent).trim();
        }
        else
        {
            let expression = spaceOutOperators(expressionP.textContent + clickedButton);
            expression = spaceOutOperators(expression)
            expressionP.textContent = expression.trim();
        }
    });

    clearButton.addEventListener('click', event =>
    {
        expressionP.textContent = '';
        resultP.textContent = '';
    });
}
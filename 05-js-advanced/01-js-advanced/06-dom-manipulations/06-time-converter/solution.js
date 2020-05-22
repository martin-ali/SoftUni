function attachEventsListeners()
{
    const unitInputs = document.querySelectorAll('input[type=text]');
    const inputByUnit = {};
    for (const unitInput of unitInputs)
    {
        inputByUnit[unitInput.id] = unitInput;
    }

    const inputButtons = document.querySelectorAll('input[type=button]');
    const buttonByUnit = {}
    for (const button of inputButtons)
    {
        buttonByUnit[button.id.replace('Btn', '')] = button;
    }

    const convertToSecondsFrom = {
        days: days => days * 60 * 60 * 24,
        hours: hours => hours * 60 * 60,
        minutes: minutes => minutes * 60,
        seconds: seconds => seconds
    };

    const convertFromSecondsTo = {
        days: seconds => seconds / 60 / 60 / 24,
        hours: seconds => seconds / 60 / 60,
        minutes: seconds => seconds / 60,
        seconds: seconds => seconds
    };

    for (const unit in inputByUnit)
    {
        const input = inputByUnit[unit];
        const button = buttonByUnit[unit];

        button.addEventListener('click', event =>
        {
            const value = parseFloat(input.value);
            const seconds = convertToSecondsFrom[unit](value);

            for (const newUnit in inputByUnit)
            {
                inputByUnit[newUnit].value = convertFromSecondsTo[newUnit](seconds);
            }
        });
    }
}
function addItem()
{
    const menuSelect = document.getElementById('menu');
    const textInput = document.getElementById('newItemText');
    const valueInput = document.getElementById('newItemValue');

    const text = textInput.value;
    const value = valueInput.value;

    textInput.value = '';
    valueInput.value = '';

    const option = document.createElement('option');
    option.textContent = text;
    option.value = value;

    menuSelect.appendChild(option);
}
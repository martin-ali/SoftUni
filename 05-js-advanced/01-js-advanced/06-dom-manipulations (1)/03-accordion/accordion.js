function toggle()
{
    const textDiv = document.getElementById('extra');
    const toggleButton = document.getElementsByClassName('button')[0].firstChild;

    if (textDiv.style.display === 'none')
    {
        textDiv.style.display = 'block';
        toggleButton.textContent = 'Less';
    }
    else
    {
        textDiv.style.display = 'none';
        toggleButton.textContent = 'More';
    }
}
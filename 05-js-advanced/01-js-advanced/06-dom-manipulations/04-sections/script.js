function create(words)
{
    const contentDiv = document.getElementById('content');
    for (const word of words)
    {
        const sectionDiv = document.createElement('div');
        const paragraph = document.createElement('p');

        paragraph.textContent = word;
        paragraph.style.display = 'none';

        sectionDiv.addEventListener('click', event =>
        {
            paragraph.style.display = 'block';
        });

        sectionDiv.appendChild(paragraph);
        contentDiv.appendChild(sectionDiv);
    }
}
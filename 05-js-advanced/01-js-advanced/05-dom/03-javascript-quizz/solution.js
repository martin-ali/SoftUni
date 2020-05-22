function solve()
{
    function advanceSection(questionSections, resultsUl, questionNumber, correctAnswers)
    {
        for (let current = 0; current <= questionNumber && current < questionSections.length; current++)
        {
            if (current === questionNumber)
            {
                questionSections[current].style.display = 'block';
            }
            else
            {
                questionSections[current].style.display = 'none';
            }
        }

        if (questionNumber === 3)
        {
            resultsUl.style.display = 'block';
            const header = resultsUl.getElementsByTagName('h1')[0];

            if (correctAnswers === questionSections.length)
            {
                header.textContent = 'You are recognized as top JavaScript fan!';
            }
            else
            {
                header.textContent = `You have ${correctAnswers} right answers`;
            }
        }
    }

    const resultsUl = document.getElementById('results');
    const questionSections = document.getElementsByTagName('section');
    const correctAnswers = ['onclick', 'JSON.stringify()', 'A programming API for HTML and XML documents'];

    let points = 0;
    let currentSection = 1;
    for (const questionSection of questionSections)
    {
        const answers = questionSection.getElementsByTagName('li');

        for (const answer of answers)
        {
            answer.addEventListener('click', event =>
            {
                const answer = event.target.textContent;

                if (correctAnswers.includes(answer))
                {
                    points++;
                }

                advanceSection(questionSections, resultsUl, currentSection++, points);
            });
        }
    }
}
function solve(entries)
{
    const submissionsByLanguage = {};
    const pointsByUser = new Map();
    entries.pop();

    for (let entry of entries)
    {
        const [user, language, currentResult] = entry.split('-');

        if (currentResult) // Entry
        {
            const oldResult = pointsByUser.get(user) || 0;

            pointsByUser.set(user, Math.max(oldResult, +currentResult));

            submissionsByLanguage[language] = submissionsByLanguage[language] + 1 || 1;
        }
        else // Ban
        {
            pointsByUser.delete(user);
        }
    }

    console.log('Results:');
    const sortedPointsByUser = [...pointsByUser.keys()]
        .sort((a, b) =>
        {
            if (pointsByUser.get(a) == pointsByUser.get(b))
            {
                // Ascending by name
                return a.localeCompare(b);
            }
            else
            {
                // Descending by points
                return pointsByUser.get(b) - pointsByUser.get(a);
            }
        });
    for (let user of sortedPointsByUser)
    {
        console.log(`${user} | ${pointsByUser.get(user)}`);
    }

    console.log('Submissions:');
    const sortedSubmissionsByLanguage = [...Object.keys(submissionsByLanguage)]
        .sort((a, b) =>
        {
            if (submissionsByLanguage[a] == submissionsByLanguage[b])
            {
                // Ascending by language
                return a.localeCompare(b);
            }
            else
            {
                // Descending ny submissions
                return submissionsByLanguage[b] - submissionsByLanguage[a];
            }
        });
    for (let language of sortedSubmissionsByLanguage)
    {
        console.log(`${language} - ${submissionsByLanguage[language]}`);
    }
}

// solve([
//     'Pesho-Java-84',
//     'Gosho-C#-70',
//     'Gosho-C#-84',
//     'Kiro-C#-94',
//     'exam finished'
// ]);

// solve([
//     'Pesho-Java-91',
//     'Gosho-C#-84',
//     'Kiro-JavaScript-90',
//     'Kiro-C#-50',
//     'Kiro-banned',
//     'exam finished'
// ]);
function getUniqueSequences(sequenceInputs)
{
    const sequences = [];

    for (const sequenceInput of sequenceInputs)
    {
        const sequence = JSON.parse(sequenceInput);

        sequences.push(sequence);
    }

    for (let first = 0; first < sequences.length; first++)
    {
        for (let second = 0; second < sequences.length; second++)
        {
            if (first === second || sequences[first].length !== sequences[second].length) continue;

            const firstSet = new Set(sequences[first]);
            const secondSet = new Set(sequences[second]);
            const thirdSet = new Set(sequences[first].concat(sequences[second]));

            if (thirdSet.size <= firstSet.size && thirdSet.size <= secondSet.size)
            {
                sequences.splice(second, 1);
                second--;
            }
        }
    }

    sequences.forEach(s => s.sort((a, b) => b - a));
    sequences.sort((a, b) => a.length - b.length);

    for (const sequence of sequences)
    {
        console.log(`[${sequence.join(', ')}]`);
    }
}
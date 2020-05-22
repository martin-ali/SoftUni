function solve(lines)
{
    'use strict';

    function sumTechniqueSkills(techniquesMap)
    {
        const techniquesArray = Array.from(techniquesMap);
        let totalSkill = 0;

        for (const [technique, skill] of techniquesArray)
        {
            totalSkill += skill;
        }

        return totalSkill;
    }

    lines.pop();

    const skillByTechniqueByGladiator = new Map();

    for (const line of lines)
    {
        if (line.includes('vs'))
        {
            const [challengerName, defenderName] = line.split(' vs ');

            const bothGladiatorsExist = skillByTechniqueByGladiator.has(challengerName)
                && skillByTechniqueByGladiator.has(defenderName);
            if (bothGladiatorsExist === false)
            {
                continue;
            }

            // Compare skills they have in common
            let challengerTotalSkills = 0;
            for (const [technique, skill] of skillByTechniqueByGladiator.get(challengerName))
            {
                const defender = skillByTechniqueByGladiator.get(defenderName);
                if (defender.has(technique))
                {
                    challengerTotalSkills += skill;
                }
            }

            let defenderTotalSkills = 0;
            for (const [technique, skill] of skillByTechniqueByGladiator.get(defenderName))
            {
                const challenger = skillByTechniqueByGladiator.get(challengerName);
                if (challenger.has(technique))
                {
                    defenderTotalSkills += skill;
                }
            }

            if (challengerTotalSkills > defenderTotalSkills)
            {
                skillByTechniqueByGladiator.delete(defenderName);
            }
            else if (defenderTotalSkills > challengerTotalSkills)
            {
                skillByTechniqueByGladiator.delete(challengerName);
            }
        }
        else
        {
            const [gladiator, technique, skillString] = line.split(' -> ');
            const newSkill = parseInt(skillString, 10);

            if (skillByTechniqueByGladiator.has(gladiator) === false)
            {
                skillByTechniqueByGladiator.set(gladiator, new Map());
            }

            if (skillByTechniqueByGladiator
                .get(gladiator)
                .has(technique) === false)
            {
                skillByTechniqueByGladiator
                    .get(gladiator)
                    .set(technique, 0);
            }

            const oldSkill = skillByTechniqueByGladiator
                .get(gladiator)
                .get(technique);
            skillByTechniqueByGladiator
                .get(gladiator)
                .set(technique, Math.max(oldSkill, newSkill));
        }
    }

    const sortedGladiators = Array.from(skillByTechniqueByGladiator);
    sortedGladiators.sort(([gladiatorA, techniquesA], [gladiatorB, techniquesB]) =>
    {
        const skillA = sumTechniqueSkills(techniquesA);
        const skillB = sumTechniqueSkills(techniquesB);

        // return skillA !== skillB
        //     ? skillB - skillA
        //     : gladiatorA.localeCompare(gladiatorB);

        if (skillA !== skillB)
        {
            return skillB - skillA;
        }
        else
        {
            return gladiatorA.localeCompare(gladiatorB);
        }
    });

    for (const [gladiator, techniques] of sortedGladiators)
    {
        let totalSkill = sumTechniqueSkills(techniques);

        console.log(`${gladiator}: ${totalSkill} skill`);
        const sortedTechniques = Array.from(techniques);
        sortedTechniques.sort(([techniqueA, skillA], [techniqueB, skillB]) =>
        {
            if (skillA !== skillB)
            {
                return skillB - skillA;
            }
            else
            {
                return techniqueA.localeCompare(techniqueB);
            }
        });

        for (const [technique, skill] of sortedTechniques)
        {
            console.log(`- ${technique} <!> ${skill}`);
        }
    }
}

// solve([
//     'Pesho -> BattleCry -> 400',
//     'Gosho -> PowerPunch -> 300',
//     'Stamat -> Duck -> 200',
//     'Stamat -> Tiger -> 250',
//     'Ave Cesar'
// ]);

// solve([
//     'Pesho -> Duck -> 400',
//     'Julius -> Shield -> 150	',
//     'Gladius -> Heal -> 200',
//     'Gladius -> Support -> 250',
//     'Gladius -> Shield -> 250',
//     'Pesho vs Gladius',
//     'Gladius vs Julius',
//     'Gladius vs Gosho',
//     'Ave Cesar'
// ]);
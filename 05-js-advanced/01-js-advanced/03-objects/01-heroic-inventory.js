function getHeroesJson(heroesData)
{
    const heroes = [];
    for (const heroData of heroesData)
    {
        const [name, level, ...items] = heroData.split(/ \/ |, /);
        const hero = { name, level: parseInt(level, 10), items };

        heroes.push(hero);
    }

    return JSON.stringify(heroes);
}
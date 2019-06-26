using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Heroes
{
    public class HeroRepository
    {
        private List<Hero> heroes;

        public HeroRepository()
        {
            this.heroes = new List<Hero>();
        }

        public int Count => this.heroes.Count;

        public void Add(Hero hero)
        {
            this.heroes.Add(hero);
        }

        public void Remove(string name)
        {
            this.heroes.RemoveAll(hero => hero.Name == name);
        }

        public Hero GetHeroWithHighestStrength()
        {
            return this.heroes.OrderByDescending(hero => hero.Item.Strength).First();
        }

        public Hero GetHeroWithHighestAbility()
        {
            return this.heroes.OrderByDescending(hero => hero.Item.Ability).First();
        }

        public Hero GetHeroWithHighestIntelligence()
        {
            return this.heroes.OrderByDescending(hero => hero.Item.Intelligence).First();
        }

        public override string ToString()
        {
            var heroesListed = string.Join(Environment.NewLine, this.heroes);

            return heroesListed;
        }
    }
}
using System;
using System.Collections.Generic;
using System.Linq;

namespace Heroes
{
    public class HeroRepository
    {
        private List<Hero> data;

        public HeroRepository()
        {
            this.data = new List<Hero>();
        }

        public int Count
        {
            get
            {
                return this.data.Count;
            }
        }

        public void Add(Hero hero)
        {
            this.data.Add(hero);
        }

        public void Remove(string name)
        {
            this.data.RemoveAll(hero => hero.Name == name);
        }

        public Hero GetHeroWithHighestStrength()
        {
            return this.data.OrderByDescending(hero => hero.Item.Strength).First();
        }

        public Hero GetHeroWithHighestAbility()
        {
            return this.data.OrderByDescending(hero => hero.Item.Ability).First();
        }

        public Hero GetHeroWithHighestIntelligence()
        {
            return this.data.OrderByDescending(hero => hero.Item.Intelligence).First();
        }

        public override string ToString()
        {
            return string.Join(Environment.NewLine, this.data);
        }
    }
}
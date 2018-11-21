using System;
using System.Collections.Generic;
using System.Linq;

namespace DefiningClasses
{
    public class Family
    {
        private List<Person> people;

        public Family()
        {
            this.people = new List<Person>();
        }

        public void AddMember(Person member)
        {
            this.people.Add(member);
        }

        public Person GetOldestMember()
        {
            return this.people.OrderByDescending(p => p.Age).First();
        }

        public IEnumerable<Person> GetPeopleWhere(Func<Person, bool> condition)
        {
            return this.people.Where(condition);
        }
    }
}
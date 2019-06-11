using System.Collections.Generic;
using System.Linq;

namespace DefiningClasses
{
    public class Family
    {
        private List<Person> Members { get; set; } = new List<Person>();

        public void AddMember(Person member)
        {
            this.Members.Add(member);
        }

        public Person GetOldestMember()
        {
            var oldestMember = this.Members.OrderByDescending(p => p.Age).First();
            return oldestMember;
        }
    }
}
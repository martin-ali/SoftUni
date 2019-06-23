using System.Collections.Generic;

namespace _06_equality_logic
{
    // Alternative way to do it for HashSet
    public class PersonEqualityComparer : IEqualityComparer<Person>
    {
        public bool Equals(Person first, Person second)
        {
            // return first.Name == second.Name
            //     && first.Age == second.Age;

            return first.CompareTo(second) == 0;
        }

        public int GetHashCode(Person person)
        {
            return person.GetHashCode();
        }
    }
}
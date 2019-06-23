using System.Collections.Generic;

namespace _06_strategy_pattern
{
    public class PersonByAgeComparer : IComparer<Person>
    {
        public int Compare(Person first, Person second)
        {
            return first.Age.CompareTo(second.Age);
        }
    }
}
using System.Collections.Generic;

namespace _06_strategy_pattern
{
    public class PersonByNameComparer : IComparer<Person>
    {
        public int Compare(Person first, Person second)
        {
            if (first.Name.Length > second.Name.Length)
            {
                return 1;
            }
            else if (second.Name.Length > first.Name.Length)
            {
                return -1;
            }

            return first.Name.ToLower()[0].CompareTo(second.Name.ToLower()[0]);
        }
    }
}
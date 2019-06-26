using System.Collections.Generic;

namespace Repository
{
    public class Repository
    {
        private Dictionary<int, Person> people = new Dictionary<int, Person>();

        private int lastId = 0;

        public int Count
        {
            get
            {
                return this.people.Count;
            }
        }

        public void Add(Person person)
        {
            this.people[this.lastId++] = person;
        }

        public Person Get(int id)
        {
            return this.people[id];
        }

        public bool Update(int id, Person newPerson)
        {
            if (this.people.ContainsKey(id) == false)
            {
                return false;
            }

            this.people[id] = newPerson;

            return true;
        }

        public bool Delete(int id)
        {
            if (this.people.ContainsKey(id) == false)
            {
                return false;
            }

            this.people.Remove(id);

            return true;
        }
    }
}
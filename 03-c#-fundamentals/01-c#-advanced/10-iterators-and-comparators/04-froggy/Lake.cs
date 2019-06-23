using System.Collections;
using System.Collections.Generic;
using System.Linq;

namespace _04_froggy
{
    public class Lake : IEnumerable<int>
    {
        public Lake(IEnumerable<int> stones)
        {
            var evens = new List<int>();
            var odds = new List<int>();

            var index = 1;
            foreach (var stone in stones)
            {
                if (index % 2 == 0)
                {
                    evens.Add(stone);
                }
                else
                {
                    odds.Add(stone);
                }

                index++;
            }

            this.Stones.AddRange(odds);
            this.Stones.AddRange(evens.Reverse<int>());
        }

        public List<int> Stones { get; private set; } = new List<int>();

        public IEnumerator<int> GetEnumerator()
        {
            foreach (var stone in this.Stones)
            {
                yield return stone;
            }
        }

        IEnumerator IEnumerable.GetEnumerator()
        {
            return this.GetEnumerator();
        }
    }
}

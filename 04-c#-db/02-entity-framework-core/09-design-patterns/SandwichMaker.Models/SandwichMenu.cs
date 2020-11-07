namespace SandwichMaker.Models
{
    using System.Collections.Generic;

    public class SandwichMenu
    {
        private Dictionary<string, SandwichPrototype> sandwiches = new Dictionary<string, SandwichPrototype>();

        public SandwichPrototype this[string name]
        {
            get
            {
                return this.sandwiches[name];
            }

            set
            {
                // Did it this way so values can be overwritten
                this.sandwiches[name] = value;
            }
        }
    }
}
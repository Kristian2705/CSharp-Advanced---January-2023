using CollectionHierarchy.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CollectionHierarchy.Models
{
    public class AddCollection : IAdd
    {
        protected List<string> collection;
        private int currentIndex = 0;
        public AddCollection()
        {
            collection = new List<string>();
        }

        public virtual int Add(string item)
        {
            collection.Add(item);
            return currentIndex++;
        }
    }
}

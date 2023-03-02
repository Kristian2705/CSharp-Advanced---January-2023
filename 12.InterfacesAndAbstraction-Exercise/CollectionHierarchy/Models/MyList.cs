using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CollectionHierarchy.Models
{
    public class MyList : AddRemoveCollection
    {
        public MyList()
            : base()
        {

        }

        public int Used { get => collection.Count; }

        public override string Remove()
        {
            string elementToRemove = collection[indexOfAddedItem];
            collection.RemoveAt(indexOfAddedItem);
            return elementToRemove;
        }
    }
}

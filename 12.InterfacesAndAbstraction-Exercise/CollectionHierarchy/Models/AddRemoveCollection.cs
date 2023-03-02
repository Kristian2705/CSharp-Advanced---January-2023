using CollectionHierarchy.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CollectionHierarchy.Models
{
    public class AddRemoveCollection : AddCollection, IRemove
    {
        protected const int indexOfAddedItem = 0;
        public AddRemoveCollection()
            : base()
        {

        }
        public override int Add(string item)
        {
            collection.Insert(indexOfAddedItem, item);
            return indexOfAddedItem;
        }

        public virtual string Remove()
        {
            string elementToRemove = collection[collection.Count - 1];
            collection.RemoveAt(collection.Count - 1);
            return elementToRemove;
        }
    }
}

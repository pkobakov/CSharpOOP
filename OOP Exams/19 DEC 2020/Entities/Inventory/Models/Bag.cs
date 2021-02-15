using System;
using System.Collections.Generic;
using System.Text;
using WarCroft.Entities.Items;

namespace WarCroft.Entities.Inventory.Models
{
    public class Bag : IBag
    {
        public int Capacity { get => throw new NotImplementedException(); set => throw new NotImplementedException(); }

        public int Load => throw new NotImplementedException();

        public IReadOnlyCollection<Item> Items => throw new NotImplementedException();

        public void AddItem(Item item)
        {
            throw new NotImplementedException();
        }

        public Item GetItem(string name)
        {
            throw new NotImplementedException();
        }
    }
}

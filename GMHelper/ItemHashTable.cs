using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GMHelper
{
    class ItemHashTable
    {
        Dictionary<string, string> items = new Dictionary<string, string>();
        public void hashAddItem(string name, string description)
        {
            try
            {
                items.Add(name, description);
                Console.WriteLine("Item with the name \"{0}\" Added", name);
            }
            catch (ArgumentException)
            {
                Console.WriteLine("An item with the name {0} already exists.", name);
            }
        }
        public void hashRemoveItem(string name)
        {
            try
            {
                items.Remove(name);
                Console.WriteLine("Item with the name \"{0}\" Removed", name);
            }
            catch (KeyNotFoundException)
            {
                Console.WriteLine("Item with the name \"{0}\" not found", name);
            }
        }
        public void hashFindItem(string name)
        {
            try
            {
                Console.WriteLine("Name: {0}\nDescription: {1}", name, items[name]);
            }
            catch (KeyNotFoundException)
            {
                Console.WriteLine("Item with the name \"{0}\" not found", name);
            }
        }
    }
}

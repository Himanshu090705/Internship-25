using Items.DataAccess.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Items.DataAccess.Repositories
{
    public class ItemsRepository
    {
        private readonly ItemsDbContext _itemDbContext;

        public ItemsRepository(ItemsDbContext itemsDbContext)
        {
            _itemDbContext = itemsDbContext;
        }

        public List<Item> GetItems()
        {
            return _itemDbContext.Items.ToList();
        }

        public Item GetItemById(int id)
        {
            Item item = _itemDbContext.Items.FirstOrDefault(item => item.Id == id);
            if (item == null)
            {
                return null;
            }
            return item;
        }

        public void AddItem(Item item)
        {
            _itemDbContext.Items.Add(item);
            _itemDbContext.SaveChanges();
        }

        public int UpdateItem(Item item)
        {
            Item itemToBeUpdated = GetItemById(item.Id);
            if (itemToBeUpdated == null)
            {
                return -1;
            }
            else
            {
                itemToBeUpdated.Name = item.Name;
                itemToBeUpdated.Description = item.Description;
                itemToBeUpdated.Price = item.Price;
                _itemDbContext.SaveChanges();
                return 1;
            }
        }

        public int DeleteItem(int id)
        {
            Item itemToBeRemoved = GetItemById(id);
            if (itemToBeRemoved == null)
            {
                return -1;
            }
            else
            {
                _itemDbContext.Items.Remove(itemToBeRemoved);
                _itemDbContext.SaveChanges();
                return 1;
            }
        }

        public List<Item> GetFilteredItems(int price)
        {
            List<Item> items = _itemDbContext.Items.Where(item => item.Price == price).ToList();
            return items;
        }
    }

}

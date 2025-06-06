using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Items.DataAccess.Models;
using Items.DataAccess;
using Items.DataAccess.Repositories;

namespace Items.Services.Services
{
    public class ItemsService
    {
        private readonly ItemsRepository _itemsRepository;

        public ItemsService(ItemsRepository itemsRepository)
        {
            _itemsRepository = itemsRepository;
        }

        public List<Item> GetItems()
        {
            return _itemsRepository.GetItems();
        }

        public Item GetItemById(int id)
        {
            return _itemsRepository.GetItemById(id);
        }

        public void AddItem(Item item)
        {
            _itemsRepository.AddItem(item);
        }

        public int UpdateItem(Item item)
        {
            return _itemsRepository.UpdateItem(item);
        }

        public int DeleteItem(int id)
        {
            return _itemsRepository.DeleteItem(id);
        }

        public List<Item> GetFilteredItems(int price)
        {
            return _itemsRepository.GetFilteredItems(price);
        }
    }
}

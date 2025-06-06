using Items.DataAccess.Models;

namespace Items.DataAccess.Repositories.Interface
{
    public interface IItemRepository
    {
        Task InsertItem(Item item);

        Item GetById(int id);
    }
}

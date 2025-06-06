using Items.DataAccess.Models;
using Items.Services.Services;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace StationaryShop.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    //[Authorize]

    public class ItemsController : ControllerBase
    {
        private readonly ItemsService _itemService;

        public ItemsController(ItemsService itemService)
        {
            _itemService = itemService;
        }

        [HttpGet("GetAllItems")]
        [Authorize(Roles = "admin")]

        public ActionResult<List<Item>> GetAllItems()
        {
            List<Item> items = _itemService.GetItems();
            if (items == null || items.Count == 0)
            {
                return NotFound("No items found");
            }
            else
            {
                return Ok(items);
            }
        }

        [HttpGet("GetSingleItem")]
        public ActionResult<Item> GetItem(int id)
        {
            Item item = _itemService.GetItemById(id);
            if (item == null)
            {
                return NotFound("Item not found");
            }
            else
            {
                return Ok(item);
            }
        }

        [HttpPost]
        public ActionResult AddItem(Item item)
        {
            _itemService.AddItem(item);
            return Ok("Item added successfully");
        }

        [HttpPut]
        [Authorize(Roles = "admin,manager")]

        public ActionResult UpdateItem(Item itemToBeUpdated)
        {
            int itemUpdateStatus = _itemService.UpdateItem(itemToBeUpdated);
            if (itemUpdateStatus == -1)
            {
                return NotFound("Item not found");
            }
            else if (itemUpdateStatus == 1)
            {
                return Ok("Item updated successfully");
            }
            else
            {
                return BadRequest("Bad request");
            }
        }

        [HttpDelete]
        [Authorize(Roles = "admin,manager")]

        public ActionResult DeleteItem(int id)
        {
            int deleteStatus = _itemService.DeleteItem(id);
            if (deleteStatus == -1)
            {
                return NotFound("Item not found");
            }
            else if (deleteStatus == 1)
            {
                return Ok("Item deleted successfully");
            }
            else
            {
                return BadRequest("Bad request");
            }
        }

        [HttpGet("GetFilteredItems")]
        public ActionResult GetFilteredItems(int price)
        {
            List<Item> items = _itemService.GetFilteredItems(price);
            if (items == null || items.Count == 0)
            {
                return NotFound("Items not found");
            }
            else
            {
                return Ok(items);
            }
        }
    }

}

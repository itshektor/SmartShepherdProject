using Microsoft.AspNetCore.Mvc;
using SmartShepherdAPI.Models;
using System.Collections.Generic;

namespace SmartShepherdAPI.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class MarketplaceController : ControllerBase
    {
        private static readonly List<ProduceItem> Items = new List<ProduceItem>();

        // Static constructor to preload featured items
        static MarketplaceController()
        {
            Items.AddRange(new List<ProduceItem>
            {
                new ProduceItem
                {
                    Id = 1,
                    Name = "Soil Sensor Pro",
                    Category = "Sensor",
                    Price = 59.99m,
                    ImageUrl = "soilsensor.jpg"
                },
                new ProduceItem
                {
                    Id = 2,
                    Name = "Herd GPS Tracker",
                    Category = "Tracking",
                    Price = 89.99m,
                    ImageUrl = "herdtracker.jpg"
                },
                new ProduceItem
                {
                    Id = 3,
                    Name = "Solar Water Pump",
                    Category = "Irrigation",
                    Price = 149.99m,
                    ImageUrl = "Solarwater.jpg"
                },
                new ProduceItem
                {
                    Id = 4,
                    Name = "Smart Ear Tags",
                    Category = "Livestock",
                    Price = 29.99m,
                    ImageUrl = "smarteartags.jpg"
                },
                new ProduceItem
                {
                    Id = 5,
                    Name = "Automatic Feed Dispenser",
                    Category = "Feeding",
                    Price = 199.99m,
                    ImageUrl = "automaticfeed.jpg"
                },
                new ProduceItem
                {
                    Id = 6,
                    Name = "Drone Crop Sprayer",
                    Category = "Drone",
                    Price = 399.99m,
                    ImageUrl = "drone.jpg"
                }
            });
        }

        [HttpGet]
        public IActionResult Get()
        {
            return Ok(Items);
        }

        [HttpPost]
        public IActionResult Post([FromBody] ProduceItem item)
        {
            if (string.IsNullOrWhiteSpace(item.Name) ||
                string.IsNullOrWhiteSpace(item.Category) ||
                item.Price <= 0)
            {
                return BadRequest("Invalid item data.");
            }

            item.Id = Items.Count > 0 ? Items[^1].Id + 1 : 1;
            Items.Add(item);
            return Ok(new { message = "Item added successfully." });
        }
    }
}

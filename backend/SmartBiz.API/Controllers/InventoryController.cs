using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using SmartBiz.Core.Entities;
using SmartBiz.Core.Interfaces;

namespace SmartBiz.API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    [Authorize]
    public class InventoryController : ControllerBase
    {
        private readonly IInventoryRepository _inv;

        public InventoryController(IInventoryRepository inv)
        {
            _inv = inv;
        }

        [HttpGet]
        public async Task<IActionResult> GetAll()
        {
            return Ok(await _inv.GetAllAsync());
        }

        [HttpGet("{productId}")]
        public async Task<IActionResult> Get(Guid productId)
        {
            var inventory = await _inv.GetByProductIdAsync(productId);
            if (inventory == null) return NotFound();

            return Ok(inventory);
        }

        [Authorize(Roles = "Admin,Manager")]
        [HttpPost]
        public async Task<IActionResult> Create([FromBody] Inventory inv)
        {
            await _inv.AddAsync(inv);
            return Ok(inv);
        }

        [Authorize(Roles = "Admin,Manager")]
        [HttpPut("adjust/{productId}")]
        public async Task<IActionResult> AdjustStock(Guid productId, [FromQuery] int change)
        {
            var result = await _inv.AdjustStockAsync(productId, change);
            if (!result) return BadRequest("Not enough stock or product not found.");

            return Ok(new { message = "Stock Updated" });
        }
    }
}

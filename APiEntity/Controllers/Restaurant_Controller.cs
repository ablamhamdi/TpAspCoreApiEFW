using APiEntity.Entitys;
using APiEntity.Services;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace APiEntity.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class Restaurant_Controller : ControllerBase
    {
        IRestaurantService _restaurantService;
        public Restaurant_Controller(IRestaurantService service)
        {
            this._restaurantService = service;
        }

        [HttpGet]
        public async Task<ActionResult<List<Restaurant>>> GetAllRestos()
        {
            if (_restaurantService == null)
            {
                return NotFound();
            }
            return await _restaurantService.ListRestaurantAsync();
        }
        [HttpGet("{id}")]
        public async Task<ActionResult<Restaurant>> getRestosId(int id)
        {
            if (_restaurantService == null)
            {
                return NotFound();
            }
            return await _restaurantService.GetResturantByIdAsync(id);
        }
        [HttpPost]
        public async Task<ActionResult<Restaurant>> AddResto(Restaurant restaurant)
        {
            if (_restaurantService == null)
            {
                return NotFound();
            }
            return await _restaurantService.AddRestaurantAsync(restaurant);
        }
        [HttpPut("{id}")]
        public async Task<ActionResult> UpdateResto(int id,Restaurant restaurant)
        {
            if(restaurant.Id != id)
            {
                return BadRequest();
            }
            await _restaurantService.UpdateResturantAsync(id, restaurant);
            return NoContent();
        }
        [HttpDelete("{id}")]
        public async Task<ActionResult> DeleteReso(int id)
        {
            Restaurant res = await _restaurantService.GetResturantByIdAsync(id);
            if (res==null)
            {
                return BadRequest();
            }
            return Ok(res);
        }
    }
}

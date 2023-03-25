using APiEntity.Entitys;

namespace APiEntity.Services
{
    public interface IRestaurantService
    {
        public Task<List<Restaurant>> ListRestaurantAsync();
        public Task<Restaurant> AddRestaurantAsync(Restaurant restaurant);
        public Task<bool> DeleteRestaurantAsync(int id);
        public Task<bool> UpdateResturantAsync(int id,Restaurant restaurant);
        public Task<Restaurant> GetResturantByIdAsync(int id);
    }
}

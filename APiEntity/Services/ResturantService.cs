using APiEntity.DbCont;
using APiEntity.Entitys;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Microsoft.VisualBasic;

namespace APiEntity.Services
{
    public class ResturantService : IRestaurantService
    {
        private FormationDbContext _FormationDbContext;
        public ResturantService(FormationDbContext context)
        {
            this._FormationDbContext = context;
        }
        public async Task<Restaurant> AddRestaurantAsync(Restaurant restaurant)
        {
            if (restaurant != null)
            {
                _FormationDbContext.Add(restaurant);
                await _FormationDbContext.SaveChangesAsync();
                return restaurant;
            }
            return null;
        }
        public async Task<bool> DeleteRestaurantAsync(int id)
        {
            var res =await _FormationDbContext.Restaurants.SingleOrDefaultAsync(x => x.Id == id);
            if (res != null)
            {
                _FormationDbContext.Restaurants.Remove(res);
                await _FormationDbContext.SaveChangesAsync();
                return true;
            }
            return false;
        }

        public async Task<Restaurant> GetResturantByIdAsync(int id)
        {
            var res = await _FormationDbContext.Restaurants.SingleOrDefaultAsync(x => x.Id == id);
            if(res != null) 
                return res;
            return null;
        }

    

        public async Task< List<Restaurant> > ListRestaurantAsync()
        {
            return await _FormationDbContext.Restaurants.ToListAsync();
        }
     
        public async Task<bool> UpdateResturantAsync(int id,Restaurant restaurant)
        {
            if(restaurant.Id != id)
            {
                _FormationDbContext.Entry(restaurant).State = EntityState.Modified;
            }
            try
            {
               await _FormationDbContext.SaveChangesAsync();
                return true;
            }
            catch 
            {
                return false;
            }
        }
    }
}

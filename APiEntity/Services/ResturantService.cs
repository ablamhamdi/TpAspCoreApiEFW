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
            var existingContact = await _FormationDbContext.Contact.FindAsync(restaurant.Contact.Id);

            if (existingContact != null)
            {
                restaurant.Contact = existingContact.Contact;
            }

            // add cuisins to restaurant
            foreach (var cuisin in restaurant.Cuisins)
            {
                var existingCuisin = await _FormationDbContext.Cuisins.FindAsync(cuisin.Id);

                if (existingCuisin != null)
                {
                    restaurant.Cuisins.Remove(cuisin);
                    restaurant.Cuisins =existingCuisin.Cuisins;
                }
            }

            _FormationDbContext.Restaurants.Add(restaurant);
            await _FormationDbContext.SaveChangesAsync();

            return restaurant;
        }
        public async Task<bool> DeleteRestaurantAsync(int id)
        {
            var res = await _FormationDbContext.Restaurants.SingleOrDefaultAsync(x => x.Id == id);
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
            var res = await _FormationDbContext.Restaurants.Include(r => r.Cuisins)
                                                           .Include(r => r.Contact)
                                                           .SingleOrDefaultAsync(x => x.Id == id);
            if (res != null)
                return res;
            return null;
        }



        public async Task<List<Restaurant>> ListRestaurantAsync()
        {
            return await _FormationDbContext.Restaurants
                                            .Include(r => r.Cuisins)
                                            .Include(r => r.Contact)
                                            .ToListAsync();
        }

        public async Task<bool> UpdateResturantAsync(int id, Restaurant restaurant)
        {
            var existingRestaurant = await _FormationDbContext.Restaurants
           .Include(r => r.Cuisins)
           .Include(r => r.Contact)
           .SingleOrDefaultAsync(r => r.Id == restaurant.Id);

            if (existingRestaurant == null)
            {
                return false;
            }

            // Update scalar properties of existingRestaurant
            existingRestaurant.Name = restaurant.Name;
            existingRestaurant.Description = restaurant.Description;
            existingRestaurant.Adress = restaurant.Adress;

            // Update Cuisins navigation property of existingRestaurant
          //  existingRestaurant.Cuisins.Clear();
            foreach (var cuisin in restaurant.Cuisins)
            {
                var existingCuisin = await _FormationDbContext.Cuisins.FindAsync(cuisin.Id);
                if (existingCuisin != null)
                {
                    existingRestaurant.Cuisins=existingCuisin.Cuisins;
                }
            }

            // Update Contact navigation property of existingRestaurant
            var existingContact = await _FormationDbContext.Contact.FindAsync(restaurant.Contact.Id);
            if (existingContact != null)
            {
                existingRestaurant.Contact = existingContact.Contact;
            }

            await _FormationDbContext.SaveChangesAsync();

            return true;
        }
    }
}

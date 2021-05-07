using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Restaurant.Entities;

namespace Restaurant
{
    public class RestaurantSeeder
    {
        private readonly RestaurantDbContext _dbContext;
        public RestaurantSeeder(RestaurantDbContext dbContext)
        {
            _dbContext = dbContext;
        }
        public void Seed()
        {
            if (_dbContext.Database.CanConnect())
            {
                if (!_dbContext.Restaurant.Any())
                {
                    var restaurants = GetRestaurants();
                    _dbContext.Restaurant.AddRange(restaurants);
                }
            }
        }

        private IEnumerable<Entities.Restaurant> GetRestaurants()
        {
            var restaurants = new List<Entities.Restaurant>()
        }
    }
}

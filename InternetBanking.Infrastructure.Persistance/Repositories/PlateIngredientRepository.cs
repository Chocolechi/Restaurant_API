using RestaurantAPI.Core.Application.Interfaces.Repositories;
using RestaurantAPI.Core.Domain.Models;
using RestaurantAPI.Infrastructure.Persistence.Context;

namespace RestaurantAPI.Infrastructure.Persistence.Repositories
{
    public class PlateIngredientRepository : GenericRepository<PlateIngredient>, IPlateIngredientRepository
    {
        private readonly AppDbContext _db;
        public PlateIngredientRepository(AppDbContext db): base(db)
        {
            _db = db;
        }

    }
}

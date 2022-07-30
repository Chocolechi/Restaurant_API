using RestaurantAPI.Core.Application.Interfaces.Repositories;
using RestaurantAPI.Core.Domain.Models;
using RestaurantAPI.Infrastructure.Persistence.Context;

namespace RestaurantAPI.Infrastructure.Persistence.Repositories
{
    public class PlateRepository : GenericRepository<Plate>, IPlateRepository
    {
        private readonly AppDbContext _db;
        public PlateRepository(AppDbContext db): base(db)
        {
            _db = db;
        }

    }
}

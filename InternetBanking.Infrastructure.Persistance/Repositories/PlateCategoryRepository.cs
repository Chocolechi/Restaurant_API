using RestaurantAPI.Core.Application.Interfaces.Repositories;
using RestaurantAPI.Core.Domain.Models;
using RestaurantAPI.Infrastructure.Persistence.Context;

namespace RestaurantAPI.Infrastructure.Persistence.Repositories
{
    public class PlateCategoryRepository : GenericRepository<Plate>, IPlateCategoryRepository
    {
        private readonly AppDbContext _db;
        public PlateCategoryRepository(AppDbContext db): base(db)
        {
            _db = db;
        }

    }
}

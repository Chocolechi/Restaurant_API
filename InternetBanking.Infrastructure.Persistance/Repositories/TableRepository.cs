using RestaurantAPI.Core.Application.Interfaces.Repositories;
using RestaurantAPI.Core.Domain.Models;
using RestaurantAPI.Infrastructure.Persistence.Context;

namespace RestaurantAPI.Infrastructure.Persistence.Repositories
{
    public class TableRepository : GenericRepository<Table>, ITableRepository
    {
        private readonly AppDbContext _db;
        public TableRepository(AppDbContext db): base(db)
        {
            _db = db;
        }

    }
}

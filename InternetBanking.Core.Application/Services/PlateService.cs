using AutoMapper;
using RestaurantAPI.Core.Application.Interfaces.Repositories;
using RestaurantAPI.Core.Application.Interfaces.Services;
using RestaurantAPI.Core.Application.ViewModels.Plate;
using RestaurantAPI.Core.Domain.Models;

namespace RestaurantAPI.Core.Application.Services
{
    public class PlateService : GenericService<PlateSaveViewModel, PlateViewModel, Plate>, IPlateService
    {
        private readonly IPlateRepository _repo;
        private readonly IMapper _mapper;
        public PlateService(IPlateRepository repo, IMapper mapper): base(repo, mapper)
        {
            _repo = repo;
            _mapper = mapper;
        }
    }
}

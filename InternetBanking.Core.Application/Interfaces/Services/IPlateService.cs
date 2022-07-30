using RestaurantAPI.Core.Application.ViewModels.Plate;
using RestaurantAPI.Core.Domain.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RestaurantAPI.Core.Application.Interfaces.Services
{
    public interface IPlateService: IGenericService<PlateSaveViewModel, PlateViewModel, Plate>
    {
    }
}

using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using CapiMotors.Data.Interfaces;
using CapiMotors.Models;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace CapiMotors.Controllers.ApiControllers
{
    [Route("Vehicle/api/{controller}/{action}")]
    [ApiController]
    public class VehicleController : ControllerBase
    {
        private readonly IVehicleRepository vehicleRepository;
        private readonly IUnitOfWork unitOfWork;

        public VehicleController(IVehicleRepository vehicleRepository, IUnitOfWork unitOfWork)
        {
            this.vehicleRepository = vehicleRepository;
            this.unitOfWork = unitOfWork;
        }


        public IActionResult Cancel(int id)
        {
            vehicleRepository.Cancel(id);
            unitOfWork.Complete();

            return Ok();
        }

        
        public IActionResult Search(int range, string make="")
        {
            PriceRangeSearch price = (PriceRangeSearch)range;
            

            SearchDto search = new SearchDto
            {
                PriceRange = price,
                Make = make
            };

            var data = vehicleRepository.GetVehiclesBySearchCriteria(search);

            return Ok(data);
        }
    }
}

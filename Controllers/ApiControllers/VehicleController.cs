using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using CapiMotors.Data.Interfaces;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace CapiMotors.Controllers.ApiControllers
{
    [Route("Vehicle/api/[controller]/{id}")]
    [ApiController]
    public class VehicleController : ControllerBase
    {
        private readonly IProductRepository vehicleRepository;
        private readonly IUnitOfWork unitOfWork;

        public VehicleController(IProductRepository vehicleRepository, IUnitOfWork unitOfWork)
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
    }
}

using Microsoft.AspNetCore.Cors.Infrastructure;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using RentCars.DataBase;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace RentCars.Controllers
{
    [ApiController]
    [Route("api/[controller")]
        public class CarsController : ControllerBase
        {

        private readonly ICarsService _carService;

            public CarsController(ICarsService carService)
            {
                _carService = carService;
            }
            //[Authorize(Roles="Cars.List")]
            [HttpGet("getall")]
            public IActionResult GetAll()
            {
                var result = _carService.GetAll();
                if (result.Success)
                {
                    return Ok(result);
                }
                else
                {
                    return BadRequest(result);
                }


            }

            [HttpPost("addcar")]
            public IActionResult AddCar(CarDTO car)
            {
                var result = _carService.Add(car);
                if (result.Success)
                {
                    return Ok(result);
                }
                else { return BadRequest(result); }
            }
            [HttpPut("updatecar")]
            public IActionResult UpdateCar(CarDTO car)
            {
                var result = _carService.Update(car);
                if (result.Success)
                    return (IActionResult)Ok(result);
                else
                    return BadRequest(result);
            }

            [HttpPost("deletecar")]
            public IActionResult DeleteCar(CarDTO car)
            {
                var result = _carService.Delete(car);
                if (result.Success)
                    return (IActionResult)Ok(result);
                else
                    return BadRequest(result);
            }
            [HttpGet("getcarbyid")]
            public IActionResult GetCarById(int carId)
            {
                var result = _carService.GetById(carId);
                if (result.Success)
                {
                    return Ok(result);
                }
                return BadRequest(result);
            }
        }
}

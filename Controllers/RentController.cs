using Microsoft.AspNetCore.Mvc;
using RentCars.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;

namespace RentCars.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class RentController : ControllerBase
    {
        private readonly IRentService _rentService;

        public RentController(IRentService rentalService)
        {
            _rentService = rentalService;
        }
        [HttpGet("getall")]
        public IActionResult GetAll()
        {
            var result = _rentService.GetAll();
            if (result.Success) { return Ok(result); }
            else { return (IActionResult)BadRequest(result); }
        }

        [HttpGet("renttwo")]
        public IActionResult RentDetailTwo()
        {
            var result = _rentService.getRentalsDetailsDtoTwo();
            if (result.Success)
            {
                return Ok(result);
            }
            else
            {
                return BadRequest(result);
            }
        }
        [HttpPost("addrent")]
        public IActionResult AddRent(Rent rental)
        {
            var result = _rentService.Add(rental);
            return result.Success ? (IActionResult)Ok(result) : BadRequest(result);
        }
        [HttpPut("updaterent")]
        public IActionResult UpdateRental(Rent rent)
        {
            var result = _rentService.Update(rent);
            return result.Success ? (IActionResult)Ok(result) : BadRequest(result);
        }

        [HttpPost("deleterent")]
        public IActionResult DeleteRent(Rent rent)
        {
            var result = _rentService.Delete(rent);
            return result.Success ? (IActionResult)Ok(result) : BadRequest(result);
        }


        [HttpGet("getrentsbycarid")]
        public IActionResult GetRentByCarId(int carId)
        {
            var result = _rentService.GetRentByCarId(carId);
            return result.Success ? (IActionResult)Ok(result) : BadRequest(result);
        }

        [HttpGet("getrentbyid")]
        public IActionResult GetRentById(int rentId)
        {
            var result = _rentService.GetById(rentId);
            return result.Success ? (IActionResult)Ok(result) : BadRequest(result);
        }
    }
}

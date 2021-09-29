using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using RentCars.DTOs;
using RentCars.Interfaces.Services;
using RentCars.Models;
using System.Collections.Generic;
using System.Linq;


namespace RentCars.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class CustomerController : ControllerBase
    {
        private readonly ICustomerService _customerService;
        public CustomerController(ICustomerService carService)
        {
            _customerService = CustomerService;
        }
        //[Authorize(Roles="Customers.List")]
        [HttpGet("getall")]
        public IActionResult GetAll()
        {
            var result = _customerService.GetAll();
            if (result.Success)
            {
                return Ok(result);
            }
            else
            {
                return BadRequest(result);
            }


        }

        [HttpPost("addcustomer")]
        public IActionResult AddCustomers(Customer customer)
        {
            var result = _customerService.Add(customer);
            if (result.Success)
            {
                return Ok(result);
            }
            else { return BadRequest(result); }
        }
        [HttpPut("updatecustomer")]
        public IActionResult UpdateCar(Customer customer)
        {
            var result = _customerService.Update(customer);
            if (result.Success)
                return (IActionResult)Ok(result);
            else
                return BadRequest(result);
        }

        [HttpPost("deletecustomer")]
        public IActionResult DeleteCar(Customer customer)
        {
            var result = _customerService.Delete(customer);
            if (result.Success)
                return (IActionResult)Ok(result);
            else
                return BadRequest(result);
        }
        [HttpGet("getcustomerbyid")]
        public IActionResult GetCarById(int customerId)
        {
            var result = _customerService.GetById(customerId);
            if (result.Success)
            {
                return Ok(result);
            }
            return BadRequest(result);
        }
    }
}

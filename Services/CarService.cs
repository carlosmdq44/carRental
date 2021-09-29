using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

using RentACarWebAPI.Interfaces.Repositories;
using RentACarWebAPI.Interfaces.Services;
using RentCars.Models;

namespace RentCars.Services
{
    public class CarService : BaseService<Car>, ICarsService
    {
        public CarService(ICarRepository carRepository) : base(carRepository) { }
    }
}
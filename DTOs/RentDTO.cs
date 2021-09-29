using Abp.Application.Services.Dto;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RentCars.Entidades
{
    public class RentDTO : EntityDto
    {
        public int Id { get; set; }
        public CarDTO car { get; set; }
        public CustomerDTO customer { get; set; }
        public DateTime dateRent { get; set; }
        public DateTime dateReturn { get; set; }

        public RentDTO(int Id,CarDTO car,CustomerDTO customer,DateTime dateRent,DateTime dateReturn)
        {
            this.Id = Id;
            this.car = car;
            this.customer = customer;
            this.dateRent = dateRent;
            this.dateReturn = dateReturn;
        }
        public double DurationTime() {     
                return (this.dateReturn - this.dateRent).TotalDays;
        }
    }
}

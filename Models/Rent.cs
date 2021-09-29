using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RentCars.Models
{
    public class Rent
    {
        public int Id { get; set; }
        public CarDTO car { get; set; }
        public Customer customer { get; set; }
        public DateTime dateRent { get; set; }
        public DateTime dateReturn { get; set; }

        public Rent(int Id,CarDTO car,Customer customer,DateTime dateRent,DateTime dateReturn)
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

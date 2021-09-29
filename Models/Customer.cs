using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RentCars.Models
{
    public class Customer
    {
        // PROPIEDADES
        public Int64 DNI { get; set; }
        public string Name { get; set; }
        public string LastName { get; set; }
        public string NumberPhone { get; set; }
        public string Street { get; set; }
        public string City { get; set; }
        public string Province { get; set; }
        public int ZipCode { get; set; }

        public DateTime UltModificacion;
        public Customer()
        {
        }
        public Customer(Int64 DNI,string Name,string LastName,string NumberPhone,string Street,string City,string Province,int ZipCode)
        {
            this.DNI = DNI;
            this.Name = Name;
            this.LastName = LastName;
            this.NumberPhone = NumberPhone;
            this.Street = Street;
            this.City = City;
            this.Province = Province;
            this.ZipCode = ZipCode;
            this.UltModificacion = DateTime.Now;

        }
    }
}

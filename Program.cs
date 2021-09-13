using System.Collections.Generic;
using System.Linq;
using System.Configuration;
using RentCars.Entidades;
using System;
using RentCars.Database;

namespace RentCars
{
    public class Program
    {
        static void Main(string[] args)
        {
            Car car1 = new Car(Mark.Chevrolet, "clasic", 2, Colour.black, true);
            Customers customers1 = new Customers(33312, "cARLOS", "FIO", "22356456", "LARREA 2232", "MAR DEL PLATA", "BS AS ", 7600);

            Rent ren1 = new Rent(1, car1, customers1, DateTime.Now, new DateTime(2021, 09, 15));
            RentCRUD.Create(ren1);

            //CarCRUD.Create(car1);

            //Car car2 = new Car(Mark.Fiat, "uno", 2, Colour.green, true);
            //CarCRUD.Create(car2);

            //Car car3 = CarCRUD.GetById(3);

            //car3.Colour = Colour.yellow;

            //CarCRUD.Update(car3);

           // CarCRUD.Remove(1);

        }
    }
}

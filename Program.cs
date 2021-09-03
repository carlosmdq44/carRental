using System.Collections.Generic;
using System.Linq;

using System.Configuration;
namespace RentCars
{
    public class Program
    {

        static void Main(string[] args)
        {



            //Car car1 = new Car(Mark.Chevrolet,"clasic",2,Colour.black,true);
            //CarCRUD.Create(car1);

            //Car car2 = new Car(Mark.Fiat, "uno", 2, Colour.green, true);
            //CarCRUD.Create(car2);


            Car car3 = CarCRUD.GetById(3);

            car3.Colour = Colour.yellow;

            CarCRUD.Update(car3);


           // CarCRUD.Remove(1);




            //Car car3 = new Car();
            //car3.Id = 3;
            //car3.Colour = Colour.black;
            //car3.Mark = Mark.Chevrolet;

            //List<Car> listCar1 = new List<Car>();
            //listCar1.Add(car1);
            //listCar1.Add(car2);
            //listCar1.Add(car3);

            //Car lastCar = listCar1.Last(); //Se usa LINQ, es sintaxis similiar a SQL, pero para Listas en C#.
            //                               //El metodo Last() devuelve el ultimo elemento

            //Car car4 = new Car();
            //car3.Id = lastCar.Id++;
            //car3.Colour = Colour.black;
            //car3.Mark = Mark.Chevrolet;


            //CarCRUD.Create(car2);
        }

    }
}

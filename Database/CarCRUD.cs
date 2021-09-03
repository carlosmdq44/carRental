using Newtonsoft.Json;
using RentCars.Database;
using System;
using System.Collections.Generic;
using System.Configuration;
using System.IO;
using System.Linq;

namespace RentCars
{
    public class CarCRUD
    {
        public List<Car> cars;
        private static string BDcar = ConfigurationManager.AppSettings["BDCar"];

        public static Car Create(Car _car)
        {
            AccessDB<Car> bd = new AccessDB<Car>(BDcar);

            if (GetALL().Count==0) {
                _car.Id = 1;
            }
            else{
                Car lastCar = GetALL().Last();
                _car.Id = lastCar.Id + 1; //El metodo Last() devuelve el ultimo elemento
            }
            bd.Insert(_car);
            return _car;
        }

        //Devuelvo la lista de Autos.
        public static List<Car> GetALL()
        {
            AccessDB<Car> bd = new AccessDB<Car>(BDcar);
            return bd.getValues();
        }

        public static Car GetById(int id) {

            foreach (Car car in GetALL()) {
                if (car.Id == id) {
                    return car;
                }
            
            }
            return null;
        }
        // Modifica
        public static void Update(Car _car) {

            List<Car> listCars = new List<Car>();
            foreach (Car car in GetALL())
            {
                if (car.Id == _car.Id)
                {
                    car.Mark = _car.Mark;
                    car.Model = _car.Model;
                    car.NumberOfDoors = _car.NumberOfDoors;
                    car.Colour = _car.Colour;
                    car.ChangeBook = _car.ChangeBook;
                }
                listCars.Add(car);
            }
            SaveList(listCars);
        }
        
        public static void Remove(int id) {

            List<Car> listCars = new List<Car>();
            foreach (Car car in GetALL()){

                if (car.Id != id)
                {
                    listCars.Add(car);
                }
            }
            SaveList(listCars);
        }

        public static void SaveList(List<Car> listCars) {

            AccessDB<Car> bd = new AccessDB<Car>(BDcar);
            bd.SaveList(listCars);
        }
    }
}


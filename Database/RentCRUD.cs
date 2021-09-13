using RentCars.Entidades;
using System;
using System.Collections.Generic;
using System.Configuration;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RentCars.Database
{
    public class RentCRUD
    {
        public List<Rent> rent;
        private static string BDrent = ConfigurationManager.AppSettings[StoreConfiguration.BDRENT];
        public static Rent Create(Rent _rent)
        {
            AccessDB<Rent> bd = new AccessDB<Rent>(BDrent);
            bd.Insert(_rent);
            return _rent;
        }
        public static List<Rent> GetALL()
        {
            AccessDB<Rent> bd = new AccessDB<Rent>(BDrent);
            return bd.getValues();
        }
        public static List<Rent> GetByDNI(Int64 DNI)
        {
            return GetALL().Where(x => x.customer.DNI == DNI).ToList();
        }
        public static void Update(Rent _rent)
        {           
            List<Rent> listRent = new List<Rent>();

            foreach (Rent rent in GetALL())
            {
                if (rent.Id == _rent.Id)
                {
                    rent.dateRent = _rent.dateRent;
                    rent.dateReturn = _rent.dateReturn;
                    rent.car = _rent.car;
                }
                listRent.Add(rent);
            }
            SaveList(listRent);
        }
        public static void Remove(int _Id)
        {

            List<Rent> newList = GetALL();
            newList.RemoveAll(x => x.Id == _Id);
            SaveList(newList);
        }
        public static void SaveList(List<Rent> listRent)
        {

            AccessDB<Rent> bd = new AccessDB<Rent>(BDrent);
            bd.SaveList(listRent);
        }
    }
}
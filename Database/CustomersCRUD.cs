using RentCars.Entidades;
using System;
using System.Collections.Generic;
using System.Configuration;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RentCars.Database
{
       public class CustomersCRUD
        {
            public List<Customer> customers;
            private static string BDcustomers = ConfigurationManager.AppSettings[StoreConfiguration.BDCUSTOMER];
            public static Customer Create(Customer _customers)
            {
                AccessDB<Customer> bd = new AccessDB<Customer>(BDcustomers);
                Customer customer = GetALL().Where(x => x.DNI == _customers.DNI).FirstOrDefault(); //LINQ Method syntax, y usa metodo lambda.

            if (customer != null)
                {
                    bd.Insert(_customers);
                    return _customers;
                }
                else { 
                    return null;
                }
            }
            public static List<Customer> GetALL()
            {
                AccessDB<Customer> bd = new AccessDB<Customer>(BDcustomers);
                return bd.getValues();
            }
            public static Customer GetByDNI(Int64 DNI)
            {
               return GetALL().Where(x => x.DNI == DNI).FirstOrDefault();
            }
            public static void Update(Customer _customers)
            {
                List<Customer> listCustomers = new List<Customer>();
                foreach (Customer customers in GetALL())
                {
                    if (_customers.DNI == customers.DNI)
                    {
                        customers.Name = _customers.Name;
                        customers.UltModificacion = DateTime.Now;
                       
                    }
                    listCustomers.Add(customers);
                }
                SaveList(listCustomers);
            }
            public static void Remove(Int64 DNI)
            {
                List<Customer> newList = GetALL();                
                newList.RemoveAll(x => x.DNI == DNI);
                SaveList(newList);
            }
            public static void SaveList(List<Customer> listCustomers)
            {
                AccessDB<Customer> bd = new AccessDB<Customer>(BDcustomers);
                bd.SaveList(listCustomers);
            }
        }
}

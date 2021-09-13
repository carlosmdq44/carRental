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
            public List<Customers> customers;
            private static string BDcustomers = ConfigurationManager.AppSettings["BDCustomers"];

            public static Customers Create(Customers _customers)
            {
                AccessDB<Customers> bd = new AccessDB<Customers>(BDcustomers);
                
                //LINQ Method syntax, y usa metodo lambda.
                Customers customer = GetALL().Where(x => x.DNI == _customers.DNI).FirstOrDefault();



                //LINQ Query syntax
                //var customer2 = from x in GetALL()
                //                where x.DNI == _customers.DNI
                //                select x;


                //Customers customer1;
                //foreach (var x in GetALL()) {

                //    if (x.DNI == _customers.DNI) {
                //        customer1 = x;
                //    }

                //}

                if (customer != null)
                {
                    bd.Insert(_customers);
                    return _customers;
                }
                else { 
                    return null;
                }

          
            }

            //Devuelvo la lista de Customers
            public static List<Customers> GetALL()
            {
                AccessDB<Customers> bd = new AccessDB<Customers>(BDcustomers);
                return bd.getValues();
            }
            
            public static Customers GetByDNI(Int64 DNI)
            {
               return GetALL().Where(x => x.DNI == DNI).FirstOrDefault();
            }
            // Modifica
            public static void Update(Customers _customers)
            {

                // instance.of(car) ()t.id
                //
                List<Customers> listCustomers = new List<Customers>();
                foreach (Customers customers in GetALL())
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

                List<Customers> newList = GetALL();                
                newList.RemoveAll(x => x.DNI == DNI);
                SaveList(newList);
            }

            public static void SaveList(List<Customers> listCustomers)
            {

                AccessDB<Customers> bd = new AccessDB<Customers>(BDcustomers);
                bd.SaveList(listCustomers);
            }
        }
}

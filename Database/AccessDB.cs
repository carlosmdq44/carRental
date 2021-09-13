using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;

namespace RentCars
{
        public class AccessDB<T>
        {
            private List<T> values; //Creo una lista generica
            public string route;
            public AccessDB(string r)
            {
                route = r;
            }
            public void Save()
            {
            //agregar try catch
                string text = JsonConvert.SerializeObject(values); //creo este tipo de string por si la clase tiene int,double,float
                File.WriteAllText(route, text);
            }
        public void SaveList(List<T> list)
        {
            try
            {
                string text = JsonConvert.SerializeObject(list); //creo este tipo de string por si la clase tiene int,double,float
                File.WriteAllText(route, text);
            }
            catch (Exception ex) {

                Console.WriteLine("Excepcion al guardar la lista " + ex.ToString());
            }

          

            
        }
        public void Read() // Lee el archivo
            {
                try { //Ponemos un try - catch en caso que el archivo no exista
                    string file = File.ReadAllText(route);
                    values = JsonConvert.DeserializeObject<List<T>>(file);
                    if (values == null) {
                        values = new List<T>();
                    }
                }
                catch (Exception ex) {
                    values = new List<T>();
                }
            }
        public List<T> getValues() {
            Read();
            return values;
        }
            public void Insert(T nuevo){
                Read();
                values.Add(nuevo);
                Save();
            }
            public List<T> Search(Func<T, bool> criterio){
                return values.Where(criterio).ToList();
            }
            public void Remove(Func<T, bool> criterio)
            {
                values = values.Where(x => !criterio(x)).ToList();
            }
        }
    }


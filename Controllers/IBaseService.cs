using System.Collections.Generic;

namespace RentCars.Controllers
{
    internal interface IBaseService<T>
    {
        T Create(T obj);
        T Get(int id);
        T Update(T obj, int id);
        void Delete(int id);
        List<T> GetAll();
        bool EntityExist(int id);
    }
}
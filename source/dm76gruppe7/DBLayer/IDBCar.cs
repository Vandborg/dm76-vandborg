using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using DataTier;

namespace DBLayer
{
    public interface IDBCar
    {
        List<Car> getAllCars();
        Car searchCarID(int id);
        Boolean updateCar(Car Car);
        Boolean createCar(Car Car);
        Boolean deleteCar(Car Car);
    }
}

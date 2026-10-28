using Assignment_10._3.Data;
using Assignment_10._3.Models;
using System;
using System.Collections.Generic;
using System.Text;

namespace Assignment_10._3.Services
{
    public class CRUD
    {
        public void AddCar(Car car)
        {
            Records.context.Cars.Add(car);
            Records.context.SaveChanges();
        }

        public List<Car> GetCars()
        {
            return Records.context.Cars.ToList();
        }

        public void DeleteCar(int id)
        {
            var car = Records.context.Cars.Find(id);

            if (car != null)
            {
                Records.context.Cars.Remove(car);
                Records.context.SaveChanges();
            }
        }

        public void UpdateCar(int id,  Car car)
        {
            var newCar = Records.context.Cars.Find(id);

            if(newCar != null)
            {
                newCar.Make = car.Make;
                newCar.Model = car.Model;
                newCar.Year = car.Year;
                newCar.Price = car.Price;
                newCar.VIN = car.VIN;

                Records.context.SaveChanges();
            }
        }

        public Car? GetCar(int id)
        {
            return Records.context.Cars.Find(id);
        }

    }
}

using Business.Concrete;
using DataAccess.Concrete;
using Entities.Concrete;
using System;

namespace ConsoleUI
{
    class Program
    {
        static void Main(string[] args)
        {
            CarManager carManager = new CarManager(new InMemoryCarDal());
            Car updateCar = new Car { Id = 2, BrandId = 3, ColorId = 6, DailyPrice = 1600, Description = "A new fan-favorite addition to our collection", ModelYear = 2013 };
            carManager.Update(updateCar);
            foreach (var car in carManager.GetAll())
            {
                Console.WriteLine(car.Description);
            }
        }
    }
}

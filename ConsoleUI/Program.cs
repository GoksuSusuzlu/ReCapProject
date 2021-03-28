using Business.Concrete;
using DataAccess.Concrete;
using DataAccess.Concrete.EntityFramework;
using Entities.Concrete;
using System;

namespace ConsoleUI
{
    class Program
    {
        static void Main(string[] args)
        {
            //new Car { Id = 1, BrandId = 3, ColorId = 4, DailyPrice = 600, Description = "An old car enough for small daily use", ModelYear = 2003 },
            //new Car { Id = 2, BrandId = 2, ColorId = 2, DailyPrice = 1300, Description = "An ideal family car", ModelYear = 2010 },
            //new Car { Id = 3, BrandId = 1, ColorId = 1, DailyPrice = 1000, Description = "small but fuel efficient car suitable for a single person.", ModelYear = 2008 },
            //new Car { Id = 4, BrandId = 5, ColorId = 5, DailyPrice = 3000, Description = "Luxury car for people who wants a ride with high standards", ModelYear = 2017 },
            Car carToUpdate = new Car { BrandId = 2, ColorId = 4, DailyPrice = 2000, Description = "Another nice sedan which provides decent comfort and performance", ModelYear = 2015 };
            CarManager carManager = new CarManager(new EfCarDal());
            carManager.Add(carToUpdate);

            carToUpdate.Description = "A nice sedan which provides decent comfort and performance(updated)";

            carManager.Update(carToUpdate);
  
            foreach (var car in carManager.GetAll())
            {
                Console.WriteLine(car.Description);
            }
        }
    }
}

using DataAccess.Abstract;
using Entities.Concrete;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace DataAccess.Concrete
{
    public class InMemoryCarDal : ICarDal
    {
        List<Car> _cars;

        public InMemoryCarDal()
        {
            _cars = new List<Car> {
                new Car{ Id = 1, BrandId = 3, ColorId = 4, DailyPrice = 600, Description = "An old car enough for small daily use", ModelYear = 2003},
                new Car{ Id = 2, BrandId = 2, ColorId = 2, DailyPrice = 1300, Description = "An ideal family car", ModelYear = 2010},
                new Car{ Id = 3, BrandId = 1, ColorId = 1, DailyPrice = 1000, Description = "small but fuel efficient car suitable for a single person.", ModelYear = 2008},
                new Car{ Id = 4, BrandId = 5, ColorId = 5, DailyPrice = 3000, Description = "Luxury car for people who wants a ride with high standards", ModelYear = 2017},
                new Car{ Id = 5, BrandId = 4, ColorId = 3, DailyPrice = 2300, Description = "A nice sedan which provides decent comfort and performance", ModelYear = 2015},
            };
            
            
        }
        public void Add(Car car)
        {
            _cars.Add(car);
        }
        //LINQ = language Integrated Query
        public void Delete(Car car)
        {
            // Gönderdiğim ürün idsine sahip olan listedeki arabayi bul.

            Car carToDelete = _cars.SingleOrDefault(c => c.Id == car.Id);
            _cars.Remove(carToDelete);
        }

        public List<Car> GetAll()
        {
            return _cars;
        }

        public Car GetById(int id)
        {
            Car carToReturn = _cars.SingleOrDefault(c => c.Id == id);
            return carToReturn;
        }

        public void Update(Car car)
        {
            Car carToUpdate = _cars.SingleOrDefault(c => c.Id == car.Id);
            carToUpdate.Id = car.Id;
            carToUpdate.BrandId = car.BrandId;
            carToUpdate.ColorId = car.ColorId;
            carToUpdate.DailyPrice = car.DailyPrice;
            carToUpdate.Description = car.Description;
        }
    }
}

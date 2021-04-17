using DataAccess.Abstract;
using Entities.Concrete;
using Entities.DTOs;
using RecapCore.Utility.Results.Abstract;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;

namespace DataAccess.Concrete
{
    public class InMemoryCarDal : ICarDal
    {
        List<Car> _cars;

        public InMemoryCarDal()
        {
            _cars = new List<Car> {
                new Car{ CarId = 1, BrandId = 3, ColorId = 4, DailyPrice = 600, Description = "An old car enough for small daily use", ModelYear = 2003},
                new Car{ CarId = 2, BrandId = 2, ColorId = 2, DailyPrice = 1300, Description = "An ideal family car", ModelYear = 2010},
                new Car{ CarId = 3, BrandId = 1, ColorId = 1, DailyPrice = 1000, Description = "small but fuel efficient car suitable for a single person.", ModelYear = 2008},
                new Car{ CarId = 4, BrandId = 5, ColorId = 5, DailyPrice = 3000, Description = "Luxury car for people who wants a ride with high standards", ModelYear = 2017},
                new Car{ CarId = 5, BrandId = 4, ColorId = 3, DailyPrice = 2300, Description = "A nice sedan which provides decent comfort and performance", ModelYear = 2015},
            };
            
            
        }
        public void Add(Car car)
        {
            _cars.Add(car);
        }

        public List<CarDetailDto> GetCarDetails()
        {
            throw new NotImplementedException();
        }

        //LINQ = language Integrated Query
        public void Delete(Car car)
        {
            // Gönderdiğim ürün idsine sahip olan listedeki arabayi bul.

            Car carToDelete = _cars.SingleOrDefault(c => c.CarId == car.CarId);
            _cars.Remove(carToDelete);
        }

        public Car Get(Expression<Func<Car, bool>> filter)
        {
            throw new NotImplementedException();
        }

        public List<Car> GetAll()
        {
            return _cars;
        }

        public List<Car> GetAll(Expression<Func<Car, bool>> filter = null)
        {
            throw new NotImplementedException();
        }

        public Car GetById(int id)
        {
            Car carToReturn = _cars.SingleOrDefault(c => c.CarId == id);
            return carToReturn;
        }

        public void Update(Car car)
        {
            Car carToUpdate = _cars.SingleOrDefault(c => c.CarId == car.CarId);
            carToUpdate.CarId = car.CarId;
            carToUpdate.BrandId = car.BrandId;
            carToUpdate.ColorId = car.ColorId;
            carToUpdate.DailyPrice = car.DailyPrice;
            carToUpdate.Description = car.Description;
        }

        IDataResult<List<CarDetailDto>> ICarDal.GetCarDetails()
        {
            throw new NotImplementedException();
        }

        public IDataResult<List<CarDetailDto>> GetCarDetailsByColorId(int colorId)
        {
            throw new NotImplementedException();
        }

        public IDataResult<List<CarDetailDto>> GetCarDetailsByBrandId(int brandId)
        {
            throw new NotImplementedException();
        }
    }
}

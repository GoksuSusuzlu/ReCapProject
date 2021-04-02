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
            //CarTest();
            //BrandTest();
            //ColorTest();
            //UserTest();
            //CustomerTest();
            //RentalTest();

        }

        private static void RentalTest()
        {
            RentalManager rentalManager = new RentalManager(new EfRentalDal());
            //rentalManager.Add(new Rental { CarId = 1, RentDate = DateTime.Now, CustomerId = 3, ReturnDate = new DateTime(2021,4,4,21,04,23)}); // burdan devamke
            foreach (var rental in rentalManager.GetRentalDetails().Data)
            {
                Console.WriteLine(rental.CompanyName);
            }
        }

        private static void CustomerTest()
        {
            CustomerManager customerManager = new CustomerManager(new EfCustomerDal());
            customerManager.Add(new Customer { UserId = 1, CompanyName = "Susuzlu Ltd. Sti." });
            customerManager.Add(new Customer { UserId = 2, CompanyName = "AcunMedya" });
            foreach (var customer in customerManager.GetAll().Data)
            {
                Console.WriteLine(customer.CompanyName);
            }
        }

        private static void UserTest()
        {
            UserManager userManager = new UserManager(new EfUserDal());
            User user = new User { FirstName = "İbrahim", LastName = "Tatlıses", Email = "ibo@gmail.com", Password = "1234" };
            userManager.Add(user);
            user.Email = "ibo@hotmail.com";
            userManager.Update(user);
            //userManager.Add(user);
            //userManager.Add(new User { FirstName = "Acun", LastName = "Ilıcalı", Email = "acun.ilicali@hotmail.com", Password = "1234" });
            //userManager.Add(new User { FirstName = "Ali", LastName = "Ağaoğlu", Email = "ali.agaoglu@hotmail.com", Password = "1234" });
            //userManager.Add(new User { FirstName = "Harun", LastName = "Sinanoğlu", Email = "harunsinanoglu@hotmail.com", Password = "1234" });
            //userManager.Add(new User { FirstName = "İsmet Arif", LastName = "Karasu", Email = "akbaba.ismet@hotmail.com", Password = "1234" });

            foreach (var rentalUser in userManager.GetAll().Data)
            {

                Console.WriteLine(rentalUser.FirstName + " " + rentalUser.LastName + "----" + rentalUser.Email);
            }
        }

        private static void ColorTest()
        {
            Color color1 = new Color { Name = "Red" };
            Color color2 = new Color { Name = "Blue" };
            Color color3 = new Color { Name = "Yellow" };
            Color color4 = new Color { Name = "Green" };
            Color color5 = new Color { Name = "Black" };
            ColorManager colorManager = new ColorManager(new EfColorDal());
            colorManager.Add(color1);
            colorManager.Add(color2);
            colorManager.Add(color3);
            colorManager.Add(color4);
            colorManager.Add(color5);
        }

        private static void BrandTest()
        {
            //Brand brand1 = new Brand { Name = "BMW" };
            //Brand brand2 = new Brand { Name = "Alpha Romeo" };
            //Brand brand3 = new Brand { Name = "Audi" };
            //Brand brand4 = new Brand { Name = "Mercedes" };
            //Brand brand5 = new Brand { Name = "Volkswagen" };
            BrandManager brandManager = new BrandManager(new EfBrandDal());
            //brandManager.Add(brand1);
            //brandManager.Add(brand2);
            //brandManager.Add(brand3);
            //brandManager.Add(brand4);
            //brandManager.Add(brand5);
            foreach (var brand in brandManager.GetAll().Data)
            {
                Console.WriteLine(brand.Name);
            }
        }

        private static void CarTest()
        {
            //new Car { Id = 1, BrandId = 3, ColorId = 4, DailyPrice = 600, Description = "An old car enough for small daily use", ModelYear = 2003 },
            //new Car { Id = 2, BrandId = 2, ColorId = 2, DailyPrice = 1300, Description = "An ideal family car", ModelYear = 2010 },
            //new Car { Id = 3, BrandId = 1, ColorId = 1, DailyPrice = 1000, Description = "small but fuel efficient car suitable for a single person.", ModelYear = 2008 },
            //new Car { Id = 4, BrandId = 5, ColorId = 5, DailyPrice = 3000, Description = "Luxury car for people who wants a ride with high standards", ModelYear = 2017 },
            //Car carToUpdate = new Car { BrandId = 2, ColorId = 4, DailyPrice = 2000, Description = "Another nice sedan which provides decent comfort and performance", ModelYear = 2015 };
            CarManager carManager = new CarManager(new EfCarDal());
            foreach (var car in carManager.GetCarDetails().Data)
            {
                //CarManager tamam, diger managerlari refactor et.
                Console.WriteLine(car.BrandName + "/" + car.ColorName + "/" + car.DailyPrice + "/" + car.Description);
            }

            //carManager.Add(carToUpdate);

            //carToUpdate.Description = "A nice sedan which provides decent comfort and performance(updated)";

            //carManager.Update(carToUpdate);

            //foreach (var car in carManager.GetAll())
            //{
            //    Console.WriteLine(car.Description);
            //}

        }
    }
}

using Business.Concrete;
using DataAccess.Concrete.EntityFramework;
using Entities.Concrete;
using System;

namespace RentaCar
{
    class Program
    {
        static void Main(string[] args)
        {
            //BrandManagerTest();
            //CarManagerTest();
            //UserManagerTest();

            RentalsManager rentalsManager = new RentalsManager(new EfRentalsDal());
            var rentalsAdd=rentalsManager.Add(new Rentals { CarId=1,CustomerId=1,RentDate=DateTime.Now,ReturnDate=DateTime.Today});
            Console.WriteLine(rentalsAdd.Message);

            Console.Read();
        }

        private static void UserManagerTest()
        {
            UserManager userManager = new UserManager(new EfUserDal());
            var user = userManager.Add(new Users { FirstName = "Deniz", LastName = "Karakılıç", Email = "mihriban_karakilic@hotmail.com", Password = "1234" });
            Console.WriteLine(user.Message);
            foreach (var users in userManager.GetAll().Data)
            {
                Console.WriteLine(users.FirstName + " " + users.LastName);
            }
        }

        private static void BrandManagerTest()
        {
            BrandManager brandManager = new BrandManager(new EfBrandDal());
            brandManager.Add(new Brand { Id = 1, Brandname = "Fo" });
        }

        private static void CarManagerTest()
        {
            CarManager carManager = new CarManager(new EfCarDal());
            carManager.Add(new Car { Id = 1, BrandId = 2, ColorId = 3, DailyPrice = 0, ModelYear = "2020" });

            Console.WriteLine("----------------------------------------------------------------------");

            foreach (var car in carManager.GetAll().Data)
            {
                Console.WriteLine(car.Id + " " + car.ModelYear + " " + car.DailyPrice + " " + car.Description);
            }

            Console.WriteLine("-----------GetByDailyPrice(min=250,max=500)------------------------");

            foreach (var car in carManager.GetByDailyPrice(250, 500).Data)
            {
                Console.WriteLine(car.Id + " " + car.ModelYear + " " + car.DailyPrice + " " + car.Description);
            }

            Console.WriteLine("-------------------GetCarsByBrandId------------------------------");

            foreach (var car in carManager.GetCarsByBrandId(3).Data)
            {
                Console.WriteLine(car.Id + " " + car.ModelYear + " " + car.DailyPrice + " " + car.Description);
            }

            Console.WriteLine("-------------------GetCarsByColorId-----------------------------");

            foreach (var car in carManager.GetCarsByColorId(5).Data)
            {
                Console.WriteLine(car.ColorId + " " + car.ModelYear + " " + car.DailyPrice + " " + car.Description);

            }
        }
    }
}
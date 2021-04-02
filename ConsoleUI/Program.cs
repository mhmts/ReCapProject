using Business.Concrete;
using DataAccess.Concrete;
using DataAccess.Concrete.EntityFramework;
using Entities;
using Entities.Concrete;
using System;

namespace ConsoleUI
{
    class Program
    {
        static void Main(string[] args)
        {
            Customer customer = new Customer { CompanyName = "ABC", UserId = 1 };
            User user = new User { FirstName = "Mehmet", LastName = "ışık", Email = "mehmet@gmail.com", Password = "123456Aa" };
            Rental rental = new Rental { CarId = 3, CustomerId = 2, RentDate = new DateTime(2021, 04, 02), ReturnDate = new DateTime(2021, 04, 20) };


            CustomerTest(customer);
            UserTest(user);
            RentalTest(rental);

            //  CarTest();
            // Brandtest();
            // ColorTest();
        }

        private static void CarTest()
        {

            CarManager carManager = new CarManager(new EfCarDal());

            Car car = new Car
            {
               
                Id = 7,
                ColorId = 2,
                BrandId = 1,
                DailyPrice = 200,
                ModelYear = 2020,
                Description = "Seat, otomatik"
            };

            
            carManager.Add(car);

           
            ArabaListele(carManager);

            car.Description = "volvo, otomatik, deri koltuk";
            carManager.Update(car);
        }
        private static void ArabaListele(CarManager carManager)
        {
            Console.WriteLine("mevcut araba listesi : ");
            foreach (var car in carManager.GetCarDetails().Data)
            {
                Console.WriteLine(car.CarName + "," + car.BrandName + "," + car.ColorName + "," + car.DailyPrice);
            }
        }
        private static void Brandtest()
        {
            BrandManager brandManager = new BrandManager(new EfBrandDal());
            Brand brand = new Brand
            {
                Id = 2,
                BrandName = "Toyota"
            };
            brandManager.Add(brand);

            Console.WriteLine("marka listesi:");
            foreach (var brand1 in brandManager.GetAll().Data)
            {
                Console.WriteLine(brand1.BrandName);
            }
            brand.BrandName = "Renault";
            brandManager.Update(brand);

            Console.WriteLine("güncel marka listesi:");
            foreach (var brand1 in brandManager.GetAll().Data)
            {
                Console.WriteLine(brand1.BrandName);
            }

            //brandManager.Delete(brand);
        }
        private static void ColorTest()
        {
            ColorManager colorManager = new ColorManager(new EfColorDal());
            Color color = new Color()
            {
                Id = 1,
                ColorName = "Kırmızı"
            };
            colorManager.Add(color);

            Console.WriteLine("renk listesi:");
            foreach (var item in colorManager.GetAll().Data)
            {
                Console.WriteLine(item.ColorName);
            }
            color.ColorName = "Siyah";
            colorManager.Update(color);

            Console.WriteLine("güncel renk listesi:");
            foreach (var item in colorManager.GetAll().Data)
            {
                Console.WriteLine(item.ColorName);
            }
            //  colorManager.Delete(item);

            Console.WriteLine("güncel renk listesi:");
            foreach (var item in colorManager.GetAll().Data)
            {
                Console.WriteLine(item.ColorName);
            }
        }

        private static void CustomerTest(Customer customer)
        {
            CustomerManager customerManager = new CustomerManager(new EfCustomerDal());
            Console.WriteLine(customerManager.Add(customer).Message);
            foreach (var item in customerManager.GetAll().Data)
            {
                Console.WriteLine(item.CompanyName);
            }
        }

        private static void UserTest(User user)
        {
            UserManager userManager = new UserManager(new EfUserDal());
            Console.WriteLine(userManager.Add(user).Message);
            foreach (var item in userManager.GetAll().Data)
            {
                Console.WriteLine(item.FirstName);
            }
        }

        private static void RentalTest(Rental rental)
        {
            RentalManager rentalManager = new RentalManager(new EfRentalDal());
            Console.WriteLine(rentalManager.Add(rental).Message);
            foreach (var item in rentalManager.GetAll().Data)
            {
                Console.WriteLine(item.Id);
            }
        }
    }
}

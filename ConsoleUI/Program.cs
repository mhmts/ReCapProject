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
               CarTest();
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
    }
}

using Core.DataAccess.EntityFramework;
using DataAccess.Abstract;
using Entities;
using Entities.DTOs;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;

namespace DataAccess.Concrete.EntityFramework
{
    public class EfCarDal : EfEntityRepositoryBase<Car, CarDbContext>, ICarDal
    {

       
            public List<CarDetailDto> GetCarDetails()
            {
                using (CarDbContext context = new CarDbContext())
                {
                    var result = from c in context.Cars
                                 join b in context.Brands
                                 on c.BrandId equals b.Id
                                 join color in context.Colors
                                 on c.ColorId equals color.Id
                                 select new CarDetailDto { CarName = c.Description, BrandName = b.BrandName, ColorName = color.ColorName, DailyPrice = c.DailyPrice };

                    return result.ToList();


                }
           
        }


    }
}


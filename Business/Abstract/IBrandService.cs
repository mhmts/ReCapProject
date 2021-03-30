using Entities.Concrete;
using System;
using System.Collections.Generic;
using System.Text;

namespace Business.Abstract
{
   public interface IBrandService
    {
        void  GetByBrandId(int Id);

        List<Brand> GetAll();
        void Add(Brand brand);
        void Delete(Brand brand);
        void Update(Brand brand);

    }
}

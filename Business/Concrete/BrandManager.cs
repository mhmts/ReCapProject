using Business.Abstract;
using DataAccess.Abstract;
using Entities.Concrete;
using System;
using System.Collections.Generic;
using System.Text;

namespace Business.Concrete
{
    public class BrandManager : IBrandService
    {
        IBrandDal _brandDal;

        public BrandManager(IBrandDal brandDal)
        {
            _brandDal = brandDal;
        }
        
        public List<Brand> GetAll()
        {
            return _brandDal.GetAll();
        }
        public void GetByBrandId(int id)
        {
            _brandDal.GetAll(b => b.Id == id);
        }
        public void Add(Brand brand)
        {
            if (brand.BrandName.Length >= 2)
            {
                _brandDal.Add(brand);
            }
            else
            {
                Console.WriteLine("Arabanın Markası en az 2 karakter olmalıdır.");
            }
        }
        public void Update(Brand brand)
        {
            _brandDal.Update(brand);
        }

        public void Delete(Brand brand)
        {
            _brandDal.Delete(brand);
        }

       
       
    }
}

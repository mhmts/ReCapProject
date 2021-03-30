using Business.Abstract;
using DataAccess.Abstract;
using Entities;
using Entities.DTOs;
using System;
using System.Collections.Generic;
using System.Text;

namespace Business.Concrete
{
    public class CarManager : ICarService
    {
        ICarDal _carDal;

        public CarManager(ICarDal carDal)
        {
            _carDal = carDal;
        }

        public List<Car> GetAll()
        {
            return _carDal.GetAll();
        }
        public void GetByCarId(int id)
        {
            _carDal.GetAll(b => b.Id == id);
        }
        public void Add(Car car)
        {

            _carDal.Add(car);


        }
        public void Update(Car car)
        {
            _carDal.Update(car);
        }

        public void Delete(Car car)
        {
            _carDal.Delete(car);
        }
        public List<CarDetailDto> GetCarDetails()
        {

            return _carDal.GetCarDetails();


        }
    }
}

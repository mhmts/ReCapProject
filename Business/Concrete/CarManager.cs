using Business.Abstract;
using Business.Constants;
using Business.ValidationRules.FluentValidation;
using Core.Aspects.Autofac;
using Core.Utilities.Results;
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

        public IDataResult<List<Car>> GetAll()
        {
            if (DateTime.Now.Hour==11)
            {
                return new ErrorDataResult<List<Car>>(Messages.MaintenanceTime);
            }
           
            return new SuccessDataResult<List<Car>>(_carDal.GetAll(),Messages.CarListed);
        }
      

        public IResult GetByCarId(int id)
        {
           _carDal.GetAll(b => b.Id == id);
            return new SuccessResult();
        }
        [ValidationAspect(typeof(CarValidator))]
        public IResult Add(Car car)
        {                     
            _carDal.Add(car);
            return new SuccessResult(Messages.CarAdded);

        }
        public IResult Update(Car car)
        {
            _carDal.Update(car);
            return new SuccessResult();
        }

        public IResult Delete(Car car)
        {
            _carDal.Delete(car);
            return new SuccessResult();
        }
        
    

       public IDataResult<List<CarDetailDto>> GetCarDetails()
        {
            return new SuccessDataResult<List<CarDetailDto>>(_carDal.GetCarDetails());
        }
     

    }
}

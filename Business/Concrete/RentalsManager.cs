using Business.Abstract;
using Business.Constants;
using Core.Utilities.Results;
using DataAccess.Abstract;
using Entities.Concrete;
using System;
using System.Collections.Generic;

namespace Business.Concrete
{
    public class RentalsManager : IRentalsService
    {
        IRentalsDal _rentalsDal;
        public RentalsManager(IRentalsDal rentalsDal)
        {
            _rentalsDal = rentalsDal;
        }
        public IResult Add(Rentals rentals)
        {
            var dateRent = rentals.RentDate;
            var dateReturn = rentals.ReturnDate;

            if (dateRent<dateReturn ||dateReturn == null)
                return new ErrorResult(Messages.RentalsError);
            else
            {
                _rentalsDal.Add(rentals);
                return new SuccessResult(Messages.RentalsAdded);
            }          
        }

        public IResult Delete(Rentals rentals)
        {
            _rentalsDal.Delete(rentals);
           return new SuccessResult(Messages.Deleted);
        }

        public IDataResult<List<Rentals>> GetAll()
        {
            if (DateTime.Now.Hour==22)
            {
                return new ErrorDataResult<List<Rentals>>(Messages.MaintenanceTime);
            }
           return new SuccessDataResult<List<Rentals>>(_rentalsDal.GetAll(),Messages.Listed);
        }

        public IResult Update(Rentals rentals)
        {
            if (rentals.ReturnDate == null)
            {
                return new ErrorResult(Messages.RentalsError);
            }
            _rentalsDal.Update(rentals);
            return new SuccessResult(Messages.Update);
        }
    }
}
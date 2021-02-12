using Business.Abstract;
using Business.Constants;
using Core.Utilities.Results;
using DataAccess.Abstract;
using Entities.Concrete;
using System.Collections.Generic;

namespace Business.Concrete
{
    public class CustomerManager : ICustomerService
    {
        ICustomerDal _customerDal;
        public CustomerManager(ICustomerDal customerDal)
        {
            _customerDal = customerDal;
        }
        public IResult Add(Customers customers)
        {
            _customerDal.Add(customers);
            return new SuccessResult(Messages.Added);
        }

        public IResult Update(Customers customers)
        {
            _customerDal.Update(customers);
            return new SuccessResult(Messages.Update);
        }

        public IResult Delete(Customers customers)
        {
            _customerDal.Delete(customers);
            return new SuccessResult(Messages.Deleted);
        }

        public IDataResult<List<Customers>> GetAll()
        {           
            return new SuccessDataResult<List<Customers>>(_customerDal.GetAll(),Messages.Listed);
        }

        public IDataResult<Customers> GetById(int userId)
        {
            return new SuccessDataResult<Customers>(_customerDal.Get(I=>I.UserId == userId));
        }
    }
}
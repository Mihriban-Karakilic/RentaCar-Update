using System.Collections.Generic;
using Business.Abstract;
using Business.Constants;
using Core.Utilities.Results;
using DataAccess.Abstract;
using Entities.Concrete;

namespace Business.Concrete
{
    public class UserManager : IUserServis
    {
        IUserDal _userDal;
        public UserManager(IUserDal userDal)
        {
            _userDal = userDal;
        }
        public IResult Add(Users users)
        {
            if (users.FirstName == null || users.LastName == null || users.Password == null|| users.Email== null)
            {
                return new ErrorResult(Messages.UserNotAdded);
            }
            _userDal.Add(users);
            return new SuccessResult(Messages.Added);

        }

        public IResult Delete(Users users)
        {
            _userDal.Delete(users);
            return new SuccessResult(Messages.Deleted);
        }

        public IResult Update(Users users)
        {
            _userDal.Update(users);
            return new SuccessResult(Messages.Update);
        }

        public IDataResult<List<Users>> GetAll()
        {
            return new SuccessDataResult<List<Users>>(_userDal.GetAll(),Messages.Listed);
        } 
    }
}
using DataAccess.Abstract;
using Entities.Concrete;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;

namespace DataAccess.Concrete.EntityFramework
{
    public class EfUserDal : IUserDal
    {
        public void Add(Users entity)
        {
            using (RentaCarContext context=new RentaCarContext())
            {
                var addedEntity = context.Entry(entity);
                addedEntity.State = EntityState.Added;
                context.SaveChanges();
            }
        }

        public void Delete(Users entity)
        {
            using (RentaCarContext context=new RentaCarContext())
            {
                var deletedEntity = context.Entry(entity);
                deletedEntity.State = EntityState.Deleted;
                context.SaveChanges();
            }
        }

        public Users Get(Expression<Func<Users, bool>> filter)
        {
            using (RentaCarContext context=new RentaCarContext())
            {
               return context.Set<Users>().SingleOrDefault(filter);
            }
        }

        public List<Users> GetAll(Expression<Func<Users, bool>> filter = null)
        {
            using (RentaCarContext context=new RentaCarContext())
            {
                return filter == null ? context.Set<Users>().ToList() : context.Set<Users>().Where(filter).ToList();
            }
        }

        public void Update(Users entity)
        {
            using (RentaCarContext context=new RentaCarContext())
            {
                var updateEntity = context.Entry(entity);
                updateEntity.State = EntityState.Modified;
                context.SaveChanges();
            }
        }
    }
}
using DataAccess.Abstract;
using Entities.Concrete;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;

namespace DataAccess.Concrete.EntityFramework
{
    public class EfCustomerDal : ICustomerDal
    {
        public void Add(Customers entity)
        {
            using (RentaCarContext context=new RentaCarContext())
            {
                var addedEntity = context.Entry(entity);
                addedEntity.State = EntityState.Added;
                context.SaveChanges();
            }
        }

        public void Delete(Customers entity)
        {
            using (RentaCarContext context=new RentaCarContext())
            {
                var deletedEntity = context.Entry(entity);
                deletedEntity.State = EntityState.Deleted;
                context.SaveChanges();
            }
        }

        public void Update(Customers entity)
        {
            using (RentaCarContext context=new RentaCarContext())
            {
                var updateEntity = context.Entry(entity);
                updateEntity.State = EntityState.Modified;
                context.SaveChanges();
            }
        }

        public Customers Get(Expression<Func<Customers, bool>> filter)
        {
            using (RentaCarContext context=new RentaCarContext())
            {
                return context.Set<Customers>().FirstOrDefault(filter);
            }
        }

        public List<Customers> GetAll(Expression<Func<Customers, bool>> filter = null)
        {
            using (RentaCarContext context=new RentaCarContext())
            {
                return filter == null ? context.Set<Customers>().ToList() : context.Set<Customers>().Where(filter).ToList();
            }
        }
    }
}
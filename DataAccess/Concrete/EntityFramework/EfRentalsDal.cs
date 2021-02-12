using DataAccess.Abstract;
using Entities.Concrete;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;

namespace DataAccess.Concrete.EntityFramework
{
    public class EfRentalsDal : IRentalsDal
    {
        public void Add(Rentals entity)
        {
            using (RentaCarContext context=new RentaCarContext())
            {
                var addedEntity = context.Entry(entity);
                addedEntity.State = EntityState.Added;
                context.SaveChanges();
            }
        }

        public void Delete(Rentals entity)
        {
            using (RentaCarContext context=new RentaCarContext())
            {
                var deletedEntity = context.Entry(entity);
                deletedEntity.State = EntityState.Deleted;
                context.SaveChanges();
            }
        }


        public void Update(Rentals entity)
        {
            using (RentaCarContext context=new RentaCarContext())
            {
                var updateEntity = context.Entry(entity);
                updateEntity.State = EntityState.Modified;
                context.SaveChanges();
            }
        }
        public Rentals Get(Expression<Func<Rentals, bool>> filter)
        {
            using (RentaCarContext context=new RentaCarContext())
            {
                return context.Set<Rentals>().FirstOrDefault(filter);
            }
        }

        public List<Rentals> GetAll(Expression<Func<Rentals, bool>> filter = null)
        {
            using (RentaCarContext context=new RentaCarContext())
            {
                return filter == null ? context.Set<Rentals>().ToList() : context.Set<Rentals>().Where(filter).ToList();
            }
        }
    }
}
﻿using DAL.Abstract;
using DAL.Concrete;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;

namespace DAL.Repository
{
    public class GenericRepository<T> : IGenericDAL<T> where T : class
    {
        public void Delete(T t)
        {
            using var c = new Context();
            c.Remove(t);
            c.SaveChanges();    

        }

        public List<T> GetbyFilter(Expression<Func<T, bool>> filter)
        {

            using var c = new Context();
            return c.Set<T>().Where(filter).ToList();

        }

        public T GetByID(int id)
        {

            using var c = new Context();
            return c.Set<T>().Find(id);

        }

        public List<T> GetList()
        {

            using var c = new Context();
            return c.Set<T>().ToList();

        }

        public void Insert(T t)
        {

            using var c = new Context();
            c.Add(t);
            c.SaveChanges();

        }

        public void Update(T t)
        {

            using var c = new Context();
            c.Update(t);
            c.SaveChanges();

        }
    }
}

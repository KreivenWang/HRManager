using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Text;
using HRModel;

namespace HRManagerDataAccess
{
    public class EntityDataFactory<T> : IDataControl<T> where T : class
    {

        private DbSet<T> currentDbset;

        public EntityDataFactory(DbSet<T> dbSet)
        {
            currentDbset = dbSet;
        }

       

        public void Add(T t)
        {
            currentDbset.Add(t);
            HrManagerContext.GetInstance().SaveChanges();
        }

        public void Delete(T t)
        {
            currentDbset.Remove(t);
            HrManagerContext.GetInstance().SaveChanges();
        }

        public T GetItem(int id)
        {
            return currentDbset.Find(id);
        }

        public List<T> GetItems()
        {
            return currentDbset.ToList();
        }


        public int Update()
        {
          return  HrManagerContext.GetInstance().SaveChanges();
        }
    }
}

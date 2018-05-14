using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace HRManagerDataAccess
{
    public interface IDataControl<T>
    {
        void Add(T  t);


        void Delete(T t);

        T GetItem(int id);


        List<T> GetItems();

        int Update();
    }
}

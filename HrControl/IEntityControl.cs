using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using HRManagerDataAccess;
using HRModel;
using Steelsa;

namespace HrControl
{
    public abstract class EntityControl<T> where T : class
    {
        protected EntityDataFactory<T> Factory { get; private set; }

        public EntityControl()
        {
            Factory = new EntityDataFactory<T>(HrManagerContext.GetDbSetInstance<T>());
        }

        public virtual bool AddEntity(T t)
        {
            InitLogNeed(t);
            try
            {
                Factory.Add(t);
                WriteLog("添加成功");
                StatusConsole.WriteLine("添加成功");
                return true;
            }
            catch (Exception e)
            {
                WriteLogFalse("添加失败",e);
                StatusConsole.WriteLine("添加失败");
                return false;
            }
        }

        public bool DeleteEntity(T t)
        {
            InitLogNeed(t);
            if (!DeleteProtected(t))
            {
                WriteDeleteProtectedLog("删除失败");
                StatusConsole.WriteLine("删除失败! (对象受删除保护)");
                return false;
            }
            try
            {
                Factory.Delete(t);
                WriteLog("删除成功");
                StatusConsole.WriteLine("删除成功");
                return true;
            }
            catch (Exception e)
            {
                WriteLogFalse("删除失败",e);
                StatusConsole.WriteLine("删除失败");
                return false;
            }
        }

        public bool UpDataEntity()
        {
            try
            {
               var effect =  Factory.Update();
                ParaList.Add(effect.ToString());
                WriteLog("更新成功,更新记录");
                StatusConsole.WriteLine("已更新记录");
                return true;
            }
            catch (Exception e)
            {
                WriteLogFalse("更新失败",e);
                StatusConsole.WriteLine("更新失败");
                return false;
            }
        }

        public virtual List<T> GetEntitys()
        {
            return Factory.GetItems();
        }


        protected List<string> ParaList = new List<string>(); 

        protected abstract void InitLogNeed(T t);

        protected abstract bool DeleteProtected(T t);

        protected abstract void WriteDeleteProtectedLog(string type);

        protected string GetLogContent()
        {
            var logcontent = string.Empty;
            foreach (var para in ParaList)
            {
                logcontent += '\t' + para;
            }
            return logcontent;
        }

        private void WriteLog(string type)
        {

            LogAccess.Write(type + GetLogContent());

        }

        private void WriteLogFalse(string type, Exception e)
        {
            LogAccess.Write_Exp(type + e +GetLogContent());
        }


    }
}

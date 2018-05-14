using System;
using System.Collections.Generic;
using System.Linq;
using System.Windows.Forms;
using HRModel;

namespace HRManagerDataAccess
{
    static class Program
    {
        /// <summary>
        /// 应用程序的主入口点。
        /// </summary>
        [STAThread]
        static void Main()
        {

            Console.WriteLine("now is database gengxin ");


            //argus.Add(new SystemArgument()
            //{
            //    List = new List<string>()
            //    {
            //        "123",
            //        "456"
            //    }
            //});


            Console.WriteLine("数据库更新完成");
          
           
            Console.Read();







//            using (var db = new HrManagerContext())
//            {



//                // Create and save a new Blog 
//                Console.Write("Enter a name for a new Blog: ");
//                
//                var name = Console.ReadLine();
//
//                var blog = new Employee { EmployeeNO = name };
//                db.Employees.Add(blog);
//                db.SaveChanges();
//
//                // Display all Blogs from the database 
//                var query = from b in db.Employees
//                            orderby b.EmployeeNO
//                            select b;
//
//                Console.WriteLine("All blogs in the database:");
//                foreach (var item in query)
//                {
//                    Console.WriteLine(item.EmployeeNO);
//                }
//
//                Console.WriteLine("Press any key to exit...");
//                Console.ReadKey();
            // } 
        }
    }
}

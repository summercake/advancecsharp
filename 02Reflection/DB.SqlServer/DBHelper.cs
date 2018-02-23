using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using DB.Interface;

namespace DB.SqlServer
{
    /// <summary>
    /// SqlServer版本
    /// </summary>
    public class DBHelper : IDBHelper
    {
        public int Id { get; set; }
        public string Name { get; set; }

        public DBHelper()
        {
            //Console.WriteLine("这里是{0}的无参构造函数", this.GetType().FullName);
        }

        public void Query()
        {
            Console.WriteLine("这里是{0}的Query", this.GetType().FullName);
        }

    }
}

﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using DB.Interface;

namespace DB.Oracle
{
    /// <summary>
    /// Oracle版本
    /// </summary>
    public class DBHelper : IDBHelper
    {
        public DBHelper()
        {
            Console.WriteLine("这里是{0}的无参构造函数", this.GetType().FullName);
        }

        public void Query()
        {
            Console.WriteLine("这里是{0}的Query", this.GetType().FullName);
        }
    }
}

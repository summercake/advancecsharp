using System;
using System.Collections.Generic;
using System.Configuration;
using System.Linq;
using System.Reflection;
using System.Runtime.Remoting.Messaging;
using System.Text;
using System.Threading.Tasks;
using DB.Interface;

namespace _02Reflection
{
    public class SimpleFactory
    {
        private static string TypeDll = ConfigurationManager.AppSettings["IDBHelper"];
        private static string TypeName = TypeDll.Split(',')[0];
        private static string DllName = TypeDll.Split(',')[1];


        public static IDBHelper CreateDbHelper()
        {
            IDBHelper dbHelper = null;
            Assembly assembly = Assembly.Load(TypeName);
            Type typeHelper = assembly.GetType(DllName);
            dbHelper = (IDBHelper)Activator.CreateInstance(typeHelper);
            return dbHelper;
        }
    }
}
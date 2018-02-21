using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _01Generic
{
    class CommonMethod
    {
        public static void ShowInt(int iParameter)
        {
            Console.WriteLine("This is {0}, parameter is {1}, type is {2}", typeof(CommonMethod).Name, iParameter,
                iParameter.GetType().Name);
        }

        public static void ShowString(string sParameter)
        {
            Console.WriteLine("This is {0}, parameter is {1}, type is {2}", typeof(CommonMethod).Name, sParameter,
                sParameter.GetType().Name);
        }

        public static void ShowDateTime(DateTime dtParameter)
        {
            Console.WriteLine("This is {0}, parameter is {1}, type is {2}", typeof(CommonMethod).Name, dtParameter,
                dtParameter.GetType().Name);
        }

        public static void ShowObject(object oParameter)
        {
            Console.WriteLine("This is {0}, parameter is {1}, type is {2}", typeof(CommonMethod).Name, oParameter,
                oParameter.GetType().Name);
        }

        public static void Show<T>(T tParameter)
        {
            Console.WriteLine("This is {0}, parameter is {1}, type is {2}", typeof(CommonMethod).Name, tParameter,
                tParameter.GetType().Name);
        }
    }
}
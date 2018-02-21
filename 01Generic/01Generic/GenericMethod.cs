using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _01Generic
{
    public class GenericMethod
    {
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
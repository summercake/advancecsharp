using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DB.SqlServer
{
    public class GenericClass<T, W, X>
    {
        public GenericClass()
        {
            Console.WriteLine("GenericClass被构造");
        }
    }
}

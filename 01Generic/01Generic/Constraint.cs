using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _01Generic
{
    public class Constraint
    {
        /// <summary>
        /// 1. only can use base class or child class of constraint as parameter
        /// 2. can use properties and methods of base class and constraint 
        /// </summary>
        /// <typeparam name="T"></typeparam>
        /// <param name="tParameter"></param>
        public static void Show<T>(T tParameter) where T : People // base class constraint
        {
            Console.WriteLine("This is {0}, parameter is {1}, type is {2}", typeof(CommonMethod).Name, tParameter,
                tParameter.GetType().Name);
            Console.WriteLine("id = {0}, name = {1}", tParameter.Id, tParameter.Name);
        }


        /// <summary>
        /// generic interface constraint
        /// </summary>
        /// <typeparam name="T"></typeparam>
        /// <param name="tParameter"></param>
        public static void ShowInterface<T>(T tParameter) where T : ISports // interface constraint
        {
            tParameter.Pingpage();
        }

        public static T Get<T>(T tParameter)
            //where T:new() // has none parameter constructor
            //where T:class // referrence type constraint
            where T : struct // value type constraint
        {
            //T t = new T();
            //return t;

            //return null;
            return default(T);
            //return tParameter;
        }

        /// <summary>
        /// the relationship among multiple constraint is "and"
        /// </summary>
        /// <typeparam name="T"></typeparam>
        public static void Many<T>() where T : People, ISports, IWork, new() // multiple constraints
        {
        }

        private void Ling()
        {
            var list = new List<int>().Select(i => new
            {
                id = i,
                name = "Test" + i
            });

            foreach (var item in list)
            {
                Console.WriteLine(item.id);
                Console.WriteLine(item.name);
            }
        }
    }
}
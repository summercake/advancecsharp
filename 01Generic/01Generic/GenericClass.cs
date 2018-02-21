using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _01Generic
{
    // generic class
    public class GenericClass<T>
    {
        public void Show(T t)
        {
            Console.WriteLine(t);
        }

        public void GenericMethod<W, X, Y, Z>()
        {
        }

        public T Get(T t)
        {
            return t;
        }
    }

    // generic interface
    public interface IGet<T>
    {
    }

    // generic delegate
    public delegate void GetHandler<T>();

    // Generic class inherit
    public class ChildClass<T> : GenericClass<T>, IGet<T>
    {
    }

    public class ChildClass : GenericClass<int>, IGet<string>
    {
    }

    public class ChildClass<T, W> : GenericClass<T>, IGet<W>
    {
    }

    public class Parent
    {
        public Parent(){}
        public Parent(string name)
        {
        }
    }

    public class Child : Parent
    {
        public Child():base()
        {

        }
        public Child(string name) : base(name)
        {
        }
    }
}
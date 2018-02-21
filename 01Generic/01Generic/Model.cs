using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _01Generic
{
    public interface ISports
    {
        void Pingpage();

    }

    public interface IWork
    {
        void Pingpage();

    }

    public class People
    {
        public int Id { get; set; }
        public string Name { get; set; }
    }

    public class Chinese : People, ISports
    {
        public string Tradition { get; set; }

        public void SayHi()
        {
            Console.WriteLine("Im Chinese");
        }

        public void Pingpage()
        {
            Console.WriteLine("Chinese Play Pinpang");
        }
    }

    public class Hubei : Chinese
    {
        public string Changejiang { get; set; }

        public void Majiang()
        {
            Console.WriteLine("Hubei play Majiang");
        }
    }

    public class Japanese:ISports
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public void Pingpage()
        {
            Console.WriteLine("Japanese play PingPang");
        }
    }
}
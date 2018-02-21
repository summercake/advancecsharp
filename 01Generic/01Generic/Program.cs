using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _01Generic
{
    class Program
    {
        static void Main(string[] args)
        {
            try
            {
                Console.WriteLine("Welcome to Advance CSharp Course");
                int iValue = 123;
                string sValue = "456";
                DateTime dtValue = DateTime.Now;
                Console.WriteLine("==========================================================");
                Console.WriteLine("===================== Normal =============================");
                Console.WriteLine("==========================================================");
                CommonMethod.ShowInt(iValue);
                CommonMethod.ShowString(sValue);
                CommonMethod.ShowDateTime(dtValue);
                Console.WriteLine("==========================================================");
                Console.WriteLine("===================== Object =============================");
                Console.WriteLine("==========================================================");
                CommonMethod.ShowObject(iValue);
                CommonMethod.ShowObject(sValue);
                CommonMethod.ShowObject(dtValue);
                Console.WriteLine("==========================================================");
                Console.WriteLine("===================== Generic =============================");
                Console.WriteLine("==========================================================");
                GenericMethod.Show(iValue);
                GenericMethod.Show(sValue);
                GenericMethod.Show(dtValue);
                GenericMethod.Show<int>(iValue);
                GenericMethod.Show<string>(sValue);
                GenericMethod.Show<DateTime>(dtValue);

                #region Monitor

                {
                    Console.WriteLine("==========================================================");
                    Console.WriteLine("===================== Compare =============================");
                    Console.WriteLine("==========================================================");
                    long commonTime;
                    long objectTime;
                    long genericTime;
                    {
                        Stopwatch stopwatch = new Stopwatch();
                        stopwatch.Start();
                        for (int i = 0; i < 100000000; i++)
                        {
                            ShowCommon(iValue);
                        }

                        stopwatch.Stop();
                        commonTime = stopwatch.ElapsedMilliseconds;
                    }
                    {
                        Stopwatch stopwatch = new Stopwatch();
                        stopwatch.Start();
                        for (int i = 0; i < 100000000; i++)
                        {
                            ShowObject(iValue);
                        }

                        stopwatch.Stop();
                        objectTime = stopwatch.ElapsedMilliseconds;
                    }
                    {
                        Stopwatch stopwatch = new Stopwatch();
                        stopwatch.Start();
                        for (int i = 0; i < 100000000; i++)
                        {
                            ShowGeneric(iValue);
                        }

                        stopwatch.Stop();
                        genericTime = stopwatch.ElapsedMilliseconds;
                    }
                    Console.WriteLine("common Time = {0}, objectTime = {1}, genericTime = {2}", commonTime, objectTime,
                        genericTime);
                }

                #endregion

                Console.WriteLine("==========================================================");
                Console.WriteLine("===================== Model =============================");
                Console.WriteLine("==========================================================");

                People people = new People()
                {
                    Id = 12,
                    Name = "People"
                };
                Constraint.Show<People>(people);
                Chinese chinese = new Chinese()
                {
                    Id = 123,
                    Name = "Chinese"
                };
                Constraint.Show<Chinese>(chinese);
                Japanese japanese = new Japanese()
                {
                    Id = 1234,
                    Name = "japanese"
                };
                //Constraint.Show<Japanese>(japanese); // This will be error

                Parent parent = new Child();

                

                Console.ReadKey();
            }
            catch (Exception e)
            {
                Console.WriteLine(e.Message);
                throw;
            }
        }

        private static void ShowCommon(int iParameter)
        {
        }

        private static void ShowObject(object oParameter)
        {
        }

        private static void ShowGeneric<T>(T tParameter)
        {
        }
    }
}
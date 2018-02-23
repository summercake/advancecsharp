using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using System.Text;
using System.Threading.Tasks; // reflection namespace
using DB.Interface;
using DB.SqlServer;
using Model;


namespace _02Reflection
{
    public class Program
    {
        static void Main(string[] args)
        {
            try
            {
                Console.WriteLine("02 Reflection");

                #region Common

                //{
                //    IDBHelper dbHelper = new DBHelper();
                //    dbHelper.Query();
                //}

                #endregion

                #region Reflection

                //{
                //    Console.WriteLine();
                //    Console.WriteLine("============================================================");
                //    Assembly assembly1 = Assembly.Load("DB.SqlServer");
                //    // LoadFile can not load dependencies
                //    Assembly assembly2 =
                //        Assembly.LoadFile(
                //            @"D:\VS2017Projects\AdvanveCSharp\02Reflection\\02Reflection\bin\Debug\DB.SqlServer.dll");
                //    Assembly assembly3 = Assembly.LoadFrom("DB.SqlServer.dll");
                //    Assembly assembly4 =
                //        Assembly.LoadFrom(
                //            @"D:\VS2017Projects\AdvanveCSharp\02Reflection\\02Reflection\bin\Debug\DB.SqlServer.dll");
                //    foreach (var item in assembly1.GetModules())
                //    {
                //        Console.WriteLine(item.Name);
                //    }

                //    foreach (var type in assembly1.GetTypes())
                //    {
                //        Console.WriteLine();
                //        Console.WriteLine("*******************************{0}****************************************",
                //            type.Name);
                //        Console.WriteLine(type.Name);
                //        Console.WriteLine("================== Constructors ==========================================");
                //        foreach (var item in type.GetConstructors())
                //        {
                //            Console.WriteLine(item.Name);
                //        }

                //        Console.WriteLine("==================== Methods ========================================");
                //        foreach (var item in type.GetMethods())
                //        {
                //            Console.WriteLine(item.Name);
                //        }

                //        Console.WriteLine("===================== Fields =======================================");
                //        foreach (var item in type.GetFields())
                //        {
                //            Console.WriteLine(item.Name);
                //        }

                //        Console.WriteLine("===================== Properties =======================================");
                //        foreach (var item in type.GetProperties())
                //        {
                //            Console.WriteLine(item.Name);
                //        }

                //        Console.WriteLine("====================== Attributes ======================================");
                //        foreach (var item in type.GetCustomAttributes())
                //        {
                //            Console.WriteLine(item.ToString());
                //        }
                //    }
                //}

                #endregion

                #region Application

                {
                    Console.WriteLine();
                    Console.WriteLine("==================================================================");
                    Console.WriteLine("==================================================================");
                    Console.WriteLine("==================================================================");

                    // 1. Load dll
                    Assembly assembly = Assembly.Load("DB.SqlServer");
                    // 2. Get Type Info
                    Type typeHelper = assembly.GetType("DB.SqlServer.DBHelper");
                    // 3. Create Instance
                    object oDBHelper = Activator.CreateInstance(typeHelper);
                    // 4. Change Type to original
                    //((DBHelper) oDBHelper).Query();
                    {
                        IDBHelper dbHelper = (IDBHelper) oDBHelper;
                        dbHelper.Query();
                    }
                    {
                        // SimpleFactory + config files + reflection == IOC
                        IDBHelper dbHelper = SimpleFactory.CreateDbHelper();
                        dbHelper.Query();
                    }
                }
                {
                    // destroy singleton
                    Assembly assembly = Assembly.Load("DB.SqlServer");
                    Type typeHelper = assembly.GetType("DB.SqlServer.Singleton");
                    object oDBHelper1 = Activator.CreateInstance(typeHelper, true);
                    object oDBHelper2 = Activator.CreateInstance(typeHelper, true);
                    object oDBHelper3 = Activator.CreateInstance(typeHelper, true);
                    object oDBHelper4 = Activator.CreateInstance(typeHelper, true);
                }
                {
                    // create generic instance
                    Assembly assembly = Assembly.Load("DB.SqlServer");
                    Type typeHelper = assembly.GetType("DB.SqlServer.GenericClass`3");
                    Type type = typeHelper.MakeGenericType(typeof(Program), typeof(int), typeof(Exception));
                    object oDBHelper = Activator.CreateInstance(type);
                }
                {
                    // create generic instance
                    Assembly assembly = Assembly.Load("DB.SqlServer");
                    Type typeHelper = assembly.GetType("DB.SqlServer.ReflectionTest");
                    object oDBHelper = Activator.CreateInstance(typeHelper);
                }

                #endregion

                #region Reflection call instance, static, overwrite, private method

                {
                    Console.WriteLine("======================================================================");
                    Assembly assembly = Assembly.Load("DB.SqlServer");
                    Type typeTest = assembly.GetType("DB.SqlServer.ReflectionTest");
                    object oTest = Activator.CreateInstance(typeTest);
                    object oTest1 = Activator.CreateInstance(typeTest, new object[] {"jack"});
                    object oTest2 = Activator.CreateInstance(typeTest, new object[] {112});
                    {
                        MethodInfo method = typeTest.GetMethod("Show1"); // call show1
                        method.Invoke(oTest, null);
                    }
                    {
                        MethodInfo method = typeTest.GetMethod("Show2"); // call show2
                        method.Invoke(oTest, new object[] {123});
                    }
                    {
                        MethodInfo method = typeTest.GetMethod("Show3", new Type[] { }); // no parameter show3
                        method.Invoke(oTest, null);
                    }
                    {
                        MethodInfo method =
                            typeTest.GetMethod("Show3", new Type[] {typeof(int)}); // int type parameter show3
                        method.Invoke(oTest, new object[] {123});
                    }
                    {
                        MethodInfo method =
                            typeTest.GetMethod("Show3", new Type[] {typeof(string)}); // string type parameter show3
                        method.Invoke(oTest, new object[] {"nancy"});
                    }
                    {
                        MethodInfo method =
                            typeTest.GetMethod("Show3",
                                new Type[] {typeof(int), typeof(string)}); // int and string type parameter show3
                        method.Invoke(oTest, new object[] {123, "john"});
                    }
                    {
                        MethodInfo method =
                            typeTest.GetMethod("Show4",
                                BindingFlags.Instance | BindingFlags.NonPublic); // call private show4
                        method.Invoke(oTest, new object[] {"john"});
                    }
                    {
                        MethodInfo method = typeTest.GetMethod("ShowStatic"); // call static method
                        method.Invoke(oTest, new object[] {"mike"});
                        method.Invoke(null, new object[] {"mike"});
                    }
                }

                #endregion

                #region Reflection get and set properities

                {
                    Console.WriteLine("========================================================");
                    People people = new People();
                    people.Id = 123;
                    people.Name = "Jack";
                    Console.WriteLine("id={0}, name = {1}", people.Id, people.Name);
                    Console.WriteLine("========================================================");

                    Type type = typeof(People);
                    object oPeople = Activator.CreateInstance(type);
                    foreach (var item in type.GetFields())
                    {
                        Console.WriteLine("{0}={1}", item.Name, item.GetValue(oPeople));
                    }

                    foreach (var item in type.GetProperties())
                    {
                        if (item.Name == "Id")
                        {
                            item.SetValue(oPeople, 547); // set value
                        }
                        else if (item.Name == "Name")
                        {
                            item.SetValue(oPeople, "Jack"); // set value
                        }
                        Console.WriteLine("{0}={1}", item.Name, item.GetValue(oPeople)); // get value
                    }
                }

                #endregion

                Console.Read();
            }
            catch (Exception e)
            {
                Console.WriteLine(e.Message);
                throw;
            }
        }
    }
}
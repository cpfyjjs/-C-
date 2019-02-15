using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _11泛型
{
    interface IMyIfc<T>
    {
        T ReturnIt(T value);
    }

    class Class1 : IMyIfc<int>, IMyIfc<string>
    {
        public int ReturnIt(int value)
        {
            return value;
        }

        public string ReturnIt(string value)
        {
            return value;
        }
    }

    #region 协变
    // 尽管Dog是Animal的派生类，但是委托Factory<Dog>没有从Factory<Animal>派生
    class Animal    //基类
    {
        public int legs = 4;
    }

    class Dog:Animal    //派生类
    {

    }

    delegate T Factory<out T>();

    partial class Program
    {
        static Dog MakeDog()    // 符合Factory委托的fangfa
        {
            return new Dog();
        }

        static void Main()
        {
            Factory<Dog> dogMake = MakeDog;
            Factory<Animal> animalMake = dogMake;

            Console.WriteLine(animalMake().legs.ToString());
        }
    }


    #endregion
}

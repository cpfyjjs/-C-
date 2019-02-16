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
        public string Name;
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

        static void Main04()
        {
            Factory<Dog> dogMake = MakeDog;
            Factory<Animal> animalMake = dogMake;

            Console.WriteLine(animalMake().legs.ToString());
        }
    }
    #endregion

    #region 逆变
    partial class Program
    {
        delegate void Action1<in T>(T a);

        static void ActOnAnimal(Animal a){
            Console.WriteLine(a.legs);
        }

        static void Main05()
        {
            Action1<Animal> act1 = ActOnAnimal;
            act1(new Dog());

            Action1<Dog> dog1 = act1;
            dog1(new Dog());
        }
    }

    #endregion

    #region 接口协变
    interface IMyIfc1<out T>
    {
        T GetFirst();
    }

    class SimpleReturn<T> : IMyIfc1<T>
    {
        public T[] items = new T[2];
        public T GetFirst()
        {
            return items[0];
        }
    }

    partial class Program
    {
        static void DoSomething(IMyIfc1<Animal> returner)
        {
            Console.WriteLine(returner.GetFirst().Name);
        }

        static void Main06()
        {
            // 接口协变
            SimpleReturn<Dog> dogReturner = new SimpleReturn<Dog>();
            dogReturner.items[0] = new Dog() { Name = "Avonlea" };
            IMyIfc1<Animal> animalReturner = dogReturner;
            DoSomething(dogReturner);
        }
    }
    #endregion
}

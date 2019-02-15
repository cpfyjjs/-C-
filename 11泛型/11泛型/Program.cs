using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _11泛型
{
    partial class Program
    {
        static void Main01(string[] args)
        {
            MyStack<int> stakInt = new MyStack<int>();
            stakInt.Push(1);
            stakInt.Push(2);
            stakInt.Push(4);
            stakInt.Push(5);
            stakInt.Print();
            stakInt.Pop();
            stakInt.Print();
        }
        
        
    }

    class MyStack<T>
    {
        T[] StackArray;
        int StackPoint = 0;

        const int MaxStark = 10;

        public MyStack()
        {
            StackArray = new T[MaxStark];
        }

        bool IsStackFull
        {
            get
            {
                return StackPoint >= MaxStark;
            }
        }

        bool IsEmpty
        {
            get
            {
                return StackPoint <= 0;
            }
        }

        public void Push(T x)
        {
            if (!IsStackFull)
            {
                StackArray[StackPoint++] = x;
            }
        }

        public T Pop()
        {
            return (!IsEmpty) ? StackArray[--StackPoint] : StackArray[0];
        }

        public void Print()
        {
            for (int i = StackPoint - 1; i >= 0; i--)
            {
                Console.WriteLine(" vlalue : {0}", StackArray[i]);
            }
        }
    }

    class Simple
    {
        // 泛型方法
        static public void ReverseAndPrint<T>(T[] arr)
        {
            Array.Reverse(arr);
            foreach(T item in arr)
            {
                Console.Write("{0},", item.ToString());
            }
            Console.WriteLine("");
        }
    }


    #region 扩展方法和泛型类
    static class ExtendHoder
    {
        public static void Print<T>(this Holder<T> h)
        {
            T[] vals = h.GetValues();
            Console.WriteLine("{0},{1},{2}", vals[0], vals[1], vals[2]);
        }
    }

    class Holder<T>
    {
        T[] vals = new T[3];
        public Holder(T v0,T v1, T v2)
        {
            vals[0] = v0;
            vals[1] = v1;
            vals[2] = v2;
        }

        public T[] GetValues()
        {
            return this.vals;
        }
    }

    partial class Program
    {
        static void Main()
        {
            var intHolder = new Holder<int>(1, 3, 5);
            intHolder.Print();
        }

    }
    #endregion

    #region 泛型结构


    #endregion

}

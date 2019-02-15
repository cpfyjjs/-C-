using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _11泛型
{
    class Program
    {
        static void Main(string[] args)
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
}

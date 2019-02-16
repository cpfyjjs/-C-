using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Runtime.CompilerServices;
using System.Reflection;

namespace _24反射和特性
{
    partial class Program
    {
        public static void MyTrace(string message,
                [CallerFilePath] string fileName="",
                [CallerLineNumber] int lineNumber=0,
                [CallerMemberName] string callingMember="")
        {
            Console.WriteLine("FileName ：{0}",fileName);
            Console.WriteLine("LineNumber ：{0}",lineNumber);
            Console.WriteLine("CallingMember ：{0}",callingMember);
            Console.WriteLine("Message ：{0}",message);

            }
        static void Main01(string[] args)
        {
            MyTrace("Simple");
        }
    }

    #region 获取Type对象
    class BaseClass
    {
        public int BaseField = 0;
    }

    class DerivedClass : BaseClass
    {
        public int DerivedField = 0;
    }

    partial class Program
    {
        static void Main01()
        {
            var bc = new BaseClass();
            var dc = new DerivedClass();

            BaseClass[] bca = new BaseClass[] { bc, dc };

            foreach(var v in bca)
            {
                Type t = v.GetType();
                Console.WriteLine("Object type : {0}", t.Name);

                FieldInfo[] fi = t.GetFields();
                foreach(var f in fi)
                {
                    Console.WriteLine("    Filed : {0}", f.Name);
                }
                Console.WriteLine();
                
            }
        }

        static void Main()
        {
            Type tdc = typeof(DerivedClass);
            Console.WriteLine("Object name : {0}", tdc.Name);

            FieldInfo[] fi = tdc.GetFields();
            foreach(var f in fi)
            {
                Console.WriteLine("    Field : {0}", f.Name);
            }
            
        }
    }

    #endregion
}

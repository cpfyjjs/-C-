using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Runtime.CompilerServices;

namespace _24反射和特性
{
    class Program
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
        static void Main(string[] args)
        {
            MyTrace("Simple");
        }
    }
}

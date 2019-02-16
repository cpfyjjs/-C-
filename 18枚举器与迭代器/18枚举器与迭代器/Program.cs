using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _18枚举器与迭代器
{
    partial class Program
    {
        static void Main01(string[] args)
        {
            Spectrum spe = new Spectrum();
            foreach(var color in spe)
            {
                Console.WriteLine(color);
            }
    
        }
    }

    class ColorEnumerator : IEnumerator
    {
        string[] _colors;
        int _position = -1;

        public ColorEnumerator(string[] theColors)
        {
            this._colors = new string[theColors.Length];
            for (var i = 0; i < theColors.Length; i++)
            {
                this._colors[i] = theColors[i];
            }
        }

        public object Current
        {
            get
            {
                if (this._position == -1 || this._position >= this._colors.Length)
                {
                    throw new InvalidOperationException();
                }
                return this._colors[this._position];
            }
        }

        public bool MoveNext()
        {
            if(this._position < this._colors.Length - 1)
            {
                this._position++;
                return true;
            }
            else
            {
                return false;
            }
        }

        public void Reset()
        {
            this._position = -1;
        }
    }

    class Spectrum : IEnumerable
    {
        string[] Colors = { "violet", "blue", "cyan", "green", "yellow", "orange", "red" };

        public IEnumerator GetEnumerator()
        {
            return new ColorEnumerator(this.Colors);
        }
    }

    #region 使用迭代器来创建枚举器
    class Myclass
    {
        public IEnumerator<string> GetEnumerator()
        {
            return BlackAndWhite();
        }

        private IEnumerator<string> BlackAndWhite()
        {
            yield return "black";
            yield return "gray";
            yield return "white";
        }
    }

    partial class Program
    {
        static void Main02()
        {
            Myclass mc = new Myclass();
            foreach(var shade in mc)
            {
                Console.WriteLine(shade);
            }
        }
    }
    #endregion


    #region 产生多个可以枚举

    class Spectrum1
    {
        string[] Colors = {"violet","blue","cyan","green","yellow","orange","red"};

        /// <summary>
        /// 
        /// </summary>
        /// <returns></returns>
        public IEnumerable<string> UVtoIR()
        {
            for (int i = 0; i < this.Colors.Length; i++)
            {
                yield return this.Colors[i];
            }
        }

        public IEnumerable<string> IRtoUV()
        {
            for (int i = this.Colors.Length - 1; i >= 0; i--)
            {
                yield return this.Colors[i];
            }
        }
    }
    #endregion


    #region  将迭代器作为属性
    class Specturm2
    {
        bool _listFormUVtoIR;
        string[] Colors = { "violet", "blue", "cyan", "green", "yellow", "orange", "red" };

        public Specturm2(bool listFormUVtoIR)
        {
            this._listFormUVtoIR = listFormUVtoIR;
        }

        public IEnumerator<string> GetEnumerator()
        {
            return this._listFormUVtoIR ? UVtoIR : IRtoUV;
        }

        public IEnumerator<string> UVtoIR
        {
            get
            {
                for(var i=0;i<this.Colors.Length; i++)
                {
                    yield return this.Colors[i];
                }
            }
        }

        public IEnumerator<string> IRtoUV
        {
            get
            {
                for(var i = this.Colors.Length - 1; i >= 0; i--)
                {
                    yield return this.Colors[i];
                }
            }
        }
    }

    partial class Program
    {
        static void Main04()
        {
            Specturm2 startUV = new Specturm2(true);
            Specturm2 startIR = new Specturm2(false);

            foreach(var color in startUV)
            {
                Console.Write("{0}, ", color);
            }
            Console.WriteLine();

            foreach(var color in startIR)
            {
                Console.Write("{0}, ", color);
            }
            Console.WriteLine();
        }
    }

    #endregion
}

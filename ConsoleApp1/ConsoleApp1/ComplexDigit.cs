using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ConsoleApp1
{
    //класс комплексных чисел
    internal class ComplexDigit
    {
        private double Real;
        private double Imaginary;

        public ComplexDigit(double Real = 0, double Imaginary = 0)
        {
            this.Real = Real;
            this.Imaginary = Imaginary;
        }

        //возврат вещественной и мнимой частей
        public double RealPart() { return Real; }
        public double ImaginaryPart() { return Imaginary; }

        //сложение
        public ComplexDigit Add(ComplexDigit cd)
        {
            ComplexDigit answer = new ComplexDigit();
            answer.Real = this.Real + cd.Real;
            answer.Imaginary = this.Imaginary + cd.Imaginary;
            return answer;
        }

        //умножение
        public ComplexDigit Multiply(ComplexDigit cd)
        {
            ComplexDigit answer = new ComplexDigit();
            answer.Real = this.Real * cd.Real - this.Imaginary * cd.Imaginary;
            answer.Imaginary = this.Real * cd.Imaginary + this.Imaginary * cd.Real;
            return answer;
        }

        //вычитание
        public ComplexDigit Difference(ComplexDigit cd)
        {
            ComplexDigit answer = new ComplexDigit();
            answer.Real = this.Real - cd.Real;
            answer.Imaginary = this.Imaginary - cd.Imaginary;
            return answer;
        }

        //деление
        public ComplexDigit Divide(ComplexDigit cd)
        {
            ComplexDigit answer = new ComplexDigit();
            answer.Real = (this.Real * cd.Real + this.Imaginary * cd.Imaginary) / (Math.Pow(cd.Real, 2) + Math.Pow(cd.Imaginary, 2));
            answer.Imaginary = (this.Imaginary * cd.Real - this.Real * cd.Imaginary) / (Math.Pow(cd.Real, 2) + Math.Pow(cd.Imaginary, 2));
            return answer;
        }

        //нахождение модуля
        public double FindModule()
        {
            return Math.Sqrt(Math.Pow(this.Real, 2) + Math.Pow(this.Imaginary, 2));
        }


        //нахождения аргумента 
        public double FindArgument()
        {
            if (this.Real > 0)
            {
                return Math.Tan(this.Imaginary / this.Real);
            }
            else if (this.Real < 0 && this.Imaginary >= 0)
            {
                return Math.Tan(this.Imaginary / this.Real) + Math.PI;
            }
            else if (this.Real < 0 && this.Imaginary < 0)
            {
                return Math.Tan(this.Imaginary / this.Real) - Math.PI;
            }
            else if (this.Real == 0 && this.Imaginary > 0)
            {
                return Math.PI / 2;
            }
            else if (this.Real == 0 && this.Imaginary < 0)
            {
                return Math.PI / (-2);
            }
            else
            {
                return 0;
            }
        }
    }
}

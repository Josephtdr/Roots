using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Numerical_Methods__Roots_ {
    class Program {
        static void Main(string[] args) {
            Rearrangement_Method(2, 0, 20, g);
            Newton_Raphson_Method(2, 0, 20, f, fprime);
            Secant_Method(2, 4, 0, 20, f);
            Binomial_Sort(2, 4, 0, 20, f);
            Method_of_False_Position(2, 4, 0, 20, f);
            Console.ReadKey();
        }

        //Secant Method
        static void Secant_Method(double Xn_2, double Xn_1, int iteration, int limit, Func<double, double> F) { 
            if (iteration == 0) Console.WriteLine("Secant Method Method:");
            double xn = Xn_1 - (F(Xn_1) * ((Xn_1 - Xn_2) / (F(Xn_1) - F(Xn_2))));
            Console.WriteLine("x{0,-3} = {1}", iteration+2, xn);
            if (iteration < limit)
                Secant_Method(Xn_1, xn, iteration + 1, limit, F);
        }
        //Method of False Position Method
        static void Method_of_False_Position(double Xn_2, double Xn_1, int iteration, int limit, Func<double, double> F) {
            if (iteration == 0) Console.WriteLine("Method of False Position Method:");
            double xn = Xn_1 - (F(Xn_1) * ((Xn_1 - Xn_2) / (F(Xn_1) - F(Xn_2))));
            Console.WriteLine("x{0,-3} = {1}", iteration + 2, xn);
            if (iteration < limit) 
                if (Xn_1 * xn > 0) 
                    Method_of_False_Position(Xn_2, xn, iteration + 1, limit, F);
                else
                    Method_of_False_Position(Xn_1, xn, iteration + 1, limit, F);
        }
        //Newton Raphson Method
        //equations
        static double f(double x) {
            return (Math.Pow(x, 2) + ((Math.E - Math.PI) * x) - Math.E * Math.PI);
        }
        static double fprime(double x) {
            return ((2 * x + (Math.E - Math.PI)));
        }
        //method
        static void Newton_Raphson_Method(double x, int iteration, int limit, Func<double, double> F, Func<double, double> FPRIME) {
            if (iteration == 0) Console.WriteLine("Newton Raphson Method Method:");
            double xnplus1 = x - (F(x) / FPRIME(x));
            Console.WriteLine("x{0,-3} = {1}", iteration, x);
            if (iteration < limit)
                Newton_Raphson_Method(xnplus1, iteration + 1, limit, F, FPRIME);
        }
        //Rearagment Method
        //equations
        static double g(double x) {
            return Math.Pow(((-Math.E + Math.PI) * x) + Math.E * Math.PI, 1d / 2d);
        }
        //method
        static void Rearrangement_Method(double x, int iteration, int limit, Func<double, double> G) {
            if (iteration == 0) Console.WriteLine("Rearrangement Method:");
            Console.WriteLine("x{0,-3} = {1}", iteration, x);
            if (iteration < limit)
                Rearrangement_Method(G(x), iteration + 1, limit, G);
        }
        //Binomial Sort
        //method
        static void Binomial_Sort(double x1, double x2, int  iteration, int limit, Func<double, double> F) {
            if (iteration == 0) Console.WriteLine("Binomial Sort:");
            double difin10thx = x1 > x2 ? (x1 - x2) / 10 : (x2 - x1) / 10;
            Console.WriteLine("x{0,-3} = {1} +- {2}", iteration, ((x1 + x2) / 2), (difin10thx * 5));
            for (int i = 0; i < 10; i++) {
                if(iteration < limit && F(x1 + (difin10thx * i)) * F(x1 + (difin10thx * (i + 1))) < 0) {  
                        Binomial_Sort(x1 + (difin10thx * i), x1 + (difin10thx * (i + 1)), iteration + 1, limit, F);
                }
            } 
        }
    }
}

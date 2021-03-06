﻿using System;
using System.Threading;

namespace ClassLibrary
{
    public class Calculator 
    {
        private readonly ICalculatorDependency dependency;

        public Calculator(ICalculatorDependency dependency)
        {
            this.dependency = dependency;
        }

        public double Divide(double a, double b)
        {
            if(b == 0)
            {
                throw new ArgumentException();
            }

            var res = a / b;
            return res;
        }

        public double Sum(double firstElement, double secondElement)
        {
            double sum = firstElement + secondElement;

            if (sum > 5)
            {
                return 5;
            }

            return sum;
        }
    }
}

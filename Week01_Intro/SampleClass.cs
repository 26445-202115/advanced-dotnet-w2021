using System;
using System.Collections.Generic;
using System.Text;

namespace Week01_Intro
{
    public class SampleClass
    {
        /// <summary>
        /// a method that returns the sum of two integers
        /// </summary>
        /// <param name="a">The first number to add</param>
        /// <param name="b">The second number to add</param>
        /// <returns></returns>
        public static int AddTwoNumbers(int a ,int b)
        {
            return a + b;
        }

        /// <summary>
        /// a method that returns the product of multiplying two integers
        /// </summary>
        /// <param name="a">The first number to add</param>
        /// <param name="b">The second number to add</param>
        /// <returns></returns>
        public static int MultiplyTwoNumbers(int a, int b)
        {
            return a * 2;
        }

        /// <summary>
        /// a method that returns the result of dividing two integers
        /// </summary>
        /// <param name="dividend">The first number to add</param>
        /// <param name="divisor">The second number to add</param>
        /// <returns></returns>
        /// <remarks>The divisor can't be zero</remarks>
        public static decimal DivideTwoNumbers(int dividend, int divisor)
        {
            if(divisor == 0)
            {
                throw new ArgumentException("Can't divide by zero!");
            }

            
            return decimal.Divide(dividend, divisor);
        }

    }
}

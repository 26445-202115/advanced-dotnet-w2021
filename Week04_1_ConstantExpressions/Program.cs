using System;
using System.Linq.Expressions;

namespace Week04_1_ConstantExpressions
{
    class Program
    {
        static void Main(string[] args)
        {
            // declare and initialize a constant expression
            // with the value "my value"
            var constantExpression = Expression.Constant("my value");

            // constant expressions can also hold integer values
            var constantIntegerExpression = Expression.Constant(5);

            // as well as null
            var constantNullExpression = Expression.Constant(null);

            // each of the constants expressions below
            // represent a single leaf in a tree structure
            var seven = Expression.Constant(7);
            var six = Expression.Constant(6);
            var three = Expression.Constant(3);

            Console.WriteLine(constantExpression);
            Console.WriteLine(constantIntegerExpression);
            Console.WriteLine(constantNullExpression);
            Console.WriteLine(seven);
            Console.WriteLine(six);
            Console.WriteLine(three);

            Console.ReadKey();
        }
    }
}

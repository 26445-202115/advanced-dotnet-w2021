using System;
using System.Linq.Expressions;

namespace Week04_2_BinaryExpressions
{
    class Program
    {
        static void Main(string[] args)
        {
            // declare and initialize the left parameter expression, represented as the variable x
            var leftParameterExpression = Expression.Parameter(typeof(int), "x");

            // declare and initialize the right parameter expression, represented as the variable y
            var rightParameterExpression = Expression.Parameter(typeof(int), "y");

            // combine the two parameter expressions into a binary expression with NodeType set to ExpressionType.Multiply 
            var binaryExpression = Expression.Multiply(leftParameterExpression, rightParameterExpression);
            
            //It is "roughly" the same like this
            //var binaryExpression = Expression.MakeBinary(ExpressionType.Multiply,leftParameterExpression, rightParameterExpression);


            // create a lambda expression using the binary expression, the left parameter expression, and the right parameter expression
            // passing 'leftParameterExpression' and 'rightParameterExpression' allows us to actually input values into our function
            var lambdaExpression = Expression.Lambda<Func<int, int, int>>(binaryExpression, leftParameterExpression, rightParameterExpression);

            //We can use the compiled expression directly as we have declared the types when building the expression
            var result = lambdaExpression.Compile()(7, 6);

            //If types are not know at compile time, we can use Expression.Lambda() instead
            var lambdaExpression2 = Expression.Lambda(binaryExpression, leftParameterExpression, rightParameterExpression);


            // In this case we need to use the DynamicInvoke() on the compiled expression.This will not check for any parameter type at compile time; might throw an error at run time if the wrong argument types are passed in.
            var result2 = lambdaExpression2.Compile().DynamicInvoke(7, 6);

            // print the result
            Console.WriteLine($"The expression represented as a string: {lambdaExpression}");

            Console.WriteLine($"The result with Compile(): {result}");
            Console.WriteLine($"The result with DynamicInvoke(): {result2}");

            // the below line is equivalent to the above code
            Expression<Func<int, int, int>> multiplyExpression = (x, y) => x * y;
            // compile and invoke the expression
            Console.WriteLine(multiplyExpression.Compile().Invoke(7, 6));
        }
    }
}

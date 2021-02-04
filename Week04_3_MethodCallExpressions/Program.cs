using System;
using System.Collections.Generic;
using System.Linq.Expressions;

namespace Week04_3_MethodCallExpressions
{
    class Program
    {
        static void Main(string[] args)
        {
            //EX1:  s.ToLower() >>>>   "Test".ToLower()


            var paramExpr = Expression.Parameter(typeof(string), "s");

            // parameter expression is the object we are calling the method on
            // the second parameter hold metadata about the given method we want to invoke
            // we are looking to invoke the ToLower method on the string object
            var instanceMethodCallExpr = Expression.Call(paramExpr, typeof(string).GetMethod("ToLower", Type.EmptyTypes));

            // convert the method call expression to a lambda expression
            // using the method call expression and the parameter expression
            // the method call expression represents the actual method we are invoking
            // the parameter expression represent the object we are actually calling for the given method
            var instanceLambdaExpr = Expression.Lambda(instanceMethodCallExpr, paramExpr);

            // the equivlant 'compile time' lambda expression is as follows
            // 's' - is our parameter expression
            // '=>' - is the lambda operator
            // 's.ToLower()' is the method call expression
            // s => s.ToLower()
            var compiledInstanceLambdaExpr = instanceLambdaExpr.Compile().DynamicInvoke("Test");

            Console.WriteLine($"The result of invoking the lambda expression representing ToLower() with the value 'Test': {compiledInstanceLambdaExpr}");

            //EX2: string.IsNullOrEmpty("Test String")

            // now we are going to invoke a static method as defined by a method call expression using a lambda expression

            //We don't need an instance parameter this time (this is a static mtehod call)
            var staticMethodCallExpr = Expression.Call(typeof(string).GetMethod("IsNullOrEmpty", new Type[] { typeof(string) }), new List<ParameterExpression> { paramExpr });

            // convert the static method call expression to a lambda expression
            var staticLambdaExpr = Expression.Lambda(staticMethodCallExpr, paramExpr);


            // invoke the lambda and pass a non-null and non-empty string
            var compiledStaticLambdaExpr = staticLambdaExpr.Compile().DynamicInvoke("This is not empty");
            Console.WriteLine($"The result of invoking the lambda expression representing IsNullOrEmpty with 'This is not empty': {compiledStaticLambdaExpr}");


            // invoke the lambda and pass the representation of a null object
            var compiledStaticLambdaExpr2 = staticLambdaExpr.Compile().DynamicInvoke(string.Empty);
            Console.WriteLine($"The result of invoking the lambda expression representing IsNullOrEmpty with string.Empty: {compiledStaticLambdaExpr2}");


            // invoke the lambda and pass an empty string
            var compiledStaticLambdaExpr3 = staticLambdaExpr.Compile().DynamicInvoke(Expression.Constant(null).Value);
            Console.WriteLine($"The result of invoking the lambda expression representing IsNullOrEmpty with null string object: {compiledStaticLambdaExpr3}");
        }
    }
}

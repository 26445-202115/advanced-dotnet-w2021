using System;
using System.Linq.Expressions;

namespace Week04_4_ExpressionVisitor
{
    class Program
    {
        static void Main(string[] args)
        {
			// declare and initialize a new expression that takes 1 string
			// and returns the result as a boolean
			Expression<Func<string, bool>> andAlsoExp = e => e.Length > 10 && e.StartsWith("A");
			Console.WriteLine($"Original Exp.: {andAlsoExp}");

			var compiledExpression = (Expression<Func<string, bool>>)andAlsoExp;
			var result = compiledExpression.Compile()("Apple");
			Console.WriteLine($"Calling the compiled original AndAlso expression with the word Apple: {result}");


			var andAlsoVisitor = new AndAlsoExpressionVisitor();
			// Use the visitor to visit the expression nodes to rewrite all the operators as OrElse
			var updatedExp = andAlsoVisitor.Visit(andAlsoExp);

			Console.WriteLine($"Updated Exp.: {updatedExp}");

			var modifiedCompiledExpression = (Expression<Func<string, bool>>)updatedExp;
			var modifiedResult = modifiedCompiledExpression.Compile()("Apple");
			Console.WriteLine($"Calling the compiled modified OrElse expression with the word Apple: {modifiedResult}");


            Console.WriteLine("\n");


			// declare and initialize a new expression that takes 3 doubles
			// and returns the result as a double

			// the first 3 arguments are the input parameters
			// and the last argument is the return type
			Expression<Func<double, double, double, double>> mathExpression = (a, b, c) => a + b - c;
			//var left = mathExpression.Body.;

			Console.WriteLine($"Original Math Expression: {mathExpression}");

			MathExpressionVisitor mathVisitor = new MathExpressionVisitor();
			// visit the math expression which rewrites all the operators to become 
			// multiplication operations
			var updatedMathExpression = mathVisitor.Visit(mathExpression);
			Console.WriteLine($"Updated Math Expression: {updatedMathExpression}");

		}
	}
}

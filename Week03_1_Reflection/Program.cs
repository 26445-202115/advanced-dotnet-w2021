﻿using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Reflection;

namespace Week03_1_Reflection
{
    class Program
    {
        static void Main(string[] args)
        {
            ConstructorInfoEx();
            MethodInfoEx();
            GetRequiredProperties();

            Console.WriteLine("Program complete");
            Console.ReadKey();

        }



        static void ConstructorInfoEx()
        {
            // using the typeof operator we can retrieve the 'Type object' for the given type
            // in our case, we are retrieving the type object for our Person class
            var type = typeof(Person);

            // the typeof operator can only be used on static types
            // meaning the type must be known at compile time
            // the following lines will cause an error
            var myInt = 5;
            //var typeofInt = typeof(myInt);

            // if we don't the type ahead of time, we cannot use the typeof operator
            // we have to use the GetType method
            Type intType = myInt.GetType();

            ConstructorInfo[] constructors = typeof(Person).GetConstructors();

            foreach (var constructor in constructors)
            {
                Console.WriteLine(constructor.Name);
            }

            // find all the public instance constructors on the person class
            constructors = typeof(Person).GetConstructors(BindingFlags.Instance | BindingFlags.Public);

            // for each constructor that does not have a parameter
            // invoke the constructor
            foreach (var constructor in constructors.Where(c => !c.GetParameters().Any()))
            {
                var instance = constructor.Invoke(null);
            }

            // find all the static constructors on the person class
            constructors = typeof(Person).GetConstructors(BindingFlags.Static);

        }

        static void MethodInfoEx()
        {
            // create a new instance of our person
            var person = new Person();

            // retrieve the type object for our person object
            var type = person.GetType();

            // find all the methods on the person class
            // that are public instance methods
            // we do this, by using the binding flags enum
            var methods = type.GetMethods(BindingFlags.Instance | BindingFlags.Public);

            // print out some metadata about the methods on the person class
            foreach (MethodInfo methodInfo in methods)
            {
                Console.Write(Environment.NewLine);

                // print the method name
                Console.WriteLine($"method name: {methodInfo.Name}");

                // print the method return type
                Console.WriteLine($"method return type: {methodInfo.ReturnType}");

                // print whether the method is generic
                Console.WriteLine($"method is is generic: {methodInfo.IsGenericMethod}");

                // print whether the method is abstract
                Console.WriteLine($"method is abstract: {methodInfo.IsAbstract}");

                Console.WriteLine($"Contains generic parameters: {methodInfo.ContainsGenericParameters}");
                Console.Write(Environment.NewLine);
            }

            foreach (var method in methods)
            {
                // if the method has only 1 parameter and the parameter is a string, invoke the method
                if (method.GetParameters().Count(c => c.ParameterType == typeof(string)) == 1)
                {
                    // invoke th method
                    // person - represents the object in which we are invoke the method
                    // the object array - represents the parameters passed to the method
                    method.Invoke(person, new object[] { "jane" });
                }
            }

            Console.WriteLine("The names of our person");

            foreach (var name in person.Names)
            {
                Console.WriteLine(name.Value);
            }


        }

        private static void GetRequiredProperties()
        {
            var allProps = typeof(Name).GetProperties();
            var requiredProps = typeof(Name).GetProperties().Where(p => p.GetCustomAttributes<RequiredAttribute>().Any());

            Console.WriteLine("All properties:");
            foreach (var item in allProps)
            {
                Console.WriteLine(item.Name);
            }

            Console.WriteLine("Required properties:");
            foreach (var item in requiredProps)
            {
                Console.WriteLine(item.Name);
            }
        }
    }

}

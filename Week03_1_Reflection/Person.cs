using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Text;

namespace Week03_1_Reflection
{
    public class Person
    {
        public List<Name> Names { get; set; }

        // define a static constructor
        static Person()
        {
        }

        // define the default constructor
        public Person()
        {
            this.Names = new List<Name>();
            Console.WriteLine("Default person constructor invoked");
        }

        // define a parameterized constructor
        public Person(NameType type, string value)
        {
            Console.WriteLine("Parameterized person constructor invoked");
        }

        public void AddName(string name)
        {
            this.AddName(new Name(NameType.FirstName, name));
        }

        public void AddName(Name name)
        {
            this.Names.Add(name);
        }

        public void DoOperation()
        {
            Console.WriteLine("The do operation method was called");
        }

    }

    public class Name
    {
        public Name()
        {

        }

        public Name(NameType type, string value)
        {
            this.Type = type;
            this.Value = value;
        }

        public NameType Type { get; set; }

        [Required]
        public string Value { get; set; }
    }

    public enum NameType
    {
        FirstName = 1,
        MiddleName = 2,
        LastName = 3
    }
}

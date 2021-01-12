using System;

namespace Week01_3_DebugEx
{
    class Program
    {
        static void Main(string[] args)
        {
            var assembly = typeof(Program).Assembly;

            // the code base is where the assembly code resides
            Console.WriteLine(assembly.CodeBase);

            // the location is the location on the disk where the assembly resides
            Console.WriteLine(assembly.Location);

            Console.WriteLine("printing defined types");
            // the exported types contain
            // ALL the types defined within an assembly
            foreach (var definedType in assembly.DefinedTypes)
            {
                Console.WriteLine(definedType.AssemblyQualifiedName);
            }

            Console.WriteLine("printing exported types");
            // the exported types contain
            // ALL THE PUBLIC TYPES defined within an assembly
            foreach (var exportedType in assembly.ExportedTypes)
            {
                Console.WriteLine(exportedType.AssemblyQualifiedName);
            }

            Console.WriteLine("printing entry point");

            Console.WriteLine(assembly.EntryPoint.Name);

            var stream = assembly.GetManifestResourceStream("Week1Examples.Resources.txt");

            Console.WriteLine("program complete");
            Console.ReadKey();
        }
    }

}


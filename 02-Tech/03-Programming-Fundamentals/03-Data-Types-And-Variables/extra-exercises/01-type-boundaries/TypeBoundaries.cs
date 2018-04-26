using System;
using System.Collections.Generic;

namespace _01_type_boundaries
{
    class TypeBoundaries
    {
        static private Dictionary<string, string> mapToSystemType = new Dictionary<string, string>()
        {
            ["byte"] = "Byte",
            ["sbyte"] = "SByte",
            ["int"] = "Int32",
            ["uint"] = "UInt32",
            ["long"] = "Int64"
        };
        static void Main()
        {
            var type = $"System.{mapToSystemType[Console.ReadLine().ToLower()]}";
            var max = Type.GetType(type).GetField("MaxValue");
            var min = Type.GetType(type).GetField("MinValue");
            Console.WriteLine(max.GetValue(null));
            Console.WriteLine(min.GetValue(null));
        }
    }
}

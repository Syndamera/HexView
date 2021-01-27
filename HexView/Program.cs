using System;

namespace HexView
{
    class Program
    {
        static void Main(string[] args)
        {
            int decimalNumber = 14;
            char hexChar;
            
            int value = 255;

            // use X to display in dec <> hex
            Console.WriteLine(value.ToString("X4") + "h");

            value = 0xAA;
            Console.WriteLine(value.ToString("X4") + "h");
        }
    }
}

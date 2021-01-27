using System;

namespace HexView
{
    class Program
    {
        // read in a decimal value
        // conversion table 0-9 & 10-16 = 0-9 & A-F by using switch?

        static void Main(string[] args)
        {
            int decimalNumber = 255;
            char hexChar;
            
            int value = 255;

            // use X to display in dec <> hex
            Console.WriteLine(value.ToString("X4") + "h");

            // decimal > hex
            Console.WriteLine(string.Format("{0:X4}", decimalNumber));

            string temp = DecToHex(15);
            Console.WriteLine("TESTING:" + temp);

            decimalNumber = HexToDec("FF");
            Console.WriteLine(decimalNumber);
        }

        public static int HexToDec(string value)
        {
            int result = 0;
            int count = value.Length - 1;

            for (int i = 0; i < value.Length; i++)
            {
                int decValue;
                switch (value[i])
                {
                    case 'A':
                        {
                            decValue = 10;
                        }
                        break;
                    case 'B':
                        {
                            decValue = 11;
                        }
                        break;
                    case 'C':
                        {
                            decValue = 12;
                        }
                        break;
                    case 'D':
                        {
                            decValue = 13;
                        }
                        break;
                    case 'E':
                        {
                            decValue = 14;
                        }
                        break;
                    case 'F':
                        {
                            decValue = 15;
                        }
                        break;
                    default:
                        {
                            decValue = -48 + (int)value[i]; // ASCII value for '0'
                        } break;
                }
                result += decValue * (int)Math.Pow(16, count);
                count--;
            }

            return result;
        }

        public static string DecToHex(int value)
        {
            string result = "";

            while(value != 0)
            {
                if ((value % 16) < 10)
                {
                    result = value % 16 + result;
                }
                else
                {
                    string hexChar = "";
                    switch (value % 16)
                    {
                        case 10:
                            {
                                hexChar = "A";
                            }
                            break;
                        case 11:
                            {
                                hexChar = "B";
                            }
                            break;
                        case 12:
                            {
                                hexChar = "C";
                            }
                            break;
                        case 13:
                            {
                                hexChar = "D";
                            }
                            break;
                        case 14:
                            {
                                hexChar = "E";
                            }
                            break;
                        case 15:
                            {
                                hexChar = "F";
                            }
                            break;
                    }
                    result = hexChar + result;
                }
                value /= 16;
            }

            return result;
        }
    }
}

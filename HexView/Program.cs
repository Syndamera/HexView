using System;
using System.Text;

namespace HexView
{
    class Program
    {
        // read in a decimal value
        // conversion table 0-9 & 10-16 = 0-9 & A-F by using switch?

        static void Main(string[] args)
        {
            int value = 255;
            
            Console.WriteLine("Enter a decimal number: ");
            int number = int.Parse(Console.ReadLine());

            if(number <= 65535)
            {
                string number2Hex = DecToHex(number);
                string appendedStr = LeftPadding(number2Hex);
                Console.WriteLine(appendedStr);
            }

            string temp = DecToHex(15);
            Console.WriteLine("DecToHex: " + temp);

            int decimalNumber = HexToDec("FFFF");
            Console.WriteLine("HexToDec: " + decimalNumber);

            DecToHex(value);
            Console.WriteLine("DecToHex: " + value);
        }

        public static string LeftPadding(string str)
        {
            // 2 % 4 = 0.5 remainder = 2
            // (lenght - remainder) "/ 4"
            int numberOfBits = 4;
            string appendedString = string.Empty;
            if (str.Length < numberOfBits)
            {
                int remainder = str.Length % numberOfBits;
                int zeroesToAppend = numberOfBits - remainder;
                // append 0 to string pos 0

                for(int i = 0; i < zeroesToAppend; i++)
                {
                    appendedString += "0";
                }
                appendedString += str;
                // append "h" to the end of the string array
                //appendedString += "h";
            }

            return appendedString;
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
            string result = string.Empty;

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

using System;
using System.Text;

namespace HexView
{
    class Program
    {
        static void Main(string[] args)
        {
            Console.Write("Enter a decimal number 0-{0:D}", UInt16.MaxValue + ": ");

            string input = Console.ReadLine();
            if(!string.IsNullOrEmpty(input))
            {
                // have to do a check that its a number and not characters
                int number = int.Parse(input);
                if (number <= UInt16.MaxValue && number > 0)
                {
                    string number2Hex = DecToHex(number);
                    string appendedStr = LeftPadding(number2Hex);
                    Console.WriteLine(number + "d " + "is " + appendedStr + "h");
                }
                else
                {
                    Console.WriteLine("ERROR: Your input is out of bounds.");
                }
            }
            else
            {
                Console.WriteLine("ERROR: No input entered.");
            }

            Console.Write("Enter a hexidecimal number 0000-FFFF: ");
            // have to check that we don't accept other characters than numbers
            // and A-F, lowercase or uppercase and convert lower to uppercase.
            input = Console.ReadLine().ToUpper();
            if(!string.IsNullOrEmpty(input))
            {
                int value = HexToDec(input);
                Console.WriteLine(input + "h is " + value +"d");
            }


            /*
            string temp = DecToHex(15);
            Console.WriteLine("DecToHex: " + temp);

            int decimalNumber = HexToDec("FFFF");
            Console.WriteLine("HexToDec: " + decimalNumber);

            DecToHex(value);
            Console.WriteLine("DecToHex: " + value);
            */
        }

        public static string LeftPadding(string str)
        {
            // 2 % 4 = 0.5 remainder = 2
            // (lenght - remainder) "/ 4"
            int numberOfBits = 4;
            string appendedStr = string.Empty;
            if (str.Length <= numberOfBits)
            {
                int remainder = str.Length % numberOfBits;
                int zeroesToAppend = numberOfBits - remainder;

                // Check that we have a remainder higer than 0
                // else we just return the str unchanged.
                if(remainder > 0)
                {
                    for (int i = 0; i < zeroesToAppend; i++)
                    {
                        // append 0 to the string array at pos 0
                        appendedStr += "0";
                    }
                }
                else
                {
                    return str;
                }

                appendedStr += str;
                // append "h" to the end of the string array
                //appendedString += "h";
            }

            return appendedStr;
        }

        public static int HexToDec(string str)
        {
            int result = 0;
            int count = str.Length - 1;

            for (int i = 0; i < str.Length; i++)
            {
                int decValue;
                switch (str[i])
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
                            decValue = -48 + (int)str[i]; // ASCII value for '0'
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

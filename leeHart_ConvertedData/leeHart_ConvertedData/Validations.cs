using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace leeHart_ConvertedData
{
    class Validations
    {
        public static int GetInt(string message = "Enter an integer :")
        {
            int validateInt = 0;
            string input = null;

            int w = 0;
            do
            {
                if (w == 1)

                {
                    message = $"Invalid Entry you must enter numbers " + message;

                }
                Console.Write( message);
                input = Console.ReadLine();
            } while (!Int32.TryParse(input, out validateInt));

            return validateInt;


        }
        public static int GetInt(int min, int max, string message = "Enter an Integer :")
        {
            int validateInt = 0;
            string input = null;

            int w = 0;
            do
            {
                if (w == 1)

                {
                    message = $"Invalid Entry you must enter numbers between {min} & {max} " + message;

                }
                Console.Write( message);
                input = Console.ReadLine();
                Int32.TryParse(input, out validateInt);
            } while ((!Int32.TryParse(input, out validateInt)) || ((validateInt < min || validateInt > max)));


            return validateInt;
        }
        public static double GetDouble(string message = "Enter an Double :")
        {
            double validateDouble = 0;
            string input = null;

            int w = 0;
            do
            {
                if (w == 1)

                {
                    message = $"Invalid Entry you must enter numbers " + message;

                }
                Console.Write("Invalid Entry \r\n"+ message);
                input = Console.ReadLine();
            } while (!double.TryParse(input, out validateDouble));

            return validateDouble;


        }
        public static double GetDouble(int min, int max, string message = "Enter an Double :")
        {
            double validateDouble = 0;
            string input = null;
            int w = 0;
            do
            {
                if (w == 1)

                {
                    message = $"Invalid Entry you must enter numbers between {min} & {max} " + message;

                }
                Console.Write(message);
                input = Console.ReadLine();
            } while ((!double.TryParse(input, out validateDouble)) || ((validateDouble < min || validateDouble > max)));


            return validateDouble;


        }
        public static decimal Getdecimal(string message = "Enter an Decimal :")
        {
            decimal validateDecimal = 0.00m;
            string input = null;

            int w = 0;
            do
            {
                if (w == 1)

                {
                    message = $"Invalid Entry you must enter numbers " + message;

                }
                Console.Write(message);
                input = Console.ReadLine();
            } while (!decimal.TryParse(input, out validateDecimal));

            return validateDecimal;


        }
        public static decimal Getdecimal(int min, int max, string message = "Enter an decimal :")
        {
            decimal validateDecimal = 0.00m;
            string input = null;
            int w = 0;
            do
            {
                if (w == 1)

                {
                    message = $"Numbers ONLY between {min} & {max} \r\nPlease Re Enter :" + message;

                }
                Console.Write(message);
                input = Console.ReadLine();
            } while ((!decimal.TryParse(input, out validateDecimal)) || ((validateDecimal < min || validateDecimal > max)));


            return validateDecimal;


        }

        public static bool GetBool(string message = "Enter Yes or No :")
        {

            bool answer = false;
            string input = null;
            bool needAValidResponse = true;
            int w = 0;
            while (needAValidResponse)
            { 
                
                    if (w == 1)

                    {
                        message = $"Invalid Response\r\nPlease Re Enter : YES OR NO \r\n" + message;

                    }
                    input = Validations.Words(message, 1, 1, false).ToLower();

                switch (input)
                {
                    case "yes":
                    case "y":
                    case "true":
                    case "t":
                        {

                            answer = true;
                            needAValidResponse = false;
                            
                        }
                        break;
                    case "no":
                    case "n":
                    case "false":
                    case "f":
                        {
                            answer = false;
                            needAValidResponse = false;
                            
                        }
                        break;
                    default : { needAValidResponse = true; } break;
                        



                }
                
                


            }
           
            return answer;
        }

        public static string Words(string message = "Please Enter the Name :", int max = 3, int min = 2, bool numbersInvalid = true)
        {
            
            bool x = false;
            
            
            string name;// = Console.ReadLine().Trim();

            string[] testArray;// = name.Split(' ').ToArray();
            
            int tester;

            int w = 0;
            do
            {
                if (w == 1)

                {
                    message = $"Invalid you need at least {min} words\r\n ex. First Last\r\n and no more than {max} words, numbers invalid is {numbersInvalid}\r\nPlease Re Enter :" + message;

                }
                w++;
                Console.Clear();
                x = false;
                Console.Write(message);
                name = Console.ReadLine().Trim();
                testArray = name.Split(' ').ToArray();
                if (testArray.Length > max)
                {x = true;}
                if (testArray.Length < min)
                { x = true;}
                else
                {
                    for (int r = 0; r < testArray.Length; r++)
                    {
                        foreach (char tests in testArray[r].ToCharArray())
                        {

                            if (numbersInvalid)
                            { 
                               if (int.TryParse(tests.ToString(), out tester))
                                { x = true; }
                            }
                            if (!char.IsLetterOrDigit(tests))
                            {
                                x = true;
                            }
                      
                        }
                    }
                }
            } while ( x );

                return name;
        }

        public string[] StringArray(int HowMany = 0,string message = "Please Enter Next Item")
        {
            string[] newArray = new string[HowMany];
            for(int i = 0 ; HowMany > i; i++)
            {
                newArray[i] = Validations.Words(message, 3, 1);

            }
            return newArray;
        }
        static public string GetResponse(string response, string match1, string match2)
        {
            bool runs = true;
            do
            {
                if (response == match1 || response == match2)
                {
                    return response;
                    
                }
                else
                {
                    response = Words($"Please Enter {match1} or {match2} : ",100,0,false).ToLower();
                }

            } while (runs);
            return response;
        }
      
    }
}

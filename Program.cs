using System;
using System.Linq;

namespace StringManipulationsAndAlgos
{
    class Program
    {
        static void Main(string[] args)
        {
            //ReverseString();
            //CheckForPallindrom();
            //CheckCountOfEachCharInString();
            //RemoveDuplicateCharFromString();
            //FindAllSubstrings();
            //CheckIfNumberIsPrime();
            //FindSumOfDigitsOfNumber();
            //FindAngleBetweenHourAndMinuteHand();
            FindSecondLargestNumberInArray(new int[] { 4, 6, 5, 10, 4, 9});
            Console.ReadLine();
        }

        static void FindSecondLargestNumberInArray(int[] input)
        {
            int highestNumber = input[0];
            int secondhighestNumber = input[0];

            for (int i = 0; i < input.Length; i++)
            {
                if(input[i] > highestNumber)
                {
                    secondhighestNumber = highestNumber;
                    highestNumber = input[i];
                }
                else if (input[i] > secondhighestNumber && input[i] < highestNumber)
                {
                    secondhighestNumber = input[i];
                }
            }

            Console.WriteLine($"Second Highest Number is {secondhighestNumber}");
        }

        static void FindAngleBetweenHourAndMinuteHand()
        {
            bool retry = false;
            do
            {
                int difference = 0;
                Console.WriteLine("Enter a time in hh.mm format");
                string input = Console.ReadLine();
                var timeFields = input.Split('.');
                int hour = Convert.ToInt16(timeFields[0]);
                int minute = Convert.ToInt16(timeFields[1]);

                var hourAngle = (hour * 30) + (minute * 30 / 60);
                var minuteAngle = minute * 6;
                difference = hourAngle - minuteAngle;

                if (difference > 180)
                {
                    difference = 360 - difference;
                }

                Console.WriteLine($"Difference between Hour and Minute hand is {difference}");

                Console.WriteLine("You wanna try again (y/n)?");
                var option = Console.ReadLine();
                if (option.ToLower() == "y")
                    retry = true;
            } while (retry);
        }

        static void FindSumOfDigitsOfNumber()
        {
            bool retry = false;
            do
            {
                Console.WriteLine("Enter a number");
                string input = Console.ReadLine();
                int number = 0;
                if (int.TryParse(input, out number))
                {
                    int sum = 0;
                    while(number > 0)
                    {
                        sum += number % 10;
                        number = number / 10;
                    }

                    Console.WriteLine($"Sum is {sum}");
                }
                else
                {
                    Console.WriteLine("Invalid input as a Number");
                }
                Console.WriteLine("You wanna try again (y/n)?");
                var option = Console.ReadLine();
                if (option.ToLower() == "y")
                    retry = true;
            } while (retry);
        }
        

        static void CheckIfNumberIsPrime()
        {
            bool retry = false;
            do
            {
                Console.WriteLine("Enter a number.");
                string input = Console.ReadLine();
                int number = 0;
                if (int.TryParse(input, out number))
                {
                    if (number == 1) Console.WriteLine("Not Prime");
                    else if (number == 2) Console.WriteLine("Prime");
                    else
                    {
                        int squareRoot = (int)Math.Sqrt(number);
                        bool isPrime = true;
                        for (int i = 3; i <= squareRoot; i++)
                        {
                            if (number % i > 0)
                            {
                                isPrime = false;
                                break;
                            }
                        }

                        if (isPrime)
                            Console.WriteLine("Prime");
                        else
                            Console.WriteLine("Non Prime");
                    }
                }
                else
                {
                    Console.WriteLine("only integers allowed.");
                }
                Console.WriteLine("Wanna try again y/n?");
                string selectedOption = Console.ReadLine();
                if (selectedOption.ToLower() == "y")
                    retry = true;
                else
                    retry = false;

            } while (retry);
        }

        static void FindAllSubstrings()
        {
            Console.WriteLine("Enter a string.");
            var input = Console.ReadLine().ToCharArray();

            for(int i = 0; i < (input.Length - 1); i++)
            {
                string temp = input[i].ToString();
                Console.WriteLine(temp);

                for (int j = i + 1; j > i && j < input.Length; j++ )
                {
                    temp = temp + input[j];
                    Console.WriteLine(temp);
                }
            }
        }

        static void RemoveDuplicateCharFromString()
        {
            Console.WriteLine("Enter a string.");
            string input = Console.ReadLine();
            var output = new string(input.Distinct().ToArray());
        }

        static void CheckCountOfEachCharInString()
        {
            Console.WriteLine("Enter a string.");
            string input = Console.ReadLine();

           var output = input.GroupBy(char.ToLower).Select(x => new {character = x.Key.ToString(), count = x.Count() });            
        }

        static void CheckForPallindrom()
        {
            bool isPalindrome = true;
            Console.WriteLine("Enter string to Check for Pallindrome.");
            char[] input = Console.ReadLine().ToCharArray();
            if (input.Length == 1)
            {
                Console.WriteLine("just 1 character !!");

            }
            else
            {
                for (int i = 0, j = input.Length - 1; i < j; i++, j--)
                {
                    if (input[i] == input[j])
                        continue;
                    else
                    {
                        isPalindrome = false;
                        break;
                    }
                }
            }

            if (isPalindrome)
                Console.WriteLine("Yes Pallindrome");
            else
                Console.WriteLine("oops Not a Pallindrome");
        }

        static void ReverseString()
        {
            Console.WriteLine("Enter string to reverse.");
            char[] input = Console.ReadLine().ToCharArray();
            char[] output = new char[input.Length];
            for (int i = 0, j = input.Length - 1; i < j; i++, j--)
            {
                output[i] = input[j];
                output[j] = input[i];
            }
            Console.WriteLine(output);
        }
    }



}

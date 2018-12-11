using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ConsoleApplication2
{
    class Program
    {
        static void Main(string[] args)
        {
            playMasterMind();
        }

        private static void playMasterMind()
        {
            while (true)
            {
                Random rndm = new Random();
                int rndmNumber = Convert.ToInt32(rndm.Next(1, 6).ToString() +
                                    rndm.Next(1, 6).ToString() + rndm.Next(1, 6).ToString() +
                                    rndm.Next(1, 6).ToString());
                Console.WriteLine("Guess the number ****. Number contains digits from 1 to 6 only.You have 10 chances to guess.");
                List<int> numlist = new List<int>();
                int rem = rndmNumber;
                while (rem != 0)
                {
                    numlist.Add(rem % 10);
                    rem = rem / 10;
                }

                const int maxRetry = 2;
                int TryCount = 1;
                while (TryCount <= maxRetry)
                {
                    Console.WriteLine("enter your 4 digit number having numbers 1 to 6");
                    string input = Console.ReadLine();
                    int userNumber;
                    Int32.TryParse(input, out userNumber);
                    if (userNumber < 1111 || userNumber > 9999)
                    {
                        Console.WriteLine("Invalid number entered.");
                        TryCount++;
                        continue;
                    }
                    List<int> usrlist = new List<int>();
                    rem = userNumber;
                    while (rem != 0)
                    {
                        usrlist.Add(rem % 10);
                        rem = rem / 10;
                    }
                    string outputStr = "";
                    for (int i = 0; i < usrlist.Count; i++)
                    {
                        if (numlist[i] == usrlist[i])
                        {
                            outputStr += "+";
                        }
                        else if (numlist.Contains(usrlist[i]))
                        {
                            outputStr += "-";
                        }
                    }
                    outputStr = String.Concat(outputStr.OrderBy(c => c));
                    Console.WriteLine(outputStr);
                    if (outputStr == "++++")
                    {
                        Console.WriteLine("Successfull Guess");
                        break;
                    }
                    else
                    {

                        if (TryCount < maxRetry)
                        {
                            Console.WriteLine("Try again" + string.Format("You have {0} chances left.", maxRetry - TryCount));
                            TryCount++;
                        }
                        else
                        {
                            Console.WriteLine("you are lost.");
                            break;
                        }

                    }

                }

                Console.WriteLine("Do you want to play again.y - yes,n - no");
                string userResponse = Console.ReadLine();
                if (userResponse.ToLower() != "y")
                {
                    break;
                }
                Console.Clear();
            }
        }
    }
}

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
            Random rndm = new Random();
            int rndmNumber = rndm.Next(1111, 6666);
            List<int> numlist = new List<int>();
            int rem = rndmNumber;
            while(rem != 0)
            {
                numlist.Add(rem % 10);
                rem = rem / 10;
            }
            
            const int maxRetry = 10;
            int TryCount = 0;
            while(TryCount <= maxRetry )
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
                for(int i=0; i< usrlist.Count; i++)
                {
                    if(numlist[i]==usrlist[i])
                    {
                        outputStr += "+";
                    }
                    else if(numlist.Contains(usrlist[i]))
                    {
                        outputStr += "-";
                    }
                }
                outputStr = String.Concat(outputStr.OrderBy(c => c));
                Console.WriteLine(outputStr);
                if (outputStr == "++++")
                {
                    Console.WriteLine("Successfull Guess");
                    Console.ReadLine();
                    break;
                }
                else
                {
                    TryCount++;
                    Console.WriteLine("Try again" + string.Format("You have {0} chances left.", maxRetry- TryCount));
                }

            }
        }
    }
}

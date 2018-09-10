using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.IO;

namespace HW6
{
    class Program
    {
        static void Main(string[] args)
        {
            #region HW6.1
            PhoneBook();
            #endregion
            #region HW6.2
            int j = 0;
            int start = 1;
            int end = 100;
            while (j < 10)
            {
                try
                {
                    Console.WriteLine("range [{0}...{1}]", start, end);
                    if (start + 1 != end)
                    {
                        start = ReadNumber(start, end);
                    }
                    else
                    {
                        break;
                    }                    
                }
                catch (Exception e)
                {
                    Console.WriteLine(e.Message);
                }                
                j++;
            }
            #endregion

            Console.ReadKey();
        }
        #region HW6.1
        static void PhoneBook()
        {
            Dictionary<string, string> PhoneBook = new Dictionary<string, string>();

             string record;

            using (StreamReader sr = new StreamReader("phones.txt"))
            {
                for (int i = 0; i < 9; i++)
                {
                    record = sr.ReadLine();
                    PhoneBook.Add(record.Split('/')[1], record.Split('/')[0]);
                }
            }

            using (StreamWriter sw = new StreamWriter("Phones2.txt"))
            {
                foreach(string phoneNumber in PhoneBook.Values)
                {
                    sw.WriteLine(phoneNumber);
                }
            }
            
            Console.Write("Enter name:");
            string searchName = Console.ReadLine();
            if (PhoneBook.ContainsKey(searchName))
            {
                Console.WriteLine("Phone number = {0}", PhoneBook[searchName]);
            }
            else
            {
                Console.WriteLine("Error! Name not found");
            }
            List<string> keys = new List<string>();
            
            foreach (var phoneRecord in PhoneBook)
            {
                if (phoneRecord.Value.StartsWith("80"))
                {
                    keys.Add(phoneRecord.Key);   
                }
            }
            foreach (string key in keys)
            {
                PhoneBook[key] = "+3" + PhoneBook[key];
            }

            using (StreamWriter sw = new StreamWriter("New.txt"))
            {
                foreach (string phoneNumber in PhoneBook.Values)
                {
                    sw.WriteLine(phoneNumber);
                }
            }
        }
        #endregion
        #region HW6.2
        static int ReadNumber(int start, int end)
        {
            int number = 0;
            Console.Write("Enter number:");
            number = int.Parse(Console.ReadLine());
            if (number > start && number < end)
            {
                return number;
            }
            else
            {
                throw new OverflowException();
            }            
        }
        #endregion
    }
}

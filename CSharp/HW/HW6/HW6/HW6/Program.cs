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
            while (j < 10)
            {
                Console.WriteLine(ReadNumber(1, 100));                
                j++;
            }
            #endregion

            Console.ReadKey();
        }
        #region HW6.1
        static void PhoneBook()
        {
            Dictionary<string, string> PhoneBook = new Dictionary<string, string>();
            string name = "name";
            string[] phones = File.ReadAllLines("phones.txt");

            for (int i = 0; i < 9; i++)
            {
                PhoneBook.Add(name + (i + 1), phones[i]);
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

            if (!File.Exists("New.txt"))
            {
                foreach (KeyValuePair<string, string> number in PhoneBook)
                {
                    File.AppendAllText("New.txt", "+3" + number.Value + "\r\n");
                }
            } 
        }
        #endregion
        #region HW6.2
        static int ReadNumber(int start, int end)
        {
            int number = 0;
            Console.Write("Enter number:");
            try
            {
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
            catch (Exception e)
            {
                Console.WriteLine("Error! {0}", e.Message);
            }            
            return 0;            
        }
        #endregion
    }
}

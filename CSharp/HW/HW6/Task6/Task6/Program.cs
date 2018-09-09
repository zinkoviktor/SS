using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.IO;

namespace Task6
{
    class Program
    {
        static void Main(string[] args)
        {
            #region Task 6.1
            double firstNum = 0.0;
            double secondNum = 0.0;
            Console.WriteLine("Enter numbers for dividing:");
            try
            {
                Console.Write("First numbers: ");
                firstNum = double.Parse(Console.ReadLine());
                Console.Write("Second numbers: ");
                secondNum = double.Parse(Console.ReadLine());
            }
            catch (ArgumentNullException)
            {
                Console.WriteLine("Error! You nothing entered!");
            }
            catch (FormatException)
            {
                Console.WriteLine("Error! You entered not a number!");
            }
            catch (OverflowException)
            {
                Console.WriteLine("Error! Entered number is too long!");
            }

            Console.WriteLine("Result: {0}", Div(firstNum, secondNum));
            #endregion
            #region Task 6.2
            
            FirstTask();            
            SecondTask();           
            ThirdTask();            
            FourthTask();
            #endregion
            #region Task 6.3 
            //using (StreamWriter writer = new StreamWriter("DirectoryC.txt"))
            //{
            //    try
            //    {
            //        Console.WriteLine("Please wait!");
            //        foreach (var file in Directory.EnumerateFiles(@"C:\\", "*", SearchOption.AllDirectories))
            //        {
            //            writer.WriteLine("{0:0.0}, size: {1:0.0} bytes", file, file.Length);
            //        }
            //    }
            //    catch (Exception e)
            //    {
            //        Console.WriteLine("Error! {0}", e.Message);                    
            //    }
            //    finally
            //    {
            //        writer.Close();
            //    }
            //    Console.WriteLine("Done!");
            //    writer.Close();                
            //}
            #endregion
            #region Task 6.4
            //try
            //{
            //    foreach (var file in Directory.GetFiles(@"D://", "*.txt", SearchOption.AllDirectories))
            //    {

            //        Console.WriteLine(new FileInfo(file));
            //        Console.WriteLine("Size: {0}", new FileInfo(file).Length);
            //    }
            //}
            //catch(Exception e)
            //{
            //    Console.WriteLine("Error! {0}", e.Message);
            //}            
            #endregion
            Console.ReadKey();
        }

        #region Task 6.1
        static double Div(double num1, double num2)
        {
            try
            {
                if (num2 == 0)
                {
                    throw new DivideByZeroException();
                }
                return num1 / num2;
            }
            catch (DivideByZeroException)
            {
                Console.WriteLine("Dividing by zero is irrational!");
                return 0;
            }
        }
        #endregion
        #region Task 6.2.1
        static void FirstTask()
        {
            int a, b;
            StreamReader reader = new StreamReader("data.txt");
             
            try
            {
                a = int.Parse(reader.ReadLine());
                b = int.Parse(reader.ReadLine());
            }
            catch (FormatException)
            {
                Console.WriteLine("Erorr in value!");
                a = 0;
                b = 0;
            }
            catch (OverflowException)
            {
                Console.WriteLine("Erorr! Value too large or too small!");
                a = 0;
                b = 0;
            }
            try
            {
                using (StreamWriter writer = new StreamWriter("rez.txt"))
                {
                    writer.WriteLine(a + " + " + b + " = " + (a + b));
                    writer.WriteLine("{0}-{1} = {2}", a, b, a - b);
                    writer.WriteLine("{0}*{1} = {2}", a, b, a * b);
                    if (a != 0 && b != 0)
                    {
                        writer.WriteLine("{0}/{1} = {2}", a, b, a / b);
                    }
                    writer.Close();
                }
            }
            catch (Exception e)
            {
                Console.Write("(1) Error! {0}", e.Message);                
            }
            
            Console.WriteLine("(1) Data have been written to the file!");
            reader.Close();
        }
        #endregion
        #region Task 6.2.2
        static void SecondTask()
        {
            try
            {
                string[] lines = File.ReadAllLines("data.txt");
                string line = lines[2];
                File.WriteAllText("rez.txt",  File.ReadAllText("rez.txt") + "You are " + line);                
            }
            catch(Exception e)
            {
                Console.WriteLine("Error! {0}", e.Message);
            }
            Console.WriteLine("(2) Data have been written to the file!");
        }
        #endregion
        #region Task 6.2.3
        static void ThirdTask()
        {
            string firstLine, secondLine, thirdLine;
            try
            {
                string[] lines = File.ReadAllLines("data.txt");               
                firstLine = lines[3];
                secondLine = lines[4];
                thirdLine = lines[5];
            }
            catch (Exception e)
            {
                Console.WriteLine("Error! {0}", e.Message);
                firstLine = "";
                secondLine = "";
                thirdLine = "";
            }

            char firstChar, secondChar, thirdChar;
            try
            {
                firstChar = char.Parse(firstLine);
                secondChar = char.Parse(secondLine);
                thirdChar = char.Parse(thirdLine);
            }
            catch (FormatException)
            {
                Console.WriteLine("Incorrect char!");
                firstChar = ' ';
                secondChar = ' ';
                thirdChar = ' ';
            }

            try
            {
                using (StreamWriter writer = new StreamWriter("rez.txt", true))
                {
                    writer.WriteLine("\r\nYou enter ({0:0.0}), ({1:0.0}), ({2:0.0})", firstChar, secondChar, thirdChar);                   
                    writer.Close();
                }
            }
            catch (Exception e)
            {
                Console.Write("(3) Error! {0}", e.Message);
            }
            Console.WriteLine("(3) Data have been written to the file!");
        }
        #endregion
        #region Task 6.2.4
        static void FourthTask()
        {
            int[] numbers = { 0, 0 };
            bool checkFirstNumber, checkSecondNumber;
            try
            {
                string[] lines = File.ReadAllLines("data.txt");                
                checkFirstNumber = Int32.TryParse(lines[6], out numbers[0]);
                checkSecondNumber = Int32.TryParse(lines[7], out numbers[1]);
            }
            catch (Exception e)
            {
                Console.WriteLine("Error! {0}", e.Message);
                checkFirstNumber = false;
                checkSecondNumber = false;
            }
            try
            {
                using (StreamWriter writer = new StreamWriter("rez.txt", true))
                {
                    writer.WriteLine("First number: {0:0.0} \r\nSecond number: {1:0.0}", checkFirstNumber, checkSecondNumber);
                    writer.Close();
                }
            }
            catch (Exception e)
            {
                Console.Write("(4) Error! {0}", e.Message);
            }
            Console.WriteLine("(4) Data have been written to the file!");            
        }
        #endregion

    }
}

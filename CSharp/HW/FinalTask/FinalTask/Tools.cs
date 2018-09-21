using System;
using System.Collections.Generic;
using System.Globalization;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FinalTask
{
    public abstract class Tools
    {
        /// <summary>Changes first character to UpperCase</summary>
        public static string FirstCharToUpper(string str)
        {
            return char.ToUpper(str[0]) + str.Substring(1);
        }

        /// <summary>Parses string to double, uses dot and comma separators</summary>
        public static double ParseToDouble(string str)
        {
            NumberFormatInfo nfi = new NumberFormatInfo();
            nfi.NumberDecimalSeparator = ".";
            double result;

            if (double.TryParse(str, out result))
            {
                return result;
            }
            else
            {
                return double.Parse(str, nfi);
            }
        }

        /// <summary>
        /// Returns Fruit Id from file line
        /// </summary>        
        /// <returns>Fruits Id</returns>
        public static int ReturnId(StreamReader sr)
        {
            int id = 0; //For Fruits Id
            char [] buffer = new char[1]; //buffer for chars
            int i = 1; //Counts
            int counter = 1;
            try
            {
                while (sr.Peek() != '/')//Reads all Id number
                {
                    if (counter == 0)
                    {
                        id = id * i;
                        i /= 10;
                        counter = 1;
                    }                    
                    id = id + (sr.Read() - '0'); //Adds number to ID variable                    
                    i = i * 10;
                    counter--;
                }
            }
            catch 
            {
                throw new Exception("Error in returnId");
            }
            sr.Read();
            return id;
            
        }

        /// <summary>Verifying line from file, on fruits parameters</summary>
        /// <param name="str">Line from file stream</param>        
        public static bool DoesValuesValid(string[] values)
        {
            try
            {                
                string name = values[0];//Gets name
                string color = values[1];//Gets color
                if (values.Length > 2)
                {
                    double vitCLvl = Tools.ParseToDouble(values[2]);//Parses to double 
                }

                return true; //If passed, returns true;
            }
            catch (Exception e)
            {
                Console.WriteLine(e.Message);//If failed, prints message
                return false;//return false
            }
        }
                
    }
}

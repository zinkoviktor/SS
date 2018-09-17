using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FinalTask
{
    class Fruit
    {
        //Colors in HEX
        enum Colors 
        {           
            Black = 0x0,
            Red = 0xFF,
            Green = 0xFF00,
            Yellow = 0xFFFF,
            Blue = 0xFF0000,
            Magenda = 0xFF00FF,
            Cyan = 0xFFFF00,
            White = 0xFFFFFF,
            None = -1
        }

        private string name; //Fruit name, default null
        private Colors color = Colors.None; //Fruit color in HEX from Enum Colors
        
        public string Name
        {
            get
            {
                return name;
            }                
        }
        public string Color
        {
            get
            {
                return color.ToString();
            }
        }

        //Constructors
        public Fruit() { }
        public Fruit(string name, string color)
        {
            this.name = name;
            this.color = parseToColorsKey(color); //Parses string color to enum keyword           
        }

        ///<summary>Inputs name and color from console</summary>
        //If fruit is created, writes message
        virtual public void Input()
        {
            if (name == null)
            {
                Console.Write("Enter name: ");
                name = Console.ReadLine();
            }
            else if (color.Equals(Colors.None))
            {
                Console.WriteLine("Name = {0}", Name);
                Console.Write("Enter color: ");
                color = parseToColorsKey(Console.ReadLine());
            }
            else
            {
                Console.WriteLine("Cannot change created Fruit!");
                Print();
            }
        }

        /// <summary>Prints name and color into console</summary>
        //If fruit is empty, writes message
        virtual public void Print()
        {
            if (name != null)
            {
                Console.WriteLine("Fruit name = {0}, color = {1}", Name, Color);
            }            
            else
            {
                Console.WriteLine("Empty fruit");
            }
        }

        /// <summary>Inputs name and color from file</summary>
        /// <param name="sr">Used to reads from file</param>
        virtual public void Input(StreamReader sr)
        {
            string line;
            string[] values;

            if (sr.Peek() > 0)
            {
                line = sr.ReadLine();
                values = line.Split('/');
                if (lineValidator(values))
                {
                    name = values[1];
                    color = parseToColorsKey(values[2]);
                }
            }                      
        }

        /// <summary>Writes name and color into file</summary>
        /// <param name="path">Used to get file path</param>
        virtual public void Print(string path)
        {
            using (StreamWriter writer = new StreamWriter(path, true))
            {
                writer.WriteLine("1/" + Name + "/" + Color);                
            }
        }

        //Changes first string character to UpperCase
        private string firstCharToUpper(string str)
        {
            return char.ToUpper(str[0]) + str.Substring(1);
        }

        //Parses string color name to the enum keyword
        private Colors parseToColorsKey(string color)
        {
            try
            {
                return (Colors)Enum.Parse(typeof(Colors), firstCharToUpper(color));
            }
            catch(Exception e)
            {
                Console.WriteLine(e.Message);
                return Colors.None;
            }
        }

        /// <summary>???</summary>
        /// <param name="str">???</param>        
        public bool lineValidator(string[] str)
        {
            try
            {
                int key = int.Parse(str[0]);
                string name = str[1];
                string color = str[2];
                if (key == 2)
                {
                    double vitCLvl = double.Parse(str[3]);
                }
                return true;
            }
            catch(Exception e)
            {
                Console.WriteLine(e.Message);
                return false;
            }
        }

        public override string ToString()
        {
            return name;
        }

    }
}

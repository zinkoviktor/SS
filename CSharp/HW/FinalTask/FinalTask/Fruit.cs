using System;
using System.Collections.Generic;
using System.Globalization;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Xml.Serialization;

namespace FinalTask
{
    
    
    [XmlInclude(typeof(Citrus))]
    public class Fruit : IFruits
    {
        //Colors in HEX        
        protected enum Colors 
        {            
            Black = 0x0,
            Red = 0xFF,
            Green = 0xFF00,            
            Yellow = 0xFFFF,
            Blue = 0xFF0000,            
            Magenda = 0xFF00FF,
            Orange = 0xFF8000,
            Cyan = 0xFFFF00,
            White = 0xFFFFFF,
            None = -1
        }
       
        protected string name; //Fruit name, default null       
        protected Colors color = Colors.None; //Fruit color in HEX from Enum Colors         
               
        public string Name
        {
            get
            {
                return name;
            }
            set
            {
                name = value;
            }
        }
        
        public string Color
        {
            get
            {
                return color.ToString();
            }
            set
            {
                color = parseToColorsKey(value);
            }
        }

        //Constructors
        public Fruit()
        {

        }
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

                if (color.Equals(Colors.None))
                {                   
                    Console.Write("Enter color: ");
                    color = parseToColorsKey(Console.ReadLine());
                }
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
                if (Tools.DoesValuesValid(values))
                {
                    name = values[0];
                    color = parseToColorsKey(values[1]);
                }
            }
        }

        /// <summary>Prints name and color into console</summary>
        //If fruit is empty, writes message
        virtual public void Print()
        {
            if (name != null)
            {
                Console.Write("\nFruit name = {0}, color = {1}", Name, Color);
            }            
            else
            {
                Console.WriteLine("Empty fruit");
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

        //Parses string color name to the enum keyword
        protected Colors parseToColorsKey(string color)
        {
            try
            {
                return (Colors)Enum.Parse(typeof(Colors), Tools.FirstCharToUpper(color));
            }
            catch(Exception e)
            {
                Console.WriteLine(e.Message);
                return Colors.None;
            }
        }

        public override string ToString()
        {
            return Color + " " + Name;
        }
        public override bool Equals(object o)
        {
            var other = o as Fruit;
            if (other == null) { return false; }
            return Name == other.Name && Color == other.Color;
        }

    }
}

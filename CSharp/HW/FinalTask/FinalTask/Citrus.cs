using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FinalTask
{
    [Serializable]
    public class Citrus : Fruit
    {
        private double vitCLvl;
        public double VitaminCLevel
        {
            get
            {
                return vitCLvl;
            }
            set
            {
                vitCLvl = value;
            }
        }

        public Citrus()
        {

        }
        public Citrus(string name, string color, double vitCLvl) : base(name, color)
        {
            this.vitCLvl = vitCLvl;
        }

        ///<summary>Inputs name, color and vitamin C level from console</summary>
        //If fruit is created, writes message
        public override void Input()
        {
            if (name == null)
            {
                Console.Write("Enter name: ");
                name = Console.ReadLine();

                if (color.Equals(Colors.None))
                {                    
                    Console.Write("Enter color: ");
                    color = parseToColorsKey(Console.ReadLine());

                    if (vitCLvl <= 0)
                    {
                        Console.Write("Enter vitamin C level: ");
                        vitCLvl = Tools.ParseToDouble(Console.ReadLine());
                    }
                }
               
            }
            else if (color.Equals(Colors.None))
            {
                Console.WriteLine("Name = {0}", name);
                Console.Write("Enter color: ");
                color = parseToColorsKey(Console.ReadLine());
            }
            else if (vitCLvl<=0)
            {
                Console.Write("Name = {0}", name);
                Console.WriteLine("Color = {0}", color);
                Console.Write("Enter vitamin C level: ");
                vitCLvl = Tools.ParseToDouble(Console.ReadLine());
            }
            else
            {
                Console.WriteLine("Cannot change created Citrus!");
                Print();
            }
        }

        /// <summary>Inputs name, color and vitamin C level from file</summary>
        /// <param name="sr">Used to reads from file</param>
        public override void Input(StreamReader sr)
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
                    vitCLvl = Tools.ParseToDouble(values[2]);
                }
            }
        }

        ///<summary>Prints name, color and vitamin C level into console</summary>
        //If citrus is empty, writes message
        public override void Print()
        {
            base.Print();           
            if (name != null && vitCLvl > 0)
            {
                Console.Write(", Vitamin C level = {0}", vitCLvl);
            }
        }

        /// <summary>Writes name, color and vitamin C into file</summary>
        /// <param name="path">Used to get file path</param>
        public override void Print(string path)
        {
            using (StreamWriter writer = new StreamWriter(path, true))
            {
                writer.WriteLine("2/" + Name + "/" + Color + "/" + vitCLvl);
            }
        }

        public override string ToString()
        {
            return Color + " " + Name + " Vitamin C = " + VitaminCLevel;
        }
    }
}

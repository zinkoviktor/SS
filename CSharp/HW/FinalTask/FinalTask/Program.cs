using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Xml.Serialization;


namespace FinalTask
{   
    public class Program
    {
        public enum FruitsId
        {
            None = 0,
            Fruit,
            Citrus
        }
        static void Main(string[] args)
        {
            
            List<Fruit> fruits = new List<Fruit>(); //List for fruits
            string readPath = @"file.txt"; //path to file, with the fruits data        

            fruits.AddRange(AddFromFile(readPath, 3));//Adds fruits from file
            fruits.AddRange(AddFromConsole(2));//Adds fruits from console

            //Prints all Yellow fruits
            Console.WriteLine("\nYellow fruits:");
            PrintFruitByColor(fruits, "yellow");

            //Prints all fruit sorted by NameDeserializing from file
            Console.WriteLine("\n\nSorted by Name:");
            PrintSortFruitByParamets(fruits, "Name", true);

            //Serializing to xml
            FruitsXMLSerializer(fruits, "xml_fruits.xml");

            //Deserializing from file
            try
            {
                List<Fruit> xmlFruits = new List<Fruit>(FruitsXMLDeserializer("xml_fruits.xml"));
                //Prints deserialized fruits
                Console.WriteLine("\n\nDeserialized list:");
                PrintList(xmlFruits);
            }
            catch (Exception e)
            {
                Console.WriteLine("Error deserializing, {0}", e.Message);
            }           

            Console.ReadKey();
        }

        /// <summary>Adds fruits from file, return fruit list</summary>
        /// <param name="path">Path to file with fruits</param>
        /// <param name="count">How many fruits must be returned</param>
        static List<Fruit> AddFromFile(string path, int count)
        {
            List<Fruit> fruits = new List<Fruit>();//Temporary list for returning

            using (StreamReader sr = new StreamReader(path))//Opens file and reads it
            {
                int id;//Variable for 

                do //Runs process for reading from file
                {
                    id = Tools.ReturnId(sr); //Get fruit Id

                    try
                    {
                        if (id == (int)FruitsId.Fruit)
                        {
                            fruits.Add(new Fruit());//Adds new Fruit
                            fruits[fruits.Count - 1].Input(sr);//Inputs data from file line
                            count--;
                        }
                        else if (id == (int)FruitsId.Citrus)
                        {
                            fruits.Add(new Citrus());//Adds new Citrus
                            fruits[fruits.Count - 1].Input(sr);//Inputs data from file line
                            count--;
                        }
                        else if (sr.Peek() > 0)
                        {
                            sr.ReadLine();//If line empty or not has Id
                            count++;
                        }
                        else
                        {
                            count = 0; //If end of file
                        }
                    }
                    catch (Exception e)
                    {
                        Console.WriteLine(e.Message);
                        count = 0;
                    }
                }
                while (count > 0);

                Console.WriteLine("{0} fruits added from file\n", fruits.Count);
                return fruits;//Returns created List
            }
        }

        static List<Fruit> AddFromConsole(int count)
        {
            List<Fruit> fruits = new List<Fruit>();//Temporary list for returning
            int type; //variable for saving Fruits ID from Console

            PrintInfo(); //Prints Information about supported types           
            
            for (int i = 0; i < count; i++) //Runs the process for adding fruits
            {
                Console.WriteLine("\nEnter Id for adding a fruit: ");                

                try
                {
                    type = int.Parse(Console.ReadLine());//Parse ID from Console

                    switch (type) //Chooses Fruits method for adding
                    {
                        case (int)FruitsId.Fruit: 
                            fruits.Add(new Fruit()); //Adds new Fruit
                            fruits[fruits.Count-1].Input();//Inputs data from Console
                            break;
                        case (int)FruitsId.Citrus:
                            fruits.Add(new Citrus());//Adds new Citrus
                            fruits[fruits.Count-1].Input();//Inputs data from Console
                            break;
                        default:
                            Console.WriteLine("Not supported");//Error message
                            i--; //Increments count
                            break;                        
                    }
                }
                catch (Exception e)
                {
                    Console.WriteLine(e.Message);
                    i--;
                }                
            }

            return fruits; //Returns created List
        }

        /// <summary>Prints Information about supported fruits types into console</summary>
        static void PrintInfo()
        {
            Console.WriteLine("Supported Fruits type");
            Console.WriteLine(" -------------------- ");
            Console.WriteLine("|ID | Name           |");
            Console.WriteLine(" -------------------- ");
            Console.WriteLine("|1  | Fruit          |");
            Console.WriteLine("|2  | Citrus         |");
            Console.WriteLine(" --------------------");
        }

        /// <summary>Prints elements from List into Console</summary>       
        static void PrintList(List<Fruit> fruits)
        {
            int count = fruits.Count; //Gets List Length 

            if (count == 1)
            {
                //If in the List one fruit
                fruits[0].Print();
            }
            else if (count > 1)
            {
                //If in the List a lot of fruits, prints all fruits
                foreach (Fruit fruit in fruits)
                {
                    fruit.Print();
                }
            }            
            else
            {
                //If List empty, prints message
                Console.WriteLine("Empty list!");
            }
        }

        /// <summary>Finds and print Fruits by color</summary>      
        static void PrintFruitByColor(List<Fruit> fruits, string color)
        {
            int count = fruits.Count; //Gets List Length 

            List<Fruit> temp = new List<Fruit>(); //Temporary list for returning

            //Finds all fruits by color, and returns all found Fruits 
            temp = fruits.FindAll(fruit => fruit.Color == Tools.FirstCharToUpper(color));

            if (temp.Count > 0)
            {
                //If List Length greater than 0, prints all found Fruits
                PrintList(temp); 
            }
            else
            {
                //If fruits was not found, prints message
                Console.WriteLine("Not found!");
            }
        }

        /// <summary>Sorts and prints fruit by parametr</summary>
        /// <param name="fruits">List for sorting</param>
        /// <param name="parametr">Parameter for sorting </param>
        /// <param name="print">If print sorted list</param>
        public static List<Fruit> PrintSortFruitByParamets(List<Fruit> fruits, string parametr, bool print)
        {
            int count = fruits.Count;//Gets List Length

            List<Fruit> temp = new List<Fruit>(fruits);//Temporary list for returning        

            parametr = Tools.FirstCharToUpper(parametr);//Parameter for sorting

            if (parametr == "Name") //Sorting by Name
            {
                //Uses lambda expression for sorting
                temp.Sort(delegate (Fruit x, Fruit y)
                {
                    if (x.Name == null && y.Name == null) return 0;
                    else if (x.Name == null) return -1;
                    else if (y.Name == null) return 1;
                    else return x.Name.CompareTo(y.Name);
                });
            }
            else if(parametr == "Color")//Sorting by Color
            {
                //Uses lambda expression for sorting
                temp.Sort(delegate (Fruit x, Fruit y)
                {
                    if (x.Color == null && y.Color == null) return 0;
                    else if (x.Color == null) return -1;
                    else if (y.Color == null) return 1;
                    else return x.Color.CompareTo(y.Color);
                });
            }            
            if (temp.Count > 0 && print == true) 
            {
                PrintList(temp);//If list is sorted, prints it
            }
            else
            {
                //Console.WriteLine("Not sorted!");//If list empty, prints error message
            }

            return temp; //Returns created list
        }

        /// <summary>
        /// Serializes fruits from List to XML format and write it to the file
        /// </summary>
        /// <param name="fruits">fruitls List</param>
        /// <param name="path">Path to XML file</param>
        public static void FruitsXMLSerializer(List<Fruit> fruits, string path)
        {
            //Declares and initializes XML Serializer
            XmlSerializer serializer = new XmlSerializer(typeof(List<Fruit>), new Type[] { typeof(Fruit), typeof(Citrus) });

            //Open Writer, uses it for creating XML file and writing data to the file, 
            try
            {
                using (StreamWriter textWriter = new StreamWriter(path))
                {
                    //Serializes Fruits form List to the file and save
                    serializer.Serialize(textWriter, fruits);
                }
            }
            catch (Exception e)
            {
                Console.WriteLine(e.Message);
            }            
        }

        /// <summary>
        /// Deserializes fruits from XML format file and return fruits List
        /// </summary>        
        /// <param name="path">Path to XML file</param>
        public static List<Fruit> FruitsXMLDeserializer(string path)
        {
            List<Fruit> tempList; //Temporary list for returning

            //Declares and initializes XML Serializer
            XmlSerializer serializer = new XmlSerializer(typeof(List<Fruit>), new Type[] { typeof(Fruit), typeof(Citrus) });

            //Reads from file
            try
            {
                using (FileStream fs = new FileStream(path, FileMode.OpenOrCreate))
                {
                    //Deserializes from file and save to the new List
                    tempList = (List<Fruit>)serializer.Deserialize(fs);
                }
            }
            catch (Exception e)
            {
                Console.WriteLine(e.Message);
                throw new InvalidOperationException("Deserialization Exeption!");
            }

            return tempList; //returns fruits List
        }
    }
}

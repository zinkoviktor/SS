using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HW5
{
    class Program
    {
        static void Main(string[] args)
        {
            List<IDeveloper> developers = new List<IDeveloper>();
            developers.Add(new Programmer());
            developers.Add(new Programmer());
            developers.Add(new Programmer());
            developers[0].Tool = "C#";
            developers[1].Tool = "JavaScript";
            developers[2].Tool = "C++";

            developers[0].Create();
            developers[0].Destroy();

            List<IDeveloper> builders = new List<IDeveloper>();
            builders.Add(new Builder());
            builders.Add(new Builder());
            builders.Add(new Builder());

            builders[0].Tool = "Shovel";
            builders[1].Tool = "Mixer";
            builders[2].Tool = "Bucket";

            builders[0].Create();
            builders[0].Destroy();
            
            Console.ReadKey();
        }
    }
}

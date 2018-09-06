using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HW5
{
    class Programmer : IDeveloper
    {
        public string Tool { get; set; }
        
        public void Create()
        {
            Console.WriteLine("{0} program created!", Tool );
        }

        public void Destroy()
        {
            Console.WriteLine("{0} program destroyed!", Tool);
        }
    }
}

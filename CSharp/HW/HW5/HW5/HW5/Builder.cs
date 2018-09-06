using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HW5
{
    class Builder : IDeveloper
    {
        public string Tool { get; set; }

        public void Create()
        {
            Console.WriteLine("Building created!", Tool);
        }

        public void Destroy()
        {
            Console.WriteLine("Building destroyed!", Tool);
        }
    }
}

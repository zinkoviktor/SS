using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HW7
{
    class Comparer : IComparer<Shape>
    {
        public int Compare(Shape x, Shape y)
        {
            int compareArea = x.Area().CompareTo(y.Area());
            if (compareArea == 0)
            {
                return x.Name.CompareTo(y.Name);
            }
            return compareArea;
        }
    }
}

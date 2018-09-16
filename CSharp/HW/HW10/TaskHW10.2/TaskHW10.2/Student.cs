using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TaskHW10._2
{
    class Student : Program
    {
        private string name;
        private List<int> marks = new List<int>();

        public Student() { name = "none"; }
        public Student(string name)
        {
            this.name = name;
        }
        public string Name { get { return name; } }

        public event MyDel MarkChange;
        
        public void AddMark(int mark)
        {            
            marks.Add(mark);
            if(MarkChange != null)
            {
                MarkChange(mark);
            }
        }
    }
}

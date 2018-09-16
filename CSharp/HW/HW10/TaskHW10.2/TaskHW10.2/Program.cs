using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TaskHW10._2
{
    class Program
    {       
        static void Main(string[] args)
        {
            Student student = new Student("Victor");
            Parent parent = new Parent();
            AccountingDep accountingDep = new AccountingDep();
            student.MarkChange += new MyDel(parent.OnMarkChange);
            student.MarkChange += new MyDel(accountingDep.Stipend);

            student.AddMark(4);
            student.AddMark(5);
            student.AddMark(4);
            student.AddMark(3);

            Console.ReadKey();

        }
        public delegate void MyDel(int m);
    }
    
}

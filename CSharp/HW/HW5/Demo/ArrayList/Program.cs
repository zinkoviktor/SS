using System;
using System.Collections;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ArrayListDemo
{
    class Program
    {
        static void Main(string[] args)
        {
            // ArrayList Constructors (Overloads)
            #region 
            ArrayList list = new ArrayList();
            ArrayList listICol = new ArrayList(new string[] { "TEN", "ELEVEN", "TWELVE" }); // ArrayList(ICollection)
            ArrayList listInt = new ArrayList(10); // ArrayList(Int32)
            #endregion

            //Properties:
            #region
            //- Capacity - gets or sets the number of elements that the ArrayList can contain
            #region
            Console.WriteLine("Capacity: (1) = {0}, (2) = {1}, (3) = {2}", list.Capacity, listICol.Capacity, listInt.Capacity);
            #endregion

            //- Count - gets the number of elements actually contained in the ArrayList
            #region
            Console.WriteLine("\nCount:    (1) = {0}, (2) = {1}, (3) = {2}", list.Count, listICol.Count, listInt.Count);
            #endregion

            //- IsFixedSize - gets a value indicating whether the ArrayList has a fixed size
            #region
            ArrayList listFixedSize = ArrayList.FixedSize(listICol);
            Console.WriteLine("\nIsFixedSize: (1) = {0}, (2) = {1}, (3) = {2}, (4) = {3}", list.IsFixedSize, listICol.IsFixedSize, listInt.IsFixedSize, listFixedSize.IsFixedSize);
            try { listFixedSize.Add("NEW"); } catch (NotSupportedException) { Console.WriteLine("Error! Collection was of a fixed size"); }
            listFixedSize[0] = "NEW";
            Console.WriteLine("listFixedSize[0] = {0}", listFixedSize[0]);
            #endregion

            //- IsReadOnly - gets a value indicating whether the ArrayList is read-only
            #region
            ArrayList listReadOnly = ArrayList.ReadOnly(listICol);
            Console.WriteLine("\nIsReadOnly: (1) = {0}, (2) = {1}, (3) = {2}, (4) = {3}, (5) = {4}", list.IsReadOnly, listICol.IsReadOnly, listInt.IsReadOnly, listFixedSize.IsReadOnly, listReadOnly.IsReadOnly);
            try { listReadOnly[0] = "HELLO"; } catch (NotSupportedException) { Console.WriteLine("Error! Collection is read-only"); }
            #endregion

            // - Item[Int32] - gets or sets the element at the specified index
            #region
            Console.WriteLine("\nItem[Int32]:");
            list.Add("first");
            list[0] = "Hello Guys!";
            Console.WriteLine(list[0]);
            #endregion

            // - IsSynchronized - gets a value indicating whether access to the ArrayList is synchronized (thread safe)
            #region
            ArrayList listSync = ArrayList.Synchronized(listICol);
            Console.WriteLine("\nIsSynchronized: (1) = {0}, (2) = {1}, (3) = {2}, (6) = {3}", list.IsSynchronized, listICol.IsSynchronized, listInt.IsSynchronized, listSync.IsSynchronized);
            #endregion

            // - SyncRoot - gets an object that can be used to synchronize access to the ArrayList
            #region
            Console.WriteLine("\nSyncRoot:");
            lock (listICol.SyncRoot)
            {
                foreach (object item in listICol)
                {
                    Console.WriteLine(item);
                }
            }
            #endregion
            #endregion

            Console.ReadKey();
        }
    }
}

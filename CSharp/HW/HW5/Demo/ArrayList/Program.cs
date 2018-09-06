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
            //ArrayList
            //Constructors(Overloads):
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

            //Methods:
            #region
            Console.ReadKey();
            Console.Clear();
            //- Adapter - Creates an ArrayList wrapper for a specific IList
            #region
            //public static System.Collections.ArrayList Adapter(System.Collections.IList list);
            //public interface IList : System.Collections.ICollection;
            //The ArrayList class provides generic Reverse, BinarySearch and Sort methods. This wrapper can be a means to use those methods on IList
            #endregion

            //- Add - Adds an object to the end of the ArrayList
            #region
            Console.WriteLine("Add method:");
            list.Add("First");
            list.Add(3);
            list.Add(true);
            Console.WriteLine("list[0] = {0}, list[1] = {1}, list[2] = {2}, list[3] = {3}", list[0], list[1], list[2], list[3]);
            #endregion

            // - AddRange - adds the elements of an ICollection to the end of the ArrayList
            #region
            Console.WriteLine("\nAddRange method:");
            list.AddRange(listICol);
            PrintListValues(list);
            #endregion

            // - BinarySearch - uses a binary search algorithm to locate a specific element in the sorted ArrayList or a portion of it
            #region
            Console.WriteLine("\nBinarySearch method:");
            Console.WriteLine("\nFind \"true\": position in list = {0}", list.BinarySearch(true));
            Console.WriteLine("Find \"First\": position in list = {0}", list.BinarySearch("First", new SimpleStringComparer()));
            Console.WriteLine("Find \"true\": position in list = {0}", list.BinarySearch(3, 2, true, null));
            #endregion

            // - Clear - removes all elements from the ArrayList
            #region
            Console.WriteLine("\nClear method:");
            listInt.Add(1);
            Console.WriteLine("Capacity = {0}", listInt.Capacity);
            Console.WriteLine("Count = {0}", listInt.Count);
            listInt.Clear();
            Console.WriteLine("Capacity = {0}", listInt.Capacity);
            Console.WriteLine("Count = {0}", listInt.Count);
            #endregion

            // - Clone - creates a shallow copy of the ArrayList
            #region
            Console.WriteLine("\nClone method:");
            list[0] = listICol;
            ArrayList cloneList = (ArrayList)list.Clone();
            Console.WriteLine("cloneList[0] HashCode = {0}", cloneList[0].GetHashCode());
            Console.WriteLine("list[0] HashCode = {0}", list[0].GetHashCode());
            list[0] = "Zero";
            Console.WriteLine("\ncloneList[0] HashCode = {0}", cloneList[0].GetHashCode());
            Console.WriteLine("list[0] HashCode = {0}", list[0].GetHashCode());
            #endregion

            // - Contains - determines whether an element is in the ArrayList
            #region
            Console.WriteLine("\nContains method:");
            Console.WriteLine(list.Contains("NEW"));
            Console.WriteLine(list.Contains("OLD"));
            #endregion

            // - CopyTo - copies the ArrayList or a portion of it to a one-dimensional array
            #region
            Console.WriteLine("\nCopyTo method:");
            string[] copyToArray = new string[7];
            copyToArray[0] = "one";
            copyToArray[1] = "six";
            PrintListValues(copyToArray);
            listICol.CopyTo(copyToArray);
            PrintListValues(copyToArray);
            listICol.CopyTo(copyToArray, 2);
            PrintListValues(copyToArray);
            list.CopyTo(0, copyToArray, 4, 2);
            PrintListValues(copyToArray);
            #endregion

            // - FixedSize - returns a list wrapper with a fixed size, where elements are allowed to be modified, but not added or removed
            #region
            Console.WriteLine("\nFixedSize method:");
            try
            {
                listFixedSize.Add("23");
            }
            catch (Exception)
            {
                Console.WriteLine("Error!");
            }
            #endregion

            // - GetEnumerator - Returns an enumerator that iterates through the ArrayList
            #region
            Console.WriteLine("\nGetEnumerator:");
            IEnumerator e = listICol.GetEnumerator();
            IEnumerator e2 = listICol.GetEnumerator(1, 2);
            IEnumerator e3 = listICol.GetEnumerator();
            Console.WriteLine("e:");
            while (e.MoveNext())
            {
                Console.WriteLine("Current = {0}", e.Current);
            }
            Console.WriteLine("\ne2:");
            while (e2.MoveNext())
            {
                Console.WriteLine("Current = {0}", e2.Current);
            }
            Console.WriteLine("\ne reset:");
            e.Reset();
            int i = 1;
            while (e.MoveNext())
            {
                if (i % 2 == 0)
                {
                    e.MoveNext();
                }
                Console.WriteLine("Current = {0}", e.Current);
                i++;
            }
            #endregion

            // - GetRange - returns an ArrayList which represents a subset of the elements in the source ArrayList
            #region
            Console.WriteLine("\nGetRange:");
            ArrayList rangeList = list.GetRange(0, 2);
            PrintListValues(rangeList);

            //list.Add("ff");
            rangeList[0] = "today";
            PrintListValues(list);
            PrintListValues(rangeList);
            #endregion

            // - SetRange - copies the elements of a collection over a range of elements in the ArrayList
            #region
            Console.WriteLine("\nSetRange:");
            PrintListValues(list);
            list.SetRange(0, listICol);
            PrintListValues(list);
            #endregion

            // - IndexOf - returns the zero-based index of the first occurrence of a value in the ArrayList or in a portion of it
            #region
            Console.WriteLine("\nIndexOf:");
            Console.WriteLine(list.IndexOf("NEW"));
            Console.WriteLine(list.IndexOf(" ", 1));
            Console.WriteLine(list.IndexOf("TWELVE", 1, 2));
            #endregion

            // - LastIndexOf - returns the zero-based index of the last occurrence of a value in the ArrayList or in a portion of it
            #region            
            Console.WriteLine("\nLastIndexOf:");
            ArrayList strLastIndexOf = new ArrayList { "1", "2", "1", "2" };

            Console.WriteLine(strLastIndexOf.LastIndexOf("2"));
            Console.WriteLine(strLastIndexOf.LastIndexOf("1", 1));
            Console.WriteLine(strLastIndexOf.LastIndexOf("2", 2, 2));

            #endregion

            // - Insert - inserts an element into the ArrayList at the specified index
            #region
            Console.WriteLine("\nInsert:");
            PrintListValues(listICol);
            listICol.Insert(0, "FIRST");
            PrintListValues(listICol);
            listICol.Insert(1, "SECOND");
            PrintListValues(listICol);
            #endregion

            // - InsertRange - inserts the elements of a collection into the ArrayList at the specified index
            #region
            Console.WriteLine("\nInsertRange:");
            string[] str = new string[] { "HELLO", "WORLD" };
            listICol.InsertRange(2, str);
            PrintListValues(listICol);
            #endregion

            // - ReadOnly - returns a list wrapper that is read-only
            #region
            Console.WriteLine("\nReadOnly:");
            try
            {
                listReadOnly.Add("value");
            }
            catch (Exception)
            {
                Console.WriteLine("Error!");
            }
            #endregion

            // - Remove - removes the first occurrence of a specific object from the ArrayList
            #region
            Console.WriteLine("\nRemove:");
            PrintListValues(list);
            list.Remove("NEW");
            PrintListValues(list);
            #endregion

            // - RemoveAt - removes the element at the specified index of the ArrayList
            #region
            Console.WriteLine("\nRemoveAt:");
            PrintListValues(list);
            list.RemoveAt(0);
            PrintListValues(list);
            #endregion

            // - RemoveRange - removes a range of elements from the ArrayList
            #region
            Console.WriteLine("\nRemoveRange:");
            PrintListValues(list);
            list.RemoveRange(0, 3);
            PrintListValues(list);
            #endregion

            // - Repeat - returns an ArrayList whose elements are copies of the specified value
            #region
            Console.WriteLine("\nRepeat:");
            ArrayList repeatList = ArrayList.Repeat("Hello", 5);
            PrintListValues(repeatList);
            ArrayList repeatList2 = ArrayList.Repeat(null, 5);
            PrintListValues(repeatList2);
            #endregion

            // - Reverse - reverses the order of the elements in the ArrayList or a portion of it
            #region
            Console.WriteLine("\nReverse:");
            ArrayList reverseList = new ArrayList { "A", "B", "C", "D", "E" };
            PrintListValues(reverseList);
            reverseList.Reverse();
            PrintListValues(reverseList);
            reverseList.Reverse(2, 2);
            PrintListValues(reverseList);
            #endregion

            // - Sort - sorts the elements in the ArrayList or a portion of it
            #region
            Console.WriteLine("\nSort:");
            PrintListValues(reverseList);
            reverseList.Sort();
            PrintListValues(reverseList);

            list.Add(true);
            try
            {
                list.Sort();
            }
            catch (Exception)
            {
                Console.WriteLine("Erorr");
            }
            list.Sort(new MyReverserClass());
            PrintListValues(list);

            reverseList.Reverse();
            PrintListValues(reverseList);

            reverseList.Sort(2, 3, null);
            PrintListValues(reverseList);
            #endregion

            // - Synchronized - returns a list wrapper that is synchronized (thread safe)

            // - ToArray - copies the elements of the ArrayList to a new array
            #region
            Console.WriteLine("\nToArray:");
            string [] copyArray = (String[]) reverseList.ToArray(typeof(string));
            PrintListValues(copyArray);
            #endregion

            // - TrimToSize - sets the capacity to the actual number of elements in the ArrayList
            #region
            Console.WriteLine("\nTrimToSize:");
            Console.WriteLine("list Capacity = {0}", list.Capacity);
            PrintListValues(list);
            list.TrimToSize();
            Console.WriteLine("list Capacity = {0}", list.Capacity);

            Console.WriteLine("\nTrimToSize for clear list:");
            Console.WriteLine("listInt Capacity = {0}", listInt.Capacity);
            listInt.TrimToSize();
            Console.WriteLine("listInt Capacity = {0} default", listInt.Capacity);
            #endregion

            Console.ReadKey();
            #endregion


        }

        public static void PrintListValues(IEnumerable myList)
        {
            int count = 0;
            foreach (Object obj in myList)
            {
                Console.Write(" {0} = {1} ", count, obj);
                count++;
            }
            Console.WriteLine();
        }

        public class SimpleStringComparer : IComparer
        {
            int IComparer.Compare(object x, object y)
            {

                return x.ToString().CompareTo(y);
            }
        }

        public class MyReverserClass : IComparer
        {
            int IComparer.Compare(Object x, Object y)
            {
                return ((new CaseInsensitiveComparer()).Compare(y.ToString(), x));
            }
        }
    }
}

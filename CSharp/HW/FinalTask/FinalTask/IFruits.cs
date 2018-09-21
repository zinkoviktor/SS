using System.IO;

namespace FinalTask
{
    public interface IFruits
    {
        string Name { get; }
        string Color { get; }

        void Input();
        void Input(StreamReader sr);

        void Print();
        void Print(string path);
        
        string ToString();
    }
}

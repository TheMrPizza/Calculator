using System;

namespace Calculator.IO
{
    public class ConsoleIO : IStreamIO
    {
        public string Read()
        {
            return Console.ReadLine();
        }

        public void Write(string msg)
        {
            Console.WriteLine(msg);
        }
    }
}

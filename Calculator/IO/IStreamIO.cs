namespace Calculator.IO
{
    public interface IStreamIO
    {
        void Write(string msg);

        string Read();
    }
}

namespace Assignment3
{
    class Program
    {
        static void Main(string[] args)
        {
            // Files will be saved in the ..\Assignment 3\bin\Debug\net6.0, directory.
            TaskCollection taskMaster = new();
            MainMenu ui = new();
            ui.Menu(taskMaster);
        }
    }
}
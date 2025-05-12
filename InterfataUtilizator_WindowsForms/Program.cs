namespace InterfataUtilizator_WindowsForms
{
    internal static class Program
    {
     
        [STAThread]
        static void Main()
        {
         
            ApplicationConfiguration.Initialize();
            Application.Run(new Form2());
        }
    }
}
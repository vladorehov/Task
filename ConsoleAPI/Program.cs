using TaskManagerCommandsLib;

namespace Program
{
    class Program
    {
        public static bool running = true;
        static void Main()
        {
            Manager manager = new Manager();
            while (running)
            {
                string command = Console.ReadLine();
                ConsoleCommandExecute(command);
                Console.WriteLine(manager.ExecuteCommand(command));
            }
        }

        static void ConsoleCommandExecute(string comandName)
        {
            switch (comandName)
            {
                case "Exit":
                    running = false;
                    break;
                case "Clear":
                    Console.Clear();
                    break;
            }
        }
    }
}
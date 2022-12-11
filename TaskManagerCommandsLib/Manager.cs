using System.Reflection;
using TaskManagerCommandsLib.Commands;

namespace TaskManagerCommandsLib
{
    public class Manager
    {
        public Manager()
        {
            SetCommandsList();
            _args = new string[2];
        }

        private string[] _args;
        private static List<ICommands> _commands = new List<ICommands>();

        /// <summary>
        /// Автоматически создает лист команд
        /// </summary>
        private void SetCommandsList()
        {
            Assembly asm = Assembly.LoadFrom("TaskManagerCommandsLib.dll");
            Type[] types = asm.GetTypes();
            foreach (Type type in types)
            {
                if ((type.IsInterface == false) &&
                    (type.IsAbstract == false) &&
                    (type.GetInterface("ICommands") != null))
                {
                    ICommands value = (ICommands)Activator.CreateInstance(type);
                    _commands.Add(value);
                }
            }
        }

        /// <summary>
        /// проверка на правильность введенной команды
        /// </summary>
        /// <param name="command"></param>
        /// <returns></returns>
        public string ExecuteCommand(string command)
        {
            ParseCommandString(command);
            string result = "";
            foreach (ICommands com in _commands)
            {
                if (com.CommandName().ContainsKey(_args[0]))
                {
                    result = com.Execute(_args);
                }
            }
            if (result == "")
                return "Команда не распознана!\n\n" + ExecuteCommand("Help");
            else
                return result;
        }

        /// <summary>
        /// "парсит" строку команды
        /// </summary>
        private void ParseCommandString(string command)
        {
            string[] str = command.Split(' ');
            _args[0] = str[0];
            if (str.Length > 1)
            {
                command = command.Substring(_args[0].Length);
                if (command.Contains('>'))
                {
                    string[] str2 = command.Split('>');
                    _args[1] = str2[0].Trim();
                    _args[2] = str2[1].Trim();
                }
                else
                {
                    _args[1] = command.Trim();
                }
            }
        }

        /// <summary>
        /// Возвращает справку по всем командам
        /// </summary>
        /// <returns></returns>
        public static string CommandsInfo()
        {
            foreach (ICommands com in _commands)
                return com.CommandInfo();
            return "";
        }
    }
}
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TaskManagerCommandsLib.Commands
{
    public class Help : ICommands
    {
        public string CommandInfo()
        {
            return "Возвращает список доступных команд";
        }
        Dictionary<string, string> _commands = new Dictionary<string, string>()
        {
            {"Help", "Help" },
            {"help", "Help" },
            {"!Help", "Help" },
            {"!help", "Help" },
        };

        public Dictionary<string, string> CommandName()
        {
            return _commands;
        }

        public string Execute(string[] args)
        {
            string str = $"______________________________________________Список команд______________________________________________\n\n" +
                $"SP -                          Возвращает список запущенных процессов с id  и именем\n" +
                $"Help -                        Возвращает список доступных команд\n" +
                $"KP + id или имя процесса -    По id - закрытие конкретного процесса, по имени - закрытие дерева процессов\n" +
                $"SP -                          Запускает нужное приложение из списка\n" +
                $"Clear -                       Отчистка экрана\n" +
                $"Exit -                        Завершение выполнения программы\n\n" +
                $"_________________________________________________________________________________________________________";
            return str;
        }
    }
}

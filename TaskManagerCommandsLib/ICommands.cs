using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TaskManagerCommandsLib
{
    internal interface ICommands
    {
        /// <summary>
        /// Метод выполнить
        /// </summary>
        string Execute(string[] args);
        /// <summary>
        /// Описание команд
        /// </summary>
        /// <returns></returns>
        string CommandInfo();
        /// <summary>
        /// Словарь наименований
        /// </summary>
        /// <returns></returns>
        Dictionary<string, string> CommandName();
    }
}

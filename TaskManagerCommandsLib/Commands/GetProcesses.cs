using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TaskManagerCommandsLib.Commands
{
    public class GetProcesses : ICommands
    {
        public string CommandInfo()
        {
            return "Возвращает список запущенных процессов с id  и именем";
        }
        Dictionary<string, string> _commands = new Dictionary<string, string>()
        {
            {"GetProcesses", "GetProcesses" },
            {"GP", "GetProcesses" },
            {"getprocesses", "GetProcesses" },
            {"gp", "GetProcesses" },
        };

        public Dictionary<string, string> CommandName()
        {
            return _commands;
        }

        public string Execute(string[] args)
        {
            string str = "";
            try
            {
                Process[] procList = Process.GetProcesses();
                foreach (Process proc in procList)
                {
                    str += proc.Id.ToString() + "\t" + proc.ProcessName.ToString() + "\n";
                }
            }
            catch (Exception ex)
            {
                str = ex.Message;
            }
            return str;
        }
    }
}

using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TaskManagerCommandsLib.Commands
{
    public class GPNAME : ICommands
    {
        public string CommandInfo()
        {
            return "возвращает имена процессов";
        }
        Dictionary<string, string> _commands = new Dictionary<string, string>()
        {
            {"GPNAME", "GPNAME" }
        };

        public Dictionary<string, string> CommandName()
        {
            return _commands;
        }

        public string Execute(string[] args)
        {
            string pName = "";
            Process[] procList = Process.GetProcesses();
            foreach (Process proc in procList)
            {
                pName += proc.ProcessName.ToString() + '\\';
            }
            return pName;
        }
    }
}

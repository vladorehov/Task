using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TaskManagerCommandsLib.Commands
{
    public class GPID : ICommands
    {
        public string CommandInfo()
        {
            return "возвращает id процессов";
        }
        Dictionary<string, string> _commands = new Dictionary<string, string>()
        {
            {"GPID", "GPID" }
        };

        public Dictionary<string, string> CommandName()
        {
            return _commands;
        }

        public string Execute(string[] args)
        {
            Process[] procList = Process.GetProcesses();
            string pid = "";
            foreach (Process proc in procList)
            {
                pid += proc.Id.ToString() + ' ';
            }
            return pid;
        }
    }
}

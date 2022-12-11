using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TaskManagerCommandsLib.Commands
{
    public class KillProcess : ICommands
    {
        public string CommandInfo()
        {
            return "Закрытие процессов";
        }
        Dictionary<string, string> _commands = new Dictionary<string, string>()
        {
            {"KillProcess", "KillProcess"},
            {"killprocess", "KillProcess"},
            {"KP", "KillProcess"},
            {"kp", "KillProcess"},
        };

        public Dictionary<string, string> CommandName()
        {
            return _commands;
        }

        public string Execute(string[] args)
        {
            string successful = "";
            if (args[1] != null)
            {
                try
                {
                    Process[] procList = Process.GetProcesses();
                    foreach (Process proc in procList)
                    {
                        if (args[1] == proc.Id.ToString())
                        {
                            proc.Kill();
                            successful = "Процесс завершен";
                            break;
                        }
                        else if (args[1] == proc.ProcessName.ToString())
                        {
                            proc.Kill();
                            successful = "Процесс завершен";
                        }
                        else
                            successful = "Введите ID или имя процесса!";
                    }
                }
                catch (Exception ex)
                {
                    successful = ex.Message;
                }
            }
            else
            {
                successful = "Введите ID или имя процесса!";
            }
            return successful;
        }
    }
}

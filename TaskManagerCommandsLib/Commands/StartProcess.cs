using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TaskManagerCommandsLib.Commands
{
    public class StartProcess : ICommands
    {
        private string _stringAppsName = "";
        private string _stringAppsPath = "";
        private string[] _appsName = new string[5];
        private string[] _appsPath = new string[5];
        private string[] _str = new string[10];

        public string CommandInfo()
        {
            return "Запускает нужное приложение из списка";
        }
        Dictionary<string, string> _commands = new Dictionary<string, string>()
        {
            {"StartProcess","StartProcess" },
            {"startprocess","StartProcess" },
            {"SP","StartProcess" },
            {"sp","StartProcess" }
        };

        public Dictionary<string, string> CommandName()
        {
            return _commands;
        }

        private void ParseApplicationsString()
        {
            if (File.Exists("APPS.txt"))
            {
                StreamReader reader = new StreamReader("APPS.txt");
                _str = reader.ReadToEnd().Split('\t');
            }
            else
            {
                using (StreamWriter sw = File.CreateText("APPS.txt"))
                {
                    sw.Write("NotePad\tnotepad\tPaint\tmspaint");
                }
                StreamReader reader = new StreamReader("APPS.txt");
                _str = reader.ReadToEnd().Split('\t');
            }

            string[] appsName = new string[_str.Length / 2];
            string[] appsPath = new string[_str.Length / 2];
            int j = 1;
            int g = 2;
            for (int i = 1; i <= _str.Length; i++)
            {
                if (i % 2 != 0)
                {
                    appsName[i - j] = _str[i - 1];
                    _appsName[i - j] = _str[i - 1];
                    j++;
                }
                else
                {
                    appsPath[i - g] = _str[i - 1];
                    _appsPath[i - g] = _str[i - 1];
                    g++;
                }
            }
        }

        public string[] ReturnAppsNames()
        {
            ParseApplicationsString();
            foreach (string aN in _appsName)
                _stringAppsName += aN + "\t";
            string[] appsName = _stringAppsName.Split('\t');
            return appsName;
        }

        public string Execute(string[] args)
        {
            string successful = "";
            ParseApplicationsString();
            try
            {
                foreach (string aN in _appsName)
                    _stringAppsName += aN + "\t";
                string[] appsName = _stringAppsName.Split('\t');
                foreach (string aN in _appsPath)
                    _stringAppsPath += aN + "\t";
                string[] appsPath = _stringAppsPath.Split('\t');
                for (int i = 0; i < appsName.Length; i++)
                {
                    if (appsName[i] == args[1])
                    {
                        Process.Start(appsPath[i]);
                        successful = "Приложение " + appsName[i] + " запущено";
                        break;
                    }
                    else
                    {
                        successful = "Приложение " + args[1] + " не найдено, список доступных приложений: \n";
                        foreach (string name in appsName)
                            successful += name + "\n";
                    }
                }
            }
            catch (Exception ex)
            {
                successful = ex.Message;
            }
            return successful;
        }
    }
}

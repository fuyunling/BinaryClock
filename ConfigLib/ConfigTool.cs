using System;
using System.Collections.Generic;
using System.IO;
using System.Text;

namespace ConfigLib
{
    public class ConfigTool
    {
        public static void CreateConfig(string configFile)
        {
            File.Create(configFile).Close();
        }

        public static void ExportConfig(string configFile, SortedList<string, object> configuration, string header)
        {
            if (!File.Exists(configFile))
            {
                CreateConfig(configFile);
            }

            StringBuilder sb = new StringBuilder();
            sb.AppendLine("[" + header + "]");
            foreach (string key in configuration.Keys)
            {
                sb.AppendLine(key + "=" + configuration[key]);
            }
            sb.AppendLine(string.Empty);

            File.AppendAllText(configFile, sb.ToString());
        }

        public static void ExportConfig(string configFile, SortedList<string, SortedList<string, object>> configuration)
        {
            if (!File.Exists(configFile))
            {
                CreateConfig(configFile);
            }

            string s = "";
            foreach (string k in configuration.Keys)
            {
                s += "[" + k + "]\n";
                foreach (string kk in configuration[k].Keys)
                {
                    s += kk + "=" + configuration[k][kk] + "\n";
                }
                s += "\n";
            }
            File.AppendAllText(configFile, s);
        }

        public static SortedList<string, SortedList<string, object>> ImportConfig(string configFile)
        {
            if (!File.Exists(configFile))
            {
                return null;
            }

            string[] lines = File.ReadAllLines(configFile);
            SortedList<string, SortedList<string, object>> conf = new SortedList<string, SortedList<string, object>>();
            string key = string.Empty;
            SortedList<string, object> sl = new SortedList<string, object>();
            foreach (string line in lines)
            {
                if (line.StartsWith("[") && line.EndsWith("]"))
                {
                    conf.Add(key, sl);
                    key = line.Substring(1, line.Length - 2);
                    sl = new SortedList<string, object>();
                }
                else if (line.Contains("="))
                {
                    string[] field = line.Split('=');
                    sl.Add(field[0].Trim(), field[1].Trim());
                }
            }
            if (!conf.ContainsKey(key))
            {
                conf.Add(key, sl);
            }
            conf.RemoveAt(0);

            return conf;
        }

        public static SortedList<string, object> ImportConfig(string configFile, string header)
        {
            if (!File.Exists(configFile))
            {
                return null;
            }

            string lines = File.ReadAllText(configFile);
            int idx = lines.IndexOf("[" + header + "]") + header.Length + 2;
            lines = lines.Substring(idx);
            idx = lines.IndexOf("[");
            if (idx > 0)
            {
                lines = lines.Substring(0, idx);
            }
            string[] lineArray = lines.Split(new char[] { '\n' },  StringSplitOptions.RemoveEmptyEntries);
            SortedList<string, object> conf = new SortedList<string, object>();
            foreach (string line in lineArray)
            {
                if (line.Contains("="))
                {
                    string[] field = line.Split('=');
                    conf.Add(field[0].Trim(), field[1].Trim());
                }
            }

            return conf;
        }

        public static void SaveAll(string file, string content, bool isAppend)
        {
            if (!File.Exists(file))
            {
                File.Create(file);
            }

            if (isAppend)
            {
                File.AppendAllText(file, content);
            }
            else
            {
                File.WriteAllText(file, content);
            }
        }

        public static string ReadAll(string file)
        {
            if (!File.Exists(file))
            {
                return string.Empty;
            }

            return File.ReadAllText(file);
        }

        public static bool ConfigExits(string configFile)
        {
            return File.Exists(configFile);
        }
    }
}

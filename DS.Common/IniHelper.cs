using System.IO;
using System.Text.RegularExpressions;

namespace DS.Common
{
    public class IniHelper
    {
        private string iniFile;
        public static System.Text.Encoding Encoding = System.Text.Encoding.UTF8;
        public IniHelper()
        {

        }
        public IniHelper(string file)
        {
            this.iniFile = file;
        }
        /// <summary>
        /// 批量读取键值对
        /// </summary>
        /// <returns>返回INI配置结构体列表,单独结构可以通过索引获取或设置</returns>
        public System.Collections.Generic.List<IniStruct> ReadValues()
        {
            return ReadValues(this.iniFile);
        }
        public string ReadValue(string key, string section)
        {
            string comments = "";
            return ReadValue(this.iniFile, key, section, ref comments);
        }
        public string ReadValue(string key, string section, ref string comments)
        {
            if (string.IsNullOrEmpty(this.iniFile)) throw new System.Exception("没有设置文件路径");
            return ReadValue(this.iniFile, key, section, ref comments);
        }
        public static string ReadValue(string file, string key, string section)
        {
            string comments = "";
            return ReadValue(file, key, section, ref comments);
        }
        private static string GetText(string file)
        {
            string content = File.ReadAllText(file);
            if (content.Contains("�"))
            {
                Encoding = System.Text.Encoding.GetEncoding("GBK");
                content = File.ReadAllText(file, System.Text.Encoding.GetEncoding("GBK"));
            }
            return content;
        }
        public static string ReadValue(string file, string key, string section, ref string comments)
        {
            string valueText = "";
            string content = GetText(file);
            if (!string.IsNullOrEmpty(section)) //首先遍历节点
            {
                MatchCollection matches = new Regex(@"\[\s*(?'section'[^\[\]\s]+)\s*\]").Matches(content);
                if (matches.Count <= 0) return "";
                Match currMatch = null;
                Match tailMatch = null;
                foreach (Match match in matches)
                {
                    string match_section = match.Groups["section"].Value;
                    if (match_section.ToLower() == section.ToLower())
                    {
                        currMatch = match;
                        continue;
                    }
                    else if (currMatch != null)
                    {
                        tailMatch = match;
                        break;
                    }

                }
                valueText = content.Substring(currMatch.Index + currMatch.Length, (tailMatch != null ? tailMatch.Index : content.Length) - currMatch.Index - currMatch.Length);//截取有效值域


            }
            else
                valueText = content;
            string[] lines = valueText.Split(new string[] { "\r\n" }, System.StringSplitOptions.None);
            foreach (string line in lines)
            {
                if (string.IsNullOrEmpty(line) || line == "\r\n" || line.Contains("["))
                    continue;
                string valueLine = line;
                if (line.Contains(";"))
                {
                    string[] seqPairs = line.Split(';');
                    if (seqPairs.Length > 1)
                        comments = seqPairs[1].Trim();
                    valueLine = seqPairs[0];
                }
                string[] keyValuePairs = valueLine.Split('=');
                string line_key = keyValuePairs[0];
                string line_value = "";
                if (keyValuePairs.Length > 1)
                {
                    line_value = keyValuePairs[1];
                }
                if (key.ToLower().Trim() == line_key.ToLower().Trim())
                {
                    return line_value;
                }
            }
            return "";
        }
        public static System.Collections.Generic.List<IniStruct> ReadValues(string file)
        {
            System.Collections.Generic.List<IniStruct> iniStructList = new System.Collections.Generic.List<IniStruct>();
            string content = GetText(file);
            System.Text.RegularExpressions.MatchCollection matches = new System.Text.RegularExpressions.Regex(@"\[\s*(?'section'[^\[\]\s]+)\s*\](?'valueContent'[^\[\]]*)").Matches(content);
            foreach (System.Text.RegularExpressions.Match match in matches)
            {
                IniStruct iniStruct = new IniStruct();
                string match_section = match.Groups["section"].Value;
                string match_value = match.Groups["valueContent"].Value;
                iniStruct.Section = match_section;

                string[] lines = match_value.Split(new string[] { "\r\n" }, System.StringSplitOptions.None);
                foreach (string line in lines)
                {
                    if (string.IsNullOrEmpty(line) || line == "\r\n" || line.Contains("["))
                        continue;
                    string comments = "";//注释
                    string valueLine = line;
                    if (line.Contains(";"))
                    {
                        string[] seqPairs = line.Split(';');
                        if (seqPairs.Length > 1)
                            comments = seqPairs[1].Trim();
                        valueLine = seqPairs[0];
                    }
                    string[] keyValuePairs = valueLine.Split('=');
                    string line_key = keyValuePairs[0];
                    string line_value = "";
                    if (keyValuePairs.Length > 1)
                    {
                        line_value = keyValuePairs[1];
                    }
                    iniStruct.Add(line_key, line_value, comments);
                }
                iniStructList.Add(iniStruct);
            }

            return iniStructList;
        }
        public void Write(string section, string key, string value)
        {
            Write(section, key, value, null);
        }
        public void Write(string section, string key, string value, string comment)
        {
            Write(this.iniFile, section, key, value, comment);
        }
        public static void Write(string file, string section, string key, string value, string comment)
        {
            bool isModified = false;
            System.Text.StringBuilder stringBuilder = new System.Text.StringBuilder();
            string content = GetText(file);
            System.Text.StringBuilder newValueContent = new System.Text.StringBuilder();
            #region 写入了节点
            if (!string.IsNullOrEmpty(section))
            {
                string pattern = string.Format(@"\[\s*{0}\s*\](?'valueContent'[^\[\]]*)", section);
                MatchCollection matches = new Regex(pattern).Matches(content);
                if (matches.Count <= 0)
                {
                    stringBuilder.AppendLine(string.Format("[{0}]", section)); //检查节点是否存在
                    stringBuilder.AppendLine(string.Format("{0}={1}{2}", key, value, !string.IsNullOrEmpty(comment) ? (";" + comment) : ""));
                    stringBuilder.AppendLine(content);
                    isModified = true;
                }
                else
                {
                    Match match = matches[0];
                    string valueContent = match.Groups["valueContent"].Value;
                    string[] lines = valueContent.Split(new string[] { "\r\n" }, System.StringSplitOptions.None);

                    newValueContent.AppendLine(string.Format("[{0}]", section));
                    foreach (string line in lines)
                    {
                        if (string.IsNullOrEmpty(line) || line == "\r\n" || line.Contains("["))
                        {
                            continue;
                        }

                        string valueLine = line;
                        string comments = "";
                        if (line.Contains(";"))
                        {
                            string[] seqPairs = line.Split(';');
                            if (seqPairs.Length > 1)
                                comments = seqPairs[1].Trim();
                            valueLine = seqPairs[0];
                        }
                        string[] keyValuePairs = valueLine.Split('=');
                        string line_key = keyValuePairs[0];
                        string line_value = "";
                        if (keyValuePairs.Length > 1)
                        {
                            line_value = keyValuePairs[1];
                        }
                        if (key.ToLower().Trim() == line_key.ToLower().Trim())
                        {
                            isModified = true;
                            newValueContent.AppendLine(string.Format("{0}={1}{2}", key, value, !string.IsNullOrEmpty(comment) ? (";" + comment) : ""));
                        }
                        else
                        {
                            newValueContent.AppendLine(line);
                        }


                    }
                    if (!isModified)
                        newValueContent.AppendLine(string.Format("{0}={1}{2}", key, value, !string.IsNullOrEmpty(comment) ? (";" + comment) : ""));
                    string newVal = newValueContent.ToString();
                    content = content.Replace(match.Value, newVal);
                    stringBuilder.Append(content);

                }
            }
            #endregion
            #region 没有指明节点
            else
            {
                string valueText = "";
                //如果节点为空
                MatchCollection matches = new Regex(@"\[\s*(?'section'[^\[\]\s]+)\s*\](?'valueContent'[^\[\]]*)").Matches(content);
                if (matches.Count > 0)
                {
                    valueText = matches[0].Index > 0 ? content.Substring(0, matches[0].Index) : "";
                    string[] lines = valueText.Split(new string[] { "\r\n" }, System.StringSplitOptions.None);
                    foreach (string line in lines)
                    {
                        if (string.IsNullOrEmpty(line) || line == "\r\n" || line.Contains("["))
                        {
                            continue;
                        }

                        string valueLine = line;
                        string comments = "";
                        if (line.Contains(";"))
                        {
                            string[] seqPairs = line.Split(';');
                            if (seqPairs.Length > 1)
                                comments = seqPairs[1].Trim();
                            valueLine = seqPairs[0];
                        }
                        string[] keyValuePairs = valueLine.Split('=');
                        string line_key = keyValuePairs[0];
                        string line_value = "";
                        if (keyValuePairs.Length > 1)
                        {
                            line_value = keyValuePairs[1];
                        }
                        if (key.ToLower().Trim() == line_key.ToLower().Trim())
                        {
                            isModified = true;
                            newValueContent.AppendLine(string.Format("{0}={1}{2}", key, value, !string.IsNullOrEmpty(comment) ? (";" + comment) : ""));
                        }
                        else
                        {
                            newValueContent.AppendLine(line);
                        }


                    }
                    if (!isModified)
                        newValueContent.AppendLine(string.Format("{0}={1}{2}", key, value, !string.IsNullOrEmpty(comment) ? (";" + comment) : ""));
                    string newVal = newValueContent.ToString();
                    content = content.Replace(valueText, newVal);
                    stringBuilder.Append(content);
                }
                else
                {
                    stringBuilder.AppendLine(string.Format("{0}={1}{2}", key, value, !string.IsNullOrEmpty(comment) ? (";" + comment) : ""));
                }
            }
            #endregion
            System.IO.File.WriteAllText(file, stringBuilder.ToString(), Encoding);
        }
    }
}

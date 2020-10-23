using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading.Tasks;

namespace AmazonOnsitePrep
{
    public class ReOrderLogFiles
    {
        public ReOrderLogFiles()
        {

        }

        public string[] ReorderLogs(string[] logs)
        {
            if (logs == null || logs.Length == 0) return logs;

            List<string> result = new List<string>(logs.Length);
            List<string> numList = new List<string>();
            Regex regStr = new Regex(@"[a-zA-Z]$");
            Regex regNum = new Regex(@"[0-9]$");
            Dictionary<string, List<string>> dictWord = new Dictionary<string, List<string>>();
            //int startindex = 0;
            int endindex = logs.Length - 1;
            for (int i = 0; i < logs.Length; i++)
            {

                Match stringMatch = regStr.Match(logs[i]);
                Match numMatch = regNum.Match(logs[i]);

                if (stringMatch.Success)
                {
                    var indexOfSpace = logs[i].IndexOf(" ");
                    dictWord.Add(logs[i], new List<string>() { logs[i].Substring(0, indexOfSpace), logs[i].Substring(indexOfSpace).Trim().Replace(" ", "") });
                    //startindex++;
                }
                if (numMatch.Success)
                {
                    //Insert log at the end
                    numList.Add(logs[i]);
                }
            }

            var res = dictWord.OrderBy(x => x.Value[1]).ThenBy(x => x.Value[0]).Select(x => x.Key).ToList();

            foreach (var ele in res)
            {
                if (!result.Contains(ele))
                {
                    result.Add(ele);
                }

            }

            foreach (var ele in numList)
            {
                result.Add(ele);
            }


            return result.ToArray();
        }
    }
}

using System;
using System.Collections.Concurrent;
using System.Collections.Generic;
using System.Data;
using System.Globalization;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CalculateTool
{
    public class InitStore
    {
        public ConcurrentDictionary<string, int[]> Store { set; get; }
        public ConcurrentDictionary<string, int[]> ConstStore { set; get; }
        public ConcurrentDictionary<string, int[]> Store_Step3 { set; get; }
        public ConcurrentDictionary<string, int[]> Store_Step4 { set; get; }

        public static InitStore initstore = null;
        public static InitStore CrtStore()
        {
            if (initstore == null)
                initstore = new InitStore();
            else
            {
                initstore = null;
                initstore = new InitStore();
            }
            initstore.Store = new ConcurrentDictionary<string, int[]>();
            initstore.ConstStore = new ConcurrentDictionary<string, int[]>();
            initstore.Store_Step3 = new ConcurrentDictionary<string, int[]>();
            initstore.Store_Step4 = new ConcurrentDictionary<string, int[]>();
            return initstore;
        }
        /// <summary>
        /// 获得导入号码库
        /// </summary>
        /// <param name="strfilepath"></param>
        /// <returns></returns>
        public void  GetStoreFromFile(string strfilepath)
        {
            initstore.Store.Clear();
            List<string> content = File.ReadAllLines(strfilepath, Encoding.Default).ToList();
            Parallel.ForEach(content, line =>
            {
                if (!string.IsNullOrEmpty(line))
                {
                    string[] nums = line.Split(' ');
                    int[] value = new int[nums.Length];
                    for (int i = 0; i < nums.Length; i++)
                    {
                        value[i] = Convert.ToInt32(nums[i]);
                    }
                    initstore.Store.TryAdd(line, value);
                }
            });
        }

        /// <summary>
        /// 获取数组
        /// </summary>
        /// <param name="nlength"></param>
        /// <returns></returns>
        public int[] GetArr(int nlength)
        {
            int[] arr = new int[nlength];
            for (int j = 0; j < arr.Length; j++)
            {
                arr[j] = j;
            }
            return arr;
        }

        public int[] GetArr(DataTable dt, int length)
        {
            int[] arr = new int[length];
            for (int i = 0; i < length; i++)
            {
                arr[i] = Convert.ToInt32(dt.Rows[i][0]);
            }
            return arr;
        }

        public int[] GetArr2_2(int nlength)
        {
            int[] arr = new int[nlength];
            for (int j = 2; j < arr.Length + 2; j++)
            {
                arr[j - 2] = j;
            }
            return arr;
        }

        public string ExportResult()
        {
            string strpath = System.Windows.Forms.Application.StartupPath + "\\分析结果";
            if (!Directory.Exists(strpath))
                Directory.CreateDirectory(strpath);

            string tradeTime = DateTime.Now.ToString("yyyyMMddHHmmss", DateTimeFormatInfo.InvariantInfo);
            string fullpath = strpath + "\\计算结果" + tradeTime + ".txt";

            FileStream fs = new FileStream(fullpath, FileMode.Create);
            StreamWriter sw = new StreamWriter(fs);
            foreach (var item in initstore.Store)
            {
                sw.Write(item.Key + "\r\n");
            }
            //清空缓冲区
            sw.Flush();
            //关闭流
            sw.Close();
            fs.Close();
            return fullpath;
        }

        /// <summary>
        /// 获得14位号码组
        /// </summary>
        /// <param name="strfilepath"></param>
        /// <returns></returns>
        public string[] GetNumsFromFile(string strfilepath)
        {
            List<string> lstcontent = new List<string>();
            string[] content = File.ReadAllLines(strfilepath, Encoding.Default);
            foreach (var line in content)
            {
                if(!string.IsNullOrEmpty(line.Trim()))
                    lstcontent.Add(line.TrimStart().TrimEnd());
            }
            return lstcontent.ToArray();
        }
    }
}

using System;
using System.Collections.Concurrent;
using System.Collections.Generic;
using System.Data;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace CalculateTool
{
    class Step2:Step1
    {
        //2.25命中
        public ConcurrentDictionary<string, int[]> ComStore_225 { set; get; }
        //2.5命中
        public ConcurrentDictionary<string, int[]> ComStore_25 { set; get; }
        //2.75命中
        public ConcurrentDictionary<string, int[]> ComStore_275 { set; get; }

        public ConcurrentDictionary<int,List<DataTable>> OrderTables { set; get; }

        public ConcurrentDictionary<string, int[]> Base_Store { set; get; }

        //2.25倒序排序
        public DataTable Dt_225 { set; get; }
        //2.5倒序排序
        public DataTable Dt_25 { set; get; }
        //2.75倒序排序
        public DataTable Dt_275 { set; get; }

        private static InitStore store = null;


        public static Step2 step2 = null;
        public static Step2 CrtStep2(InitStore initstore)
        {
            if (step2 == null)
                step2 = new Step2();
            else
            {
                step2 = null;
                step2 = new Step2();
            }
            step2.ComStore_225 = new ConcurrentDictionary<string, int[]>();
            step2.ComStore_25 = new ConcurrentDictionary<string, int[]>();
            step2.ComStore_275 = new ConcurrentDictionary<string, int[]>();
            step2.Dt_225 = new DataTable();
            step2.Dt_25 = new DataTable();
            step2.Dt_275 = new DataTable();
            step2.Base_Store = new ConcurrentDictionary<string, int[]>();
            step2.OrderTables = new ConcurrentDictionary<int, List<DataTable>>();
            store = initstore;
            return step2;
        }


        /// <summary>
        /// 根据命中过滤
        /// </summary>
        /// <param name="dhits">命中率</param>
        /// <param name="diccom">字典对象</param>
        /// <param name="Selnos">选择的号码组</param>
        /// <param name="strtype">类型</param>
        public void Filterbyhit(double dhits,string[] Selnos, string strtype)
        {
            if(step2.ComStore_225.Count > 0)
                step2.ComStore_225.Clear();

            if (step2.ComStore_25.Count > 0)
                step2.ComStore_25.Clear();

            if (step2.ComStore_275.Count > 0)
                step2.ComStore_275.Clear();

            Parallel.ForEach(step2.Base_Store, item =>
            {
                //命中次数
                int nhittimes = 0;
                foreach (int nno in item.Value)
                {
                    string strno = nno.ToString().PadLeft(2, '0');
                    foreach (var selno in Selnos)
                    {
                        if (Convert.ToString(selno).Contains(strno))
                            Interlocked.Increment(ref nhittimes);
                    }
                }
                if (dhits * Selnos.Length == nhittimes)
                {
                    switch (strtype)
                    {
                        case "2.25":
                            step2.ComStore_225.TryAdd(item.Key, item.Value);
                            break;
                        case "2.5":
                            step2.ComStore_25.TryAdd(item.Key, item.Value);
                            break;
                        case "2.75":
                            step2.ComStore_275.TryAdd(item.Key, item.Value);
                            break;
                    }
                }
            });
        }

        /// <summary>
        /// 获取统计表
        /// </summary>
        /// <param name="nno"></param>
        /// <param name="ComStore"></param>
        /// <param name="dt"></param>
        /// <returns></returns>
        public DataTable GetProTable(ConcurrentDictionary<string, int[]> ComStore)
        {
            DataTable dt = new DataTable();
            dt = InitDt(dt);
            for (int i = 1; i <= 33; i++)
            {
                string strno = i.ToString().PadLeft(2, '0');
                DataRow row = dt.NewRow();
                var rows = (from r in ComStore where r.Key.Contains(strno) select r).ToList();
                row[0] = strno;
                row[1] = rows.Count;
                dt.Rows.Add(row);
            }
            dt = GetOrderRows(dt);
            return dt;
        }

        /// <summary>
        /// 初始化table
        /// </summary>
        /// <param name="dt"></param>
        /// <returns></returns>
        private DataTable InitDt(DataTable dt)
        {
            if (dt.Columns.Count == 0)
            {
                dt.Columns.Add("no");
                dt.Columns.Add("times");
            }
            dt.Columns["times"].DataType = typeof(int);
            return dt;
        }

        /// <summary>
        /// 获取倒序号码
        /// </summary>
        /// <param name="dt"></param>
        /// <returns></returns>
        private DataTable GetOrderRows(DataTable dt)
        {
            DataView dv = dt.DefaultView;
            dt.DefaultView.Sort = "times ASC,no desc";
            return dv.ToTable();
        }

        /// <summary>
        /// 获得导入号码库
        /// </summary>
        /// <param name="strfilepath"></param>
        /// <returns></returns>
        public void GetBaseStoreFromFile(string strfilepath)
        {
            step2.Base_Store.Clear();
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
                    step2.Base_Store.TryAdd(line, value);
                }
            });
        }
    }
}

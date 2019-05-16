using System;
using System.Collections.Concurrent;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CalculateTool
{
    class Step3:Step2
    {
        //15选1组合库
        public ConcurrentDictionary<string, int[]> ComStore15_1 { set; get; }
        //15选2组合库
        public ConcurrentDictionary<string, int[]> ComStore15_2 { set; get; }
        //15选3组合库
        public ConcurrentDictionary<string, int[]> ComStore15_3 { set; get; }
        //15选4组合库
        public ConcurrentDictionary<string, int[]> ComStore15_4 { set; get; }
        //15选5组合库
        public ConcurrentDictionary<string, int[]> ComStore15_5 { set; get; }
        //15选6组合库
        public ConcurrentDictionary<string, int[]> ComStore15_6 { set; get; }
        public static Step3 step3 = null;
        private static InitStore store = null;
        public static Step3 CrtStep3(InitStore initstore)
        {
            if (step3 == null)
                step3 = new Step3();
            else
            {
                step3 = null;
                step3 = new Step3();
            }
            step3.ComStore15_1 = new ConcurrentDictionary<string, int[]>();
            step3.ComStore15_2 = new ConcurrentDictionary<string, int[]>();
            step3.ComStore15_3 = new ConcurrentDictionary<string, int[]>();
            step3.ComStore15_4 = new ConcurrentDictionary<string, int[]>();
            step3.ComStore15_5 = new ConcurrentDictionary<string, int[]>();
            step3.ComStore15_6 = new ConcurrentDictionary<string, int[]>();
            store = initstore;
            return step3;
        }

        public void Filter(int nlow,int nup,DataTable dt)
        {
            FilterStore_Notcontains(nlow, dt);
            SetCom15(dt);
            FilterStore_Larger(nup);
        }


        /// <summary>
        /// 先排除不包含任意一个的
        /// </summary>
        private void FilterStore_Notcontains(int nlow,DataTable dt)
        {
            int[] value = null;
            bool bfindflg = false;
            if (nlow == 0)
                return;
            if (nlow == 1)
            {
                //先排除不包含任意一个号码的
                foreach (var item in store.Store)
                {
                    bfindflg = false;
                    for (int i = 0; i < 15; i++)
                    {
                        if (item.Key.Contains(Convert.ToString(dt.Rows[i][0])))
                        {
                            bfindflg = true;
                            break;
                        }
                    }
                    if (!bfindflg)
                    {
                        store.Store.TryRemove(item.Key, out value);
                    }
                }
            }

            if (nlow == 2)
            {
                //先排除不包含任意一个号码的
                foreach (var item in store.Store)
                {
                    bfindflg = false;
                    for (int i = 0; i < 15; i++)
                    {
                        if (item.Key.Contains(Convert.ToString(dt.Rows[i][0])))
                        {
                            bfindflg = true;
                            break;
                        }
                    }
                    if (!bfindflg)
                    {
                        store.Store.TryRemove(item.Key, out value);
                    }
                }
                string strno = "";
                int nfindcount = 0;
                //再排除只包含一个号码的
                foreach (var item in store.Store)
                {
                    nfindcount = 0;
                    for (int i = 0; i < item.Value.Length; i++)
                    {
                        strno = item.Value[i].ToString().PadLeft(2, '0');
                        for (int j = 0; j < 15; j++)
                        {
                            if (strno == Convert.ToString(dt.Rows[j][0]))
                            {
                                nfindcount++;
                                if(nfindcount > 1)
                                    break;
                            }
                        }
                        if (nfindcount > 1)
                            break;
                    }

                    if (nfindcount == 1)
                    {
                        store.Store.TryRemove(item.Key, out value);
                    }
                }
            }
        }

        /// <summary>
        /// 排除比自己大的
        /// </summary>
        /// <param name="nnum"></param>
        private void FilterStore_Larger(int nnum)
        {
            int[] temp = null;
            for (int i = 6; i > nnum; i--)
            {
                //上限为6时不需要做任何操作
                switch (i)
                {
                    case 5:
                        FinallFilter(ComStore15_5, 5);
                        break;
                    case 4:
                        FinallFilter(ComStore15_4, 4);
                        break;
                    case 3:
                        FinallFilter(ComStore15_3, 3);
                        break;
                    case 2:
                        FinallFilter(ComStore15_2, 2);
                        break;
                    case 1:
                        foreach (var item in step3.ComStore15_1)
                        {
                            var keys = (from r in Store where r.Key.Contains(item.Key) select r).ToList();
                            foreach (var key in keys)
                            {
                                store.Store.TryRemove(key.Key, out temp);
                            }
                        }
                        break;
                }
            }
        }


        /// <summary>
        /// 初始化15选1-6的组合
        /// </summary>
        /// <param name="dt"></param>
        private void SetCom15(DataTable dt)
        {
            int[] arr = GetArr(dt, 15);
            step3.ComStore15_1.Clear();
            step3.ComStore15_2.Clear();
            step3.ComStore15_3.Clear();
            step3.ComStore15_4.Clear();
            step3.ComStore15_5.Clear();
            step3.ComStore15_6.Clear();
            //计算15选1-6的所有组合
            for (int i = 1; i < 7; i++)
            {
                //求组合
                List<int[]> lstCombination = PermutationAndCombination<int>.GetCombination(arr, i);

                switch (i)
                {
                    case 1:
                        SetCom(lstCombination, false, step3.ComStore15_1);
                        break;
                    case 2:
                        SetCom(lstCombination, false, step3.ComStore15_2);
                        break;
                    case 3:
                        SetCom(lstCombination, false, step3.ComStore15_3);
                        break;
                    case 4:
                        SetCom(lstCombination, false, step3.ComStore15_4);
                        break;
                    case 5:
                        SetCom(lstCombination, false, step3.ComStore15_5);
                        break;
                    case 6:
                        SetCom(lstCombination, false, step3.ComStore15_6);
                        break;
                }
            }
        }

        /// <summary>
        /// 设置初始集合
        /// </summary>
        /// <param name="lstCombination"></param>
        /// <param name="isMT"></param>
        /// <param name="dic"></param>
        /// <returns></returns>
        private ConcurrentDictionary<string, int[]> SetCom(List<int[]> lstCombination, bool isMT, ConcurrentDictionary<string, int[]> dic)
        {
            lstCombination.Reverse();
            //大数据量开启多线程
            if (isMT)
            {
                Parallel.ForEach(lstCombination, items =>
                {
                    Array.Sort(items);
                    string temp = "";
                    foreach (var item in items)
                    {
                        temp += item.ToString().PadLeft(2, '0') + " ";
                    }
                    temp = temp.Substring(0, temp.Length - 1);
                    dic.TryAdd(temp, items);
                });

            }
            //小数据量关闭多线程减少系统开销
            else
            {
                foreach (var items in lstCombination)
                {
                    Array.Sort(items);
                    string temp = "";
                    foreach (var item in items)
                    {
                        temp += item.ToString().PadLeft(2, '0') + " ";
                    }
                    temp = temp.Substring(0, temp.Length - 1);
                    dic.TryAdd(temp, items);
                }
            }
            return dic;
        }

        /// <summary>
        /// 终极过滤
        /// </summary>
        /// <param name="dic"></param>
        private void FinallFilter(ConcurrentDictionary<string, int[]> dic, int length)
        {
            //先找到不存在的号码
            int[] arr = GetArr(33);
            List<int> lstnotexist = new List<int>();
            List<string> lsttemp = new List<string>();
            string strtemp = "";
            int[] outvalue = null;
            foreach (var item in dic)
            {
                for (int i = 1; i <= arr.Length; i++)
                {
                    if (!item.Value.Contains(i))
                    {
                        lstnotexist.Add(i);
                    }
                }
                //计算不存在的所有组合
                List<int[]> lstCombination = PermutationAndCombination<int>.GetCombination(lstnotexist.ToArray(), 6 - length);

                int[] nkeys = new int[6];
                //数组合并
                foreach (int[] value in lstCombination)
                {
                    nkeys = item.Value.Concat(value).ToArray();
                    Array.Sort(nkeys);
                    for (int k = 0; k < nkeys.Length; k++)
                    {
                        strtemp += nkeys[k].ToString().PadLeft(2, '0') + " ";
                    }
                    strtemp = strtemp.Substring(0, strtemp.Length - 1);
                    lsttemp.Add(strtemp);
                    strtemp = "";
                    lstnotexist.Clear();
                }
                Parallel.ForEach(lsttemp, key => { store.Store.TryRemove(key, out outvalue); });
                lsttemp.Clear();
            }
        }
    }
}

using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CalculateTool
{
    class Step5:Step4
    {
        public static Step5 step5 = null;
        private static InitStore store = null;
        public static Step5 CrtStep5(InitStore initstore)
        {
            if (step5 == null)
                step5 = new Step5();
            else
            {
                step5 = null;
                step5 = new Step5();
            }
            store = initstore;
            return step5;
        }


        /// <summary>
        /// 合并去重
        /// </summary>
        public void HybirdFilter(DataTable dt1,DataTable dt2)
        {
            //合并去重
            List<string> list = Merge_Step5(dt1,dt2);

            //满足5-6个的保留其余删除
            if (list.Count >= 31)
            {
                Filter(5, list);
            }

            //满足4-6个的保留其余删除
            if (list.Count >= 28 && list.Count <= 30)
            {
                Filter(4, list);
            }

            //满足3-6个保留其余删除
            if (list.Count <= 27)
            {
                Filter(3,list);
            }
        }

        /// <summary>
        /// 第三步的过滤
        /// </summary>
        /// <param name="lstCombination"></param>
        /// <param name="length"></param>
        private void Filter(int Count,List<string> list)
        {
            int ncount = 0;
            bool bfindflg = false;
            int[] value = null;
            foreach (var item in store.Store)
            {
                ncount = 0;
                bfindflg = false;
                string[] temp = item.Key.Split(' ');
                foreach (string no in temp)
                {
                    if (list.Contains(no))
                    {
                        ncount++;
                        if (ncount >= Count)
                        {
                            bfindflg = true;
                            break;
                        }
                    }
                }
                if (!bfindflg)
                    store.Store.TryRemove(item.Key, out value);
            }
        }

        private List<string> Merge_Step5(DataTable dt1,DataTable dt2)
        {
            string strno = "";
            List<string> list = new List<string>();
            for (int i = 0; i < 15; i++)
            {
                strno = Convert.ToString(dt1.Rows[i][0]);
                list.Add(strno);
            }

            for (int i = 0; i < 15; i++)
            {
                strno = Convert.ToString(dt2.Rows[i][0]);
                if (!list.Contains(strno))
                    list.Add(strno);
            }
            return list;
        }
    }
}

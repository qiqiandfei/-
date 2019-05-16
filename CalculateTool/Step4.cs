using System;
using System.Collections.Generic;
using System.Collections.Concurrent;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CalculateTool
{
    class Step4:Step3
    {
        private ConcurrentDictionary<int,List<string>> MergeNums { get; set; } 
        public static Step4 step4 = null;
        private static InitStore store = null;
        public static Step4 CrtStep4(InitStore initstore)
        {
            if (step4 == null)
                step4 = new Step4();
            else
            {
                step4 = null;
                step4 = new Step4();
            }
            store = initstore;
            return step4;
        }


        public List<string> Merge(DataTable dt1,DataTable dt2)
        {
            List<string> list = new List<string>();
            string strno = "";
            for (int i = 0; i < 15; i++)
            {
                strno = Convert.ToString(dt1.Rows[i][0]);
                list.Add(strno);
            }

            for (int i = 0; i < 15; i++)
            {
                strno = Convert.ToString(dt2.Rows[i][0]);
                list.Add(strno);
            }
            return list;
        }

        /// <summary>
        /// 第三步的过滤
        /// </summary>
        /// <param name="lstCombination"></param>
        /// <param name="length"></param>
        public void Filter(List<string> lstnums, int nlowlimit,int nuplimit)
        {
            int ncount = 0;

            int[] value = null;

            foreach (var item in store.Store)
            {
                ncount = 0;
                foreach (string no in lstnums)
                {
                    if (item.Key.Contains(no))
                    {
                        ncount++;
                    }
                }
                if (ncount < nlowlimit || ncount > nuplimit)
                {
                    store.Store.TryRemove(item.Key, out value);
                }
            }
        }
    }
}

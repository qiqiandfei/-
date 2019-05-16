using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CalculateTool
{
    class Step6:Step5
    {
        public static Step6 step6 = null;
        private static InitStore store = null;
        public static Step6 CrtStep6(InitStore initstore)
        {
            if (step6 == null)
                step6 = new Step6();
            else
            {
                step6 = null;
                step6 = new Step6();
            }
            store = initstore;
            return step6;
        }

        public void SubFilter(int nsublow1, int nsubup1, int nsublow2, int nsubup2, DataTable dt1,DataTable dt2,DataTable dt3)
        {
            List<string> list1 = GetNums(dt1);
            List<string> list2 = GetNums(dt2);
            List<string> list3 = GetNums(dt3);
            int[] value = null;
            bool bdelflg = false;
            foreach (var item in store.Store)
            {
                bdelflg = CalCount(nsublow1, nsubup1, nsublow2, nsubup2, item.Key,list1,list2,list3);
                if (!bdelflg)
                    store.Store.TryRemove(item.Key,out value);
            }
        }

        private List<string> GetNums(DataTable dt)
        {
            List<string> list = new List<string>();
            for (int i = 0; i < 15; i++)
            {
                list.Add(Convert.ToString(dt.Rows[i][0]));
            }
            return list;
        }

        private bool CalCount(int nsublow1, int nsubup1, int nsublow2, int nsubup2, string key,List<string> list1, List<string> list2, List<string> list3)
        {
            bool res = false;
            int count1 = 0;
            int count2 = 0;
            int count3 = 0;
            foreach (var item in list1)
            {
                if (key.Contains(item))
                    count1++;
            }
            foreach (var item in list2)
            {
                if (key.Contains(item))
                    count2++;
            }
            foreach (var item in list3)
            {
                if (key.Contains(item))
                    count3++;
            }

            int nsub1 = 0;
            int nsub2 = 0;
            nsub1 = count1 - count2;
            nsub2 = count2 - count3;
            if ((nsub1 >= nsublow1 && nsub1 <= nsubup1) && (nsub2 >= nsublow2 && nsub2 <= nsubup2))
                res = true;
            return res;
        }
    }
}

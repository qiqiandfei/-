using System;
using System.Collections.Generic;
using System.Collections.Concurrent;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace CalculateTool
{
    public class Step1:InitStore
    {
        public ConcurrentDictionary<int,string[]> Group { set; get; }
        public static Step1 step1 = null;

        public static Step1 CrtStep1()
        {
            if(step1 == null)
                step1 = new Step1();
            else
            {
                step1 = null;
                step1 = new Step1();
            }
            step1.Group = new ConcurrentDictionary<int, string[]>();
            return step1;
        }

        /// <summary>
        /// 将号码组合并分组
        /// </summary>
        /// <param name="nums"></param>
        /// <returns></returns>
        public void SetAllGroup(ListBox.ObjectCollection nums)
        {
            step1.Group.Clear();
            //获取组数计算组合
            int[] arr = GetArr(nums.Count);
            List<int[]> lstCombination = PermutationAndCombination<int>.GetCombination(arr, 4);

            int nIndex = 0;
            //根据下标将索引转换成号码组
            foreach (var item in lstCombination)
            {
                nIndex++;
                string[] value = new string[4];
                for (int i = 0; i < item.Length; i++)
                {
                    value[i] = Convert.ToString(nums[item[i]]);
                }
                step1.Group.TryAdd(nIndex, value);
            }
        }

        /// <summary>
        /// 将号码组合并分组
        /// </summary>
        /// <param name="nums"></param>
        /// <returns></returns>
        public void SetAllGroup3_1(ListBox.ObjectCollection nums)
        {
            step1.Group.Clear();
            string[] constgrp = new string[3];
            for (int i = 0; i < 3; i++)
            {
                constgrp[i] = Convert.ToString(nums[i]);
            }

            int nIndex = 1;
            for (int i = 3; i < nums.Count; i++)
            {
                string[] numsgrp = new string[4];
                numsgrp[0] = constgrp[0];
                numsgrp[1] = constgrp[1];
                numsgrp[2] = constgrp[2];
                numsgrp[3] = Convert.ToString(nums[i]);
                step1.Group.TryAdd(nIndex, numsgrp);
                nIndex++;
            }
        }

        /// <summary>
        /// 将号码组合并分组
        /// </summary>
        /// <param name="nums"></param>
        /// <returns></returns>
        public void SetAllGroup2_2(ListBox.ObjectCollection nums)
        {
            step1.Group.Clear();

            //获取组数计算组合
            int[] arr = GetArr2_2(nums.Count - 2);
            List<int[]> lstCombination = PermutationAndCombination<int>.GetCombination(arr, 2);

            int nIndex = 0;
            //根据下标将索引转换成号码组
            foreach (var item in lstCombination)
            {
                nIndex++;
                string[] value = new string[4];
                value[0] = Convert.ToString(nums[0]);
                value[1] = Convert.ToString(nums[1]);
                for (int i = 0; i < item.Length; i++)
                {
                    value[i + 2] = Convert.ToString(nums[item[i]]);
                }
                step1.Group.TryAdd(nIndex, value);
            }
        }
    }
}

using System;
using System.Collections.Concurrent;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Diagnostics;
using System.Drawing;
using System.Globalization;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace CalculateTool
{
    public partial class Form2 : Form
    {
        public static string strCurTip = "";
        private int nProcessvalue = 0;
        private CalculateTool.Step1 step1 = null;
        private CalculateTool.Step2 step2 = null;
        private CalculateTool.Step3 step3 = null;
        private CalculateTool.Step4 step4 = null;
        private CalculateTool.Step5 step5 = null;
        private CalculateTool.Step6 step6 = null;
        private InitStore store = null;
        private DataTable dtStore = null;
        private UIReFresher trf = null;
        private int nlowlimit = 0;
        private int nuplimit = 0;
        private int nrange1_up = 0;
        private int nrange2_up = 0;
        private int nrange3_up = 0;
        private int nrange1_low = 0;
        private int nrange2_low = 0;
        private int nrange3_low = 0;
        private string strBasePath = "";
        private int nsubup1 = 0;
        private int nsubup2 = 0;
        private int nsublow1 = 0;
        private int nsublow2 = 0;
        public Form2()
        {
            InitializeComponent();
        }

        private void btnSelBase_Click(object sender, EventArgs e)
        {
            if (this.openFileDialog.ShowDialog() == DialogResult.OK)
            {
                this.txtBasePath.Text = this.openFileDialog.FileName;
                if (Path.GetExtension(this.txtBasePath.Text.Trim()) != ".txt")
                {
                    MessageBox.Show("文件格式有误，请选择txt格式文件！", "提示");
                    this.txtBasePath.Text = "";
                }
                else
                {
                    strBasePath = this.txtBasePath.Text;
                }
            }
        }

        private void btnSelStore_Click(object sender, EventArgs e)
        {
            if (this.openFileDialog.ShowDialog() == DialogResult.OK)
            {
                this.txtPathStore.Text = this.openFileDialog.FileName;
                if (Path.GetExtension(this.txtPathStore.Text.Trim()) != ".txt")
                {
                    MessageBox.Show("文件格式有误，请选择txt格式文件！", "提示");
                    this.txtPathStore.Text = "";
                }
                else
                {
                    if (store == null)
                        store = InitStore.CrtStore();
                    store.GetStoreFromFile(this.txtPathStore.Text);
                    LoadDgv();
                    this.dataGridView.DataSource = dtStore;
                    this.dataGridView.Columns[0].AutoSizeMode = DataGridViewAutoSizeColumnMode.NotSet;
                    this.dataGridView.Columns[1].AutoSizeMode = DataGridViewAutoSizeColumnMode.Fill;
                    this.labnums.Text = dtStore.Rows.Count.ToString() + "组号码";
                    store.ConstStore.Clear();
                    Parallel.ForEach(store.Store, item => { store.ConstStore.TryAdd(item.Key, item.Value); });
                    MessageBox.Show("分步号码库导入成功！", "提示");

                }
            }
        }

        private void btnSel14_Click(object sender, EventArgs e)
        {
            if (this.openFileDialog.ShowDialog() == DialogResult.OK)
            {
                this.txtPath14.Text = this.openFileDialog.FileName;
                if (Path.GetExtension(this.txtPath14.Text.Trim()) != ".txt")
                {
                    MessageBox.Show("文件格式有误，请选择txt格式文件！", "提示");
                    this.txtPath14.Text = "";
                }
                else
                {
                    if (store == null)
                        store = CalculateTool.InitStore.CrtStore();
                    this.listBox.Items.Clear();
                    string[] nums = store.GetNumsFromFile(this.txtPath14.Text);
                    string temp = "";
                    foreach (var num in nums)
                    {
                        temp = num.TrimStart();
                        temp = num.TrimEnd();
                        string[] strsno = temp.Split(' ');
                        string strlistno = "";
                        for (int i = 0; i < strsno.Length; i++)
                        {
                            if (strsno[i].Length == 1)
                                strsno[i] = strsno[i].PadLeft(2, '0');
                            strlistno += strsno[i] + " ";
                        }
                        strlistno = strlistno.Substring(0, strlistno.Length - 1);
                        this.listBox.Items.Add(strlistno);
                    }
                    this.btnGroup.Enabled = true;
                }
            }
        }

        /// <summary>
        /// 第一步计算分组
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void btnGroup_Click(object sender, EventArgs e)
        {
            try
            {
                if (step1 == null)
                    step1 = CalculateTool.Step1.CrtStep1();
                string strErrmsg = Check();
                if (string.IsNullOrEmpty(strErrmsg))
                {
                    this.btnGroup.Enabled = false;
                    //第三步取值范围
                    nrange1_up = Convert.ToInt32(numRange1_up.Text);
                    nrange2_up = Convert.ToInt32(numRange2_up.Text);
                    nrange3_up = Convert.ToInt32(numRange3_up.Text);
                    nrange1_low = Convert.ToInt32(numRange1_low.Text);
                    nrange2_low = Convert.ToInt32(numRange2_low.Text);
                    nrange3_low = Convert.ToInt32(numRange3_low.Text);
                    //第四步平均下限
                    nlowlimit = (int)Convert.ToDouble(cmbLowLimit.Text) * 2;
                    nuplimit = (int)Convert.ToDouble(cmbUpLimit.Text) * 2;
                    //第五步

                    //第六步
                    nsubup1 = Convert.ToInt32(numSubUp1.Text);
                    nsubup2 = Convert.ToInt32(numSubUp2.Text);
                    nsublow1 = Convert.ToInt32(numSubLow1.Text);
                    nsublow2 = Convert.ToInt32(numSubLow2.Text);
                    AutoSelStore();
                    if(trf == null)
                        //业务开始
                        trf = new UIReFresher { UIRefresh = UIRefresh };
                    if (this.rad3_0.Checked)
                    {
                        Task start = new Task(Start3_0);
                        start.Start();
                    }

                    if (this.rad3_1.Checked)
                    {
                        Task start = new Task(Start3_1);
                        start.Start();
                    }

                    if (this.rad2_2.Checked)
                    {
                        Task start = new Task(Start2_2);
                        start.Start();
                    }
                }
                else
                {
                    MessageBox.Show(strErrmsg, "提示");
                }

            }
            catch (Exception exception)
            {
                MessageBox.Show("程序出现错误：" + exception, "提示");
            }
        }

        

        private void Start3_0()
        {
            DateTime TimeStart = DateTime.Now;
            
            step1.SetAllGroup(this.listBox.Items);
            List<string> list = new List<string>();
            step2 = null;
            step3 = null;
            step4 = null;
            step5 = null;
            step6 = null;
            int ntotal = step1.Group.Count * 10;
            int ncurr = 0;
            double dpercent = 0d;
            nProcessvalue = 0;
            foreach (var item in step1.Group)
            {
                if (store.Store.Count <= 1)
                {
                    strCurTip = "分步号码库号码组数<=1组，执行终止！";
                    nProcessvalue = 100;
                    trf.UIRefresh();
                    MessageBox.Show("程序执行终止:" + "共花费" + DateTime.Now.Subtract(TimeStart).TotalSeconds.ToString() + "秒！");
                    return;
                }
                if (step2 == null)
                {
                    step2 = CalculateTool.Step2.CrtStep2(store);
                    step2.GetBaseStoreFromFile(strBasePath);
                }
                strCurTip = "共有"+ step1.Group.Count.ToString() + "个分组，正在对第" + item.Key.ToString() + "个分组计算2.25平均......";
                trf.UIRefresh();
                step2.Filterbyhit(2.25, item.Value, "2.25");
                step2.Dt_225.Clear();
                step2.Dt_225 = step2.GetProTable(step2.ComStore_225);
                ncurr++;
                dpercent = (double)ncurr / (double)ntotal;
                nProcessvalue = (int)(dpercent * 100);
                trf.UIRefresh();

                strCurTip = "共有" + step1.Group.Count.ToString() + "个分组，正在对第" + item.Key.ToString() + "个分组计算2.5平均......";
                trf.UIRefresh();
                step2.Filterbyhit(2.5, item.Value, "2.5");
                step2.Dt_25.Clear();
                step2.Dt_25 = step2.GetProTable(step2.ComStore_25);
                ncurr++;
                dpercent = (double)ncurr / (double)ntotal;
                nProcessvalue = (int)(dpercent * 100);
                trf.UIRefresh();

                strCurTip = "共有" + step1.Group.Count.ToString() + "个分组，正在对第" + item.Key.ToString() + "个分组计算2.75平均......";
                trf.UIRefresh();
                step2.Filterbyhit(2.75, item.Value, "2.75");
                step2.Dt_275.Clear();
                step2.Dt_275 = step2.GetProTable(step2.ComStore_275);
                ncurr++;
                dpercent = (double)ncurr / (double)ntotal;
                nProcessvalue = (int)(dpercent * 100);
                trf.UIRefresh();
                //=====================第三步过滤开始============================
                if (step3 == null)
                    step3 = CalculateTool.Step3.CrtStep3(store);
                strCurTip = "共有" + step1.Group.Count.ToString() + "个分组，正在对第" + item.Key.ToString() + "组进行基于2.25的取值范围过滤......";
                trf.UIRefresh();
                step3.Filter(nrange1_low, nrange1_up, step2.Dt_225);
                ncurr++;
                dpercent = (double)ncurr / (double)ntotal;
                nProcessvalue = (int)(dpercent * 100);
                trf.UIRefresh();

                strCurTip = "共有" + step1.Group.Count.ToString() + "个分组，正在对第" + item.Key.ToString() + "组进行基于2.5的取值范围过滤......";
                trf.UIRefresh();
                step3.Filter(nrange2_low, nrange2_up, step2.Dt_25);
                ncurr++;
                dpercent = (double)ncurr / (double)ntotal;
                nProcessvalue = (int)(dpercent * 100);
                trf.UIRefresh();

                strCurTip = "共有" + step1.Group.Count.ToString() + "个分组，正在对第" + item.Key.ToString() + "组进行基于2.75的取值范围过滤......";
                trf.UIRefresh();
                step3.Filter(nrange3_low, nrange3_up, step2.Dt_275);
                ncurr++;
                dpercent = (double)ncurr / (double)ntotal;
                nProcessvalue = (int)(dpercent * 100);
                trf.UIRefresh();
                //======================第四步过滤开始============================
                if (step4 == null)
                    step4 = CalculateTool.Step4.CrtStep4(store);
                list.Clear();
                strCurTip = "共有" + step1.Group.Count.ToString() + "个分组，正在对第" + item.Key.ToString() + "组进行平均过滤......";
                trf.UIRefresh();
                ncurr++;
                dpercent = (double)ncurr / (double)ntotal;
                nProcessvalue = (int)(dpercent * 100);
                trf.UIRefresh();

                list = step4.Merge(step2.Dt_225, step2.Dt_275);
                step4.Filter(list, nlowlimit, nuplimit);
                ncurr++;
                dpercent = (double)ncurr / (double)ntotal;
                nProcessvalue = (int)(dpercent * 100);
                trf.UIRefresh();

                //======================第五步过滤开始============================
                if (step5 == null)
                    step5 = CalculateTool.Step5.CrtStep5(store);
                strCurTip = "共有" + step1.Group.Count.ToString() + "个分组，正在对第" + item.Key.ToString() + "组进行混合过滤......";
                trf.UIRefresh();
                step5.HybirdFilter(step2.Dt_225, step2.Dt_275);
                ncurr++;
                dpercent = (double)ncurr / (double)ntotal;
                nProcessvalue = (int)(dpercent * 100);
                trf.UIRefresh();

                //======================第六步过滤开始============================
                if (step6 == null)
                    step6 = CalculateTool.Step6.CrtStep6(store);
                strCurTip = "共有" + step1.Group.Count.ToString() + "个分组，正在对第" + item.Key.ToString() + "组进行相减过滤......";
                trf.UIRefresh();
                step6.SubFilter(nsublow1,nsubup1,nsublow2,nsubup2,step2.Dt_225, step2.Dt_25, step2.Dt_275);
                ncurr++;
                dpercent = (double)ncurr / (double)ntotal;
                nProcessvalue = (int)(dpercent * 100);
                trf.UIRefresh();
            }
            //更新grid
            LoadDgv();
            strCurTip = "执行成功！";
            nProcessvalue = 100;
            trf.UIRefresh();
            GC.Collect();
            GC.WaitForPendingFinalizers();
            double elapsedTimeInSeconds = DateTime.Now.Subtract(TimeStart).TotalSeconds;
            MessageBox.Show("执行成功:" + "共花费" + elapsedTimeInSeconds.ToString() + "秒！");
        }

        private void Start3_1()
        {
            DateTime TimeStart = DateTime.Now;
            step1.SetAllGroup3_1(this.listBox.Items);
            List<string> list = new List<string>();
            step2 = null;
            step3 = null;
            step4 = null;
            step5 = null;
            step6 = null;
            int ntotal = step1.Group.Count * 10;
            int ncurr = 0;
            double dpercent = 0d;
            nProcessvalue = 0;
            foreach (var item in step1.Group)
            {
                if (store.Store.Count <= 1)
                {
                    strCurTip = "分步号码库号码组数<=1组，执行终止！";
                    nProcessvalue = 100;
                    trf.UIRefresh();
                    MessageBox.Show("程序执行终止:" + "共花费" + DateTime.Now.Subtract(TimeStart).TotalSeconds.ToString() + "秒！");
                    return;
                }
                if (step2 == null)
                {
                    step2 = CalculateTool.Step2.CrtStep2(store);
                    step2.GetBaseStoreFromFile(strBasePath);
                }
                strCurTip = "共有" + step1.Group.Count.ToString() + "个分组，正在对第" + item.Key.ToString() + "个分组计算2.25平均......";
                trf.UIRefresh();
                step2.Filterbyhit(2.25, item.Value, "2.25");
                step2.Dt_225.Clear();
                step2.Dt_225 = step2.GetProTable(step2.ComStore_225);
                ncurr++;
                dpercent = (double)ncurr / (double)ntotal;
                nProcessvalue = (int)(dpercent * 100);
                trf.UIRefresh();

                strCurTip = "共有" + step1.Group.Count.ToString() + "个分组，正在对第" + item.Key.ToString() + "个分组计算2.5平均......";
                trf.UIRefresh();
                step2.Filterbyhit(2.5, item.Value, "2.5");
                step2.Dt_25.Clear();
                step2.Dt_25 = step2.GetProTable(step2.ComStore_25);
                ncurr++;
                dpercent = (double)ncurr / (double)ntotal;
                nProcessvalue = (int)(dpercent * 100);
                trf.UIRefresh();

                strCurTip = "共有" + step1.Group.Count.ToString() + "个分组，正在对第" + item.Key.ToString() + "个分组计算2.75平均......";
                trf.UIRefresh();
                step2.Filterbyhit(2.75, item.Value, "2.75");
                step2.Dt_275.Clear();
                step2.Dt_275 = step2.GetProTable(step2.ComStore_275);
                ncurr++;
                dpercent = (double)ncurr / (double)ntotal;
                nProcessvalue = (int)(dpercent * 100);
                trf.UIRefresh();
                //=====================第三步过滤开始============================
                if (step3 == null)
                    step3 = CalculateTool.Step3.CrtStep3(store);
                strCurTip = "共有" + step1.Group.Count.ToString() + "个分组，正在对第" + item.Key.ToString() + "组进行基于2.25的取值范围过滤......";
                trf.UIRefresh();
                step3.Filter(nrange1_low, nrange1_up, step2.Dt_225);
                ncurr++;
                dpercent = (double)ncurr / (double)ntotal;
                nProcessvalue = (int)(dpercent * 100);
                trf.UIRefresh();

                strCurTip = "共有" + step1.Group.Count.ToString() + "个分组，正在对第" + item.Key.ToString() + "组进行基于2.5的取值范围过滤......";
                trf.UIRefresh();
                step3.Filter(nrange2_low, nrange2_up, step2.Dt_25);
                ncurr++;
                dpercent = (double)ncurr / (double)ntotal;
                nProcessvalue = (int)(dpercent * 100);
                trf.UIRefresh();

                strCurTip = "共有" + step1.Group.Count.ToString() + "个分组，正在对第" + item.Key.ToString() + "组进行基于2.75的取值范围过滤......";
                trf.UIRefresh();
                step3.Filter(nrange3_low, nrange3_up, step2.Dt_275);
                ncurr++;
                dpercent = (double)ncurr / (double)ntotal;
                nProcessvalue = (int)(dpercent * 100);
                trf.UIRefresh();
                //======================第四步过滤开始============================
                if (step4 == null)
                    step4 = CalculateTool.Step4.CrtStep4(store);
                list.Clear();
                strCurTip = "共有" + step1.Group.Count.ToString() + "个分组，正在对第" + item.Key.ToString() + "组进行平均过滤......";
                trf.UIRefresh();
                ncurr++;
                dpercent = (double)ncurr / (double)ntotal;
                nProcessvalue = (int)(dpercent * 100);
                trf.UIRefresh();

                list = step4.Merge(step2.Dt_225, step2.Dt_275);
                step4.Filter(list, nlowlimit, nuplimit);
                ncurr++;
                dpercent = (double)ncurr / (double)ntotal;
                nProcessvalue = (int)(dpercent * 100);
                trf.UIRefresh();

                //======================第五步过滤开始============================
                if (step5 == null)
                    step5 = CalculateTool.Step5.CrtStep5(store);
                strCurTip = "共有" + step1.Group.Count.ToString() + "个分组，正在对第" + item.Key.ToString() + "组进行混合过滤......";
                trf.UIRefresh();
                step5.HybirdFilter(step2.Dt_225, step2.Dt_275);
                ncurr++;
                dpercent = (double)ncurr / (double)ntotal;
                nProcessvalue = (int)(dpercent * 100);
                trf.UIRefresh();

                //======================第六步过滤开始============================
                if (step6 == null)
                    step6 = CalculateTool.Step6.CrtStep6(store);
                strCurTip = "共有" + step1.Group.Count.ToString() + "个分组，正在对第" + item.Key.ToString() + "组进行相减过滤......";
                trf.UIRefresh();
                step6.SubFilter(nsublow1, nsubup1, nsublow2, nsubup2, step2.Dt_225, step2.Dt_25, step2.Dt_275);
                ncurr++;
                dpercent = (double)ncurr / (double)ntotal;
                nProcessvalue = (int)(dpercent * 100);
                trf.UIRefresh();
            }
            //更新grid
            LoadDgv();
            strCurTip = "执行成功！";
            nProcessvalue = 100;
            trf.UIRefresh();
            GC.Collect();
            GC.WaitForPendingFinalizers();
            double elapsedTimeInSeconds = DateTime.Now.Subtract(TimeStart).TotalSeconds;
            MessageBox.Show("执行成功:" + "共花费" + elapsedTimeInSeconds.ToString() + "秒！");
        }

        private void Start2_2()
        {
            DateTime TimeStart = DateTime.Now;
            step1.SetAllGroup2_2(this.listBox.Items);
            List<string> list = new List<string>();
            step2 = null;
            step3 = null;
            step4 = null;
            step5 = null;
            step6 = null;
            int ntotal = step1.Group.Count * 10;
            int ncurr = 0;
            double dpercent = 0d;
            nProcessvalue = 0;
            foreach (var item in step1.Group)
            {
                if (store.Store.Count <= 1)
                {
                    strCurTip = "分步号码库号码组数<=1组，执行终止！";
                    nProcessvalue = 100;
                    trf.UIRefresh();
                    MessageBox.Show("程序执行终止:" + "共花费" + DateTime.Now.Subtract(TimeStart).TotalSeconds.ToString() + "秒！");
                    return;
                }
                if (step2 == null)
                {
                    step2 = CalculateTool.Step2.CrtStep2(store);
                    step2.GetBaseStoreFromFile(strBasePath);
                }
                strCurTip = "共有" + step1.Group.Count.ToString() + "个分组，正在对第" + item.Key.ToString() + "个分组计算2.25平均......";
                trf.UIRefresh();
                step2.Filterbyhit(2.25, item.Value, "2.25");
                step2.Dt_225.Clear();
                step2.Dt_225 = step2.GetProTable(step2.ComStore_225);
                ncurr++;
                dpercent = (double)ncurr / (double)ntotal;
                nProcessvalue = (int)(dpercent * 100);
                trf.UIRefresh();

                strCurTip = "共有" + step1.Group.Count.ToString() + "个分组，正在对第" + item.Key.ToString() + "个分组计算2.5平均......";
                trf.UIRefresh();
                step2.Filterbyhit(2.5, item.Value, "2.5");
                step2.Dt_25.Clear();
                step2.Dt_25 = step2.GetProTable(step2.ComStore_25);
                ncurr++;
                dpercent = (double)ncurr / (double)ntotal;
                nProcessvalue = (int)(dpercent * 100);
                trf.UIRefresh();

                strCurTip = "共有" + step1.Group.Count.ToString() + "个分组，正在对第" + item.Key.ToString() + "个分组计算2.75平均......";
                trf.UIRefresh();
                step2.Filterbyhit(2.75, item.Value, "2.75");
                step2.Dt_275.Clear();
                step2.Dt_275 = step2.GetProTable(step2.ComStore_275);
                ncurr++;
                dpercent = (double)ncurr / (double)ntotal;
                nProcessvalue = (int)(dpercent * 100);
                trf.UIRefresh();
                //=====================第三步过滤开始============================
                if (step3 == null)
                    step3 = CalculateTool.Step3.CrtStep3(store);
                strCurTip = "共有" + step1.Group.Count.ToString() + "个分组，正在对第" + item.Key.ToString() + "组进行基于2.25的取值范围过滤......";
                trf.UIRefresh();
                step3.Filter(nrange1_low, nrange1_up, step2.Dt_225);
                ncurr++;
                dpercent = (double)ncurr / (double)ntotal;
                nProcessvalue = (int)(dpercent * 100);
                trf.UIRefresh();

                strCurTip = "共有" + step1.Group.Count.ToString() + "个分组，正在对第" + item.Key.ToString() + "组进行基于2.5的取值范围过滤......";
                trf.UIRefresh();
                step3.Filter(nrange2_low, nrange2_up, step2.Dt_25);
                ncurr++;
                dpercent = (double)ncurr / (double)ntotal;
                nProcessvalue = (int)(dpercent * 100);
                trf.UIRefresh();

                strCurTip = "共有" + step1.Group.Count.ToString() + "个分组，正在对第" + item.Key.ToString() + "组进行基于2.75的取值范围过滤......";
                trf.UIRefresh();
                step3.Filter(nrange3_low, nrange3_up, step2.Dt_275);
                ncurr++;
                dpercent = (double)ncurr / (double)ntotal;
                nProcessvalue = (int)(dpercent * 100);
                trf.UIRefresh();
                //======================第四步过滤开始============================
                if (step4 == null)
                    step4 = CalculateTool.Step4.CrtStep4(store);
                list.Clear();
                strCurTip = "共有" + step1.Group.Count.ToString() + "个分组，正在对第" + item.Key.ToString() + "组进行平均过滤......";
                trf.UIRefresh();
                ncurr++;
                dpercent = (double)ncurr / (double)ntotal;
                nProcessvalue = (int)(dpercent * 100);
                trf.UIRefresh();

                list = step4.Merge(step2.Dt_225, step2.Dt_275);
                step4.Filter(list, nlowlimit, nuplimit);
                ncurr++;
                dpercent = (double)ncurr / (double)ntotal;
                nProcessvalue = (int)(dpercent * 100);
                trf.UIRefresh();

                //======================第五步过滤开始============================
                if (step5 == null)
                    step5 = CalculateTool.Step5.CrtStep5(store);
                strCurTip = "共有" + step1.Group.Count.ToString() + "个分组，正在对第" + item.Key.ToString() + "组进行混合过滤......";
                trf.UIRefresh();
                step5.HybirdFilter(step2.Dt_225, step2.Dt_275);
                ncurr++;
                dpercent = (double)ncurr / (double)ntotal;
                nProcessvalue = (int)(dpercent * 100);
                trf.UIRefresh();

                //======================第六步过滤开始============================
                if (step6 == null)
                    step6 = CalculateTool.Step6.CrtStep6(store);
                strCurTip = "共有" + step1.Group.Count.ToString() + "个分组，正在对第" + item.Key.ToString() + "组进行相减过滤......";
                trf.UIRefresh();
                step6.SubFilter(nsublow1, nsubup1, nsublow2, nsubup2, step2.Dt_225, step2.Dt_25, step2.Dt_275);
                ncurr++;
                dpercent = (double)ncurr / (double)ntotal;
                nProcessvalue = (int)(dpercent * 100);
                trf.UIRefresh();
            }
            //更新grid
            LoadDgv();
            strCurTip = "执行成功！";
            nProcessvalue = 100;
            trf.UIRefresh();
            GC.Collect();
            GC.WaitForPendingFinalizers();
            double elapsedTimeInSeconds = DateTime.Now.Subtract(TimeStart).TotalSeconds;
            MessageBox.Show("执行成功:" + "共花费" + elapsedTimeInSeconds.ToString() + "秒！");
        }


        /// <summary>
        /// 加载Grid
        /// </summary>

        private void LoadDgv()
        {
            if (dtStore == null)
            {
                dtStore = new DataTable();
            }
            else
            {
                dtStore = null;
                dtStore = new DataTable();
            }
            DataColumn dtcol1 = new DataColumn
            {
                ColumnName = "序号",
                Caption = "序号"
            };
            dtStore.Columns.Add(dtcol1);
            DataColumn dtcol2 = new DataColumn
            {
                ColumnName = "号码组",
                Caption = "号码组"
            };
            dtStore.Columns.Add(dtcol2);

            int nno = 0;
            foreach (var item in store.Store)
            {
                nno++;
                DataRow dr = dtStore.NewRow();
                dr[0] = nno.ToString();
                dr[1] = item.Key;
                dtStore.Rows.Add(dr);
            }
        }


        private string Check()
        {
            string strErrmsg = "";
            if (string.IsNullOrEmpty(txtPathStore.Text.Trim()))
                strErrmsg = "请先导入基准号码库!";
            if (string.IsNullOrEmpty(txtPathStore.Text.Trim()))
                strErrmsg = "请先导入14位自选号码组!";
            if(this.listBox.Items.Count < 4)
                strErrmsg = "导入的14位号码组不能少于4组!";
                
            return strErrmsg;
        }


        private delegate void SetUIHandler();

        private void UIRefresh()
        {
            if (this.labTip.InvokeRequired)
            {
                SetUIHandler set = new SetUIHandler(UIRefresh);
                this.BeginInvoke(set);
            }
            else
            {
                this.labTip.Text = strCurTip;
                labTip.Refresh();
                if (strCurTip == "执行成功！")
                {
                    this.btnGroup.Enabled = true;
                    this.dataGridView.DataSource = dtStore;
                    this.dataGridView.Columns[0].AutoSizeMode = DataGridViewAutoSizeColumnMode.NotSet;
                    this.dataGridView.Columns[1].AutoSizeMode = DataGridViewAutoSizeColumnMode.Fill;
                    this.labnums.Text = dtStore.Rows.Count.ToString() + "组号码";
                }

                if (strCurTip.Contains("执行终止"))
                {
                    this.btnGroup.Enabled = true;
                }
                if (strCurTip == "导出成功！")
                {
                    this.btnExport.Enabled = true;
                }

                if (nProcessvalue >= 100)
                {
                    this.progressBar.Value = 100;
                    this.progressBar.Visible = false;
                }
                else
                {
                    this.progressBar.Visible = true;
                    this.progressBar.Value = nProcessvalue;
                }
            }
        }

        private void Form2_Load(object sender, EventArgs e)
        {
            cmbLowLimit.SelectedIndex = 0;
            cmbUpLimit.SelectedIndex = 0;
            this.progressBar.Visible = false;
            this.rad3_0.Checked = true;
        }

        private void btnExport_Click(object sender, EventArgs e)
        {
            if (this.dataGridView.Rows.Count > 0)
            {
                this.btnExport.Enabled = false;
                this.progressBar.Visible = true;
                if (trf == null)
                    //业务开始
                    trf = new UIReFresher { UIRefresh = UIRefresh };
                Task start = new Task(ExportResult);
                start.Start();
            }
            else
            {
                MessageBox.Show("没有可以导出的数据！", "提示");
            }
            
        }

        private void ExportResult()
        {
            nProcessvalue = 0;
            strCurTip = "正在导出数据，请稍后......";
            trf.UIRefresh();
            int ntotal = this.dataGridView.Rows.Count;
            int ncurr = 0;
            double dpercent = 0d;
            string strpath = System.Windows.Forms.Application.StartupPath + "\\分析结果";
            if (!Directory.Exists(strpath))
                Directory.CreateDirectory(strpath);

            string tradeTime = DateTime.Now.ToString("yyyyMMddHHmmss", DateTimeFormatInfo.InvariantInfo);
            string fullpath = strpath + "\\计算结果" + tradeTime + ".txt";
            DialogResult export = MessageBox.Show("是否需要导出顺序与界面一致？（与界面顺序一致会带来额外系统开销~）", "提示", MessageBoxButtons.YesNo);
            FileStream fs = new FileStream(fullpath, FileMode.Create);
            StreamWriter sw = new StreamWriter(fs);
            if (export == DialogResult.Yes)
            {
                
                foreach (DataGridViewRow row in this.dataGridView.Rows)
                {
                    sw.Write(Convert.ToString(row.Cells[1].Value) + "\r\n");
                    ncurr++;
                    dpercent = (double)ncurr / (double)ntotal;
                    nProcessvalue = (int)(dpercent * 100);
                    trf.UIRefresh();
                }
            }
            else
            {
                foreach (var item in store.Store)
                {
                    sw.Write(item.Key + "\r\n");
                    ncurr++;
                    dpercent = (double)ncurr / (double)ntotal;
                    nProcessvalue = (int)(dpercent * 100);
                    trf.UIRefresh();
                }
            }
            //清空缓冲区
            sw.Flush();
            //关闭流
            sw.Close();
            fs.Close();
            if (File.Exists(fullpath))
            {
                strCurTip = "导出成功！";
                nProcessvalue = 100;
                trf.UIRefresh();
                DialogResult diars = MessageBox.Show("计算结果导出完成，是否现在打开？", "提示", MessageBoxButtons.YesNo);
                if (diars == DialogResult.Yes)
                {
                    System.Diagnostics.Process.Start(strpath);
                }
            }
        }

        /// <summary>
        /// 自动选择基准库
        /// </summary>
        private void AutoSelStore()
        {
            store.Store.Clear();
            Parallel.ForEach(store.ConstStore, item => { store.Store.TryAdd(item.Key, item.Value); });
        }
    }
}

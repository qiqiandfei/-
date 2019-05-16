namespace CalculateTool
{
    partial class Form2
    {
        /// <summary>
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code

        /// <summary>
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(Form2));
            this.label1 = new System.Windows.Forms.Label();
            this.txtPathStore = new System.Windows.Forms.TextBox();
            this.btnSelStore = new System.Windows.Forms.Button();
            this.openFileDialog = new System.Windows.Forms.OpenFileDialog();
            this.label2 = new System.Windows.Forms.Label();
            this.txtPath14 = new System.Windows.Forms.TextBox();
            this.btnSel14 = new System.Windows.Forms.Button();
            this.listBox = new System.Windows.Forms.ListBox();
            this.btnGroup = new System.Windows.Forms.Button();
            this.labTip = new System.Windows.Forms.Label();
            this.label7 = new System.Windows.Forms.Label();
            this.label6 = new System.Windows.Forms.Label();
            this.label5 = new System.Windows.Forms.Label();
            this.numRange3_up = new System.Windows.Forms.NumericUpDown();
            this.numRange2_up = new System.Windows.Forms.NumericUpDown();
            this.numRange1_up = new System.Windows.Forms.NumericUpDown();
            this.label3 = new System.Windows.Forms.Label();
            this.cmbLowLimit = new System.Windows.Forms.ComboBox();
            this.label4 = new System.Windows.Forms.Label();
            this.cmbUpLimit = new System.Windows.Forms.ComboBox();
            this.numRange1_low = new System.Windows.Forms.NumericUpDown();
            this.numRange2_low = new System.Windows.Forms.NumericUpDown();
            this.numRange3_low = new System.Windows.Forms.NumericUpDown();
            this.btnExport = new System.Windows.Forms.Button();
            this.progressBar = new System.Windows.Forms.ProgressBar();
            this.dataGridView = new System.Windows.Forms.DataGridView();
            this.label8 = new System.Windows.Forms.Label();
            this.txtBasePath = new System.Windows.Forms.TextBox();
            this.btnSelBase = new System.Windows.Forms.Button();
            this.labnums = new System.Windows.Forms.Label();
            this.label9 = new System.Windows.Forms.Label();
            this.label10 = new System.Windows.Forms.Label();
            this.numSubUp1 = new System.Windows.Forms.NumericUpDown();
            this.numSubLow1 = new System.Windows.Forms.NumericUpDown();
            this.numSubUp2 = new System.Windows.Forms.NumericUpDown();
            this.numSubLow2 = new System.Windows.Forms.NumericUpDown();
            this.rad3_0 = new System.Windows.Forms.RadioButton();
            this.rad3_1 = new System.Windows.Forms.RadioButton();
            this.rad2_2 = new System.Windows.Forms.RadioButton();
            this.label11 = new System.Windows.Forms.Label();
            ((System.ComponentModel.ISupportInitialize)(this.numRange3_up)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.numRange2_up)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.numRange1_up)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.numRange1_low)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.numRange2_low)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.numRange3_low)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.dataGridView)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.numSubUp1)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.numSubLow1)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.numSubUp2)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.numSubLow2)).BeginInit();
            this.SuspendLayout();
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(10, 57);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(77, 12);
            this.label1.TabIndex = 0;
            this.label1.Text = "分步号码库：";
            // 
            // txtPathStore
            // 
            this.txtPathStore.Location = new System.Drawing.Point(88, 54);
            this.txtPathStore.Name = "txtPathStore";
            this.txtPathStore.Size = new System.Drawing.Size(297, 21);
            this.txtPathStore.TabIndex = 1;
            // 
            // btnSelStore
            // 
            this.btnSelStore.Location = new System.Drawing.Point(391, 53);
            this.btnSelStore.Name = "btnSelStore";
            this.btnSelStore.Size = new System.Drawing.Size(50, 22);
            this.btnSelStore.TabIndex = 2;
            this.btnSelStore.Text = "选择";
            this.btnSelStore.UseVisualStyleBackColor = true;
            this.btnSelStore.Click += new System.EventHandler(this.btnSelStore_Click);
            // 
            // openFileDialog
            // 
            this.openFileDialog.Filter = "文本文件|*.txt";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(10, 97);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(77, 12);
            this.label2.TabIndex = 0;
            this.label2.Text = "14位号码组：";
            // 
            // txtPath14
            // 
            this.txtPath14.Location = new System.Drawing.Point(88, 93);
            this.txtPath14.Name = "txtPath14";
            this.txtPath14.Size = new System.Drawing.Size(297, 21);
            this.txtPath14.TabIndex = 1;
            // 
            // btnSel14
            // 
            this.btnSel14.Location = new System.Drawing.Point(391, 91);
            this.btnSel14.Name = "btnSel14";
            this.btnSel14.Size = new System.Drawing.Size(50, 23);
            this.btnSel14.TabIndex = 2;
            this.btnSel14.Text = "选择";
            this.btnSel14.UseVisualStyleBackColor = true;
            this.btnSel14.Click += new System.EventHandler(this.btnSel14_Click);
            // 
            // listBox
            // 
            this.listBox.FormattingEnabled = true;
            this.listBox.ItemHeight = 12;
            this.listBox.Location = new System.Drawing.Point(88, 157);
            this.listBox.Name = "listBox";
            this.listBox.Size = new System.Drawing.Size(297, 160);
            this.listBox.TabIndex = 3;
            // 
            // btnGroup
            // 
            this.btnGroup.Location = new System.Drawing.Point(179, 500);
            this.btnGroup.Name = "btnGroup";
            this.btnGroup.Size = new System.Drawing.Size(75, 23);
            this.btnGroup.TabIndex = 4;
            this.btnGroup.Text = "号码过滤";
            this.btnGroup.UseVisualStyleBackColor = true;
            this.btnGroup.Click += new System.EventHandler(this.btnGroup_Click);
            // 
            // labTip
            // 
            this.labTip.Location = new System.Drawing.Point(10, 539);
            this.labTip.Name = "labTip";
            this.labTip.Size = new System.Drawing.Size(805, 23);
            this.labTip.TabIndex = 5;
            this.labTip.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // label7
            // 
            this.label7.AutoSize = true;
            this.label7.Location = new System.Drawing.Point(270, 355);
            this.label7.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.label7.Name = "label7";
            this.label7.Size = new System.Drawing.Size(71, 12);
            this.label7.TabIndex = 10;
            this.label7.Text = "取值范围3：";
            // 
            // label6
            // 
            this.label6.AutoSize = true;
            this.label6.Location = new System.Drawing.Point(140, 355);
            this.label6.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(71, 12);
            this.label6.TabIndex = 11;
            this.label6.Text = "取值范围2：";
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Location = new System.Drawing.Point(12, 355);
            this.label5.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(71, 12);
            this.label5.TabIndex = 12;
            this.label5.Text = "取值范围1：";
            // 
            // numRange3_up
            // 
            this.numRange3_up.Location = new System.Drawing.Point(345, 337);
            this.numRange3_up.Margin = new System.Windows.Forms.Padding(2);
            this.numRange3_up.Maximum = new decimal(new int[] {
            6,
            0,
            0,
            0});
            this.numRange3_up.Minimum = new decimal(new int[] {
            4,
            0,
            0,
            0});
            this.numRange3_up.Name = "numRange3_up";
            this.numRange3_up.ReadOnly = true;
            this.numRange3_up.Size = new System.Drawing.Size(40, 21);
            this.numRange3_up.TabIndex = 7;
            this.numRange3_up.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
            this.numRange3_up.Value = new decimal(new int[] {
            5,
            0,
            0,
            0});
            // 
            // numRange2_up
            // 
            this.numRange2_up.Location = new System.Drawing.Point(215, 337);
            this.numRange2_up.Margin = new System.Windows.Forms.Padding(2);
            this.numRange2_up.Maximum = new decimal(new int[] {
            6,
            0,
            0,
            0});
            this.numRange2_up.Minimum = new decimal(new int[] {
            4,
            0,
            0,
            0});
            this.numRange2_up.Name = "numRange2_up";
            this.numRange2_up.ReadOnly = true;
            this.numRange2_up.Size = new System.Drawing.Size(40, 21);
            this.numRange2_up.TabIndex = 8;
            this.numRange2_up.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
            this.numRange2_up.Value = new decimal(new int[] {
            5,
            0,
            0,
            0});
            // 
            // numRange1_up
            // 
            this.numRange1_up.Location = new System.Drawing.Point(87, 337);
            this.numRange1_up.Margin = new System.Windows.Forms.Padding(2);
            this.numRange1_up.Maximum = new decimal(new int[] {
            6,
            0,
            0,
            0});
            this.numRange1_up.Minimum = new decimal(new int[] {
            4,
            0,
            0,
            0});
            this.numRange1_up.Name = "numRange1_up";
            this.numRange1_up.ReadOnly = true;
            this.numRange1_up.Size = new System.Drawing.Size(40, 21);
            this.numRange1_up.TabIndex = 9;
            this.numRange1_up.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
            this.numRange1_up.Value = new decimal(new int[] {
            5,
            0,
            0,
            0});
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(12, 406);
            this.label3.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(65, 12);
            this.label3.TabIndex = 12;
            this.label3.Text = "平均下限：";
            // 
            // cmbLowLimit
            // 
            this.cmbLowLimit.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cmbLowLimit.FormattingEnabled = true;
            this.cmbLowLimit.Items.AddRange(new object[] {
            "2",
            "1.5"});
            this.cmbLowLimit.Location = new System.Drawing.Point(87, 402);
            this.cmbLowLimit.Name = "cmbLowLimit";
            this.cmbLowLimit.Size = new System.Drawing.Size(48, 20);
            this.cmbLowLimit.TabIndex = 14;
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Location = new System.Drawing.Point(146, 406);
            this.label4.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(65, 12);
            this.label4.TabIndex = 12;
            this.label4.Text = "平均上限：";
            // 
            // cmbUpLimit
            // 
            this.cmbUpLimit.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cmbUpLimit.FormattingEnabled = true;
            this.cmbUpLimit.Items.AddRange(new object[] {
            "4",
            "4.5"});
            this.cmbUpLimit.Location = new System.Drawing.Point(215, 402);
            this.cmbUpLimit.Name = "cmbUpLimit";
            this.cmbUpLimit.Size = new System.Drawing.Size(45, 20);
            this.cmbUpLimit.TabIndex = 14;
            // 
            // numRange1_low
            // 
            this.numRange1_low.Location = new System.Drawing.Point(88, 364);
            this.numRange1_low.Maximum = new decimal(new int[] {
            2,
            0,
            0,
            0});
            this.numRange1_low.Name = "numRange1_low";
            this.numRange1_low.ReadOnly = true;
            this.numRange1_low.Size = new System.Drawing.Size(39, 21);
            this.numRange1_low.TabIndex = 17;
            this.numRange1_low.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
            this.numRange1_low.Value = new decimal(new int[] {
            1,
            0,
            0,
            0});
            // 
            // numRange2_low
            // 
            this.numRange2_low.Location = new System.Drawing.Point(215, 364);
            this.numRange2_low.Maximum = new decimal(new int[] {
            2,
            0,
            0,
            0});
            this.numRange2_low.Name = "numRange2_low";
            this.numRange2_low.ReadOnly = true;
            this.numRange2_low.Size = new System.Drawing.Size(39, 21);
            this.numRange2_low.TabIndex = 17;
            this.numRange2_low.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
            this.numRange2_low.Value = new decimal(new int[] {
            1,
            0,
            0,
            0});
            // 
            // numRange3_low
            // 
            this.numRange3_low.Location = new System.Drawing.Point(345, 364);
            this.numRange3_low.Maximum = new decimal(new int[] {
            2,
            0,
            0,
            0});
            this.numRange3_low.Name = "numRange3_low";
            this.numRange3_low.ReadOnly = true;
            this.numRange3_low.Size = new System.Drawing.Size(39, 21);
            this.numRange3_low.TabIndex = 17;
            this.numRange3_low.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
            this.numRange3_low.Value = new decimal(new int[] {
            1,
            0,
            0,
            0});
            // 
            // btnExport
            // 
            this.btnExport.Location = new System.Drawing.Point(606, 500);
            this.btnExport.Name = "btnExport";
            this.btnExport.Size = new System.Drawing.Size(75, 23);
            this.btnExport.TabIndex = 18;
            this.btnExport.Text = "导出结果";
            this.btnExport.UseVisualStyleBackColor = true;
            this.btnExport.Click += new System.EventHandler(this.btnExport_Click);
            // 
            // progressBar
            // 
            this.progressBar.Location = new System.Drawing.Point(12, 565);
            this.progressBar.Name = "progressBar";
            this.progressBar.Size = new System.Drawing.Size(806, 23);
            this.progressBar.TabIndex = 19;
            // 
            // dataGridView
            // 
            this.dataGridView.AllowUserToAddRows = false;
            this.dataGridView.AllowUserToDeleteRows = false;
            this.dataGridView.AllowUserToOrderColumns = true;
            this.dataGridView.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dataGridView.Location = new System.Drawing.Point(447, 14);
            this.dataGridView.Name = "dataGridView";
            this.dataGridView.ReadOnly = true;
            this.dataGridView.RowTemplate.Height = 23;
            this.dataGridView.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect;
            this.dataGridView.Size = new System.Drawing.Size(371, 467);
            this.dataGridView.TabIndex = 20;
            // 
            // label8
            // 
            this.label8.AutoSize = true;
            this.label8.Location = new System.Drawing.Point(10, 17);
            this.label8.Name = "label8";
            this.label8.Size = new System.Drawing.Size(77, 12);
            this.label8.TabIndex = 0;
            this.label8.Text = "基准号码库：";
            // 
            // txtBasePath
            // 
            this.txtBasePath.Location = new System.Drawing.Point(88, 14);
            this.txtBasePath.Name = "txtBasePath";
            this.txtBasePath.Size = new System.Drawing.Size(297, 21);
            this.txtBasePath.TabIndex = 21;
            // 
            // btnSelBase
            // 
            this.btnSelBase.Location = new System.Drawing.Point(391, 13);
            this.btnSelBase.Name = "btnSelBase";
            this.btnSelBase.Size = new System.Drawing.Size(50, 22);
            this.btnSelBase.TabIndex = 22;
            this.btnSelBase.Text = "选择";
            this.btnSelBase.UseVisualStyleBackColor = true;
            this.btnSelBase.Click += new System.EventHandler(this.btnSelBase_Click);
            // 
            // labnums
            // 
            this.labnums.Location = new System.Drawing.Point(447, 484);
            this.labnums.Name = "labnums";
            this.labnums.Size = new System.Drawing.Size(130, 23);
            this.labnums.TabIndex = 23;
            this.labnums.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // label9
            // 
            this.label9.AutoSize = true;
            this.label9.Location = new System.Drawing.Point(12, 451);
            this.label9.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.label9.Name = "label9";
            this.label9.Size = new System.Drawing.Size(113, 12);
            this.label9.TabIndex = 12;
            this.label9.Text = "2.25-2.5相减取值：";
            // 
            // label10
            // 
            this.label10.AutoSize = true;
            this.label10.Location = new System.Drawing.Point(226, 451);
            this.label10.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.label10.Name = "label10";
            this.label10.Size = new System.Drawing.Size(113, 12);
            this.label10.TabIndex = 12;
            this.label10.Text = "2.5-2.75相减取值：";
            // 
            // numSubUp1
            // 
            this.numSubUp1.Location = new System.Drawing.Point(132, 433);
            this.numSubUp1.Maximum = new decimal(new int[] {
            6,
            0,
            0,
            0});
            this.numSubUp1.Minimum = new decimal(new int[] {
            1,
            0,
            0,
            0});
            this.numSubUp1.Name = "numSubUp1";
            this.numSubUp1.ReadOnly = true;
            this.numSubUp1.Size = new System.Drawing.Size(40, 21);
            this.numSubUp1.TabIndex = 24;
            this.numSubUp1.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
            this.numSubUp1.Value = new decimal(new int[] {
            3,
            0,
            0,
            0});
            // 
            // numSubLow1
            // 
            this.numSubLow1.Location = new System.Drawing.Point(132, 460);
            this.numSubLow1.Maximum = new decimal(new int[] {
            1,
            0,
            0,
            -2147483648});
            this.numSubLow1.Minimum = new decimal(new int[] {
            6,
            0,
            0,
            -2147483648});
            this.numSubLow1.Name = "numSubLow1";
            this.numSubLow1.ReadOnly = true;
            this.numSubLow1.Size = new System.Drawing.Size(40, 21);
            this.numSubLow1.TabIndex = 24;
            this.numSubLow1.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
            this.numSubLow1.Value = new decimal(new int[] {
            3,
            0,
            0,
            -2147483648});
            // 
            // numSubUp2
            // 
            this.numSubUp2.Location = new System.Drawing.Point(344, 433);
            this.numSubUp2.Maximum = new decimal(new int[] {
            6,
            0,
            0,
            0});
            this.numSubUp2.Minimum = new decimal(new int[] {
            1,
            0,
            0,
            0});
            this.numSubUp2.Name = "numSubUp2";
            this.numSubUp2.ReadOnly = true;
            this.numSubUp2.Size = new System.Drawing.Size(40, 21);
            this.numSubUp2.TabIndex = 24;
            this.numSubUp2.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
            this.numSubUp2.Value = new decimal(new int[] {
            3,
            0,
            0,
            0});
            // 
            // numSubLow2
            // 
            this.numSubLow2.Location = new System.Drawing.Point(344, 460);
            this.numSubLow2.Maximum = new decimal(new int[] {
            1,
            0,
            0,
            -2147483648});
            this.numSubLow2.Minimum = new decimal(new int[] {
            6,
            0,
            0,
            -2147483648});
            this.numSubLow2.Name = "numSubLow2";
            this.numSubLow2.ReadOnly = true;
            this.numSubLow2.Size = new System.Drawing.Size(40, 21);
            this.numSubLow2.TabIndex = 24;
            this.numSubLow2.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
            this.numSubLow2.Value = new decimal(new int[] {
            3,
            0,
            0,
            -2147483648});
            // 
            // rad3_0
            // 
            this.rad3_0.AutoSize = true;
            this.rad3_0.Location = new System.Drawing.Point(88, 129);
            this.rad3_0.Name = "rad3_0";
            this.rad3_0.Size = new System.Drawing.Size(53, 16);
            this.rad3_0.TabIndex = 25;
            this.rad3_0.TabStop = true;
            this.rad3_0.Text = "3 + 0";
            this.rad3_0.UseVisualStyleBackColor = true;
            // 
            // rad3_1
            // 
            this.rad3_1.AutoSize = true;
            this.rad3_1.Location = new System.Drawing.Point(171, 129);
            this.rad3_1.Name = "rad3_1";
            this.rad3_1.Size = new System.Drawing.Size(53, 16);
            this.rad3_1.TabIndex = 25;
            this.rad3_1.TabStop = true;
            this.rad3_1.Text = "3 + 1";
            this.rad3_1.UseVisualStyleBackColor = true;
            // 
            // rad2_2
            // 
            this.rad2_2.AutoSize = true;
            this.rad2_2.Location = new System.Drawing.Point(254, 129);
            this.rad2_2.Name = "rad2_2";
            this.rad2_2.Size = new System.Drawing.Size(53, 16);
            this.rad2_2.TabIndex = 25;
            this.rad2_2.TabStop = true;
            this.rad2_2.Text = "2 + 2";
            this.rad2_2.UseVisualStyleBackColor = true;
            // 
            // label11
            // 
            this.label11.AutoSize = true;
            this.label11.Location = new System.Drawing.Point(17, 131);
            this.label11.Name = "label11";
            this.label11.Size = new System.Drawing.Size(65, 12);
            this.label11.TabIndex = 0;
            this.label11.Text = "组合方式：";
            // 
            // Form2
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 12F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(830, 599);
            this.Controls.Add(this.rad2_2);
            this.Controls.Add(this.rad3_1);
            this.Controls.Add(this.rad3_0);
            this.Controls.Add(this.numSubLow2);
            this.Controls.Add(this.numSubUp2);
            this.Controls.Add(this.numSubLow1);
            this.Controls.Add(this.numSubUp1);
            this.Controls.Add(this.labnums);
            this.Controls.Add(this.btnSelBase);
            this.Controls.Add(this.txtBasePath);
            this.Controls.Add(this.dataGridView);
            this.Controls.Add(this.progressBar);
            this.Controls.Add(this.btnExport);
            this.Controls.Add(this.numRange3_low);
            this.Controls.Add(this.numRange2_low);
            this.Controls.Add(this.numRange1_low);
            this.Controls.Add(this.cmbUpLimit);
            this.Controls.Add(this.cmbLowLimit);
            this.Controls.Add(this.label7);
            this.Controls.Add(this.label6);
            this.Controls.Add(this.label4);
            this.Controls.Add(this.label10);
            this.Controls.Add(this.label9);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.label5);
            this.Controls.Add(this.numRange3_up);
            this.Controls.Add(this.numRange2_up);
            this.Controls.Add(this.numRange1_up);
            this.Controls.Add(this.labTip);
            this.Controls.Add(this.btnGroup);
            this.Controls.Add(this.listBox);
            this.Controls.Add(this.btnSel14);
            this.Controls.Add(this.btnSelStore);
            this.Controls.Add(this.txtPath14);
            this.Controls.Add(this.txtPathStore);
            this.Controls.Add(this.label11);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.label8);
            this.Controls.Add(this.label1);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle;
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.MaximizeBox = false;
            this.Name = "Form2";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "彩虹飞舞V1.0.6";
            this.Load += new System.EventHandler(this.Form2_Load);
            ((System.ComponentModel.ISupportInitialize)(this.numRange3_up)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.numRange2_up)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.numRange1_up)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.numRange1_low)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.numRange2_low)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.numRange3_low)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.dataGridView)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.numSubUp1)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.numSubLow1)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.numSubUp2)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.numSubLow2)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.TextBox txtPathStore;
        private System.Windows.Forms.Button btnSelStore;
        private System.Windows.Forms.OpenFileDialog openFileDialog;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.TextBox txtPath14;
        private System.Windows.Forms.Button btnSel14;
        private System.Windows.Forms.ListBox listBox;
        private System.Windows.Forms.Button btnGroup;
        private System.Windows.Forms.Label labTip;
        private System.Windows.Forms.Label label7;
        private System.Windows.Forms.Label label6;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.NumericUpDown numRange3_up;
        private System.Windows.Forms.NumericUpDown numRange2_up;
        private System.Windows.Forms.NumericUpDown numRange1_up;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.ComboBox cmbLowLimit;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.ComboBox cmbUpLimit;
        private System.Windows.Forms.NumericUpDown numRange1_low;
        private System.Windows.Forms.NumericUpDown numRange2_low;
        private System.Windows.Forms.NumericUpDown numRange3_low;
        private System.Windows.Forms.Button btnExport;
        private System.Windows.Forms.ProgressBar progressBar;
        private System.Windows.Forms.DataGridView dataGridView;
        private System.Windows.Forms.Label label8;
        private System.Windows.Forms.TextBox txtBasePath;
        private System.Windows.Forms.Button btnSelBase;
        private System.Windows.Forms.Label labnums;
        private System.Windows.Forms.Label label9;
        private System.Windows.Forms.Label label10;
        private System.Windows.Forms.NumericUpDown numSubUp1;
        private System.Windows.Forms.NumericUpDown numSubLow1;
        private System.Windows.Forms.NumericUpDown numSubUp2;
        private System.Windows.Forms.NumericUpDown numSubLow2;
        private System.Windows.Forms.RadioButton rad3_0;
        private System.Windows.Forms.RadioButton rad3_1;
        private System.Windows.Forms.RadioButton rad2_2;
        private System.Windows.Forms.Label label11;
    }
}
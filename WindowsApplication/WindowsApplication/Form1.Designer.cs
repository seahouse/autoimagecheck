namespace 激光快速测量系统
{

    public partial class Form1 : global::System.Windows.Forms.Form
    {

        protected override void Dispose(bool disposing)
        {
            if (disposing && this.components != null)
            {
                this.components.Dispose();
            }
            base.Dispose(disposing);
        }


        private void InitializeComponent()
        {
            this.components = new System.ComponentModel.Container();
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(Form1));
            this.btOPenfile = new System.Windows.Forms.Button();
            this.grpNames = new System.Windows.Forms.GroupBox();
            this.flpNames = new System.Windows.Forms.FlowLayoutPanel();
            this.btnMeasure = new System.Windows.Forms.Button();
            this.btnAnalyse = new System.Windows.Forms.Button();
            this.btnStart = new System.Windows.Forms.Button();
            this.timer1 = new System.Windows.Forms.Timer(this.components);
            this.openFileDialog1 = new System.Windows.Forms.OpenFileDialog();
            this.folderBrowserDialog1 = new System.Windows.Forms.FolderBrowserDialog();
            this.label1 = new System.Windows.Forms.Label();
            this.groupBox2 = new System.Windows.Forms.GroupBox();
            this.cboX = new System.Windows.Forms.ComboBox();
            this.label3 = new System.Windows.Forms.Label();
            this.chkGrid = new System.Windows.Forms.CheckBox();
            this.cboRange = new System.Windows.Forms.ComboBox();
            this.cboGrid = new System.Windows.Forms.ComboBox();
            this.label2 = new System.Windows.Forms.Label();
            this.btnSaveLocation = new System.Windows.Forms.Button();
            this.lb_path = new System.Windows.Forms.Label();
            this.pictureBox2 = new System.Windows.Forms.PictureBox();
            this.lbOperator = new System.Windows.Forms.Label();
            this.lbTime = new System.Windows.Forms.Label();
            this.tBoxOperator = new System.Windows.Forms.TextBox();
            this.tboxPart = new System.Windows.Forms.TextBox();
            this.btnView = new System.Windows.Forms.Button();
            this.label6 = new System.Windows.Forms.Label();
            this.tboxSeroNo = new System.Windows.Forms.TextBox();
            this.lbStatus = new System.Windows.Forms.Label();
            this.bW_monitor = new System.ComponentModel.BackgroundWorker();
            this.picChart = new System.Windows.Forms.PictureBox();
            this.groupBox3 = new System.Windows.Forms.GroupBox();
            this.tBtolzoom = new System.Windows.Forms.TextBox();
            this.label9 = new System.Windows.Forms.Label();
            this.tBdTol = new System.Windows.Forms.TextBox();
            this.label8 = new System.Windows.Forms.Label();
            this.tBuTol = new System.Windows.Forms.TextBox();
            this.label7 = new System.Windows.Forms.Label();
            this.labelZ = new System.Windows.Forms.Label();
            this.fplTop = new System.Windows.Forms.FlowLayoutPanel();
            this.pnlSetting = new System.Windows.Forms.Panel();
            this.btnTest = new System.Windows.Forms.Button();
            this.pnlRight = new System.Windows.Forms.Panel();
            this.btnTest2 = new System.Windows.Forms.Button();
            this.grpNames.SuspendLayout();
            this.groupBox2.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox2)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.picChart)).BeginInit();
            this.groupBox3.SuspendLayout();
            this.fplTop.SuspendLayout();
            this.pnlSetting.SuspendLayout();
            this.pnlRight.SuspendLayout();
            this.SuspendLayout();
            // 
            // btOPenfile
            // 
            this.btOPenfile.Dock = System.Windows.Forms.DockStyle.Top;
            this.btOPenfile.Font = new System.Drawing.Font("SimSun", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.btOPenfile.Location = new System.Drawing.Point(0, 0);
            this.btOPenfile.Name = "btOPenfile";
            this.btOPenfile.Size = new System.Drawing.Size(253, 31);
            this.btOPenfile.TabIndex = 0;
            this.btOPenfile.Text = "选择产品";
            this.btOPenfile.UseVisualStyleBackColor = true;
            this.btOPenfile.Click += new System.EventHandler(this.btOPenfile_Click);
            // 
            // grpNames
            // 
            this.grpNames.Controls.Add(this.flpNames);
            this.grpNames.Dock = System.Windows.Forms.DockStyle.Fill;
            this.grpNames.Font = new System.Drawing.Font("SimSun", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.grpNames.Location = new System.Drawing.Point(0, 31);
            this.grpNames.Name = "grpNames";
            this.grpNames.Size = new System.Drawing.Size(253, 204);
            this.grpNames.TabIndex = 1;
            this.grpNames.TabStop = false;
            this.grpNames.Text = "截面及名称";
            // 
            // flpNames
            // 
            this.flpNames.AutoScroll = true;
            this.flpNames.Dock = System.Windows.Forms.DockStyle.Fill;
            this.flpNames.FlowDirection = System.Windows.Forms.FlowDirection.TopDown;
            this.flpNames.Location = new System.Drawing.Point(3, 22);
            this.flpNames.Name = "flpNames";
            this.flpNames.Size = new System.Drawing.Size(247, 179);
            this.flpNames.TabIndex = 0;
            this.flpNames.MouseUp += new System.Windows.Forms.MouseEventHandler(this.Form1_MouseUp);
            // 
            // btnMeasure
            // 
            this.btnMeasure.Enabled = false;
            this.btnMeasure.Font = new System.Drawing.Font("SimSun", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.btnMeasure.Location = new System.Drawing.Point(3, 326);
            this.btnMeasure.Name = "btnMeasure";
            this.btnMeasure.Size = new System.Drawing.Size(71, 45);
            this.btnMeasure.TabIndex = 2;
            this.btnMeasure.Text = "测 量";
            this.btnMeasure.UseVisualStyleBackColor = true;
            this.btnMeasure.Click += new System.EventHandler(this.btnMeasure_Click);
            // 
            // btnAnalyse
            // 
            this.btnAnalyse.Font = new System.Drawing.Font("SimSun", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.btnAnalyse.Location = new System.Drawing.Point(89, 326);
            this.btnAnalyse.Name = "btnAnalyse";
            this.btnAnalyse.Size = new System.Drawing.Size(74, 45);
            this.btnAnalyse.TabIndex = 3;
            this.btnAnalyse.Text = "分 析";
            this.btnAnalyse.UseVisualStyleBackColor = true;
            this.btnAnalyse.Click += new System.EventHandler(this.btnAnalyse_Click);
            // 
            // btnStart
            // 
            this.btnStart.AutoSize = true;
            this.btnStart.Location = new System.Drawing.Point(15, 203);
            this.btnStart.Name = "btnStart";
            this.btnStart.Size = new System.Drawing.Size(55, 53);
            this.btnStart.TabIndex = 5;
            this.btnStart.Text = "start";
            this.btnStart.UseVisualStyleBackColor = true;
            this.btnStart.Click += new System.EventHandler(this.btnStart_Click);
            // 
            // timer1
            // 
            this.timer1.Interval = 40;
            this.timer1.Tick += new System.EventHandler(this.timer1_Tick_1);
            // 
            // openFileDialog1
            // 
            this.openFileDialog1.FileName = "openFileDialog1";
            // 
            // label1
            // 
            this.label1.Anchor = System.Windows.Forms.AnchorStyles.Left;
            this.label1.AutoSize = true;
            this.label1.BackColor = System.Drawing.Color.Transparent;
            this.label1.Font = new System.Drawing.Font("SimSun", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.label1.Location = new System.Drawing.Point(141, 10);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(76, 16);
            this.label1.TabIndex = 6;
            this.label1.Text = "测量产品";
            // 
            // groupBox2
            // 
            this.groupBox2.Controls.Add(this.cboX);
            this.groupBox2.Controls.Add(this.label3);
            this.groupBox2.Controls.Add(this.chkGrid);
            this.groupBox2.Controls.Add(this.cboRange);
            this.groupBox2.Controls.Add(this.cboGrid);
            this.groupBox2.Controls.Add(this.label2);
            this.groupBox2.Font = new System.Drawing.Font("SimSun", 10.5F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.groupBox2.Location = new System.Drawing.Point(76, 125);
            this.groupBox2.Name = "groupBox2";
            this.groupBox2.Size = new System.Drawing.Size(163, 151);
            this.groupBox2.TabIndex = 8;
            this.groupBox2.TabStop = false;
            this.groupBox2.Text = "显示控制";
            // 
            // cboX
            // 
            this.cboX.FormattingEnabled = true;
            this.cboX.Items.AddRange(new object[] {
            "100",
            "40",
            "50",
            "60",
            "80"});
            this.cboX.Location = new System.Drawing.Point(96, 65);
            this.cboX.Name = "cboX";
            this.cboX.Size = new System.Drawing.Size(55, 22);
            this.cboX.Sorted = true;
            this.cboX.TabIndex = 8;
            this.cboX.Text = "60";
            this.cboX.SelectedIndexChanged += new System.EventHandler(this.cboX_SelectedIndexChanged);
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.BackColor = System.Drawing.Color.Transparent;
            this.label3.Location = new System.Drawing.Point(14, 68);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(63, 14);
            this.label3.TabIndex = 7;
            this.label3.Text = "放大倍数";
            // 
            // chkGrid
            // 
            this.chkGrid.AutoSize = true;
            this.chkGrid.BackColor = System.Drawing.Color.Transparent;
            this.chkGrid.Location = new System.Drawing.Point(17, 106);
            this.chkGrid.Name = "chkGrid";
            this.chkGrid.Size = new System.Drawing.Size(54, 18);
            this.chkGrid.TabIndex = 6;
            this.chkGrid.Text = "Grid";
            this.chkGrid.UseVisualStyleBackColor = false;
            this.chkGrid.CheckedChanged += new System.EventHandler(this.chkGrid_CheckedChanged);
            // 
            // cboRange
            // 
            this.cboRange.FormattingEnabled = true;
            this.cboRange.Items.AddRange(new object[] {
            "2.5",
            "3.5",
            "5.0"});
            this.cboRange.Location = new System.Drawing.Point(96, 27);
            this.cboRange.Name = "cboRange";
            this.cboRange.Size = new System.Drawing.Size(55, 22);
            this.cboRange.Sorted = true;
            this.cboRange.TabIndex = 5;
            this.cboRange.Text = "2.5";
            this.cboRange.SelectedIndexChanged += new System.EventHandler(this.cboRange_SelectedIndexChanged);
            // 
            // cboGrid
            // 
            this.cboGrid.FormattingEnabled = true;
            this.cboGrid.Items.AddRange(new object[] {
            "0.1",
            "0.2",
            "0.4",
            "0.6"});
            this.cboGrid.Location = new System.Drawing.Point(94, 104);
            this.cboGrid.Name = "cboGrid";
            this.cboGrid.Size = new System.Drawing.Size(57, 22);
            this.cboGrid.TabIndex = 4;
            this.cboGrid.Text = "0.4";
            this.cboGrid.SelectedIndexChanged += new System.EventHandler(this.cboGrid_SelectedIndexChanged);
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.BackColor = System.Drawing.Color.Transparent;
            this.label2.CausesValidation = false;
            this.label2.Location = new System.Drawing.Point(14, 35);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(63, 14);
            this.label2.TabIndex = 2;
            this.label2.Text = "检测范围";
            // 
            // btnSaveLocation
            // 
            this.btnSaveLocation.Anchor = System.Windows.Forms.AnchorStyles.Left;
            this.btnSaveLocation.BackColor = System.Drawing.SystemColors.Control;
            this.btnSaveLocation.ForeColor = System.Drawing.SystemColors.ControlText;
            this.btnSaveLocation.Location = new System.Drawing.Point(546, 3);
            this.btnSaveLocation.Name = "btnSaveLocation";
            this.btnSaveLocation.Size = new System.Drawing.Size(87, 31);
            this.btnSaveLocation.TabIndex = 9;
            this.btnSaveLocation.Text = "保存路径";
            this.btnSaveLocation.UseVisualStyleBackColor = false;
            this.btnSaveLocation.Click += new System.EventHandler(this.btnSaveLocation_Click);
            // 
            // lb_path
            // 
            this.lb_path.Anchor = System.Windows.Forms.AnchorStyles.Left;
            this.lb_path.AutoSize = true;
            this.lb_path.BackColor = System.Drawing.Color.Transparent;
            this.lb_path.Location = new System.Drawing.Point(639, 10);
            this.lb_path.Name = "lb_path";
            this.lb_path.Size = new System.Drawing.Size(16, 16);
            this.lb_path.TabIndex = 10;
            this.lb_path.Text = "-";
            // 
            // pictureBox2
            // 
            this.pictureBox2.Image = ((System.Drawing.Image)(resources.GetObject("pictureBox2.Image")));
            this.pictureBox2.Location = new System.Drawing.Point(15, 144);
            this.pictureBox2.Name = "pictureBox2";
            this.pictureBox2.Size = new System.Drawing.Size(50, 50);
            this.pictureBox2.TabIndex = 12;
            this.pictureBox2.TabStop = false;
            this.pictureBox2.Click += new System.EventHandler(this.pictureBox2_Click);
            // 
            // lbOperator
            // 
            this.lbOperator.Anchor = System.Windows.Forms.AnchorStyles.Left;
            this.lbOperator.AutoSize = true;
            this.lbOperator.BackColor = System.Drawing.Color.Transparent;
            this.lbOperator.Font = new System.Drawing.Font("SimSun", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.lbOperator.Location = new System.Drawing.Point(3, 10);
            this.lbOperator.Name = "lbOperator";
            this.lbOperator.Size = new System.Drawing.Size(42, 16);
            this.lbOperator.TabIndex = 13;
            this.lbOperator.Text = "操作";
            // 
            // lbTime
            // 
            this.lbTime.Anchor = System.Windows.Forms.AnchorStyles.Left;
            this.lbTime.AutoSize = true;
            this.lbTime.BackColor = System.Drawing.Color.Transparent;
            this.lbTime.Font = new System.Drawing.Font("Calibri", 14.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lbTime.ForeColor = System.Drawing.Color.LimeGreen;
            this.lbTime.Location = new System.Drawing.Point(492, 7);
            this.lbTime.Name = "lbTime";
            this.lbTime.Size = new System.Drawing.Size(48, 23);
            this.lbTime.TabIndex = 14;
            this.lbTime.Text = "日期";
            // 
            // tBoxOperator
            // 
            this.tBoxOperator.Anchor = System.Windows.Forms.AnchorStyles.Left;
            this.tBoxOperator.Location = new System.Drawing.Point(51, 5);
            this.tBoxOperator.Name = "tBoxOperator";
            this.tBoxOperator.Size = new System.Drawing.Size(84, 26);
            this.tBoxOperator.TabIndex = 15;
            this.tBoxOperator.Text = "Operator";
            // 
            // tboxPart
            // 
            this.tboxPart.Anchor = System.Windows.Forms.AnchorStyles.Left;
            this.tboxPart.Location = new System.Drawing.Point(223, 5);
            this.tboxPart.Name = "tboxPart";
            this.tboxPart.ReadOnly = true;
            this.tboxPart.Size = new System.Drawing.Size(96, 26);
            this.tboxPart.TabIndex = 16;
            // 
            // btnView
            // 
            this.btnView.Font = new System.Drawing.Font("SimSun", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.btnView.Location = new System.Drawing.Point(184, 326);
            this.btnView.Name = "btnView";
            this.btnView.Size = new System.Drawing.Size(67, 45);
            this.btnView.TabIndex = 18;
            this.btnView.Text = "浏 览";
            this.btnView.UseVisualStyleBackColor = true;
            this.btnView.Click += new System.EventHandler(this.btnView_Click);
            // 
            // label6
            // 
            this.label6.Anchor = System.Windows.Forms.AnchorStyles.Left;
            this.label6.AutoSize = true;
            this.label6.BackColor = System.Drawing.Color.Transparent;
            this.label6.Font = new System.Drawing.Font("SimSun", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.label6.Location = new System.Drawing.Point(325, 10);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(59, 16);
            this.label6.TabIndex = 19;
            this.label6.Text = "序列号";
            // 
            // tboxSeroNo
            // 
            this.tboxSeroNo.Anchor = System.Windows.Forms.AnchorStyles.Left;
            this.tboxSeroNo.Location = new System.Drawing.Point(390, 5);
            this.tboxSeroNo.Name = "tboxSeroNo";
            this.tboxSeroNo.Size = new System.Drawing.Size(96, 26);
            this.tboxSeroNo.TabIndex = 20;
            this.tboxSeroNo.Text = "3245";
            this.tboxSeroNo.KeyDown += new System.Windows.Forms.KeyEventHandler(this.tboxSeroNo_KeyDown);
            // 
            // lbStatus
            // 
            this.lbStatus.AutoSize = true;
            this.lbStatus.BackColor = System.Drawing.Color.Transparent;
            this.lbStatus.Font = new System.Drawing.Font("SimSun", 10.5F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.lbStatus.ForeColor = System.Drawing.Color.Red;
            this.lbStatus.Location = new System.Drawing.Point(12, 292);
            this.lbStatus.Name = "lbStatus";
            this.lbStatus.Size = new System.Drawing.Size(31, 14);
            this.lbStatus.TabIndex = 21;
            this.lbStatus.Text = "...";
            // 
            // bW_monitor
            // 
            this.bW_monitor.WorkerReportsProgress = true;
            this.bW_monitor.WorkerSupportsCancellation = true;
            this.bW_monitor.DoWork += new System.ComponentModel.DoWorkEventHandler(this.bW_monitor_DoWork);
            this.bW_monitor.ProgressChanged += new System.ComponentModel.ProgressChangedEventHandler(this.bW_monitor_ProgressChanged);
            // 
            // picChart
            // 
            this.picChart.BackColor = System.Drawing.SystemColors.ActiveCaptionText;
            this.picChart.Dock = System.Windows.Forms.DockStyle.Fill;
            this.picChart.Location = new System.Drawing.Point(0, 37);
            this.picChart.Name = "picChart";
            this.picChart.Size = new System.Drawing.Size(704, 583);
            this.picChart.TabIndex = 4;
            this.picChart.TabStop = false;
            this.picChart.Paint += new System.Windows.Forms.PaintEventHandler(this.picChart_Paint);
            // 
            // groupBox3
            // 
            this.groupBox3.BackColor = System.Drawing.Color.Transparent;
            this.groupBox3.Controls.Add(this.tBtolzoom);
            this.groupBox3.Controls.Add(this.label9);
            this.groupBox3.Controls.Add(this.tBdTol);
            this.groupBox3.Controls.Add(this.label8);
            this.groupBox3.Controls.Add(this.tBuTol);
            this.groupBox3.Controls.Add(this.label7);
            this.groupBox3.Dock = System.Windows.Forms.DockStyle.Top;
            this.groupBox3.Font = new System.Drawing.Font("SimSun", 10.5F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.groupBox3.Location = new System.Drawing.Point(0, 0);
            this.groupBox3.Name = "groupBox3";
            this.groupBox3.Size = new System.Drawing.Size(253, 119);
            this.groupBox3.TabIndex = 23;
            this.groupBox3.TabStop = false;
            this.groupBox3.Text = "公差";
            // 
            // tBtolzoom
            // 
            this.tBtolzoom.Location = new System.Drawing.Point(117, 83);
            this.tBtolzoom.Name = "tBtolzoom";
            this.tBtolzoom.Size = new System.Drawing.Size(92, 23);
            this.tBtolzoom.TabIndex = 8;
            this.tBtolzoom.Text = "2";
            // 
            // label9
            // 
            this.label9.AutoSize = true;
            this.label9.BackColor = System.Drawing.Color.Transparent;
            this.label9.CausesValidation = false;
            this.label9.Location = new System.Drawing.Point(42, 88);
            this.label9.Name = "label9";
            this.label9.Size = new System.Drawing.Size(63, 14);
            this.label9.TabIndex = 7;
            this.label9.Text = "偏差放大";
            // 
            // tBdTol
            // 
            this.tBdTol.Location = new System.Drawing.Point(117, 54);
            this.tBdTol.Name = "tBdTol";
            this.tBdTol.Size = new System.Drawing.Size(92, 23);
            this.tBdTol.TabIndex = 6;
            this.tBdTol.Text = "-0.05";
            this.tBdTol.KeyDown += new System.Windows.Forms.KeyEventHandler(this.tBdTol_KeyDown);
            // 
            // label8
            // 
            this.label8.AutoSize = true;
            this.label8.BackColor = System.Drawing.Color.Transparent;
            this.label8.CausesValidation = false;
            this.label8.Location = new System.Drawing.Point(42, 58);
            this.label8.Name = "label8";
            this.label8.Size = new System.Drawing.Size(49, 14);
            this.label8.TabIndex = 5;
            this.label8.Text = "下偏差";
            // 
            // tBuTol
            // 
            this.tBuTol.Location = new System.Drawing.Point(117, 22);
            this.tBuTol.Name = "tBuTol";
            this.tBuTol.Size = new System.Drawing.Size(92, 23);
            this.tBuTol.TabIndex = 4;
            this.tBuTol.Text = "0.05";
            this.tBuTol.KeyDown += new System.Windows.Forms.KeyEventHandler(this.tBuTol_KeyDown);
            // 
            // label7
            // 
            this.label7.AutoSize = true;
            this.label7.BackColor = System.Drawing.Color.Transparent;
            this.label7.CausesValidation = false;
            this.label7.Location = new System.Drawing.Point(43, 31);
            this.label7.Name = "label7";
            this.label7.Size = new System.Drawing.Size(49, 14);
            this.label7.TabIndex = 3;
            this.label7.Text = "上偏差";
            // 
            // labelZ
            // 
            this.labelZ.AutoSize = true;
            this.labelZ.BackColor = System.Drawing.Color.Black;
            this.labelZ.Font = new System.Drawing.Font("SimSun", 18F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.labelZ.ForeColor = System.Drawing.SystemColors.ButtonHighlight;
            this.labelZ.Location = new System.Drawing.Point(2, 46);
            this.labelZ.Name = "labelZ";
            this.labelZ.Size = new System.Drawing.Size(166, 24);
            this.labelZ.TabIndex = 24;
            this.labelZ.Text = "截面位置Z=0.0";
            // 
            // fplTop
            // 
            this.fplTop.Controls.Add(this.lbOperator);
            this.fplTop.Controls.Add(this.tBoxOperator);
            this.fplTop.Controls.Add(this.label1);
            this.fplTop.Controls.Add(this.tboxPart);
            this.fplTop.Controls.Add(this.label6);
            this.fplTop.Controls.Add(this.tboxSeroNo);
            this.fplTop.Controls.Add(this.lbTime);
            this.fplTop.Controls.Add(this.btnSaveLocation);
            this.fplTop.Controls.Add(this.lb_path);
            this.fplTop.Dock = System.Windows.Forms.DockStyle.Top;
            this.fplTop.Font = new System.Drawing.Font("SimSun", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.fplTop.Location = new System.Drawing.Point(0, 0);
            this.fplTop.Name = "fplTop";
            this.fplTop.Size = new System.Drawing.Size(704, 37);
            this.fplTop.TabIndex = 25;
            this.fplTop.WrapContents = false;
            this.fplTop.MouseUp += new System.Windows.Forms.MouseEventHandler(this.Form1_MouseUp);
            // 
            // pnlSetting
            // 
            this.pnlSetting.Controls.Add(this.btnTest2);
            this.pnlSetting.Controls.Add(this.btnTest);
            this.pnlSetting.Controls.Add(this.groupBox3);
            this.pnlSetting.Controls.Add(this.pictureBox2);
            this.pnlSetting.Controls.Add(this.btnStart);
            this.pnlSetting.Controls.Add(this.lbStatus);
            this.pnlSetting.Controls.Add(this.groupBox2);
            this.pnlSetting.Controls.Add(this.btnView);
            this.pnlSetting.Controls.Add(this.btnMeasure);
            this.pnlSetting.Controls.Add(this.btnAnalyse);
            this.pnlSetting.Dock = System.Windows.Forms.DockStyle.Bottom;
            this.pnlSetting.Location = new System.Drawing.Point(0, 235);
            this.pnlSetting.Name = "pnlSetting";
            this.pnlSetting.Size = new System.Drawing.Size(253, 385);
            this.pnlSetting.TabIndex = 26;
            this.pnlSetting.MouseUp += new System.Windows.Forms.MouseEventHandler(this.Form1_MouseUp);
            // 
            // btnTest
            // 
            this.btnTest.Font = new System.Drawing.Font("SimSun", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.btnTest.Location = new System.Drawing.Point(88, 277);
            this.btnTest.Name = "btnTest";
            this.btnTest.Size = new System.Drawing.Size(74, 45);
            this.btnTest.TabIndex = 24;
            this.btnTest.Text = " Test";
            this.btnTest.UseVisualStyleBackColor = true;
            this.btnTest.Click += new System.EventHandler(this.btnTest_Click);
            // 
            // pnlRight
            // 
            this.pnlRight.Controls.Add(this.grpNames);
            this.pnlRight.Controls.Add(this.pnlSetting);
            this.pnlRight.Controls.Add(this.btOPenfile);
            this.pnlRight.Dock = System.Windows.Forms.DockStyle.Right;
            this.pnlRight.Location = new System.Drawing.Point(704, 0);
            this.pnlRight.Name = "pnlRight";
            this.pnlRight.Size = new System.Drawing.Size(253, 620);
            this.pnlRight.TabIndex = 27;
            // 
            // btnTest2
            // 
            this.btnTest2.Font = new System.Drawing.Font("SimSun", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.btnTest2.Location = new System.Drawing.Point(180, 277);
            this.btnTest2.Name = "btnTest2";
            this.btnTest2.Size = new System.Drawing.Size(74, 45);
            this.btnTest2.TabIndex = 25;
            this.btnTest2.Text = " Test2";
            this.btnTest2.UseVisualStyleBackColor = true;
            this.btnTest2.Click += new System.EventHandler(this.btnTest2_Click);
            // 
            // Form1
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(96F, 96F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Dpi;
            this.AutoScroll = true;
            this.AutoSize = true;
            this.ClientSize = new System.Drawing.Size(957, 620);
            this.Controls.Add(this.labelZ);
            this.Controls.Add(this.picChart);
            this.Controls.Add(this.fplTop);
            this.Controls.Add(this.pnlRight);
            this.Font = new System.Drawing.Font("SimSun", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.Name = "Form1";
            this.Text = "激光快速测量系统";
            this.WindowState = System.Windows.Forms.FormWindowState.Maximized;
            this.Load += new System.EventHandler(this.Form1_Load);
            this.grpNames.ResumeLayout(false);
            this.groupBox2.ResumeLayout(false);
            this.groupBox2.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox2)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.picChart)).EndInit();
            this.groupBox3.ResumeLayout(false);
            this.groupBox3.PerformLayout();
            this.fplTop.ResumeLayout(false);
            this.fplTop.PerformLayout();
            this.pnlSetting.ResumeLayout(false);
            this.pnlSetting.PerformLayout();
            this.pnlRight.ResumeLayout(false);
            this.ResumeLayout(false);
            this.PerformLayout();

        }


        private global::System.ComponentModel.IContainer components;


        private global::System.Windows.Forms.Button btOPenfile;


        private global::System.Windows.Forms.GroupBox grpNames;


        private global::System.Windows.Forms.Button btnMeasure;


        private global::System.Windows.Forms.Button btnAnalyse;


        private global::System.Windows.Forms.Button btnStart;


        private global::System.Windows.Forms.Timer timer1;


        private global::System.Windows.Forms.OpenFileDialog openFileDialog1;


        private global::System.Windows.Forms.FolderBrowserDialog folderBrowserDialog1;


        private global::System.Windows.Forms.Label label1;


        private global::System.Windows.Forms.GroupBox groupBox2;


        private global::System.Windows.Forms.Label label2;


        private global::System.Windows.Forms.ComboBox cboGrid;


        private global::System.Windows.Forms.ComboBox cboRange;


        private global::System.Windows.Forms.ComboBox cboX;


        private global::System.Windows.Forms.Label label3;


        private global::System.Windows.Forms.CheckBox chkGrid;


        private global::System.Windows.Forms.Button btnSaveLocation;


        private global::System.Windows.Forms.Label lb_path;


        private global::System.Windows.Forms.PictureBox pictureBox2;


        private global::System.Windows.Forms.Label lbOperator;


        private global::System.Windows.Forms.Label lbTime;


        private global::System.Windows.Forms.TextBox tBoxOperator;


        private global::System.Windows.Forms.TextBox tboxPart;



        private global::System.Windows.Forms.Button btnView;


        private global::System.Windows.Forms.Label label6;


        private global::System.Windows.Forms.TextBox tboxSeroNo;


        private global::System.Windows.Forms.Label lbStatus;


        private global::System.ComponentModel.BackgroundWorker bW_monitor;


        private global::System.Windows.Forms.PictureBox picChart;


        private global::System.Windows.Forms.GroupBox groupBox3;


        private global::System.Windows.Forms.TextBox tBtolzoom;


        private global::System.Windows.Forms.Label label9;


        private global::System.Windows.Forms.TextBox tBdTol;


        private global::System.Windows.Forms.Label label8;


        private global::System.Windows.Forms.TextBox tBuTol;


        private global::System.Windows.Forms.Label label7;


        private global::System.Windows.Forms.Label labelZ;
        private System.Windows.Forms.FlowLayoutPanel fplTop;
        private System.Windows.Forms.Panel pnlSetting;
        private System.Windows.Forms.Panel pnlRight;
        private System.Windows.Forms.Button btnTest;
        private System.Windows.Forms.FlowLayoutPanel flpNames;
        private System.Windows.Forms.Button btnTest2;
    }
}

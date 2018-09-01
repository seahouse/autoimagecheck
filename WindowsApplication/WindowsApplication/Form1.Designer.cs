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
            this.components = new global::System.ComponentModel.Container();
            global::System.ComponentModel.ComponentResourceManager componentResourceManager = new global::System.ComponentModel.ComponentResourceManager(typeof(global::激光快速测量系统.Form1));
            this.btOPenfile = new global::System.Windows.Forms.Button();
            this.groupBox1 = new global::System.Windows.Forms.GroupBox();
            this.label5 = new global::System.Windows.Forms.Label();
            this.label4 = new global::System.Windows.Forms.Label();
            this.button2 = new global::System.Windows.Forms.Button();
            this.button3 = new global::System.Windows.Forms.Button();
            this.btnStart = new global::System.Windows.Forms.Button();
            this.timer1 = new global::System.Windows.Forms.Timer(this.components);
            this.openFileDialog1 = new global::System.Windows.Forms.OpenFileDialog();
            this.folderBrowserDialog1 = new global::System.Windows.Forms.FolderBrowserDialog();
            this.label1 = new global::System.Windows.Forms.Label();
            this.groupBox2 = new global::System.Windows.Forms.GroupBox();
            this.comboBox3 = new global::System.Windows.Forms.ComboBox();
            this.label3 = new global::System.Windows.Forms.Label();
            this.checkBoxGrid = new global::System.Windows.Forms.CheckBox();
            this.comboBox2 = new global::System.Windows.Forms.ComboBox();
            this.comboBox1 = new global::System.Windows.Forms.ComboBox();
            this.label2 = new global::System.Windows.Forms.Label();
            this.button1 = new global::System.Windows.Forms.Button();
            this.lb_path = new global::System.Windows.Forms.Label();
            this.pictureBox2 = new global::System.Windows.Forms.PictureBox();
            this.lbOperator = new global::System.Windows.Forms.Label();
            this.lbTime = new global::System.Windows.Forms.Label();
            this.tBoxOperator = new global::System.Windows.Forms.TextBox();
            this.tboxPart = new global::System.Windows.Forms.TextBox();
            this.TimerBackgroundWorker = new global::System.ComponentModel.BackgroundWorker();
            this.button4 = new global::System.Windows.Forms.Button();
            this.label6 = new global::System.Windows.Forms.Label();
            this.tboxSeroNo = new global::System.Windows.Forms.TextBox();
            this.lbStatus = new global::System.Windows.Forms.Label();
            this.bW_monitor = new global::System.ComponentModel.BackgroundWorker();
            this.pictureBox1 = new global::System.Windows.Forms.PictureBox();
            this.groupBox3 = new global::System.Windows.Forms.GroupBox();
            this.tBtolzoom = new global::System.Windows.Forms.TextBox();
            this.label9 = new global::System.Windows.Forms.Label();
            this.tBdTol = new global::System.Windows.Forms.TextBox();
            this.label8 = new global::System.Windows.Forms.Label();
            this.tBuTol = new global::System.Windows.Forms.TextBox();
            this.label7 = new global::System.Windows.Forms.Label();
            this.labelZ = new global::System.Windows.Forms.Label();
            this.groupBox1.SuspendLayout();
            this.groupBox2.SuspendLayout();
            ((global::System.ComponentModel.ISupportInitialize)this.pictureBox2).BeginInit();
            ((global::System.ComponentModel.ISupportInitialize)this.pictureBox1).BeginInit();
            this.groupBox3.SuspendLayout();
            base.SuspendLayout();
            this.btOPenfile.BackgroundImage = (global::System.Drawing.Image)componentResourceManager.GetObject("btOPenfile.BackgroundImage");
            this.btOPenfile.Font = new global::System.Drawing.Font("宋体", 12f, global::System.Drawing.FontStyle.Regular, global::System.Drawing.GraphicsUnit.Point, 134);
            this.btOPenfile.Location = new global::System.Drawing.Point(2319, 31);
            this.btOPenfile.Name = "btOPenfile";
            this.btOPenfile.Size = new global::System.Drawing.Size(93, 31);
            this.btOPenfile.TabIndex = 0;
            this.btOPenfile.Text = "选择产品";
            this.btOPenfile.UseVisualStyleBackColor = true;
            this.btOPenfile.Click += new global::System.EventHandler(this.btOPenfile_Click);
            this.groupBox1.BackColor = global::System.Drawing.SystemColors.ActiveCaption;
            this.groupBox1.BackgroundImage = (global::System.Drawing.Image)componentResourceManager.GetObject("groupBox1.BackgroundImage");
            this.groupBox1.Controls.Add(this.label5);
            this.groupBox1.Controls.Add(this.label4);
            this.groupBox1.Font = new global::System.Drawing.Font("宋体", 12f, global::System.Drawing.FontStyle.Regular, global::System.Drawing.GraphicsUnit.Point, 134);
            this.groupBox1.ForeColor = global::System.Drawing.SystemColors.ButtonHighlight;
            this.groupBox1.Location = new global::System.Drawing.Point(2238, 77);
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.Size = new global::System.Drawing.Size(262, 787);
            this.groupBox1.TabIndex = 1;
            this.groupBox1.TabStop = false;
            this.groupBox1.Text = "截面及名称";
            this.label5.AutoSize = true;
            this.label5.BackColor = global::System.Drawing.Color.Transparent;
            this.label5.Location = new global::System.Drawing.Point(26, 397);
            this.label5.Name = "label5";
            this.label5.Size = new global::System.Drawing.Size(208, 16);
            this.label5.TabIndex = 1;
            this.label5.Text = "--------  排气边  -------";
            this.label4.AutoSize = true;
            this.label4.BackColor = global::System.Drawing.Color.Transparent;
            this.label4.Location = new global::System.Drawing.Point(26, 37);
            this.label4.Name = "label4";
            this.label4.Size = new global::System.Drawing.Size(208, 16);
            this.label4.TabIndex = 0;
            this.label4.Text = "--------  进气边  -------";
            this.button2.BackgroundImage = (global::System.Drawing.Image)componentResourceManager.GetObject("button2.BackgroundImage");
            this.button2.Enabled = false;
            this.button2.Font = new global::System.Drawing.Font("宋体", 12f, global::System.Drawing.FontStyle.Bold, global::System.Drawing.GraphicsUnit.Point, 134);
            this.button2.Location = new global::System.Drawing.Point(2242, 1289);
            this.button2.Name = "button2";
            this.button2.Size = new global::System.Drawing.Size(71, 45);
            this.button2.TabIndex = 2;
            this.button2.Text = "测 量";
            this.button2.UseVisualStyleBackColor = true;
            this.button2.Click += new global::System.EventHandler(this.button2_Click);
            this.button3.BackgroundImage = (global::System.Drawing.Image)componentResourceManager.GetObject("button3.BackgroundImage");
            this.button3.Font = new global::System.Drawing.Font("宋体", 12f, global::System.Drawing.FontStyle.Bold, global::System.Drawing.GraphicsUnit.Point, 134);
            this.button3.Location = new global::System.Drawing.Point(2338, 1289);
            this.button3.Name = "button3";
            this.button3.Size = new global::System.Drawing.Size(74, 45);
            this.button3.TabIndex = 3;
            this.button3.Text = "分 析";
            this.button3.UseVisualStyleBackColor = true;
            this.button3.Click += new global::System.EventHandler(this.button3_Click);
            this.btnStart.AutoSize = true;
            this.btnStart.Image = (global::System.Drawing.Image)componentResourceManager.GetObject("btnStart.Image");
            this.btnStart.Location = new global::System.Drawing.Point(2242, 1146);
            this.btnStart.Name = "btnStart";
            this.btnStart.Size = new global::System.Drawing.Size(55, 53);
            this.btnStart.TabIndex = 5;
            this.btnStart.Text = "start";
            this.btnStart.UseVisualStyleBackColor = true;
            this.btnStart.Click += new global::System.EventHandler(this.btnStart_Click);
            this.timer1.Interval = 40;
            this.timer1.Tick += new global::System.EventHandler(this.timer1_Tick_1);
            this.openFileDialog1.FileName = "openFileDialog1";
            this.label1.AutoSize = true;
            this.label1.BackColor = global::System.Drawing.Color.Transparent;
            this.label1.Font = new global::System.Drawing.Font("宋体", 12f, global::System.Drawing.FontStyle.Bold, global::System.Drawing.GraphicsUnit.Point, 134);
            this.label1.ForeColor = global::System.Drawing.SystemColors.ButtonHighlight;
            this.label1.Location = new global::System.Drawing.Point(381, 34);
            this.label1.Name = "label1";
            this.label1.Size = new global::System.Drawing.Size(76, 16);
            this.label1.TabIndex = 6;
            this.label1.Text = "测量产品";
            this.groupBox2.BackgroundImage = (global::System.Drawing.Image)componentResourceManager.GetObject("groupBox2.BackgroundImage");
            this.groupBox2.Controls.Add(this.comboBox3);
            this.groupBox2.Controls.Add(this.label3);
            this.groupBox2.Controls.Add(this.checkBoxGrid);
            this.groupBox2.Controls.Add(this.comboBox2);
            this.groupBox2.Controls.Add(this.comboBox1);
            this.groupBox2.Controls.Add(this.label2);
            this.groupBox2.Font = new global::System.Drawing.Font("宋体", 10.5f, global::System.Drawing.FontStyle.Regular, global::System.Drawing.GraphicsUnit.Point, 134);
            this.groupBox2.ForeColor = global::System.Drawing.SystemColors.ButtonHighlight;
            this.groupBox2.Location = new global::System.Drawing.Point(2319, 1048);
            this.groupBox2.Name = "groupBox2";
            this.groupBox2.Size = new global::System.Drawing.Size(179, 151);
            this.groupBox2.TabIndex = 8;
            this.groupBox2.TabStop = false;
            this.groupBox2.Text = "显示控制";
            this.comboBox3.FormattingEnabled = true;
            this.comboBox3.Items.AddRange(new object[]
            {
                "100",
                "40",
                "50",
                "60",
                "80"
            });
            this.comboBox3.Location = new global::System.Drawing.Point(96, 65);
            this.comboBox3.Name = "comboBox3";
            this.comboBox3.Size = new global::System.Drawing.Size(55, 22);
            this.comboBox3.Sorted = true;
            this.comboBox3.TabIndex = 8;
            this.comboBox3.Text = "60";
            this.comboBox3.SelectedIndexChanged += new global::System.EventHandler(this.comboBox3_SelectedIndexChanged);
            this.label3.AutoSize = true;
            this.label3.BackColor = global::System.Drawing.Color.Transparent;
            this.label3.ForeColor = global::System.Drawing.SystemColors.ButtonHighlight;
            this.label3.Location = new global::System.Drawing.Point(14, 68);
            this.label3.Name = "label3";
            this.label3.Size = new global::System.Drawing.Size(63, 14);
            this.label3.TabIndex = 7;
            this.label3.Text = "放大倍数";
            this.checkBoxGrid.AutoSize = true;
            this.checkBoxGrid.BackColor = global::System.Drawing.Color.Transparent;
            this.checkBoxGrid.ForeColor = global::System.Drawing.SystemColors.ButtonHighlight;
            this.checkBoxGrid.Location = new global::System.Drawing.Point(17, 106);
            this.checkBoxGrid.Name = "checkBoxGrid";
            this.checkBoxGrid.Size = new global::System.Drawing.Size(54, 18);
            this.checkBoxGrid.TabIndex = 6;
            this.checkBoxGrid.Text = "Grid";
            this.checkBoxGrid.UseVisualStyleBackColor = false;
            this.checkBoxGrid.CheckedChanged += new global::System.EventHandler(this.checkBoxGrid_CheckedChanged);
            this.comboBox2.FormattingEnabled = true;
            this.comboBox2.Items.AddRange(new object[]
            {
                "2.5",
                "3.5",
                "5.0"
            });
            this.comboBox2.Location = new global::System.Drawing.Point(96, 27);
            this.comboBox2.Name = "comboBox2";
            this.comboBox2.Size = new global::System.Drawing.Size(55, 22);
            this.comboBox2.Sorted = true;
            this.comboBox2.TabIndex = 5;
            this.comboBox2.Text = "2.5";
            this.comboBox2.SelectedIndexChanged += new global::System.EventHandler(this.comboBox2_SelectedIndexChanged);
            this.comboBox1.FormattingEnabled = true;
            this.comboBox1.Items.AddRange(new object[]
            {
                "0.1",
                "0.2",
                "0.4",
                "0.6"
            });
            this.comboBox1.Location = new global::System.Drawing.Point(94, 104);
            this.comboBox1.Name = "comboBox1";
            this.comboBox1.Size = new global::System.Drawing.Size(57, 22);
            this.comboBox1.TabIndex = 4;
            this.comboBox1.Text = "0.4";
            this.comboBox1.SelectedIndexChanged += new global::System.EventHandler(this.comboBox1_SelectedIndexChanged);
            this.label2.AutoSize = true;
            this.label2.BackColor = global::System.Drawing.Color.Transparent;
            this.label2.CausesValidation = false;
            this.label2.ForeColor = global::System.Drawing.SystemColors.ButtonHighlight;
            this.label2.Location = new global::System.Drawing.Point(14, 35);
            this.label2.Name = "label2";
            this.label2.Size = new global::System.Drawing.Size(63, 14);
            this.label2.TabIndex = 2;
            this.label2.Text = "检测范围";
            this.button1.BackColor = global::System.Drawing.SystemColors.Control;
            this.button1.BackgroundImage = (global::System.Drawing.Image)componentResourceManager.GetObject("button1.BackgroundImage");
            this.button1.Font = new global::System.Drawing.Font("宋体", 10.5f, global::System.Drawing.FontStyle.Regular, global::System.Drawing.GraphicsUnit.Point, 134);
            this.button1.ForeColor = global::System.Drawing.SystemColors.ControlText;
            this.button1.Location = new global::System.Drawing.Point(1207, 23);
            this.button1.Name = "button1";
            this.button1.Size = new global::System.Drawing.Size(87, 31);
            this.button1.TabIndex = 9;
            this.button1.Text = "保存路径";
            this.button1.UseVisualStyleBackColor = false;
            this.button1.Click += new global::System.EventHandler(this.button1_Click);
            this.lb_path.AutoSize = true;
            this.lb_path.BackColor = global::System.Drawing.Color.Transparent;
            this.lb_path.Font = new global::System.Drawing.Font("宋体", 12f, global::System.Drawing.FontStyle.Regular, global::System.Drawing.GraphicsUnit.Point, 134);
            this.lb_path.ForeColor = global::System.Drawing.SystemColors.ButtonHighlight;
            this.lb_path.Location = new global::System.Drawing.Point(1304, 32);
            this.lb_path.Name = "lb_path";
            this.lb_path.Size = new global::System.Drawing.Size(16, 16);
            this.lb_path.TabIndex = 10;
            this.lb_path.Text = "-";
            this.pictureBox2.Image = (global::System.Drawing.Image)componentResourceManager.GetObject("pictureBox2.Image");
            this.pictureBox2.Location = new global::System.Drawing.Point(2241, 1058);
            this.pictureBox2.Name = "pictureBox2";
            this.pictureBox2.Size = new global::System.Drawing.Size(50, 50);
            this.pictureBox2.TabIndex = 12;
            this.pictureBox2.TabStop = false;
            this.pictureBox2.Click += new global::System.EventHandler(this.pictureBox2_Click);
            this.lbOperator.AutoSize = true;
            this.lbOperator.BackColor = global::System.Drawing.Color.Transparent;
            this.lbOperator.Font = new global::System.Drawing.Font("宋体", 12f, global::System.Drawing.FontStyle.Bold, global::System.Drawing.GraphicsUnit.Point, 134);
            this.lbOperator.ForeColor = global::System.Drawing.SystemColors.ButtonHighlight;
            this.lbOperator.Location = new global::System.Drawing.Point(75, 33);
            this.lbOperator.Name = "lbOperator";
            this.lbOperator.Size = new global::System.Drawing.Size(42, 16);
            this.lbOperator.TabIndex = 13;
            this.lbOperator.Text = "操作";
            this.lbTime.AutoSize = true;
            this.lbTime.BackColor = global::System.Drawing.Color.Transparent;
            this.lbTime.Font = new global::System.Drawing.Font("宋体", 14.25f, global::System.Drawing.FontStyle.Regular, global::System.Drawing.GraphicsUnit.Point, 134);
            this.lbTime.ForeColor = global::System.Drawing.SystemColors.ButtonHighlight;
            this.lbTime.Location = new global::System.Drawing.Point(1821, 31);
            this.lbTime.Name = "lbTime";
            this.lbTime.Size = new global::System.Drawing.Size(47, 19);
            this.lbTime.TabIndex = 14;
            this.lbTime.Text = "日期";
            this.tBoxOperator.Font = new global::System.Drawing.Font("宋体", 12f, global::System.Drawing.FontStyle.Regular, global::System.Drawing.GraphicsUnit.Point, 134);
            this.tBoxOperator.Location = new global::System.Drawing.Point(123, 27);
            this.tBoxOperator.Name = "tBoxOperator";
            this.tBoxOperator.Size = new global::System.Drawing.Size(84, 26);
            this.tBoxOperator.TabIndex = 15;
            this.tBoxOperator.Text = "Operator";
            this.tBoxOperator.KeyPress += new global::System.Windows.Forms.KeyPressEventHandler(this.tBoxOperator_KeyPress);
            this.tboxPart.Font = new global::System.Drawing.Font("宋体", 12f, global::System.Drawing.FontStyle.Regular, global::System.Drawing.GraphicsUnit.Point, 134);
            this.tboxPart.Location = new global::System.Drawing.Point(465, 28);
            this.tboxPart.Name = "tboxPart";
            this.tboxPart.Size = new global::System.Drawing.Size(96, 26);
            this.tboxPart.TabIndex = 16;
            this.tboxPart.KeyDown += new global::System.Windows.Forms.KeyEventHandler(this.tboxPart_KeyDown);
            this.TimerBackgroundWorker.WorkerReportsProgress = true;
            this.TimerBackgroundWorker.DoWork += new global::System.ComponentModel.DoWorkEventHandler(this.TimerBackgroundWorker_DoWork);
            this.TimerBackgroundWorker.ProgressChanged += new global::System.ComponentModel.ProgressChangedEventHandler(this.TimerBackgroundWorker_ProgressChanged);
            this.button4.BackgroundImage = (global::System.Drawing.Image)componentResourceManager.GetObject("button4.BackgroundImage");
            this.button4.Font = new global::System.Drawing.Font("宋体", 12f, global::System.Drawing.FontStyle.Bold, global::System.Drawing.GraphicsUnit.Point, 134);
            this.button4.Location = new global::System.Drawing.Point(2437, 1289);
            this.button4.Name = "button4";
            this.button4.Size = new global::System.Drawing.Size(67, 45);
            this.button4.TabIndex = 18;
            this.button4.Text = "浏 览";
            this.button4.UseVisualStyleBackColor = true;
            this.button4.Click += new global::System.EventHandler(this.button4_Click);
            this.label6.AutoSize = true;
            this.label6.BackColor = global::System.Drawing.Color.Transparent;
            this.label6.Font = new global::System.Drawing.Font("宋体", 12f, global::System.Drawing.FontStyle.Bold, global::System.Drawing.GraphicsUnit.Point, 134);
            this.label6.ForeColor = global::System.Drawing.SystemColors.ButtonHighlight;
            this.label6.Location = new global::System.Drawing.Point(758, 33);
            this.label6.Name = "label6";
            this.label6.Size = new global::System.Drawing.Size(59, 16);
            this.label6.TabIndex = 19;
            this.label6.Text = "序列号";
            this.tboxSeroNo.Font = new global::System.Drawing.Font("宋体", 12f, global::System.Drawing.FontStyle.Regular, global::System.Drawing.GraphicsUnit.Point, 134);
            this.tboxSeroNo.Location = new global::System.Drawing.Point(826, 26);
            this.tboxSeroNo.Name = "tboxSeroNo";
            this.tboxSeroNo.Size = new global::System.Drawing.Size(96, 26);
            this.tboxSeroNo.TabIndex = 20;
            this.tboxSeroNo.Text = "3245";
            this.tboxSeroNo.KeyDown += new global::System.Windows.Forms.KeyEventHandler(this.tboxSeroNo_KeyDown);
            this.lbStatus.AutoSize = true;
            this.lbStatus.BackColor = global::System.Drawing.Color.Transparent;
            this.lbStatus.Font = new global::System.Drawing.Font("宋体", 10.5f, global::System.Drawing.FontStyle.Bold, global::System.Drawing.GraphicsUnit.Point, 134);
            this.lbStatus.ForeColor = global::System.Drawing.Color.Red;
            this.lbStatus.Location = new global::System.Drawing.Point(2238, 1241);
            this.lbStatus.Name = "lbStatus";
            this.lbStatus.Size = new global::System.Drawing.Size(31, 14);
            this.lbStatus.TabIndex = 21;
            this.lbStatus.Text = "...";
            this.bW_monitor.WorkerReportsProgress = true;
            this.bW_monitor.WorkerSupportsCancellation = true;
            this.bW_monitor.DoWork += new global::System.ComponentModel.DoWorkEventHandler(this.bW_monitor_DoWork);
            this.bW_monitor.ProgressChanged += new global::System.ComponentModel.ProgressChangedEventHandler(this.bW_monitor_ProgressChanged);
            this.pictureBox1.BackColor = global::System.Drawing.SystemColors.ActiveCaptionText;
            this.pictureBox1.Location = new global::System.Drawing.Point(21, 64);
            this.pictureBox1.Name = "pictureBox1";
            this.pictureBox1.Size = new global::System.Drawing.Size(2181, 1297);
            this.pictureBox1.TabIndex = 4;
            this.pictureBox1.TabStop = false;
            this.pictureBox1.Paint += new global::System.Windows.Forms.PaintEventHandler(this.pictureBox1_Paint);
            this.groupBox3.BackColor = global::System.Drawing.Color.Transparent;
            this.groupBox3.Controls.Add(this.tBtolzoom);
            this.groupBox3.Controls.Add(this.label9);
            this.groupBox3.Controls.Add(this.tBdTol);
            this.groupBox3.Controls.Add(this.label8);
            this.groupBox3.Controls.Add(this.tBuTol);
            this.groupBox3.Controls.Add(this.label7);
            this.groupBox3.Font = new global::System.Drawing.Font("宋体", 10.5f, global::System.Drawing.FontStyle.Regular, global::System.Drawing.GraphicsUnit.Point, 134);
            this.groupBox3.ForeColor = global::System.Drawing.SystemColors.ButtonHighlight;
            this.groupBox3.Location = new global::System.Drawing.Point(2238, 891);
            this.groupBox3.Name = "groupBox3";
            this.groupBox3.Size = new global::System.Drawing.Size(262, 119);
            this.groupBox3.TabIndex = 23;
            this.groupBox3.TabStop = false;
            this.groupBox3.Text = "公差";
            this.tBtolzoom.Location = new global::System.Drawing.Point(117, 83);
            this.tBtolzoom.Name = "tBtolzoom";
            this.tBtolzoom.Size = new global::System.Drawing.Size(92, 23);
            this.tBtolzoom.TabIndex = 8;
            this.tBtolzoom.Text = "2";
            this.label9.AutoSize = true;
            this.label9.BackColor = global::System.Drawing.Color.Transparent;
            this.label9.CausesValidation = false;
            this.label9.ForeColor = global::System.Drawing.SystemColors.ButtonHighlight;
            this.label9.Location = new global::System.Drawing.Point(42, 88);
            this.label9.Name = "label9";
            this.label9.Size = new global::System.Drawing.Size(63, 14);
            this.label9.TabIndex = 7;
            this.label9.Text = "偏差放大";
            this.tBdTol.Location = new global::System.Drawing.Point(117, 54);
            this.tBdTol.Name = "tBdTol";
            this.tBdTol.Size = new global::System.Drawing.Size(92, 23);
            this.tBdTol.TabIndex = 6;
            this.tBdTol.Text = "-0.05";
            this.tBdTol.KeyDown += new global::System.Windows.Forms.KeyEventHandler(this.tBdTol_KeyDown);
            this.label8.AutoSize = true;
            this.label8.BackColor = global::System.Drawing.Color.Transparent;
            this.label8.CausesValidation = false;
            this.label8.ForeColor = global::System.Drawing.SystemColors.ButtonHighlight;
            this.label8.Location = new global::System.Drawing.Point(42, 58);
            this.label8.Name = "label8";
            this.label8.Size = new global::System.Drawing.Size(49, 14);
            this.label8.TabIndex = 5;
            this.label8.Text = "下偏差";
            this.tBuTol.Location = new global::System.Drawing.Point(117, 22);
            this.tBuTol.Name = "tBuTol";
            this.tBuTol.Size = new global::System.Drawing.Size(92, 23);
            this.tBuTol.TabIndex = 4;
            this.tBuTol.Text = "0.05";
            this.tBuTol.KeyDown += new global::System.Windows.Forms.KeyEventHandler(this.tBuTol_KeyDown);
            this.label7.AutoSize = true;
            this.label7.BackColor = global::System.Drawing.Color.Transparent;
            this.label7.CausesValidation = false;
            this.label7.ForeColor = global::System.Drawing.SystemColors.ButtonHighlight;
            this.label7.Location = new global::System.Drawing.Point(43, 31);
            this.label7.Name = "label7";
            this.label7.Size = new global::System.Drawing.Size(49, 14);
            this.label7.TabIndex = 3;
            this.label7.Text = "上偏差";
            this.labelZ.AutoSize = true;
            this.labelZ.BackColor = global::System.Drawing.Color.Black;
            this.labelZ.Font = new global::System.Drawing.Font("宋体", 18f, global::System.Drawing.FontStyle.Regular, global::System.Drawing.GraphicsUnit.Point, 134);
            this.labelZ.ForeColor = global::System.Drawing.SystemColors.ButtonHighlight;
            this.labelZ.Location = new global::System.Drawing.Point(119, 189);
            this.labelZ.Name = "labelZ";
            this.labelZ.Size = new global::System.Drawing.Size(166, 24);
            this.labelZ.TabIndex = 24;
            this.labelZ.Text = "截面位置Z=0.0";
            base.AutoScaleDimensions = new global::System.Drawing.SizeF(96f, 96f);
            base.AutoScaleMode = global::System.Windows.Forms.AutoScaleMode.Dpi;
            this.AutoScroll = true;
            this.AutoSize = true;
            this.BackgroundImage = (global::System.Drawing.Image)componentResourceManager.GetObject("$this.BackgroundImage");
            base.ClientSize = new global::System.Drawing.Size(1371, 750);
            base.Controls.Add(this.labelZ);
            base.Controls.Add(this.groupBox3);
            base.Controls.Add(this.lbStatus);
            base.Controls.Add(this.tboxSeroNo);
            base.Controls.Add(this.label6);
            base.Controls.Add(this.button4);
            base.Controls.Add(this.tboxPart);
            base.Controls.Add(this.tBoxOperator);
            base.Controls.Add(this.lbTime);
            base.Controls.Add(this.lbOperator);
            base.Controls.Add(this.pictureBox2);
            base.Controls.Add(this.lb_path);
            base.Controls.Add(this.button1);
            base.Controls.Add(this.groupBox2);
            base.Controls.Add(this.label1);
            base.Controls.Add(this.btnStart);
            base.Controls.Add(this.button3);
            base.Controls.Add(this.button2);
            base.Controls.Add(this.groupBox1);
            base.Controls.Add(this.btOPenfile);
            base.Controls.Add(this.pictureBox1);
            this.Font = new global::System.Drawing.Font("宋体", 9f, global::System.Drawing.FontStyle.Regular, global::System.Drawing.GraphicsUnit.Point, 134);
            base.Icon = (global::System.Drawing.Icon)componentResourceManager.GetObject("$this.Icon");
            base.Name = "Form1";
            this.Text = "激光快速测量系统";
            base.Load += new global::System.EventHandler(this.Form1_Load);
            base.MouseDown += new global::System.Windows.Forms.MouseEventHandler(this.Form1_MouseDown);
            this.groupBox1.ResumeLayout(false);
            this.groupBox1.PerformLayout();
            this.groupBox2.ResumeLayout(false);
            this.groupBox2.PerformLayout();
            ((global::System.ComponentModel.ISupportInitialize)this.pictureBox2).EndInit();
            ((global::System.ComponentModel.ISupportInitialize)this.pictureBox1).EndInit();
            this.groupBox3.ResumeLayout(false);
            this.groupBox3.PerformLayout();
            base.ResumeLayout(false);
            base.PerformLayout();
        }


        private global::System.ComponentModel.IContainer components;


        private global::System.Windows.Forms.Button btOPenfile;


        private global::System.Windows.Forms.GroupBox groupBox1;


        private global::System.Windows.Forms.Button button2;


        private global::System.Windows.Forms.Button button3;


        private global::System.Windows.Forms.Button btnStart;


        private global::System.Windows.Forms.Timer timer1;


        private global::System.Windows.Forms.OpenFileDialog openFileDialog1;


        private global::System.Windows.Forms.FolderBrowserDialog folderBrowserDialog1;


        private global::System.Windows.Forms.Label label1;


        private global::System.Windows.Forms.GroupBox groupBox2;


        private global::System.Windows.Forms.Label label2;


        private global::System.Windows.Forms.ComboBox comboBox1;


        private global::System.Windows.Forms.ComboBox comboBox2;


        private global::System.Windows.Forms.ComboBox comboBox3;


        private global::System.Windows.Forms.Label label3;


        private global::System.Windows.Forms.CheckBox checkBoxGrid;


        private global::System.Windows.Forms.Button button1;


        private global::System.Windows.Forms.Label lb_path;


        private global::System.Windows.Forms.PictureBox pictureBox2;


        private global::System.Windows.Forms.Label label5;


        private global::System.Windows.Forms.Label label4;


        private global::System.Windows.Forms.Label lbOperator;


        private global::System.Windows.Forms.Label lbTime;


        private global::System.Windows.Forms.TextBox tBoxOperator;


        private global::System.Windows.Forms.TextBox tboxPart;


        private global::System.ComponentModel.BackgroundWorker TimerBackgroundWorker;


        private global::System.Windows.Forms.Button button4;


        private global::System.Windows.Forms.Label label6;


        private global::System.Windows.Forms.TextBox tboxSeroNo;


        private global::System.Windows.Forms.Label lbStatus;


        private global::System.ComponentModel.BackgroundWorker bW_monitor;


        private global::System.Windows.Forms.PictureBox pictureBox1;


        private global::System.Windows.Forms.GroupBox groupBox3;


        private global::System.Windows.Forms.TextBox tBtolzoom;


        private global::System.Windows.Forms.Label label9;


        private global::System.Windows.Forms.TextBox tBdTol;


        private global::System.Windows.Forms.Label label8;


        private global::System.Windows.Forms.TextBox tBuTol;


        private global::System.Windows.Forms.Label label7;


        private global::System.Windows.Forms.Label labelZ;
    }
}

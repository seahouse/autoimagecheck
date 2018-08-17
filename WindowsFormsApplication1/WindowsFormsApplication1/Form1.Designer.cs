namespace WindowsFormsApplication1
{
  partial class Form1
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
      this.components = new System.ComponentModel.Container();
      System.Windows.Forms.DataVisualization.Charting.ChartArea chartArea1 = new System.Windows.Forms.DataVisualization.Charting.ChartArea();
      System.Windows.Forms.DataVisualization.Charting.Legend legend1 = new System.Windows.Forms.DataVisualization.Charting.Legend();
      System.Windows.Forms.DataVisualization.Charting.Series series1 = new System.Windows.Forms.DataVisualization.Charting.Series();
      System.Windows.Forms.DataVisualization.Charting.Series series2 = new System.Windows.Forms.DataVisualization.Charting.Series();
      System.Windows.Forms.DataVisualization.Charting.Series series3 = new System.Windows.Forms.DataVisualization.Charting.Series();
      System.Windows.Forms.DataVisualization.Charting.Series series4 = new System.Windows.Forms.DataVisualization.Charting.Series();
      this.chart = new System.Windows.Forms.DataVisualization.Charting.Chart();
      this.timer = new System.Windows.Forms.Timer(this.components);
      this.btnLoadTxtData = new System.Windows.Forms.Button();
      this._btnUsbOpen = new System.Windows.Forms.Button();
      this._txtboxLog = new System.Windows.Forms.TextBox();
      this._pnlDeviceId = new System.Windows.Forms.Panel();
      this._lblDeviceStatus5 = new System.Windows.Forms.Label();
      this._lblDeviceStatus4 = new System.Windows.Forms.Label();
      this.radioButton2 = new System.Windows.Forms.RadioButton();
      this.radioButton1 = new System.Windows.Forms.RadioButton();
      this.panel1 = new System.Windows.Forms.Panel();
      this._lblReceiveProfileCount5 = new System.Windows.Forms.Label();
      this._lblReceiveProfileCount4 = new System.Windows.Forms.Label();
      this._lblReceiveProfileCount3 = new System.Windows.Forms.Label();
      this.label3 = new System.Windows.Forms.Label();
      this._lblReceiveProfileCount0 = new System.Windows.Forms.Label();
      this._lblReceiveProfileCount1 = new System.Windows.Forms.Label();
      this._lblReceiveProfileCount2 = new System.Windows.Forms.Label();
      this.label5 = new System.Windows.Forms.Label();
      this.label4 = new System.Windows.Forms.Label();
      this._lblDeviceStatus3 = new System.Windows.Forms.Label();
      this._lblDeviceStatus2 = new System.Windows.Forms.Label();
      this._lblDeviceStatus1 = new System.Windows.Forms.Label();
      this._lblDeviceStatus0 = new System.Windows.Forms.Label();
      this._rdDevice3 = new System.Windows.Forms.RadioButton();
      this._rdDevice2 = new System.Windows.Forms.RadioButton();
      this._rdDevice1 = new System.Windows.Forms.RadioButton();
      this._rdDevice0 = new System.Windows.Forms.RadioButton();
      this._btnGetProfile = new System.Windows.Forms.Button();
      this._grpExport = new System.Windows.Forms.GroupBox();
      this._nudProfileNo = new System.Windows.Forms.NumericUpDown();
      this._txtboxProfileFilePath = new System.Windows.Forms.TextBox();
      this._btnSaveMeasureData = new System.Windows.Forms.Button();
      this._btnSave = new System.Windows.Forms.Button();
      this._btnProfileFileSave = new System.Windows.Forms.Button();
      this.label2 = new System.Windows.Forms.Label();
      this._lblSavePath = new System.Windows.Forms.Label();
      this._grpMeasureRange = new System.Windows.Forms.GroupBox();
      this._cmbReceivedBinning = new System.Windows.Forms.ComboBox();
      this._cmbMeasureX = new System.Windows.Forms.ComboBox();
      this._lblReceivedBinning = new System.Windows.Forms.Label();
      this._lblMeasureX = new System.Windows.Forms.Label();
      this._grpReceived = new System.Windows.Forms.GroupBox();
      this._chkboxEnvelope = new System.Windows.Forms.CheckBox();
      this._cmbCompressX = new System.Windows.Forms.ComboBox();
      this._lblCompressX = new System.Windows.Forms.Label();
      this._grpHead = new System.Windows.Forms.GroupBox();
      this._rdbtnOneHead = new System.Windows.Forms.RadioButton();
      this._rdbtnTwoHead = new System.Windows.Forms.RadioButton();
      this._rdbtnWide = new System.Windows.Forms.RadioButton();
      this._btnHighSpeedDataUsbCommunicationInitalize = new System.Windows.Forms.Button();
      this._chkOnlyProfileCount = new System.Windows.Forms.CheckBox();
      this._btnPreStartHighSpeedDataCommunication = new System.Windows.Forms.Button();
      this._btnStartHighSpeedDataCommunication = new System.Windows.Forms.Button();
      this._btnHighSpeedDataCommunicationFinalize = new System.Windows.Forms.Button();
      this.btnLoadTxtData2 = new System.Windows.Forms.Button();
      this.btnLoadTxtData4 = new System.Windows.Forms.Button();
      this.btnLoadTxtData3 = new System.Windows.Forms.Button();
      this._numInterval = new System.Windows.Forms.NumericUpDown();
      this._chkStartTimer = new System.Windows.Forms.CheckBox();
      this._timerHighSpeedReceive = new System.Windows.Forms.Timer(this.components);
      this.button1 = new System.Windows.Forms.Button();
      this.button2 = new System.Windows.Forms.Button();
      this.button3 = new System.Windows.Forms.Button();
      this.btnCalc = new System.Windows.Forms.Button();
      ((System.ComponentModel.ISupportInitialize)(this.chart)).BeginInit();
      this._pnlDeviceId.SuspendLayout();
      this.panel1.SuspendLayout();
      this._grpExport.SuspendLayout();
      ((System.ComponentModel.ISupportInitialize)(this._nudProfileNo)).BeginInit();
      this._grpMeasureRange.SuspendLayout();
      this._grpReceived.SuspendLayout();
      this._grpHead.SuspendLayout();
      ((System.ComponentModel.ISupportInitialize)(this._numInterval)).BeginInit();
      this.SuspendLayout();
      // 
      // chart
      // 
      chartArea1.Name = "ChartArea1";
      this.chart.ChartAreas.Add(chartArea1);
      legend1.Name = "Legend1";
      this.chart.Legends.Add(legend1);
      this.chart.Location = new System.Drawing.Point(32, 28);
      this.chart.Name = "chart";
      series1.ChartArea = "ChartArea1";
      series1.Legend = "Legend1";
      series1.Name = "Series1";
      series2.ChartArea = "ChartArea1";
      series2.ChartType = System.Windows.Forms.DataVisualization.Charting.SeriesChartType.Spline;
      series2.Legend = "Legend1";
      series2.Name = "Series2";
      series3.ChartArea = "ChartArea1";
      series3.ChartType = System.Windows.Forms.DataVisualization.Charting.SeriesChartType.Spline;
      series3.Legend = "Legend1";
      series3.Name = "Series3";
      series4.ChartArea = "ChartArea1";
      series4.ChartType = System.Windows.Forms.DataVisualization.Charting.SeriesChartType.Spline;
      series4.Legend = "Legend1";
      series4.Name = "Series4";
      this.chart.Series.Add(series1);
      this.chart.Series.Add(series2);
      this.chart.Series.Add(series3);
      this.chart.Series.Add(series4);
      this.chart.Size = new System.Drawing.Size(550, 500);
      this.chart.TabIndex = 0;
      this.chart.Text = "chart1";
      // 
      // timer
      // 
      this.timer.Tick += new System.EventHandler(this.timer_Tick);
      // 
      // btnLoadTxtData
      // 
      this.btnLoadTxtData.Location = new System.Drawing.Point(32, 556);
      this.btnLoadTxtData.Name = "btnLoadTxtData";
      this.btnLoadTxtData.Size = new System.Drawing.Size(75, 23);
      this.btnLoadTxtData.TabIndex = 1;
      this.btnLoadTxtData.Text = "button1";
      this.btnLoadTxtData.UseVisualStyleBackColor = true;
      this.btnLoadTxtData.Click += new System.EventHandler(this.btnLoadTxtData_Click);
      // 
      // _btnUsbOpen
      // 
      this._btnUsbOpen.BackColor = System.Drawing.Color.LightGray;
      this._btnUsbOpen.Location = new System.Drawing.Point(32, 596);
      this._btnUsbOpen.Name = "_btnUsbOpen";
      this._btnUsbOpen.Size = new System.Drawing.Size(145, 23);
      this._btnUsbOpen.TabIndex = 2;
      this._btnUsbOpen.Text = "UsbOpen";
      this._btnUsbOpen.UseVisualStyleBackColor = false;
      this._btnUsbOpen.Click += new System.EventHandler(this._btnUsbOpen_Click);
      // 
      // _txtboxLog
      // 
      this._txtboxLog.Font = new System.Drawing.Font("Tahoma", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
      this._txtboxLog.Location = new System.Drawing.Point(632, 536);
      this._txtboxLog.Multiline = true;
      this._txtboxLog.Name = "_txtboxLog";
      this._txtboxLog.ScrollBars = System.Windows.Forms.ScrollBars.Vertical;
      this._txtboxLog.Size = new System.Drawing.Size(315, 70);
      this._txtboxLog.TabIndex = 3;
      // 
      // _pnlDeviceId
      // 
      this._pnlDeviceId.BackColor = System.Drawing.Color.DarkGray;
      this._pnlDeviceId.Controls.Add(this._lblDeviceStatus5);
      this._pnlDeviceId.Controls.Add(this._lblDeviceStatus4);
      this._pnlDeviceId.Controls.Add(this.radioButton2);
      this._pnlDeviceId.Controls.Add(this.radioButton1);
      this._pnlDeviceId.Controls.Add(this.panel1);
      this._pnlDeviceId.Controls.Add(this.label5);
      this._pnlDeviceId.Controls.Add(this.label4);
      this._pnlDeviceId.Controls.Add(this._lblDeviceStatus3);
      this._pnlDeviceId.Controls.Add(this._lblDeviceStatus2);
      this._pnlDeviceId.Controls.Add(this._lblDeviceStatus1);
      this._pnlDeviceId.Controls.Add(this._lblDeviceStatus0);
      this._pnlDeviceId.Controls.Add(this._rdDevice3);
      this._pnlDeviceId.Controls.Add(this._rdDevice2);
      this._pnlDeviceId.Controls.Add(this._rdDevice1);
      this._pnlDeviceId.Controls.Add(this._rdDevice0);
      this._pnlDeviceId.Location = new System.Drawing.Point(844, 28);
      this._pnlDeviceId.Name = "_pnlDeviceId";
      this._pnlDeviceId.Size = new System.Drawing.Size(334, 140);
      this._pnlDeviceId.TabIndex = 4;
      this._pnlDeviceId.Tag = "";
      // 
      // _lblDeviceStatus5
      // 
      this._lblDeviceStatus5.AutoSize = true;
      this._lblDeviceStatus5.Location = new System.Drawing.Point(55, 118);
      this._lblDeviceStatus5.Name = "_lblDeviceStatus5";
      this._lblDeviceStatus5.Size = new System.Drawing.Size(72, 13);
      this._lblDeviceStatus5.TabIndex = 65;
      this._lblDeviceStatus5.Text = "Unconnected";
      // 
      // _lblDeviceStatus4
      // 
      this._lblDeviceStatus4.AutoSize = true;
      this._lblDeviceStatus4.Location = new System.Drawing.Point(55, 102);
      this._lblDeviceStatus4.Name = "_lblDeviceStatus4";
      this._lblDeviceStatus4.Size = new System.Drawing.Size(72, 13);
      this._lblDeviceStatus4.TabIndex = 64;
      this._lblDeviceStatus4.Text = "Unconnected";
      // 
      // radioButton2
      // 
      this.radioButton2.AutoSize = true;
      this.radioButton2.Location = new System.Drawing.Point(8, 114);
      this.radioButton2.Name = "radioButton2";
      this.radioButton2.Size = new System.Drawing.Size(31, 17);
      this.radioButton2.TabIndex = 63;
      this.radioButton2.Tag = "5";
      this.radioButton2.Text = "&5";
      this.radioButton2.UseVisualStyleBackColor = true;
      // 
      // radioButton1
      // 
      this.radioButton1.AutoSize = true;
      this.radioButton1.Location = new System.Drawing.Point(8, 97);
      this.radioButton1.Name = "radioButton1";
      this.radioButton1.Size = new System.Drawing.Size(31, 17);
      this.radioButton1.TabIndex = 62;
      this.radioButton1.Tag = "4";
      this.radioButton1.Text = "&4";
      this.radioButton1.UseVisualStyleBackColor = true;
      // 
      // panel1
      // 
      this.panel1.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(192)))), ((int)(((byte)(255)))), ((int)(((byte)(255)))));
      this.panel1.Controls.Add(this._lblReceiveProfileCount5);
      this.panel1.Controls.Add(this._lblReceiveProfileCount4);
      this.panel1.Controls.Add(this._lblReceiveProfileCount3);
      this.panel1.Controls.Add(this.label3);
      this.panel1.Controls.Add(this._lblReceiveProfileCount0);
      this.panel1.Controls.Add(this._lblReceiveProfileCount1);
      this.panel1.Controls.Add(this._lblReceiveProfileCount2);
      this.panel1.Location = new System.Drawing.Point(205, 3);
      this.panel1.Name = "panel1";
      this.panel1.Size = new System.Drawing.Size(121, 135);
      this.panel1.TabIndex = 59;
      // 
      // _lblReceiveProfileCount5
      // 
      this._lblReceiveProfileCount5.AutoSize = true;
      this._lblReceiveProfileCount5.BackColor = System.Drawing.Color.Transparent;
      this._lblReceiveProfileCount5.Location = new System.Drawing.Point(3, 114);
      this._lblReceiveProfileCount5.Name = "_lblReceiveProfileCount5";
      this._lblReceiveProfileCount5.Size = new System.Drawing.Size(13, 13);
      this._lblReceiveProfileCount5.TabIndex = 6;
      this._lblReceiveProfileCount5.Text = "0";
      // 
      // _lblReceiveProfileCount4
      // 
      this._lblReceiveProfileCount4.AutoSize = true;
      this._lblReceiveProfileCount4.BackColor = System.Drawing.Color.Transparent;
      this._lblReceiveProfileCount4.Location = new System.Drawing.Point(3, 97);
      this._lblReceiveProfileCount4.Name = "_lblReceiveProfileCount4";
      this._lblReceiveProfileCount4.Size = new System.Drawing.Size(13, 13);
      this._lblReceiveProfileCount4.TabIndex = 5;
      this._lblReceiveProfileCount4.Text = "0";
      // 
      // _lblReceiveProfileCount3
      // 
      this._lblReceiveProfileCount3.AutoSize = true;
      this._lblReceiveProfileCount3.BackColor = System.Drawing.Color.Transparent;
      this._lblReceiveProfileCount3.Location = new System.Drawing.Point(3, 79);
      this._lblReceiveProfileCount3.Name = "_lblReceiveProfileCount3";
      this._lblReceiveProfileCount3.Size = new System.Drawing.Size(13, 13);
      this._lblReceiveProfileCount3.TabIndex = 4;
      this._lblReceiveProfileCount3.Text = "0";
      // 
      // label3
      // 
      this.label3.Font = new System.Drawing.Font("Tahoma", 8.25F, ((System.Drawing.FontStyle)((System.Drawing.FontStyle.Bold | System.Drawing.FontStyle.Underline))), System.Drawing.GraphicsUnit.Point, ((byte)(0)));
      this.label3.Location = new System.Drawing.Point(3, 3);
      this.label3.Name = "label3";
      this.label3.Size = new System.Drawing.Size(174, 30);
      this.label3.TabIndex = 0;
      this.label3.Text = "Number of \r\nreceived profiles";
      // 
      // _lblReceiveProfileCount0
      // 
      this._lblReceiveProfileCount0.AutoSize = true;
      this._lblReceiveProfileCount0.BackColor = System.Drawing.Color.Transparent;
      this._lblReceiveProfileCount0.Location = new System.Drawing.Point(3, 31);
      this._lblReceiveProfileCount0.Name = "_lblReceiveProfileCount0";
      this._lblReceiveProfileCount0.Size = new System.Drawing.Size(13, 13);
      this._lblReceiveProfileCount0.TabIndex = 1;
      this._lblReceiveProfileCount0.Text = "0";
      // 
      // _lblReceiveProfileCount1
      // 
      this._lblReceiveProfileCount1.AutoSize = true;
      this._lblReceiveProfileCount1.BackColor = System.Drawing.Color.Transparent;
      this._lblReceiveProfileCount1.Location = new System.Drawing.Point(3, 48);
      this._lblReceiveProfileCount1.Name = "_lblReceiveProfileCount1";
      this._lblReceiveProfileCount1.Size = new System.Drawing.Size(13, 13);
      this._lblReceiveProfileCount1.TabIndex = 2;
      this._lblReceiveProfileCount1.Text = "0";
      // 
      // _lblReceiveProfileCount2
      // 
      this._lblReceiveProfileCount2.AutoSize = true;
      this._lblReceiveProfileCount2.BackColor = System.Drawing.Color.Transparent;
      this._lblReceiveProfileCount2.Location = new System.Drawing.Point(3, 65);
      this._lblReceiveProfileCount2.Name = "_lblReceiveProfileCount2";
      this._lblReceiveProfileCount2.Size = new System.Drawing.Size(13, 13);
      this._lblReceiveProfileCount2.TabIndex = 3;
      this._lblReceiveProfileCount2.Text = "0";
      // 
      // label5
      // 
      this.label5.AutoSize = true;
      this.label5.Font = new System.Drawing.Font("Tahoma", 8.25F, ((System.Drawing.FontStyle)((System.Drawing.FontStyle.Bold | System.Drawing.FontStyle.Underline))), System.Drawing.GraphicsUnit.Point, ((byte)(0)));
      this.label5.Location = new System.Drawing.Point(42, 12);
      this.label5.Name = "label5";
      this.label5.Size = new System.Drawing.Size(145, 13);
      this.label5.TabIndex = 1;
      this.label5.Text = "State (USB / IP address)";
      // 
      // label4
      // 
      this.label4.AutoSize = true;
      this.label4.Font = new System.Drawing.Font("Tahoma", 8.25F, ((System.Drawing.FontStyle)((System.Drawing.FontStyle.Bold | System.Drawing.FontStyle.Underline))), System.Drawing.GraphicsUnit.Point, ((byte)(0)));
      this.label4.Location = new System.Drawing.Point(19, 12);
      this.label4.Name = "label4";
      this.label4.Size = new System.Drawing.Size(20, 13);
      this.label4.TabIndex = 0;
      this.label4.Text = "ID";
      // 
      // _lblDeviceStatus3
      // 
      this._lblDeviceStatus3.AutoSize = true;
      this._lblDeviceStatus3.Location = new System.Drawing.Point(55, 84);
      this._lblDeviceStatus3.Name = "_lblDeviceStatus3";
      this._lblDeviceStatus3.Size = new System.Drawing.Size(72, 13);
      this._lblDeviceStatus3.TabIndex = 61;
      this._lblDeviceStatus3.Text = "Unconnected";
      // 
      // _lblDeviceStatus2
      // 
      this._lblDeviceStatus2.AutoSize = true;
      this._lblDeviceStatus2.Location = new System.Drawing.Point(55, 66);
      this._lblDeviceStatus2.Name = "_lblDeviceStatus2";
      this._lblDeviceStatus2.Size = new System.Drawing.Size(72, 13);
      this._lblDeviceStatus2.TabIndex = 7;
      this._lblDeviceStatus2.Text = "Unconnected";
      // 
      // _lblDeviceStatus1
      // 
      this._lblDeviceStatus1.AutoSize = true;
      this._lblDeviceStatus1.Location = new System.Drawing.Point(55, 51);
      this._lblDeviceStatus1.Name = "_lblDeviceStatus1";
      this._lblDeviceStatus1.Size = new System.Drawing.Size(72, 13);
      this._lblDeviceStatus1.TabIndex = 5;
      this._lblDeviceStatus1.Text = "Unconnected";
      // 
      // _lblDeviceStatus0
      // 
      this._lblDeviceStatus0.AutoSize = true;
      this._lblDeviceStatus0.Location = new System.Drawing.Point(55, 35);
      this._lblDeviceStatus0.Name = "_lblDeviceStatus0";
      this._lblDeviceStatus0.Size = new System.Drawing.Size(72, 13);
      this._lblDeviceStatus0.TabIndex = 3;
      this._lblDeviceStatus0.Text = "Unconnected";
      // 
      // _rdDevice3
      // 
      this._rdDevice3.AutoSize = true;
      this._rdDevice3.Location = new System.Drawing.Point(8, 80);
      this._rdDevice3.Name = "_rdDevice3";
      this._rdDevice3.Size = new System.Drawing.Size(31, 17);
      this._rdDevice3.TabIndex = 60;
      this._rdDevice3.Tag = "3";
      this._rdDevice3.Text = "&3";
      this._rdDevice3.TextImageRelation = System.Windows.Forms.TextImageRelation.TextAboveImage;
      this._rdDevice3.UseVisualStyleBackColor = true;
      // 
      // _rdDevice2
      // 
      this._rdDevice2.AutoSize = true;
      this._rdDevice2.Location = new System.Drawing.Point(8, 66);
      this._rdDevice2.Name = "_rdDevice2";
      this._rdDevice2.Size = new System.Drawing.Size(31, 17);
      this._rdDevice2.TabIndex = 6;
      this._rdDevice2.Tag = "2";
      this._rdDevice2.Text = "&2";
      this._rdDevice2.UseVisualStyleBackColor = true;
      // 
      // _rdDevice1
      // 
      this._rdDevice1.AutoSize = true;
      this._rdDevice1.Location = new System.Drawing.Point(8, 49);
      this._rdDevice1.Name = "_rdDevice1";
      this._rdDevice1.Size = new System.Drawing.Size(31, 17);
      this._rdDevice1.TabIndex = 4;
      this._rdDevice1.Tag = "1";
      this._rdDevice1.Text = "&1";
      this._rdDevice1.UseVisualStyleBackColor = true;
      // 
      // _rdDevice0
      // 
      this._rdDevice0.AutoSize = true;
      this._rdDevice0.Checked = true;
      this._rdDevice0.Location = new System.Drawing.Point(8, 32);
      this._rdDevice0.Name = "_rdDevice0";
      this._rdDevice0.Size = new System.Drawing.Size(31, 17);
      this._rdDevice0.TabIndex = 2;
      this._rdDevice0.TabStop = true;
      this._rdDevice0.Tag = "0";
      this._rdDevice0.Text = "&0";
      this._rdDevice0.UseVisualStyleBackColor = true;
      // 
      // _btnGetProfile
      // 
      this._btnGetProfile.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(192)))), ((int)(((byte)(255)))), ((int)(((byte)(192)))));
      this._btnGetProfile.ForeColor = System.Drawing.SystemColors.ControlText;
      this._btnGetProfile.Location = new System.Drawing.Point(200, 596);
      this._btnGetProfile.Name = "_btnGetProfile";
      this._btnGetProfile.Size = new System.Drawing.Size(142, 23);
      this._btnGetProfile.TabIndex = 5;
      this._btnGetProfile.Text = "GetProfile";
      this._btnGetProfile.UseVisualStyleBackColor = false;
      this._btnGetProfile.Click += new System.EventHandler(this._btnGetProfile_Click);
      // 
      // _grpExport
      // 
      this._grpExport.Controls.Add(this._nudProfileNo);
      this._grpExport.Controls.Add(this._txtboxProfileFilePath);
      this._grpExport.Controls.Add(this._btnSaveMeasureData);
      this._grpExport.Controls.Add(this._btnSave);
      this._grpExport.Controls.Add(this._btnProfileFileSave);
      this._grpExport.Controls.Add(this.label2);
      this._grpExport.Controls.Add(this._lblSavePath);
      this._grpExport.Location = new System.Drawing.Point(840, 364);
      this._grpExport.Name = "_grpExport";
      this._grpExport.Size = new System.Drawing.Size(339, 92);
      this._grpExport.TabIndex = 6;
      this._grpExport.TabStop = false;
      this._grpExport.Text = "Save the results file";
      // 
      // _nudProfileNo
      // 
      this._nudProfileNo.Location = new System.Drawing.Point(170, 42);
      this._nudProfileNo.Maximum = new decimal(new int[] {
            999,
            0,
            0,
            0});
      this._nudProfileNo.Name = "_nudProfileNo";
      this._nudProfileNo.Size = new System.Drawing.Size(43, 20);
      this._nudProfileNo.TabIndex = 4;
      // 
      // _txtboxProfileFilePath
      // 
      this._txtboxProfileFilePath.Location = new System.Drawing.Point(105, 18);
      this._txtboxProfileFilePath.Name = "_txtboxProfileFilePath";
      this._txtboxProfileFilePath.Size = new System.Drawing.Size(189, 20);
      this._txtboxProfileFilePath.TabIndex = 1;
      this._txtboxProfileFilePath.Text = "C:\\liangyi\\autoimagecheck\\WindowsFormsApplication1\\WindowsFormsApplication1\\bin\\D" +
    "ebug\\111.txt";
      // 
      // _btnSaveMeasureData
      // 
      this._btnSaveMeasureData.Location = new System.Drawing.Point(193, 65);
      this._btnSaveMeasureData.Name = "_btnSaveMeasureData";
      this._btnSaveMeasureData.Size = new System.Drawing.Size(130, 23);
      this._btnSaveMeasureData.TabIndex = 6;
      this._btnSaveMeasureData.Text = "Save the measurement value";
      this._btnSaveMeasureData.UseVisualStyleBackColor = true;
      // 
      // _btnSave
      // 
      this._btnSave.Location = new System.Drawing.Point(44, 65);
      this._btnSave.Name = "_btnSave";
      this._btnSave.Size = new System.Drawing.Size(132, 23);
      this._btnSave.TabIndex = 5;
      this._btnSave.Text = "Save the profile";
      this._btnSave.UseVisualStyleBackColor = true;
      // 
      // _btnProfileFileSave
      // 
      this._btnProfileFileSave.Location = new System.Drawing.Point(300, 18);
      this._btnProfileFileSave.Name = "_btnProfileFileSave";
      this._btnProfileFileSave.Size = new System.Drawing.Size(25, 18);
      this._btnProfileFileSave.TabIndex = 2;
      this._btnProfileFileSave.Text = "...";
      this._btnProfileFileSave.UseVisualStyleBackColor = true;
      // 
      // label2
      // 
      this.label2.AutoSize = true;
      this.label2.Location = new System.Drawing.Point(8, 43);
      this.label2.Name = "label2";
      this.label2.Size = new System.Drawing.Size(132, 13);
      this.label2.TabIndex = 3;
      this.label2.Text = "Index of the profile to save";
      // 
      // _lblSavePath
      // 
      this._lblSavePath.AutoSize = true;
      this._lblSavePath.Location = new System.Drawing.Point(9, 22);
      this._lblSavePath.Name = "_lblSavePath";
      this._lblSavePath.Size = new System.Drawing.Size(86, 13);
      this._lblSavePath.TabIndex = 0;
      this._lblSavePath.Text = "Save destination";
      // 
      // _grpMeasureRange
      // 
      this._grpMeasureRange.Controls.Add(this._cmbReceivedBinning);
      this._grpMeasureRange.Controls.Add(this._cmbMeasureX);
      this._grpMeasureRange.Controls.Add(this._lblReceivedBinning);
      this._grpMeasureRange.Controls.Add(this._lblMeasureX);
      this._grpMeasureRange.Location = new System.Drawing.Point(848, 216);
      this._grpMeasureRange.Name = "_grpMeasureRange";
      this._grpMeasureRange.Size = new System.Drawing.Size(317, 67);
      this._grpMeasureRange.TabIndex = 7;
      this._grpMeasureRange.TabStop = false;
      this._grpMeasureRange.Text = "Imaging settings";
      // 
      // _cmbReceivedBinning
      // 
      this._cmbReceivedBinning.DisplayMember = "Key";
      this._cmbReceivedBinning.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
      this._cmbReceivedBinning.FormattingEnabled = true;
      this._cmbReceivedBinning.Location = new System.Drawing.Point(182, 42);
      this._cmbReceivedBinning.Name = "_cmbReceivedBinning";
      this._cmbReceivedBinning.Size = new System.Drawing.Size(91, 21);
      this._cmbReceivedBinning.TabIndex = 3;
      this._cmbReceivedBinning.ValueMember = "Value";
      // 
      // _cmbMeasureX
      // 
      this._cmbMeasureX.DisplayMember = "Key";
      this._cmbMeasureX.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
      this._cmbMeasureX.FormattingEnabled = true;
      this._cmbMeasureX.Location = new System.Drawing.Point(182, 17);
      this._cmbMeasureX.Name = "_cmbMeasureX";
      this._cmbMeasureX.Size = new System.Drawing.Size(91, 21);
      this._cmbMeasureX.TabIndex = 1;
      this._cmbMeasureX.ValueMember = "Value";
      // 
      // _lblReceivedBinning
      // 
      this._lblReceivedBinning.AutoSize = true;
      this._lblReceivedBinning.Location = new System.Drawing.Point(13, 46);
      this._lblReceivedBinning.Name = "_lblReceivedBinning";
      this._lblReceivedBinning.Size = new System.Drawing.Size(42, 13);
      this._lblReceivedBinning.TabIndex = 2;
      this._lblReceivedBinning.Text = "Binning";
      // 
      // _lblMeasureX
      // 
      this._lblMeasureX.AutoSize = true;
      this._lblMeasureX.Location = new System.Drawing.Point(12, 19);
      this._lblMeasureX.Name = "_lblMeasureX";
      this._lblMeasureX.Size = new System.Drawing.Size(154, 13);
      this._lblMeasureX.TabIndex = 0;
      this._lblMeasureX.Text = "Measurement range X direction";
      // 
      // _grpReceived
      // 
      this._grpReceived.Controls.Add(this._chkboxEnvelope);
      this._grpReceived.Controls.Add(this._cmbCompressX);
      this._grpReceived.Controls.Add(this._lblCompressX);
      this._grpReceived.Location = new System.Drawing.Point(848, 296);
      this._grpReceived.Name = "_grpReceived";
      this._grpReceived.Size = new System.Drawing.Size(317, 50);
      this._grpReceived.TabIndex = 8;
      this._grpReceived.TabStop = false;
      this._grpReceived.Text = "Profile settings";
      // 
      // _chkboxEnvelope
      // 
      this._chkboxEnvelope.AutoSize = true;
      this._chkboxEnvelope.Checked = true;
      this._chkboxEnvelope.CheckState = System.Windows.Forms.CheckState.Checked;
      this._chkboxEnvelope.Location = new System.Drawing.Point(196, 20);
      this._chkboxEnvelope.Name = "_chkboxEnvelope";
      this._chkboxEnvelope.Size = new System.Drawing.Size(105, 17);
      this._chkboxEnvelope.TabIndex = 2;
      this._chkboxEnvelope.Text = "Envelope setting";
      this._chkboxEnvelope.UseVisualStyleBackColor = true;
      // 
      // _cmbCompressX
      // 
      this._cmbCompressX.DisplayMember = "Key";
      this._cmbCompressX.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
      this._cmbCompressX.FormattingEnabled = true;
      this._cmbCompressX.Location = new System.Drawing.Point(127, 18);
      this._cmbCompressX.Name = "_cmbCompressX";
      this._cmbCompressX.Size = new System.Drawing.Size(59, 21);
      this._cmbCompressX.TabIndex = 1;
      this._cmbCompressX.ValueMember = "Value";
      // 
      // _lblCompressX
      // 
      this._lblCompressX.AutoSize = true;
      this._lblCompressX.Location = new System.Drawing.Point(6, 22);
      this._lblCompressX.Name = "_lblCompressX";
      this._lblCompressX.Size = new System.Drawing.Size(104, 13);
      this._lblCompressX.TabIndex = 0;
      this._lblCompressX.Text = "Compression (X axis)";
      // 
      // _grpHead
      // 
      this._grpHead.Controls.Add(this._rdbtnOneHead);
      this._grpHead.Controls.Add(this._rdbtnTwoHead);
      this._grpHead.Controls.Add(this._rdbtnWide);
      this._grpHead.Location = new System.Drawing.Point(844, 172);
      this._grpHead.Name = "_grpHead";
      this._grpHead.Size = new System.Drawing.Size(317, 38);
      this._grpHead.TabIndex = 9;
      this._grpHead.TabStop = false;
      this._grpHead.Text = "Head";
      // 
      // _rdbtnOneHead
      // 
      this._rdbtnOneHead.AutoSize = true;
      this._rdbtnOneHead.Location = new System.Drawing.Point(21, 17);
      this._rdbtnOneHead.Name = "_rdbtnOneHead";
      this._rdbtnOneHead.Size = new System.Drawing.Size(74, 17);
      this._rdbtnOneHead.TabIndex = 0;
      this._rdbtnOneHead.Text = "One Head";
      this._rdbtnOneHead.UseVisualStyleBackColor = true;
      // 
      // _rdbtnTwoHead
      // 
      this._rdbtnTwoHead.AutoSize = true;
      this._rdbtnTwoHead.Checked = true;
      this._rdbtnTwoHead.Location = new System.Drawing.Point(104, 17);
      this._rdbtnTwoHead.Name = "_rdbtnTwoHead";
      this._rdbtnTwoHead.Size = new System.Drawing.Size(75, 17);
      this._rdbtnTwoHead.TabIndex = 1;
      this._rdbtnTwoHead.TabStop = true;
      this._rdbtnTwoHead.Text = "Two Head";
      this._rdbtnTwoHead.UseVisualStyleBackColor = true;
      // 
      // _rdbtnWide
      // 
      this._rdbtnWide.AutoSize = true;
      this._rdbtnWide.Location = new System.Drawing.Point(187, 17);
      this._rdbtnWide.Name = "_rdbtnWide";
      this._rdbtnWide.Size = new System.Drawing.Size(109, 17);
      this._rdbtnWide.TabIndex = 2;
      this._rdbtnWide.Text = "Two heads (wide)";
      this._rdbtnWide.UseVisualStyleBackColor = true;
      // 
      // _btnHighSpeedDataUsbCommunicationInitalize
      // 
      this._btnHighSpeedDataUsbCommunicationInitalize.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(192)))), ((int)(((byte)(218)))), ((int)(((byte)(255)))));
      this._btnHighSpeedDataUsbCommunicationInitalize.ForeColor = System.Drawing.SystemColors.ControlText;
      this._btnHighSpeedDataUsbCommunicationInitalize.Location = new System.Drawing.Point(32, 644);
      this._btnHighSpeedDataUsbCommunicationInitalize.Name = "_btnHighSpeedDataUsbCommunicationInitalize";
      this._btnHighSpeedDataUsbCommunicationInitalize.Size = new System.Drawing.Size(141, 41);
      this._btnHighSpeedDataUsbCommunicationInitalize.TabIndex = 10;
      this._btnHighSpeedDataUsbCommunicationInitalize.Text = "HighSpeedDataUSB CommunicationInitalize";
      this._btnHighSpeedDataUsbCommunicationInitalize.UseVisualStyleBackColor = false;
      this._btnHighSpeedDataUsbCommunicationInitalize.Click += new System.EventHandler(this._btnHighSpeedDataUsbCommunicationInitalize_Click);
      // 
      // _chkOnlyProfileCount
      // 
      this._chkOnlyProfileCount.AutoSize = true;
      this._chkOnlyProfileCount.Location = new System.Drawing.Point(884, 480);
      this._chkOnlyProfileCount.Name = "_chkOnlyProfileCount";
      this._chkOnlyProfileCount.Size = new System.Drawing.Size(183, 17);
      this._chkOnlyProfileCount.TabIndex = 11;
      this._chkOnlyProfileCount.Text = "Count only the number of profiles.";
      this._chkOnlyProfileCount.UseVisualStyleBackColor = true;
      // 
      // _btnPreStartHighSpeedDataCommunication
      // 
      this._btnPreStartHighSpeedDataCommunication.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(192)))), ((int)(((byte)(218)))), ((int)(((byte)(255)))));
      this._btnPreStartHighSpeedDataCommunication.ForeColor = System.Drawing.SystemColors.ControlText;
      this._btnPreStartHighSpeedDataCommunication.Location = new System.Drawing.Point(392, 644);
      this._btnPreStartHighSpeedDataCommunication.Name = "_btnPreStartHighSpeedDataCommunication";
      this._btnPreStartHighSpeedDataCommunication.Size = new System.Drawing.Size(145, 41);
      this._btnPreStartHighSpeedDataCommunication.TabIndex = 12;
      this._btnPreStartHighSpeedDataCommunication.Text = "PreStartHighSpeedData Communication";
      this._btnPreStartHighSpeedDataCommunication.UseVisualStyleBackColor = false;
      this._btnPreStartHighSpeedDataCommunication.Click += new System.EventHandler(this._btnPreStartHighSpeedDataCommunication_Click);
      // 
      // _btnStartHighSpeedDataCommunication
      // 
      this._btnStartHighSpeedDataCommunication.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(192)))), ((int)(((byte)(218)))), ((int)(((byte)(255)))));
      this._btnStartHighSpeedDataCommunication.ForeColor = System.Drawing.SystemColors.ControlText;
      this._btnStartHighSpeedDataCommunication.Location = new System.Drawing.Point(541, 644);
      this._btnStartHighSpeedDataCommunication.Name = "_btnStartHighSpeedDataCommunication";
      this._btnStartHighSpeedDataCommunication.Size = new System.Drawing.Size(143, 41);
      this._btnStartHighSpeedDataCommunication.TabIndex = 13;
      this._btnStartHighSpeedDataCommunication.Text = "StartHighSpeed DataCommunication";
      this._btnStartHighSpeedDataCommunication.UseVisualStyleBackColor = false;
      this._btnStartHighSpeedDataCommunication.Click += new System.EventHandler(this._btnStartHighSpeedDataCommunication_Click);
      // 
      // _btnHighSpeedDataCommunicationFinalize
      // 
      this._btnHighSpeedDataCommunicationFinalize.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(192)))), ((int)(((byte)(218)))), ((int)(((byte)(255)))));
      this._btnHighSpeedDataCommunicationFinalize.ForeColor = System.Drawing.SystemColors.ControlText;
      this._btnHighSpeedDataCommunicationFinalize.Location = new System.Drawing.Point(900, 644);
      this._btnHighSpeedDataCommunicationFinalize.Name = "_btnHighSpeedDataCommunicationFinalize";
      this._btnHighSpeedDataCommunicationFinalize.Size = new System.Drawing.Size(141, 41);
      this._btnHighSpeedDataCommunicationFinalize.TabIndex = 14;
      this._btnHighSpeedDataCommunicationFinalize.Text = "HighSpeedData CommunicationFinalize";
      this._btnHighSpeedDataCommunicationFinalize.UseVisualStyleBackColor = false;
      this._btnHighSpeedDataCommunicationFinalize.Click += new System.EventHandler(this._btnHighSpeedDataCommunicationFinalize_Click);
      // 
      // btnLoadTxtData2
      // 
      this.btnLoadTxtData2.Location = new System.Drawing.Point(128, 556);
      this.btnLoadTxtData2.Name = "btnLoadTxtData2";
      this.btnLoadTxtData2.Size = new System.Drawing.Size(75, 23);
      this.btnLoadTxtData2.TabIndex = 15;
      this.btnLoadTxtData2.Text = "button1";
      this.btnLoadTxtData2.UseVisualStyleBackColor = true;
      this.btnLoadTxtData2.Click += new System.EventHandler(this.btnLoadTxtData2_Click);
      // 
      // btnLoadTxtData4
      // 
      this.btnLoadTxtData4.Location = new System.Drawing.Point(328, 556);
      this.btnLoadTxtData4.Name = "btnLoadTxtData4";
      this.btnLoadTxtData4.Size = new System.Drawing.Size(75, 23);
      this.btnLoadTxtData4.TabIndex = 16;
      this.btnLoadTxtData4.Text = "button1";
      this.btnLoadTxtData4.UseVisualStyleBackColor = true;
      this.btnLoadTxtData4.Click += new System.EventHandler(this.btnLoadTxtData4_Click);
      // 
      // btnLoadTxtData3
      // 
      this.btnLoadTxtData3.Location = new System.Drawing.Point(232, 556);
      this.btnLoadTxtData3.Name = "btnLoadTxtData3";
      this.btnLoadTxtData3.Size = new System.Drawing.Size(75, 23);
      this.btnLoadTxtData3.TabIndex = 16;
      this.btnLoadTxtData3.Text = "button1";
      this.btnLoadTxtData3.UseVisualStyleBackColor = true;
      this.btnLoadTxtData3.Click += new System.EventHandler(this.btnLoadTxtData3_Click);
      // 
      // _numInterval
      // 
      this._numInterval.Increment = new decimal(new int[] {
            10,
            0,
            0,
            0});
      this._numInterval.Location = new System.Drawing.Point(1004, 460);
      this._numInterval.Maximum = new decimal(new int[] {
            1000,
            0,
            0,
            0});
      this._numInterval.Minimum = new decimal(new int[] {
            10,
            0,
            0,
            0});
      this._numInterval.Name = "_numInterval";
      this._numInterval.Size = new System.Drawing.Size(64, 20);
      this._numInterval.TabIndex = 18;
      this._numInterval.Value = new decimal(new int[] {
            500,
            0,
            0,
            0});
      // 
      // _chkStartTimer
      // 
      this._chkStartTimer.AutoSize = true;
      this._chkStartTimer.Location = new System.Drawing.Point(884, 460);
      this._chkStartTimer.Name = "_chkStartTimer";
      this._chkStartTimer.Size = new System.Drawing.Size(91, 17);
      this._chkStartTimer.TabIndex = 17;
      this._chkStartTimer.Text = "Start the timer";
      this._chkStartTimer.UseVisualStyleBackColor = true;
      this._chkStartTimer.CheckedChanged += new System.EventHandler(this._chkStartTimer_CheckedChanged);
      // 
      // _timerHighSpeedReceive
      // 
      this._timerHighSpeedReceive.Interval = 500;
      this._timerHighSpeedReceive.Tick += new System.EventHandler(this._timerHighSpeedReceive_Tick);
      // 
      // button1
      // 
      this.button1.Location = new System.Drawing.Point(416, 556);
      this.button1.Name = "button1";
      this.button1.Size = new System.Drawing.Size(75, 23);
      this.button1.TabIndex = 19;
      this.button1.Text = "button1";
      this.button1.UseVisualStyleBackColor = true;
      this.button1.Click += new System.EventHandler(this.button1_Click);
      // 
      // button2
      // 
      this.button2.Location = new System.Drawing.Point(644, 28);
      this.button2.Name = "button2";
      this.button2.Size = new System.Drawing.Size(112, 23);
      this.button2.TabIndex = 20;
      this.button2.Text = "B301GF_CR10-LE";
      this.button2.UseVisualStyleBackColor = true;
      this.button2.Click += new System.EventHandler(this.button2_Click);
      // 
      // button3
      // 
      this.button3.Location = new System.Drawing.Point(644, 52);
      this.button3.Name = "button3";
      this.button3.Size = new System.Drawing.Size(112, 23);
      this.button3.TabIndex = 21;
      this.button3.Text = "B301GF_CR10-TE";
      this.button3.UseVisualStyleBackColor = true;
      this.button3.Click += new System.EventHandler(this.button3_Click);
      // 
      // btnCalc
      // 
      this.btnCalc.Location = new System.Drawing.Point(504, 556);
      this.btnCalc.Name = "btnCalc";
      this.btnCalc.Size = new System.Drawing.Size(75, 23);
      this.btnCalc.TabIndex = 22;
      this.btnCalc.Text = "Calc";
      this.btnCalc.UseVisualStyleBackColor = true;
      this.btnCalc.Click += new System.EventHandler(this.btnCalc_Click);
      // 
      // Form1
      // 
      this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
      this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
      this.ClientSize = new System.Drawing.Size(1184, 762);
      this.Controls.Add(this.btnCalc);
      this.Controls.Add(this.button3);
      this.Controls.Add(this.button2);
      this.Controls.Add(this.button1);
      this.Controls.Add(this._numInterval);
      this.Controls.Add(this._chkStartTimer);
      this.Controls.Add(this.btnLoadTxtData3);
      this.Controls.Add(this.btnLoadTxtData4);
      this.Controls.Add(this.btnLoadTxtData2);
      this.Controls.Add(this._btnHighSpeedDataCommunicationFinalize);
      this.Controls.Add(this._btnPreStartHighSpeedDataCommunication);
      this.Controls.Add(this._btnStartHighSpeedDataCommunication);
      this.Controls.Add(this._chkOnlyProfileCount);
      this.Controls.Add(this._btnHighSpeedDataUsbCommunicationInitalize);
      this.Controls.Add(this._grpHead);
      this.Controls.Add(this._grpReceived);
      this.Controls.Add(this._grpMeasureRange);
      this.Controls.Add(this._grpExport);
      this.Controls.Add(this._btnGetProfile);
      this.Controls.Add(this._pnlDeviceId);
      this.Controls.Add(this._txtboxLog);
      this.Controls.Add(this._btnUsbOpen);
      this.Controls.Add(this.btnLoadTxtData);
      this.Controls.Add(this.chart);
      this.Name = "Form1";
      this.Text = "Form1";
      this.Load += new System.EventHandler(this.Form1_Load);
      ((System.ComponentModel.ISupportInitialize)(this.chart)).EndInit();
      this._pnlDeviceId.ResumeLayout(false);
      this._pnlDeviceId.PerformLayout();
      this.panel1.ResumeLayout(false);
      this.panel1.PerformLayout();
      this._grpExport.ResumeLayout(false);
      this._grpExport.PerformLayout();
      ((System.ComponentModel.ISupportInitialize)(this._nudProfileNo)).EndInit();
      this._grpMeasureRange.ResumeLayout(false);
      this._grpMeasureRange.PerformLayout();
      this._grpReceived.ResumeLayout(false);
      this._grpReceived.PerformLayout();
      this._grpHead.ResumeLayout(false);
      this._grpHead.PerformLayout();
      ((System.ComponentModel.ISupportInitialize)(this._numInterval)).EndInit();
      this.ResumeLayout(false);
      this.PerformLayout();

    }

    #endregion

    private System.Windows.Forms.DataVisualization.Charting.Chart chart;
    private System.Windows.Forms.Timer timer;
    private System.Windows.Forms.Button btnLoadTxtData;
    private System.Windows.Forms.Button _btnUsbOpen;
    private System.Windows.Forms.TextBox _txtboxLog;
    private System.Windows.Forms.Panel _pnlDeviceId;
    private System.Windows.Forms.Label _lblDeviceStatus5;
    private System.Windows.Forms.Label _lblDeviceStatus4;
    private System.Windows.Forms.RadioButton radioButton2;
    private System.Windows.Forms.RadioButton radioButton1;
    private System.Windows.Forms.Panel panel1;
    private System.Windows.Forms.Label _lblReceiveProfileCount5;
    private System.Windows.Forms.Label _lblReceiveProfileCount4;
    private System.Windows.Forms.Label _lblReceiveProfileCount3;
    private System.Windows.Forms.Label label3;
    private System.Windows.Forms.Label _lblReceiveProfileCount0;
    private System.Windows.Forms.Label _lblReceiveProfileCount1;
    private System.Windows.Forms.Label _lblReceiveProfileCount2;
    private System.Windows.Forms.Label label5;
    private System.Windows.Forms.Label label4;
    private System.Windows.Forms.Label _lblDeviceStatus3;
    private System.Windows.Forms.Label _lblDeviceStatus2;
    private System.Windows.Forms.Label _lblDeviceStatus1;
    private System.Windows.Forms.Label _lblDeviceStatus0;
    private System.Windows.Forms.RadioButton _rdDevice3;
    private System.Windows.Forms.RadioButton _rdDevice2;
    private System.Windows.Forms.RadioButton _rdDevice1;
    private System.Windows.Forms.RadioButton _rdDevice0;
    private System.Windows.Forms.Button _btnGetProfile;
    private System.Windows.Forms.GroupBox _grpExport;
    private System.Windows.Forms.NumericUpDown _nudProfileNo;
    private System.Windows.Forms.TextBox _txtboxProfileFilePath;
    private System.Windows.Forms.Button _btnSaveMeasureData;
    private System.Windows.Forms.Button _btnSave;
    private System.Windows.Forms.Button _btnProfileFileSave;
    private System.Windows.Forms.Label label2;
    private System.Windows.Forms.Label _lblSavePath;
    private System.Windows.Forms.GroupBox _grpMeasureRange;
    private System.Windows.Forms.ComboBox _cmbReceivedBinning;
    private System.Windows.Forms.ComboBox _cmbMeasureX;
    private System.Windows.Forms.Label _lblReceivedBinning;
    private System.Windows.Forms.Label _lblMeasureX;
    private System.Windows.Forms.GroupBox _grpReceived;
    private System.Windows.Forms.CheckBox _chkboxEnvelope;
    private System.Windows.Forms.ComboBox _cmbCompressX;
    private System.Windows.Forms.Label _lblCompressX;
    private System.Windows.Forms.GroupBox _grpHead;
    private System.Windows.Forms.RadioButton _rdbtnOneHead;
    private System.Windows.Forms.RadioButton _rdbtnTwoHead;
    private System.Windows.Forms.RadioButton _rdbtnWide;
    private System.Windows.Forms.Button _btnHighSpeedDataUsbCommunicationInitalize;
    private System.Windows.Forms.CheckBox _chkOnlyProfileCount;
    private System.Windows.Forms.Button _btnPreStartHighSpeedDataCommunication;
    private System.Windows.Forms.Button _btnStartHighSpeedDataCommunication;
    private System.Windows.Forms.Button _btnHighSpeedDataCommunicationFinalize;
    private System.Windows.Forms.Button btnLoadTxtData2;
    private System.Windows.Forms.Button btnLoadTxtData4;
    private System.Windows.Forms.Button btnLoadTxtData3;
    private System.Windows.Forms.NumericUpDown _numInterval;
    private System.Windows.Forms.CheckBox _chkStartTimer;
    private System.Windows.Forms.Timer _timerHighSpeedReceive;
    private System.Windows.Forms.Button button1;
    private System.Windows.Forms.Button button2;
    private System.Windows.Forms.Button button3;
    private System.Windows.Forms.Button btnCalc;
  }
}


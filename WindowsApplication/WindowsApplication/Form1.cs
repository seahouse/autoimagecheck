using iTextSharp.text;
using iTextSharp.text.pdf;
using LJV7_DllSampleAll;
using MathWorks.MATLAB.NET.Arrays;
using MatLabPeizh;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Diagnostics;
using System.Drawing;
using System.Drawing.Drawing2D;
using System.IO;
using System.Management;
using System.Media;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading;
using System.Windows.Forms;
using System.Linq;

namespace 激光快速测量系统
{

    public partial class Form1 : Form
    {
        /// <summary>
        /// B301GF_CR10-LE.txt
        /// </summary>
        const string NAME_REG = @"((.+)_(.+)-([TL]E))\.TXT";

        public Form1()
        {
            this.InitializeComponent();
            //Size size = new Size(2560, 1440);
            //base.Size = size;
            //this.pictureBox1.Size = new Size(2180, 1300);

            {
                var timer = new System.Windows.Forms.Timer { Interval = 1000 };

                timer.Tick += (s, e) =>
                {
                    lbTime.Text = DateTime.Now.ToString("yyyy-MM-dd HH:mm:ss");
                };
                timer.Start();
            }
        }

        private void Form1_Load(object sender, EventArgs e)
        {
            //if (!this.Copyright())
            //{
            //    MessageBox.Show("Please contect the developer!");
            //    Application.Exit();
            //    return;
            //}

            this.RefreshImage = new Bitmap(this.picChart.ClientSize.Width, this.picChart.ClientSize.Height);
            this.boxH = this.picChart.Height;
            this.boxW = this.picChart.Width;
            this.Hlimit = 2.5;
            this.m_scale = 60.0;
            this.mcx = this.boxW / 2;
            this.mcy = this.boxH / 10;
            Graphics graphics = Graphics.FromHwnd(IntPtr.Zero);
            this.Dpi = graphics.DpiX;
            this.scale = this.m_scale / 25.4 * (double)this.Dpi * 1.2;

            lb_path.Text = Global.ResultPath;
            tboxPart.Clear();
        }

        private void Form1_MouseUp(object sender, MouseEventArgs e)
        {
            if (e.Button != MouseButtons.Right) return;

            var fmProcess = new fmProcess { StartPosition = FormStartPosition.CenterScreen };
            var ret = fmProcess.ShowDialog();
            if (ret != DialogResult.OK) return;

            Form3 form = new Form3();
            form.StartPosition = FormStartPosition.CenterScreen;
            form.ShowDialog();
        }

        private void btOPenfile_Click(object sender, EventArgs e)
        {
            if (folderBrowserDialog1.ShowDialog() != DialogResult.OK) return;

            mdpath = folderBrowserDialog1.SelectedPath;

            flpNames.Controls.Clear();
            radioButtons.Clear();
            tboxPart.Clear();

            DirectoryInfo directoryInfo = new DirectoryInfo(this.mdpath);
            var files = directoryInfo.GetFiles("*.txt").OrderBy(p => p.Name).ToList();

            foreach (FileInfo fileInfo in files)
            {
                string name = fileInfo.Name;

                var match = Regex.Match(name, NAME_REG, RegexOptions.IgnoreCase);
                if (!match.Success || match.Groups.Count != 5)
                {
                    continue;
                }

                Category cat;
                var result = Enum.TryParse<Category>(match.Groups[4].Value, out cat);
                if (!result)
                {
                    continue;
                }

                tboxPart.Text = match.Groups[2].Value;

                var rdb = new RadioButton { Text = match.Groups[1].Value, AutoSize = true, Tag = fileInfo };
                rdb.Click += radioButton_Click;


                if (!radioButtons.ContainsKey(cat)) radioButtons[cat] = new List<RadioButton>();
                radioButtons[cat].Add(rdb);
            }

            if (radioButtons.Count == 0)
            {
                MessageBox.Show("所选文件夹下 没有模型文件！", Text, MessageBoxButtons.OK, MessageBoxIcon.Information);
                return;
            }

            if (radioButtons.ContainsKey(Category.LE))
            {
                flpNames.Controls.Add(new Label { Text = "--------  进气边 --------", AutoSize = true });
                foreach (var item in radioButtons[Category.LE])
                {
                    flpNames.Controls.Add(item);
                }
            }
            if (radioButtons.ContainsKey(Category.TE))
            {
                flpNames.Controls.Add(new Label { Text = "--------  排气边  -------", AutoSize = true });
                foreach (var item in radioButtons[Category.TE])
                {
                    flpNames.Controls.Add(item);
                }
            }
        }

        private void radioButton_Click(object sender, EventArgs e)
        {
            var rdb = sender as RadioButton;
            if (rdb == null || !rdb.Checked) return;

            var fi = rdb.Tag as FileInfo;
            if (fi == null) return;

            this.ScName = rdb.Text.Substring(tboxPart.Text.Length + 1);

            this.ReadMpfile(fi.FullName);
            this.labelZ.Text = "截面位置Z=" + this.Sec_z.ToString();
            Graphics graphics = Graphics.FromImage(this.RefreshImage);
            graphics.Clear(Color.Black);
            if (this.chkGrid.Checked)
            {
                this.DrawGrid(graphics);
            }
            if (this.MpNum > 0)
            {
                this.DrawModel(this.ddx, this.ddy);
            }
            this.DrawPlate();
            if (this.CpNum > 0)
            {
                this.DrawMeasure();
            }
            this.picChart.Refresh();
        }

        private void DrawPlate()
        {
            Graphics graphics = Graphics.FromImage(this.RefreshImage);
            this.mx1 = (int)((double)this.mcx - 5.0 * this.scale);
            this.my1 = (int)((double)this.mcy + this.Hlimit * this.scale);
            this.mx2 = (int)((double)this.mcx + 5.0 * this.scale);
            this.my2 = (int)((double)this.mcy + this.Hlimit * this.scale);
            Point pt = new Point(this.mx1, this.my1);
            Point pt2 = new Point(this.mx2, this.my2);
            this.pen1.DashStyle = DashStyle.Solid;
            graphics.DrawLine(this.pen1, pt, pt2);
            this.pen2.DashStyle = DashStyle.DashDot;
            Point pt3 = new Point(this.mcx, 0);
            Point pt4 = new Point(this.mcx, this.boxH);
            graphics.DrawLine(this.pen2, pt3, pt4);
        }


        //public void DelectDir(string srcPath)
        //{
        //    try
        //    {
        //        DirectoryInfo directoryInfo = new DirectoryInfo(srcPath);
        //        FileSystemInfo[] fileSystemInfos = directoryInfo.GetFileSystemInfos();
        //        foreach (FileSystemInfo fileSystemInfo in fileSystemInfos)
        //        {
        //            if (fileSystemInfo is DirectoryInfo)
        //            {
        //                DirectoryInfo directoryInfo2 = new DirectoryInfo(fileSystemInfo.FullName);
        //                directoryInfo2.Delete(true);
        //            }
        //            else
        //            {
        //                File.Delete(fileSystemInfo.FullName);
        //            }
        //        }
        //    }
        //    catch (Exception)
        //    {
        //        throw;
        //    }
        //}


        private void btnAnalyse_Click(object sender, EventArgs e)
        {
            this.btnMeasure.Enabled = false;
            this.lbStatus.Text = "正在分析数据 请等待...";
            this.Cursor = Cursors.WaitCursor;

            foreach (var item in flpNames.Controls.OfType<RadioButton>())
            {
                item.ForeColor = Color.White;
            }

            if (!string.IsNullOrEmpty(mdpath) && !string.IsNullOrEmpty(Global.ResultPath))
            {
                MWArray[] array = new MWArray[2];
                MWArray[] array2 = new MWArray[3];
                MatLabPeizhun matLabPeizhun = new MatLabPeizhun();
                double num = Convert.ToDouble(this.tBuTol.Text);
                double num2 = Convert.ToDouble(this.tBdTol.Text);
                double num3 = Convert.ToDouble(this.tBdTol.Text);
                double[] realData = new double[]
                {
                    num,
                    num2,
                    num3,
                    this.Hlimit
                };
                MWNumericArray mwnumericArray = new MWNumericArray(1, 4, realData);
                array2[0] = this.mdpath;
                array2[1] = Global.ResultPath;
                array2[2] = mwnumericArray;
                string text = this.tBoxOperator.Text;
                matLabPeizhun.peizhundll1(1, ref array, array2);

                string[] files = Directory.GetFiles(Global.TempPDFFolder);
                string text2 = DateTime.Now.ToString("yyyyMMddhhmmss");
                this.SerNo = this.tboxSeroNo.Text;
                this.Finishresultfile = Path.Combine(Global.ResultPath,
                    string.Format("{0}-{1}-{2}.pdf", tboxPart.Text, SerNo, text2));

                this.mergePDFFiles(files, Finishresultfile);
            }

            this.lbStatus.Text = "正在启动 adobe 浏览，请等待...";
            if (!string.IsNullOrEmpty(Finishresultfile) && File.Exists(Finishresultfile))
            {
                Process.Start(Finishresultfile);
            }
            else if (MessageBox.Show("没有新结果 要打开以前的结果吗？", "Confirm Message", MessageBoxButtons.OKCancel) == DialogResult.OK)
            {
                OpenFileDialog openFileDialog = new OpenFileDialog();
                openFileDialog.Filter = "pdf文件|*.pdf|所有文件|*.*";
                openFileDialog.RestoreDirectory = true;
                if (openFileDialog.ShowDialog() == DialogResult.OK)
                {
                    string fileName = openFileDialog.FileName;
                    Process.Start(fileName);
                }
            }
            lbStatus.Text = "";
            this.Cursor = Cursors.Arrow;
        }


        private bool Copyright()
        {
            string a = "";
            ManagementClass managementClass = new ManagementClass("Win32_DiskDrive");
            ManagementObjectCollection instances = managementClass.GetInstances();
            int num = 0;
            foreach (ManagementBaseObject managementBaseObject in instances)
            {
                ManagementObject managementObject = (ManagementObject)managementBaseObject;
                num++;
                if (num == 1)
                {
                    a = (string)managementObject.Properties["Model"].Value;
                }
            }
            return a == "HGST HTS541010A9E680" || a == "WDC WD5000AAKX-60U6A SCSI Disk Device" || a == "WDC WD5000AAKX-003CA0 ATA Device" || a == "ST1000DM003-1SB102" || a == "WD Elements 1078 USB Device";
        }


        //private void ReadProf(string prfname, double[] prfx1, double[] prfy1, double[] prfx2, double[] prfy2)
        //{
        //    FileStream fileStream = new FileStream(prfname, FileMode.Open, FileAccess.Read);
        //    StreamReader streamReader = new StreamReader(fileStream, Encoding.Default);
        //    fileStream.Seek(0L, SeekOrigin.Begin);
        //    string text = streamReader.ReadLine();
        //    this.CpNum = 0;
        //    while (text != null)
        //    {
        //        string[] array = text.Split(new char[]
        //        {
        //            '\t'
        //        });
        //        int num = array.Length;
        //        if (num > 3)
        //        {
        //            this.CpNum++;
        //            prfx1[this.CpNum - 1] = (double)(-(double)Convert.ToInt32(array[0])) / 100000.0;
        //            prfx2[this.CpNum - 1] = (double)(-(double)Convert.ToInt32(array[0])) / 100000.0;
        //            prfy1[this.CpNum - 1] = (double)Convert.ToInt32(array[1]) / 100000.0;
        //            prfy2[this.CpNum - 1] = (double)Convert.ToInt32(array[2]) / 100000.0;
        //        }
        //        text = streamReader.ReadLine();
        //    }
        //    streamReader.Close();
        //    fileStream.Close();
        //}


        //private void timer1_Tick(object sender, EventArgs e)
        //{
        //    this.GetScanData();
        //    Graphics graphics = Graphics.FromImage(this.RefreshImage);
        //    graphics.Clear(Color.Black);
        //    if (this.chkGrid.Checked)
        //    {
        //        this.DrawGrid(graphics);
        //    }
        //    if (this.MpNum > 0)
        //    {
        //        this.DrawModel(this.ddx, this.ddy);
        //    }
        //    this.DrawPlate();
        //    if (this.CpNum > 0)
        //    {
        //        this.DrawMeasure();
        //    }
        //    this.picChart.Refresh();
        //}


        private void DrawGrid(Graphics g)
        {
            Pen pen = new Pen(Color.Gray, 1f);
            System.Drawing.Font font = new System.Drawing.Font("Verdana", 8f);
            StringFormat stringFormat = new StringFormat();
            StringFormat stringFormat2 = new StringFormat();
            stringFormat.Alignment = StringAlignment.Center;
            stringFormat2.LineAlignment = StringAlignment.Center;
            SolidBrush brush = new SolidBrush(Color.Yellow);
            double num = Math.Round(this.ddx * 10.0) / 10.0;
            double num2 = Math.Round(this.ddy * 10.0) / 10.0;
            double num3 = num;
            double num4 = num2;
            int num5 = this.mcx + (int)((num3 - this.ddx) * this.scale);
            int num6 = 0;
            int y = this.boxH;
            Point pt = new Point(num5, num6);
            Point point = new Point(num5, y);
            g.DrawLine(pen, pt, point);
            g.DrawString(num.ToString("n"), font, brush, point, stringFormat);
            num6 = this.mcy - (int)((num4 - this.ddy) * this.scale);
            num5 = 0;
            int x = this.boxW;
            pt = new Point(num5, num6);
            point = new Point(x, num6);
            g.DrawLine(pen, pt, point);
            num6 = 0;
            y = this.boxH;
            for (;;)
            {
                num3 += this.GridSize;
                num5 = this.mcx + (int)((num3 - this.ddx) * this.scale);
                if (num5 > this.boxW)
                {
                    break;
                }
                pt = new Point(num5, num6);
                point = new Point(num5, y);
                g.DrawLine(pen, pt, point);
                g.DrawString(num3.ToString("n"), font, brush, point, stringFormat);
            }
            num3 = num;
            for (;;)
            {
                num3 -= this.GridSize;
                num5 = this.mcx + (int)((num3 - this.ddx) * this.scale);
                if (num5 < 0)
                {
                    break;
                }
                pt = new Point(num5, num6);
                point = new Point(num5, y);
                g.DrawLine(pen, pt, point);
                g.DrawString(num3.ToString("n"), font, brush, point, stringFormat);
            }
            num5 = 0;
            x = this.boxW;
            num4 = num2;
            num6 = this.mcy - (int)((num4 - this.ddy) * this.scale);
            g.DrawString(num4.ToString("n"), font, brush, new Point(num5, num6), stringFormat2);
            for (;;)
            {
                num4 += this.GridSize;
                num6 = this.mcy - (int)((num4 - this.ddy) * this.scale);
                if (num6 < 0)
                {
                    break;
                }
                pt = new Point(num5, num6);
                point = new Point(x, num6);
                g.DrawLine(pen, pt, point);
                g.DrawString(num4.ToString("n"), font, brush, new Point(num5, num6), stringFormat2);
            }
            num4 = num2;
            for (;;)
            {
                num4 -= this.GridSize;
                num6 = this.mcy - (int)((num4 - this.ddy) * this.scale);
                if (num6 > this.boxH)
                {
                    break;
                }
                pt = new Point(num5, num6);
                point = new Point(x, num6);
                g.DrawLine(pen, pt, point);
                g.DrawString(num4.ToString("n"), font, brush, new Point(num5, num6), stringFormat2);
            }
        }


        private void ReadMpfile(string filePath)
        {
            FileStream fileStream = null;
            StreamReader streamReader = null;
            try
            {
                fileStream = new FileStream(filePath, FileMode.Open, FileAccess.Read);
                streamReader = new StreamReader(fileStream, Encoding.Default);
                fileStream.Seek(0L, SeekOrigin.Begin);
                string input = streamReader.ReadLine();
                this.MpNum = 0;
                while (input != null)
                {
                    string[] array = Regex.Split(input, "\\s+");
                    int num = 0;
                    for (int i = 0; i < array.Length; i++)
                    {
                        if (array[i] != "")
                        {
                            num++;
                            if (num == 1)
                            {
                                this.MpNum++;
                                this.MPx[this.MpNum] = Convert.ToDouble(array[i]);
                            }
                            else if (num == 2)
                            {
                                this.MPy[this.MpNum] = Convert.ToDouble(array[i]);
                            }
                            else if (num == 3)
                            {
                                this.Sec_z = Convert.ToDouble(array[i]);
                            }
                        }
                    }
                    input = streamReader.ReadLine();
                }
            }
            catch
            {
            }
            finally
            {
                if (fileStream != null)
                {
                    fileStream.Close();
                }
                if (streamReader != null)
                {
                    streamReader.Close();
                }
            }
        }


        private void btnMeasure_Click(object sender, EventArgs e)
        {
            if (this.btnStart.Text == "Measure")
            {
                foreach (var item in flpNames.Controls.OfType<RadioButton>().Where(p => p.Checked))
                {
                    item.ForeColor = Color.Yellow;
                }

                this.btnAnalyse.Enabled = true;
                this.lbStatus.Text = "正在采集保存数据 请等待...";
                this.timer1.Enabled = false;
                this.pictureBox2.Image = System.Drawing.Image.FromFile("IMG\\No.png");
                this.btnStart.Text = "Start";
                this.GetDataPro();
                this.Hlimit = Convert.ToDouble(this.cboRange.Text);
                this.abtractData(this.Hlimit);
                DateTime.Now.ToString("yyyyMMddhhmmss");
                this.SerNo = this.tboxSeroNo.Text;
                FileStream fileStream = new FileStream(
                    Path.Combine(Global.ResultPath, string.Format("{0}-{1}-{2}.txt", tboxPart.Text, SerNo, ScName)), FileMode.Create);
                StreamWriter streamWriter = new StreamWriter(fileStream);
                streamWriter.WriteLine(string.Concat(new string[]
                {
                    this.tBuTol.Text,
                    "   ",
                    this.tBdTol.Text,
                    "  ",
                    this.tBtolzoom.Text
                }));
                for (int k = 0; k < this.CpNum; k++)
                {
                    streamWriter.WriteLine(this.PrfX[k].ToString("F3") + "   " + this.PrfY[k].ToString("F3") + "  0.000");
                }
                streamWriter.Flush();
                streamWriter.Close();
                fileStream.Close();
                this.lbStatus.Text = "";
                return;
            }
            MessageBox.Show("请启动激光测量，获得数据!");
        }


        private void DrawModel(double x, double y)
        {
            Graphics graphics = Graphics.FromImage(this.RefreshImage);
            this.pen1.DashStyle = DashStyle.Solid;
            if (this.MpNum > 0)
            {
                double num = 0.1;
                double num2 = 0.2;
                for (int i = 1; i < this.MpNum; i++)
                {
                    double num3 = this.MPx[i + 1] - this.MPx[i];
                    double num4 = this.MPy[i + 1] - this.MPy[i];
                    double num5 = Math.Sqrt(num3 * num3 + num4 * num4);
                    num3 /= num5;
                    num4 /= num5;
                    num = num4;
                    num2 = -num3;
                    this.MPxD[i] = this.MPx[i] + this.dTol * num * this.zoom;
                    this.MPyD[i] = this.MPy[i] + this.dTol * num2 * this.zoom;
                    this.MPxU[i] = this.MPx[i] + this.uTol * num * this.zoom;
                    this.MPyU[i] = this.MPy[i] + this.uTol * num2 * this.zoom;
                }
                this.MPxD[this.MpNum] = this.MPx[this.MpNum] + this.dTol * num * this.zoom;
                this.MPyD[this.MpNum] = this.MPy[this.MpNum] + this.dTol * num2 * this.zoom;
                this.MPxU[this.MpNum] = this.MPx[this.MpNum] + this.uTol * num * this.zoom;
                this.MPyU[this.MpNum] = this.MPy[this.MpNum] + this.uTol * num2 * this.zoom;
            }
            for (int i = 1; i < this.MpNum; i++)
            {
                int x2 = this.mcx + (int)((this.MPx[i] - x) * this.scale);
                int x3 = this.mcx + (int)((this.MPx[i + 1] - x) * this.scale);
                int y2 = this.mcy - (int)((this.MPy[i] - y) * this.scale);
                int y3 = this.mcy - (int)((this.MPy[i + 1] - y) * this.scale);
                Point pt = new Point(x2, y2);
                Point pt2 = new Point(x3, y3);
                graphics.DrawLine(this.pen4, pt, pt2);
                x2 = this.mcx + (int)((this.MPxU[i] - x) * this.scale);
                x3 = this.mcx + (int)((this.MPxU[i + 1] - x) * this.scale);
                y2 = this.mcy - (int)((this.MPyU[i] - y) * this.scale);
                y3 = this.mcy - (int)((this.MPyU[i + 1] - y) * this.scale);
                pt = new Point(x2, y2);
                pt2 = new Point(x3, y3);
                graphics.DrawLine(this.pen3, pt, pt2);
                x2 = this.mcx + (int)((this.MPxD[i] - x) * this.scale);
                x3 = this.mcx + (int)((this.MPxD[i + 1] - x) * this.scale);
                y2 = this.mcy - (int)((this.MPyD[i] - y) * this.scale);
                y3 = this.mcy - (int)((this.MPyD[i + 1] - y) * this.scale);
                pt = new Point(x2, y2);
                pt2 = new Point(x3, y3);
                graphics.DrawLine(this.pen3, pt, pt2);
            }
        }


        private void DrawMeasure()
        {
            Graphics graphics = Graphics.FromImage(this.RefreshImage);
            this.pen1.DashStyle = DashStyle.Solid;
            for (int i = 0; i < this.CpNum - 1; i++)
            {
                int x = this.mcx + (int)((this.PrfX[i] - this.ddx) * this.scale);
                int x2 = this.mcx + (int)((this.PrfX[i + 1] - this.ddx) * this.scale);
                int y = this.mcy - (int)((this.PrfY[i] - this.ddy) * this.scale);
                int y2 = this.mcy - (int)((this.PrfY[i + 1] - this.ddy) * this.scale);
                Point pt = new Point(x, y);
                Point pt2 = new Point(x2, y2);
                graphics.DrawLine(this.pen5, pt, pt2);
            }
        }


        private void timer1_Tick_1(object sender, EventArgs e)
        {
            this.GetDataPro();
            Graphics graphics = Graphics.FromImage(this.RefreshImage);
            graphics.Clear(Color.Black);
            if (this.chkGrid.Checked)
            {
                this.DrawGrid(graphics);
            }
            if (this.MpNum > 0)
            {
                this.DrawModel(this.ddx, this.ddy);
            }
            this.DrawPlate();
            if (this.CpNum > 0)
            {
                this.DrawMeasure();
            }
            this.picChart.Refresh();
        }


        private void GetScanData()
        {
            int[] array = new int[1000];
            int[] array2 = new int[1000];
            int[] array3 = new int[1000];
            double[] array4 = new double[1000];
            double[] array5 = new double[1000];
            double[] array6 = new double[1000];
            double[] array7 = new double[1000];
            double[] array8 = new double[1000];
            double[] array9 = new double[1000];
            double[] array10 = new double[1000];
            double[] array11 = new double[1000];
            MainForm mainForm = new MainForm();
            this.CpNum = 800;
            mainForm.getProfdata(array, array2, array3);
            for (int i = 0; i < this.CpNum; i++)
            {
                array4[i] = (double)(-(double)array[i]) / 100000.0;
                array5[i] = (double)(-(double)array[i]) / 100000.0;
                array6[i] = (double)array2[i] / 100000.0;
                array7[i] = (double)array3[i] / 100000.0;
            }
            int num = 0;
            int num2 = 0;
            for (int i = 0; i < this.CpNum; i++)
            {
                if (Math.Abs(array6[i]) < 4.0)
                {
                    num++;
                    array8[num - 1] = array4[i];
                    array10[num - 1] = array6[i];
                }
            }
            for (int i = 0; i < this.CpNum; i++)
            {
                if (Math.Abs(array7[i]) < 4.0)
                {
                    num2++;
                    array9[num2 - 1] = array5[i];
                    array11[num2 - 1] = array7[i];
                }
            }
            double num3 = Global.Angle;
            double xoff = Global.XOff;
            double yoff = Global.YOff;
            if (num > 0 && num2 > 0)
            {
                for (int i = 0; i < num2; i++)
                {
                    double num4 = array9[i];
                    double num5 = array11[i];
                    array9[i] = num4 * Math.Cos(num3) - num5 * Math.Sin(num3) + xoff;
                    array11[i] = num4 * Math.Sin(num3) + num5 * Math.Cos(num3) + yoff;
                }
                int num6 = num;
                int num7 = 1;
                for (int i = 0; i < 25; i++)
                {
                    for (int j = num; j > num - 25; j--)
                    {
                        double num8 = array9[i];
                        double num9 = array9[i + 1];
                        double num10 = array11[i];
                        double num11 = array11[i + 1];
                        double num12 = array8[j];
                        double num13 = array8[j - 1];
                        double num14 = array10[j];
                        double num15 = array10[j - 1];
                        double num16 = num9 - num8;
                        double num17 = num13 - num12;
                        double num18 = num11 - num10;
                        double num19 = num15 - num14;
                        double num20 = num16 * num19 - num17 * num18;
                        Math.Sqrt(num16 * num16 + num18 * num18);
                        if (num20 != 0.0)
                        {
                            double num21 = (num16 * num19 * num12 - num17 * num18 * num8 - num17 * num16 * (num14 - num10)) / num20;
                            if (num16 != 0.0)
                            {
                                double num22 = (num21 - num8) * num18 / num16;
                                if ((num21 - num8) / num16 >= 0.0 || (num21 - num8) / num16 <= 1.0)
                                {
                                    num6 = j;
                                    num7 = i;
                                    break;
                                }
                            }
                            else
                            {
                                double num23 = (num21 - num12) * num19 / num17;
                                if ((num21 - num12) / num17 >= 0.0 || (num21 - num12) / num17 <= 1.0)
                                {
                                    num6 = j;
                                    num7 = i;
                                    break;
                                }
                            }
                        }
                    }
                }
                num6--;
                num7++;
                this.CpNum = 0;
                for (int i = 0; i < num6; i++)
                {
                    this.PrfX[this.CpNum] = array8[i];
                    this.PrfY[this.CpNum] = array10[i];
                    this.CpNum++;
                }
                for (int i = num7; i < num2; i++)
                {
                    this.PrfX[this.CpNum] = array9[i];
                    this.PrfY[this.CpNum] = array11[i];
                    this.CpNum++;
                }
                num3 = -0.78539815;
                double num24 = 0.0;
                double num25 = -3.39;
                for (int i = 0; i < this.CpNum; i++)
                {
                    double num4 = this.PrfX[i];
                    double num5 = this.PrfY[i];
                    this.PrfX[i] = num4 * Math.Cos(num3) - num5 * Math.Sin(num3) + num24;
                    this.PrfY[i] = num4 * Math.Sin(num3) + num5 * Math.Cos(num3) + num25;
                }
            }
        }


        private void GetDataPro()
        {
            int[] array = new int[1000];                // x
            int[] array2 = new int[1000];               // y1
            int[] array3 = new int[1000];               // y2
            double[] array4 = new double[1000];         // x1: 4~-3.9
            double[] array5 = new double[1000];         // x2: 4~-3.9
            double[] array6 = new double[1000];         // y1
            double[] array7 = new double[1000];         // y2
            double[] array8 = new double[1000];         // x1: valid data
            double[] array9 = new double[1000];         // x2: valid data
            double[] array10 = new double[1000];        // y1: valid data
            double[] array11 = new double[1000];        // y2: valid data
            MainForm mainForm = new MainForm();
            this.CpNum = 800;
            bool profdata = mainForm.getProfdata(array, array2, array3);
            if (profdata)
            {
                for (int i = 0; i < this.CpNum; i++)
                {
                    array4[i] = (double)(-(double)array[i]) / 100000.0;
                    array6[i] = (double)array2[i] / 100000.0;
                    array5[i] = (double)(-(double)array[i]) / 100000.0;
                    array7[i] = (double)array3[i] / 100000.0;
                }
                int num = 0;                // num of x1
                int num2 = 0;               // num of x2
                for (int i = 0; i < this.CpNum; i++)
                {
                    if (Math.Abs(array6[i]) < 4.0)
                    {
                        num++;
                        array8[num - 1] = array4[i];
                        array10[num - 1] = array6[i];
                    }
                }
                for (int i = 0; i < this.CpNum; i++)
                {
                    if (Math.Abs(array7[i]) < 4.0)
                    {
                        num2++;
                        array9[num2 - 1] = array5[i];
                        array11[num2 - 1] = array7[i];
                    }
                }
                double num3 = Global.Angle;             // angle
                double xoff = Global.XOff;            // x offset
                double yoff = Global.YOff;            // y offset
                num3 = num3 / 180.0 * 3.1415926;
                if (num > 0 && num2 > 0)
                {
                    for (int i = 0; i < num2; i++)
                    {
                        double num4 = array9[i];
                        double num5 = array11[i];
                        array9[i] = num4 * Math.Cos(num3) - num5 * Math.Sin(num3) + xoff;
                        array11[i] = num4 * Math.Sin(num3) + num5 * Math.Cos(num3) + yoff;
                    }
                    int num6 = num;
                    int num7 = 1;
                    for (int i = 0; i < 50; i++)
                    {
                        int num8 = num - 1;
                        while (num8 > num - 50 && num8 >= 1)
                        {
                            double num9 = array9[i];
                            double num10 = array9[i + 1];
                            double num11 = array11[i];
                            double num12 = array11[i + 1];
                            double num13 = array8[num8];
                            double num14 = array8[num8 - 1];
                            double num15 = array10[num8];
                            double num16 = array10[num8 - 1];
                            if (this.IntersectionTwoline(num9, num11, num10, num12, num13, num15, num14, num16))
                            {
                                double num17 = num10 - num9;
                                double num18 = num14 - num13;
                                double num19 = num12 - num11;
                                double num20 = num16 - num15;
                                double num21 = num17 * num20 - num18 * num19;
                                Math.Sqrt(num17 * num17 + num19 * num19);
                                if (num21 != 0.0)
                                {
                                    double num22 = (num17 * num20 * num13 - num18 * num19 * num9 - num18 * num17 * (num15 - num11)) / num21;
                                    if (num17 != 0.0)
                                    {
                                        double num23 = (num22 - num9) * num19 / num17;
                                        if ((num22 - num9) / num17 >= 0.0 || (num22 - num9) / num17 <= 1.0)
                                        {
                                            num6 = num8;
                                            num7 = i;
                                            break;
                                        }
                                    }
                                    else
                                    {
                                        double num24 = (num22 - num13) * num20 / num18;
                                        if ((num22 - num13) / num18 >= 0.0 || (num22 - num13) / num18 <= 1.0)
                                        {
                                            num6 = num8;
                                            num7 = i;
                                            break;
                                        }
                                    }
                                }
                            }
                            num8--;
                        }
                    }
                    num6--;
                    num7++;
                    this.CpNum = 0;
                    for (int i = 0; i < num6; i++)
                    {
                        this.PrfX[this.CpNum] = array8[i];
                        this.PrfY[this.CpNum] = array10[i];
                        this.CpNum++;
                    }
                    for (int i = num7; i < num2; i++)
                    {
                        this.PrfX[this.CpNum] = array9[i];
                        this.PrfY[this.CpNum] = array11[i];
                        this.CpNum++;
                    }
                    this.CpNum--;
                    num3 = -0.78539815;
                    double num25 = -3.9;
                    double num26;
                    for (int i = 0; i < this.CpNum; i++)
                    {
                        double num4 = this.PrfX[i];
                        double num5 = this.PrfY[i];
                        this.PrfX[i] = num4 * Math.Cos(num3) - num5 * Math.Sin(num3);
                        this.PrfY[i] = num4 * Math.Sin(num3) + num5 * Math.Cos(num3);
                        if (this.PrfY[i] > num25)
                        {
                            num25 = this.PrfY[i];
                            num26 = this.PrfX[i];
                        }
                    }
                    num25 = -3.9;
                    num26 = 0.0;
                    for (int i = 0; i < this.CpNum; i++)
                    {
                        this.PrfX[i] = this.PrfX[i] + num26;
                        this.PrfY[i] = this.PrfY[i] + num25;
                    }
                    return;
                }
            }
            else
            {
                this.timer1.Enabled = false;
                this.pictureBox2.Image = System.Drawing.Image.FromFile("IMG\\No.png");
                this.btnStart.Text = "Start";
                MessageBox.Show("请链接测头 usb！");
            }
        }


        private void abtractData(double limt)
        {
            int num = 0;
            double[] array = new double[800];
            double[] array2 = new double[800];
            for (int i = 0; i < this.CpNum; i++)
            {
                double num2 = this.PrfX[i];
                double num3 = this.PrfY[i];
                if (num3 >= -limt)
                {
                    num++;
                    array[num] = this.PrfX[i];
                    array2[num] = this.PrfY[i];
                }
            }
            this.CpNum = 0;
            double num4 = array[1];
            double num5 = array2[1];
            double num6 = array[2];
            double num7 = array2[2];
            double num8 = Math.Sqrt((num6 - num4) * (num6 - num4) + (num7 - num5) * (num7 - num5));
            int num9;
            if (num8 < 0.4)
            {
                this.PrfX[this.CpNum] = array[1];
                this.PrfY[this.CpNum] = array2[1];
                num9 = 2;
            }
            else
            {
                this.PrfX[this.CpNum] = array[2];
                this.PrfY[this.CpNum] = array2[2];
                num9 = 3;
            }
            for (int i = num9; i <= num; i++)
            {
                num4 = this.PrfX[this.CpNum];
                num5 = this.PrfY[this.CpNum];
                num6 = array[i];
                num7 = array2[i];
                num8 = Math.Sqrt((num6 - num4) * (num6 - num4) + (num7 - num5) * (num7 - num5));
                if (num8 < 0.4)
                {
                    this.CpNum++;
                    this.PrfX[this.CpNum] = array[i];
                    this.PrfY[this.CpNum] = array2[i];
                }
            }
        }


        private bool IntersectionTwoline(double x1, double y1, double x2, double y2, double x3, double y3, double x4, double y4)
        {
            bool flag = false;
            bool flag2 = false;
            double num;
            double num2;
            if (x1 > x2)
            {
                num = x2;
                num2 = x1;
            }
            else
            {
                num = x1;
                num2 = x2;
            }
            double num3;
            double num4;
            if (x3 > x4)
            {
                num3 = x4;
                num4 = x3;
            }
            else
            {
                num3 = x3;
                num4 = x4;
            }
            double num5;
            double num6;
            if (y1 > y2)
            {
                num5 = y2;
                num6 = y1;
            }
            else
            {
                num5 = y1;
                num6 = y2;
            }
            double num7;
            double num8;
            if (y3 > y4)
            {
                num7 = y4;
                num8 = y3;
            }
            else
            {
                num7 = y3;
                num8 = y4;
            }
            double num9 = num2 - num;
            double num10 = num4 - num3;
            double num11 = num6 - num5;
            double num12 = num8 - num7;
            if (num9 > num10)
            {
                if ((num3 >= num && num3 <= num2) || (num4 >= num && num4 <= num2))
                {
                    flag = true;
                }
            }
            else if ((num >= num3 && num <= num4) || (num2 >= num3 && num2 <= num4))
            {
                flag = true;
            }
            if (num11 > num12)
            {
                if ((num7 >= num5 && num7 <= num6) || (num8 >= num5 && num8 <= num6))
                {
                    flag2 = true;
                }
            }
            else if ((num5 >= num7 && num5 <= num8) || (num6 >= num7 && num6 <= num8))
            {
                flag2 = true;
            }
            return flag && flag2;
        }


        private void picChart_Paint(object sender, PaintEventArgs e)
        {
            DoubleBuffered = true;
            e.Graphics.DrawImage(this.RefreshImage, 0, 0);
        }


        private void btnStart_Click(object sender, EventArgs e)
        {
            this.timer1.Enabled = true;
            this.pictureBox2.Image = System.Drawing.Image.FromFile("IMG\\pass.png");
            this.btnStart.Text = "Measure";
        }


        private void btnSaveLocation_Click(object sender, EventArgs e)
        {
            if (this.folderBrowserDialog1.ShowDialog() == DialogResult.OK)
            {
                this.lb_path.Text = this.folderBrowserDialog1.SelectedPath;
                Global.ResultPath = this.folderBrowserDialog1.SelectedPath;
            }
        }


        private void cboX_SelectedIndexChanged(object sender, EventArgs e)
        {
            this.m_scale = Convert.ToDouble(this.cboX.Text);
            this.scale = this.m_scale * (double)this.Dpi / 25.4 * 1.2;
            Graphics graphics = Graphics.FromImage(this.RefreshImage);
            graphics.Clear(Color.Black);
            if (this.chkGrid.Checked)
            {
                this.DrawGrid(graphics);
            }
            if (this.MpNum > 0)
            {
                this.DrawModel(this.ddx, this.ddy);
            }
            this.DrawPlate();
            if (this.CpNum > 0)
            {
                this.DrawMeasure();
            }
            this.picChart.Refresh();
        }


        private void cboGrid_SelectedIndexChanged(object sender, EventArgs e)
        {
            this.GridSize = (double)Convert.ToSingle(this.cboGrid.Text);
            Graphics graphics = Graphics.FromImage(this.RefreshImage);
            graphics.Clear(Color.Black);
            if (this.chkGrid.Checked)
            {
                this.DrawGrid(graphics);
            }
            if (this.MpNum > 0)
            {
                this.DrawModel(this.ddx, this.ddy);
            }
            this.DrawPlate();
            if (this.CpNum > 0)
            {
                this.DrawMeasure();
            }
            this.picChart.Refresh();
        }


        private void chkGrid_CheckedChanged(object sender, EventArgs e)
        {
            if (this.chkGrid.Checked)
            {
                Graphics graphics = Graphics.FromImage(this.RefreshImage);
                graphics.Clear(Color.Black);
                this.DrawGrid(graphics);
                if (this.MpNum > 0)
                {
                    this.DrawModel(this.ddx, this.ddy);
                }
                this.DrawPlate();
                if (this.CpNum > 0)
                {
                    this.DrawMeasure();
                }
                this.picChart.Refresh();
                return;
            }
            Graphics graphics2 = Graphics.FromImage(this.RefreshImage);
            graphics2.Clear(Color.Black);
            if (this.MpNum > 0)
            {
                this.DrawModel(this.ddx, this.ddy);
            }
            this.DrawPlate();
            if (this.CpNum > 0)
            {
                this.DrawMeasure();
            }
            this.picChart.Refresh();
        }


        //public static byte[] ImgToByt(System.Drawing.Image img)
        //{
        //    MemoryStream memoryStream = new MemoryStream();
        //    img.Save(memoryStream, ImageFormat.Png);
        //    return memoryStream.GetBuffer();
        //}


        //public static System.Drawing.Image BytToImg(byte[] byt)
        //{
        //    MemoryStream stream = new MemoryStream(byt);
        //    return System.Drawing.Image.FromStream(stream);
        //}


        private void btnView_Click(object sender, EventArgs e)
        {
            this.lbStatus.Text = "正在启动 adobe 浏览，请等待...";
            if (this.Finishresultfile != null)
            {
                Process.Start("ApaReader", this.Finishresultfile);
            }
            else if (MessageBox.Show("没有新结果 要打开以前的结果吗？", "Confirm Message", MessageBoxButtons.OKCancel) == DialogResult.OK)
            {
                OpenFileDialog openFileDialog = new OpenFileDialog();
                openFileDialog.Filter = "pdf文件|*.pdf|所有文件|*.*";
                openFileDialog.RestoreDirectory = true;
                if (openFileDialog.ShowDialog() == DialogResult.OK)
                {
                    string fileName = openFileDialog.FileName;
                    Process.Start("ApaReader.exe", fileName);
                }
            }
            this.lbStatus.Text = "";
        }


        //public void AddImage(string path, int Alignment, float newWidth, float newHeight, Document doc)
        //{
        //    iTextSharp.text.Image instance = iTextSharp.text.Image.GetInstance(path);
        //    instance.Alignment = Alignment;
        //    if (newWidth != 0f)
        //    {
        //        instance.ScaleAbsolute(newWidth, newHeight);
        //    }
        //    else if (instance.Width > PageSize.A4.Width)
        //    {
        //        instance.ScaleAbsolute(this.rect.Width, instance.Width * instance.Height / this.rect.Height);
        //    }
        //    doc.Add(instance);
        //}


        private void mergePDFFiles(string[] fileList, string outMergeFile)
        {
            Document document = new Document(PageSize.A4.Rotate());
            PdfWriter instance = PdfWriter.GetInstance(document, new FileStream(outMergeFile, FileMode.Create));
            List<PdfReader> list = new List<PdfReader>();
            document.Open();
            PdfContentByte directContent = instance.DirectContent;
            int num = fileList.Length;
            for (int i = 0; i < fileList.Length; i++)
            {
                if (fileList[i] != null)
                {
                    PdfReader pdfReader = new PdfReader(fileList[i]);
                    int numberOfPages = pdfReader.NumberOfPages;
                    for (int j = 1; j <= numberOfPages; j++)
                    {
                        document.NewPage();
                        PdfImportedPage importedPage = instance.GetImportedPage(pdfReader, j);
                        directContent.AddTemplate(importedPage, 0f, -1f, 1f, 0f, -10f, pdfReader.GetPageSizeWithRotation(j).Height);
                        int alignment = 0;
                        float num2 = 720f;
                        float newHeight = 30f;
                        iTextSharp.text.Image instance2 = iTextSharp.text.Image.GetInstance("IMG\\hangya.png");
                        instance2.Alignment = alignment;
                        if (num2 != 0f)
                        {
                            instance2.ScaleAbsolute(num2, newHeight);
                        }
                        else if (instance2.Width > PageSize.A4.Width)
                        {
                            instance2.ScaleAbsolute(PageSize.A4.Width, instance2.Width * instance2.Height / PageSize.A4.Height);
                        }
                        instance2.SetAbsolutePosition(50f, 520f);
                        document.Add(instance2);
                        BaseFont bf = BaseFont.CreateFont("Fonts\\simfang.ttf", "Identity-H", false);
                        iTextSharp.text.Font font = new iTextSharp.text.Font(bf, 10f);
                        Phrase phrase = new Phrase(string.Concat(new object[]
                        {
                            "- 第",
                            instance.PageNumber,
                            "页/共",
                            num.ToString(),
                            "页 -"
                        }), font);
                        ColumnText.ShowTextAligned(directContent, 1, phrase, 430f, document.Bottom + 20f, 0f);
                        font = new iTextSharp.text.Font(bf, 14f);
                        Phrase phrase2 = new Phrase("检验：" + this.tBoxOperator.Text, font);
                        ColumnText.ShowTextAligned(directContent, 1, phrase2, 120f, 525f, 0f);
                        Phrase phrase3 = new Phrase("时间：" + DateTime.Now.ToString(), font);
                        ColumnText.ShowTextAligned(directContent, 1, phrase3, 320f, 525f, 0f);
                    }
                    list.Add(pdfReader);
                }
            }
            document.Close();
            foreach (PdfReader pdfReader2 in list)
            {
                pdfReader2.Dispose();
            }
        }


        private void pictureBox2_Click(object sender, EventArgs e)
        {
            SystemSounds.Hand.Play();
            this.pictureBox2.Image = System.Drawing.Image.FromFile("IMG\\Pass.png");
        }


        private void cboRange_SelectedIndexChanged(object sender, EventArgs e)
        {
            this.Hlimit = Convert.ToDouble(this.cboRange.Text);
            Graphics graphics = Graphics.FromImage(this.RefreshImage);
            graphics.Clear(Color.Black);
            if (this.chkGrid.Checked)
            {
                this.DrawGrid(graphics);
            }
            if (this.MpNum > 0)
            {
                this.DrawModel(this.ddx, this.ddy);
            }
            this.DrawPlate();
            if (this.CpNum > 0)
            {
                this.DrawMeasure();
            }
            this.picChart.Refresh();
        }

        private void bW_monitor_DoWork(object sender, DoWorkEventArgs e)
        {
            int num = 0;
            while (!this.bW_monitor.CancellationPending)
            {
                num++;
                Thread.Sleep(100);
                if (num > 10)
                {
                    num = 0;
                }
                this.bW_monitor.ReportProgress(num);
            }
            e.Cancel = true;
        }


        private void bW_monitor_ProgressChanged(object sender, ProgressChangedEventArgs e)
        {
            this.GetScanData();
            Graphics graphics = Graphics.FromImage(this.RefreshImage);
            graphics.Clear(Color.Black);
            if (this.chkGrid.Checked)
            {
                this.DrawGrid(graphics);
            }
            if (this.MpNum > 0)
            {
                this.DrawModel(this.ddx, this.ddy);
            }
            this.DrawPlate();
            if (this.CpNum > 0)
            {
                this.DrawMeasure();
            }
            this.picChart.Refresh();
        }


        //private void button5_Click(object sender, EventArgs e)
        //{
        //    string path = "c:\\mergpdf\\";
        //    string[] files = Directory.GetFiles(path);
        //    SaveFileDialog saveFileDialog = new SaveFileDialog();
        //    saveFileDialog.Filter = "pdf文件|*.pdf|所有文件|*.*";
        //    saveFileDialog.InitialDirectory = this.resultsPath;
        //    saveFileDialog.RestoreDirectory = true;
        //    if (saveFileDialog.ShowDialog() == DialogResult.OK)
        //    {
        //        this.Finishresultfile = saveFileDialog.FileName;
        //        this.mergePDFFiles(files, this.Finishresultfile);
        //    }
        //}


        private void tBuTol_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Return)
            {
                this.uTol = Convert.ToDouble(this.tBuTol.Text);
                Graphics graphics = Graphics.FromImage(this.RefreshImage);
                graphics.Clear(Color.Black);
                if (this.chkGrid.Checked)
                {
                    this.DrawGrid(graphics);
                }
                if (this.MpNum > 0)
                {
                    this.DrawModel(this.ddx, this.ddy);
                }
                this.DrawPlate();
                if (this.CpNum > 0)
                {
                    this.DrawMeasure();
                }
                this.picChart.Refresh();
            }
        }


        private void tBdTol_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Return)
            {
                this.dTol = Convert.ToDouble(this.tBdTol.Text);
                Graphics graphics = Graphics.FromImage(this.RefreshImage);
                graphics.Clear(Color.Black);
                if (this.chkGrid.Checked)
                {
                    this.DrawGrid(graphics);
                }
                if (this.MpNum > 0)
                {
                    this.DrawModel(this.ddx, this.ddy);
                }
                this.DrawPlate();
                if (this.CpNum > 0)
                {
                    this.DrawMeasure();
                }
                this.picChart.Refresh();
            }
        }

        private void tboxSeroNo_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode != Keys.Return) return;

            this.btnMeasure.Enabled = true;
            DateTime now = DateTime.Now;
            this.SerNo = this.tboxSeroNo.Text;
            string text = now.ToString("yy-MM-dd");
            if (string.IsNullOrEmpty(tboxPart.Text))
            {
                MessageBox.Show("请先调取检测产品理论模型！", "提示", MessageBoxButtons.OK, MessageBoxIcon.Information);
                return;
            }
            string text2 = Path.Combine(Global.DefaultResultPath, tboxPart.Text, text, SerNo);

            Global.ResultPath = text2;
            int num = 0;
            if (Directory.Exists(text2))
            {
                while (Directory.Exists(Global.ResultPath))
                {
                    num++;
                    Global.ResultPath = text2 + "R" + num.ToString();
                }
            }
            Directory.CreateDirectory(Global.ResultPath);
            this.lb_path.Text = Global.ResultPath;
        }


        private Pen pen1 = new Pen(Color.White, 2f);


        private Pen pen2 = new Pen(Color.White, 1f);


        private Pen pen3 = new Pen(Color.Green, 1f);


        private Pen pen4 = new Pen(Color.White, 1f);


        private Pen pen5 = new Pen(Color.Red, 1f);


        private int boxH;


        private int boxW;


        private Bitmap RefreshImage;


        private float Dpi = 10f;


        private double scale;


        private double Hlimit;


        private double m_scale;


        private int mcx;


        private int mcy;


        private int mx1;


        private int my1;


        private int mx2;


        private int my2;

        //private string PartName;

        /// <summary>
        /// 产品目录
        /// </summary>
        string mdpath;


        //private string mdfile;


        //private string resultsPath;


        //private string resultfile;


        private string Finishresultfile;


        private string SerNo = "";


        private string ScName = "";


        enum Category
        {
            /// <summary>
            /// 进气边
            /// </summary>
            LE,
            /// <summary>
            /// 排气边
            /// </summary>
            TE
        }

        private readonly Dictionary<Category, List<RadioButton>> radioButtons = new Dictionary<Category, List<RadioButton>>();


        private double[] MPx = new double[500];


        private double[] MPy = new double[500];


        private double GridSize = 0.4;


        private double[] MPxU = new double[500];


        private double[] MPyU = new double[500];


        private double[] MPxD = new double[500];


        private double[] MPyD = new double[500];


        private double[] PrfX = new double[2000];


        private double[] PrfY = new double[2000];


        private double ddx = 0;


        private double ddy = 0;


        private int MpNum;


        private int CpNum;


        private double zoom = 1.0;


        private double Sec_z;


        private double uTol = 0.05;


        private double dTol = -0.05;

        private void btnTest_Click(object sender, EventArgs e)
        {
            this.GetTestData();
            Graphics graphics = Graphics.FromImage(this.RefreshImage);
            graphics.Clear(Color.Black);
            if (this.chkGrid.Checked)
            {
                this.DrawGrid(graphics);
            }
            if (this.MpNum > 0)
            {
                this.DrawModel(this.ddx, this.ddy);
            }
            this.DrawPlate();
            if (this.CpNum > 0)
            {
                this.DrawMeasure();
            }
            this.picChart.Refresh();
        }

        private void GetTestData()
        {
            int[] array = new int[1000];                // x
            int[] array2 = new int[1000];               // y1
            int[] array3 = new int[1000];               // y2
            double[] array4 = new double[1000];         // x1: 4~-3.9
            double[] array5 = new double[1000];         // x2: 4~-3.9
            double[] array6 = new double[1000];         // y1
            double[] array7 = new double[1000];         // y2
            double[] array8 = new double[1000];         // x1: valid data
            double[] array9 = new double[1000];         // x2: valid data
            double[] array10 = new double[1000];        // y1: valid data
            double[] array11 = new double[1000];        // y2: valid data
            MainForm mainForm = new MainForm();
            this.CpNum = 800;
            StreamReader sr = new StreamReader("t2.txt", Encoding.Default);
            String line;
            int index = 0;
            while ((line = sr.ReadLine()) != null)
            {
                String[] aa = line.Split('\t');
                if (aa.Length > 2)
                {
                    array[index] = int.Parse(aa.ElementAt(0));
                    array2[index] = int.Parse(aa.ElementAt(1));
                    array3[index] = int.Parse(aa.ElementAt(2));
                    index++;
                }
            }
            //bool profdata = mainForm.getProfdata(array, array2, array3);
            //if (profdata)
            {
                for (int i = 0; i < this.CpNum; i++)
                {
                    array4[i] = (double)(-(double)array[i]) / 100000.0;
                    array6[i] = (double)array2[i] / 100000.0;
                    array5[i] = (double)(-(double)array[i]) / 100000.0;
                    array7[i] = (double)array3[i] / 100000.0;
                }
                int num = 0;                // num of x1
                int num2 = 0;               // num of x2
                for (int i = 0; i < this.CpNum; i++)
                {
                    if (Math.Abs(array6[i]) < 4.0)
                    {
                        num++;
                        array8[num - 1] = array4[i];
                        array10[num - 1] = array6[i];
                    }
                }
                for (int i = 0; i < this.CpNum; i++)
                {
                    if (Math.Abs(array7[i]) < 4.0)
                    {
                        num2++;
                        array9[num2 - 1] = array5[i];
                        array11[num2 - 1] = array7[i];
                    }
                }
                double num3 = Global.Angle;             // angle
                double xoff = Global.XOff;            // x offset
                double yoff = Global.YOff;            // y offset
                num3 = num3 / 180.0 * 3.1415926;
                if (num > 0 && num2 > 0)
                {
                    for (int i = 0; i < num2; i++)
                    {
                        double num4 = array9[i];
                        double num5 = array11[i];
                        array9[i] = num4 * Math.Cos(num3) - num5 * Math.Sin(num3) + xoff;
                        array11[i] = num4 * Math.Sin(num3) + num5 * Math.Cos(num3) + yoff;
                    }
                    int num6 = num;
                    int num7 = 1;
                    for (int i = 0; i < 50; i++)
                    {
                        int num8 = num - 1;
                        while (num8 > num - 50 && num8 >= 1)
                        {
                            double num9 = array9[i];
                            double num10 = array9[i + 1];
                            double num11 = array11[i];
                            double num12 = array11[i + 1];
                            double num13 = array8[num8];
                            double num14 = array8[num8 - 1];
                            double num15 = array10[num8];
                            double num16 = array10[num8 - 1];
                            if (this.IntersectionTwoline(num9, num11, num10, num12, num13, num15, num14, num16))
                            {
                                double num17 = num10 - num9;
                                double num18 = num14 - num13;
                                double num19 = num12 - num11;
                                double num20 = num16 - num15;
                                double num21 = num17 * num20 - num18 * num19;
                                Math.Sqrt(num17 * num17 + num19 * num19);
                                if (num21 != 0.0)
                                {
                                    double num22 = (num17 * num20 * num13 - num18 * num19 * num9 - num18 * num17 * (num15 - num11)) / num21;
                                    if (num17 != 0.0)
                                    {
                                        double num23 = (num22 - num9) * num19 / num17;
                                        if ((num22 - num9) / num17 >= 0.0 || (num22 - num9) / num17 <= 1.0)
                                        {
                                            num6 = num8;
                                            num7 = i;
                                            break;
                                        }
                                    }
                                    else
                                    {
                                        double num24 = (num22 - num13) * num20 / num18;
                                        if ((num22 - num13) / num18 >= 0.0 || (num22 - num13) / num18 <= 1.0)
                                        {
                                            num6 = num8;
                                            num7 = i;
                                            break;
                                        }
                                    }
                                }
                            }
                            num8--;
                        }
                    }
                    num6--;
                    num7++;
                    this.CpNum = 0;
                    for (int i = 0; i < num6; i++)
                    {
                        this.PrfX[this.CpNum] = array8[i];
                        this.PrfY[this.CpNum] = array10[i];
                        this.CpNum++;
                    }
                    for (int i = num7; i < num2; i++)
                    {
                        this.PrfX[this.CpNum] = array9[i];
                        this.PrfY[this.CpNum] = array11[i];
                        this.CpNum++;
                    }
                    this.CpNum--;
                    num3 = -0.78539815;
                    double num25 = -3.9;
                    double num26;
                    for (int i = 0; i < this.CpNum; i++)
                    {
                        double num4 = this.PrfX[i];
                        double num5 = this.PrfY[i];
                        this.PrfX[i] = num4 * Math.Cos(num3) - num5 * Math.Sin(num3);
                        this.PrfY[i] = num4 * Math.Sin(num3) + num5 * Math.Cos(num3);
                        if (this.PrfY[i] > num25)
                        {
                            num25 = this.PrfY[i];
                            num26 = this.PrfX[i];
                        }
                    }
                    num25 = -3.9;
                    num26 = 0.0;
                    for (int i = 0; i < this.CpNum; i++)
                    {
                        this.PrfX[i] = this.PrfX[i] + num26;
                        this.PrfY[i] = this.PrfY[i] + num25;
                    }
                    return;
                }
            }
            //else
            //{
            //    this.timer1.Enabled = false;
            //    this.pictureBox2.Image = System.Drawing.Image.FromFile("IMG\\No.png");
            //    this.btnStart.Text = "Start";
            //    MessageBox.Show("请链接测头 usb！");
            //}
        }
        //private iTextSharp.text.Rectangle rect;
    }
}
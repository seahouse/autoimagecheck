using System;
using System.ComponentModel;
using System.Drawing;
using System.IO;
using System.Windows.Forms;

namespace 激光快速测量系统
{

    public partial class Form3 : Form
    {

        public Form3()
        {
            this.InitializeComponent();
        }


        private void button1_Click(object sender, EventArgs e)
        {
            global1.Xta1 = Convert.ToDouble(this.tbXta1.Text);
            global1.Xoff1 = Convert.ToDouble(this.tBXoff1.Text);
            global1.Yoff1 = Convert.ToDouble(this.tBYoff1.Text);
            FileStream fileStream = new FileStream("init.txt", FileMode.Open);
            StreamWriter streamWriter = new StreamWriter(fileStream);
            streamWriter.WriteLine(string.Concat(new string[]
            {
                this.tbXta1.Text,
                "   ",
                this.tBXoff1.Text,
                "  ",
                this.tBYoff1.Text
            }));
            streamWriter.Flush();
            streamWriter.Close();
            fileStream.Close();
            base.Close();
        }


        private void button2_Click(object sender, EventArgs e)
        {
            base.Close();
        }


        private void Form3_Load(object sender, EventArgs e)
        {
            this.tbXta1.Text = global1.Xta1.ToString();
            this.tBXoff1.Text = global1.Xoff1.ToString();
            this.tBYoff1.Text = global1.Yoff1.ToString();
        }
    }
}

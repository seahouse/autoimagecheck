using System;
using System.ComponentModel;
using System.Drawing;
using System.Windows.Forms;

namespace 激光快速测量系统
{
    partial class fmProcess : Form
    {
        public fmProcess()
        {
            this.InitializeComponent();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            if (this.textBox1.Text == "jd-hya_66")
            {
                Form3 form = new Form3();
                form.ShowDialog();
                base.Close();
                return;
            }
            MessageBox.Show("密码错误！");
        }

        private void button2_Click(object sender, EventArgs e)
        {
            base.Close();
        }
    }
}

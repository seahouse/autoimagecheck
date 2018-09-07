using System;
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
                DialogResult = DialogResult.OK;
            }
            else
                MessageBox.Show("密码错误！", Text, MessageBoxButtons.OK, MessageBoxIcon.Information);
        }
    }
}
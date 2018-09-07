using System;
using System.Windows.Forms;

namespace 激光快速测量系统
{
    public partial class Form3 : Form
    {
        public Form3()
        {
            this.InitializeComponent();
        }
        private void Form3_Load(object sender, EventArgs e)
        {
            nAngle.Value = Convert.ToDecimal(Global.Angle);
            nXoff.Value = Convert.ToDecimal(Global.XOff);
            nYoff.Value = Convert.ToDecimal(Global.YOff);
        }

        private void btnOK_Click(object sender, EventArgs e)
        {
            Global.Angle = Convert.ToDouble(nAngle.Value);
            Global.XOff = Convert.ToDouble(nXoff.Value);
            Global.YOff = Convert.ToDouble(nYoff.Value);
            DialogResult = DialogResult.OK;
        }
    }
}

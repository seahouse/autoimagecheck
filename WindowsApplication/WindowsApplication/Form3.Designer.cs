namespace 激光快速测量系统
{

    public partial class Form3 : global::System.Windows.Forms.Form
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
            this.groupBox1 = new global::System.Windows.Forms.GroupBox();
            this.label3 = new global::System.Windows.Forms.Label();
            this.label2 = new global::System.Windows.Forms.Label();
            this.label1 = new global::System.Windows.Forms.Label();
            this.tBYoff1 = new global::System.Windows.Forms.TextBox();
            this.tBXoff1 = new global::System.Windows.Forms.TextBox();
            this.tbXta1 = new global::System.Windows.Forms.TextBox();
            this.button1 = new global::System.Windows.Forms.Button();
            this.button2 = new global::System.Windows.Forms.Button();
            this.groupBox1.SuspendLayout();
            base.SuspendLayout();
            this.groupBox1.Controls.Add(this.label3);
            this.groupBox1.Controls.Add(this.label2);
            this.groupBox1.Controls.Add(this.label1);
            this.groupBox1.Controls.Add(this.tBYoff1);
            this.groupBox1.Controls.Add(this.tBXoff1);
            this.groupBox1.Controls.Add(this.tbXta1);
            this.groupBox1.Location = new global::System.Drawing.Point(29, 52);
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.Size = new global::System.Drawing.Size(179, 172);
            this.groupBox1.TabIndex = 0;
            this.groupBox1.TabStop = false;
            this.groupBox1.Text = "测头坐标";
            this.label3.AutoSize = true;
            this.label3.Location = new global::System.Drawing.Point(34, 132);
            this.label3.Name = "label3";
            this.label3.Size = new global::System.Drawing.Size(35, 12);
            this.label3.TabIndex = 4;
            this.label3.Text = "Y平移";
            this.label2.AutoSize = true;
            this.label2.Location = new global::System.Drawing.Point(34, 87);
            this.label2.Name = "label2";
            this.label2.Size = new global::System.Drawing.Size(35, 12);
            this.label2.TabIndex = 3;
            this.label2.Text = "X平移";
            this.label1.AutoSize = true;
            this.label1.Location = new global::System.Drawing.Point(34, 43);
            this.label1.Name = "label1";
            this.label1.Size = new global::System.Drawing.Size(41, 12);
            this.label1.TabIndex = 1;
            this.label1.Text = "旋转角";
            this.tBYoff1.Location = new global::System.Drawing.Point(78, 129);
            this.tBYoff1.Name = "tBYoff1";
            this.tBYoff1.Size = new global::System.Drawing.Size(78, 21);
            this.tBYoff1.TabIndex = 2;
            this.tBYoff1.Text = "0.1615";
            this.tBXoff1.Location = new global::System.Drawing.Point(78, 84);
            this.tBXoff1.Name = "tBXoff1";
            this.tBXoff1.Size = new global::System.Drawing.Size(78, 21);
            this.tBXoff1.TabIndex = 2;
            this.tBXoff1.Text = "0.4811";
            this.tbXta1.Location = new global::System.Drawing.Point(78, 40);
            this.tbXta1.Name = "tbXta1";
            this.tbXta1.Size = new global::System.Drawing.Size(78, 21);
            this.tbXta1.TabIndex = 1;
            this.tbXta1.Text = "89.91";
            this.button1.Location = new global::System.Drawing.Point(29, 256);
            this.button1.Name = "button1";
            this.button1.Size = new global::System.Drawing.Size(74, 25);
            this.button1.TabIndex = 2;
            this.button1.Text = "确认";
            this.button1.UseVisualStyleBackColor = true;
            this.button1.Click += new global::System.EventHandler(this.button1_Click);
            this.button2.Location = new global::System.Drawing.Point(131, 256);
            this.button2.Name = "button2";
            this.button2.Size = new global::System.Drawing.Size(74, 25);
            this.button2.TabIndex = 3;
            this.button2.Text = "取消";
            this.button2.UseVisualStyleBackColor = true;
            this.button2.Click += new global::System.EventHandler(this.button2_Click);
            base.AutoScaleDimensions = new global::System.Drawing.SizeF(6f, 12f);
            base.AutoScaleMode = global::System.Windows.Forms.AutoScaleMode.Font;
            base.ClientSize = new global::System.Drawing.Size(269, 318);
            base.Controls.Add(this.button2);
            base.Controls.Add(this.button1);
            base.Controls.Add(this.groupBox1);
            base.MaximizeBox = false;
            base.MinimizeBox = false;
            base.Name = "Form3";
            this.Text = "系统数据转换参数";
            base.Load += new global::System.EventHandler(this.Form3_Load);
            this.groupBox1.ResumeLayout(false);
            this.groupBox1.PerformLayout();
            base.ResumeLayout(false);
        }


        private global::System.ComponentModel.IContainer components = null;


        private global::System.Windows.Forms.GroupBox groupBox1;


        private global::System.Windows.Forms.Label label3;


        private global::System.Windows.Forms.Label label2;


        private global::System.Windows.Forms.Label label1;


        private global::System.Windows.Forms.TextBox tBYoff1;


        private global::System.Windows.Forms.TextBox tBXoff1;


        private global::System.Windows.Forms.TextBox tbXta1;


        private global::System.Windows.Forms.Button button1;


        private global::System.Windows.Forms.Button button2;
    }
}

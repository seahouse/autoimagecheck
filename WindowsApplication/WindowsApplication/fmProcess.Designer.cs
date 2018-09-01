namespace 激光快速测量系统
{
    partial class fmProcess
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
            this.textBox1 = new global::System.Windows.Forms.TextBox();
            this.button1 = new global::System.Windows.Forms.Button();
            this.label1 = new global::System.Windows.Forms.Label();
            this.button2 = new global::System.Windows.Forms.Button();
            base.SuspendLayout();
            this.textBox1.Location = new global::System.Drawing.Point(136, 36);
            this.textBox1.Name = "textBox1";
            this.textBox1.Size = new global::System.Drawing.Size(129, 21);
            this.textBox1.TabIndex = 0;
            this.textBox1.UseSystemPasswordChar = true;
            this.button1.Location = new global::System.Drawing.Point(81, 88);
            this.button1.Name = "button1";
            this.button1.Size = new global::System.Drawing.Size(81, 26);
            this.button1.TabIndex = 1;
            this.button1.Text = "登录";
            this.button1.UseVisualStyleBackColor = true;
            this.button1.Click += new global::System.EventHandler(this.button1_Click);
            this.label1.AutoSize = true;
            this.label1.Location = new global::System.Drawing.Point(79, 39);
            this.label1.Name = "label1";
            this.label1.Size = new global::System.Drawing.Size(29, 12);
            this.label1.TabIndex = 2;
            this.label1.Text = "密码";
            this.button2.Location = new global::System.Drawing.Point(220, 88);
            this.button2.Name = "button2";
            this.button2.Size = new global::System.Drawing.Size(70, 27);
            this.button2.TabIndex = 3;
            this.button2.Text = "退出";
            this.button2.UseVisualStyleBackColor = true;
            this.button2.Click += new global::System.EventHandler(this.button2_Click);
            base.AutoScaleDimensions = new global::System.Drawing.SizeF(6f, 12f);
            base.AutoScaleMode = global::System.Windows.Forms.AutoScaleMode.Font;
            base.ClientSize = new global::System.Drawing.Size(373, 126);
            base.Controls.Add(this.button2);
            base.Controls.Add(this.label1);
            base.Controls.Add(this.button1);
            base.Controls.Add(this.textBox1);
            base.MaximizeBox = false;
            base.MinimizeBox = false;
            base.Name = "fmProcess";
            this.Text = "登录参数设置";
            base.ResumeLayout(false);
            base.PerformLayout();
        }

        private global::System.ComponentModel.IContainer components = null;

        private global::System.Windows.Forms.TextBox textBox1;

        private global::System.Windows.Forms.Button button1;

        private global::System.Windows.Forms.Label label1;

        private global::System.Windows.Forms.Button button2;
    }
}

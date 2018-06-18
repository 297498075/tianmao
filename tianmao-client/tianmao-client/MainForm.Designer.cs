namespace tianmao_client
{
    partial class MainForm
    {
        /// <summary>
        /// 必需的设计器变量。
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// 清理所有正在使用的资源。
        /// </summary>
        /// <param name="disposing">如果应释放托管资源，为 true；否则为 false。</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows 窗体设计器生成的代码

        /// <summary>
        /// 设计器支持所需的方法 - 不要修改
        /// 使用代码编辑器修改此方法的内容。
        /// </summary>
        private void InitializeComponent()
        {
            this.components = new System.ComponentModel.Container();
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(MainForm));
            this.setImageList = new System.Windows.Forms.ImageList(this.components);
            this.menuStrip1 = new System.Windows.Forms.MenuStrip();
            this.设置ToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.mainpanel = new System.Windows.Forms.Panel();
            this.textBox_名称 = new System.Windows.Forms.TextBox();
            this.textBox_服务器地址 = new System.Windows.Forms.TextBox();
            this.label_name = new System.Windows.Forms.Label();
            this.label_服务器地址 = new System.Windows.Forms.Label();
            this.button_cancel = new System.Windows.Forms.Button();
            this.button_ok = new System.Windows.Forms.Button();
            this.menuStrip1.SuspendLayout();
            this.mainpanel.SuspendLayout();
            this.SuspendLayout();
            // 
            // setImageList
            // 
            this.setImageList.ImageStream = ((System.Windows.Forms.ImageListStreamer)(resources.GetObject("setImageList.ImageStream")));
            this.setImageList.TransparentColor = System.Drawing.Color.Transparent;
            this.setImageList.Images.SetKeyName(0, "set.png");
            this.setImageList.Images.SetKeyName(1, "setting.png");
            // 
            // menuStrip1
            // 
            this.menuStrip1.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.设置ToolStripMenuItem});
            this.menuStrip1.Location = new System.Drawing.Point(0, 0);
            this.menuStrip1.Name = "menuStrip1";
            this.menuStrip1.Size = new System.Drawing.Size(327, 25);
            this.menuStrip1.TabIndex = 7;
            this.menuStrip1.Text = "menuStrip1";
            // 
            // 设置ToolStripMenuItem
            // 
            this.设置ToolStripMenuItem.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.设置ToolStripMenuItem.Name = "设置ToolStripMenuItem";
            this.设置ToolStripMenuItem.Size = new System.Drawing.Size(44, 21);
            this.设置ToolStripMenuItem.Text = "设置";
            this.设置ToolStripMenuItem.Click += new System.EventHandler(this.设置ToolStripMenuItem_Click);
            // 
            // mainpanel
            // 
            this.mainpanel.BackColor = System.Drawing.Color.Transparent;
            this.mainpanel.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Center;
            this.mainpanel.Controls.Add(this.textBox_名称);
            this.mainpanel.Controls.Add(this.textBox_服务器地址);
            this.mainpanel.Controls.Add(this.label_name);
            this.mainpanel.Controls.Add(this.label_服务器地址);
            this.mainpanel.Controls.Add(this.button_cancel);
            this.mainpanel.Controls.Add(this.button_ok);
            this.mainpanel.Location = new System.Drawing.Point(0, 28);
            this.mainpanel.Margin = new System.Windows.Forms.Padding(2);
            this.mainpanel.Name = "mainpanel";
            this.mainpanel.Size = new System.Drawing.Size(328, 208);
            this.mainpanel.TabIndex = 0;
            // 
            // textBox_名称
            // 
            this.textBox_名称.Font = new System.Drawing.Font("Microsoft Sans Serif", 12.8F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.textBox_名称.Location = new System.Drawing.Point(128, 82);
            this.textBox_名称.Margin = new System.Windows.Forms.Padding(2);
            this.textBox_名称.Name = "textBox_名称";
            this.textBox_名称.Size = new System.Drawing.Size(169, 27);
            this.textBox_名称.TabIndex = 5;
            // 
            // textBox_服务器地址
            // 
            this.textBox_服务器地址.Font = new System.Drawing.Font("Microsoft Sans Serif", 12.8F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.textBox_服务器地址.Location = new System.Drawing.Point(128, 46);
            this.textBox_服务器地址.Margin = new System.Windows.Forms.Padding(2);
            this.textBox_服务器地址.Name = "textBox_服务器地址";
            this.textBox_服务器地址.Size = new System.Drawing.Size(169, 27);
            this.textBox_服务器地址.TabIndex = 4;
            // 
            // label_name
            // 
            this.label_name.AutoSize = true;
            this.label_name.Font = new System.Drawing.Font("Microsoft Sans Serif", 12.8F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.label_name.Location = new System.Drawing.Point(73, 82);
            this.label_name.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.label_name.Name = "label_name";
            this.label_name.Size = new System.Drawing.Size(51, 22);
            this.label_name.TabIndex = 3;
            this.label_name.Text = "名称:";
            // 
            // label_服务器地址
            // 
            this.label_服务器地址.AutoSize = true;
            this.label_服务器地址.Font = new System.Drawing.Font("Microsoft Sans Serif", 12.8F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.label_服务器地址.Location = new System.Drawing.Point(19, 49);
            this.label_服务器地址.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.label_服务器地址.Name = "label_服务器地址";
            this.label_服务器地址.Size = new System.Drawing.Size(105, 22);
            this.label_服务器地址.TabIndex = 2;
            this.label_服务器地址.Text = "服务器地址:";
            // 
            // button_cancel
            // 
            this.button_cancel.Font = new System.Drawing.Font("Microsoft Sans Serif", 10.8F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.button_cancel.Location = new System.Drawing.Point(183, 138);
            this.button_cancel.Margin = new System.Windows.Forms.Padding(2);
            this.button_cancel.Name = "button_cancel";
            this.button_cancel.Size = new System.Drawing.Size(62, 27);
            this.button_cancel.TabIndex = 1;
            this.button_cancel.Text = "关闭";
            this.button_cancel.UseVisualStyleBackColor = true;
            this.button_cancel.Click += new System.EventHandler(this.button_cancel_Click);
            // 
            // button_ok
            // 
            this.button_ok.Font = new System.Drawing.Font("Microsoft Sans Serif", 10.8F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.button_ok.Location = new System.Drawing.Point(96, 138);
            this.button_ok.Margin = new System.Windows.Forms.Padding(2);
            this.button_ok.Name = "button_ok";
            this.button_ok.Size = new System.Drawing.Size(62, 27);
            this.button_ok.TabIndex = 0;
            this.button_ok.Text = "连接";
            this.button_ok.UseVisualStyleBackColor = true;
            this.button_ok.Click += new System.EventHandler(this.button_ok_Click);
            // 
            // MainForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 12F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(327, 233);
            this.Controls.Add(this.menuStrip1);
            this.Controls.Add(this.mainpanel);
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.Margin = new System.Windows.Forms.Padding(2);
            this.MaximizeBox = false;
            this.Name = "MainForm";
            this.menuStrip1.ResumeLayout(false);
            this.menuStrip1.PerformLayout();
            this.mainpanel.ResumeLayout(false);
            this.mainpanel.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion
        private System.Windows.Forms.Panel mainpanel;
        private System.Windows.Forms.TextBox textBox_名称;
        private System.Windows.Forms.TextBox textBox_服务器地址;
        private System.Windows.Forms.Label label_name;
        private System.Windows.Forms.Label label_服务器地址;
        private System.Windows.Forms.Button button_cancel;
        private System.Windows.Forms.Button button_ok;
        private System.Windows.Forms.ImageList setImageList;
        private System.Windows.Forms.MenuStrip menuStrip1;
        private System.Windows.Forms.ToolStripMenuItem 设置ToolStripMenuItem;
    }
}


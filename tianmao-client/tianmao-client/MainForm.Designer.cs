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
            this.程序路径ToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.mainpanel = new System.Windows.Forms.Panel();
            this.textBox_password = new System.Windows.Forms.TextBox();
            this.textBox_userId = new System.Windows.Forms.TextBox();
            this.label_password = new System.Windows.Forms.Label();
            this.label_userId = new System.Windows.Forms.Label();
            this.button_cancel = new System.Windows.Forms.Button();
            this.button_ok = new System.Windows.Forms.Button();
            this.contextMenuStrip_icon = new System.Windows.Forms.ContextMenuStrip(this.components);
            this.选项ToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.windows启动ToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.程序路径ToolStripMenuItem1 = new System.Windows.Forms.ToolStripMenuItem();
            this.toolStripSeparator1 = new System.Windows.Forms.ToolStripSeparator();
            this.连接断开ToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.退出ToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.notifyIcon = new System.Windows.Forms.NotifyIcon(this.components);
            this.menuStrip1.SuspendLayout();
            this.mainpanel.SuspendLayout();
            this.contextMenuStrip_icon.SuspendLayout();
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
            this.menuStrip1.ImageScalingSize = new System.Drawing.Size(20, 20);
            this.menuStrip1.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.设置ToolStripMenuItem});
            this.menuStrip1.Location = new System.Drawing.Point(0, 0);
            this.menuStrip1.Name = "menuStrip1";
            this.menuStrip1.Padding = new System.Windows.Forms.Padding(8, 2, 0, 2);
            this.menuStrip1.Size = new System.Drawing.Size(436, 28);
            this.menuStrip1.TabIndex = 7;
            this.menuStrip1.Text = "menuStrip1";
            // 
            // 设置ToolStripMenuItem
            // 
            this.设置ToolStripMenuItem.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.程序路径ToolStripMenuItem});
            this.设置ToolStripMenuItem.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.设置ToolStripMenuItem.Name = "设置ToolStripMenuItem";
            this.设置ToolStripMenuItem.Size = new System.Drawing.Size(51, 24);
            this.设置ToolStripMenuItem.Text = "设置";
            // 
            // 程序路径ToolStripMenuItem
            // 
            this.程序路径ToolStripMenuItem.Name = "程序路径ToolStripMenuItem";
            this.程序路径ToolStripMenuItem.Size = new System.Drawing.Size(144, 26);
            this.程序路径ToolStripMenuItem.Text = "程序路径";
            this.程序路径ToolStripMenuItem.Click += new System.EventHandler(this.程序路径ToolStripMenuItem_Click);
            // 
            // mainpanel
            // 
            this.mainpanel.BackColor = System.Drawing.Color.Transparent;
            this.mainpanel.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Center;
            this.mainpanel.Controls.Add(this.textBox_password);
            this.mainpanel.Controls.Add(this.textBox_userId);
            this.mainpanel.Controls.Add(this.label_password);
            this.mainpanel.Controls.Add(this.label_userId);
            this.mainpanel.Controls.Add(this.button_cancel);
            this.mainpanel.Controls.Add(this.button_ok);
            this.mainpanel.Location = new System.Drawing.Point(0, 35);
            this.mainpanel.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.mainpanel.Name = "mainpanel";
            this.mainpanel.Size = new System.Drawing.Size(437, 260);
            this.mainpanel.TabIndex = 0;
            // 
            // textBox_password
            // 
            this.textBox_password.Font = new System.Drawing.Font("Microsoft Sans Serif", 12.8F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.textBox_password.Location = new System.Drawing.Point(171, 102);
            this.textBox_password.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.textBox_password.Name = "textBox_password";
            this.textBox_password.Size = new System.Drawing.Size(224, 32);
            this.textBox_password.TabIndex = 5;
            // 
            // textBox_userId
            // 
            this.textBox_userId.Font = new System.Drawing.Font("Microsoft Sans Serif", 12.8F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.textBox_userId.Location = new System.Drawing.Point(171, 58);
            this.textBox_userId.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.textBox_userId.Name = "textBox_userId";
            this.textBox_userId.Size = new System.Drawing.Size(224, 32);
            this.textBox_userId.TabIndex = 4;
            // 
            // label_password
            // 
            this.label_password.AutoSize = true;
            this.label_password.Font = new System.Drawing.Font("Microsoft Sans Serif", 12.8F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.label_password.Location = new System.Drawing.Point(97, 102);
            this.label_password.Name = "label_password";
            this.label_password.Size = new System.Drawing.Size(62, 26);
            this.label_password.TabIndex = 3;
            this.label_password.Text = "密码:";
            // 
            // label_userId
            // 
            this.label_userId.AutoSize = true;
            this.label_userId.Font = new System.Drawing.Font("Microsoft Sans Serif", 12.8F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.label_userId.Location = new System.Drawing.Point(75, 58);
            this.label_userId.Name = "label_userId";
            this.label_userId.Size = new System.Drawing.Size(84, 26);
            this.label_userId.TabIndex = 2;
            this.label_userId.Text = "用户名:";
            // 
            // button_cancel
            // 
            this.button_cancel.Font = new System.Drawing.Font("Microsoft Sans Serif", 10.8F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.button_cancel.Location = new System.Drawing.Point(244, 172);
            this.button_cancel.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.button_cancel.Name = "button_cancel";
            this.button_cancel.Size = new System.Drawing.Size(83, 34);
            this.button_cancel.TabIndex = 1;
            this.button_cancel.Text = "关闭";
            this.button_cancel.UseVisualStyleBackColor = true;
            this.button_cancel.Click += new System.EventHandler(this.button_cancel_Click);
            // 
            // button_ok
            // 
            this.button_ok.Font = new System.Drawing.Font("Microsoft Sans Serif", 10.8F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.button_ok.Location = new System.Drawing.Point(128, 172);
            this.button_ok.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.button_ok.Name = "button_ok";
            this.button_ok.Size = new System.Drawing.Size(83, 34);
            this.button_ok.TabIndex = 0;
            this.button_ok.Text = "连接";
            this.button_ok.UseVisualStyleBackColor = true;
            this.button_ok.Click += new System.EventHandler(this.button_ok_Click);
            // 
            // contextMenuStrip_icon
            // 
            this.contextMenuStrip_icon.ImageScalingSize = new System.Drawing.Size(20, 20);
            this.contextMenuStrip_icon.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.选项ToolStripMenuItem,
            this.toolStripSeparator1,
            this.连接断开ToolStripMenuItem,
            this.退出ToolStripMenuItem});
            this.contextMenuStrip_icon.Name = "contextMenuStrip_icon";
            this.contextMenuStrip_icon.Size = new System.Drawing.Size(145, 82);
            // 
            // 选项ToolStripMenuItem
            // 
            this.选项ToolStripMenuItem.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.windows启动ToolStripMenuItem,
            this.程序路径ToolStripMenuItem1});
            this.选项ToolStripMenuItem.Name = "选项ToolStripMenuItem";
            this.选项ToolStripMenuItem.Size = new System.Drawing.Size(144, 24);
            this.选项ToolStripMenuItem.Text = "选项";
            // 
            // windows启动ToolStripMenuItem
            // 
            this.windows启动ToolStripMenuItem.Name = "windows启动ToolStripMenuItem";
            this.windows启动ToolStripMenuItem.Size = new System.Drawing.Size(256, 26);
            this.windows启动ToolStripMenuItem.Text = "Windows登录后自动启动";
            this.windows启动ToolStripMenuItem.Click += new System.EventHandler(this.windows启动ToolStripMenuItem_Click);
            // 
            // 程序路径ToolStripMenuItem1
            // 
            this.程序路径ToolStripMenuItem1.Name = "程序路径ToolStripMenuItem1";
            this.程序路径ToolStripMenuItem1.Size = new System.Drawing.Size(256, 26);
            this.程序路径ToolStripMenuItem1.Text = "程序路径";
            this.程序路径ToolStripMenuItem1.Click += new System.EventHandler(this.程序路径ToolStripMenuItem1_Click);
            // 
            // toolStripSeparator1
            // 
            this.toolStripSeparator1.Name = "toolStripSeparator1";
            this.toolStripSeparator1.Size = new System.Drawing.Size(141, 6);
            // 
            // 连接断开ToolStripMenuItem
            // 
            this.连接断开ToolStripMenuItem.Name = "连接断开ToolStripMenuItem";
            this.连接断开ToolStripMenuItem.Size = new System.Drawing.Size(144, 24);
            this.连接断开ToolStripMenuItem.Text = "连接/断开";
            this.连接断开ToolStripMenuItem.Click += new System.EventHandler(this.连接断开ToolStripMenuItem_Click);
            // 
            // 退出ToolStripMenuItem
            // 
            this.退出ToolStripMenuItem.Name = "退出ToolStripMenuItem";
            this.退出ToolStripMenuItem.Size = new System.Drawing.Size(144, 24);
            this.退出ToolStripMenuItem.Text = "退出";
            this.退出ToolStripMenuItem.Click += new System.EventHandler(this.退出ToolStripMenuItem_Click);
            // 
            // notifyIcon
            // 
            this.notifyIcon.ContextMenuStrip = this.contextMenuStrip_icon;
            this.notifyIcon.Icon = ((System.Drawing.Icon)(resources.GetObject("notifyIcon.Icon")));
            this.notifyIcon.Text = "tianmao";
            this.notifyIcon.Visible = true;
            // 
            // MainForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 15F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(436, 291);
            this.ContextMenuStrip = this.contextMenuStrip_icon;
            this.Controls.Add(this.menuStrip1);
            this.Controls.Add(this.mainpanel);
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.MaximizeBox = false;
            this.Name = "MainForm";
            this.Load += new System.EventHandler(this.MainForm_Load);
            this.menuStrip1.ResumeLayout(false);
            this.menuStrip1.PerformLayout();
            this.mainpanel.ResumeLayout(false);
            this.mainpanel.PerformLayout();
            this.contextMenuStrip_icon.ResumeLayout(false);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion
        private System.Windows.Forms.Panel mainpanel;
        private System.Windows.Forms.TextBox textBox_password;
        private System.Windows.Forms.TextBox textBox_userId;
        private System.Windows.Forms.Label label_password;
        private System.Windows.Forms.Label label_userId;
        private System.Windows.Forms.Button button_cancel;
        private System.Windows.Forms.Button button_ok;
        private System.Windows.Forms.ImageList setImageList;
        private System.Windows.Forms.MenuStrip menuStrip1;
        private System.Windows.Forms.ToolStripMenuItem 设置ToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem 程序路径ToolStripMenuItem;
        private System.Windows.Forms.ContextMenuStrip contextMenuStrip_icon;
        private System.Windows.Forms.NotifyIcon notifyIcon;
        private System.Windows.Forms.ToolStripMenuItem 连接断开ToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem 退出ToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem 选项ToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem windows启动ToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem 程序路径ToolStripMenuItem1;
        private System.Windows.Forms.ToolStripSeparator toolStripSeparator1;
    }
}


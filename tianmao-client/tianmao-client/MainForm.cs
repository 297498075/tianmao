using SocketClient;
using System;
using System.Windows.Forms;
using tianmao_client.Common;

namespace tianmao_client
{
    public partial class MainForm : System.Windows.Forms.Form
    {
        private static String userId;
        private static String password;

        public static string UserId { get => userId.Trim(); set => userId = value; }
        public static string Password { get => password.Trim(); set => password = value; }

        public MainForm(String userId = "", String password = "")
        {
            UserId = userId;
            Password = password;
            InitializeComponent();
        }

        private void MainForm_Load(object sender, EventArgs e)
        {
            if (AutoStart.Have(Program.Name)) { windows启动ToolStripMenuItem.Checked = true; }
        }

        private void button_ok_Click(object sender, EventArgs e)
        {
            userId = textBox_userId.Text;
            password = textBox_password.Text;

            String str = CheckValue();
            if (!String.IsNullOrEmpty(str)) { MessageBox.Show(str); return; }
            if (Session.State == Session.SocketState.Close)
            {
                Session.State = Session.SocketState.Connected;
                MessageBox.Show("已连接到服务器");
                连接断开ToolStripMenuItem.Text = "断开";
                button_ok.Text = "断开";
            }
            else
            {
                Session.State = Session.SocketState.Close;
                MessageBox.Show("已断开连接");
                连接断开ToolStripMenuItem.Text = "连接";
                button_ok.Text = "连接";
            }
        }

        private string CheckValue()
        {
            if (String.IsNullOrEmpty(UserId) || String.IsNullOrEmpty(Password))
            {
                return "请输入用户名和密码！";
            }

            var pass = DBCommon.DataBaseFactory.GetDataBase(DBCommon.DataBaseType.main)
                .ExecuteSingle("select password from User where id='" + userId + "'");
            if (pass == null || pass.Equals("Password"))
            {
                return "用户名或密码错误！";
            }

            return String.Empty;
        }

        private void button_cancel_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void 设置ToolStripMenuItem_MouseEnter(object sender, EventArgs e)
        {
            设置ToolStripMenuItem.Image = setImageList.Images[0];
        }

        private void 设置ToolStripMenuItem_MouseLeave(object sender, EventArgs e)
        {
            设置ToolStripMenuItem.Image = setImageList.Images[1];
        }

        private void 程序路径ToolStripMenuItem_Click(object sender, EventArgs e)
        {
            new PathForm().ShowDialog();
        }

        private void 连接断开ToolStripMenuItem_Click(object sender, EventArgs e)
        {
            button_ok_Click(sender, e);
        }

        private void 退出ToolStripMenuItem_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void 程序路径ToolStripMenuItem1_Click(object sender, EventArgs e)
        {
            程序路径ToolStripMenuItem_Click(sender, e);
        }

        private void windows启动ToolStripMenuItem_Click(object sender, EventArgs e)
        {
            if (windows启动ToolStripMenuItem.Checked)
            {
                AutoStart.Delete(Program.Name);
                windows启动ToolStripMenuItem.Checked = false;
            }
            else
            {
                AutoStart.Add(Program.Name);
                windows启动ToolStripMenuItem.Checked = true;
            }
        }

    }
}

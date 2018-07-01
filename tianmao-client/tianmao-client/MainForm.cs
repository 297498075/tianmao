using SocketClient;
using System;
using System.Windows.Forms;

namespace tianmao_client
{
    public partial class MainForm : System.Windows.Forms.Form
    {
        private static String address = String.Empty;
        private static String id = String.Empty;

        public static string Address { get => address.Trim(); set => address = value; }
        public static string Id { get => id.Trim(); set => id = value; }

        public MainForm()
        {
            InitializeComponent();
        }

        private void button_ok_Click(object sender, EventArgs e)
        {
            if(Program.State == Program.SocketState.Close)
            {
                address = textBox_服务器地址.Text;
                id = textBox_名称.Text;
                Program.State = Program.SocketState.Connected;
                button_ok.Text = "断开";
            }
            else
            {
                Program.State = Program.SocketState.Close;
                button_ok.Text = "连接";
            }
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

        private void 设置ToolStripMenuItem_Click(object sender, EventArgs e)
        {
            new PathForm().ShowDialog();
        }
    }
}

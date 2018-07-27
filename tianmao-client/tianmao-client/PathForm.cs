using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Diagnostics;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using tianmao_client.Service;

namespace tianmao_client
{
    public partial class PathForm : Form
    {
        public static Dictionary<String, String> paths;

        static PathForm()
        {
            using (FileStream fs = new FileStream("Process.json", FileMode.Open))
            {
                using (StreamReader sr = new StreamReader(fs))
                {
                    paths = JsonConvert.DeserializeObject<Dictionary<string, string>>(sr.ReadToEnd());
                }
            }
        }

        public PathForm()
        {
            InitializeComponent();
        }

        private void button_cancel_Click(object sender, EventArgs e)
        {
            DialogResult = DialogResult.Cancel;
            if (DialogResult == DialogResult.OK) {
                //关闭选中程序
                int index = dataGridView.CurrentRow.Index;    //取得选中行的索引  
                string exeName = dataGridView.Rows[index].Cells["Column_Path"].Value.ToString();
                //程序名称
                exeName = exeName.Substring(exeName.LastIndexOf('\\') + 1);
                CmdService cmd = new CmdService();
                cmd.Exec("taskkill /f /im \""+ exeName + "\"");
            }
        }

        private void PathForm_Load(object sender, EventArgs e)
        {
            foreach(var keyValue in paths)
            {
                dataGridView.Rows.Add(keyValue.Key,keyValue.Value);
            }
        }

        private void button_save_Click(object sender, EventArgs e)
        {
            paths.Clear();
            foreach (DataGridViewRow keyValue in dataGridView.Rows)
            {
                var cmd = keyValue.Cells[2].Value == null ?
                    String.Empty : keyValue.Cells[2].Value.ToString();
                if (!String.IsNullOrEmpty(keyValue.Cells[0].Value?.ToString()))
                paths.Add(keyValue.Cells[0].Value?.ToString()
                    ,keyValue.Cells[1].Value.ToString() + '\0' + cmd
                     );
            }
            MessageBox.Show("保存成功");
        }
    }
}

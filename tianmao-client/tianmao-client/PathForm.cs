using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

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
                paths.Add(keyValue.Cells[0].Value.ToString()
                    ,keyValue.Cells[1].Value.ToString());
            }
        }
    }
}

using System;
using System.Windows.Forms;

namespace tianmao_client
{
    static class Program
    {
        public static String Name { get => "tianmao"; }
        [STAThread]
        static void Main()
        {
            Session.SocketStart();
            Application.EnableVisualStyles();
            Application.SetCompatibleTextRenderingDefault(false);
            Application.Run(new MainForm(GetUserId(),GetPassword()));
        }

        private static string GetPassword()
        {
            return String.Empty;
        }

        private static string GetUserId()
        {
            return String.Empty;
        }
    }
}

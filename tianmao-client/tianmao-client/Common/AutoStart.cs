using IWshRuntimeLibrary;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace tianmao_client.Common
{
    public static class AutoStart
    {
        public static bool Have(String fileName)
        {
            return System.IO.File.Exists(
                Path.Combine(
                    Environment.GetFolderPath(
                        Environment.SpecialFolder.CommonStartup), fileName + ".lnk"));
        }

        public static bool Add(String fileName)
        {
            WshShell shell = new WshShell();
            IWshShortcut shortcut = (IWshShortcut)shell.CreateShortcut(Path.Combine(Environment.GetFolderPath(Environment.SpecialFolder.CommonStartup), fileName + ".lnk"));//创建快捷方式对象
            shortcut.TargetPath = System.Reflection.Assembly.GetExecutingAssembly().Location;//指定目标路径
            shortcut.WorkingDirectory = Environment.CurrentDirectory;//设置起始位置
            shortcut.WindowStyle = 1;//设置运行方式，默认为常规窗口
            shortcut.Description = "Only for learning";//设置备注
            shortcut.IconLocation = Path.Combine(Environment.CurrentDirectory, "icon.ico");//设置图标路径
            shortcut.Save();//保存快捷方式
            
            return true;
        }

        public static bool Delete(String fileName)
        {
            try
            {
                System.IO.File.Delete(Path.Combine(Environment.GetFolderPath(Environment.SpecialFolder.CommonStartup), fileName + ".lnk"));
            }
            catch (Exception)
            {
                return false;
            }
            return true;
        }
    }
}

using System.IO;
using System.Windows;
using Microsoft.Win32;
using MyOffice.Classes;

namespace MyOffice.Abstract
{
    public abstract class DialogPathFinder : IPathFinder
    {
        public string GetPath(string filter)
        {
            bool? res = null;
            string path = "";
            Application.Current.Dispatcher.Invoke(() =>
            {
                OpenFileDialog ofd = new OpenFileDialog();
                ofd.Filter = filter;
                res = ofd.ShowDialog(Application.Current.MainWindow);
                path = ofd.FileName;
            });
            if (res == true && File.Exists(path))
            {
                return path;
            }
            return null;
        }

        public abstract string GetPath();
    }
}

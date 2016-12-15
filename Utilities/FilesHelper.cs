using System;
using System.IO;
using System.Windows.Forms;
using DevExpress.XtraEditors;

namespace Utilities
{
    public class FilesHelper
    {
        public static string FindingFileName(string path, string name)
        {
            return FindingFileName(path, name, true);
        }

        public static string FindingFileName(string path, string name, bool showMessage)
        {
            string str = "\\";
            for (int i = 0; i <= 10; i++)
            {
                if (File.Exists(string.Concat(path, str, name)))
                {
                    return Path.GetFullPath(string.Concat(path, str, name));
                }
                str = string.Concat(str, "..\\");
            }
            string currentDirectory = Environment.CurrentDirectory;
            if (currentDirectory != path)
            {
                return FindingFileName(currentDirectory, name, showMessage);
            }
            if (showMessage)
            {
                XtraMessageBox.Show(string.Concat("Archivo ", name, " no se existe"), "Error", MessageBoxButtons.OK, MessageBoxIcon.Hand);
            }
            return "";
        } 
    }
}
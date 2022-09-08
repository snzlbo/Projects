using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.IO;
using System.Windows.Forms;

namespace fileHandler
{
    class FileChanger
    {
        public string text { get; set; }
        public string fileName { get; set; }
        public string path { get; set; }

        /// <summary>
        /// Текст уншиж оруулж ирэх
        /// </summary>
        /// <param name="path">Тухайн оруулж ирсэн файлын замыг байнга хадгална.</param>
        /// <returns></returns>
        public string readFile(string path)
        {
            try
            {
                FileStream filestream = File.OpenRead(path);
                byte[] bytE = new byte[8192];
                UTF8Encoding temp = new UTF8Encoding(true);
                while (filestream.Read(bytE, 0, bytE.Length) > 0)
                {
                    this.text = temp.GetString(bytE);
                };
                this.path = path;
                cutName(path);
                filestream.Close();
                return this.text;
            }
            catch (FileNotFoundException e)
            {
                Console.WriteLine(e.Message);
            }
            return "";
        }

        /// <summary>
        /// Path дотроос файлын нэрийг тасдаж авах.
        /// </summary>
        /// <param name="path">Тухайн оруулж ирсэн файлын замыг байнга хадгална.</param>
        public void cutName(string path)
        {
            FileStream file = File.OpenRead(path);
            string[] a = path.Split('\\');
            this.fileName = a[a.Length - 1];
            file.Close();
        }

        /// <summary>
        /// Өгөгдсөн зам дээр файлыг үүсгэнэ.
        /// </summary>
        /// <param name="path">зам</param>
        /// <param name="text">текст</param>
        public void createFile(string path, string text)
        {
            saveTextFile(path, text);
        }

        /// <summary>
        /// Өгөгдсөн байршилд файлыг хадгалах.
        /// </summary>
        /// <param name="path"></param>
        /// <param name="text"></param>
        public void TextHandle(string path, string text)
        {
            saveTextFile(path, text);
        }

        private void saveTextFile(string path, string text)
        {
            StreamWriter streamWriter = new StreamWriter(path);
            streamWriter.Write(text);
            streamWriter.Close();
            this.path = path;
        }

        /// <summary>
        /// Field цэвэрлэх
        /// </summary>
        public void makeNull() {
            path = null;
            text = null;
            fileName = null;
        }

    }
}

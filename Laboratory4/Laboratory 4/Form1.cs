using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Runtime.Serialization.Formatters.Binary;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.IO;
using System.Windows.Forms;
using fileHandler;

namespace Laboratory_4
{
    public partial class Notepad : Form
    {
        private OpenFileDialog openFileDialog;
        private FileChanger fileChanger;
        private SaveFileDialog saveFileDialog;
        private FontDialog fontDialog;
        private ConfirmForm confirmForm;
        private const string configName = "config.cfg";

        /// <summary>
        /// Анхдагч байгуулагч
        /// </summary>
        public Notepad()
        {
            fileChanger = new FileChanger();
            InitializeComponent();
        }

        /// <summary>
        /// Шинэ файл үүсгэх товчлуурыг зохицуулагч. "Шинэ"
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void new_Click(object sender, EventArgs e)
        {
            if (fileChanger.path == null)
            {
                if (this.confirmForm == null)
                {
                    this.confirmForm = new ConfirmForm("Hadgalah uu?");
                }

                if(richTextBox1.Text == fileChanger.text)
                {
                    fileChanger.makeNull();
                    richTextBox1.Text = "";
                }
                DialogResult result = this.confirmForm.ShowDialog();
                if (result == DialogResult.Yes)
                {
                    save_Click(sender, e);
                }
                else if (result == DialogResult.Cancel)
                {

                }
                else if (result == DialogResult.No)
                {
                    fileChanger.makeNull();
                    richTextBox1.Text = "";
                }
            }
            fileChanger.makeNull();
            richTextBox1.Text = "";
        }

        /// <summary>
        /// Текст өөрчлөгчид файл оруулж ирэх товчлуур зохицуулагч. "Нээх"
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void open_Click(object sender, EventArgs e) {
            openFileDialog = new OpenFileDialog();
            openFileDialog.Filter = "Notepad Files (*.txt)|*.txt|(*.mytext)|*.mytext|(*.myFile)|*.myFile";

            if (openFileDialog.ShowDialog() == DialogResult.OK)
            {
                string path = openFileDialog.FileName.ToString();
                richTextBox1.Text = fileChanger.readFile(path);
            }
        }
        /// <summary>
        /// Файлыг хадгалах товчлуур зохицуулагч. "Хадгалах" SAME AS SAVE AS 
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        /// 
        private void save_Click(object sender, EventArgs e)
        {
            if (fileChanger.path != null)
            {
                fileChanger.saveTextFile(fileChanger.path, richTextBox1.Text);
            }
            else
            {
                saveFile_Click(sender, e);
            }
        }
        
        /// <summary>
        /// Файлыг хадгалах үйлдэлийг хийх товчлуур зохицуулагч "Файл хадгалах"
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void saveFile_Click(object sender, EventArgs e)
        {
            saveFileDialog = new SaveFileDialog();
            string path;

            if (fileChanger.fileName != null)
            {
                saveFileDialog.FileName = fileChanger.fileName;
            }
            saveFileDialog.Filter = "Notepad Files (*.txt)|*.txt|(*.mytext)|*.mytext|(*.myFile)|*.myFile";
            saveFileDialog.AddExtension = true;
            if (saveFileDialog.ShowDialog() == DialogResult.OK)
            {
                path = saveFileDialog.FileName;
                fileChanger.createFile(path, richTextBox1.Text);
            }
        }

        /// <summary>
        /// Формыг ажлуулж эхлэхэд ажиллаж эхлэх функц. Энд өмнөх байршлыг config.cfg дээрээс олж авчирч байгаа.
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void Notepad_Load(object sender, EventArgs e)
        {
            FileStream filestream = File.OpenRead(configName);
            try
            {
                BinaryFormatter formatter = new BinaryFormatter();
                string filePath = (string)formatter.Deserialize(filestream);
                int x = Int32.Parse(formatter.Deserialize(filestream).ToString()) ;
                int y = Int32.Parse(formatter.Deserialize(filestream).ToString());
                fileChanger.readFile(filePath);
                richTextBox1.Text = fileChanger.text;

                this.Location = new Point(x, y);
            }
            catch (Exception err)
            {
                Console.WriteLine(err.Message);
            }
            finally
            {
                filestream.Close();
            }
        }

        /// <summary>
        /// Формыг хаахаас өмнө хадгалагдсан эсэхийг шалгах. Өмнөх байршил хадгалах.
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void Notepad_FormClosing(object sender, FormClosingEventArgs e)
        {
            string path = Directory.GetCurrentDirectory();
            FileStream filestream = File.OpenWrite(path + "/" + configName);
            BinaryFormatter formatter = new BinaryFormatter();

            if (richTextBox1.Text != fileChanger.text)
            {
                if (this.confirmForm == null)
                {
                    this.confirmForm = new ConfirmForm("Uurchlult hadgalah uu?");
                    DialogResult result = this.confirmForm.ShowDialog();
                    if (result == DialogResult.Yes)
                    {
                        save_Click(sender, e);
                    }
                }
            }

            if (fileChanger.path == null)
            {
                if (richTextBox1.Text != "") save_Click(sender, e);
            }


            //Байршлыг config.cfg дотор бичих.
            if (fileChanger.path != null)
            {
                formatter.Serialize(filestream, fileChanger.path);
                formatter.Serialize(filestream, this.Location.X);
                formatter.Serialize(filestream, this.Location.Y);
            }
            filestream.Close();
        }

        /// <summary>
        /// FontDialog зохицуулагч товчлуур.
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void font_Click(object sender, EventArgs e)
        {
            fontDialog = new FontDialog();
            if (fontDialog.ShowDialog() != DialogResult.Cancel)
            {
                richTextBox1.Font = fontDialog.Font;
                richTextBox1.ForeColor = fontDialog.Color;
            }
        }

        /// <summary>
        /// Гарах товчлуур зохицуулагч. Exit
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void exit_Click(object sender, EventArgs e)
        {
            if (fileChanger.path == null)
            {
                if (this.confirmForm == null)
                {
                    this.confirmForm = new ConfirmForm("Hadgalah uu?");
                }

                DialogResult result = this.confirmForm.ShowDialog();
                if (result == DialogResult.Yes)
                {
                    save_Click(sender, e);
                    Application.Exit();
                }
                else if (result == DialogResult.No)
                {
                    Application.Exit();
                }
                else if (result == DialogResult.Cancel)
                {
                    
                }
            }
            Application.Exit();
        }
    }
}


namespace Laboratory_4
{
    partial class Notepad
    {
        /// <summary>
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code

        /// <summary>
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            this.menuStrip1 = new System.Windows.Forms.MenuStrip();
            this.файлToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.шинэToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.нээхToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.хадгаларToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.файлХадгалахToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.toolStripSeparator1 = new System.Windows.Forms.ToolStripSeparator();
            this.гарахToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.форматToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.фонтToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.richTextBox1 = new System.Windows.Forms.RichTextBox();
            this.menuStrip1.SuspendLayout();
            this.SuspendLayout();
            // 
            // menuStrip1
            // 
            this.menuStrip1.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.файлToolStripMenuItem,
            this.форматToolStripMenuItem});
            this.menuStrip1.Location = new System.Drawing.Point(0, 0);
            this.menuStrip1.Name = "menuStrip1";
            this.menuStrip1.Size = new System.Drawing.Size(891, 24);
            this.menuStrip1.TabIndex = 0;
            this.menuStrip1.Text = "menuStrip1";
            // 
            // файлToolStripMenuItem
            // 
            this.файлToolStripMenuItem.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.шинэToolStripMenuItem,
            this.нээхToolStripMenuItem,
            this.хадгаларToolStripMenuItem,
            this.файлХадгалахToolStripMenuItem,
            this.toolStripSeparator1,
            this.гарахToolStripMenuItem});
            this.файлToolStripMenuItem.Name = "файлToolStripMenuItem";
            this.файлToolStripMenuItem.Size = new System.Drawing.Size(48, 20);
            this.файлToolStripMenuItem.Text = "&Файл";
            // 
            // шинэToolStripMenuItem
            // 
            this.шинэToolStripMenuItem.Name = "шинэToolStripMenuItem";
            this.шинэToolStripMenuItem.ShortcutKeys = ((System.Windows.Forms.Keys)((System.Windows.Forms.Keys.Control | System.Windows.Forms.Keys.N)));
            this.шинэToolStripMenuItem.Size = new System.Drawing.Size(226, 22);
            this.шинэToolStripMenuItem.Text = "&Шинэ";
            this.шинэToolStripMenuItem.Click += new System.EventHandler(this.new_Click);
            // 
            // нээхToolStripMenuItem
            // 
            this.нээхToolStripMenuItem.Name = "нээхToolStripMenuItem";
            this.нээхToolStripMenuItem.ShortcutKeys = ((System.Windows.Forms.Keys)((System.Windows.Forms.Keys.Control | System.Windows.Forms.Keys.O)));
            this.нээхToolStripMenuItem.Size = new System.Drawing.Size(226, 22);
            this.нээхToolStripMenuItem.Text = "&Нээх...";
            this.нээхToolStripMenuItem.Click += new System.EventHandler(this.open_Click);
            // 
            // хадгаларToolStripMenuItem
            // 
            this.хадгаларToolStripMenuItem.Name = "хадгаларToolStripMenuItem";
            this.хадгаларToolStripMenuItem.ShortcutKeys = ((System.Windows.Forms.Keys)((System.Windows.Forms.Keys.Control | System.Windows.Forms.Keys.S)));
            this.хадгаларToolStripMenuItem.Size = new System.Drawing.Size(226, 22);
            this.хадгаларToolStripMenuItem.Text = "&Хадгалах";
            this.хадгаларToolStripMenuItem.Click += new System.EventHandler(this.save_Click);
            // 
            // файлХадгалахToolStripMenuItem
            // 
            this.файлХадгалахToolStripMenuItem.Name = "файлХадгалахToolStripMenuItem";
            this.файлХадгалахToolStripMenuItem.ShortcutKeys = ((System.Windows.Forms.Keys)(((System.Windows.Forms.Keys.Control | System.Windows.Forms.Keys.Shift) 
            | System.Windows.Forms.Keys.S)));
            this.файлХадгалахToolStripMenuItem.Size = new System.Drawing.Size(226, 22);
            this.файлХадгалахToolStripMenuItem.Text = "&Файл хадгалах";
            this.файлХадгалахToolStripMenuItem.Click += new System.EventHandler(this.saveFile_Click);
            // 
            // toolStripSeparator1
            // 
            this.toolStripSeparator1.Name = "toolStripSeparator1";
            this.toolStripSeparator1.Size = new System.Drawing.Size(223, 6);
            // 
            // гарахToolStripMenuItem
            // 
            this.гарахToolStripMenuItem.Name = "гарахToolStripMenuItem";
            this.гарахToolStripMenuItem.ShortcutKeys = ((System.Windows.Forms.Keys)((System.Windows.Forms.Keys.Control | System.Windows.Forms.Keys.X)));
            this.гарахToolStripMenuItem.Size = new System.Drawing.Size(226, 22);
            this.гарахToolStripMenuItem.Text = "Гарах";
            this.гарахToolStripMenuItem.Click += new System.EventHandler(this.exit_Click);
            // 
            // форматToolStripMenuItem
            // 
            this.форматToolStripMenuItem.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.фонтToolStripMenuItem});
            this.форматToolStripMenuItem.Name = "форматToolStripMenuItem";
            this.форматToolStripMenuItem.Size = new System.Drawing.Size(62, 20);
            this.форматToolStripMenuItem.Text = "&Формат";
            // 
            // фонтToolStripMenuItem
            // 
            this.фонтToolStripMenuItem.Name = "фонтToolStripMenuItem";
            this.фонтToolStripMenuItem.Size = new System.Drawing.Size(180, 22);
            this.фонтToolStripMenuItem.Text = "Фонт...";
            this.фонтToolStripMenuItem.Click += new System.EventHandler(this.font_Click);
            // 
            // richTextBox1
            // 
            this.richTextBox1.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.richTextBox1.Location = new System.Drawing.Point(0, 27);
            this.richTextBox1.Name = "richTextBox1";
            this.richTextBox1.Size = new System.Drawing.Size(883, 500);
            this.richTextBox1.TabIndex = 1;
            this.richTextBox1.Text = "";
            // 
            // Notepad
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(891, 535);
            this.Controls.Add(this.richTextBox1);
            this.Controls.Add(this.menuStrip1);
            this.MainMenuStrip = this.menuStrip1;
            this.Name = "Notepad";
            this.Text = "Текст өөрчлөгч";
            this.FormClosing += new System.Windows.Forms.FormClosingEventHandler(this.Notepad_FormClosing);
            this.Load += new System.EventHandler(this.Notepad_Load);
            this.menuStrip1.ResumeLayout(false);
            this.menuStrip1.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.MenuStrip menuStrip1;
        private System.Windows.Forms.RichTextBox richTextBox1;
        private System.Windows.Forms.ToolStripMenuItem файлToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem шинэToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem нээхToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem хадгаларToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem форматToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem фонтToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem файлХадгалахToolStripMenuItem;
        private System.Windows.Forms.ToolStripSeparator toolStripSeparator1;
        private System.Windows.Forms.ToolStripMenuItem гарахToolStripMenuItem;
    }
}


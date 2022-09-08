using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Laboratory_4
{
    public partial class ConfirmForm : Form
    {
        public ConfirmForm()
        {
            InitializeComponent();
            this.DialogResult = DialogResult.No;
        }

        public ConfirmForm(string title)
        {
            InitializeComponent();
            this.DialogResult = DialogResult.No;
            this.label1.Text = title;
        }

        private void button1_Click(object sender, EventArgs e)
        {
            DialogResult = DialogResult.Yes;
        }

        private void button2_Click(object sender, EventArgs e)
        {
            
        }
    }
}

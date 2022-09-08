using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using Calculator;

namespace Laboratory3
{
    public partial class Form1 : Form
    {
        CalculatorBase calculator;
        int value1;
        string operation;
        public Form1()
        {
            InitializeComponent();
            calculator = new CalculatorBase();
        }

        private void Digit_click(object sender, EventArgs e)
        {
            if (result.Text == "0")
                result.Text = "";
            result.Text += (((Button)sender).Text);
        }
        private void Operators_Click(object sender, EventArgs e)
        {
            if(operation != "")
            {
                Equal_Load(sender, e);
            }
            value1 = Int32.Parse(result.Text);
            operation = ((Button)sender).Text;
            result.Text = "";
        }

        private void Equal_Load(object sender, EventArgs e)
        {
            switch (operation)
            {
                case "+":
                    calculator.add(value1, Int32.Parse(result.Text));
                    break;
                case "-":
                    calculator.subtract(value1, Int32.Parse(result.Text));
                    break;
            }
            result.Text = Convert.ToString(calculator.Result);
            operation = "";
        }

        public void MemoryDraw()
        {
            //create panel and buttons
            Panel panel = new Panel();
            Button MPbutton = new Button();
            Button MSbutton = new Button();
            Button MCbutton = new Button();
            TextBox resultdisplay = new TextBox();
            // panel add controls
            panel.Name = "panel1";
            panel.Size = new System.Drawing.Size(286, 100);
            panel.Controls.Add(MPbutton);
            panel.Controls.Add(MSbutton);
            panel.Controls.Add(MCbutton);
            panel.Controls.Add(resultdisplay);
            //memoryPlus 
            MPbutton.Location = new System.Drawing.Point(19, 53);
            MPbutton.Name = "MAbutton";
            MPbutton.Size = new System.Drawing.Size(63, 31);
            MPbutton.Text = "M+";
            MPbutton.Click += new System.EventHandler(this.MPbutton_Click);
            // memorySub 
            MSbutton.Location = new System.Drawing.Point(105, 53);
            MSbutton.Name = "MMbutton";
            MSbutton.Size = new System.Drawing.Size(63, 31);
            MSbutton.Text = "M-";
            MSbutton.Click += new System.EventHandler(this.MSbutton_Click);
            //memoryClear 
            MCbutton.Location = new System.Drawing.Point(192, 53);
            MCbutton.Name = "MRbutton";
            MCbutton.Size = new System.Drawing.Size(63, 31);
            MCbutton.Text = "MC";
            MCbutton.Click += new EventHandler(this.MCbutton_Click);
            //resultDisplay
            resultdisplay.Location = new System.Drawing.Point(19, 3);
            resultdisplay.Name = "textbox";
            resultdisplay.Size = new System.Drawing.Size(236, 29);
            resultdisplay.Text = result.Text;
            // flowLayoutPanel add panel
            flowLayoutPanel1.Controls.Add(panel);
        }
        private void MCbutton_Click(object sender, System.EventArgs e)
        {
            flowLayoutPanel1.Controls.Remove((((Panel)(((Button)sender).Parent))));
        }
        private void MPbutton_Click(object sender, EventArgs e)
        {
            calculator.memoryList[0].IncreaseMemoryItem(Int32.Parse(flowLayoutPanel1.Controls[0].Controls[3].Text));
            flowLayoutPanel1.Controls[0].Controls[3].Text = Convert.ToString(calculator.memoryList[0].MemoryItem);
        }
        private void MSbutton_Click(object sender, EventArgs e)
        {
            calculator.memoryList[0].DecreaseMemoryItem(Int32.Parse(flowLayoutPanel1.Controls[0].Controls[3].Text));
            flowLayoutPanel1.Controls[0].Controls[3].Text = Convert.ToString(calculator.memoryList[0].MemoryItem);
        }

        private void Clear_button(object sender, EventArgs e)
        {
            calculator.clearResult();
            result.Text = Convert.ToString(calculator.Result);
        }

        private void ClearByOne_Button(object sender, EventArgs e)
        {
            calculator.removeByOne();
            result.Text = Convert.ToString(calculator.Result);
        }

        // MEMORY SECTION

        private void MemorySubtract(object sender, EventArgs e)
        {
            MemoryStorage(sender, e);
            calculator.memoryList[0].DecreaseMemoryItem(Int32.Parse(result.Text));
            flowLayoutPanel1.Controls[0].Controls[3].Text = Convert.ToString(calculator.memoryList[0].MemoryItem);
        }

        private void MemoryPlus(object sender, EventArgs e)
        {
            MemoryStorage(sender, e);
            calculator.memoryList[0].IncreaseMemoryItem(Int32.Parse(result.Text));
            flowLayoutPanel1.Controls[0].Controls[3].Text = Convert.ToString(calculator.memoryList[0].MemoryItem);
        }

        private void MemoryStorage(object sender, EventArgs e)
        {
            calculator.addToMemory();
            MemoryDraw();
        }

        private void MemoryClear(object sender, EventArgs e)
        {
            calculator.ClearMemory();
            flowLayoutPanel1.Controls.Clear();
        }
    }
}

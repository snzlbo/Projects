using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Laboratory5
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }

        private static int gap = 20;
        private Point zeroPoint;
        private String filter = "Image Files(*.jpg; *.jpeg; *.gif; *.bmp)|*.jpg; *.jpeg; *.gif; *.bmp";
        Bitmap bitmap;
        Graphics formulaGraphic;
        Graphics backgroundImage;
        Pen grayPen = new Pen(Color.Gray, 1);
        Pen bluePen = new Pen(Color.Blue, 2);

        private void panel1_Paint(object sender, PaintEventArgs e)
        {
            bitmap = new Bitmap(width: 3840, height: 2160);
            this.backgroundImage = Graphics.FromImage(bitmap);

            //Background-ийг цагаан болгож байна
            for (int i = 0; i < panel1.Width; i++)
            {
                backgroundImage.DrawLine(new Pen(Color.White, 1), new Point(i, 0), new Point(i, panel1.Height));
            }
            DrawBackground();
        }
        private void DrawBackground()
        {
            Graphics gridLine = panel1.CreateGraphics();
            int xAxisCounter = panel1.Width / gap;
            int yAxisCounter = panel1.Height / gap;
            int xPoint = gap, yPoint = gap;

            for (int i = 0; i < xAxisCounter; i++)
            {
                gridLine.DrawLine(this.grayPen, xPoint, 0, xPoint, panel1.Height);
                backgroundImage.DrawLine(this.grayPen, xPoint, 0, xPoint, panel1.Height);
                // X тэнхлэгийн тал хэсэгт цэнхрээр зурна
                if (i == xAxisCounter / 2)
                {
                    gridLine.DrawLine(this.bluePen, xPoint, 0, xPoint, panel1.Height);
                    backgroundImage.DrawLine(this.bluePen, xPoint, 0, xPoint, panel1.Height);
                    zeroPoint.X = xPoint;
                }
                else if (i < yAxisCounter)
                {
                    gridLine.DrawLine(grayPen, 0, yPoint, panel1.Width, yPoint);
                    backgroundImage.DrawLine(grayPen, 0, yPoint, panel1.Width, yPoint);
                    // Y тэнхлэгийн тал хэсэгт цэнхрээр зурна
                    if (i == yAxisCounter / 2)
                    {
                        gridLine.DrawLine(bluePen, 0, yPoint, panel1.Width, yPoint);
                        backgroundImage.DrawLine(bluePen, 0, yPoint, panel1.Width, yPoint);
                        zeroPoint.Y = yPoint;
                    }
                    yPoint += gap;
                }
                xPoint += gap;
            }
        }

        /// <summary>
        /// Өгөгдсөн а тогтмолын дагуу y = аx ^ 3 томъёоны график зуран функц
        /// </summary>
        private void DrawGraphic()
        {
            float graphicIterator = 0F;
            float yPoint = zeroPoint.Y;
            float xPoint = zeroPoint.X;
            float a = float.Parse(textBox1.Text);
            Pen redPen = new Pen(Color.Green, 2);

            //Бүх цэгүүдийн олонлогийг хадгалах лист
            List<PointF> top = new List<PointF>();
            List<PointF> bottom = new List<PointF>();
            if (formulaGraphic == null)
            {
                this.formulaGraphic = panel1.CreateGraphics();

            }
            if(a != 0)
            {
                //top side of cubic graphic
                while (xPoint < panel1.Width && yPoint > 0)
                {

                    yPoint = zeroPoint.Y - (a * (float)Math.Pow(graphicIterator, 3) * gap);
                    xPoint = zeroPoint.X + (graphicIterator * gap);
                    graphicIterator += (0.1F);
                    top.Add(new PointF(xPoint, yPoint));
                }
                yPoint = zeroPoint.Y;
                xPoint = zeroPoint.X;
                graphicIterator = 0F;

                //bottom side of cubic graphic
                while (xPoint > 0 || yPoint < panel1.Height)
                {
                    yPoint = zeroPoint.Y + (a * (float)Math.Pow(graphicIterator, 3) * gap);
                    xPoint = zeroPoint.X - (graphicIterator * gap);
                    graphicIterator += (0.1F);
                    bottom.Add(new PointF(xPoint, yPoint));
                }

                //Цэгүүдийг холбож зурах хэсэг
                PointF[] topArray = top.ToArray();
                PointF[] bottomArray = bottom.ToArray();
                formulaGraphic.SmoothingMode = System.Drawing.Drawing2D.SmoothingMode.AntiAlias;
                formulaGraphic.DrawCurve(redPen, topArray, 1.0F);
                formulaGraphic.DrawCurve(redPen, bottomArray, 1.0F);

                //Background bitmap зургийг гүйцээж зурж байна.
                backgroundImage.SmoothingMode = System.Drawing.Drawing2D.SmoothingMode.AntiAlias;
                backgroundImage.DrawCurve(redPen, topArray, 1.0F);
                backgroundImage.DrawCurve(redPen, bottomArray, 1.0F);
            }
        }

        private void Save_Click(object sender, EventArgs e)
        {
            DrawGraphic();
            backgroundImage.SmoothingMode = System.Drawing.Drawing2D.SmoothingMode.AntiAlias;
            Font font = new Font(new FontFamily("TIMES"), 24);
            Point setPoint = new Point(20, 20);
            Color fontColor = Color.Red;
            TextRenderer.DrawText(backgroundImage, "y = ax ^ 3", font, setPoint, fontColor);
            bitmap.Save(@"C:\Users\User\Desktop\Sainaa\Windows Programming\Laboratory5\bitmap.bmp", System.Drawing.Imaging.ImageFormat.Bmp);
        }

        private async void Import_Click(object sender, EventArgs e)
        {
            OpenFileDialog openFileDialog = new OpenFileDialog();
            openFileDialog.Filter = filter;
            DateTime date1, date2;

            List<PointF> foundPointF = new List<PointF>();

            Bitmap btmp;
            if (openFileDialog.ShowDialog() == DialogResult.OK)
            {
                btmp = new Bitmap(openFileDialog.FileName);
                date1 = DateTime.Now;
                Color gotColor;
                Color color;
                int width = btmp.Width;
                int height = btmp.Height;

                

                await Task.Run(() =>
                {
                    for (int i = 0; i < width; i++)
                    {
                        for (int j = 0; j < height; j++)
                        {

                            gotColor = btmp.GetPixel(i, j);
                            if (gotColor.R > 0 && gotColor.G < 80 && gotColor.B < 80)
                            {
                                color = btmp.GetPixel(0, j);
                                foundPointF.Add(new PointF(i, j));
                                if (color.R > 0 || color.G > 0 || color.B > 0)
                                {
                                    btmp.SetPixel(i, j, btmp.GetPixel(i, 0));
                                }
                                else
                                    btmp.SetPixel(i, j, color);
                            }
                        }
                    }
                });

                date2 = DateTime.Now;
                TimeSpan ts = date2.Subtract(date1);
                Console.WriteLine(ts.TotalMilliseconds);
                for (int i = 0; i < foundPointF.Count; i++)
                {
                    int xPoint = (int)foundPointF[i].X + 50;
                    int yPoint = (int)foundPointF[i].Y + 50;
                    try
                    {
                        btmp.SetPixel(xPoint, yPoint, Color.Red);
                    }
                    catch { }
                }
                panel1.BackgroundImage = btmp;
                bitmap.Save(@"C:\Users\User\Desktop\Sainaa\Windows Programming\Laboratory5\bitmapA.bmp", System.Drawing.Imaging.ImageFormat.Bmp);
            }
        }
    }
}

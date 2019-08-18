using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Drawing.Imaging;
using System.IO;
using System.Linq;
using System.Net;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace primageneratorx
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }

        public const int _width = 260;
        public const int _height = 305;

        public const string _base = "iVBORw0KGgoAAAANSUhEUgAAAQQAAAExCAMAAACtYSwmAAAABGdBTUEAALGPC/xhBQAAAwBQTFRFAAAAOzJ0TlJdYGVva3B7IrFM+rI8//IAqNrC2eDi8Pf58fj5AAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAxapfrAAAAQB0Uk5T////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////AFP3ByUAAAAJcEhZcwAADsIAAA7CARUoSoAAAAAZdEVYdFNvZnR3YXJlAHBhaW50Lm5ldCA0LjAuMjHxIGmVAAAKcUlEQVR4Xu2a7ZLcRg4Ez2dZtuz3f15dsqsGh+HXkDO7nLVd+YOBRqO7gYzQaiOk//wMPyMBIgEiASIBIgEiASIBIgEiAf4uEn654fWHEgkQCfA3kvDn4DM8RAJEAnxNCUzahyWWAdG3PoRIgEiAt0gYI054vTb1r7/+WhkCz3+jF79OJEAkwLsk/HdAoHH4aurZUjF4+IZ2P4RIgEiA90oQY8oJBi8Vs5ivh2+Q9I2vEQkQCfBFJHz//v2vv/4iKCQBKibQ4OIDPUQCRAJcJkGdV+z5b5DBg+YSo9yUBGCrjmjJV9c+TSRAJMCVEr59+zYa/+WPP/7gq1kKMjMPYpyYkAcyqqdYp1TjZ54iEiAS4DIJQKt4KBWapUNy1YPQKQJXf5yHSIBIgE+VMLo2WkqCYKlZOiR3PMB015gafOZlD5EAkQCfLcED334OgNcDlh7jBpl9CWLcdKdCGT98kkiASIDLJBSzJEtNIViuSiC/RRXouN8+QyRAJMCnSgC68rSNqfWWJ5YB0BYeZip6zQwdgVr67cNEAkQCvEXCkhpBTCPdq1gt8GIBW37+GJEAkQCfLQFoyaPuMsbaVDHbEqtJwZafP0AkQCTA15EgKAZPMlAGvF6wtUXeHTwiEiAS4AIJQD8e8p5ptg08SWM1Kbbq/fwjIgEiAa6RALTkyW9U5/wNqF8LO+wK1UCPl6zukvTzu0QCRAJcJgFoyfMPetvTL4W7KoSrBzoCXr/gIRIgEuACCaP9FWYewFPdYNcuBrNioUov1jyQcR/bRAJEAlwjYfoRsMHqaEBeg4t9D44GyxoybmWDSIBIgAskAG145jXYBXd8Y5ZheVACLM+6jw0i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";   
        public Color baseprimary = ColorTranslator.FromHtml("#6b707b");
        public Color basesecondary = ColorTranslator.FromHtml("#d9e0e2");
        public Color basehighlight = ColorTranslator.FromHtml("#fab23c");

        public string batchPath;

        private void button1_Click(object sender, EventArgs e)
        {
            string dim = textBox1.Text + "x" + textBox2.Text;
            try
            {
                Thread a = new Thread(() => doPrima(dim, true, true));
                a.IsBackground = true;
                a.Start();
            }
            catch
            {
                doPrima("1x1", true, true);
            }
        }

        private string getName()
        {
            try
            {
                WebClient w = new WebClient();
                byte[] dat = w.DownloadData("https://namey.muffinlabs.com/name.json?type=surname");
                string name = System.Text.Encoding.UTF8.GetString(dat);
                name = name.Substring(2, name.Length - 4);
                return name;
            }
            catch
            {
                return "apiError";
            }
        }

        public Bitmap doPrima(string dim, bool doDisplayProc, bool doProgressProc)
        {
            String[] dimr = dim.Split('x');
            int dimx = Int32.Parse(dimr[0]);
            int dimy = Int32.Parse(dimr[1]);
            int numOfPrimas = dimx * dimy;

            if (doProgressProc)
            {
                this.Invoke(new MethodInvoker(delegate ()
                {
                    progressBar1.Maximum = numOfPrimas;
                }));
            }


            string dppath = Environment.GetFolderPath(Environment.SpecialFolder.MyDocuments) + "/dicpicbot_data/";
            Size psize = new Size(_width, _height);
            Size mSize = getPrimSize(dim);
            Size newPrimaSize = getPrimSize(dim);
            List<Point> positions = getAllPositions(dim);
            Bitmap BaseBmp = new Bitmap(newPrimaSize.Width, newPrimaSize.Height);
            Graphics gr = Graphics.FromImage(BaseBmp);

            int count = 0;

            foreach (Point p in positions)
            {
                Bitmap prima = GetNewPrima();
                if (checkBox2.Checked)
                {
                    using (Graphics graphics = Graphics.FromImage(prima))
                    {
                        string primaName = getName();
                        PointF point = new PointF(2f, 280f);
                        Font lucFont = new Font("Lucida Console", 14);
                        SizeF size = graphics.MeasureString(primaName, lucFont);
                        RectangleF rect = new RectangleF(point, size);
                        rect.Height = rect.Height + 1;
                        graphics.FillRectangle(Brushes.Black, rect);
                        point.Y = point.Y + 2;
                        graphics.DrawString(primaName, lucFont, Brushes.White, point);
                        graphics.Dispose();
                    }
                }
                gr.DrawImage(prima, p);
                count++;

                if (doProgressProc)
                {
                    this.Invoke(new MethodInvoker(delegate ()
                    {
                        progressBar1.Value = count;
                    }));
                }
                if (checkBox1.Checked){
                    this.Invoke(new MethodInvoker(delegate ()
                    {
                        pictureBox1.Image = BaseBmp;
                    }));
                }
            }

            if (doDisplayProc)
            {
                this.Invoke(new MethodInvoker(delegate ()
                {
                    pictureBox1.Image = BaseBmp;
                }));
            }

            return BaseBmp;
        }

        private void Form1_Load(object sender, EventArgs e)
        {
            doPrima("1x1", true, false);
        }

        public List<Point> getAllPositions(string dim)
        {
            List<Point> points = new List<Point> { };

            string[] dimxy = dim.Split('x');
            int x = Int32.Parse(dimxy[0]);
            int y = Int32.Parse(dimxy[1]);

            for (int i = 0; i < x; i++)
            {
                for (int o = 0; o < y; o++)
                {
                    points.Add(new Point(_width * i, _height * o));

                }
            }

            return points;
        }

        public Size getPrimSize(string dim)
        {
            string[] dimxy = dim.Split('x');
            int basex = _width;
            int basey = _height;
            int x = Int32.Parse(dimxy[0]);
            int y = Int32.Parse(dimxy[1]);
            return new Size(basex * x, basey * y);
        }

        public Bitmap GetNewPrima()
        {
            Bitmap drawn = new Bitmap(_width, _height);

            Color basefeet = Color.FromArgb(255, 242, 0);
            Color baselegs = Color.FromArgb(34, 177, 76);
            Color baseface = Color.FromArgb(78, 82, 93);
            Color baseweird = Color.FromArgb(78, 82, 93);

            Color normallegs = Color.FromArgb(240, 247, 249);
            Color normalface = Color.FromArgb(78, 82, 93);

            Random rnd = new Random();
            Bitmap primabitmap;

            byte[] byteBuffer = Convert.FromBase64String(_base);
            MemoryStream memoryStream = new MemoryStream(byteBuffer);
            memoryStream.Position = 0;
            primabitmap = (Bitmap)Bitmap.FromStream(memoryStream);
            memoryStream.Close();
            memoryStream = null;
            byteBuffer = null;

            Color PRIMARY = Color.FromArgb(rnd.Next(0, 255), rnd.Next(0, 255), rnd.Next(0, 255));
            Color SECONDARY = Color.FromArgb(rnd.Next(0, 255), rnd.Next(0, 255), rnd.Next(0, 255));
            Color HIGHLIGHT = Color.FromArgb(rnd.Next(0, 255), rnd.Next(0, 255), rnd.Next(0, 255));
            Color FEET = Color.FromArgb(rnd.Next(0, 255), rnd.Next(0, 255), rnd.Next(0, 255));
            Color LEGS = Color.FromArgb(rnd.Next(0, 255), rnd.Next(0, 255), rnd.Next(0, 255));
            Color FACE = Color.FromArgb(rnd.Next(0, 255), rnd.Next(0, 255), rnd.Next(0, 255));
            Color WEIRD = Color.FromArgb(rnd.Next(0, 255), rnd.Next(0, 255), rnd.Next(0, 255));

            SolidBrush pr = new SolidBrush(PRIMARY);
            SolidBrush se = new SolidBrush(SECONDARY);
            SolidBrush hl = new SolidBrush(HIGHLIGHT);
            SolidBrush fe = new SolidBrush(FEET);
            SolidBrush le = new SolidBrush(LEGS);
            SolidBrush fa = new SolidBrush(FACE);
            SolidBrush we = new SolidBrush(WEIRD);

            SolidBrush len = new SolidBrush(normallegs);
            SolidBrush fan = new SolidBrush(normalface);
            SolidBrush wen = new SolidBrush(normallegs);

            Graphics g = Graphics.FromImage(primabitmap);
            Graphics drawing = Graphics.FromImage(drawn);
            int y = primabitmap.Height;
            int x = primabitmap.Width;

            for (int i = 0; i < x; i++)
            {
                for (int o = 0; o < y; o++)
                {
                    Color p = primabitmap.GetPixel(i, o);
                    SolidBrush old = new SolidBrush(p);

                    if (p == baseprimary)
                    {
                        drawing.FillRectangle(pr, i, o, 1, 1);
                    }
                    else if (p == basesecondary)
                    {
                        drawing.FillRectangle(se, i, o, 1, 1);
                    }
                    else if (p == basehighlight)
                    {
                        drawing.FillRectangle(hl, i, o, 1, 1);
                    }
                    else if (p == basefeet)
                    {
                        drawing.FillRectangle(fe, i, o, 1, 1);
                    }
                    else if (p == baselegs)
                    {
                        drawing.FillRectangle(le, i, o, 1, 1);
                    }
                    else if (p == baseface)
                    {
                         drawing.FillRectangle(fan, i, o, 1, 1);
                    }
                    else if (p == baseweird)
                    {
                        drawing.FillRectangle(we, i, o, 1, 1);
                    }
                    else
                    {
                        drawing.FillRectangle(old, i, o, 1, 1);
                    }

                }
            }

            return drawn;
        }

        private void button2_Click(object sender, EventArgs e)
        {
            using (SaveFileDialog dlg = new SaveFileDialog())
            {
                dlg.Title = "Save";
                dlg.Filter = "Png files | .png";

                if (dlg.ShowDialog() == DialogResult.OK)
                {
                    Bitmap b = (Bitmap)pictureBox1.Image;
                    b.Save(dlg.FileName, ImageFormat.Png);

                }
            }
        }

        private void button3_Click(object sender, EventArgs e)
        {
            Form info = new info();
            info.Show();
        }

        private void textBox3_TextChanged(object sender, EventArgs e)
        {

        }

        private void button4_Click(object sender, EventArgs e)
        {
            using (var fbd = new FolderBrowserDialog())
            {
                DialogResult result = fbd.ShowDialog();

                if (result == DialogResult.OK && !string.IsNullOrWhiteSpace(fbd.SelectedPath))
                {
                    batchPath = fbd.SelectedPath;
                }
            }
        }

        public void doPrimaBatch()
        {
            for (int i = 0; i < numericUpDown1.Value + 1; i++)
            {
                Bitmap cur = doPrima("1x1", false, false);
                cur.Save(batchPath + "/" + i + ".png", ImageFormat.Png);
                this.Invoke(new MethodInvoker(delegate ()
                {
                    label3.Text = i + "/" + numericUpDown1.Value;
                    progressBar1.Maximum = (int)numericUpDown1.Value;
                    Console.WriteLine(i + "/" + (int)numericUpDown1.Value);
                    progressBar1.Value = i;
                }));

                Thread.Sleep(25);
            }
        }

        private void button5_Click(object sender, EventArgs e)
        {
            if(batchPath != "")
            {
                numericUpDown1.Enabled = false;
                button4.Enabled = false;
                button5.Enabled = false;
                Thread a = new Thread(() => doPrimaBatch());
                a.IsBackground = true;
                a.Start();
            }
        }
    }
}

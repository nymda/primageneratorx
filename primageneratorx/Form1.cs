using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Drawing.Drawing2D;
using System.Drawing.Imaging;
using System.IO;
using System.Linq;
using System.Net;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using System.Windows.Forms;

//you never commented this. good luck. 

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
        public const string _base = "iVBORw0KGgoAAAANSUhEUgAAAQQAAAExCAMAAACtYSwmAAAABGdBTUEAALGPC/xhBQAAAwBQTFRFAAAAOzJ0TlJdYGVva3B7IrFM+rI8//IAqNrC2eDi8Pf5AAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAsjkizQAAAQB0Uk5T////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////AFP3ByUAAAAJcEhZcwAADsEAAA7BAbiRa+0AAAAZdEVYdFNvZnR3YXJlAHBhaW50Lm5ldCA0LjAuMjHxIGmVAAAKbElEQVR4Xu2d7Y4jRw4Ez2ff2r73f9+96MoUj+ovdUua1tjO+NFgsVhVZAA7O4AX8L9+hp+RAJEAkQCRAJEAkQCRAJEAkQB/FQm/3PD6rUQCRAL8hST8Z/AVHiIBIgG+pwQm7cMSy4DoW28hEiAS4CMSxogTXq9N/euvv1aGwPPf6MWvEwkQCfApCf8eEGgcvpp6tlQMHr6h3bcQCRAJ8FkJYkw5weClYhbz9fANkr7xNSIBIgG+iYQfP35oqEISoGKCXjM0vMdDJEAkwGUS1HnFnv8GGXkoRrkpCcBWHdGSr659mkiASIArJfz222+j8V/++OMPvpqlIDPzIMaJCXkgo3qKdUo1fuYpIgEiAS6TALSKh1KhWTokVz0InSJw9fs8RAJEAnyphNG10VISBEvN0iG54wGmu8bU4DMve4gEiAT4agke+PZzALwesPQYN8jsSxDjpjsVyvjhk0QCRAJcJqGYJVlqCsFyVQL5LapAx/32GSIBIgG+VALQladtTK23PLEMgLbwMFPRa2boCNTSbx8mEiAS4CMSltQIYhrpXsVqgRcL2PLzx4gEiAT4aglASx51lzHWporZllhNCrb8/AEiASIBvo8EQTF4koEy4PWCrS3y7uARkQCRABdIAPrxkPdMs23gSRqrSbFV7+cfEQkQCXCNBKAlT36jOudvQP1a2GFXqAZ6vGR1l6Sf3yUSIBLgMglAS55/0NuefincVSFcPdAR8PoFD5EAkQAXSBjtrzDzAJ7qBrt2MZgVC1V6seaBjPvYJhIgEuAaCdOPgA1WRwPyGlzse3A0WNaQcSsbRAJEAlwgAWjDM6/BLrjjG7MMy4MSYHnWfWwQCfD9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";   
        public Color baseprimary = ColorTranslator.FromHtml("#6b707b");
        public Color basesecondary = ColorTranslator.FromHtml("#d9e0e2");
        public Color basehighlight = ColorTranslator.FromHtml("#fab23c");

        public Color PRIMARY;
        public Color SECONDARY;
        public Color HIGHLIGHT;
        public Color FEET;
        public Color LEGS;
        public Color FACE;
        public Color WEIRD;

        public string batchPath;

        private void button1_Click(object sender, EventArgs e)
        {
            string dim = textBox1.Text + "x" + textBox2.Text;

            if(comboBox1.Text == "Wheel")
            {
                doGraphicShit(null);
            }

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
            if (textBox3.Text == "$rand")
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
            else
            {
                return textBox3.Text;
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

            Size psize = new Size(_width, _height);
            Size mSize = getPrimSize(dim);
            Size newPrimaSize = getPrimSize(dim);
            List<Point> positions = getAllPositions(dim);
            Bitmap BaseBmp = new Bitmap(newPrimaSize.Width, newPrimaSize.Height);
            Graphics gr = Graphics.FromImage(BaseBmp);

            int count = 0;

            foreach (Point p in positions)
            {
                Bitmap prima = GetNewPrima(true);
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
            INIT_COLOUR_WHEEL();
        }

        public Color randcolour()
        {
            Random rnd = new Random();
            Color outlir = Color.FromArgb(getRandom(1, 255), getRandom(1, 255), getRandom(1, 255));
            return outlir;
        }

        static Random rnd = new Random();

        public int getRandom(int min, int max)
        {
            return rnd.Next(min, max);
        }

        public List<Color> getSimilarColours()
        {
            List<Color> lc = new List<Color> { };

            int tol = 70;

            Color outlier = randcolour();
            Color colourone = randcolour();
            Color colourtwo = randcolour();
            Color colourthree = randcolour();
            Color colourfour = randcolour();
            Color colourfive = randcolour();
            Color coloursix = randcolour();

            bool opt0 = AreColorsSimilar(colourone, colourtwo, tol);
            bool opt1 = AreColorsSimilar(colourtwo, colourthree, tol);
            bool opt2 = AreColorsSimilar(colourthree, colourfour, tol);
            bool opt3 = AreColorsSimilar(colourfour, colourfive, tol);
            bool opt4 = AreColorsSimilar(colourfive, coloursix, tol);

            Color averageclr = averagecolor(colourone, colourtwo, colourthree, colourfour, colourfive, coloursix);

            bool optotlr = AreColorsUnSimilar(outlier, averageclr, tol);

            while (!optotlr)
            {
                outlier = randcolour();
                optotlr = AreColorsUnSimilar(outlier, averageclr, 20);
            }

            while (!opt0)
            {
                colourtwo = randcolour();
                opt0 = AreColorsSimilar(colourone, colourtwo, tol);
            }

            while (!opt1)
            {
                colourthree = randcolour();
                opt1 = AreColorsSimilar(colourtwo, colourthree, tol);
            }

            while (!opt2)
            {
                colourfour = randcolour();
                opt2 = AreColorsSimilar(colourthree, colourfour, tol);
            }

            while (!opt3)
            {
                colourfive = randcolour();
                opt3 = AreColorsSimilar(colourfour, colourfive, tol);
            }

            while (!opt4)
            {
                coloursix = randcolour();
                opt4 = AreColorsSimilar(colourfive, coloursix, tol);
            }

            if(opt0 && opt1 && opt2 && opt3 && opt4)
            {
                lc.Add(colourone);
                lc.Add(colourtwo);
                lc.Add(colourthree);
                lc.Add(colourfour);
                lc.Add(colourfive);
                lc.Add(coloursix);
                lc.Add(outlier);
            }

            return lc;
        }

        Color averagecolor(Color c1, Color c2, Color c3, Color c4, Color c5, Color c6)
        {
            int aaverage = ((c1.A + c2.A + c3.A + c4.A + c5.A + c6.A) / 6);
            int raverage = ((c1.R + c2.R + c3.R + c4.R + c5.R + c6.R) / 6);
            int gaverage = ((c1.G + c2.G + c3.G + c4.G + c5.G + c6.G) / 6);
            int baverage = ((c1.B + c2.B + c3.B + c4.B + c5.B + c6.B) / 6);
            Color average = Color.FromArgb(aaverage, raverage, gaverage, baverage);
            return average;

        }

        bool AreColorsSimilar(Color c1, Color c2, int tolerance)
        {
            return Math.Abs(c1.R - c2.R) < tolerance &&
                   Math.Abs(c1.G - c2.G) < tolerance &&
                   Math.Abs(c1.B - c2.B) < tolerance;
        }

        bool AreColorsUnSimilar(Color c1, Color c2, int tolerance)
        {
            return Math.Abs(c1.R - c2.R) > tolerance &&
                   Math.Abs(c1.G - c2.G) > tolerance &&
                   Math.Abs(c1.B - c2.B) > tolerance;
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

        public Bitmap GetNewPrima(bool doWheelGen)
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

            this.Invoke(new MethodInvoker(delegate ()
            {
                if (comboBox1.Text == "RandNice")
                {
                    List<Color> lc = getSimilarColours();
                    PRIMARY = lc[1];
                    SECONDARY = lc[2];
                    HIGHLIGHT = lc[3];
                    FEET = lc[2];
                    LEGS = lc[4];
                    FACE = lc[6];
                    WEIRD = lc[0];
                }
                else if (comboBox1.Text == "Random")
                {
                    PRIMARY = randcolour();
                    SECONDARY = randcolour();
                    HIGHLIGHT = randcolour();
                    FEET = randcolour();
                    LEGS = randcolour();
                    FACE = randcolour();
                    WEIRD = randcolour();
                }
                else if (comboBox1.Text == "Wheel" && doWheelGen == true)
                {

                }
                else if (comboBox1.Text == "Wheel" && doWheelGen == false)
                {

                }
            }));

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
                cur.Save(batchPath + "/prim" + i + ".png", ImageFormat.Png);
                this.Invoke(new MethodInvoker(delegate ()
                {
                    label3.Text = i + "/" + numericUpDown1.Value;
                    progressBar1.Maximum = (int)numericUpDown1.Value;
                    //Console.WriteLine(i + "/" + (int)numericUpDown1.Value);
                    progressBar1.Value = i;
                }));

                Thread.Sleep(10);
            }
        }

        private void button5_Click(object sender, EventArgs e)
        {
            if(batchPath != "")
            {
                numericUpDown1.Enabled = false;
                button4.Enabled = false;
                button5.Enabled = false;
                checkBox1.Checked = false;
                checkBox1.Enabled = false;

                Thread a = new Thread(() => doPrimaBatch());
                a.IsBackground = true;
                a.Start();
            }
        }

        private void button6_Click(object sender, EventArgs e)
        {
            textBox3.Text = "$rand";
        }

        private void checkBox2_CheckedChanged(object sender, EventArgs e)
        {
            button6.Enabled = !button6.Enabled;
            textBox3.Enabled = !textBox3.Enabled;
        }

        //NEW COLOUR WHEEL BULLSHIT HERE \/\/\/\/

        public Bitmap b = new Bitmap(310, 310);
        public Bitmap back = new Bitmap(310, 310);
        public bool size = true;

        private void INIT_COLOUR_WHEEL()
        {
            Graphics g = Graphics.FromImage(b);
            Graphics o = Graphics.FromImage(back);
            DrawColorWheel(g, Color.Black, 0, 0, 309, 309);
            DrawColorWheel(o, Color.Black, 0, 0, 309, 309);
            pictureBox2.Image = b;
            doGraphicShit(null);
        }

        //csharphelper.com
        private void DrawColorWheel(Graphics gr, Color outline_color, int xmin, int ymin, int wid, int hgt)
        {
            Rectangle rect = new Rectangle(xmin, ymin, wid, hgt);
            GraphicsPath wheel_path = new GraphicsPath();
            wheel_path.AddEllipse(rect);
            wheel_path.Flatten();

            float num_pts = (wheel_path.PointCount - 1) / 6;
            Color[] surround_colors = new Color[wheel_path.PointCount];

            int index = 0;
            InterpolateColors(surround_colors, ref index, 1 * num_pts, 255, 255, 0, 0, 255, 255, 0, 255);
            InterpolateColors(surround_colors, ref index, 2 * num_pts, 255, 255, 0, 255, 255, 0, 0, 255);
            InterpolateColors(surround_colors, ref index, 3 * num_pts, 255, 0, 0, 255, 255, 0, 255, 255);
            InterpolateColors(surround_colors, ref index, 4 * num_pts, 255, 0, 255, 255, 255, 0, 255, 0);
            InterpolateColors(surround_colors, ref index, 5 * num_pts, 255, 0, 255, 0, 255, 255, 255, 0);
            InterpolateColors(surround_colors, ref index, wheel_path.PointCount, 255, 255, 255, 0, 255, 255, 0, 0);

            using (PathGradientBrush path_brush = new PathGradientBrush(wheel_path))
            {
                path_brush.CenterColor = Color.White;
                path_brush.SurroundColors = surround_colors;

                gr.FillPath(path_brush, wheel_path);

                using (Pen thick_pen = new Pen(outline_color, 2))
                {
                    gr.DrawPath(thick_pen, wheel_path);
                }
            }
        }

        //csharphelper.com
        private void InterpolateColors(Color[] surround_colors, ref int index, float stop_pt, int from_a, int from_r, int from_g, int from_b, int to_a, int to_r, int to_g, int to_b)
        {
            int num_pts = (int)stop_pt - index;
            float a = from_a, r = from_r, g = from_g, b = from_b;
            float da = (to_a - from_a) / (num_pts - 1);
            float dr = (to_r - from_r) / (num_pts - 1);
            float dg = (to_g - from_g) / (num_pts - 1);
            float db = (to_b - from_b) / (num_pts - 1);

            for (int i = 0; i < num_pts; i++)
            {
                surround_colors[index++] = Color.FromArgb((int)a, (int)r, (int)g, (int)b);
                a += da;
                r += dr;
                g += dg;
                b += db;
            }
        }

        private void doGraphicShit(MouseEventArgs mev)
        {
            int baseSize = trackBar1.Value * 10;

            Random rnd = new Random();

            Point e = new Point();
            if (mev != null)
            {
                e.X = mev.X;
                e.Y = mev.Y;

                //buffer around selectable area
                if(e.X > 302)
                {
                    e.X = 302;
                }

                if(e.Y > 302)
                {
                    e.Y = 302;
                }

                if (e.X < 8)
                {
                    e.X = 8;
                }

                if (e.Y < 8)
                {
                    e.Y = 8;
                }

                Console.WriteLine(e.X + " " + e.Y);
            }
            else
            {
                e = new Point(rnd.Next(30, 280), rnd.Next(30, 280));
            }

            Graphics g = Graphics.FromImage(b);
            g.FillRectangle(Brushes.White, 0, 0, 310, 310);
            g.DrawImage(back, 0, 0);
            Point p = new Point(e.X, e.Y);
            Point o = new Point(150 - (e.X - 150), 150 - (e.Y - 150));
            Color colorOp;
            if (p.X > 0 && p.Y > 0)
            {
                colorOp = b.GetPixel(p.X, p.Y);
            }
            else
            {
                colorOp = Color.Black;
            }

            g.DrawRectangle(Pens.Black, p.X, p.Y, 1, 1);
            g.DrawRectangle(Pens.Black, o.X, o.Y, 1, 1);
            pictureBox2.Image = b;
            label7.BackColor = colorOp;

            List<Color> pixels = new List<Color> { };

            for (int i = p.X - baseSize / 2; i < p.X + baseSize / 2; i++)
            {
                for (int f = p.Y - baseSize / 2; f < p.Y + baseSize / 2; f++)
                {
                    if ((i > 0 && f > 0) && (i < 310 && f < 310))
                    {
                        Color cur = b.GetPixel(i, f);
                        pixels.Add(cur);
                    }
                    else
                    {
                        pixels.Add(Color.Black);
                    }
                }
            }

            Bitmap redraw = new Bitmap(baseSize, baseSize);
            Graphics gr = Graphics.FromImage(redraw);

            int count = 0;
            for (int i = 0; i < baseSize; i++)
            {
                for (int f = 0; f < baseSize; f++)
                {
                    count++;
                    Color cur;
                    try
                    {
                        cur = pixels[count];
                    }
                    catch
                    {
                        cur = Color.Black;
                    }

                    gr.DrawRectangle(new Pen(cur), i, f, 1, 1);

                }
            }

            for (int i = 0; i < pixels.Count(); i++)
            {
                if ((pixels[i].R + " " + pixels[i].B + " " + pixels[i].G) == "0 0 0")
                {
                    pixels.RemoveAt(i);
                }

            }

            Color c1 = pixels[rnd.Next(0, pixels.Count())];
            Color c2 = pixels[rnd.Next(0, pixels.Count())];
            Color c3 = pixels[rnd.Next(0, pixels.Count())];

            c1 = brightnessAdjust(c1);
            c2 = brightnessAdjust(c2);
            c3 = brightnessAdjust(c3);

            label8.BackColor = c1;
            label4.BackColor = c2;
            label5.BackColor = c3;

            Color color;

            color = b.GetPixel(o.X + 5, o.Y + 5);
            if (color == Color.Black)
            {
                color = b.GetPixel(o.X - 5, o.Y - 5);
            }

            color = brightnessAdjust(color);

            label9.BackColor = color;

            PRIMARY = c1;
            SECONDARY = c3;
            HIGHLIGHT = color;
            FEET = c3;
            LEGS = c2;
            FACE = color;
            WEIRD = c2;

            gr.DrawRectangle(Pens.Black, 0, 0, baseSize - 1, baseSize - 1);
            pictureBox3.Image = redraw;
        }

        private Color brightnessAdjust(Color c)
        {
            Random rnd = new Random();
            Color modif = c;
            int modR = modif.R;
            int modG = modif.G;
            int modB = modif.B;

            int Rdif = 255 - modR;
            int Gdif = 255 - modB;
            int Bdif = 255 - modG;

            bool swit = (bool)(rnd.NextDouble() < 50 / 100);

            if (swit)
            {
                int RRand = rnd.Next(0, Rdif);
                int GRand = rnd.Next(0, Gdif);
                int BRand = rnd.Next(0, Bdif);

                modif = Color.FromArgb(c.A, c.R + RRand / 2, c.G + GRand / 2, c.B + BRand / 2);
            }
            else
            {
                int RRand = rnd.Next(0, modR);
                int GRand = rnd.Next(0, modG);
                int BRand = rnd.Next(0, modB);

                modif = Color.FromArgb(c.A, c.R - RRand / 2, c.G - GRand / 2, c.B - BRand / 2);
            }

            return modif;
        }

        private void getCircle(Graphics drawingArea, Pen penToUse, Point center, int radius)
        {
            Rectangle rect = new Rectangle(center.X - radius, center.Y - radius, radius * 2, radius * 2);
            Point rectP = new Point(rect.X, rect.Y);
            drawingArea.DrawRectangle(penToUse, rect);
        }

        private void trackBar1_Scroll(object sender, EventArgs e)
        {
            label6.Text = (trackBar1.Value * 10).ToString();
        }


        private void button7_Click(object sender, EventArgs e)
        {
            doGraphicShit(null);

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

        private void pictureBox2_MouseUp(object sender, MouseEventArgs e)
        {
            doGraphicShit(e);

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

        private void pictureBox2_Click(object sender, EventArgs e)
        {
            
        }

        private void trackBar1_Scroll_1(object sender, EventArgs e)
        {
            label6.Text = (trackBar1.Value * 10).ToString();
        }

        private void comboBox1_SelectedIndexChanged(object sender, EventArgs e)
        {
            Size NoWheel = new Size(643, 696);
            Size YesWheel = new Size(1078, 696);

            if(comboBox1.Text == "Wheel")
            {
                this.Size = YesWheel;
            }
            else
            {
                this.Size = NoWheel;
            }
        }
    }
}


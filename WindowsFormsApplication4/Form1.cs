using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using System.Collections;

namespace WindowsFormsApplication4
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        } 
   
        public class t
        {
            public double x;
            public double y;
            public double res;
            public t(double xx, double yy, double r) 
            {
                x = xx;
                y = yy;
                res = r;
            }
        };

        public double fun(double x1, double x2)
        {
            return (0.5 * Math.Pow(x1, 2) + 0.5 * Math.Pow(x2, 2) - x1 - 2 * x2 + 5);
        }

        static public int MyClassCompareDate(t mf1, t mf2)
        {
            return mf1.y.CompareTo(mf2.y);
        }
        public int prov(double x1, double x2)
        {
            if (((2 * x1 + 3 * x2) >= 8) &&((x1 + 4 * x2) >= 5) &&(x1  >= 0) &&(x2  >= 0)) return 1;
            return 0;
        }
        public int prov1(double x1, double x2)
        {
            if (((2 * x1 + 3 * x2) > 8) && ((x1 + 4 * x2) >= 5) && (x1 >= 0) && (x2 >= 0)) return 1;
            return 0;
        }
        private void button1_Click(object sender, EventArgs e)
        {
            try
            {
                double x1min = System.Convert.ToDouble(textBox1.Text);
                double x1max = System.Convert.ToDouble(textBox2.Text);
                double x2min = System.Convert.ToDouble(textBox3.Text);
                double x2max = System.Convert.ToDouble(textBox4.Text);
               
                int n1 = 0;
                int n2 = 0;
                this.dataGridView1.Rows.Clear();  
                int count = this.dataGridView1.Columns.Count;
                for (int i = 0; i < count; i++)   
                { this.dataGridView1.Columns.RemoveAt(0); }            
      
                for (int i = 0; x1min + 0.5 * i <= x1max; i++)
                {
                    n1++;
                    dataGridView1.Columns.Add("Column"+System.Convert.ToString(i),System.Convert.ToString(x1min+0.5*i));    
                }
                for (int i = 0; i < n1; i++)
                    dataGridView1.Columns[i].Width = (int)(dataGridView1.Width / (n1 + 1));

                for (int i = 0; x2min + 0.5 * i <= x2max; i++)
                {
                    n2++;
                    dataGridView1.Rows.Add();
                    dataGridView1.Rows[i].HeaderCell.Value = System.Convert.ToString(x2min + 0.5 * i);
                }
                  double min = 10000;
                  double max = -10000;
                  for (int i = 0; i < n1; i++)
                  {
                      for (int j = 0; j < n2; j++)
                      {
                              dataGridView1[i, j].Value = System.Convert.ToString(fun(x1min + 0.5 * i, x2min + 0.5 * j));
                          if (prov(x1min + 0.5 * i, x2min + 0.5 * j) == 1)
                          {
                              if (min > System.Convert.ToDouble(dataGridView1[i, j].Value)) 
                                  min = System.Convert.ToDouble(dataGridView1[i, j].Value);
                              if (max < System.Convert.ToDouble(dataGridView1[i, j].Value)) 
                                  max = System.Convert.ToDouble(dataGridView1[i, j].Value);
                              dataGridView1.Rows[j].Cells[i].Style.BackColor = System.Drawing.Color.Aqua;
                          }
                      }
                  }
                  label6.Text = System.Convert.ToString(min);
                  Graphics g = pictureBox1.CreateGraphics();
                  g.Clear(Color.White);
                  g.DrawLine(new Pen(Brushes.Black, 1), new Point(0, 0), new Point(0, 300));
                  g.DrawLine(new Pen(Brushes.Black, 1), new Point(0, 0), new Point(300, 0));
                  g.DrawLine(new Pen(Brushes.Black, 1), new Point(300-1, 0), new Point(300-1, 300-1));
                  g.DrawLine(new Pen(Brushes.Black, 1), new Point(0, 300-1), new Point(300-1, 300-1));
                  double delta = 0.02;
               
                int kol_kolez=15;
                double kol = (max - min) / kol_kolez;
               
                double elem;
                t w; 
                 List<t> parts; 
                for (int z = 0; z < kol_kolez; z++)
                {
                     parts = new List<t>();
                    for (double i = x1min; i < x1max; i+=0.01)
                    {
                    for (double j = x2min; j < x2max; j += 0.01)
                    {
                        elem = fun(i, j);

                        if (prov(i,j) == 1)
                        if (1 == 1)
                        {
                            if ((elem < (kol*z + min + delta)) && (elem > (kol*z + min - delta)))
                            {
                                 w = new t((double)(i), (double)(j), (double)elem);
                                parts.Add(w);
                            }
                        }                     
                    }
                }
                parts.Sort(MyClassCompareDate);
                double ww = 250/(max - min);

                    for (int i = 0; i < parts.Count; i++)
                    {
                        g.DrawLine(new Pen(Brushes.Blue, 1), new Point((int)((parts[i].x+1) * 60), (int)((parts[i].y+1) * 60)), new Point((int)((parts[i].x+1) * 60+1), (int)((parts[i].y+1) *60 +1)));
                    }
                }
           } catch (Exception ee) { MessageBox.Show(ee.Message); }
        }

        private void button2_Click(object sender, EventArgs e)
        {
            try
            {
                double x1min = System.Convert.ToDouble(textBox1.Text);
                double x1max = System.Convert.ToDouble(textBox2.Text);
                double x2min = System.Convert.ToDouble(textBox3.Text);
                double x2max = System.Convert.ToDouble(textBox4.Text);

                int n1 = 0;
                int n2 = 0;
                this.dataGridView1.Rows.Clear();
                int count = this.dataGridView1.Columns.Count;
                for (int i = 0; i < count; i++)
                { this.dataGridView1.Columns.RemoveAt(0); }

                for (int i = 0; x1min + 0.5 * i <= x1max; i++)
                {
                    n1++;
                    dataGridView1.Columns.Add("Column" + System.Convert.ToString(i), System.Convert.ToString(x1min + 0.5 * i));
                }
                for (int i = 0; i < n1; i++)
                    dataGridView1.Columns[i].Width = (int)(dataGridView1.Width / (n1 + 1));

                for (int i = 0; x2min + 0.5 * i <= x2max; i++)
                {
                    n2++;
                    dataGridView1.Rows.Add();
                    dataGridView1.Rows[i].HeaderCell.Value = System.Convert.ToString(x2min + 0.5 * i);
                }

                double min = 10000;
                double max = -10000;
                for (int i = 0; i < n1; i++)
                {
                    for (int j = 0; j < n2; j++)
                    {
                        dataGridView1[i, j].Value = System.Convert.ToString(fun(x1min + 0.5 * i, x2min + 0.5 * j));
                        if (prov1(x1min + 0.5 * i, x2min + 0.5 * j) == 1)
                        {
                            if (min > System.Convert.ToDouble(dataGridView1[i, j].Value)) min = System.Convert.ToDouble(dataGridView1[i, j].Value);
                            if (max < System.Convert.ToDouble(dataGridView1[i, j].Value)) max = System.Convert.ToDouble(dataGridView1[i, j].Value);
                            dataGridView1.Rows[j].Cells[i].Style.BackColor = System.Drawing.Color.Aqua;
                        }
                    }
                }
                label6.Text = System.Convert.ToString(min);
                Graphics g = pictureBox1.CreateGraphics();
                g.Clear(Color.White);
                g.DrawLine(new Pen(Brushes.Black, 1), new Point(0, 0), new Point(0, 300));
                g.DrawLine(new Pen(Brushes.Black, 1), new Point(0, 0), new Point(300, 0));
                g.DrawLine(new Pen(Brushes.Black, 1), new Point(300 - 1, 0), new Point(300 - 1, 300 - 1));
                g.DrawLine(new Pen(Brushes.Black, 1), new Point(0, 300 - 1), new Point(300 - 1, 300 - 1));
                double delta = 0.02;

                int kol_kolez = 15;
                double kol = (max - min) / kol_kolez;

                double elem;
                t w;
                List<t> parts;
                for (int z = 0; z < kol_kolez; z++)
                {
                    parts = new List<t>();
                    for (double i = x1min; i < x1max; i += 0.01)
                    {
                        for (double j = x2min; j < x2max; j += 0.01)
                        {
                            elem = fun(i, j);

                            if (prov1(i, j) == 1)
                                if (1 == 1)
                                {
                                    if ((elem < (kol * z + min + delta)) && (elem > (kol * z + min - delta)))
                                    {
                                        w = new t((double)(i), (double)(j), (double)elem);
                                        parts.Add(w);
                                    }
                                }
                        }
                    }
                    parts.Sort(MyClassCompareDate);
                    double ww = 250 / (max - min);

                    for (int i = 0; i < parts.Count; i++)
                    {
                        g.DrawLine(new Pen(Brushes.Blue, 1), new Point((int)((parts[i].x + 1) * 60), (int)((parts[i].y + 1) * 60)), new Point((int)((parts[i].x + 1) * 60 + 1), (int)((parts[i].y + 1) * 60 + 1)));
                    }
                }
            }
            catch (Exception ee) { MessageBox.Show(ee.Message); }
        }

        private void button3_Click(object sender, EventArgs e)
        {
            double x1min = System.Convert.ToDouble(textBox1.Text);
            double x1max = System.Convert.ToDouble(textBox2.Text);
            double x2min = System.Convert.ToDouble(textBox3.Text);
            double x2max = System.Convert.ToDouble(textBox4.Text);

            // прорисовка линий уровня
            try
            {               
                int n1 = 0;
                int n2 = 0;
                this.dataGridView1.Rows.Clear();
                int count = this.dataGridView1.Columns.Count;
                for (int i = 0; i < count; i++)
                { this.dataGridView1.Columns.RemoveAt(0); }

                for (int i = 0; x1min + 0.5 * i <= x1max; i++)
                {
                    n1++;
                    dataGridView1.Columns.Add("Column" + System.Convert.ToString(i), System.Convert.ToString(x1min + 0.5 * i));
                }
                for (int i = 0; i < n1; i++)
                    dataGridView1.Columns[i].Width = (int)(dataGridView1.Width / (n1 + 1));

                for (int i = 0; x2min + 0.5 * i <= x2max; i++)
                {
                    n2++;
                    dataGridView1.Rows.Add();
                    dataGridView1.Rows[i].HeaderCell.Value = System.Convert.ToString(x2min + 0.5 * i);
                }

                double min_value = 10000;
                double max_value = -10000;
                for (int i = 0; i < n1; i++)
                {
                    for (int j = 0; j < n2; j++)
                    {
                        dataGridView1[i, j].Value = System.Convert.ToString(fun(x1min + 0.5 * i, x2min + 0.5 * j));
                        if (prov1(x1min + 0.5 * i, x2min + 0.5 * j) == 1)
                        {
                            if (min_value > System.Convert.ToDouble(dataGridView1[i, j].Value)) min_value = System.Convert.ToDouble(dataGridView1[i, j].Value);
                            if (max_value < System.Convert.ToDouble(dataGridView1[i, j].Value)) max_value = System.Convert.ToDouble(dataGridView1[i, j].Value);
                            dataGridView1.Rows[j].Cells[i].Style.BackColor = System.Drawing.Color.Aqua;
                        }
                    }
                }
                label6.Text = System.Convert.ToString(min_value);
                Graphics gr = pictureBox3.CreateGraphics();
                gr.Clear(Color.White);
                gr.DrawLine(new Pen(Brushes.Black, 1), new Point(0, 0), new Point(0, 300));
                gr.DrawLine(new Pen(Brushes.Black, 1), new Point(0, 0), new Point(300, 0));
                gr.DrawLine(new Pen(Brushes.Black, 1), new Point(300 - 1, 0), new Point(300 - 1, 300 - 1));
                gr.DrawLine(new Pen(Brushes.Black, 1), new Point(0, 300 - 1), new Point(300 - 1, 300 - 1));
                double delta = 0.02;

                int kol_kolez = 15;
                double kol = (max_value - min_value) / kol_kolez;

                double elem;
                t w;
                List<t> parts;
                for (int z = 0; z < kol_kolez; z++)
                {
                    parts = new List<t>();
                    for (double i = x1min; i < x1max; i += 0.01)
                    {
                        for (double j = x2min; j < x2max; j += 0.01)
                        {
                            elem = fun(i, j);

                            if (prov1(i, j) == 1)
                                if (1 == 1)
                                {
                                    if ((elem < (kol * z + min_value + delta)) && (elem > (kol * z + min_value - delta)))
                                    {
                                        w = new t((double)(i), (double)(j), (double)elem);
                                        parts.Add(w);
                                    }
                                }
                        }
                    }
                    parts.Sort(MyClassCompareDate);
                    double ww = 250 / (max_value - min_value);

                    for (int i = 0; i < parts.Count; i++)
                    {
                        gr.DrawLine(new Pen(Brushes.Blue, 1), new Point((int)((parts[i].x + 1) * 60), (int)((parts[i].y + 1) * 60)), new Point((int)((parts[i].x + 1) * 60 + 1), (int)((parts[i].y + 1) * 60 + 1)));
                    }
                }
            }
            catch (Exception ee) { MessageBox.Show(ee.Message); }

            // итерации
            this.dataGridView2.Rows.Clear();  
            dataGridView2.Columns.Add("Column" + System.Convert.ToString(1), "x1");
            dataGridView2.Columns.Add("Column" + System.Convert.ToString(2), "x2");
            dataGridView2.Columns.Add("Column" + System.Convert.ToString(3), "z");
            dataGridView2.Columns[0].Width = (int)(dataGridView2.Width / (4));
            dataGridView2.Columns[1].Width = (int)(dataGridView2.Width / (4));
            dataGridView2.Columns[2].Width = (int)(dataGridView2.Width / (4));
            dataGridView2.RowHeadersWidth = 50;
            int n=System.Convert.ToInt32(textBox5.Text);
            
            double x1, x2, f;
            double min = 10000;
            double minx1 = 0.0, minx2 = 0.0;
            Random rm = new Random();

            for (int i = 0; i < n; i++)
            {
                dataGridView2.Rows.Add();
                dataGridView2.Rows[i].HeaderCell.Value = System.Convert.ToString(i);
                
                x1=rm.NextDouble()*(Math.Abs(x1max)+Math.Abs(x1min))+x1min;
                x2=rm.NextDouble()*(Math.Abs(x2max)+Math.Abs(x2min))+x2min;
                f = fun(x1, x2);
                
                if ((prov1(x1, x2) == 1)&& (f < min))
                {
                    min = f;
                    minx1 = x1;
                    minx2 = x2;
                }
                dataGridView2[0, i].Value =System.Convert.ToString(x1);
                dataGridView2[1, i].Value =System.Convert.ToString(x2);
                dataGridView2[2, i].Value = System.Convert.ToString(f);
            }

            MessageBox.Show("x1= " + System.Convert.ToString(minx1) + "\r\nx2= " + System.Convert.ToString(minx2) + "\r\nmin= " + System.Convert.ToString(min));
        }
        public bool provx(double x1, double x2) {
            if ((System.Convert.ToDouble(textBox1.Text) <= x1) && (System.Convert.ToDouble(textBox2.Text) >= x1))
            {
                if ((System.Convert.ToDouble(textBox3.Text) <= x2) && (System.Convert.ToDouble(textBox4.Text) >= x2))
                {
                    if (prov1(x1, x2) == 1)return true;
                }
            }
            return false;
        }

        private void button4_Click_1(object sender, EventArgs e)
        {
            // прорисовка линий уровня
            try
            {
                double x1min = System.Convert.ToDouble(textBox1.Text);
                double x1max = System.Convert.ToDouble(textBox2.Text);
                double x2min = System.Convert.ToDouble(textBox3.Text);
                double x2max = System.Convert.ToDouble(textBox4.Text);

                int n1 = 0;
                int n2 = 0;
                this.dataGridView1.Rows.Clear();
                int count = this.dataGridView1.Columns.Count;
                for (int i = 0; i < count; i++)
                { this.dataGridView1.Columns.RemoveAt(0); }

                for (int i = 0; x1min + 0.5 * i <= x1max; i++)
                {
                    n1++;
                    dataGridView1.Columns.Add("Column" + System.Convert.ToString(i), System.Convert.ToString(x1min + 0.5 * i));
                }
                for (int i = 0; i < n1; i++)
                    dataGridView1.Columns[i].Width = (int)(dataGridView1.Width / (n1 + 1));

                for (int i = 0; x2min + 0.5 * i <= x2max; i++)
                {
                    n2++;
                    dataGridView1.Rows.Add();
                    dataGridView1.Rows[i].HeaderCell.Value = System.Convert.ToString(x2min + 0.5 * i);
                }

                double min_value = 10000;
                double max_value = -10000;
                for (int i = 0; i < n1; i++)
                {
                    for (int j = 0; j < n2; j++)
                    {
                        dataGridView1[i, j].Value = System.Convert.ToString(fun(x1min + 0.5 * i, x2min + 0.5 * j));
                        if (prov1(x1min + 0.5 * i, x2min + 0.5 * j) == 1)
                        {
                            if (min_value > System.Convert.ToDouble(dataGridView1[i, j].Value)) min_value = System.Convert.ToDouble(dataGridView1[i, j].Value);
                            if (max_value < System.Convert.ToDouble(dataGridView1[i, j].Value)) max_value = System.Convert.ToDouble(dataGridView1[i, j].Value);
                            dataGridView1.Rows[j].Cells[i].Style.BackColor = System.Drawing.Color.Aqua;
                        }
                    }
                }
                label6.Text = System.Convert.ToString(min_value);
                Graphics gr = pictureBox2.CreateGraphics();
                gr.Clear(Color.White);
                gr.DrawLine(new Pen(Brushes.Black, 1), new Point(0, 0), new Point(0, 300));
                gr.DrawLine(new Pen(Brushes.Black, 1), new Point(0, 0), new Point(300, 0));
                gr.DrawLine(new Pen(Brushes.Black, 1), new Point(300 - 1, 0), new Point(300 - 1, 300 - 1));
                gr.DrawLine(new Pen(Brushes.Black, 1), new Point(0, 300 - 1), new Point(300 - 1, 300 - 1));
                double delta = 0.02;

                int kol_kolez = 15;
                double kol = (max_value - min_value) / kol_kolez;

                double elem;
                t w;
                List<t> parts;
                for (int z = 0; z < kol_kolez; z++)
                {
                    parts = new List<t>();
                    for (double i = x1min; i < x1max; i += 0.01)
                    {
                        for (double j = x2min; j < x2max; j += 0.01)
                        {
                            elem = fun(i, j);

                            if (prov1(i, j) == 1)
                                if (1 == 1)
                                {
                                    if ((elem < (kol * z + min_value + delta)) && (elem > (kol * z + min_value - delta)))
                                    {
                                        w = new t((double)(i), (double)(j), (double)elem);
                                        parts.Add(w);
                                    }
                                }
                        }
                    }
                    parts.Sort(MyClassCompareDate);
                    double ww = 250 / (max_value - min_value);

                    for (int i = 0; i < parts.Count; i++)
                    {
                        gr.DrawLine(new Pen(Brushes.Blue, 1), new Point((int)((parts[i].x + 1) * 60), (int)((parts[i].y + 1) * 60)), new Point((int)((parts[i].x + 1) * 60 + 1), (int)((parts[i].y + 1) * 60 + 1)));
                    }
                }
            }
            catch (Exception ee) { MessageBox.Show(ee.Message); }

            // прорисовка маршрута
            double x1 = System.Convert.ToDouble(textBox6.Text);
            double x2 = System.Convert.ToDouble(textBox7.Text);
            double h = System.Convert.ToDouble(textBox8.Text);
            double epsilon = System.Convert.ToDouble(textBox9.Text);
            double min = fun(x1, x2);
            bool r1, r2, r3, r4;
            double f1, f2, f3, f4;
            Graphics g = pictureBox2.CreateGraphics();

            if (prov1(x1, x2) == 1)
            {
                while (h > epsilon)
                {
                    r1 = provx(x1 - h, x2);
                    r2 = provx(x1 + h, x2);
                    r3 = provx(x1, x2 - h);
                    r4 = provx(x1, x2 + h);
                    if (r1)
                    {
                        f1 = fun(x1 - h, x2);
                        if (min > f1)
                        {
                            g.DrawLine(new Pen(Brushes.Green, 1), new Point((int)((x1 + 1) * 60), (int)((x2 + 1) * 60)), new Point((int)(((x1 + 1) - h) * 60), (int)((x2 + 1) * 60)));
                            min = f1; x1 = x1 - h;
                            MessageBox.Show(System.Convert.ToString("x1= " + System.Convert.ToString(x1) + "\r\nx2= " + System.Convert.ToString(x2) + "\r\nmin= " + System.Convert.ToString(min))); continue;
                        }
                    }

                    if (r2)
                    {
                        f2 = fun(x1 + h, x2);
                        if (min > f2)
                        {
                            g.DrawLine(new Pen(Brushes.Green, 1), new Point((int)((x1 + 1) * 60), (int)((x2 + 1) * 60)), new Point((int)(((x1 + 1) + h) * 60), (int)((x2 + 1) * 60)));
                            min = f2; x1 = x1 + h; MessageBox.Show(System.Convert.ToString("x1= " + System.Convert.ToString(x1) + "\r\nx2= " + System.Convert.ToString(x2) + "\r\nmin= " + System.Convert.ToString(min)));
                            continue;
                        }
                    }

                    if (r3)
                    {
                        f3 = fun(x1, x2 - h);
                        if (min > f3)
                        {
                            g.DrawLine(new Pen(Brushes.Green, 1), new Point((int)((x1 + 1) * 60), (int)((x2 + 1) * 60)), new Point((int)((x1 + 1) * 60), (int)(((x2 + 1) - h) * 60)));
                            min = f3; x2 = x2 - h; MessageBox.Show(System.Convert.ToString("x1= " + System.Convert.ToString(x1) + "\r\nx2= " + System.Convert.ToString(x2) + "\r\nmin= " + System.Convert.ToString(min)));
                            continue;
                        }
                    }
                    if (r4)
                    {
                        f4 = fun(x1, x2 + h);
                        if (min > f4)
                        {
                            g.DrawLine(new Pen(Brushes.Green, 1), new Point((int)((x1 + 1) * 60), (int)((x2 + 1) * 60)), new Point((int)((x1 + 1) * 60), (int)(((x2 + 1) + h) * 60)));
                            min = f4; x2 = x2 + h; MessageBox.Show(System.Convert.ToString("x1= " + System.Convert.ToString(x1) + "\r\nx2= " + System.Convert.ToString(x2) + "\r\nmin= " + System.Convert.ToString(min)));
                            continue;
                        }
                        else { h /= 10; }
                    }
                    else { h /= 10; }
                }
            }
            else { MessageBox.Show("Точка вне ограничейний"); }
        }

        private void button5_Click(object sender, EventArgs e)
        {
            shtraf();
        }
                
        public void shtraf()
        {
            dataGridView3.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.Fill;
            dataGridView3.Columns.Add("Column" + System.Convert.ToString(1), "x1");
            dataGridView3.Columns.Add("Column" + System.Convert.ToString(2), "x2");
            dataGridView3.Columns.Add("Column" + System.Convert.ToString(3), "z");
            double x1 = System.Convert.ToDouble(textBox23.Text); 
            double x2 = System.Convert.ToDouble(textBox22.Text);
            double h = System.Convert.ToDouble(textBox21.Text);
            double e = System.Convert.ToDouble(textBox20.Text);
            StrafnieFunkcii asd = new StrafnieFunkcii();
            List<ExtremumCoordinates> ex = new List<ExtremumCoordinates>();
            ex = asd.extremumFunction(x1, x2, h, e);

            for (int i = 0; i < ex.Count; i++)
            {
                dataGridView3.Rows.Add();
                dataGridView3.Rows[i].HeaderCell.Value = System.Convert.ToString(i);
                dataGridView3[0, i].Value = System.Convert.ToString(ex[i].getX1().ToString("F5"));
                dataGridView3[1, i].Value = System.Convert.ToString(ex[i].getX2().ToString("F5"));
                dataGridView3[2, i].Value = System.Convert.ToString(ex[i].getExtremum().ToString("F5"));
            }
            lines();
        }

        public void lines()
        {
            int size = pictureBox1.Width;
            int x1 = -1; // -1
            int x2 = 4; // 6
            int razm = Convert.ToInt32(x2 - x1);
            for (double i = 0; i < razm; i += 0.5)
            {
                double X0 = (razm - x2) * (size / razm);
                double Y0 = (razm - x2) * (size / razm);
                int z = Convert.ToInt32(fun(i, i) * (pictureBox1.Width / razm));

                pictureBox4.CreateGraphics().DrawEllipse(new Pen(Color.Blue, 2), Convert.ToInt32(X0 - z / 2), Convert.ToInt32(Y0 - z / 2), z, z);
            }
        }
    }
}

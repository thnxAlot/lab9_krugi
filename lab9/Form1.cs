using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Threading.Tasks;
using System.Threading;
using System.Diagnostics;

namespace lab9
{

    public partial class Form1 : Form
    {
         static Graphics graphics;

        List<System.Threading.Timer> timers;

        static List<int> die = new List<int>();

        Random rand = new Random();

        public Form1()

        {

            InitializeComponent();
            button1.Click += Button1_Click;
            button2.Click += button2_Click;
            graphics = pictureBox1.CreateGraphics();

        }

        int id=0;

        private void button2_Click(object sender, EventArgs e)

        {

            ((Button)sender).Enabled = false;

            graphics.Clear(Color.White);

            timers = new List<System.Threading.Timer>();

            for (int i = 0; i < max_circles; i++)
            {
                
                cirs.Add(new Vector4(rand.Next(0, 500),
                rand.Next(0, 300),
                rand.Next(40, 100),
                rand.Next(0, 255)));
                die.Add(0);
                timeFrom.Add(0);
                timers.Add(new System.Threading.Timer(
                new TimerCallback(drawCircle), new Vector3(0,0,id), 0, 100));
                id++;

            }

            timy = new System.Threading.Timer(
                    new TimerCallback(drawCircles), null, 0, 57);
        }
        System.Threading.Timer timy;

        private void Button1_Click(object sender, System.EventArgs e)

        {
            lock(timeFrom)
            {
                lock(cirs)
                {
                    for (int i = 0; i < id; i++)
                    {
                        timers[i].Dispose();
                    }
                    timy.Dispose();

                    button2.Enabled = true;
                    graphics.Clear(Color.White);
                    die = new List<int>();
                    cirs = new List<Vector4>();
                    id = 0;
                    timeFrom = new List<int>();
                    timers = new List<System.Threading.Timer>();
                }
            }
            
        }

        static List<Vector4> cirs = new List<Vector4>();
        static object lock_max=new object();
        static object lock_av=new object();
        static int max_circles = 10;
        static int avg_time = 3;
        private void cirs_count_slider_Scroll(object sender, EventArgs e)
        {
            lock (lock_max)
            {
                max_circles = cirs_count_slider.Value;
            }
            label1.Text = cirs_count_slider.Value.ToString();
        }

        private void av_time_slider_Scroll(object sender, EventArgs e)
        {
            lock (lock_av)
            {
                avg_time = av_time_slider.Value;
            }
            label2.Text = av_time_slider.Value.ToString();
        }

        public void drawCircles(object obj)
        {
            graphics.Clear(Color.White);
            Pen pn = new Pen(Color.White);
            int n = 0;
            for (int i = 0; i < id; i++)
            {
                lock (die)
                {
                    if (die[i] != 1)
                    {
                        lock (cirs)
                        {
                            pn.Color = Color.FromArgb((int)cirs[i].w, (int)cirs[i].w, (int)cirs[i].w);
                            graphics.DrawEllipse(pn, cirs[i].x, cirs[i].y, cirs[i].z, cirs[i].z);
                            n++;
                        }
                        
                    }
                }
            }
            lock (lock_max)
            {
                if (n < max_circles && n != 0)
                {
                    lock (timeFrom)
                    {
                        for (int i = 0; i < max_circles - n; i++)
                        {
                            timeFrom.Add(0);
                            cirs.Add(new Vector4(rand.Next(0, 500),
                            rand.Next(0, 300),
                            rand.Next(40, 100),
                            rand.Next(0, 255)));
                            die.Add(0);
                            timers.Add(new System.Threading.Timer(
                            new TimerCallback(drawCircle), new Vector3(0, 0, id), 0, 100));
                            id++;
                        }
                    }
                }
            }
            //int k = 0;
            
                

            
            
            
        }

        List<int> timeFrom = new List<int>();

        public void drawCircle(object obj)

        {
            
            //int timeFrom = (int)((Vector3)obj).x;
            int identity = (int)((Vector3)obj).z;

            lock (cirs)
            {
                if (rand.Next(0, 5) == 0)
                {
                    int sm = rand.Next(-35, 35);
                    Vector3 smesh = new Vector3(-sm / 2,
                        -sm / 2, sm);
                    cirs[identity] += smesh / 2;

                }
                
            }

            lock (timeFrom)
            {
                timeFrom[identity] += 100;



                lock (lock_av)
                {
                    if (rand.Next(0, 2) == 0)
                    {
                        if (timeFrom[identity] >= avg_time * 1000+
                            rand.Next(-1000,1000))
                        {
                            //cirs.RemoveAt(identity);
                            lock (die)
                            {
                                timers[identity].Dispose();
                                die[identity] = 1;
                                
                            }


                            //timers.RemoveAt(identity);
                        }
                    }

                }

            }






        }

    }
    public class circle
    {
        public Point start;
        public Size size;
        public Color color;

        public static int ammount = 0;

        

        public circle(Point st,Size si, Color col)
        {
            ammount++;
            start = st;
            size = si;
            color = col;
        }
    }

    public class Vector4:Vector3
    {
        public float w;
        public Vector4(float x, float y, float z, float w) : base(x, y,z)
        {
            this.w = w;
        }
        public Vector4(int x, int y, int z, int w) : base(x, y, z)
        {
            this.w = w;
        }
        public static Vector4 operator +(Vector4 other1, Vector4 other2)
        {
            return new Vector4(other1.x + other2.x,
                other1.y + other2.y,
                other1.z + other2.z,
                other1.w + other2.w);
        }
        public static Vector4 operator +(Vector4 other1, Vector3 other2)
        {
            return new Vector4(other1.x + other2.x,
                other1.y + other2.y,
                other1.z + other2.z,
                other1.w);
        }
        public static Vector4 operator +(Vector4 other1, Vector2 other2)
        {
            return new Vector4(other1.x + other2.x,
                other1.y + other2.y,
                other1.z,
                other1.w);
        }
        public static Vector4 operator -(Vector4 other1, Vector4 other2)
        {
            return new Vector4(other1.x - other2.x,
                other1.y - other2.y,
                other1.z - other2.z,
                other1.w - other2.w);
        }
        public static Vector4 operator -(Vector4 other1, Vector3 other2)
        {
            return new Vector4(other1.x - other2.x,
                other1.y - other2.y,
                other1.z - other2.z,
                other1.w);
        }
        public static Vector4 operator -(Vector4 other1, Vector2 other2)
        {
            return new Vector4(other1.x - other2.x,
                other1.y - other2.y,
                other1.z,
                other1.w);
        }
    }

    public class Vector3:Vector2
    {
        public float z;
        public Vector3(float x, float y, float z=0) :base(x,y)
        {
            this.z = z;
        }
        public Vector3(int x, int y, int z=0) : base(x, y)
        {
            this.z = z;
        }

        public static Vector3 operator +(Vector3 other1, Vector3 other2)
        {
            return new Vector3(other1.x + other2.x, 
                other1.y + other2.y,
                other1.z + other2.z);
        }
        public static Vector3 operator +(Vector3 other1, Vector2 other2)
        {
            return new Vector3(other1.x + other2.x, 
                other1.y + other2.y,
                other1.z );
        }
        public static Vector3 operator -(Vector3 other1, Vector3 other2)
        {
            return new Vector3(other1.x - other2.x,
                other1.y - other2.y, 
                other1.z - other2.z);
        }
        public static Vector3 operator -(Vector3 other1, Vector2 other2)
        {
            return new Vector3(other1.x - other2.x,
                other1.y - other2.y,
                other1.z);
        }
        public static Vector3 operator +(Vector3 other1, float val)
        {
            return new Vector3(other1.x + val, 
                other1.y + val,
                other1.z + val);
        }
        public static Vector3 operator -(Vector3 other1, float val)
        {
            return new Vector3(other1.x - val, 
                other1.y - val, 
                other1.z - val);
        }
        public static Vector3 operator *(Vector3 other1, float val)
        {
            return new Vector3(other1.x * val, 
                other1.y * val, 
                other1.z * val);
        }
        public static Vector3 operator /(Vector3 other1, float val)
        {
            return new Vector3(other1.x / val, 
                other1.y / val, 
                other1.z / val);
        }

        
    }

    public class Vector2
    {
        public float x { get; set; }
        public float y { get; set; }
        public Vector2(float x, float y)
        {
            this.x = x;
            this.y = y;
        }
        public Vector2(int x, int y)
        {
            this.x = x;
            this.y = y;
        }

        public static Vector2 operator +(Vector2 other1, Vector2 other2)
        {
            return new Vector2(other1.x + other2.x, other1.y + other2.y);
        }
        public static Vector2 operator -(Vector2 other1, Vector2 other2)
        {
            return new Vector2(other1.x - other2.x, other1.y - other2.y);
        }
        public static Vector2 operator +(Vector2 other1, float val)
        {
            return new Vector2(other1.x + val, other1.y + val);
        }
        public static Vector2 operator -(Vector2 other1, float val)
        {
            return new Vector2(other1.x - val, other1.y - val);
        }
        public static Vector2 operator *(Vector2 other1, float val)
        {
            return new Vector2(other1.x * val, other1.y * val);
        }
        public static Vector2 operator /(Vector2 other1, float val)
        {
            return new Vector2(other1.x / val, other1.y / val);
        }
    }

    
}

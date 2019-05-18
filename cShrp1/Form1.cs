using System;
using System.Collections;
using System.Collections.Generic;
using System.Drawing;
using System.Threading;
using System.Windows.Forms;


namespace cShrp1
{
    public partial class Form1 : Form
    {
        private Metro gnome;
        private double[] times = new double[6];
        private int num = 0;
        private System.Diagnostics.Stopwatch watch = new System.Diagnostics.Stopwatch();
        private bool beenTapped = false;
        private bool red = false;
        private bool alterTempo = false;
        private bool up = false;
        

        public Form1()
        {
            InitializeComponent();
            gnome = new Metro();
        }

        private void Form1_Load(object sender, EventArgs e)
        {
            clock.Interval = gnome.BPM;
            flashy.Text= "BPM: " + gnome.BPM;
        }

        //
        //button Up 
        //

        private void BtnUp_MouseUp(object sender, MouseEventArgs e)
        {
            alterTempo = false;
        }
        private void BtnUp_MouseDown(object sender, MouseEventArgs e)
        {
            alterTempo = true;
            up = true;
            Thread thr = new Thread(runs);
            thr.Start();
        }
        //
        //Button Down
        //
        private void BtnDown_MouseUp(object sender, MouseEventArgs e)
        {
            alterTempo = false;
        }

        private void BtnDown_MouseDown(object sender, MouseEventArgs e)
        {
            alterTempo = true;
            up = false;
            Thread thr = new Thread(runs);
            thr.Start();
        }
        
        public void colorChange()
        {
            
            flashy.BackColor = gnome.flashMe();
        }


        private void Clock_Tick(object sender, EventArgs e)
        {
            clock.Enabled = true;  
            //makePartyLights();
            clock.Interval = gnome.Duration;
            gnome.click();
            colorChange();
            flashy.Text = Convert.ToString("BPM: " + gnome.BPM);
            
        }


        private void runs()
        {
            int count = 0;
            int bpm = gnome.BPM;
            while (alterTempo)
            {
                if (up)
                {
                    Console.WriteLine("in up");
                    if (count < 25)
                    {
                        count++;
                    }
                }
                else
                {
                    if (count > -25)
                    {
                        Console.WriteLine("in down");
                        count--;
                    }
                }
                    gnome.bpmChange(count);
                    Thread.Sleep(300);
            }
            up = false;
        }

        private void BtnTap_Click(object sender, EventArgs e)
        {
            if (watch.IsRunning)
            {
                watch.Stop();
                String value = watch.Elapsed.ToString().Substring(6);
                double newVal = Convert.ToDouble(value);
                if (newVal < 3.0)
                {
                    times[num] = newVal;
                    watch.Reset();
                    gnome.tap(times);
                }
                watch.Reset();
                //after certain amount of time disregaud old
                //catch any within certain time linmit before refering to tap tepo
            }
            else
            {
                watch.Start();
            }

        }
        private void updateTempo()
        {

        }

        private void BtnStrStp_Click(object sender, EventArgs e)
        {
            gnome.onOff();
        }
    }
}

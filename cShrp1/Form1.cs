using System;
using System.Collections;
using System.Collections.Generic;
using System.ComponentModel;
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
        private bool open = true;
        private delegate void textMonitor();
        private delegate void flasher();
        

        public Form1()
        {
            InitializeComponent();
            gnome = new Metro();
            flashy.Text = "BPM: " + gnome.BPM;

        }

        private void Form1_Load(object sender, EventArgs e)
        {
            clock.Interval = gnome.BPM;
        }

        //
        //button Up 
        //
        private void BtnUp_MouseDown(object sender, MouseEventArgs e)
        {
            gnome.AlterBPM = true;//set altering metronome tempo to true
            Thread thr = new Thread(gnome.BPMUp);
            var t = new Thread(new ThreadStart(threadStuff));
            t.Start();
            thr.Start();
        }
        private void BtnUp_MouseUp(object sender, MouseEventArgs e)
        {
            gnome.AlterBPM = false;//set altering metronome tempo to false
        }

        //
        //Button Down
        //
        private void BtnDown_MouseDown(object sender, MouseEventArgs e)
        {
            gnome.AlterBPM = true; //set altering metronome tempo to true
            Thread thr = new Thread(gnome.BPMDown);
            var t = new Thread(new ThreadStart(threadStuff));
            t.Start();
            thr.Start();
        }
        private void BtnDown_MouseUp(object sender, MouseEventArgs e) { gnome.AlterBPM = false; }//set altering metronome tempo to false

        //
        //For flashy/bpm label update allows for threading of the label on form1
        //
        public void threadFlash()
        {while (gnome.On)
            {
                if (!open)
                { flashy.Invoke(new flasher(updateColor)); }
                else
                {
                    break;
                }
            }
        }

        public void updateColor() { flashy.BackColor = gnome.C;}
        public void threadStuff() { while (gnome.AlterBPM) { flashy.Invoke(new textMonitor(updateFlashy)); } }
        public void updateFlashy() { flashy.Text = "BPM: " + gnome.BPM; }

        //
        //TapTempo 
        //
        private void BtnTap_Click(object sender, EventArgs e)
        {
            gnome.tap1();
            flashy.Text = "BPM: "+ gnome.BPM;
        }

        private void BtnStrStp_Click(object sender, EventArgs e){
            var flashThread = new Thread(new ThreadStart(threadFlash));
            gnome.onOff();
            if (gnome.On)
            {
                flashThread.Start();
            }
        }

        private void Form1_FormClosing(object sender, FormClosingEventArgs e)
        {
            open = false;
        }
    }
}

using System;
using System.Collections;
using System.Collections.Generic;
using System.Drawing;
using System.Media;
using System.Threading;
using System.Timers;

namespace cShrp1
{
    class Metro 
    {
        private double[] times = new double[24];
        private int timesCollected = 0;
        private int bpm;
        private int duration;
        private double old;
        private bool color1 = false;
        private bool alter = false;
        private bool on = false;
        private bool increase;
        private Color c;
        private System.Diagnostics.Stopwatch watch = new System.Diagnostics.Stopwatch(); //controls elapsed time for tapTempo
        private System.Diagnostics.Stopwatch elapsedClock = new System.Diagnostics.Stopwatch(); //monitors duration of tapTemp
        private System.Timers.Timer clock; //controls the clicktrack

        public Metro()
        {
            bpm = 60;
            BPMToDuration();
            clock = new System.Timers.Timer();
            startClock();
        }
        public int BPM
        {
            get { return bpm; }
            set { bpm = value;}
        }
        public int Duration
        {
            get { return duration;}
            set { duration = value;}
        }
      
        public bool AlterBPM
        {
            get { return alter; }
            set { alter = value; }
        }
        public bool Increase
        {
            get { return increase; }
            set { increase = value; }
        }
        public bool On {get { return on; }  }
        public Color C {get { return c; }  }
   
        public void onOff()
        {
            on = on ? false : true;
            clock.Enabled = clock.Enabled ? false : true; 
        }
        private void startClock()
        {
            Console.WriteLine("Durations: " + duration);
            Console.WriteLine("BPM :" + bpm);
            clock.Interval = duration;
            clock.AutoReset = true;
            clock.Elapsed += new ElapsedEventHandler(clockTick);
            clock.Enabled = false;
        }
        private void clockTick(object source, ElapsedEventArgs e)
        {
            click();
            if (AlterBPM) { clock.Interval = duration; } 
        }
        public void click()
        {
            SoundPlayer player = new SoundPlayer("C:/Users/Landon Lemieux/Desktop/click.wav");
            player.PlaySync();
            flashMe();
        }

        private void flashMe()
        {
            c = color1 ? Color.Blue : Color.Red;
            color1 = color1 ? false : true;
        }

        private void BPMToDuration()
        {
            double bps = (double)bpm / 60.0;
            double temp = (1000 / bps);
            temp = Math.Round(temp);
            duration = (int)temp;
        }
        private void durationToBPM()
        {
            double temp = 1000.0 / (double) duration;
            temp *= 60;
            temp = Math.Round(temp);
            bpm = (int)temp;
        }

        public void BPMUp()
        {
            int count = 0;
            while (alter)
            {
                if (count <= 25){ count++; }
                bpm += count;
                BPMToDuration();
                Thread.Sleep(300);
                Console.WriteLine("IN UP");
            }
        }
        public void BPMDown()
        {
            int count = 0;
            while (alter)
            {
                if (count >= -25){count--;}
                bpm -= count;
                BPMToDuration();
                Thread.Sleep(300);
                Console.WriteLine("IN DOWN");
            }
        }

        public void tap1() {
            if (watch.IsRunning)
            {
                watch.Stop();
                elapsedClock.Reset();
                String value = watch.Elapsed.ToString().Substring(6);
                double newVal = Convert.ToDouble(value);
                if (newVal < 3.0)
                {
                    times[timesCollected] = newVal;
                    watch.Reset();
                    tap();
                    timesCollected++;
                }
                if (timesCollected == 5)
                {
                    cleanUpArray();
                }
                watch.Reset();
                //after certain amount of time disregaud old
                //catch any within certain time linmit before refering to tap tepo
            }else {
                watch.Start();
                if(timesCollected == 0)
                {
                    elapsedClock.Start();
                    Thread monitor = new Thread(clockMonitor);
                    AlterBPM = true;
                }
            }
        }
        private void clockMonitor()
        {
            while(elapsedClock.ElapsedMilliseconds < 5000)
            { Thread.Sleep(1000); }
            cleanUpArray();
        }

        private void cleanUpArray()
        {
            Array.Clear(times, 0, times.Length);
            timesCollected = 0;
            AlterBPM = false; //qustionable
        }
        private void tap()
        {
            //get average 2+ taps
            //could be many taps account for up to 4?
            if (old == 0)
            {
                old = times[0];
            }
            double fin=0.0;

            foreach (double t in times)
            {
                Console.WriteLine(t);
                if (t != 0)
                {
                    fin = (old + t) / 2;
                    old = fin;
                }
            }
            fin = fin * 1000;
            duration = Convert.ToInt32(fin);
            Console.WriteLine("Durations: " + duration);
            Console.WriteLine("BPM :" + bpm);
            durationToBPM();
            clock.Interval = duration;
        }
    }
}

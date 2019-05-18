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

        private int bpm;
        private int duration;
        private double old;
        private bool color1 = false;
        private System.Timers.Timer clock;

        public Metro()
        {
            bpm = 60;
            bpmToDuration();
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
       

        private void startClock()
        {
            clock.Interval = duration;
            clock.AutoReset = true;
            clock.Elapsed += new ElapsedEventHandler(clockTick);
            clock.Enabled = false;
        }
        private void clockTick(object source, ElapsedEventArgs e)
        {
                click();
                //clock.Interval = duration;
        }
        public void onOff()
        {
            clock.Enabled = clock.Enabled ? false : true; 
        }
        public void click()
        {
                SoundPlayer player = new SoundPlayer("C:/Users/Landon Lemieux/Desktop/click.wav");
                player.PlaySync();
                //flashMe();
        }

        public Color flashMe()
        {
            Color c;
            c = color1 ? Color.Blue : Color.Red;
            color1 = color1 ? false : true;

            return c;
        }
        private void bpmToDuration()
        {
            double bps = (double)bpm / 60.0;
            double temp = (1000 / bps);
            temp = Math.Round(temp);
            duration = (int)temp;
        }

        public void bpmChange(int click)
        {   
            if (bpm < 350)
            {
                bpm += click;
                bpmToDuration();
            }
            else
            {
                bpm = 350;
            }
        }


        public void tap(double [] times)
        {
            //get average 2+ taps
            //could be many taps account for up to 4?
            if (old == 0)
            {
                old = times[0];
            }
            double fin=0.0;
            //System.TimeSpan new;
            foreach (double t in times)
            { if (t != 0) {
                fin = (old + t) / 2;
                old = fin;
            }
            }
            fin = fin * 1000;
            duration = Convert.ToInt32(fin);
            durationToBpm();

        }
        private void durationToBpm()
        {
            double temp = 1000.0 / (double) duration;
            temp *= 60;
            temp = Math.Round(temp);
            bpm = (int)temp;

        }
    }
}

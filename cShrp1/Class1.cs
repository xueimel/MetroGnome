using System;
using System.Collections;
using System.Collections.Generic;
using System.Drawing;
using System.Media;


namespace cShrp1
{
    class Metro 
    {

        private int bpm;
        private int duration;
        private double old;
        private bool on = false;
        private bool color1 = false;
        private System.Timers.Timer clock = new System.Timers.Timer();

        public Metro()
        {
            bpm = 120;
            bpmToDuration();
            clock.Interval = duration;
        }

        public void onOff()
        {
            on = on ? false : true; 
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
       
        public void click()
        {
            if (on)
            {
                SoundPlayer player = new SoundPlayer("C:/Users/Landon Lemieux/Desktop/click.wav");
                player.PlaySync();
                flashMe();
            }
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
            Console.WriteLine("BPS: " + bps);
            duration = (int)temp;
            Console.WriteLine("Duration: " + duration);
        }

        public void bpmChange(int click)
        {   
            if (bpm < 350)
            {
                bpm += click;
                bpmToDuration();
                Console.WriteLine("BPM: " + bpm);
            }
            else
            {
                bpm = 350;
                Console.WriteLine("Throw exception");
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

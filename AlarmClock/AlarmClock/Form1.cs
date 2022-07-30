using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Media;

namespace AlarmClock
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }
        System.Media.SoundPlayer player = new System.Media.SoundPlayer();
        int alarmCheck = 0;
        String hour, minute, time;

        private void button1_Click(object sender, EventArgs e)
        {
            alarmCheck = 1;
            hour = hourBox.Text;
            minute = minutesBox.Text;
            time = timeBox.Text;
        }

        private void timer1_Tick(object sender, EventArgs e)
        {
            DateTime date = DateTime.Now;
            label4.Text = date.ToString("hh:mm:ss tt");
            if (alarmCheck == 1)
            {
                label5.Text = hour + " : " + minute + " " + time;
                if ((date.ToString("hh") == hour) && (date.ToString("mm") == minute) && (date.ToString("tt") == time))
                {
                    player.PlayLooping();
                    alarmCheck = 0;
                }
            }
            else
            {
                label5.Text = "Alarm not set";
            }

        }

        private void button2_Click(object sender, EventArgs e)
        {
            player.Stop();
        }

        private void Form1_Load(object sender, EventArgs e)
        {
            timer1.Start();
            player.SoundLocation = @"D:\Semester 5\Visual Programming\Uni C#\beep-01a.wav";
        }
    }
}

using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using Scan;
namespace AntivirusUI
{
    public partial class Scaning : Form
    {
        ScanEngine scn_engine;

        int time = 0;
        public Scaning(ScanEngine scn_engine)
        {
            InitializeComponent();
            this.scn_engine = scn_engine;
        }

        private void Break_button_Click(object sender, EventArgs e)
        {
            StartScaning ss = new StartScaning();
            ss.flag = true;
            Close();
        }

        private void start_stop_button_Click(object sender, EventArgs e)
        {
            if (start_stop_button.Text == "Приостановить")
            {
                start_stop_button.Text = "Возобновить";
            }
            else
            {
                start_stop_button.Text = "Приостановить";
            }
        }

        private void Scaning_Load(object sender, EventArgs e)
        {
            timer1.Enabled = true;
        }

        private void timer1_Tick(object sender, EventArgs e)
        {
            time++;
            label6.Text = time.ToString() + " с.";
            if (progressBar1.Value < 100)
                progressBar1.Value += 1;
        }
    }
}

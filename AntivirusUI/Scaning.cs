using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace AntivirusUI
{
    public partial class Scaning : Form
    {
        public Scaning()
        {
            InitializeComponent();
        }

        private void Break_button_Click(object sender, EventArgs e)
        {
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
    }
}

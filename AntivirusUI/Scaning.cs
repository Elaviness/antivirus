﻿using System;
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
    }
}

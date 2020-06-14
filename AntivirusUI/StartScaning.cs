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
using SignatureBase;
namespace AntivirusUI
{
    public partial class StartScaning : Form
    {
        public Signature sgnt {get; set;}
        public StartScaning()
        {
            InitializeComponent();
        }

        private void StartScaning_Load(object sender, EventArgs e)
        {

        }

        private void StartScaningButton_Click(object sender, EventArgs e)
        {
            try
            {
                ScanEngine scn_engine = new ScanEngine(textBox1.Text);
                Close();
                Scaning scn_window = new Scaning();
                scn_window.Show();
                scn_engine.Start_scaning(sgnt);
            } catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }
    }
}

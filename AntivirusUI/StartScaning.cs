using System;
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

        private void StartScaning_Load(object sender, EventArgs e){ }

        private void StartScaningButton_Click(object sender, EventArgs e)
        {
            try
            {
                ScanEngine scn_engine = new ScanEngine(textBox1.Text);
                Close();
                Scaning scn_window = new Scaning(scn_engine);
                scn_window.Show();
                Start_scaning(scn_engine);

            } catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }

        private async void Start_scaning(ScanEngine scn_engine)
        {

            await Task.Run(() =>
            {
                scn_engine.Start_scaning(sgnt);
                
            });    
        }
    }
}

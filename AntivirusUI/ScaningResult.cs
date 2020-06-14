using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace AntivirusUI
{
    public partial class ScaningResult : Form
    {
        public ScaningResult()
        {
            InitializeComponent();
        }

        private void ScaningResult_Load(object sender, EventArgs e)
        {
            const string PATH_TO_REPORT_FILE = @"C:\Temp\AntivirusReportFile.txt";

            string line;
            try
            {
                using (StreamReader sr = new StreamReader(PATH_TO_REPORT_FILE, Encoding.Default))
                {
                    while ((line = sr.ReadLine()) != null)
                    {
                        listBox1.Items.Add(line);
                    }
                    if (listBox1.Items.Count == 0)
                    {
                        listBox1.Items.Add("Пока нет информации о сканированиях");
                    }
                }
            } catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
                listBox1.Items.Add("Не удалось получить информацию");
            }
        }

        private void buttonExit_Click(object sender, EventArgs e)
        {
            Close();
        }
    }
}

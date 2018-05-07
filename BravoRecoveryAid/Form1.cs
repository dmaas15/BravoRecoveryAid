using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace BravoRecoveryAid
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }

        private void openFileDialog1_FileOk(object sender, CancelEventArgs e)
        {

        }

        private void button1_Click(object sender, EventArgs e)
        {
            OpenFileDialog openFileDialog1 = new OpenFileDialog();
            openFileDialog1.Title = "Browse Log Files";
            openFileDialog1.InitialDirectory = @"C:\VWorks Workspace\VWorks\Logs";
            openFileDialog1.Filter = "log files (*.log)|*.log";
            openFileDialog1.CheckFileExists = true;
            openFileDialog1.CheckPathExists = true;
            if (openFileDialog1.ShowDialog() == DialogResult.OK)
            {
                // Read each line of the file into a string array. Each element
                // of the array is one line of the file.
                textBox1.Text = openFileDialog1.FileName;
                openFileDialog1.Dispose();
                string fname = textBox1.Text;
                string[] lines = System.IO.File.ReadAllLines(@fname);

                // Display the file contents by using a foreach loop.
                System.Console.WriteLine("Contents of WriteLines2.txt = ");
                foreach (string line in lines)
                {
                    string[] subStrings = line.Split('\t');
                    dataGridView1.Rows.Add(subStrings);
                    Console.WriteLine(subStrings[0]);
                }

            }


        }

        private void Form1_Load(object sender, EventArgs e)
        {

        }

        private void dataGridView1_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {

        }
    }
}

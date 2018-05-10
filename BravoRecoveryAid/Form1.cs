using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using Accord.MachineLearning;

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
                }

            }


        }

        private void Form1_Load(object sender, EventArgs e)
        {

        }

        private void dataGridView1_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {

        }

        private void button2_Click(object sender, EventArgs e)
        {
            foreach (DataGridViewRow row in dataGridView1.SelectedRows)
            {
                if (!row.IsNewRow)
                    dataGridView1.Rows.Remove(row);
            }
        }

        private void button3_Click(object sender, EventArgs e)
        {
            int lastRow = dataGridView1.Rows.Count;
            int rowCount = 1;
            object protocol;
            //Console.WriteLine(lastRow);
            do
            {
                protocol = dataGridView1.Rows[lastRow - rowCount].Cells[7].Value;
                if (protocol!=null)
                {
                    if (protocol.ToString() != "")
                    {
                        Console.WriteLine(protocol.GetType() + " " + protocol);
                        textBox2.Text = protocol.ToString();
                        break;
                    }
                }
                //Console.WriteLine(protocol);
                rowCount++;
            } while (rowCount<lastRow);
;
        }
    }
}

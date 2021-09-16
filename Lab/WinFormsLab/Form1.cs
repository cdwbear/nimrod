using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace WinFormsLab
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
            dateTimePicker1.Format = DateTimePickerFormat.Custom;
            dateTimePicker1.CustomFormat = "MMM yyyy";
            timer1.Interval = 15000;
            timer1.Enabled = true;
			timer1.Tick += Timer1_Tick;
			timer1.Start();
        }

		private void Timer1_Tick(object sender, EventArgs e)
		{
			labelTimer1.Text = DateTime.Now.ToLongTimeString();
		}

		private void button1_Click(object sender, EventArgs e)
        {
            label1.Text = textBox1.Text;
        }

        private void button2_Click(object sender, EventArgs e)
        {
            saveFileDialog1.CheckPathExists = true;
            saveFileDialog1.FileName = "goobah";
            saveFileDialog1.InitialDirectory = @"C:\NoAnswerJones";

            saveFileDialog1.ShowDialog();
        }

        private void dateTimePicker1_ValueChanged(object sender, EventArgs e)
        {
            var selectedDate = dateTimePicker1.Value;
        }

		private void radioButtonTimer_CheckedChanged(object sender, EventArgs e)
		{
			if (radioButtonTimer.Checked)
			{
				timer1.Start();
			}
			else
            {
	            timer1.Stop();
            }
		}
	}
}

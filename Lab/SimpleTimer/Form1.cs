using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Diagnostics;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace SimpleTimer
{
    public partial class FormTimer : Form
    {
        Stopwatch sw1 = new Stopwatch();
        public FormTimer()
        {
            InitializeComponent();
        }

        private void buttonStart_Click(object sender, EventArgs e)
        {
            labelStart.Text = DateTime.Now.ToLongTimeString();
            sw1.Start();
        }

        private void buttonStop_Click(object sender, EventArgs e)
        {
            sw1.Stop();
            labelStop.Text = DateTime.Now.ToLongTimeString();
        }
    }
}

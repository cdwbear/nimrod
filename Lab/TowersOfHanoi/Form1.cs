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

namespace TowersOfHanoi
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            richTextBoxStack.Clear();
            richTextBoxMoves.Clear();

            var discs = textBox1.Text;

            int discCount = 0;
            if (!Int32.TryParse(discs, out discCount))
            {
                discCount = 0;
            }
            var towerSolver = new TowerSolver(this, 3);

            Stopwatch sw = new Stopwatch();

            sw.Start();
            towerSolver.moveTower(discCount, "A", "B", "C");
            sw.Stop();

            TimeSpan ts1 = sw.Elapsed;

            MessageBox.Show($"Time was {sw.Elapsed.Minutes}:{sw.Elapsed.Seconds}:{sw.Elapsed.Milliseconds}");
        }

        private void button2_Click(object sender, EventArgs e)
        {
            richTextBoxStack.Clear();
            richTextBoxMoves.Clear();

            var discs = textBox1.Text;

            int discCount = 0;
            if (!Int32.TryParse(discs, out discCount))
            {
                discCount = 0;
            }
            var towerSolver = new TowerSolver(this, 3);

            Stopwatch sw = new Stopwatch();

            sw.Start();
            towerSolver.moveTower2(discCount, "A", "C", "B");
            sw.Stop();

            TimeSpan ts1 = sw.Elapsed;
            var avgTicksPerDisk = (Math.Pow(2, discCount) - 1) / ts1.Ticks;

            // var avgTimeSpan = new TimeSpan(avgTicksPerDisk);

            MessageBox.Show($"Time was {sw.Elapsed.Minutes}:{sw.Elapsed.Seconds}:{sw.Elapsed.Milliseconds} - Ticks:{sw.ElapsedTicks}");
        }
    }
}

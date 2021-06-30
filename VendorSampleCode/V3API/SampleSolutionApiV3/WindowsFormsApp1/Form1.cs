using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using WindowsFormsApp1.ApexSandboxApi;

namespace WindowsFormsApp1
{
    public partial class Form1 : Form
    {
        private OneTouchServicesClient client = new OneTouchServicesClient();

        public Form1()
        {
            InitializeComponent();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            var payerList = client.GetPayers("OE5DKAJ0MJBK5OV0WYLQPZ1M", "PJQP3A2BYMCXMXPPOABQ3F4B", PayerType.Medicaid);
        }
    }
}

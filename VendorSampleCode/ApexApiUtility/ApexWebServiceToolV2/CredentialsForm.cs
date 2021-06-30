using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace ApexWebServiceToolV2
{
    public partial class CredentialsForm : Form
    {
        public string ServiceKey
        {
            get { return textBoxKey.Text; }
            private set { textBoxKey.Text = value; }
        }

        public string ServicePwd
        {
            get { return textBoxPwd.Text; }
            private set { textBoxPwd.Text = value; }
        }
        
        public CredentialsForm(string serviceKey, string servicePassword)
        {
            InitializeComponent();

            ServiceKey = serviceKey;
            ServicePwd = servicePassword;
        }

        private void textBox_TextChanged(object sender, EventArgs e)
        {
            buttonSave.Enabled = true;

            textBoxKey.TextChanged -= textBox_TextChanged;
            textBoxPwd.TextChanged -= textBox_TextChanged;
        }
    }
}

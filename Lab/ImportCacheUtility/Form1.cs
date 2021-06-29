using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Resources;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using Apex.ImportingServices.Contracts;
using Apex.ImportTools;
using Apex.Services;
using Apex.ServiceFoundation;
using Apex.CommonServiceContracts;

namespace ImportCacheUtility
{
    public partial class Form1 : Form
    {
        private IClientManager _clientManager;

        public Form1()
        {
            InitializeComponent();

            comboBoxDocumentTypes.DataSource = Enum.GetValues(typeof(DocumentType));


            _clientManager = RemotingManager.GetComponent<IClientManager>();
            if (_clientManager == null)
            {
                MessageBox.Show("Could not connect");
            }
        }

        private void buttonFindClient_Click(object sender, EventArgs e)
        {
            if (!string.IsNullOrEmpty(textBoxClientId.Text))
            {
                var clientConfig = _clientManager.GetClient(textBoxClientId.Text, DocumentType.MedicalClaim.ToString());


            }
            // _clientManager.GetClient(textB)
        }
    }
}

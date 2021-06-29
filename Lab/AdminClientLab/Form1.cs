using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using Apex.ServiceFoundation;
using Apex.AdministrativeServices.Contracts.Providers;
using Apex.AdministrativeServices.Contracts.Clients;
using Apex.AdministrativeServices.DataManager.Contracts;

namespace AdminClientLab
{
    public partial class Form1 : Form
    {
        private IClientService _clientService;
        private IProviderService _providerService;
        private IProviderRegistrationService _providerRegistrationService;

        public Form1()
        {
            InitializeComponent();

            _clientService = RemotingManager.GetProxy<IClientService>();
            _providerRegistrationService = RemotingManager.GetProxy<IProviderRegistrationService>();
            _providerService = RemotingManager.GetProxy<IProviderService>();
        }
    }
}

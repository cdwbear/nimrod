using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
//using ApexWebServiceToolV2.ApexSandboxReference;
//using ApexWebServiceToolV2.ApexProduction;
//using ApexWebServiceToolV2.ApexProd;
//using ApexWebServiceToolV2.ApexLocal;
using ApexWebServiceToolV2.ApexSandbox;
//using ApexWebServiceToolV2.ApexLocal9557;

namespace ApexWebServiceToolV2
{
    public partial class EligibilityPayers : Form
    {
        private List<Payer> _liveMedicalPayers = null;
        private List<Payer> _liveDentalPayers = null;
        private List<Payer> _liveMedicaidPayers = null;
        private List<Payer> _testMedicalPayers = null;
        private List<Payer> _testDentalPayers = null;
        private List<Payer> _testMedicaidPayers = null;
        private List<Payer> _currentList = null; 

        private string _key;
        private string _pwd;
        private PayerType _payerType = PayerType.Medical;
        private bool _livePayer = true;
        private OneTouchServicesClient client15 = new OneTouchServicesClient();

        public Payer SelectedPayer { get; set; }

        public EligibilityPayers(string key, string pwd)
        {
            InitializeComponent();
            resultsControlElig.DataGridViewResults.Visible = true;
            resultsControlElig.TreeViewPanel.Visible = false;
            resultsControlElig.DataGridViewResults.MultiSelect = false;

            _key = key;
            _pwd = pwd;
            client15 = ClientHelper.Instance.ApexClient;

            PopulatePayerList();

            radioButtonMedical.Checked = true;
            radioButtonLive.Checked = true;

            radioButtonMedical.CheckedChanged += radioButtonPayerType_Checked;
            radioButtonDental.CheckedChanged += radioButtonPayerType_Checked;
            radioButtonMedicaid.CheckedChanged += radioButtonPayerType_Checked;
            radioButtonLive.CheckedChanged += radioButtonPayerType_Checked;
            radioButtonTest.CheckedChanged += radioButtonPayerType_Checked;

            radioButtonPayerType_Checked(radioButtonMedical, null);
        }


        private void radioButtonPayerType_Checked(object sender, EventArgs e)
        {
            var radio = sender as RadioButton;

            if (radio != null && radio.Checked)
            {
                var listName = string.Empty;
                if (radioButtonMedical.Checked)
                {
                    if (radioButtonLive.Checked)
                    {
                        listName = "Medical";
                        _currentList = _liveMedicalPayers;
                    }
                    else
                    {
                        listName = "Test Medical";
                        _currentList = _testMedicalPayers;
                    }
                }
                else if (radioButtonDental.Checked)
                {
                    if (radioButtonLive.Checked)
                    {
                        listName = "Dental";
                        _currentList = _liveDentalPayers;
                    }
                    else
                    {
                        listName = "Test Dental";
                        _currentList = _testDentalPayers;
                    }
                }
                else
                {
                    if (radioButtonLive.Checked)
                    {
                        listName = "Medicaid";
                        _currentList = _liveMedicaidPayers;
                    }
                    else
                    {
                        listName = "Test Medicaid";
                        _currentList = _testMedicaidPayers;
                    }
                }

                if (null != _currentList)
                {
                    resultsControlElig.UpdateResultsGrid(_currentList.OfType<object>().ToArray(), listName);
                }
            }
        }

        private void PopulatePayerList()
        {
            Cursor.Current = Cursors.WaitCursor;

            try
            {
                _liveMedicalPayers = client15.GetPayers(_key, _pwd, PayerType.Medical).Where(payer => payer.OffersEligibility).ToList();
                _liveDentalPayers = client15.GetPayers(_key, _pwd, PayerType.Dental).Where(payer => payer.OffersEligibility).ToList();
                //_liveMedicaidPayers = client15.GetPayers(_key, _pwd, PayerType.Medicaid).Where(payer => payer.OffersEligibility).ToList();
                _testMedicalPayers = client15.GetTestPayers(_key, _pwd, PayerType.Medical).Where(payer => payer.OffersEligibility).ToList();
                _testDentalPayers = client15.GetTestPayers(_key, _pwd, PayerType.Dental).Where(payer => payer.OffersEligibility).ToList();
                //_testMedicaidPayers = client15.GetTestPayers(_key, _pwd, PayerType.Medicaid).Where(payer => payer.OffersEligibility).ToList();
            }
            catch (Exception e)
            {
                MessageBox.Show(e.ToString());
            }

            Cursor.Current = Cursors.Default;
        }

        public bool IsTestPayer(Payer payer)
        {
            return payer != null && !string.IsNullOrWhiteSpace(payer.ApexPayerId) && 
                   ((_testDentalPayers != null && _testDentalPayers.Any(x => x.ApexPayerId == payer.ApexPayerId) ||
                    _testMedicalPayers != null && _testMedicalPayers.Any(x => x.ApexPayerId == payer.ApexPayerId) ||
                    _testMedicaidPayers != null && _testMedicalPayers.Any(x => x.ApexPayerId == payer.ApexPayerId)));
        }

        private void EligibilityPayers_FormClosing(object sender, FormClosingEventArgs e)
        {
            if (this.DialogResult == DialogResult.OK)
            {
                if (resultsControlElig.DataGridViewResults.SelectedRows.Count == 0)
                {
                    MessageBox.Show("Please select a payer!");
                    e.Cancel = true;
                }
                else
                {
                    var payerRow = resultsControlElig.DataGridViewResults.SelectedRows[0];

                    var payer = _currentList.FirstOrDefault(x => x.ApexPayerId == (payerRow.Cells[0].Value as string));
                    SelectedPayer = payer;
                }
            }
        }
    }
}

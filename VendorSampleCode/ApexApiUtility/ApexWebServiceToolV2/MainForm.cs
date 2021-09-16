using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Configuration;
using System.Diagnostics;
using System.Dynamic;
using System.IO;
using System.Linq;
using System.Net;
using System.Runtime.Serialization;
using System.ServiceModel;
using System.ServiceModel.Configuration;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using Newtonsoft.Json.Converters;
using ApiV3Library;

//using ApexWebServiceToolV2.ApexServiceReference;
//using Sandbox = ApexWebServiceToolV2.ApexSandboxReference;
using System.Xml;
using System.Xml.Serialization;
//using ApexWebServiceToolV2.ApexLocal;
using ApexWebServiceToolV2.ApexSandbox;
using Newtonsoft.Json;
using Formatting = Newtonsoft.Json.Formatting;
using RadioButton = System.Windows.Forms.RadioButton;

//using ApexWebServiceToolV2.ApexLocal9557;
//using ApexWebServiceToolV2.ApexProduction;
//using ApexWebServiceToolV2.ApexProd;
//using ApexWebServiceToolV2.ApexEligibility1_0;
//using ApexWebServiceToolV2.ApexOneTouch1_0;
//using WinConsoleWithWebServices.ApexServiceReferenceLocal;

namespace ApexWebServiceToolV2
{
    public partial class MainForm : Form
    {
        private OneTouchServicesClient client15 = new OneTouchServicesClient();
        private string _key_15 = string.Empty;
        private string _pwd_15 = string.Empty;
        private string _vendorSiteId = string.Empty;
        private string _bindingAddress = string.Empty;
        private DataGridView _resultsGrid = null;
        private int lastSortedColumn = -1;
        private Payer[] _payers = null;
        private Payer[] _testPayers = null;
        private ChannelEndpointElement currentEndpoint = null;
        private ClientHelper _clientHelper = null;
        private ApiVersion version = ApiVersion.V1_5;
        private ApiV3 clientV3 = null;
        private bool viewV3ResultsAsJson = false;

        private enum op
        {
            GetPayers,
            SubmitClaims,
            GetClaimStatusByDate,
            GetPayerResponseDocuments,
        }

        public MainForm()
        {
            ServicePointManager.SecurityProtocol = SecurityProtocolType.Tls12;
            InitializeComponent();

            _clientHelper = ClientHelper.Instance;
            client15 = _clientHelper.ApexClient;

            ClientSection config = ConfigurationManager.GetSection("system.serviceModel/client") as ClientSection;
            ChannelEndpointElement[] endpointElements = new ChannelEndpointElement[config.Endpoints.Count];
            config.Endpoints.CopyTo(endpointElements, 0);

            comboBoxBinding.Items.AddRange(endpointElements);
            comboBoxBinding.DisplayMember = "Address";

            int idx = comboBoxBinding.FindString(client15.Endpoint.Address.ToString());
            comboBoxBinding.SelectedIndex = idx >= 0 ? idx : 0;

            comboBoxBinding.SelectedIndexChanged += comboBoxBinding_SelectedIndexChanged;

            dateTimePickerFrom.Value = DateTime.Today.AddDays(-4.0);
            dateTimePickerTo.Value = DateTime.Now;
        }

        private void RadioButtonApiVersion_CheckedChanged(object sender, EventArgs e)
        {
            RadioButton rb = sender as RadioButton;
            string tag = string.Empty;

            if (rb.Checked)
            {
	            if (null != rb)
	            {
		            tag = rb.Tag as string;
	            }

	            if (string.Compare(tag, "V3", StringComparison.CurrentCultureIgnoreCase) == 0)
	            {
		            version = ApiVersion.V3;
		            checkBoxViewJsonForV3.Enabled = true;
	            }
	            else
	            {
		            version = ApiVersion.V1_5;
		            checkBoxViewJsonForV3.Enabled = false;
	            }
            }
        }

        private void MainForm_Load(object sender, EventArgs e)
        {
            try
            {
                _key_15 = ConfigurationManager.AppSettings.Get(ConfigKeys.key15);
                _pwd_15 = ConfigurationManager.AppSettings.Get(ConfigKeys.password15);
                _vendorSiteId = ConfigurationManager.AppSettings.Get(ConfigKeys.vendorSiteId);
                _bindingAddress = ConfigurationManager.AppSettings.Get(ConfigKeys.lastBinding);
                
                bool writeXml = false;
                Boolean.TryParse(ConfigurationManager.AppSettings.Get(ConfigKeys.writeSerializedXml),
                                 out writeXml);
                checkBoxSerializeReponseFiles.Checked = writeXml;
                
                bool writeAnsi = false;
                Boolean.TryParse(ConfigurationManager.AppSettings.Get(ConfigKeys.writeAnsi5010), out writeAnsi);

                bool writeStatus = false;
                Boolean.TryParse(ConfigurationManager.AppSettings.Get(ConfigKeys.writeStatus), out writeStatus);
                checkBoxSerializeStatusToFile.Checked = writeStatus;

                int idx = comboBoxBinding.FindString(_bindingAddress);
                comboBoxBinding.SelectedIndex = idx >= 0 ? idx : 0;

            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.ToString());
                return;
            }

            textBoxKey.Text = _key_15;
            textBoxPassword.Text = _pwd_15;
            textBoxVendorSiteID.Text = _vendorSiteId;

            var claimIds = new string[] { "TESTD9123", "TESTD912345" };
            //foreach (string s in claimIds)
            //{
            //    dataGridViewVendorClaimIds.Rows.Add(s);
            //}
        }


        private void buttonGetTestPayers_Click(object sender, EventArgs e)
        {
            try
            {
                if (version == ApiVersion.V3)
                {
                    MessageBox.Show("There is no GetTestPayers in the V3 API");
                    return;
                }

                resultsControlMain.UpdateResultsGrid(new object[0], string.Empty);
                var payerType = radioButtonPayerMedical.Checked
                    ? PayerType.Medical
                    : radioButtonDental.Checked ? PayerType.Dental : PayerType.Medicaid;

                prepareResultsView(forPayerResponseDocs: false);

                _testPayers = client15.GetTestPayers(_key_15, _pwd_15, payerType);

                resultsControlMain.UpdateResultsGrid(_testPayers, "Payers v1.5");
            }
            catch (Exception ex)
            {
                var message = ex.Message;
                var stackMessage = ex.StackTrace;

                MessageBox.Show(string.Format("Error: [{0}], Stack Trace: [{1}]", message, stackMessage));
            }
        }

        private void button_1_5_GetPayers_Click(object sender, EventArgs e)
        {
            try
            {
                resultsControlMain.UpdateResultsGrid(new object[0], string.Empty);
                var payerType = radioButtonPayerMedical.Checked
                    ? PayerType.Medical
                    : radioButtonDental.Checked ? PayerType.Dental : PayerType.Medicaid;

                prepareResultsView(forPayerResponseDocs: false);

                if (version == ApiVersion.V3)
                {
                    if (comboBoxBinding.SelectedItem != null)
                    {
                        var url = ((System.ServiceModel.Configuration.ChannelEndpointElement)comboBoxBinding
                            .SelectedItem).Address.ToString();
                        string results = ApiV3.GetPayers(_key_15, _pwd_15, _vendorSiteId, url,
                            payerType.ToString());

                        

                        if (!string.IsNullOrWhiteSpace(results))
                        {
                            if (viewV3ResultsAsJson)
                            {
                                prepareJsonResultsView();
                                resultsControlMain.RichTextBox2.Text = results;
                                resultsControlMain.Update();
                                return;
                            }

                            _payers = JsonConvert.DeserializeObject<List<Payer>>(results).ToArray();
                        }
                    }
                }
                else
                {
                    _payers = client15.GetPayers(_key_15, _pwd_15, payerType);
                }

                resultsControlMain.UpdateResultsGrid(_payers, "Payers v1.5", 3);
            }
            catch (Exception ex)
            {
                var message = ex.Message;
                var stackMessage = ex.StackTrace;

                MessageBox.Show(string.Format("Error: [{0}], Stack Trace: [{1}]", message, stackMessage));
            }
        }

        private void buttonSubmitClaimsAsync_Click(object sender, EventArgs e)
        {
            processClaims(false);
        }

        private void buttonSubmitClaims_Click(object sender, EventArgs e)
        {
            Cursor.Current = Cursors.WaitCursor;
            processClaims();
            Cursor.Current = Cursors.Default;
        }

        private async void processClaims(bool isSynchronous = true)
        {
            if (version != ApiVersion.V1_5)
                return;

            if (string.IsNullOrWhiteSpace(_vendorSiteId))
            {
                MessageBox.Show("Missing Vendor Site ID");
                textBoxVendorSiteID.Focus();
                return;
            }
            
            if (listBoxClaimFiles.Items.Count == 0)
            {
                buttonGetFile_Click(this, new EventArgs());
            }

            if (listBoxClaimFiles.Items.Count > 0)
            {
                List<ClaimSubmitResult> submitResults = new List<ClaimSubmitResult>();
                foreach (object pathForClaims in listBoxClaimFiles.Items)
                {
                    var fileContent = File.ReadAllText(pathForClaims as string);

                    try
                    {
                        ClaimSubmitResult csResult = null;

                        if (version == ApiVersion.V3)
                        {
                            if (comboBoxBinding.SelectedItem != null)
                            {
                                //var payerType = radioButtonPayerMedical.Checked
                                //    ? PayerType.Medical
                                //    : radioButtonDental.Checked ? PayerType.Dental : PayerType.Medicaid;

                                //var url = ((System.ServiceModel.Configuration.ChannelEndpointElement)comboBoxBinding
                                //    .SelectedItem).Address.ToString();
                                //string results = ApiV3.GetPayers(_key_15, _pwd_15, _vendorSiteId, url,
                                //    payerType.ToString());

                                //if (!string.IsNullOrWhiteSpace(results))
                                //{
                                //    _payers = JsonConvert.DeserializeObject<List<Payer>>(results).ToArray();
                                //}
                            }
                        }
                        else
                        {
                            if (isSynchronous)
                            {
                                csResult = client15.SubmitClaims(_key_15, _pwd_15, _vendorSiteId, fileContent);
                            }
                            else
                            {
                                Task<ClaimSubmitResult> taskClaimSubmit = client15.SubmitClaimsAsync(_key_15, _pwd_15, _vendorSiteId, fileContent);
                                csResult = await taskClaimSubmit;
                            }
                        }

                        if (null != csResult)
                        {
	                        prepareResultsViewForSubmitResults();

                            XmlSerializer serializer = new XmlSerializer(typeof (ClaimSubmitResult));
                            if (checkBoxSerializeStatusToFile.Checked)
                            {
                                var path = Path.Combine(AppDomain.CurrentDomain.BaseDirectory,
                                                        "ClaimSubmitResultDocxml.xml");


                                FileStream file = File.Create(path);
                                serializer.Serialize(file, csResult);
                                file.Close();
                            }
                            submitResults.Add(csResult);

                            XmlDocument xmlDoc = new XmlDocument();
                            resultsControlMain.TreeViewResults2.BeginUpdate();

                            using (MemoryStream memoryStream = new MemoryStream())
                            {
                                serializer.Serialize(memoryStream, csResult);
                                memoryStream.Flush();
                                memoryStream.Seek(0, SeekOrigin.Begin);

                                xmlDoc.Load(memoryStream);
                            }

                            var tNode = resultsControlMain.TreeViewResults2.Nodes[0];
                            int nodeIdx =
	                            tNode.Nodes.Add(
		                            new TreeNode($"Claim Results for submission of file {pathForClaims}"));

                            AddNode(xmlDoc.DocumentElement, tNode.Nodes[nodeIdx]);
                            resultsControlMain.TreeViewResults2.Nodes[0].Expand();
                            resultsControlMain.TreeViewResults2.EndUpdate();
                        }
                    }
                    catch (Exception ex)
                    {
                        MessageBox.Show(string.Format("SubmitClaims returned Exception: {0}", ex.Message));
                    }
                }

                //submitResults.ForEach(
                //    result => resultsControlMain.UpdateResultsGrid(submitResults.ToArray(), "Claim Submit Results"));
            }
            else
            {
                MessageBox.Show("Please select one or more claim files!");
                listBoxClaimFiles.Focus();
            }
        }

	    private void AddNode(XmlNode inXmlNode, TreeNode inTreeNode)
	    {
		    XmlNode xNode;
		    TreeNode tNode;
		    XmlNodeList nodeList;
		    int i;

		    if (inXmlNode.HasChildNodes)
		    {
			    nodeList = inXmlNode.ChildNodes;
			    for (i = 0; i <= nodeList.Count - 1; i++)
			    {
				    xNode = inXmlNode.ChildNodes[i];
                    var nodeName = xNode.Name;
                    if (string.Compare(xNode.Name.ToLower(), "wsclaimpayment",
                            StringComparison.CurrentCultureIgnoreCase) == 0)
                    {
                        nodeName =
                            $"{nodeName} - {xNode["Patient"]["CommonName"].InnerText}, {xNode["Patient"]["FirstName"].InnerText}";
                    }
                    // inTreeNode.Nodes.Add(new TreeNode(xNode.Name));
                    inTreeNode.Nodes.Add(new TreeNode(nodeName));
				    tNode = inTreeNode.Nodes[i];
				    AddNode(xNode, tNode);
			    }
		    }
		    else
		    {
		        if (!string.IsNullOrEmpty((inXmlNode.InnerText).Trim()))
		        {
		            inTreeNode.Text = (inXmlNode.InnerText).Trim();
		        }
		    }
        }

        private void buttonGetFile_Click(object sender, EventArgs e)
        {
            openFileDialog1.CheckFileExists = true;
            openFileDialog1.Multiselect = false;
            openFileDialog1.InitialDirectory = AppDomain.CurrentDomain.BaseDirectory;
            openFileDialog1.FileName = string.Empty;
            if (openFileDialog1.ShowDialog() == DialogResult.OK)
            {
                var fileNames = openFileDialog1.FileNames;
                listBoxClaimFiles.Items.Clear();
                listBoxClaimFiles.Items.AddRange(fileNames);
            }
        }

        private void changeCredentialsToolStripMenuItem_Click(object sender, EventArgs e)
        {
            var credForm = new CredentialsForm(_key_15, _pwd_15);
            if (DialogResult.OK == credForm.ShowDialog())
            {
                _key_15 = credForm.ServiceKey;
                _pwd_15 = credForm.ServicePwd;

                Configuration config = ConfigurationManager.OpenExeConfiguration(Application.ExecutablePath);
                config.AppSettings.Settings[ConfigKeys.key15].Value = _key_15;
                config.AppSettings.Settings[ConfigKeys.password15].Value = _pwd_15;
                config.Save(ConfigurationSaveMode.Modified);
            }
        }

        private void exportResultsToCSVToolStripMenuItem_Click(object sender, EventArgs e)
        {
            var exportName = resultsControlMain.ResultsLabel;
            var resultsGrid = resultsControlMain.DataGridViewResults;

            Cursor.Current = Cursors.WaitCursor;

            var sb = new StringBuilder();
            var columnCount = resultsGrid.Columns.Count;
            for (int colIdx = 0; colIdx < columnCount; colIdx++)
            {
                sb.AppendFormat("\"{0}\"{1}", resultsGrid.Columns[colIdx].Name, colIdx + 1 < columnCount ? "," : "");
            }
            sb.Append("\r\n");

            foreach (DataGridViewRow row in resultsGrid.Rows)
            {
                for (int idx = 0; idx < columnCount; idx++)
                {
                    sb.AppendFormat("\"{0}\"{1}", row.Cells[idx].Value as string, idx + 1 < columnCount ? "," : "");
                }
                sb.Append("\r\n");
            }

            File.WriteAllText(string.Format("{0} - {1}.csv", exportName, DateTime.Today.ToString("yyyyMMdd")), sb.ToString());

            Cursor.Current = Cursors.Default;
        }

        private void prepareJsonResultsView()
        {
            resultsControlMain.GridViewPanel.Visible = false;
            resultsControlMain.TreeViewPanel.Visible = false;
            resultsControlMain.RichTextViewPanel.Visible = true;
            resultsControlMain.RichTextBox1.Visible = true;
            resultsControlMain.RichTextBox2.Visible = true;
        }

        private void prepareResultsViewForSubmitResults()
        {
	        resultsControlMain.GridViewPanel.Visible = false;
	        resultsControlMain.Update();
	        resultsControlMain.TreeViewPanel.Visible = true;

	        resultsControlMain.TreeViewResults.Nodes.Clear();
	        resultsControlMain.TreeViewResults2.Nodes.Clear();
	        resultsControlMain.DataGridViewResults.Rows.Clear();

	        resultsControlMain.TreeViewResults2.BeginUpdate();
	        resultsControlMain.TreeViewResults2.Nodes.Clear();
	        resultsControlMain.TreeViewResults2.Nodes.Add(new TreeNode("Claim Submit Results"));
	        resultsControlMain.TreeViewResults2.Nodes[0].Expand();
	        resultsControlMain.TreeViewResults2.EndUpdate();
        }

        private void prepareResultsView(bool forPayerResponseDocs)
        {
            if (forPayerResponseDocs)
            {
                resultsControlMain.GridViewPanel.Visible = false;
                resultsControlMain.Update();
                resultsControlMain.TreeViewPanel.Visible = true;

                resultsControlMain.TreeViewResults.Nodes.Clear();
                resultsControlMain.TreeViewResults2.Nodes.Clear();
                resultsControlMain.DataGridViewResults.Rows.Clear();

                resultsControlMain.TreeViewResults.BeginUpdate();
                resultsControlMain.TreeViewResults.Nodes.Clear();
                resultsControlMain.TreeViewResults.Nodes.Add(new TreeNode("Remittances"));
                resultsControlMain.TreeViewResults.Nodes[0].Expand();
                resultsControlMain.TreeViewResults.EndUpdate();

                resultsControlMain.TreeViewResults2.BeginUpdate();
                resultsControlMain.TreeViewResults2.Nodes.Clear();
                resultsControlMain.TreeViewResults2.Nodes.Add(new TreeNode("Claim Statuses"));
                resultsControlMain.TreeViewResults2.Nodes[0].Expand();
                resultsControlMain.TreeViewResults2.EndUpdate();
            }
            else
            {
                resultsControlMain.UpdateResultsGrid(new object[0], string.Empty);
                var payerType = radioButtonPayerMedical.Checked
                    ? PayerType.Medical
                    : radioButtonDental.Checked ? PayerType.Dental : PayerType.Unknown;
                resultsControlMain.GridViewPanel.Visible = true;
                resultsControlMain.Update();
                resultsControlMain.TreeViewPanel.Visible = false;
                resultsControlMain.UpdateGridHeaders("Payers v1.5");
            }
        }

        private void buttonGetClaimStatus_Click_1_5(object sender, EventArgs e)
        {
            Cursor.Current = Cursors.WaitCursor;
            prepareResultsView(forPayerResponseDocs: true);

            var vendorSiteId = textBoxVendorSiteID.Text;
            if (string.IsNullOrEmpty(vendorSiteId) || string.IsNullOrEmpty(vendorSiteId))
            {
                MessageBox.Show("Missing required data!");
                return;
            }

            XmlSerializer serializer = new XmlSerializer(typeof(WsHealthCareClaimStatus));

            List<string> docIds = new List<string>();

            try
            {
                WsHealthCareClaimStatus[] claimStatusValues = new WsHealthCareClaimStatus[] { };

                if (version == ApiVersion.V3)
                {
                    if (comboBoxBinding.SelectedItem != null)
                    {
                        var url = ((System.ServiceModel.Configuration.ChannelEndpointElement)comboBoxBinding
                            .SelectedItem).Address.ToString();
                        string results = ApiV3.GetClaimStatusByDate(_key_15, _pwd_15, vendorSiteId, url, dateTimePickerFrom.Value,
                            dateTimePickerTo.Value);

                        if (!string.IsNullOrWhiteSpace(results))
                        {
                            if (viewV3ResultsAsJson)
                            {
                                prepareJsonResultsView();
                                resultsControlMain.RichTextBox2.Text = results;
                                return;
                            }
                            claimStatusValues = JsonConvert.DeserializeObject<List<WsHealthCareClaimStatus>>(results).ToArray();
                        }
                    }

                }
                else
                {

                    claimStatusValues = this.client15.GetClaimStatusByDate(_key_15, _pwd_15, vendorSiteId,
                        dateTimePickerFrom.Value, dateTimePickerTo.Value);
                }

                if (claimStatusValues != null && claimStatusValues.Length > 0)
                {
                    XmlDocument xmlDoc = new XmlDocument();
                    resultsControlMain.TreeViewResults2.BeginUpdate();

                    var statusValues = claimStatusValues.ToList().OrderByDescending(s => s.CreateDate);
                    foreach (WsHealthCareClaimStatus cs in statusValues)
                    {
                        using (MemoryStream memoryStream = new MemoryStream())
                        {
                            serializer.Serialize(memoryStream, cs);
                            memoryStream.Flush();
                            memoryStream.Seek(0, SeekOrigin.Begin);

                            xmlDoc.Load(memoryStream);
                        }

                        var tNode = resultsControlMain.TreeViewResults2.Nodes[0];
                        int nodeIdx =
                            tNode.Nodes.Add(new TreeNode($"Status: {cs.CreateDate}-{cs.ClaimNumber}-{cs.CurrentState}-{cs.RelatedDocumentType}"));

                        AddNode(xmlDoc.DocumentElement, tNode.Nodes[nodeIdx]);
                    }
                    resultsControlMain.TreeViewResults2.Nodes[0].Expand();
                    resultsControlMain.TreeViewResults2.EndUpdate();
                }

            }
            catch (Exception ex)
            {
                MessageBox.Show($"{ex.Message}");
            }

            Cursor.Current = Cursors.Default;
        }

        private void buttonGetPayerDocs_Click_1_5(object sender, EventArgs e)
        {
            Cursor.Current = Cursors.WaitCursor;

            prepareResultsView(forPayerResponseDocs: true);

            var vendorSiteId = textBoxVendorSiteID.Text;
            if (string.IsNullOrEmpty(vendorSiteId) || string.IsNullOrEmpty(vendorSiteId))
            {
                MessageBox.Show("Missing required data!");
                return;
            }

            XmlSerializer serializer = new XmlSerializer(typeof(WsHealthCareClaimStatus));

            List<string> docIds = new List<string>();

            try
            {
                WsHealthCareClaimStatus[] claimStatusValues = new WsHealthCareClaimStatus[] { };

                if (version == ApiVersion.V3)
                {
                    if (comboBoxBinding.SelectedItem != null)
                    {
                        var url = ((System.ServiceModel.Configuration.ChannelEndpointElement)comboBoxBinding
                            .SelectedItem).Address.ToString();
                        string results = ApiV3.GetClaimStatusByDate(_key_15, _pwd_15, vendorSiteId, url, dateTimePickerFrom.Value,
                            dateTimePickerTo.Value);

                        if (!string.IsNullOrWhiteSpace(results))
                        {
                            claimStatusValues = JsonConvert.DeserializeObject<List<WsHealthCareClaimStatus>>(results).ToArray();
                        }
                    }

                }
                else
                {

                    claimStatusValues = this.client15.GetClaimStatusByDate(_key_15, _pwd_15, vendorSiteId,
                        dateTimePickerFrom.Value, dateTimePickerTo.Value);
                }


                int idx = 0;
                foreach (WsHealthCareClaimStatus claimStatus in claimStatusValues)
                {
                    if (string.IsNullOrEmpty(claimStatus.RelatedDocumentId) == false)
                    {
                        docIds.Add(claimStatus.RelatedDocumentId);
                    }

                    if (checkBoxSerializeStatusToFile.Checked)
                    {
                        var path = Path.Combine(AppDomain.CurrentDomain.BaseDirectory, string.Format("ClaimStatusDoc-{0}_{1:000}_{2}_[{3}]_{4}.xml", _vendorSiteId,
                                                              ++idx,
                                                              claimStatus.ClaimNumber,
                                                              claimStatus.VendorClaimId,
                                                              (claimStatus.LastUpdateDate ?? DateTime.MinValue).ToString("yyyyMMddHHmmssfff")));


                        FileStream file = File.Create(path);
                        serializer.Serialize(file, claimStatus);
                        file.Close();
                    }
                }

            }
            catch (Exception ex)
            {
                MessageBox.Show($"{ex.Message}");
            }

            try
            {
                if (docIds.Count == 0)
                {
                    return;
                }

                WsPayerResponseDocuments responses = null;

                if (version == ApiVersion.V3)
                {
                    if (comboBoxBinding.SelectedItem != null)
                    {
                        var url = ((System.ServiceModel.Configuration.ChannelEndpointElement)comboBoxBinding
                            .SelectedItem).Address.ToString();
                        string results = ApiV3.GetPayerResponseDocuments(_key_15, _pwd_15, vendorSiteId, url,
                            docIds.ToArray());

                        if (!string.IsNullOrWhiteSpace(results))
                        {
                            responses = JsonConvert.DeserializeObject <WsPayerResponseDocuments>(results);
                        }
                    }

                }
                else
                {
                    responses = 
                        client15.GetPayerResponseDocuments(_key_15, _pwd_15, docIds.ToArray());
                }

                if (responses != null && responses.RemittanceAdvices.Length > 0) // && checkBoxSerializeReponseFiles.Checked)
                {
                    int idx = 0;
                    serializer = new XmlSerializer(typeof (WsRemittanceAdvice));

	                XmlDocument xmlDoc = new XmlDocument();

                    Stopwatch sw1 = new Stopwatch();

                    //resultsControlMain.GridViewPanel.Visible = false;
                    //resultsControlMain.Update();
                    //resultsControlMain.TreeViewPanel.Visible = true;
                    // resultsControlMain.Resu

                    if (viewV3ResultsAsJson && version == ApiVersion.V3)
                    {
                        var jsonRemittances = JsonConvert.SerializeObject(responses.RemittanceAdvices, Formatting.Indented);

                        prepareJsonResultsView();
                        resultsControlMain.RichTextBox1.Text = jsonRemittances;
                    }
                    else
                    {


                        sw1.Start();
                        resultsControlMain.TreeViewResults.BeginUpdate();

                        //resultsControlMain.TreeViewResults.Nodes.Clear();
                        //resultsControlMain.TreeViewResults.Nodes.Add(new TreeNode("Remittances"));

                        var remittances = responses.RemittanceAdvices.ToList().OrderByDescending(r => r.CreateDate);
                        foreach (WsRemittanceAdvice eob in remittances)
                        {
                            if (checkBoxSerializeReponseFiles.Checked)
                            {
	                            var path = Path.Combine(AppDomain.CurrentDomain.BaseDirectory,
		                            $"835Output-{_vendorSiteId}_{++idx:000}_[{eob.VendorClaimId}]_{(eob.CreateDate ?? DateTime.MinValue).ToString("yyyyMMddHHmmssfff")}_{eob.VendorClaimId}");
                                    //string.Format("835Output-{0}_{1:000}_[{2}]_{3}.xml", _vendorSiteId, ++idx,
                                        //eob.VendorClaimId,
                                        //(eob.CreateDate ?? DateTime.MinValue).ToString(
                                        //    "yyyyMMddHHmmssfff")));

                                FileStream file = File.Create(path);
                                serializer.Serialize(file, eob);
                                file.Flush();
                                file.Close();
                            }

                            using (MemoryStream memoryStream = new MemoryStream())
                            {
                                serializer.Serialize(memoryStream, eob);
                                memoryStream.Flush();
                                memoryStream.Seek(0, SeekOrigin.Begin);

                                xmlDoc.Load(memoryStream);
                            }

                            var tNode = resultsControlMain.TreeViewResults.Nodes[0];
                            int nodeIdx =
                                tNode.Nodes.Add(new TreeNode($"ERA: {eob.CreateDate.ToString()}-{eob.Payer.Name}-{eob.VendorClaimId}"));

                            AddNode(xmlDoc.DocumentElement, tNode.Nodes[nodeIdx]);

                        }

                        resultsControlMain.TreeViewResults.Nodes[0].Expand();
                        resultsControlMain.TreeViewResults.EndUpdate();

                        sw1.Stop();
                    }


                }

                if (responses.PayerClaimStatuses.Length > 0) // && checkBoxSerializeReponseFiles.Checked)
                {
                    int idx = 0;
                    XmlDocument xmlDoc = new XmlDocument();

                    if (viewV3ResultsAsJson && version == ApiVersion.V3)
                    {
                        var jsonStatuses = JsonConvert.SerializeObject(responses.PayerClaimStatuses, Formatting.Indented);

                        prepareJsonResultsView();
                        resultsControlMain.RichTextBox2.Text = jsonStatuses;
                    }
                    else
                    {

                        Stopwatch sw1 = new Stopwatch();
                        sw1.Start();
                        resultsControlMain.TreeViewResults2.BeginUpdate();

                        //resultsControlMain.TreeViewResults2.Nodes.Clear();
                        //resultsControlMain.TreeViewResults2.Nodes.Add(new TreeNode("Claim Statuses"));

                        serializer = new XmlSerializer(typeof(WsPayerClaimStatus));
                        var claimStatuses = responses.PayerClaimStatuses.ToList()
                            .OrderByDescending(cs => cs.CreateDate);
                        foreach (WsPayerClaimStatus claimStatus in claimStatuses)
                        {
                            if (checkBoxSerializeStatusToFile.Checked)
                            {
                                var path = Path.Combine(AppDomain.CurrentDomain.BaseDirectory,
                                    string.Format("277Output-{0}_{1:000}_{2}_[{3}]_{4}.xml", _vendorSiteId, ++idx,
                                        claimStatus.VendorClaimId,
                                        claimStatus.ClearinghouseControlNumber,
                                        (claimStatus.CreateDate ?? DateTime.MinValue).ToString(
                                            "yyyyMMddHHmmssfff")));
                                FileStream file = File.Create(path);

                                serializer.Serialize(file, claimStatus);
                                file.Close();
                            }

                            using (MemoryStream memoryStream = new MemoryStream())
                            {
                                serializer.Serialize(memoryStream, claimStatus);
                                memoryStream.Flush();
                                memoryStream.Seek(0, SeekOrigin.Begin);

                                xmlDoc.Load(memoryStream);
                            }

                            var tNode = resultsControlMain.TreeViewResults2.Nodes[0];
                            if (claimStatus.Patient == null)
                            {
                                claimStatus.Patient = new WsPatient();
                            }

                            int nodeIdx = tNode.Nodes.Add(new TreeNode(
                                $"CS: {claimStatus.CreateDate.ToString()}-{claimStatus.Patient.CommonName}-{claimStatus.ClearinghouseControlNumber}"));

                            AddNode(xmlDoc.DocumentElement, tNode.Nodes[nodeIdx]);

                        }

                        resultsControlMain.TreeViewResults2.Nodes[0].Expand();
                        resultsControlMain.TreeViewResults2.EndUpdate();

                        sw1.Stop();
                    }

                }

                resultsControlMain.UpdateTreeHeaders();
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.ToString());
            }

            Cursor.Current = Cursors.Default;
        }

        private void initV3Client()
        {
            if (clientV3 == null)
            {
                clientV3 = new ApiV3(textBoxKey.Text, textBoxPassword.Text, textBoxVendorSiteID.Text, comboBoxBinding.SelectedText);
            }
        }

        private void buttonEligibility_Click(object sender, EventArgs e)
        {
            var benefitForm = new BenefitRequestForm(_key_15, _pwd_15, _vendorSiteId);
            benefitForm.ShowDialog();
        }

        private void textBoxKey_TextChanged(object sender, EventArgs e)
        {
            _key_15 = textBoxKey.Text;
        }

        private void textBoxPassword_TextChanged(object sender, EventArgs e)
        {
            _pwd_15 = textBoxPassword.Text;
        }

        private void textBoxVendorSiteID_TextChanged(object sender, EventArgs e)
        {
            _vendorSiteId = textBoxVendorSiteID.Text;
        }

        private void buttonSaveSettings_Click(object sender, EventArgs e)
        {
            Configuration config = ConfigurationManager.OpenExeConfiguration(Application.ExecutablePath);
            config.AppSettings.Settings[ConfigKeys.key15].Value = _key_15;
            config.AppSettings.Settings[ConfigKeys.password15].Value = _pwd_15;
            config.AppSettings.Settings[ConfigKeys.vendorSiteId].Value = _vendorSiteId;
            config.AppSettings.Settings[ConfigKeys.writeSerializedXml].Value =
                checkBoxSerializeReponseFiles.Checked.ToString();
            config.AppSettings.Settings[ConfigKeys.writeStatus].Value =
                checkBoxSerializeStatusToFile.Checked.ToString();
			config.AppSettings.Settings[ConfigKeys.apiVersion].Value = radioButtonV15.Checked ? radioButtonV15.Tag as string : radioButtonV3.Tag as string;

            var endpointElement = comboBoxBinding.SelectedItem as ChannelEndpointElement;
            if (null != endpointElement)
            {
                config.AppSettings.Settings[ConfigKeys.lastBinding].Value = endpointElement.Address.ToString();
            }

            config.Save(ConfigurationSaveMode.Modified);
        }

        private void comboBoxBinding_SelectedIndexChanged(object sender, EventArgs e)
        {
            var endpoint = comboBoxBinding.SelectedItem as ChannelEndpointElement;

            client15 = _clientHelper.ChangeBinding(endpoint);
        }

        private void DeserializeEra()
        {
            EraDeserializer eraDeserializer = new EraDeserializer();
            eraDeserializer.DoIt();
        }

        private void checkBoxViewJsonForV3_CheckedChanged(object sender, EventArgs e)
        {
            if (sender is CheckBox)
            {
                viewV3ResultsAsJson = ((CheckBox) sender).Checked;
            }
        }
    }
}

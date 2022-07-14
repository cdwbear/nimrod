namespace ApexWebServiceToolV2
{
    partial class MainForm
    {
        /// <summary>
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code

        /// <summary>
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
			System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(MainForm));
			this.button_1_5_GetPayers = new System.Windows.Forms.Button();
			this.tableLayoutPanelBase = new System.Windows.Forms.TableLayoutPanel();
			this.tableLayoutPanelAPIs = new System.Windows.Forms.TableLayoutPanel();
			this.groupBoxApi = new System.Windows.Forms.GroupBox();
			this.textBoxClaimIdFilter = new System.Windows.Forms.TextBox();
			this.checkBoxClaimIdFilter = new System.Windows.Forms.CheckBox();
			this.checkBoxViewJsonForV3 = new System.Windows.Forms.CheckBox();
			this.groupBoxApiSelector = new System.Windows.Forms.GroupBox();
			this.radioButtonV3 = new System.Windows.Forms.RadioButton();
			this.radioButtonV15 = new System.Windows.Forms.RadioButton();
			this.checkBoxSerializeStatusToFile = new System.Windows.Forms.CheckBox();
			this.checkBoxSerializeReponseFiles = new System.Windows.Forms.CheckBox();
			this.labelTo = new System.Windows.Forms.Label();
			this.labelFrom = new System.Windows.Forms.Label();
			this.dateTimePickerTo = new System.Windows.Forms.DateTimePicker();
			this.dateTimePickerFrom = new System.Windows.Forms.DateTimePicker();
			this.groupBoxGetPayers = new System.Windows.Forms.GroupBox();
			this.radioButtonDental = new System.Windows.Forms.RadioButton();
			this.radioButtonPayerMedicaid = new System.Windows.Forms.RadioButton();
			this.radioButtonPayerMedical = new System.Windows.Forms.RadioButton();
			this.buttonGetTestPayers = new System.Windows.Forms.Button();
			this.listBoxClaimFiles = new System.Windows.Forms.ListBox();
			this.button1 = new System.Windows.Forms.Button();
			this.buttonGetClaimStatusByDate = new System.Windows.Forms.Button();
			this.buttonGetFile = new System.Windows.Forms.Button();
			this.buttonSubmitClaimsAsync = new System.Windows.Forms.Button();
			this.buttonSubmitClaims = new System.Windows.Forms.Button();
			this.labelFile = new System.Windows.Forms.Label();
			this.groupBoxSettings = new System.Windows.Forms.GroupBox();
			this.tableLayoutPanel1 = new System.Windows.Forms.TableLayoutPanel();
			this.labelKey = new System.Windows.Forms.Label();
			this.buttonSaveSettings = new System.Windows.Forms.Button();
			this.comboBoxBinding = new System.Windows.Forms.ComboBox();
			this.labelBinding = new System.Windows.Forms.Label();
			this.textBoxKey = new System.Windows.Forms.TextBox();
			this.label3 = new System.Windows.Forms.Label();
			this.textBoxPassword = new System.Windows.Forms.TextBox();
			this.buttonEligibility = new System.Windows.Forms.Button();
			this.textBoxVendorSiteID = new System.Windows.Forms.TextBox();
			this.label2 = new System.Windows.Forms.Label();
			this.resultsControlMain = new CommonControls.ResultsControl();
			this.openFileDialog1 = new System.Windows.Forms.OpenFileDialog();
			this.menuStrip1 = new System.Windows.Forms.MenuStrip();
			this.toolsToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
			this.changeCredentialsToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
			this.exportResultsToCSVToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
			this.tableLayoutPanelBase.SuspendLayout();
			this.tableLayoutPanelAPIs.SuspendLayout();
			this.groupBoxApi.SuspendLayout();
			this.groupBoxApiSelector.SuspendLayout();
			this.groupBoxGetPayers.SuspendLayout();
			this.groupBoxSettings.SuspendLayout();
			this.tableLayoutPanel1.SuspendLayout();
			this.menuStrip1.SuspendLayout();
			this.SuspendLayout();
			// 
			// button_1_5_GetPayers
			// 
			this.button_1_5_GetPayers.Location = new System.Drawing.Point(0, 34);
			this.button_1_5_GetPayers.Name = "button_1_5_GetPayers";
			this.button_1_5_GetPayers.Size = new System.Drawing.Size(126, 23);
			this.button_1_5_GetPayers.TabIndex = 0;
			this.button_1_5_GetPayers.Text = "GetPayers";
			this.button_1_5_GetPayers.UseVisualStyleBackColor = true;
			this.button_1_5_GetPayers.Click += new System.EventHandler(this.button_1_5_GetPayers_Click);
			// 
			// tableLayoutPanelBase
			// 
			this.tableLayoutPanelBase.ColumnCount = 1;
			this.tableLayoutPanelBase.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 100F));
			this.tableLayoutPanelBase.Controls.Add(this.tableLayoutPanelAPIs, 0, 0);
			this.tableLayoutPanelBase.Controls.Add(this.resultsControlMain, 0, 1);
			this.tableLayoutPanelBase.Dock = System.Windows.Forms.DockStyle.Fill;
			this.tableLayoutPanelBase.Location = new System.Drawing.Point(0, 24);
			this.tableLayoutPanelBase.Name = "tableLayoutPanelBase";
			this.tableLayoutPanelBase.RowCount = 2;
			this.tableLayoutPanelBase.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 225F));
			this.tableLayoutPanelBase.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 100F));
			this.tableLayoutPanelBase.Size = new System.Drawing.Size(1056, 777);
			this.tableLayoutPanelBase.TabIndex = 2;
			// 
			// tableLayoutPanelAPIs
			// 
			this.tableLayoutPanelAPIs.ColumnCount = 2;
			this.tableLayoutPanelAPIs.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 49.14286F));
			this.tableLayoutPanelAPIs.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 50.85714F));
			this.tableLayoutPanelAPIs.Controls.Add(this.groupBoxApi, 0, 0);
			this.tableLayoutPanelAPIs.Controls.Add(this.groupBoxSettings, 1, 0);
			this.tableLayoutPanelAPIs.Dock = System.Windows.Forms.DockStyle.Fill;
			this.tableLayoutPanelAPIs.Location = new System.Drawing.Point(3, 3);
			this.tableLayoutPanelAPIs.Name = "tableLayoutPanelAPIs";
			this.tableLayoutPanelAPIs.RowCount = 1;
			this.tableLayoutPanelAPIs.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 50F));
			this.tableLayoutPanelAPIs.Size = new System.Drawing.Size(1050, 219);
			this.tableLayoutPanelAPIs.TabIndex = 2;
			// 
			// groupBoxApi
			// 
			this.groupBoxApi.Controls.Add(this.textBoxClaimIdFilter);
			this.groupBoxApi.Controls.Add(this.checkBoxClaimIdFilter);
			this.groupBoxApi.Controls.Add(this.checkBoxViewJsonForV3);
			this.groupBoxApi.Controls.Add(this.groupBoxApiSelector);
			this.groupBoxApi.Controls.Add(this.checkBoxSerializeStatusToFile);
			this.groupBoxApi.Controls.Add(this.checkBoxSerializeReponseFiles);
			this.groupBoxApi.Controls.Add(this.labelTo);
			this.groupBoxApi.Controls.Add(this.labelFrom);
			this.groupBoxApi.Controls.Add(this.dateTimePickerTo);
			this.groupBoxApi.Controls.Add(this.dateTimePickerFrom);
			this.groupBoxApi.Controls.Add(this.groupBoxGetPayers);
			this.groupBoxApi.Controls.Add(this.listBoxClaimFiles);
			this.groupBoxApi.Controls.Add(this.button1);
			this.groupBoxApi.Controls.Add(this.buttonGetClaimStatusByDate);
			this.groupBoxApi.Controls.Add(this.buttonGetFile);
			this.groupBoxApi.Controls.Add(this.buttonSubmitClaimsAsync);
			this.groupBoxApi.Controls.Add(this.buttonSubmitClaims);
			this.groupBoxApi.Controls.Add(this.labelFile);
			this.groupBoxApi.Dock = System.Windows.Forms.DockStyle.Fill;
			this.groupBoxApi.Location = new System.Drawing.Point(3, 3);
			this.groupBoxApi.Name = "groupBoxApi";
			this.groupBoxApi.Size = new System.Drawing.Size(510, 213);
			this.groupBoxApi.TabIndex = 0;
			this.groupBoxApi.TabStop = false;
			this.groupBoxApi.Text = "API";
			// 
			// textBoxClaimIdFilter
			// 
			this.textBoxClaimIdFilter.Location = new System.Drawing.Point(124, 184);
			this.textBoxClaimIdFilter.Name = "textBoxClaimIdFilter";
			this.textBoxClaimIdFilter.Size = new System.Drawing.Size(261, 20);
			this.textBoxClaimIdFilter.TabIndex = 15;
			// 
			// checkBoxClaimIdFilter
			// 
			this.checkBoxClaimIdFilter.AutoSize = true;
			this.checkBoxClaimIdFilter.Enabled = false;
			this.checkBoxClaimIdFilter.Location = new System.Drawing.Point(6, 187);
			this.checkBoxClaimIdFilter.Name = "checkBoxClaimIdFilter";
			this.checkBoxClaimIdFilter.Size = new System.Drawing.Size(116, 17);
			this.checkBoxClaimIdFilter.TabIndex = 14;
			this.checkBoxClaimIdFilter.Text = "Filter By Claim ID(s)";
			this.checkBoxClaimIdFilter.UseVisualStyleBackColor = true;
			// 
			// checkBoxViewJsonForV3
			// 
			this.checkBoxViewJsonForV3.AutoSize = true;
			this.checkBoxViewJsonForV3.Enabled = false;
			this.checkBoxViewJsonForV3.Location = new System.Drawing.Point(285, 19);
			this.checkBoxViewJsonForV3.Name = "checkBoxViewJsonForV3";
			this.checkBoxViewJsonForV3.Size = new System.Drawing.Size(163, 17);
			this.checkBoxViewJsonForV3.TabIndex = 13;
			this.checkBoxViewJsonForV3.Text = "View Results as JSON for V3";
			this.checkBoxViewJsonForV3.UseVisualStyleBackColor = true;
			this.checkBoxViewJsonForV3.CheckedChanged += new System.EventHandler(this.checkBoxViewJsonForV3_CheckedChanged);
			// 
			// groupBoxApiSelector
			// 
			this.groupBoxApiSelector.Controls.Add(this.radioButtonV3);
			this.groupBoxApiSelector.Controls.Add(this.radioButtonV15);
			this.groupBoxApiSelector.Location = new System.Drawing.Point(6, 10);
			this.groupBoxApiSelector.Margin = new System.Windows.Forms.Padding(0);
			this.groupBoxApiSelector.Name = "groupBoxApiSelector";
			this.groupBoxApiSelector.Padding = new System.Windows.Forms.Padding(0);
			this.groupBoxApiSelector.Size = new System.Drawing.Size(200, 29);
			this.groupBoxApiSelector.TabIndex = 12;
			this.groupBoxApiSelector.TabStop = false;
			// 
			// radioButtonV3
			// 
			this.radioButtonV3.AutoSize = true;
			this.radioButtonV3.Location = new System.Drawing.Point(93, 6);
			this.radioButtonV3.Margin = new System.Windows.Forms.Padding(0);
			this.radioButtonV3.Name = "radioButtonV3";
			this.radioButtonV3.Size = new System.Drawing.Size(113, 17);
			this.radioButtonV3.TabIndex = 0;
			this.radioButtonV3.Tag = "V3";
			this.radioButtonV3.Text = "V 3 (REST, JSON)";
			this.radioButtonV3.UseVisualStyleBackColor = true;
			this.radioButtonV3.CheckedChanged += new System.EventHandler(this.RadioButtonApiVersion_CheckedChanged);
			// 
			// radioButtonV15
			// 
			this.radioButtonV15.AutoSize = true;
			this.radioButtonV15.Checked = true;
			this.radioButtonV15.Location = new System.Drawing.Point(0, 6);
			this.radioButtonV15.Margin = new System.Windows.Forms.Padding(0);
			this.radioButtonV15.Name = "radioButtonV15";
			this.radioButtonV15.Size = new System.Drawing.Size(88, 17);
			this.radioButtonV15.TabIndex = 0;
			this.radioButtonV15.TabStop = true;
			this.radioButtonV15.Tag = "V1.5";
			this.radioButtonV15.Text = "V 1.5 (SOAP)";
			this.radioButtonV15.UseVisualStyleBackColor = true;
			this.radioButtonV15.CheckedChanged += new System.EventHandler(this.RadioButtonApiVersion_CheckedChanged);
			// 
			// checkBoxSerializeStatusToFile
			// 
			this.checkBoxSerializeStatusToFile.AutoSize = true;
			this.checkBoxSerializeStatusToFile.Location = new System.Drawing.Point(6, 164);
			this.checkBoxSerializeStatusToFile.Name = "checkBoxSerializeStatusToFile";
			this.checkBoxSerializeStatusToFile.Size = new System.Drawing.Size(202, 17);
			this.checkBoxSerializeStatusToFile.TabIndex = 11;
			this.checkBoxSerializeStatusToFile.Text = "Write Serialized Status Objects to File";
			this.checkBoxSerializeStatusToFile.UseVisualStyleBackColor = true;
			// 
			// checkBoxSerializeReponseFiles
			// 
			this.checkBoxSerializeReponseFiles.AutoSize = true;
			this.checkBoxSerializeReponseFiles.Location = new System.Drawing.Point(285, 164);
			this.checkBoxSerializeReponseFiles.Name = "checkBoxSerializeReponseFiles";
			this.checkBoxSerializeReponseFiles.Size = new System.Drawing.Size(211, 17);
			this.checkBoxSerializeReponseFiles.TabIndex = 10;
			this.checkBoxSerializeReponseFiles.Text = "Write Serialized XML Responses to File";
			this.checkBoxSerializeReponseFiles.UseVisualStyleBackColor = true;
			// 
			// labelTo
			// 
			this.labelTo.AutoSize = true;
			this.labelTo.Location = new System.Drawing.Point(144, 136);
			this.labelTo.Name = "labelTo";
			this.labelTo.Size = new System.Drawing.Size(23, 13);
			this.labelTo.TabIndex = 8;
			this.labelTo.Text = "To:";
			// 
			// labelFrom
			// 
			this.labelFrom.AutoSize = true;
			this.labelFrom.Location = new System.Drawing.Point(134, 114);
			this.labelFrom.Name = "labelFrom";
			this.labelFrom.Size = new System.Drawing.Size(33, 13);
			this.labelFrom.TabIndex = 8;
			this.labelFrom.Text = "From:";
			// 
			// dateTimePickerTo
			// 
			this.dateTimePickerTo.CustomFormat = "MM/dd/yyyy";
			this.dateTimePickerTo.Format = System.Windows.Forms.DateTimePickerFormat.Custom;
			this.dateTimePickerTo.Location = new System.Drawing.Point(171, 134);
			this.dateTimePickerTo.Name = "dateTimePickerTo";
			this.dateTimePickerTo.Size = new System.Drawing.Size(95, 20);
			this.dateTimePickerTo.TabIndex = 7;
			// 
			// dateTimePickerFrom
			// 
			this.dateTimePickerFrom.CustomFormat = "MM/dd/yyyy";
			this.dateTimePickerFrom.Format = System.Windows.Forms.DateTimePickerFormat.Custom;
			this.dateTimePickerFrom.Location = new System.Drawing.Point(171, 111);
			this.dateTimePickerFrom.Name = "dateTimePickerFrom";
			this.dateTimePickerFrom.Size = new System.Drawing.Size(95, 20);
			this.dateTimePickerFrom.TabIndex = 7;
			// 
			// groupBoxGetPayers
			// 
			this.groupBoxGetPayers.Controls.Add(this.radioButtonDental);
			this.groupBoxGetPayers.Controls.Add(this.radioButtonPayerMedicaid);
			this.groupBoxGetPayers.Controls.Add(this.radioButtonPayerMedical);
			this.groupBoxGetPayers.Controls.Add(this.buttonGetTestPayers);
			this.groupBoxGetPayers.Controls.Add(this.button_1_5_GetPayers);
			this.groupBoxGetPayers.Location = new System.Drawing.Point(6, 45);
			this.groupBoxGetPayers.Name = "groupBoxGetPayers";
			this.groupBoxGetPayers.Size = new System.Drawing.Size(265, 61);
			this.groupBoxGetPayers.TabIndex = 3;
			this.groupBoxGetPayers.TabStop = false;
			this.groupBoxGetPayers.Text = "Payers";
			// 
			// radioButtonDental
			// 
			this.radioButtonDental.AutoSize = true;
			this.radioButtonDental.Location = new System.Drawing.Point(154, 11);
			this.radioButtonDental.Name = "radioButtonDental";
			this.radioButtonDental.Size = new System.Drawing.Size(56, 17);
			this.radioButtonDental.TabIndex = 1;
			this.radioButtonDental.Text = "Dental";
			this.radioButtonDental.UseVisualStyleBackColor = true;
			// 
			// radioButtonPayerMedicaid
			// 
			this.radioButtonPayerMedicaid.AutoSize = true;
			this.radioButtonPayerMedicaid.Enabled = false;
			this.radioButtonPayerMedicaid.Location = new System.Drawing.Point(74, 11);
			this.radioButtonPayerMedicaid.Name = "radioButtonPayerMedicaid";
			this.radioButtonPayerMedicaid.Size = new System.Drawing.Size(68, 17);
			this.radioButtonPayerMedicaid.TabIndex = 1;
			this.radioButtonPayerMedicaid.Text = "Medicaid";
			this.radioButtonPayerMedicaid.UseVisualStyleBackColor = true;
			// 
			// radioButtonPayerMedical
			// 
			this.radioButtonPayerMedical.AutoSize = true;
			this.radioButtonPayerMedical.Checked = true;
			this.radioButtonPayerMedical.Location = new System.Drawing.Point(0, 11);
			this.radioButtonPayerMedical.Name = "radioButtonPayerMedical";
			this.radioButtonPayerMedical.Size = new System.Drawing.Size(62, 17);
			this.radioButtonPayerMedical.TabIndex = 1;
			this.radioButtonPayerMedical.TabStop = true;
			this.radioButtonPayerMedical.Text = "Medical";
			this.radioButtonPayerMedical.UseVisualStyleBackColor = true;
			// 
			// buttonGetTestPayers
			// 
			this.buttonGetTestPayers.Location = new System.Drawing.Point(135, 34);
			this.buttonGetTestPayers.Name = "buttonGetTestPayers";
			this.buttonGetTestPayers.Size = new System.Drawing.Size(126, 23);
			this.buttonGetTestPayers.TabIndex = 0;
			this.buttonGetTestPayers.Text = "GetTestPayers";
			this.buttonGetTestPayers.UseVisualStyleBackColor = true;
			this.buttonGetTestPayers.Click += new System.EventHandler(this.buttonGetTestPayers_Click);
			// 
			// listBoxClaimFiles
			// 
			this.listBoxClaimFiles.Location = new System.Drawing.Point(285, 79);
			this.listBoxClaimFiles.Name = "listBoxClaimFiles";
			this.listBoxClaimFiles.SelectionMode = System.Windows.Forms.SelectionMode.MultiExtended;
			this.listBoxClaimFiles.Size = new System.Drawing.Size(207, 43);
			this.listBoxClaimFiles.TabIndex = 6;
			// 
			// button1
			// 
			this.button1.Location = new System.Drawing.Point(6, 108);
			this.button1.Name = "button1";
			this.button1.Size = new System.Drawing.Size(123, 23);
			this.button1.TabIndex = 0;
			this.button1.Text = "GetClaimStatusByDate";
			this.button1.UseVisualStyleBackColor = true;
			this.button1.Click += new System.EventHandler(this.buttonGetClaimStatus_Click_1_5);
			// 
			// buttonGetClaimStatusByDate
			// 
			this.buttonGetClaimStatusByDate.Location = new System.Drawing.Point(6, 130);
			this.buttonGetClaimStatusByDate.Name = "buttonGetClaimStatusByDate";
			this.buttonGetClaimStatusByDate.Size = new System.Drawing.Size(123, 23);
			this.buttonGetClaimStatusByDate.TabIndex = 0;
			this.buttonGetClaimStatusByDate.Text = "GetPayerDocsByDate";
			this.buttonGetClaimStatusByDate.UseVisualStyleBackColor = true;
			this.buttonGetClaimStatusByDate.Click += new System.EventHandler(this.buttonGetPayerDocs_Click_1_5);
			// 
			// buttonGetFile
			// 
			this.buttonGetFile.Location = new System.Drawing.Point(285, 50);
			this.buttonGetFile.Name = "buttonGetFile";
			this.buttonGetFile.Size = new System.Drawing.Size(27, 23);
			this.buttonGetFile.TabIndex = 5;
			this.buttonGetFile.Text = "...";
			this.buttonGetFile.UseVisualStyleBackColor = true;
			this.buttonGetFile.Click += new System.EventHandler(this.buttonGetFile_Click);
			// 
			// buttonSubmitClaimsAsync
			// 
			this.buttonSubmitClaimsAsync.AutoSize = true;
			this.buttonSubmitClaimsAsync.Location = new System.Drawing.Point(380, 130);
			this.buttonSubmitClaimsAsync.Name = "buttonSubmitClaimsAsync";
			this.buttonSubmitClaimsAsync.Size = new System.Drawing.Size(112, 23);
			this.buttonSubmitClaimsAsync.TabIndex = 0;
			this.buttonSubmitClaimsAsync.Text = "SubmitClaimsAsync";
			this.buttonSubmitClaimsAsync.UseVisualStyleBackColor = true;
			this.buttonSubmitClaimsAsync.Click += new System.EventHandler(this.buttonSubmitClaimsAsync_Click);
			// 
			// buttonSubmitClaims
			// 
			this.buttonSubmitClaims.AutoSize = true;
			this.buttonSubmitClaims.Location = new System.Drawing.Point(285, 130);
			this.buttonSubmitClaims.Name = "buttonSubmitClaims";
			this.buttonSubmitClaims.Size = new System.Drawing.Size(89, 23);
			this.buttonSubmitClaims.TabIndex = 0;
			this.buttonSubmitClaims.Text = "SubmitClaims";
			this.buttonSubmitClaims.UseVisualStyleBackColor = true;
			this.buttonSubmitClaims.Click += new System.EventHandler(this.buttonSubmitClaims_Click);
			// 
			// labelFile
			// 
			this.labelFile.AutoSize = true;
			this.labelFile.Location = new System.Drawing.Point(318, 55);
			this.labelFile.Name = "labelFile";
			this.labelFile.Size = new System.Drawing.Size(118, 13);
			this.labelFile.TabIndex = 4;
			this.labelFile.Text = "Select Claim Batch File:";
			// 
			// groupBoxSettings
			// 
			this.groupBoxSettings.Controls.Add(this.tableLayoutPanel1);
			this.groupBoxSettings.Dock = System.Windows.Forms.DockStyle.Fill;
			this.groupBoxSettings.Location = new System.Drawing.Point(519, 3);
			this.groupBoxSettings.Name = "groupBoxSettings";
			this.groupBoxSettings.Size = new System.Drawing.Size(528, 213);
			this.groupBoxSettings.TabIndex = 1;
			this.groupBoxSettings.TabStop = false;
			this.groupBoxSettings.Text = "Settings";
			// 
			// tableLayoutPanel1
			// 
			this.tableLayoutPanel1.ColumnCount = 2;
			this.tableLayoutPanel1.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 39.46587F));
			this.tableLayoutPanel1.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 60.53413F));
			this.tableLayoutPanel1.Controls.Add(this.labelKey, 0, 0);
			this.tableLayoutPanel1.Controls.Add(this.buttonSaveSettings, 1, 4);
			this.tableLayoutPanel1.Controls.Add(this.comboBoxBinding, 1, 3);
			this.tableLayoutPanel1.Controls.Add(this.labelBinding, 0, 3);
			this.tableLayoutPanel1.Controls.Add(this.textBoxKey, 1, 0);
			this.tableLayoutPanel1.Controls.Add(this.label3, 0, 1);
			this.tableLayoutPanel1.Controls.Add(this.textBoxPassword, 1, 1);
			this.tableLayoutPanel1.Controls.Add(this.buttonEligibility, 0, 4);
			this.tableLayoutPanel1.Controls.Add(this.textBoxVendorSiteID, 1, 2);
			this.tableLayoutPanel1.Controls.Add(this.label2, 0, 2);
			this.tableLayoutPanel1.Dock = System.Windows.Forms.DockStyle.Fill;
			this.tableLayoutPanel1.Location = new System.Drawing.Point(3, 16);
			this.tableLayoutPanel1.Name = "tableLayoutPanel1";
			this.tableLayoutPanel1.RowCount = 6;
			this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle());
			this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle());
			this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle());
			this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle());
			this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle());
			this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 20F));
			this.tableLayoutPanel1.Size = new System.Drawing.Size(522, 194);
			this.tableLayoutPanel1.TabIndex = 10;
			// 
			// labelKey
			// 
			this.labelKey.Anchor = System.Windows.Forms.AnchorStyles.Right;
			this.labelKey.AutoSize = true;
			this.labelKey.Location = new System.Drawing.Point(138, 6);
			this.labelKey.Name = "labelKey";
			this.labelKey.Size = new System.Drawing.Size(65, 13);
			this.labelKey.TabIndex = 1;
			this.labelKey.Text = "Vendor Key:";
			// 
			// buttonSaveSettings
			// 
			this.buttonSaveSettings.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
			this.buttonSaveSettings.Location = new System.Drawing.Point(372, 108);
			this.buttonSaveSettings.Name = "buttonSaveSettings";
			this.buttonSaveSettings.Size = new System.Drawing.Size(147, 23);
			this.buttonSaveSettings.TabIndex = 7;
			this.buttonSaveSettings.Text = "Save Settings";
			this.buttonSaveSettings.UseVisualStyleBackColor = true;
			this.buttonSaveSettings.Click += new System.EventHandler(this.buttonSaveSettings_Click);
			// 
			// comboBoxBinding
			// 
			this.comboBoxBinding.Dock = System.Windows.Forms.DockStyle.Fill;
			this.comboBoxBinding.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
			this.comboBoxBinding.FormattingEnabled = true;
			this.comboBoxBinding.Location = new System.Drawing.Point(209, 81);
			this.comboBoxBinding.Name = "comboBoxBinding";
			this.comboBoxBinding.Size = new System.Drawing.Size(310, 21);
			this.comboBoxBinding.TabIndex = 8;
			// 
			// labelBinding
			// 
			this.labelBinding.Anchor = System.Windows.Forms.AnchorStyles.Right;
			this.labelBinding.AutoSize = true;
			this.labelBinding.Location = new System.Drawing.Point(114, 85);
			this.labelBinding.Name = "labelBinding";
			this.labelBinding.Size = new System.Drawing.Size(89, 13);
			this.labelBinding.TabIndex = 9;
			this.labelBinding.Text = "Current Endpoint:";
			// 
			// textBoxKey
			// 
			this.textBoxKey.Dock = System.Windows.Forms.DockStyle.Fill;
			this.textBoxKey.Location = new System.Drawing.Point(209, 3);
			this.textBoxKey.Name = "textBoxKey";
			this.textBoxKey.Size = new System.Drawing.Size(310, 20);
			this.textBoxKey.TabIndex = 2;
			this.textBoxKey.TextChanged += new System.EventHandler(this.textBoxKey_TextChanged);
			// 
			// label3
			// 
			this.label3.Anchor = System.Windows.Forms.AnchorStyles.Right;
			this.label3.AutoSize = true;
			this.label3.Location = new System.Drawing.Point(110, 32);
			this.label3.Name = "label3";
			this.label3.Size = new System.Drawing.Size(93, 13);
			this.label3.TabIndex = 1;
			this.label3.Text = "Vendor Password:";
			// 
			// textBoxPassword
			// 
			this.textBoxPassword.Dock = System.Windows.Forms.DockStyle.Fill;
			this.textBoxPassword.Location = new System.Drawing.Point(209, 29);
			this.textBoxPassword.Name = "textBoxPassword";
			this.textBoxPassword.Size = new System.Drawing.Size(310, 20);
			this.textBoxPassword.TabIndex = 2;
			this.textBoxPassword.TextChanged += new System.EventHandler(this.textBoxPassword_TextChanged);
			// 
			// buttonEligibility
			// 
			this.buttonEligibility.Anchor = System.Windows.Forms.AnchorStyles.Bottom;
			this.buttonEligibility.Location = new System.Drawing.Point(5, 108);
			this.buttonEligibility.Name = "buttonEligibility";
			this.buttonEligibility.Size = new System.Drawing.Size(196, 23);
			this.buttonEligibility.TabIndex = 0;
			this.buttonEligibility.Text = "Submit Eligibility Requests";
			this.buttonEligibility.UseVisualStyleBackColor = true;
			this.buttonEligibility.Click += new System.EventHandler(this.buttonEligibility_Click);
			// 
			// textBoxVendorSiteID
			// 
			this.textBoxVendorSiteID.Dock = System.Windows.Forms.DockStyle.Fill;
			this.textBoxVendorSiteID.Location = new System.Drawing.Point(209, 55);
			this.textBoxVendorSiteID.Name = "textBoxVendorSiteID";
			this.textBoxVendorSiteID.Size = new System.Drawing.Size(310, 20);
			this.textBoxVendorSiteID.TabIndex = 2;
			this.textBoxVendorSiteID.TextChanged += new System.EventHandler(this.textBoxVendorSiteID_TextChanged);
			// 
			// label2
			// 
			this.label2.Anchor = System.Windows.Forms.AnchorStyles.Right;
			this.label2.AutoSize = true;
			this.label2.Location = new System.Drawing.Point(124, 58);
			this.label2.Name = "label2";
			this.label2.Size = new System.Drawing.Size(79, 13);
			this.label2.TabIndex = 1;
			this.label2.Text = "Vendor Site ID:";
			// 
			// resultsControlMain
			// 
			this.resultsControlMain.Dock = System.Windows.Forms.DockStyle.Fill;
			this.resultsControlMain.Location = new System.Drawing.Point(3, 228);
			this.resultsControlMain.Name = "resultsControlMain";
			this.resultsControlMain.ResultsLabel = "Results";
			this.resultsControlMain.Size = new System.Drawing.Size(1050, 546);
			this.resultsControlMain.TabIndex = 3;
			// 
			// openFileDialog1
			// 
			this.openFileDialog1.FileName = "openFileDialog1";
			// 
			// menuStrip1
			// 
			this.menuStrip1.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.toolsToolStripMenuItem});
			this.menuStrip1.Location = new System.Drawing.Point(0, 0);
			this.menuStrip1.Name = "menuStrip1";
			this.menuStrip1.Size = new System.Drawing.Size(1056, 24);
			this.menuStrip1.TabIndex = 3;
			this.menuStrip1.Text = "menuStrip1";
			// 
			// toolsToolStripMenuItem
			// 
			this.toolsToolStripMenuItem.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.changeCredentialsToolStripMenuItem,
            this.exportResultsToCSVToolStripMenuItem});
			this.toolsToolStripMenuItem.Name = "toolsToolStripMenuItem";
			this.toolsToolStripMenuItem.Size = new System.Drawing.Size(47, 20);
			this.toolsToolStripMenuItem.Text = "&Tools";
			// 
			// changeCredentialsToolStripMenuItem
			// 
			this.changeCredentialsToolStripMenuItem.Name = "changeCredentialsToolStripMenuItem";
			this.changeCredentialsToolStripMenuItem.Size = new System.Drawing.Size(185, 22);
			this.changeCredentialsToolStripMenuItem.Text = "&Change Credentials";
			this.changeCredentialsToolStripMenuItem.Click += new System.EventHandler(this.changeCredentialsToolStripMenuItem_Click);
			// 
			// exportResultsToCSVToolStripMenuItem
			// 
			this.exportResultsToCSVToolStripMenuItem.Name = "exportResultsToCSVToolStripMenuItem";
			this.exportResultsToCSVToolStripMenuItem.Size = new System.Drawing.Size(185, 22);
			this.exportResultsToCSVToolStripMenuItem.Text = "&Export Results to CSV";
			this.exportResultsToCSVToolStripMenuItem.Click += new System.EventHandler(this.exportResultsToCSVToolStripMenuItem_Click);
			// 
			// MainForm
			// 
			this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
			this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
			this.ClientSize = new System.Drawing.Size(1056, 801);
			this.Controls.Add(this.tableLayoutPanelBase);
			this.Controls.Add(this.menuStrip1);
			this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
			this.MainMenuStrip = this.menuStrip1;
			this.Name = "MainForm";
			this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
			this.Text = "Apex Web Services 1.5";
			this.Load += new System.EventHandler(this.MainForm_Load);
			this.tableLayoutPanelBase.ResumeLayout(false);
			this.tableLayoutPanelAPIs.ResumeLayout(false);
			this.groupBoxApi.ResumeLayout(false);
			this.groupBoxApi.PerformLayout();
			this.groupBoxApiSelector.ResumeLayout(false);
			this.groupBoxApiSelector.PerformLayout();
			this.groupBoxGetPayers.ResumeLayout(false);
			this.groupBoxGetPayers.PerformLayout();
			this.groupBoxSettings.ResumeLayout(false);
			this.tableLayoutPanel1.ResumeLayout(false);
			this.tableLayoutPanel1.PerformLayout();
			this.menuStrip1.ResumeLayout(false);
			this.menuStrip1.PerformLayout();
			this.ResumeLayout(false);
			this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Button button_1_5_GetPayers;
        private System.Windows.Forms.TableLayoutPanel tableLayoutPanelBase;
        private System.Windows.Forms.TableLayoutPanel tableLayoutPanelAPIs;
        private System.Windows.Forms.GroupBox groupBoxApi;
        private CommonControls.ResultsControl resultsControlMain;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.TextBox textBoxVendorSiteID;
        private System.Windows.Forms.Button buttonSubmitClaims;
        private System.Windows.Forms.GroupBox groupBoxGetPayers;
        private System.Windows.Forms.RadioButton radioButtonPayerMedicaid;
        private System.Windows.Forms.RadioButton radioButtonPayerMedical;
        private System.Windows.Forms.Button buttonGetFile;
        private System.Windows.Forms.Label labelFile;
        private System.Windows.Forms.OpenFileDialog openFileDialog1;
        private System.Windows.Forms.MenuStrip menuStrip1;
        private System.Windows.Forms.ToolStripMenuItem toolsToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem changeCredentialsToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem exportResultsToCSVToolStripMenuItem;
        private System.Windows.Forms.Button buttonGetClaimStatusByDate;
        private System.Windows.Forms.RadioButton radioButtonDental;
        private System.Windows.Forms.Button buttonGetTestPayers;
        private System.Windows.Forms.Button buttonEligibility;
        private System.Windows.Forms.TextBox textBoxKey;
        private System.Windows.Forms.TextBox textBoxPassword;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Label labelKey;
        private System.Windows.Forms.GroupBox groupBoxSettings;
        private System.Windows.Forms.ListBox listBoxClaimFiles;
        private System.Windows.Forms.Button buttonSaveSettings;
        private System.Windows.Forms.Label labelBinding;
        private System.Windows.Forms.ComboBox comboBoxBinding;
        private System.Windows.Forms.Button buttonSubmitClaimsAsync;
        private System.Windows.Forms.DateTimePicker dateTimePickerFrom;
        private System.Windows.Forms.TableLayoutPanel tableLayoutPanel1;
        private System.Windows.Forms.Label labelFrom;
        private System.Windows.Forms.DateTimePicker dateTimePickerTo;
        private System.Windows.Forms.Label labelTo;
        private System.Windows.Forms.CheckBox checkBoxSerializeReponseFiles;
        private System.Windows.Forms.CheckBox checkBoxSerializeStatusToFile;
        private System.Windows.Forms.GroupBox groupBoxApiSelector;
        private System.Windows.Forms.RadioButton radioButtonV15;
        private System.Windows.Forms.RadioButton radioButtonV3;
        private System.Windows.Forms.Button button1;
        private System.Windows.Forms.CheckBox checkBoxViewJsonForV3;
		private System.Windows.Forms.TextBox textBoxClaimIdFilter;
		private System.Windows.Forms.CheckBox checkBoxClaimIdFilter;
	}
}


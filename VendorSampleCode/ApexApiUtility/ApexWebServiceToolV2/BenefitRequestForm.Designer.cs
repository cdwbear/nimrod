namespace ApexWebServiceToolV2
{
    partial class BenefitRequestForm
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
			System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle7 = new System.Windows.Forms.DataGridViewCellStyle();
			System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle8 = new System.Windows.Forms.DataGridViewCellStyle();
			System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle9 = new System.Windows.Forms.DataGridViewCellStyle();
			System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle10 = new System.Windows.Forms.DataGridViewCellStyle();
			System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle11 = new System.Windows.Forms.DataGridViewCellStyle();
			System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle12 = new System.Windows.Forms.DataGridViewCellStyle();
			this.labelIsTest = new System.Windows.Forms.Label();
			this.labelPayeeNPI = new System.Windows.Forms.Label();
			this.labelEligibilityPayeeFirstName = new System.Windows.Forms.Label();
			this.labelEligibilityCommonName = new System.Windows.Forms.Label();
			this.labelEligibilityVendorSiteID = new System.Windows.Forms.Label();
			this.textBoxSubscriberFirst = new System.Windows.Forms.TextBox();
			this.textBoxSubscriberLast = new System.Windows.Forms.TextBox();
			this.checkBoxEligibilityIsTest = new System.Windows.Forms.CheckBox();
			this.textBoxNPI = new System.Windows.Forms.TextBox();
			this.textBoxPayerID = new System.Windows.Forms.TextBox();
			this.textBoxEligibilityVendorSiteId = new System.Windows.Forms.TextBox();
			this.textBoxEligibilityPayeeFirstName = new System.Windows.Forms.TextBox();
			this.textBoxEligibilityPayeeCommonName = new System.Windows.Forms.TextBox();
			this.labelServiceType = new System.Windows.Forms.Label();
			this.dataGridViewServiceTypes = new System.Windows.Forms.DataGridView();
			this.tableLayoutPanelBase = new System.Windows.Forms.TableLayoutPanel();
			this.labelEligibilityResponses = new System.Windows.Forms.Label();
			this.buttonSubmitEligibilityRequest = new System.Windows.Forms.Button();
			this.labelEligibilityRequests = new System.Windows.Forms.Label();
			this.tableLayoutPanelEligibilityForm = new System.Windows.Forms.TableLayoutPanel();
			this.labelTraceNumber = new System.Windows.Forms.Label();
			this.buttonGetPayer = new System.Windows.Forms.Button();
			this.tableLayoutPanelDepGender = new System.Windows.Forms.TableLayoutPanel();
			this.radioButtonDepFemale = new System.Windows.Forms.RadioButton();
			this.radioButtonDepMale = new System.Windows.Forms.RadioButton();
			this.dateTimePickerDependentDOB = new System.Windows.Forms.DateTimePicker();
			this.textBoxDependentLast = new System.Windows.Forms.TextBox();
			this.textBoxDependentFirst = new System.Windows.Forms.TextBox();
			this.labelDependentDOB = new System.Windows.Forms.Label();
			this.labelDependentLast = new System.Windows.Forms.Label();
			this.labelDependentFirst = new System.Windows.Forms.Label();
			this.textBoxSubscriberID = new System.Windows.Forms.TextBox();
			this.tableLayoutPanelSubGender = new System.Windows.Forms.TableLayoutPanel();
			this.radioButtonSubFemale = new System.Windows.Forms.RadioButton();
			this.radioButtonSubMale = new System.Windows.Forms.RadioButton();
			this.dateTimePickerSubscriberDOB = new System.Windows.Forms.DateTimePicker();
			this.labelSubscriberID = new System.Windows.Forms.Label();
			this.labelSex = new System.Windows.Forms.Label();
			this.labelSubscriberDOB = new System.Windows.Forms.Label();
			this.labelSubscriberLast = new System.Windows.Forms.Label();
			this.labelSubscriberFirst = new System.Windows.Forms.Label();
			this.labelPayeeTitle = new System.Windows.Forms.Label();
			this.labelSubscriberHeading = new System.Windows.Forms.Label();
			this.checkBoxUseDependent = new System.Windows.Forms.CheckBox();
			this.labelDepGender = new System.Windows.Forms.Label();
			this.textBoxDependentSubscriberId = new System.Windows.Forms.TextBox();
			this.labelOriginatorId = new System.Windows.Forms.Label();
			this.textBoxTraceNumber = new System.Windows.Forms.TextBox();
			this.textBoxOriginatingCompanyId = new System.Windows.Forms.TextBox();
			this.labelFederalTaxId = new System.Windows.Forms.Label();
			this.textBoxTaxId = new System.Windows.Forms.TextBox();
			this.label2 = new System.Windows.Forms.Label();
			this.labelDependentRelationship = new System.Windows.Forms.Label();
			this.comboBoxRelationship = new System.Windows.Forms.ComboBox();
			this.buttonClose = new System.Windows.Forms.Button();
			this.tableLayoutPanelSerializing = new System.Windows.Forms.TableLayoutPanel();
			this.checkBoxSerializeRequest = new System.Windows.Forms.CheckBox();
			this.checkBoxSerializeResponse = new System.Windows.Forms.CheckBox();
			this.tableLayoutPanelRequestMgmt = new System.Windows.Forms.TableLayoutPanel();
			this.tableLayoutPanelRequests = new System.Windows.Forms.TableLayoutPanel();
			this.dataGridViewRequests = new System.Windows.Forms.DataGridView();
			this.VendorSiteId = new System.Windows.Forms.DataGridViewTextBoxColumn();
			this.PayerCommonName = new System.Windows.Forms.DataGridViewTextBoxColumn();
			this.PayeeName = new System.Windows.Forms.DataGridViewTextBoxColumn();
			this.SubscriberName = new System.Windows.Forms.DataGridViewTextBoxColumn();
			this.DependentName = new System.Windows.Forms.DataGridViewTextBoxColumn();
			this.tableLayoutPanelSubmitButtons = new System.Windows.Forms.TableLayoutPanel();
			this.buttonSubmitAllRequests = new System.Windows.Forms.Button();
			this.buttonClearRequests = new System.Windows.Forms.Button();
			this.buttonSubmitSelectedRequests = new System.Windows.Forms.Button();
			this.labelRequests = new System.Windows.Forms.Label();
			this.tableLayoutPanelResponses = new System.Windows.Forms.TableLayoutPanel();
			this.treeViewSoapResponse = new System.Windows.Forms.TreeView();
			this.label1 = new System.Windows.Forms.Label();
			this.dataGridViewEligibilityResponses = new System.Windows.Forms.DataGridView();
			this.RequestID = new System.Windows.Forms.DataGridViewTextBoxColumn();
			this.Status = new System.Windows.Forms.DataGridViewTextBoxColumn();
			this.Errors = new System.Windows.Forms.DataGridViewTextBoxColumn();
			this.ErrorMessage = new System.Windows.Forms.DataGridViewTextBoxColumn();
			this.buttonGetEligibilityResponses = new System.Windows.Forms.Button();
			this.richTextBoxResults = new System.Windows.Forms.RichTextBox();
			this.labelResponses = new System.Windows.Forms.Label();
			((System.ComponentModel.ISupportInitialize)(this.dataGridViewServiceTypes)).BeginInit();
			this.tableLayoutPanelBase.SuspendLayout();
			this.tableLayoutPanelEligibilityForm.SuspendLayout();
			this.tableLayoutPanelDepGender.SuspendLayout();
			this.tableLayoutPanelSubGender.SuspendLayout();
			this.tableLayoutPanelSerializing.SuspendLayout();
			this.tableLayoutPanelRequestMgmt.SuspendLayout();
			this.tableLayoutPanelRequests.SuspendLayout();
			((System.ComponentModel.ISupportInitialize)(this.dataGridViewRequests)).BeginInit();
			this.tableLayoutPanelSubmitButtons.SuspendLayout();
			this.tableLayoutPanelResponses.SuspendLayout();
			((System.ComponentModel.ISupportInitialize)(this.dataGridViewEligibilityResponses)).BeginInit();
			this.SuspendLayout();
			// 
			// labelIsTest
			// 
			this.labelIsTest.Anchor = System.Windows.Forms.AnchorStyles.Right;
			this.labelIsTest.AutoSize = true;
			this.labelIsTest.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
			this.labelIsTest.Location = new System.Drawing.Point(89, 3);
			this.labelIsTest.Name = "labelIsTest";
			this.labelIsTest.Size = new System.Drawing.Size(59, 13);
			this.labelIsTest.TabIndex = 0;
			this.labelIsTest.Text = "IS TEST:";
			// 
			// labelPayeeNPI
			// 
			this.labelPayeeNPI.Anchor = System.Windows.Forms.AnchorStyles.Right;
			this.labelPayeeNPI.AutoSize = true;
			this.labelPayeeNPI.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
			this.labelPayeeNPI.Location = new System.Drawing.Point(87, 91);
			this.labelPayeeNPI.Name = "labelPayeeNPI";
			this.labelPayeeNPI.Size = new System.Drawing.Size(61, 13);
			this.labelPayeeNPI.TabIndex = 6;
			this.labelPayeeNPI.Text = "Payee NPI:";
			// 
			// labelEligibilityPayeeFirstName
			// 
			this.labelEligibilityPayeeFirstName.Anchor = System.Windows.Forms.AnchorStyles.Right;
			this.labelEligibilityPayeeFirstName.AutoSize = true;
			this.labelEligibilityPayeeFirstName.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
			this.labelEligibilityPayeeFirstName.Location = new System.Drawing.Point(88, 39);
			this.labelEligibilityPayeeFirstName.Name = "labelEligibilityPayeeFirstName";
			this.labelEligibilityPayeeFirstName.Size = new System.Drawing.Size(60, 13);
			this.labelEligibilityPayeeFirstName.TabIndex = 2;
			this.labelEligibilityPayeeFirstName.Text = "First Name:";
			// 
			// labelEligibilityCommonName
			// 
			this.labelEligibilityCommonName.Anchor = System.Windows.Forms.AnchorStyles.Right;
			this.labelEligibilityCommonName.AutoSize = true;
			this.labelEligibilityCommonName.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
			this.labelEligibilityCommonName.Location = new System.Drawing.Point(66, 65);
			this.labelEligibilityCommonName.Name = "labelEligibilityCommonName";
			this.labelEligibilityCommonName.Size = new System.Drawing.Size(82, 13);
			this.labelEligibilityCommonName.TabIndex = 4;
			this.labelEligibilityCommonName.Text = "Common Name:";
			// 
			// labelEligibilityVendorSiteID
			// 
			this.labelEligibilityVendorSiteID.Anchor = System.Windows.Forms.AnchorStyles.Right;
			this.labelEligibilityVendorSiteID.AutoSize = true;
			this.labelEligibilityVendorSiteID.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
			this.labelEligibilityVendorSiteID.Location = new System.Drawing.Point(69, 143);
			this.labelEligibilityVendorSiteID.Name = "labelEligibilityVendorSiteID";
			this.labelEligibilityVendorSiteID.Size = new System.Drawing.Size(79, 13);
			this.labelEligibilityVendorSiteID.TabIndex = 10;
			this.labelEligibilityVendorSiteID.Text = "Vendor Site ID:";
			// 
			// textBoxSubscriberFirst
			// 
			this.textBoxSubscriberFirst.Dock = System.Windows.Forms.DockStyle.Fill;
			this.textBoxSubscriberFirst.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
			this.textBoxSubscriberFirst.Location = new System.Drawing.Point(154, 393);
			this.textBoxSubscriberFirst.Name = "textBoxSubscriberFirst";
			this.textBoxSubscriberFirst.Size = new System.Drawing.Size(183, 20);
			this.textBoxSubscriberFirst.TabIndex = 22;
			// 
			// textBoxSubscriberLast
			// 
			this.textBoxSubscriberLast.Dock = System.Windows.Forms.DockStyle.Fill;
			this.textBoxSubscriberLast.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
			this.textBoxSubscriberLast.Location = new System.Drawing.Point(154, 419);
			this.textBoxSubscriberLast.Name = "textBoxSubscriberLast";
			this.textBoxSubscriberLast.Size = new System.Drawing.Size(183, 20);
			this.textBoxSubscriberLast.TabIndex = 24;
			// 
			// checkBoxEligibilityIsTest
			// 
			this.checkBoxEligibilityIsTest.Anchor = System.Windows.Forms.AnchorStyles.Left;
			this.checkBoxEligibilityIsTest.AutoSize = true;
			this.checkBoxEligibilityIsTest.Checked = true;
			this.checkBoxEligibilityIsTest.CheckState = System.Windows.Forms.CheckState.Checked;
			this.checkBoxEligibilityIsTest.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
			this.checkBoxEligibilityIsTest.Location = new System.Drawing.Point(154, 3);
			this.checkBoxEligibilityIsTest.Name = "checkBoxEligibilityIsTest";
			this.checkBoxEligibilityIsTest.Size = new System.Drawing.Size(15, 14);
			this.checkBoxEligibilityIsTest.TabIndex = 1;
			this.checkBoxEligibilityIsTest.UseVisualStyleBackColor = true;
			// 
			// textBoxNPI
			// 
			this.textBoxNPI.Dock = System.Windows.Forms.DockStyle.Fill;
			this.textBoxNPI.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
			this.textBoxNPI.Location = new System.Drawing.Point(154, 88);
			this.textBoxNPI.Name = "textBoxNPI";
			this.textBoxNPI.Size = new System.Drawing.Size(183, 20);
			this.textBoxNPI.TabIndex = 7;
			// 
			// textBoxPayerID
			// 
			this.textBoxPayerID.Dock = System.Windows.Forms.DockStyle.Fill;
			this.textBoxPayerID.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
			this.textBoxPayerID.Location = new System.Drawing.Point(154, 166);
			this.textBoxPayerID.Name = "textBoxPayerID";
			this.textBoxPayerID.ReadOnly = true;
			this.textBoxPayerID.Size = new System.Drawing.Size(183, 20);
			this.textBoxPayerID.TabIndex = 13;
			// 
			// textBoxEligibilityVendorSiteId
			// 
			this.textBoxEligibilityVendorSiteId.Dock = System.Windows.Forms.DockStyle.Fill;
			this.textBoxEligibilityVendorSiteId.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
			this.textBoxEligibilityVendorSiteId.Location = new System.Drawing.Point(154, 140);
			this.textBoxEligibilityVendorSiteId.Name = "textBoxEligibilityVendorSiteId";
			this.textBoxEligibilityVendorSiteId.Size = new System.Drawing.Size(183, 20);
			this.textBoxEligibilityVendorSiteId.TabIndex = 11;
			this.textBoxEligibilityVendorSiteId.TextChanged += new System.EventHandler(this.textBoxEligibilityVendorSiteId_TextChanged);
			// 
			// textBoxEligibilityPayeeFirstName
			// 
			this.textBoxEligibilityPayeeFirstName.Dock = System.Windows.Forms.DockStyle.Fill;
			this.textBoxEligibilityPayeeFirstName.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
			this.textBoxEligibilityPayeeFirstName.Location = new System.Drawing.Point(154, 36);
			this.textBoxEligibilityPayeeFirstName.Name = "textBoxEligibilityPayeeFirstName";
			this.textBoxEligibilityPayeeFirstName.Size = new System.Drawing.Size(183, 20);
			this.textBoxEligibilityPayeeFirstName.TabIndex = 3;
			// 
			// textBoxEligibilityPayeeCommonName
			// 
			this.textBoxEligibilityPayeeCommonName.Dock = System.Windows.Forms.DockStyle.Fill;
			this.textBoxEligibilityPayeeCommonName.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
			this.textBoxEligibilityPayeeCommonName.Location = new System.Drawing.Point(154, 62);
			this.textBoxEligibilityPayeeCommonName.Name = "textBoxEligibilityPayeeCommonName";
			this.textBoxEligibilityPayeeCommonName.Size = new System.Drawing.Size(183, 20);
			this.textBoxEligibilityPayeeCommonName.TabIndex = 5;
			// 
			// labelServiceType
			// 
			this.labelServiceType.Anchor = System.Windows.Forms.AnchorStyles.Right;
			this.labelServiceType.AutoSize = true;
			this.labelServiceType.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
			this.labelServiceType.Location = new System.Drawing.Point(78, 303);
			this.labelServiceType.Name = "labelServiceType";
			this.labelServiceType.Size = new System.Drawing.Size(70, 13);
			this.labelServiceType.TabIndex = 18;
			this.labelServiceType.Text = "Service Type";
			// 
			// dataGridViewServiceTypes
			// 
			this.dataGridViewServiceTypes.AllowUserToAddRows = false;
			this.dataGridViewServiceTypes.AllowUserToDeleteRows = false;
			this.dataGridViewServiceTypes.AllowUserToResizeRows = false;
			this.dataGridViewServiceTypes.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
			this.dataGridViewServiceTypes.Cursor = System.Windows.Forms.Cursors.Hand;
			this.dataGridViewServiceTypes.Dock = System.Windows.Forms.DockStyle.Fill;
			this.dataGridViewServiceTypes.Location = new System.Drawing.Point(154, 245);
			this.dataGridViewServiceTypes.Name = "dataGridViewServiceTypes";
			this.dataGridViewServiceTypes.ReadOnly = true;
			this.dataGridViewServiceTypes.RowHeadersVisible = false;
			this.dataGridViewServiceTypes.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect;
			this.dataGridViewServiceTypes.Size = new System.Drawing.Size(183, 129);
			this.dataGridViewServiceTypes.TabIndex = 19;
			// 
			// tableLayoutPanelBase
			// 
			this.tableLayoutPanelBase.ColumnCount = 2;
			this.tableLayoutPanelBase.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Absolute, 346F));
			this.tableLayoutPanelBase.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Absolute, 722F));
			this.tableLayoutPanelBase.Controls.Add(this.labelEligibilityResponses, 1, 0);
			this.tableLayoutPanelBase.Controls.Add(this.buttonSubmitEligibilityRequest, 0, 2);
			this.tableLayoutPanelBase.Controls.Add(this.labelEligibilityRequests, 0, 0);
			this.tableLayoutPanelBase.Controls.Add(this.tableLayoutPanelEligibilityForm, 0, 1);
			this.tableLayoutPanelBase.Controls.Add(this.buttonClose, 1, 4);
			this.tableLayoutPanelBase.Controls.Add(this.tableLayoutPanelSerializing, 1, 2);
			this.tableLayoutPanelBase.Controls.Add(this.tableLayoutPanelRequestMgmt, 1, 1);
			this.tableLayoutPanelBase.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
			this.tableLayoutPanelBase.Location = new System.Drawing.Point(0, 0);
			this.tableLayoutPanelBase.Name = "tableLayoutPanelBase";
			this.tableLayoutPanelBase.RowCount = 5;
			this.tableLayoutPanelBase.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 20F));
			this.tableLayoutPanelBase.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 726F));
			this.tableLayoutPanelBase.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 29F));
			this.tableLayoutPanelBase.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 12F));
			this.tableLayoutPanelBase.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 8F));
			this.tableLayoutPanelBase.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 20F));
			this.tableLayoutPanelBase.Size = new System.Drawing.Size(1063, 775);
			this.tableLayoutPanelBase.TabIndex = 39;
			// 
			// labelEligibilityResponses
			// 
			this.labelEligibilityResponses.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
			this.labelEligibilityResponses.AutoSize = true;
			this.labelEligibilityResponses.Font = new System.Drawing.Font("Microsoft Sans Serif", 10F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
			this.labelEligibilityResponses.Location = new System.Drawing.Point(349, 3);
			this.labelEligibilityResponses.Name = "labelEligibilityResponses";
			this.labelEligibilityResponses.Size = new System.Drawing.Size(170, 17);
			this.labelEligibilityResponses.TabIndex = 2;
			this.labelEligibilityResponses.Text = "Eligibility Management";
			// 
			// buttonSubmitEligibilityRequest
			// 
			this.buttonSubmitEligibilityRequest.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
			this.buttonSubmitEligibilityRequest.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
			this.buttonSubmitEligibilityRequest.Location = new System.Drawing.Point(180, 749);
			this.buttonSubmitEligibilityRequest.Name = "buttonSubmitEligibilityRequest";
			this.buttonSubmitEligibilityRequest.Size = new System.Drawing.Size(163, 23);
			this.buttonSubmitEligibilityRequest.TabIndex = 1;
			this.buttonSubmitEligibilityRequest.Text = "Submit Eligibility Request";
			this.buttonSubmitEligibilityRequest.UseVisualStyleBackColor = true;
			this.buttonSubmitEligibilityRequest.Click += new System.EventHandler(this.buttonSubmitEligibilityRequest_Click);
			// 
			// labelEligibilityRequests
			// 
			this.labelEligibilityRequests.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
			this.labelEligibilityRequests.AutoSize = true;
			this.labelEligibilityRequests.Font = new System.Drawing.Font("Microsoft Sans Serif", 10F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
			this.labelEligibilityRequests.Location = new System.Drawing.Point(3, 3);
			this.labelEligibilityRequests.Name = "labelEligibilityRequests";
			this.labelEligibilityRequests.Size = new System.Drawing.Size(179, 17);
			this.labelEligibilityRequests.TabIndex = 0;
			this.labelEligibilityRequests.Text = "Eligibility Request Form";
			// 
			// tableLayoutPanelEligibilityForm
			// 
			this.tableLayoutPanelEligibilityForm.ColumnCount = 2;
			this.tableLayoutPanelEligibilityForm.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Absolute, 151F));
			this.tableLayoutPanelEligibilityForm.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Absolute, 189F));
			this.tableLayoutPanelEligibilityForm.Controls.Add(this.labelTraceNumber, 0, 8);
			this.tableLayoutPanelEligibilityForm.Controls.Add(this.buttonGetPayer, 0, 7);
			this.tableLayoutPanelEligibilityForm.Controls.Add(this.tableLayoutPanelDepGender, 1, 21);
			this.tableLayoutPanelEligibilityForm.Controls.Add(this.dateTimePickerDependentDOB, 1, 20);
			this.tableLayoutPanelEligibilityForm.Controls.Add(this.textBoxDependentLast, 1, 19);
			this.tableLayoutPanelEligibilityForm.Controls.Add(this.dataGridViewServiceTypes, 1, 10);
			this.tableLayoutPanelEligibilityForm.Controls.Add(this.textBoxDependentFirst, 1, 18);
			this.tableLayoutPanelEligibilityForm.Controls.Add(this.labelDependentDOB, 0, 20);
			this.tableLayoutPanelEligibilityForm.Controls.Add(this.labelDependentLast, 0, 19);
			this.tableLayoutPanelEligibilityForm.Controls.Add(this.labelDependentFirst, 0, 18);
			this.tableLayoutPanelEligibilityForm.Controls.Add(this.textBoxSubscriberID, 1, 16);
			this.tableLayoutPanelEligibilityForm.Controls.Add(this.tableLayoutPanelSubGender, 1, 15);
			this.tableLayoutPanelEligibilityForm.Controls.Add(this.dateTimePickerSubscriberDOB, 1, 14);
			this.tableLayoutPanelEligibilityForm.Controls.Add(this.labelSubscriberID, 0, 16);
			this.tableLayoutPanelEligibilityForm.Controls.Add(this.labelSex, 0, 15);
			this.tableLayoutPanelEligibilityForm.Controls.Add(this.labelSubscriberDOB, 0, 14);
			this.tableLayoutPanelEligibilityForm.Controls.Add(this.labelSubscriberLast, 0, 13);
			this.tableLayoutPanelEligibilityForm.Controls.Add(this.textBoxNPI, 1, 4);
			this.tableLayoutPanelEligibilityForm.Controls.Add(this.textBoxEligibilityVendorSiteId, 1, 6);
			this.tableLayoutPanelEligibilityForm.Controls.Add(this.textBoxSubscriberLast, 1, 13);
			this.tableLayoutPanelEligibilityForm.Controls.Add(this.textBoxSubscriberFirst, 1, 12);
			this.tableLayoutPanelEligibilityForm.Controls.Add(this.labelSubscriberFirst, 0, 12);
			this.tableLayoutPanelEligibilityForm.Controls.Add(this.textBoxEligibilityPayeeCommonName, 1, 3);
			this.tableLayoutPanelEligibilityForm.Controls.Add(this.textBoxEligibilityPayeeFirstName, 1, 2);
			this.tableLayoutPanelEligibilityForm.Controls.Add(this.labelPayeeTitle, 0, 1);
			this.tableLayoutPanelEligibilityForm.Controls.Add(this.labelIsTest, 0, 0);
			this.tableLayoutPanelEligibilityForm.Controls.Add(this.checkBoxEligibilityIsTest, 1, 0);
			this.tableLayoutPanelEligibilityForm.Controls.Add(this.labelServiceType, 0, 10);
			this.tableLayoutPanelEligibilityForm.Controls.Add(this.labelEligibilityPayeeFirstName, 0, 2);
			this.tableLayoutPanelEligibilityForm.Controls.Add(this.labelEligibilityCommonName, 0, 3);
			this.tableLayoutPanelEligibilityForm.Controls.Add(this.labelPayeeNPI, 0, 4);
			this.tableLayoutPanelEligibilityForm.Controls.Add(this.labelEligibilityVendorSiteID, 0, 6);
			this.tableLayoutPanelEligibilityForm.Controls.Add(this.labelSubscriberHeading, 0, 11);
			this.tableLayoutPanelEligibilityForm.Controls.Add(this.checkBoxUseDependent, 0, 17);
			this.tableLayoutPanelEligibilityForm.Controls.Add(this.labelDepGender, 0, 21);
			this.tableLayoutPanelEligibilityForm.Controls.Add(this.textBoxDependentSubscriberId, 1, 22);
			this.tableLayoutPanelEligibilityForm.Controls.Add(this.textBoxPayerID, 1, 7);
			this.tableLayoutPanelEligibilityForm.Controls.Add(this.labelOriginatorId, 0, 9);
			this.tableLayoutPanelEligibilityForm.Controls.Add(this.textBoxTraceNumber, 1, 8);
			this.tableLayoutPanelEligibilityForm.Controls.Add(this.textBoxOriginatingCompanyId, 1, 9);
			this.tableLayoutPanelEligibilityForm.Controls.Add(this.labelFederalTaxId, 0, 5);
			this.tableLayoutPanelEligibilityForm.Controls.Add(this.textBoxTaxId, 1, 5);
			this.tableLayoutPanelEligibilityForm.Controls.Add(this.label2, 0, 22);
			this.tableLayoutPanelEligibilityForm.Controls.Add(this.labelDependentRelationship, 0, 23);
			this.tableLayoutPanelEligibilityForm.Controls.Add(this.comboBoxRelationship, 1, 23);
			this.tableLayoutPanelEligibilityForm.Dock = System.Windows.Forms.DockStyle.Fill;
			this.tableLayoutPanelEligibilityForm.Location = new System.Drawing.Point(3, 23);
			this.tableLayoutPanelEligibilityForm.Name = "tableLayoutPanelEligibilityForm";
			this.tableLayoutPanelEligibilityForm.RowCount = 25;
			this.tableLayoutPanelEligibilityForm.RowStyles.Add(new System.Windows.Forms.RowStyle());
			this.tableLayoutPanelEligibilityForm.RowStyles.Add(new System.Windows.Forms.RowStyle());
			this.tableLayoutPanelEligibilityForm.RowStyles.Add(new System.Windows.Forms.RowStyle());
			this.tableLayoutPanelEligibilityForm.RowStyles.Add(new System.Windows.Forms.RowStyle());
			this.tableLayoutPanelEligibilityForm.RowStyles.Add(new System.Windows.Forms.RowStyle());
			this.tableLayoutPanelEligibilityForm.RowStyles.Add(new System.Windows.Forms.RowStyle());
			this.tableLayoutPanelEligibilityForm.RowStyles.Add(new System.Windows.Forms.RowStyle());
			this.tableLayoutPanelEligibilityForm.RowStyles.Add(new System.Windows.Forms.RowStyle());
			this.tableLayoutPanelEligibilityForm.RowStyles.Add(new System.Windows.Forms.RowStyle());
			this.tableLayoutPanelEligibilityForm.RowStyles.Add(new System.Windows.Forms.RowStyle());
			this.tableLayoutPanelEligibilityForm.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 135F));
			this.tableLayoutPanelEligibilityForm.RowStyles.Add(new System.Windows.Forms.RowStyle());
			this.tableLayoutPanelEligibilityForm.RowStyles.Add(new System.Windows.Forms.RowStyle());
			this.tableLayoutPanelEligibilityForm.RowStyles.Add(new System.Windows.Forms.RowStyle());
			this.tableLayoutPanelEligibilityForm.RowStyles.Add(new System.Windows.Forms.RowStyle());
			this.tableLayoutPanelEligibilityForm.RowStyles.Add(new System.Windows.Forms.RowStyle());
			this.tableLayoutPanelEligibilityForm.RowStyles.Add(new System.Windows.Forms.RowStyle());
			this.tableLayoutPanelEligibilityForm.RowStyles.Add(new System.Windows.Forms.RowStyle());
			this.tableLayoutPanelEligibilityForm.RowStyles.Add(new System.Windows.Forms.RowStyle());
			this.tableLayoutPanelEligibilityForm.RowStyles.Add(new System.Windows.Forms.RowStyle());
			this.tableLayoutPanelEligibilityForm.RowStyles.Add(new System.Windows.Forms.RowStyle());
			this.tableLayoutPanelEligibilityForm.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 27F));
			this.tableLayoutPanelEligibilityForm.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 25F));
			this.tableLayoutPanelEligibilityForm.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 25F));
			this.tableLayoutPanelEligibilityForm.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 10F));
			this.tableLayoutPanelEligibilityForm.Size = new System.Drawing.Size(340, 720);
			this.tableLayoutPanelEligibilityForm.TabIndex = 40;
			// 
			// labelTraceNumber
			// 
			this.labelTraceNumber.Anchor = System.Windows.Forms.AnchorStyles.Right;
			this.labelTraceNumber.AutoSize = true;
			this.labelTraceNumber.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
			this.labelTraceNumber.Location = new System.Drawing.Point(70, 196);
			this.labelTraceNumber.Name = "labelTraceNumber";
			this.labelTraceNumber.Size = new System.Drawing.Size(78, 13);
			this.labelTraceNumber.TabIndex = 14;
			this.labelTraceNumber.Text = "Trace Number:";
			// 
			// buttonGetPayer
			// 
			this.buttonGetPayer.Dock = System.Windows.Forms.DockStyle.Fill;
			this.buttonGetPayer.Location = new System.Drawing.Point(3, 166);
			this.buttonGetPayer.Name = "buttonGetPayer";
			this.buttonGetPayer.Size = new System.Drawing.Size(145, 21);
			this.buttonGetPayer.TabIndex = 12;
			this.buttonGetPayer.Text = "Select Apex Payer ID";
			this.buttonGetPayer.UseVisualStyleBackColor = true;
			this.buttonGetPayer.Click += new System.EventHandler(this.buttonGetPayers_Click);
			// 
			// tableLayoutPanelDepGender
			// 
			this.tableLayoutPanelDepGender.ColumnCount = 2;
			this.tableLayoutPanelDepGender.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle());
			this.tableLayoutPanelDepGender.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 100F));
			this.tableLayoutPanelDepGender.Controls.Add(this.radioButtonDepFemale, 1, 0);
			this.tableLayoutPanelDepGender.Controls.Add(this.radioButtonDepMale, 0, 0);
			this.tableLayoutPanelDepGender.Dock = System.Windows.Forms.DockStyle.Fill;
			this.tableLayoutPanelDepGender.Enabled = false;
			this.tableLayoutPanelDepGender.Location = new System.Drawing.Point(154, 627);
			this.tableLayoutPanelDepGender.Name = "tableLayoutPanelDepGender";
			this.tableLayoutPanelDepGender.RowCount = 1;
			this.tableLayoutPanelDepGender.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 100F));
			this.tableLayoutPanelDepGender.Size = new System.Drawing.Size(183, 21);
			this.tableLayoutPanelDepGender.TabIndex = 39;
			// 
			// radioButtonDepFemale
			// 
			this.radioButtonDepFemale.Anchor = System.Windows.Forms.AnchorStyles.Left;
			this.radioButtonDepFemale.AutoSize = true;
			this.radioButtonDepFemale.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
			this.radioButtonDepFemale.Location = new System.Drawing.Point(57, 3);
			this.radioButtonDepFemale.Name = "radioButtonDepFemale";
			this.radioButtonDepFemale.Size = new System.Drawing.Size(59, 15);
			this.radioButtonDepFemale.TabIndex = 0;
			this.radioButtonDepFemale.Text = "Female";
			this.radioButtonDepFemale.UseVisualStyleBackColor = true;
			// 
			// radioButtonDepMale
			// 
			this.radioButtonDepMale.Anchor = System.Windows.Forms.AnchorStyles.Left;
			this.radioButtonDepMale.AutoSize = true;
			this.radioButtonDepMale.Checked = true;
			this.radioButtonDepMale.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
			this.radioButtonDepMale.Location = new System.Drawing.Point(3, 3);
			this.radioButtonDepMale.Name = "radioButtonDepMale";
			this.radioButtonDepMale.Size = new System.Drawing.Size(48, 15);
			this.radioButtonDepMale.TabIndex = 1;
			this.radioButtonDepMale.TabStop = true;
			this.radioButtonDepMale.Text = "Male";
			this.radioButtonDepMale.UseVisualStyleBackColor = true;
			// 
			// dateTimePickerDependentDOB
			// 
			this.dateTimePickerDependentDOB.Dock = System.Windows.Forms.DockStyle.Fill;
			this.dateTimePickerDependentDOB.Enabled = false;
			this.dateTimePickerDependentDOB.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
			this.dateTimePickerDependentDOB.Format = System.Windows.Forms.DateTimePickerFormat.Short;
			this.dateTimePickerDependentDOB.Location = new System.Drawing.Point(154, 601);
			this.dateTimePickerDependentDOB.Name = "dateTimePickerDependentDOB";
			this.dateTimePickerDependentDOB.Size = new System.Drawing.Size(183, 20);
			this.dateTimePickerDependentDOB.TabIndex = 37;
			this.dateTimePickerDependentDOB.Value = new System.DateTime(2003, 10, 19, 0, 0, 0, 0);
			// 
			// textBoxDependentLast
			// 
			this.textBoxDependentLast.Dock = System.Windows.Forms.DockStyle.Fill;
			this.textBoxDependentLast.Enabled = false;
			this.textBoxDependentLast.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
			this.textBoxDependentLast.Location = new System.Drawing.Point(154, 575);
			this.textBoxDependentLast.Name = "textBoxDependentLast";
			this.textBoxDependentLast.Size = new System.Drawing.Size(183, 20);
			this.textBoxDependentLast.TabIndex = 35;
			// 
			// textBoxDependentFirst
			// 
			this.textBoxDependentFirst.Dock = System.Windows.Forms.DockStyle.Fill;
			this.textBoxDependentFirst.Enabled = false;
			this.textBoxDependentFirst.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
			this.textBoxDependentFirst.Location = new System.Drawing.Point(154, 549);
			this.textBoxDependentFirst.Name = "textBoxDependentFirst";
			this.textBoxDependentFirst.Size = new System.Drawing.Size(183, 20);
			this.textBoxDependentFirst.TabIndex = 33;
			// 
			// labelDependentDOB
			// 
			this.labelDependentDOB.Anchor = System.Windows.Forms.AnchorStyles.Right;
			this.labelDependentDOB.AutoSize = true;
			this.labelDependentDOB.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
			this.labelDependentDOB.Location = new System.Drawing.Point(79, 604);
			this.labelDependentDOB.Name = "labelDependentDOB";
			this.labelDependentDOB.Size = new System.Drawing.Size(69, 13);
			this.labelDependentDOB.TabIndex = 36;
			this.labelDependentDOB.Text = "Date of Birth:";
			// 
			// labelDependentLast
			// 
			this.labelDependentLast.Anchor = System.Windows.Forms.AnchorStyles.Right;
			this.labelDependentLast.AutoSize = true;
			this.labelDependentLast.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
			this.labelDependentLast.Location = new System.Drawing.Point(87, 578);
			this.labelDependentLast.Name = "labelDependentLast";
			this.labelDependentLast.Size = new System.Drawing.Size(61, 13);
			this.labelDependentLast.TabIndex = 34;
			this.labelDependentLast.Text = "Last Name:";
			// 
			// labelDependentFirst
			// 
			this.labelDependentFirst.Anchor = System.Windows.Forms.AnchorStyles.Right;
			this.labelDependentFirst.AutoSize = true;
			this.labelDependentFirst.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
			this.labelDependentFirst.Location = new System.Drawing.Point(88, 552);
			this.labelDependentFirst.Name = "labelDependentFirst";
			this.labelDependentFirst.Size = new System.Drawing.Size(60, 13);
			this.labelDependentFirst.TabIndex = 32;
			this.labelDependentFirst.Text = "First Name:";
			// 
			// textBoxSubscriberID
			// 
			this.textBoxSubscriberID.Dock = System.Windows.Forms.DockStyle.Fill;
			this.textBoxSubscriberID.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
			this.textBoxSubscriberID.Location = new System.Drawing.Point(154, 500);
			this.textBoxSubscriberID.Name = "textBoxSubscriberID";
			this.textBoxSubscriberID.Size = new System.Drawing.Size(183, 20);
			this.textBoxSubscriberID.TabIndex = 30;
			// 
			// tableLayoutPanelSubGender
			// 
			this.tableLayoutPanelSubGender.ColumnCount = 2;
			this.tableLayoutPanelSubGender.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle());
			this.tableLayoutPanelSubGender.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 100F));
			this.tableLayoutPanelSubGender.Controls.Add(this.radioButtonSubFemale, 1, 0);
			this.tableLayoutPanelSubGender.Controls.Add(this.radioButtonSubMale, 0, 0);
			this.tableLayoutPanelSubGender.Dock = System.Windows.Forms.DockStyle.Fill;
			this.tableLayoutPanelSubGender.Location = new System.Drawing.Point(154, 471);
			this.tableLayoutPanelSubGender.Name = "tableLayoutPanelSubGender";
			this.tableLayoutPanelSubGender.RowCount = 1;
			this.tableLayoutPanelSubGender.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 100F));
			this.tableLayoutPanelSubGender.Size = new System.Drawing.Size(183, 23);
			this.tableLayoutPanelSubGender.TabIndex = 28;
			// 
			// radioButtonSubFemale
			// 
			this.radioButtonSubFemale.Anchor = System.Windows.Forms.AnchorStyles.Left;
			this.radioButtonSubFemale.AutoSize = true;
			this.radioButtonSubFemale.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
			this.radioButtonSubFemale.Location = new System.Drawing.Point(57, 3);
			this.radioButtonSubFemale.Name = "radioButtonSubFemale";
			this.radioButtonSubFemale.Size = new System.Drawing.Size(59, 17);
			this.radioButtonSubFemale.TabIndex = 1;
			this.radioButtonSubFemale.Text = "Female";
			this.radioButtonSubFemale.UseVisualStyleBackColor = true;
			// 
			// radioButtonSubMale
			// 
			this.radioButtonSubMale.Anchor = System.Windows.Forms.AnchorStyles.Left;
			this.radioButtonSubMale.AutoSize = true;
			this.radioButtonSubMale.Checked = true;
			this.radioButtonSubMale.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
			this.radioButtonSubMale.Location = new System.Drawing.Point(3, 3);
			this.radioButtonSubMale.Name = "radioButtonSubMale";
			this.radioButtonSubMale.Size = new System.Drawing.Size(48, 17);
			this.radioButtonSubMale.TabIndex = 0;
			this.radioButtonSubMale.TabStop = true;
			this.radioButtonSubMale.Text = "Male";
			this.radioButtonSubMale.UseVisualStyleBackColor = true;
			// 
			// dateTimePickerSubscriberDOB
			// 
			this.dateTimePickerSubscriberDOB.Dock = System.Windows.Forms.DockStyle.Fill;
			this.dateTimePickerSubscriberDOB.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
			this.dateTimePickerSubscriberDOB.Format = System.Windows.Forms.DateTimePickerFormat.Short;
			this.dateTimePickerSubscriberDOB.Location = new System.Drawing.Point(154, 445);
			this.dateTimePickerSubscriberDOB.Name = "dateTimePickerSubscriberDOB";
			this.dateTimePickerSubscriberDOB.Size = new System.Drawing.Size(183, 20);
			this.dateTimePickerSubscriberDOB.TabIndex = 26;
			this.dateTimePickerSubscriberDOB.Value = new System.DateTime(1970, 10, 19, 0, 0, 0, 0);
			// 
			// labelSubscriberID
			// 
			this.labelSubscriberID.Anchor = System.Windows.Forms.AnchorStyles.Right;
			this.labelSubscriberID.AutoSize = true;
			this.labelSubscriberID.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
			this.labelSubscriberID.Location = new System.Drawing.Point(74, 503);
			this.labelSubscriberID.Name = "labelSubscriberID";
			this.labelSubscriberID.Size = new System.Drawing.Size(74, 13);
			this.labelSubscriberID.TabIndex = 29;
			this.labelSubscriberID.Text = "Subscriber ID:";
			// 
			// labelSex
			// 
			this.labelSex.Anchor = System.Windows.Forms.AnchorStyles.Right;
			this.labelSex.AutoSize = true;
			this.labelSex.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
			this.labelSex.Location = new System.Drawing.Point(103, 476);
			this.labelSex.Name = "labelSex";
			this.labelSex.Size = new System.Drawing.Size(45, 13);
			this.labelSex.TabIndex = 27;
			this.labelSex.Text = "Gender:";
			// 
			// labelSubscriberDOB
			// 
			this.labelSubscriberDOB.Anchor = System.Windows.Forms.AnchorStyles.Right;
			this.labelSubscriberDOB.AutoSize = true;
			this.labelSubscriberDOB.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
			this.labelSubscriberDOB.Location = new System.Drawing.Point(79, 448);
			this.labelSubscriberDOB.Name = "labelSubscriberDOB";
			this.labelSubscriberDOB.Size = new System.Drawing.Size(69, 13);
			this.labelSubscriberDOB.TabIndex = 25;
			this.labelSubscriberDOB.Text = "Date of Birth:";
			// 
			// labelSubscriberLast
			// 
			this.labelSubscriberLast.Anchor = System.Windows.Forms.AnchorStyles.Right;
			this.labelSubscriberLast.AutoSize = true;
			this.labelSubscriberLast.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
			this.labelSubscriberLast.Location = new System.Drawing.Point(87, 422);
			this.labelSubscriberLast.Name = "labelSubscriberLast";
			this.labelSubscriberLast.Size = new System.Drawing.Size(61, 13);
			this.labelSubscriberLast.TabIndex = 23;
			this.labelSubscriberLast.Text = "Last Name:";
			// 
			// labelSubscriberFirst
			// 
			this.labelSubscriberFirst.Anchor = System.Windows.Forms.AnchorStyles.Right;
			this.labelSubscriberFirst.AutoSize = true;
			this.labelSubscriberFirst.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
			this.labelSubscriberFirst.Location = new System.Drawing.Point(88, 396);
			this.labelSubscriberFirst.Name = "labelSubscriberFirst";
			this.labelSubscriberFirst.Size = new System.Drawing.Size(60, 13);
			this.labelSubscriberFirst.TabIndex = 21;
			this.labelSubscriberFirst.Text = "First Name:";
			// 
			// labelPayeeTitle
			// 
			this.labelPayeeTitle.Anchor = System.Windows.Forms.AnchorStyles.Left;
			this.labelPayeeTitle.AutoSize = true;
			this.labelPayeeTitle.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
			this.labelPayeeTitle.Location = new System.Drawing.Point(3, 20);
			this.labelPayeeTitle.Name = "labelPayeeTitle";
			this.labelPayeeTitle.Size = new System.Drawing.Size(42, 13);
			this.labelPayeeTitle.TabIndex = 37;
			this.labelPayeeTitle.Text = "Payee";
			// 
			// labelSubscriberHeading
			// 
			this.labelSubscriberHeading.Anchor = System.Windows.Forms.AnchorStyles.Left;
			this.labelSubscriberHeading.AutoSize = true;
			this.labelSubscriberHeading.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
			this.labelSubscriberHeading.Location = new System.Drawing.Point(3, 377);
			this.labelSubscriberHeading.Name = "labelSubscriberHeading";
			this.labelSubscriberHeading.Size = new System.Drawing.Size(67, 13);
			this.labelSubscriberHeading.TabIndex = 20;
			this.labelSubscriberHeading.Text = "Subscriber";
			// 
			// checkBoxUseDependent
			// 
			this.checkBoxUseDependent.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
			this.checkBoxUseDependent.AutoSize = true;
			this.checkBoxUseDependent.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
			this.checkBoxUseDependent.Location = new System.Drawing.Point(3, 526);
			this.checkBoxUseDependent.Name = "checkBoxUseDependent";
			this.checkBoxUseDependent.Size = new System.Drawing.Size(88, 17);
			this.checkBoxUseDependent.TabIndex = 31;
			this.checkBoxUseDependent.Text = "Dependent";
			this.checkBoxUseDependent.UseVisualStyleBackColor = true;
			this.checkBoxUseDependent.CheckedChanged += new System.EventHandler(this.checkBoxUseDependent_CheckedChanged);
			// 
			// labelDepGender
			// 
			this.labelDepGender.Anchor = System.Windows.Forms.AnchorStyles.Right;
			this.labelDepGender.AutoSize = true;
			this.labelDepGender.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
			this.labelDepGender.Location = new System.Drawing.Point(120, 631);
			this.labelDepGender.Name = "labelDepGender";
			this.labelDepGender.Size = new System.Drawing.Size(28, 13);
			this.labelDepGender.TabIndex = 38;
			this.labelDepGender.Text = "Sex:";
			// 
			// textBoxDependentSubscriberId
			// 
			this.textBoxDependentSubscriberId.Dock = System.Windows.Forms.DockStyle.Fill;
			this.textBoxDependentSubscriberId.Enabled = false;
			this.textBoxDependentSubscriberId.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
			this.textBoxDependentSubscriberId.Location = new System.Drawing.Point(154, 654);
			this.textBoxDependentSubscriberId.Name = "textBoxDependentSubscriberId";
			this.textBoxDependentSubscriberId.Size = new System.Drawing.Size(183, 20);
			this.textBoxDependentSubscriberId.TabIndex = 41;
			// 
			// labelOriginatorId
			// 
			this.labelOriginatorId.Anchor = System.Windows.Forms.AnchorStyles.Right;
			this.labelOriginatorId.AutoSize = true;
			this.labelOriginatorId.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
			this.labelOriginatorId.Location = new System.Drawing.Point(27, 222);
			this.labelOriginatorId.Name = "labelOriginatorId";
			this.labelOriginatorId.Size = new System.Drawing.Size(121, 13);
			this.labelOriginatorId.TabIndex = 16;
			this.labelOriginatorId.Text = "Originating Company ID:";
			// 
			// textBoxTraceNumber
			// 
			this.textBoxTraceNumber.Dock = System.Windows.Forms.DockStyle.Fill;
			this.textBoxTraceNumber.Location = new System.Drawing.Point(154, 193);
			this.textBoxTraceNumber.Name = "textBoxTraceNumber";
			this.textBoxTraceNumber.Size = new System.Drawing.Size(183, 20);
			this.textBoxTraceNumber.TabIndex = 15;
			// 
			// textBoxOriginatingCompanyId
			// 
			this.textBoxOriginatingCompanyId.Dock = System.Windows.Forms.DockStyle.Fill;
			this.textBoxOriginatingCompanyId.Location = new System.Drawing.Point(154, 219);
			this.textBoxOriginatingCompanyId.Name = "textBoxOriginatingCompanyId";
			this.textBoxOriginatingCompanyId.Size = new System.Drawing.Size(183, 20);
			this.textBoxOriginatingCompanyId.TabIndex = 17;
			// 
			// labelFederalTaxId
			// 
			this.labelFederalTaxId.Anchor = System.Windows.Forms.AnchorStyles.Right;
			this.labelFederalTaxId.AutoSize = true;
			this.labelFederalTaxId.Location = new System.Drawing.Point(68, 117);
			this.labelFederalTaxId.Name = "labelFederalTaxId";
			this.labelFederalTaxId.Size = new System.Drawing.Size(80, 13);
			this.labelFederalTaxId.TabIndex = 8;
			this.labelFederalTaxId.Text = "Federal Tax ID:";
			// 
			// textBoxTaxId
			// 
			this.textBoxTaxId.Dock = System.Windows.Forms.DockStyle.Fill;
			this.textBoxTaxId.Location = new System.Drawing.Point(154, 114);
			this.textBoxTaxId.Name = "textBoxTaxId";
			this.textBoxTaxId.Size = new System.Drawing.Size(183, 20);
			this.textBoxTaxId.TabIndex = 9;
			this.textBoxTaxId.TextChanged += new System.EventHandler(this.textBoxTaxId_TextChanged);
			// 
			// label2
			// 
			this.label2.Anchor = System.Windows.Forms.AnchorStyles.Right;
			this.label2.AutoSize = true;
			this.label2.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
			this.label2.Location = new System.Drawing.Point(74, 657);
			this.label2.Name = "label2";
			this.label2.Size = new System.Drawing.Size(74, 13);
			this.label2.TabIndex = 40;
			this.label2.Text = "Subscriber ID:";
			// 
			// labelDependentRelationship
			// 
			this.labelDependentRelationship.Anchor = System.Windows.Forms.AnchorStyles.Right;
			this.labelDependentRelationship.AutoSize = true;
			this.labelDependentRelationship.Location = new System.Drawing.Point(15, 682);
			this.labelDependentRelationship.Name = "labelDependentRelationship";
			this.labelDependentRelationship.Size = new System.Drawing.Size(133, 13);
			this.labelDependentRelationship.TabIndex = 42;
			this.labelDependentRelationship.Text = "Relationship to Subscriber:";
			// 
			// comboBoxRelationship
			// 
			this.comboBoxRelationship.AutoCompleteMode = System.Windows.Forms.AutoCompleteMode.SuggestAppend;
			this.comboBoxRelationship.AutoCompleteSource = System.Windows.Forms.AutoCompleteSource.ListItems;
			this.comboBoxRelationship.Dock = System.Windows.Forms.DockStyle.Fill;
			this.comboBoxRelationship.FormattingEnabled = true;
			this.comboBoxRelationship.Location = new System.Drawing.Point(154, 679);
			this.comboBoxRelationship.Name = "comboBoxRelationship";
			this.comboBoxRelationship.Size = new System.Drawing.Size(183, 21);
			this.comboBoxRelationship.TabIndex = 43;
			// 
			// buttonClose
			// 
			this.buttonClose.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
			this.buttonClose.DialogResult = System.Windows.Forms.DialogResult.OK;
			this.buttonClose.Location = new System.Drawing.Point(927, 790);
			this.buttonClose.Name = "buttonClose";
			this.buttonClose.Size = new System.Drawing.Size(138, 2);
			this.buttonClose.TabIndex = 4;
			this.buttonClose.Text = "Close";
			this.buttonClose.UseVisualStyleBackColor = true;
			// 
			// tableLayoutPanelSerializing
			// 
			this.tableLayoutPanelSerializing.ColumnCount = 3;
			this.tableLayoutPanelSerializing.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle());
			this.tableLayoutPanelSerializing.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle());
			this.tableLayoutPanelSerializing.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 100F));
			this.tableLayoutPanelSerializing.Controls.Add(this.checkBoxSerializeRequest, 0, 0);
			this.tableLayoutPanelSerializing.Controls.Add(this.checkBoxSerializeResponse, 1, 0);
			this.tableLayoutPanelSerializing.Dock = System.Windows.Forms.DockStyle.Fill;
			this.tableLayoutPanelSerializing.Location = new System.Drawing.Point(349, 749);
			this.tableLayoutPanelSerializing.Name = "tableLayoutPanelSerializing";
			this.tableLayoutPanelSerializing.RowCount = 1;
			this.tableLayoutPanelSerializing.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 100F));
			this.tableLayoutPanelSerializing.Size = new System.Drawing.Size(716, 23);
			this.tableLayoutPanelSerializing.TabIndex = 3;
			// 
			// checkBoxSerializeRequest
			// 
			this.checkBoxSerializeRequest.AutoSize = true;
			this.checkBoxSerializeRequest.Location = new System.Drawing.Point(3, 3);
			this.checkBoxSerializeRequest.Name = "checkBoxSerializeRequest";
			this.checkBoxSerializeRequest.Size = new System.Drawing.Size(108, 17);
			this.checkBoxSerializeRequest.TabIndex = 0;
			this.checkBoxSerializeRequest.Text = "Serialize Request";
			this.checkBoxSerializeRequest.UseVisualStyleBackColor = true;
			// 
			// checkBoxSerializeResponse
			// 
			this.checkBoxSerializeResponse.AutoSize = true;
			this.checkBoxSerializeResponse.Location = new System.Drawing.Point(117, 3);
			this.checkBoxSerializeResponse.Name = "checkBoxSerializeResponse";
			this.checkBoxSerializeResponse.Size = new System.Drawing.Size(116, 17);
			this.checkBoxSerializeResponse.TabIndex = 1;
			this.checkBoxSerializeResponse.Text = "Serialize Response";
			this.checkBoxSerializeResponse.UseVisualStyleBackColor = true;
			// 
			// tableLayoutPanelRequestMgmt
			// 
			this.tableLayoutPanelRequestMgmt.ColumnCount = 1;
			this.tableLayoutPanelRequestMgmt.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 50F));
			this.tableLayoutPanelRequestMgmt.Controls.Add(this.tableLayoutPanelRequests, 0, 0);
			this.tableLayoutPanelRequestMgmt.Controls.Add(this.tableLayoutPanelResponses, 0, 1);
			this.tableLayoutPanelRequestMgmt.Location = new System.Drawing.Point(349, 23);
			this.tableLayoutPanelRequestMgmt.Name = "tableLayoutPanelRequestMgmt";
			this.tableLayoutPanelRequestMgmt.RowCount = 2;
			this.tableLayoutPanelRequestMgmt.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 23.55491F));
			this.tableLayoutPanelRequestMgmt.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 76.44508F));
			this.tableLayoutPanelRequestMgmt.Size = new System.Drawing.Size(680, 692);
			this.tableLayoutPanelRequestMgmt.TabIndex = 41;
			// 
			// tableLayoutPanelRequests
			// 
			this.tableLayoutPanelRequests.ColumnCount = 1;
			this.tableLayoutPanelRequests.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 100F));
			this.tableLayoutPanelRequests.Controls.Add(this.dataGridViewRequests, 0, 1);
			this.tableLayoutPanelRequests.Controls.Add(this.tableLayoutPanelSubmitButtons, 0, 2);
			this.tableLayoutPanelRequests.Controls.Add(this.labelRequests, 0, 0);
			this.tableLayoutPanelRequests.Location = new System.Drawing.Point(3, 3);
			this.tableLayoutPanelRequests.Name = "tableLayoutPanelRequests";
			this.tableLayoutPanelRequests.RowCount = 3;
			this.tableLayoutPanelRequests.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 20F));
			this.tableLayoutPanelRequests.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 97F));
			this.tableLayoutPanelRequests.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 16F));
			this.tableLayoutPanelRequests.Size = new System.Drawing.Size(660, 153);
			this.tableLayoutPanelRequests.TabIndex = 40;
			// 
			// dataGridViewRequests
			// 
			this.dataGridViewRequests.AllowUserToAddRows = false;
			this.dataGridViewRequests.AllowUserToDeleteRows = false;
			this.dataGridViewRequests.AllowUserToResizeRows = false;
			dataGridViewCellStyle7.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft;
			dataGridViewCellStyle7.BackColor = System.Drawing.SystemColors.Control;
			dataGridViewCellStyle7.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
			dataGridViewCellStyle7.ForeColor = System.Drawing.SystemColors.WindowText;
			dataGridViewCellStyle7.SelectionBackColor = System.Drawing.SystemColors.Highlight;
			dataGridViewCellStyle7.SelectionForeColor = System.Drawing.SystemColors.HighlightText;
			dataGridViewCellStyle7.WrapMode = System.Windows.Forms.DataGridViewTriState.True;
			this.dataGridViewRequests.ColumnHeadersDefaultCellStyle = dataGridViewCellStyle7;
			this.dataGridViewRequests.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
			this.dataGridViewRequests.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.VendorSiteId,
            this.PayerCommonName,
            this.PayeeName,
            this.SubscriberName,
            this.DependentName});
			dataGridViewCellStyle8.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft;
			dataGridViewCellStyle8.BackColor = System.Drawing.SystemColors.Window;
			dataGridViewCellStyle8.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
			dataGridViewCellStyle8.ForeColor = System.Drawing.SystemColors.ControlText;
			dataGridViewCellStyle8.SelectionBackColor = System.Drawing.SystemColors.Highlight;
			dataGridViewCellStyle8.SelectionForeColor = System.Drawing.SystemColors.HighlightText;
			dataGridViewCellStyle8.WrapMode = System.Windows.Forms.DataGridViewTriState.False;
			this.dataGridViewRequests.DefaultCellStyle = dataGridViewCellStyle8;
			this.dataGridViewRequests.Dock = System.Windows.Forms.DockStyle.Fill;
			this.dataGridViewRequests.Location = new System.Drawing.Point(3, 23);
			this.dataGridViewRequests.Name = "dataGridViewRequests";
			this.dataGridViewRequests.ReadOnly = true;
			dataGridViewCellStyle9.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft;
			dataGridViewCellStyle9.BackColor = System.Drawing.SystemColors.Control;
			dataGridViewCellStyle9.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
			dataGridViewCellStyle9.ForeColor = System.Drawing.SystemColors.WindowText;
			dataGridViewCellStyle9.SelectionBackColor = System.Drawing.SystemColors.Highlight;
			dataGridViewCellStyle9.SelectionForeColor = System.Drawing.SystemColors.HighlightText;
			dataGridViewCellStyle9.WrapMode = System.Windows.Forms.DataGridViewTriState.True;
			this.dataGridViewRequests.RowHeadersDefaultCellStyle = dataGridViewCellStyle9;
			this.dataGridViewRequests.RowHeadersVisible = false;
			this.dataGridViewRequests.Size = new System.Drawing.Size(654, 91);
			this.dataGridViewRequests.TabIndex = 0;
			// 
			// VendorSiteId
			// 
			this.VendorSiteId.HeaderText = "Vendor Site ID";
			this.VendorSiteId.Name = "VendorSiteId";
			this.VendorSiteId.ReadOnly = true;
			// 
			// PayerCommonName
			// 
			this.PayerCommonName.HeaderText = "Payer Common Name";
			this.PayerCommonName.Name = "PayerCommonName";
			this.PayerCommonName.ReadOnly = true;
			// 
			// PayeeName
			// 
			this.PayeeName.HeaderText = "Doctor Name";
			this.PayeeName.Name = "PayeeName";
			this.PayeeName.ReadOnly = true;
			// 
			// SubscriberName
			// 
			this.SubscriberName.HeaderText = "Subscriber Name";
			this.SubscriberName.Name = "SubscriberName";
			this.SubscriberName.ReadOnly = true;
			// 
			// DependentName
			// 
			this.DependentName.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.Fill;
			this.DependentName.HeaderText = "Dependent Name";
			this.DependentName.Name = "DependentName";
			this.DependentName.ReadOnly = true;
			// 
			// tableLayoutPanelSubmitButtons
			// 
			this.tableLayoutPanelSubmitButtons.ColumnCount = 4;
			this.tableLayoutPanelSubmitButtons.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 100F));
			this.tableLayoutPanelSubmitButtons.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Absolute, 144F));
			this.tableLayoutPanelSubmitButtons.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Absolute, 149F));
			this.tableLayoutPanelSubmitButtons.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Absolute, 80F));
			this.tableLayoutPanelSubmitButtons.Controls.Add(this.buttonSubmitAllRequests, 3, 0);
			this.tableLayoutPanelSubmitButtons.Controls.Add(this.buttonClearRequests, 1, 0);
			this.tableLayoutPanelSubmitButtons.Controls.Add(this.buttonSubmitSelectedRequests, 2, 0);
			this.tableLayoutPanelSubmitButtons.Location = new System.Drawing.Point(3, 120);
			this.tableLayoutPanelSubmitButtons.Name = "tableLayoutPanelSubmitButtons";
			this.tableLayoutPanelSubmitButtons.RowCount = 1;
			this.tableLayoutPanelSubmitButtons.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 100F));
			this.tableLayoutPanelSubmitButtons.Size = new System.Drawing.Size(632, 30);
			this.tableLayoutPanelSubmitButtons.TabIndex = 1;
			// 
			// buttonSubmitAllRequests
			// 
			this.buttonSubmitAllRequests.Location = new System.Drawing.Point(555, 3);
			this.buttonSubmitAllRequests.Name = "buttonSubmitAllRequests";
			this.buttonSubmitAllRequests.Size = new System.Drawing.Size(74, 23);
			this.buttonSubmitAllRequests.TabIndex = 0;
			this.buttonSubmitAllRequests.Text = "Submit All Requests";
			this.buttonSubmitAllRequests.UseVisualStyleBackColor = true;
			this.buttonSubmitAllRequests.Click += new System.EventHandler(this.buttonSubmitAllRequests_Click);
			// 
			// buttonClearRequests
			// 
			this.buttonClearRequests.Anchor = System.Windows.Forms.AnchorStyles.Right;
			this.buttonClearRequests.Location = new System.Drawing.Point(316, 3);
			this.buttonClearRequests.Name = "buttonClearRequests";
			this.buttonClearRequests.Size = new System.Drawing.Size(84, 23);
			this.buttonClearRequests.TabIndex = 1;
			this.buttonClearRequests.Text = "Clear List";
			this.buttonClearRequests.UseVisualStyleBackColor = true;
			this.buttonClearRequests.Click += new System.EventHandler(this.buttonClearRequests_Click);
			// 
			// buttonSubmitSelectedRequests
			// 
			this.buttonSubmitSelectedRequests.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
			this.buttonSubmitSelectedRequests.Location = new System.Drawing.Point(406, 3);
			this.buttonSubmitSelectedRequests.Name = "buttonSubmitSelectedRequests";
			this.buttonSubmitSelectedRequests.Size = new System.Drawing.Size(143, 23);
			this.buttonSubmitSelectedRequests.TabIndex = 0;
			this.buttonSubmitSelectedRequests.Text = "Submit Selected";
			this.buttonSubmitSelectedRequests.UseVisualStyleBackColor = true;
			this.buttonSubmitSelectedRequests.Click += new System.EventHandler(this.buttonSubmitSelectedRequests_Click);
			// 
			// labelRequests
			// 
			this.labelRequests.AutoSize = true;
			this.labelRequests.Font = new System.Drawing.Font("Microsoft Sans Serif", 10F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
			this.labelRequests.Location = new System.Drawing.Point(3, 0);
			this.labelRequests.Name = "labelRequests";
			this.labelRequests.Size = new System.Drawing.Size(76, 17);
			this.labelRequests.TabIndex = 2;
			this.labelRequests.Text = "Requests";
			// 
			// tableLayoutPanelResponses
			// 
			this.tableLayoutPanelResponses.ColumnCount = 1;
			this.tableLayoutPanelResponses.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 100F));
			this.tableLayoutPanelResponses.Controls.Add(this.treeViewSoapResponse, 0, 5);
			this.tableLayoutPanelResponses.Controls.Add(this.label1, 0, 3);
			this.tableLayoutPanelResponses.Controls.Add(this.dataGridViewEligibilityResponses, 0, 1);
			this.tableLayoutPanelResponses.Controls.Add(this.buttonGetEligibilityResponses, 0, 2);
			this.tableLayoutPanelResponses.Controls.Add(this.richTextBoxResults, 0, 4);
			this.tableLayoutPanelResponses.Controls.Add(this.labelResponses, 0, 0);
			this.tableLayoutPanelResponses.Location = new System.Drawing.Point(3, 165);
			this.tableLayoutPanelResponses.Name = "tableLayoutPanelResponses";
			this.tableLayoutPanelResponses.RowCount = 6;
			this.tableLayoutPanelResponses.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 20F));
			this.tableLayoutPanelResponses.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 99F));
			this.tableLayoutPanelResponses.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 29F));
			this.tableLayoutPanelResponses.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 23F));
			this.tableLayoutPanelResponses.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 160F));
			this.tableLayoutPanelResponses.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 20F));
			this.tableLayoutPanelResponses.Size = new System.Drawing.Size(657, 494);
			this.tableLayoutPanelResponses.TabIndex = 50;
			// 
			// treeViewSoapResponse
			// 
			this.treeViewSoapResponse.Location = new System.Drawing.Point(3, 334);
			this.treeViewSoapResponse.Name = "treeViewSoapResponse";
			this.treeViewSoapResponse.Size = new System.Drawing.Size(632, 157);
			this.treeViewSoapResponse.TabIndex = 40;
			// 
			// label1
			// 
			this.label1.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
			this.label1.AutoSize = true;
			this.label1.Font = new System.Drawing.Font("Microsoft Sans Serif", 10F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
			this.label1.Location = new System.Drawing.Point(3, 154);
			this.label1.Name = "label1";
			this.label1.Size = new System.Drawing.Size(127, 17);
			this.label1.TabIndex = 2;
			this.label1.Text = "Response Detail";
			// 
			// dataGridViewEligibilityResponses
			// 
			this.dataGridViewEligibilityResponses.AllowUserToAddRows = false;
			this.dataGridViewEligibilityResponses.AllowUserToDeleteRows = false;
			dataGridViewCellStyle10.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft;
			dataGridViewCellStyle10.BackColor = System.Drawing.SystemColors.Control;
			dataGridViewCellStyle10.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
			dataGridViewCellStyle10.ForeColor = System.Drawing.SystemColors.WindowText;
			dataGridViewCellStyle10.SelectionBackColor = System.Drawing.SystemColors.Highlight;
			dataGridViewCellStyle10.SelectionForeColor = System.Drawing.SystemColors.HighlightText;
			dataGridViewCellStyle10.WrapMode = System.Windows.Forms.DataGridViewTriState.True;
			this.dataGridViewEligibilityResponses.ColumnHeadersDefaultCellStyle = dataGridViewCellStyle10;
			this.dataGridViewEligibilityResponses.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
			this.dataGridViewEligibilityResponses.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.RequestID,
            this.Status,
            this.Errors,
            this.ErrorMessage});
			dataGridViewCellStyle11.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft;
			dataGridViewCellStyle11.BackColor = System.Drawing.SystemColors.Window;
			dataGridViewCellStyle11.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
			dataGridViewCellStyle11.ForeColor = System.Drawing.SystemColors.ControlText;
			dataGridViewCellStyle11.SelectionBackColor = System.Drawing.SystemColors.Highlight;
			dataGridViewCellStyle11.SelectionForeColor = System.Drawing.SystemColors.HighlightText;
			dataGridViewCellStyle11.WrapMode = System.Windows.Forms.DataGridViewTriState.False;
			this.dataGridViewEligibilityResponses.DefaultCellStyle = dataGridViewCellStyle11;
			this.dataGridViewEligibilityResponses.Dock = System.Windows.Forms.DockStyle.Fill;
			this.dataGridViewEligibilityResponses.Location = new System.Drawing.Point(3, 23);
			this.dataGridViewEligibilityResponses.Name = "dataGridViewEligibilityResponses";
			this.dataGridViewEligibilityResponses.ReadOnly = true;
			dataGridViewCellStyle12.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft;
			dataGridViewCellStyle12.BackColor = System.Drawing.SystemColors.Control;
			dataGridViewCellStyle12.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
			dataGridViewCellStyle12.ForeColor = System.Drawing.SystemColors.WindowText;
			dataGridViewCellStyle12.SelectionBackColor = System.Drawing.SystemColors.Highlight;
			dataGridViewCellStyle12.SelectionForeColor = System.Drawing.SystemColors.HighlightText;
			dataGridViewCellStyle12.WrapMode = System.Windows.Forms.DataGridViewTriState.True;
			this.dataGridViewEligibilityResponses.RowHeadersDefaultCellStyle = dataGridViewCellStyle12;
			this.dataGridViewEligibilityResponses.RowHeadersVisible = false;
			this.dataGridViewEligibilityResponses.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect;
			this.dataGridViewEligibilityResponses.Size = new System.Drawing.Size(651, 93);
			this.dataGridViewEligibilityResponses.TabIndex = 0;
			// 
			// RequestID
			// 
			this.RequestID.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.ColumnHeader;
			this.RequestID.HeaderText = "Request ID";
			this.RequestID.Name = "RequestID";
			this.RequestID.ReadOnly = true;
			this.RequestID.Width = 86;
			// 
			// Status
			// 
			this.Status.HeaderText = "Status";
			this.Status.Name = "Status";
			this.Status.ReadOnly = true;
			// 
			// Errors
			// 
			this.Errors.HeaderText = "Responses";
			this.Errors.Name = "Errors";
			this.Errors.ReadOnly = true;
			this.Errors.Width = 70;
			// 
			// ErrorMessage
			// 
			this.ErrorMessage.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.Fill;
			this.ErrorMessage.HeaderText = "Errors";
			this.ErrorMessage.Name = "ErrorMessage";
			this.ErrorMessage.ReadOnly = true;
			// 
			// buttonGetEligibilityResponses
			// 
			this.buttonGetEligibilityResponses.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
			this.buttonGetEligibilityResponses.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
			this.buttonGetEligibilityResponses.Location = new System.Drawing.Point(491, 122);
			this.buttonGetEligibilityResponses.Name = "buttonGetEligibilityResponses";
			this.buttonGetEligibilityResponses.Size = new System.Drawing.Size(163, 23);
			this.buttonGetEligibilityResponses.TabIndex = 1;
			this.buttonGetEligibilityResponses.Text = "Get Eligibility Responses";
			this.buttonGetEligibilityResponses.UseVisualStyleBackColor = true;
			this.buttonGetEligibilityResponses.Click += new System.EventHandler(this.buttonGetEligibilityResponses_Click);
			// 
			// richTextBoxResults
			// 
			this.richTextBoxResults.Location = new System.Drawing.Point(3, 174);
			this.richTextBoxResults.Name = "richTextBoxResults";
			this.richTextBoxResults.Size = new System.Drawing.Size(632, 154);
			this.richTextBoxResults.TabIndex = 3;
			this.richTextBoxResults.Text = "";
			// 
			// labelResponses
			// 
			this.labelResponses.AutoSize = true;
			this.labelResponses.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
			this.labelResponses.Location = new System.Drawing.Point(3, 0);
			this.labelResponses.Name = "labelResponses";
			this.labelResponses.Size = new System.Drawing.Size(87, 16);
			this.labelResponses.TabIndex = 4;
			this.labelResponses.Text = "Responses";
			// 
			// BenefitRequestForm
			// 
			this.AcceptButton = this.buttonClose;
			this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
			this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
			this.ClientSize = new System.Drawing.Size(1170, 818);
			this.Controls.Add(this.tableLayoutPanelBase);
			this.Name = "BenefitRequestForm";
			this.StartPosition = System.Windows.Forms.FormStartPosition.CenterParent;
			this.Text = "Submit Eligibility Requests";
			this.FormClosing += new System.Windows.Forms.FormClosingEventHandler(this.BenefitRequestForm_FormClosing);
			this.Load += new System.EventHandler(this.BenefitRequestForm_Load);
			((System.ComponentModel.ISupportInitialize)(this.dataGridViewServiceTypes)).EndInit();
			this.tableLayoutPanelBase.ResumeLayout(false);
			this.tableLayoutPanelBase.PerformLayout();
			this.tableLayoutPanelEligibilityForm.ResumeLayout(false);
			this.tableLayoutPanelEligibilityForm.PerformLayout();
			this.tableLayoutPanelDepGender.ResumeLayout(false);
			this.tableLayoutPanelDepGender.PerformLayout();
			this.tableLayoutPanelSubGender.ResumeLayout(false);
			this.tableLayoutPanelSubGender.PerformLayout();
			this.tableLayoutPanelSerializing.ResumeLayout(false);
			this.tableLayoutPanelSerializing.PerformLayout();
			this.tableLayoutPanelRequestMgmt.ResumeLayout(false);
			this.tableLayoutPanelRequests.ResumeLayout(false);
			this.tableLayoutPanelRequests.PerformLayout();
			((System.ComponentModel.ISupportInitialize)(this.dataGridViewRequests)).EndInit();
			this.tableLayoutPanelSubmitButtons.ResumeLayout(false);
			this.tableLayoutPanelResponses.ResumeLayout(false);
			this.tableLayoutPanelResponses.PerformLayout();
			((System.ComponentModel.ISupportInitialize)(this.dataGridViewEligibilityResponses)).EndInit();
			this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Label labelIsTest;
        private System.Windows.Forms.Label labelPayeeNPI;
        private System.Windows.Forms.Label labelEligibilityPayeeFirstName;
        private System.Windows.Forms.Label labelEligibilityCommonName;
        private System.Windows.Forms.Label labelEligibilityVendorSiteID;
        private System.Windows.Forms.TextBox textBoxSubscriberFirst;
        private System.Windows.Forms.TextBox textBoxSubscriberLast;
        private System.Windows.Forms.CheckBox checkBoxEligibilityIsTest;
        private System.Windows.Forms.TextBox textBoxNPI;
        private System.Windows.Forms.TextBox textBoxPayerID;
        private System.Windows.Forms.TextBox textBoxEligibilityVendorSiteId;
        private System.Windows.Forms.TextBox textBoxEligibilityPayeeFirstName;
        private System.Windows.Forms.TextBox textBoxEligibilityPayeeCommonName;
        private System.Windows.Forms.Label labelServiceType;
        private System.Windows.Forms.DataGridView dataGridViewServiceTypes;
        private System.Windows.Forms.TableLayoutPanel tableLayoutPanelBase;
        private System.Windows.Forms.Label labelEligibilityRequests;
        private System.Windows.Forms.TableLayoutPanel tableLayoutPanelEligibilityForm;
        private System.Windows.Forms.Label labelPayeeTitle;
        private System.Windows.Forms.Label labelSubscriberID;
        private System.Windows.Forms.Label labelSex;
        private System.Windows.Forms.Label labelSubscriberDOB;
        private System.Windows.Forms.Label labelSubscriberLast;
        private System.Windows.Forms.Label labelSubscriberFirst;
        private System.Windows.Forms.Label labelSubscriberHeading;
        private System.Windows.Forms.TableLayoutPanel tableLayoutPanelDepGender;
        private System.Windows.Forms.RadioButton radioButtonDepFemale;
        private System.Windows.Forms.RadioButton radioButtonDepMale;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.DateTimePicker dateTimePickerDependentDOB;
        private System.Windows.Forms.TextBox textBoxDependentLast;
        private System.Windows.Forms.TextBox textBoxDependentFirst;
        private System.Windows.Forms.Label labelDependentDOB;
        private System.Windows.Forms.Label labelDependentLast;
        private System.Windows.Forms.Label labelDependentFirst;
        private System.Windows.Forms.TextBox textBoxSubscriberID;
        private System.Windows.Forms.TableLayoutPanel tableLayoutPanelSubGender;
        private System.Windows.Forms.RadioButton radioButtonSubFemale;
        private System.Windows.Forms.RadioButton radioButtonSubMale;
        private System.Windows.Forms.DateTimePicker dateTimePickerSubscriberDOB;
        private System.Windows.Forms.CheckBox checkBoxUseDependent;
        private System.Windows.Forms.Label labelDepGender;
        private System.Windows.Forms.TextBox textBoxDependentSubscriberId;
        private System.Windows.Forms.DataGridView dataGridViewEligibilityResponses;
        private System.Windows.Forms.Button buttonSubmitEligibilityRequest;
        private System.Windows.Forms.Button buttonGetEligibilityResponses;
        private System.Windows.Forms.Button buttonGetPayer;
        private System.Windows.Forms.Label labelEligibilityResponses;
        private System.Windows.Forms.TableLayoutPanel tableLayoutPanelResponses;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.DataGridViewTextBoxColumn RequestID;
        private System.Windows.Forms.DataGridViewTextBoxColumn Status;
        private System.Windows.Forms.DataGridViewTextBoxColumn Errors;
        private System.Windows.Forms.DataGridViewTextBoxColumn ErrorMessage;
        private System.Windows.Forms.RichTextBox richTextBoxResults;
        private System.Windows.Forms.Button buttonClose;
        private System.Windows.Forms.Label labelTraceNumber;
        private System.Windows.Forms.Label labelOriginatorId;
        private System.Windows.Forms.TextBox textBoxTraceNumber;
        private System.Windows.Forms.TextBox textBoxOriginatingCompanyId;
        private System.Windows.Forms.TableLayoutPanel tableLayoutPanelSerializing;
        private System.Windows.Forms.CheckBox checkBoxSerializeRequest;
        private System.Windows.Forms.CheckBox checkBoxSerializeResponse;
        private System.Windows.Forms.Label labelFederalTaxId;
        private System.Windows.Forms.TextBox textBoxTaxId;
        private System.Windows.Forms.TableLayoutPanel tableLayoutPanelRequestMgmt;
        private System.Windows.Forms.TableLayoutPanel tableLayoutPanelRequests;
        private System.Windows.Forms.DataGridView dataGridViewRequests;
        private System.Windows.Forms.TableLayoutPanel tableLayoutPanelSubmitButtons;
        private System.Windows.Forms.Button buttonSubmitAllRequests;
        private System.Windows.Forms.Button buttonClearRequests;
        private System.Windows.Forms.Label labelRequests;
        private System.Windows.Forms.Label labelResponses;
        private System.Windows.Forms.Button buttonSubmitSelectedRequests;
        private System.Windows.Forms.DataGridViewTextBoxColumn VendorSiteId;
        private System.Windows.Forms.DataGridViewTextBoxColumn PayerCommonName;
        private System.Windows.Forms.DataGridViewTextBoxColumn PayeeName;
        private System.Windows.Forms.DataGridViewTextBoxColumn SubscriberName;
        private System.Windows.Forms.DataGridViewTextBoxColumn DependentName;
		private System.Windows.Forms.TreeView treeViewSoapResponse;
		private System.Windows.Forms.Label labelDependentRelationship;
		private System.Windows.Forms.ComboBox comboBoxRelationship;
	}
}
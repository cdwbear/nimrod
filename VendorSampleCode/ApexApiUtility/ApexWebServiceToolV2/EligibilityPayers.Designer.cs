namespace ApexWebServiceToolV2
{
    partial class EligibilityPayers
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
            this.resultsControlElig = new CommonControls.ResultsControl();
            this.tableLayoutPanelBase = new System.Windows.Forms.TableLayoutPanel();
            this.tableLayoutPanel1 = new System.Windows.Forms.TableLayoutPanel();
            this.buttonSelectPayer = new System.Windows.Forms.Button();
            this.buttonCancel = new System.Windows.Forms.Button();
            this.tableLayoutPanelPayerTypes = new System.Windows.Forms.TableLayoutPanel();
            this.radioButtonTest = new System.Windows.Forms.RadioButton();
            this.radioButtonLive = new System.Windows.Forms.RadioButton();
            this.tableLayoutPanelLineOfBusiness = new System.Windows.Forms.TableLayoutPanel();
            this.labelLob = new System.Windows.Forms.Label();
            this.radioButtonMedical = new System.Windows.Forms.RadioButton();
            this.radioButtonDental = new System.Windows.Forms.RadioButton();
            this.radioButtonMedicaid = new System.Windows.Forms.RadioButton();
            this.tableLayoutPanelBase.SuspendLayout();
            this.tableLayoutPanel1.SuspendLayout();
            this.tableLayoutPanelPayerTypes.SuspendLayout();
            this.tableLayoutPanelLineOfBusiness.SuspendLayout();
            this.SuspendLayout();
            // 
            // resultsControlElig
            // 
            this.resultsControlElig.Dock = System.Windows.Forms.DockStyle.Fill;
            this.resultsControlElig.Location = new System.Drawing.Point(3, 67);
            this.resultsControlElig.Name = "resultsControlElig";
            this.resultsControlElig.ResultsLabel = "Results";
            this.resultsControlElig.Size = new System.Drawing.Size(966, 231);
            this.resultsControlElig.TabIndex = 1;
            // 
            // tableLayoutPanelBase
            // 
            this.tableLayoutPanelBase.ColumnCount = 1;
            this.tableLayoutPanelBase.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 100F));
            this.tableLayoutPanelBase.Controls.Add(this.tableLayoutPanel1, 0, 3);
            this.tableLayoutPanelBase.Controls.Add(this.tableLayoutPanelPayerTypes, 0, 0);
            this.tableLayoutPanelBase.Controls.Add(this.resultsControlElig, 0, 2);
            this.tableLayoutPanelBase.Controls.Add(this.tableLayoutPanelLineOfBusiness, 0, 1);
            this.tableLayoutPanelBase.Dock = System.Windows.Forms.DockStyle.Fill;
            this.tableLayoutPanelBase.Location = new System.Drawing.Point(0, 0);
            this.tableLayoutPanelBase.Name = "tableLayoutPanelBase";
            this.tableLayoutPanelBase.RowCount = 4;
            this.tableLayoutPanelBase.RowStyles.Add(new System.Windows.Forms.RowStyle());
            this.tableLayoutPanelBase.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 32F));
            this.tableLayoutPanelBase.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 100F));
            this.tableLayoutPanelBase.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 34F));
            this.tableLayoutPanelBase.Size = new System.Drawing.Size(972, 335);
            this.tableLayoutPanelBase.TabIndex = 0;
            // 
            // tableLayoutPanel1
            // 
            this.tableLayoutPanel1.ColumnCount = 2;
            this.tableLayoutPanel1.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 100F));
            this.tableLayoutPanel1.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle());
            this.tableLayoutPanel1.Controls.Add(this.buttonSelectPayer, 0, 0);
            this.tableLayoutPanel1.Controls.Add(this.buttonCancel, 1, 0);
            this.tableLayoutPanel1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.tableLayoutPanel1.Location = new System.Drawing.Point(3, 304);
            this.tableLayoutPanel1.Name = "tableLayoutPanel1";
            this.tableLayoutPanel1.RowCount = 1;
            this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 100F));
            this.tableLayoutPanel1.Size = new System.Drawing.Size(966, 28);
            this.tableLayoutPanel1.TabIndex = 2;
            // 
            // buttonSelectPayer
            // 
            this.buttonSelectPayer.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.buttonSelectPayer.DialogResult = System.Windows.Forms.DialogResult.OK;
            this.buttonSelectPayer.Location = new System.Drawing.Point(745, 3);
            this.buttonSelectPayer.Name = "buttonSelectPayer";
            this.buttonSelectPayer.Size = new System.Drawing.Size(106, 22);
            this.buttonSelectPayer.TabIndex = 0;
            this.buttonSelectPayer.Text = "Select Payer";
            this.buttonSelectPayer.UseVisualStyleBackColor = true;
            // 
            // buttonCancel
            // 
            this.buttonCancel.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.buttonCancel.DialogResult = System.Windows.Forms.DialogResult.Cancel;
            this.buttonCancel.Location = new System.Drawing.Point(857, 3);
            this.buttonCancel.Name = "buttonCancel";
            this.buttonCancel.Size = new System.Drawing.Size(106, 22);
            this.buttonCancel.TabIndex = 1;
            this.buttonCancel.Text = "Cancel";
            this.buttonCancel.UseVisualStyleBackColor = true;
            // 
            // tableLayoutPanelPayerTypes
            // 
            this.tableLayoutPanelPayerTypes.ColumnCount = 2;
            this.tableLayoutPanelPayerTypes.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle());
            this.tableLayoutPanelPayerTypes.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 100F));
            this.tableLayoutPanelPayerTypes.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Absolute, 20F));
            this.tableLayoutPanelPayerTypes.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Absolute, 20F));
            this.tableLayoutPanelPayerTypes.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Absolute, 20F));
            this.tableLayoutPanelPayerTypes.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Absolute, 20F));
            this.tableLayoutPanelPayerTypes.Controls.Add(this.radioButtonTest, 1, 0);
            this.tableLayoutPanelPayerTypes.Controls.Add(this.radioButtonLive, 0, 0);
            this.tableLayoutPanelPayerTypes.Dock = System.Windows.Forms.DockStyle.Fill;
            this.tableLayoutPanelPayerTypes.Location = new System.Drawing.Point(3, 3);
            this.tableLayoutPanelPayerTypes.Name = "tableLayoutPanelPayerTypes";
            this.tableLayoutPanelPayerTypes.RowCount = 1;
            this.tableLayoutPanelPayerTypes.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 100F));
            this.tableLayoutPanelPayerTypes.Size = new System.Drawing.Size(966, 26);
            this.tableLayoutPanelPayerTypes.TabIndex = 0;
            // 
            // radioButtonTest
            // 
            this.radioButtonTest.AutoSize = true;
            this.radioButtonTest.Location = new System.Drawing.Point(89, 3);
            this.radioButtonTest.Name = "radioButtonTest";
            this.radioButtonTest.Size = new System.Drawing.Size(138, 17);
            this.radioButtonTest.TabIndex = 1;
            this.radioButtonTest.Text = "Test (Loopback) Payers";
            this.radioButtonTest.UseVisualStyleBackColor = true;
            // 
            // radioButtonLive
            // 
            this.radioButtonLive.AutoSize = true;
            this.radioButtonLive.Checked = true;
            this.radioButtonLive.Location = new System.Drawing.Point(3, 3);
            this.radioButtonLive.Name = "radioButtonLive";
            this.radioButtonLive.Size = new System.Drawing.Size(80, 17);
            this.radioButtonLive.TabIndex = 0;
            this.radioButtonLive.TabStop = true;
            this.radioButtonLive.Text = "Live Payers";
            this.radioButtonLive.UseVisualStyleBackColor = true;
            // 
            // tableLayoutPanelLineOfBusiness
            // 
            this.tableLayoutPanelLineOfBusiness.ColumnCount = 4;
            this.tableLayoutPanelLineOfBusiness.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle());
            this.tableLayoutPanelLineOfBusiness.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle());
            this.tableLayoutPanelLineOfBusiness.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle());
            this.tableLayoutPanelLineOfBusiness.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 100F));
            this.tableLayoutPanelLineOfBusiness.Controls.Add(this.labelLob, 0, 0);
            this.tableLayoutPanelLineOfBusiness.Controls.Add(this.radioButtonMedical, 1, 0);
            this.tableLayoutPanelLineOfBusiness.Controls.Add(this.radioButtonDental, 2, 0);
            this.tableLayoutPanelLineOfBusiness.Controls.Add(this.radioButtonMedicaid, 3, 0);
            this.tableLayoutPanelLineOfBusiness.Dock = System.Windows.Forms.DockStyle.Fill;
            this.tableLayoutPanelLineOfBusiness.Location = new System.Drawing.Point(3, 35);
            this.tableLayoutPanelLineOfBusiness.Name = "tableLayoutPanelLineOfBusiness";
            this.tableLayoutPanelLineOfBusiness.RowCount = 1;
            this.tableLayoutPanelLineOfBusiness.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 100F));
            this.tableLayoutPanelLineOfBusiness.Size = new System.Drawing.Size(966, 26);
            this.tableLayoutPanelLineOfBusiness.TabIndex = 3;
            // 
            // labelLob
            // 
            this.labelLob.Anchor = System.Windows.Forms.AnchorStyles.Left;
            this.labelLob.AutoSize = true;
            this.labelLob.Location = new System.Drawing.Point(3, 6);
            this.labelLob.Name = "labelLob";
            this.labelLob.Size = new System.Drawing.Size(87, 13);
            this.labelLob.TabIndex = 0;
            this.labelLob.Text = "Line of Business:";
            // 
            // radioButtonMedical
            // 
            this.radioButtonMedical.Anchor = System.Windows.Forms.AnchorStyles.Left;
            this.radioButtonMedical.AutoSize = true;
            this.radioButtonMedical.Checked = true;
            this.radioButtonMedical.Location = new System.Drawing.Point(96, 4);
            this.radioButtonMedical.Name = "radioButtonMedical";
            this.radioButtonMedical.Size = new System.Drawing.Size(62, 17);
            this.radioButtonMedical.TabIndex = 1;
            this.radioButtonMedical.TabStop = true;
            this.radioButtonMedical.Text = "Medical";
            this.radioButtonMedical.UseVisualStyleBackColor = true;
            // 
            // radioButtonDental
            // 
            this.radioButtonDental.Anchor = System.Windows.Forms.AnchorStyles.Left;
            this.radioButtonDental.AutoSize = true;
            this.radioButtonDental.Location = new System.Drawing.Point(164, 4);
            this.radioButtonDental.Name = "radioButtonDental";
            this.radioButtonDental.Size = new System.Drawing.Size(56, 17);
            this.radioButtonDental.TabIndex = 1;
            this.radioButtonDental.Text = "Dental";
            this.radioButtonDental.UseVisualStyleBackColor = true;
            // 
            // radioButtonMedicaid
            // 
            this.radioButtonMedicaid.Anchor = System.Windows.Forms.AnchorStyles.Left;
            this.radioButtonMedicaid.AutoSize = true;
            this.radioButtonMedicaid.Location = new System.Drawing.Point(226, 4);
            this.radioButtonMedicaid.Name = "radioButtonMedicaid";
            this.radioButtonMedicaid.Size = new System.Drawing.Size(68, 17);
            this.radioButtonMedicaid.TabIndex = 1;
            this.radioButtonMedicaid.Text = "Medicaid";
            this.radioButtonMedicaid.UseVisualStyleBackColor = true;
            // 
            // EligibilityPayers
            // 
            this.AcceptButton = this.buttonSelectPayer;
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.CancelButton = this.buttonCancel;
            this.ClientSize = new System.Drawing.Size(972, 335);
            this.Controls.Add(this.tableLayoutPanelBase);
            this.Name = "EligibilityPayers";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterParent;
            this.Text = "Eligibility Payers";
            this.FormClosing += new System.Windows.Forms.FormClosingEventHandler(this.EligibilityPayers_FormClosing);
            this.tableLayoutPanelBase.ResumeLayout(false);
            this.tableLayoutPanel1.ResumeLayout(false);
            this.tableLayoutPanelPayerTypes.ResumeLayout(false);
            this.tableLayoutPanelPayerTypes.PerformLayout();
            this.tableLayoutPanelLineOfBusiness.ResumeLayout(false);
            this.tableLayoutPanelLineOfBusiness.PerformLayout();
            this.ResumeLayout(false);

        }

        #endregion

        private CommonControls.ResultsControl resultsControlElig;
        private System.Windows.Forms.TableLayoutPanel tableLayoutPanelBase;
        private System.Windows.Forms.TableLayoutPanel tableLayoutPanel1;
        private System.Windows.Forms.Button buttonSelectPayer;
        private System.Windows.Forms.Button buttonCancel;
        private System.Windows.Forms.TableLayoutPanel tableLayoutPanelPayerTypes;
        private System.Windows.Forms.RadioButton radioButtonTest;
        private System.Windows.Forms.RadioButton radioButtonLive;
        private System.Windows.Forms.TableLayoutPanel tableLayoutPanelLineOfBusiness;
        private System.Windows.Forms.Label labelLob;
        private System.Windows.Forms.RadioButton radioButtonMedical;
        private System.Windows.Forms.RadioButton radioButtonDental;
        private System.Windows.Forms.RadioButton radioButtonMedicaid;
    }
}
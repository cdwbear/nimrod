namespace ApexWebServiceToolV2
{
    partial class CredentialsForm
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
            this.labelKey_15 = new System.Windows.Forms.Label();
            this.labelPassword_10 = new System.Windows.Forms.Label();
            this.textBoxKey = new System.Windows.Forms.TextBox();
            this.textBoxPwd = new System.Windows.Forms.TextBox();
            this.buttonSave = new System.Windows.Forms.Button();
            this.buttonCancel = new System.Windows.Forms.Button();
            this.tableLayoutPanelBase = new System.Windows.Forms.TableLayoutPanel();
            this.tableLayoutPanelButtons = new System.Windows.Forms.TableLayoutPanel();
            this.labelServiceCred = new System.Windows.Forms.Label();
            this.tableLayoutPanelServiceCred = new System.Windows.Forms.TableLayoutPanel();
            this.tableLayoutPanelBase.SuspendLayout();
            this.tableLayoutPanelButtons.SuspendLayout();
            this.tableLayoutPanelServiceCred.SuspendLayout();
            this.SuspendLayout();
            // 
            // labelKey_15
            // 
            this.labelKey_15.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Left | System.Windows.Forms.AnchorStyles.Right)));
            this.labelKey_15.AutoSize = true;
            this.labelKey_15.Location = new System.Drawing.Point(3, 7);
            this.labelKey_15.Name = "labelKey_15";
            this.labelKey_15.Size = new System.Drawing.Size(135, 13);
            this.labelKey_15.TabIndex = 0;
            this.labelKey_15.Text = "Service Key";
            this.labelKey_15.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            // 
            // labelPassword_10
            // 
            this.labelPassword_10.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Left | System.Windows.Forms.AnchorStyles.Right)));
            this.labelPassword_10.AutoSize = true;
            this.labelPassword_10.Location = new System.Drawing.Point(3, 34);
            this.labelPassword_10.Name = "labelPassword_10";
            this.labelPassword_10.Size = new System.Drawing.Size(135, 13);
            this.labelPassword_10.TabIndex = 0;
            this.labelPassword_10.Text = "Service Password";
            this.labelPassword_10.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            // 
            // textBoxKey
            // 
            this.textBoxKey.Dock = System.Windows.Forms.DockStyle.Fill;
            this.textBoxKey.Location = new System.Drawing.Point(144, 3);
            this.textBoxKey.Name = "textBoxKey";
            this.textBoxKey.Size = new System.Drawing.Size(332, 20);
            this.textBoxKey.TabIndex = 1;
            this.textBoxKey.TextChanged += new System.EventHandler(this.textBox_TextChanged);
            // 
            // textBoxPwd
            // 
            this.textBoxPwd.Dock = System.Windows.Forms.DockStyle.Fill;
            this.textBoxPwd.Location = new System.Drawing.Point(144, 30);
            this.textBoxPwd.Name = "textBoxPwd";
            this.textBoxPwd.Size = new System.Drawing.Size(332, 20);
            this.textBoxPwd.TabIndex = 1;
            this.textBoxPwd.TextChanged += new System.EventHandler(this.textBox_TextChanged);
            // 
            // buttonSave
            // 
            this.buttonSave.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.buttonSave.DialogResult = System.Windows.Forms.DialogResult.OK;
            this.buttonSave.Enabled = false;
            this.buttonSave.Location = new System.Drawing.Point(320, 6);
            this.buttonSave.Name = "buttonSave";
            this.buttonSave.Size = new System.Drawing.Size(75, 23);
            this.buttonSave.TabIndex = 2;
            this.buttonSave.Text = "&Save";
            this.buttonSave.UseVisualStyleBackColor = true;
            // 
            // buttonCancel
            // 
            this.buttonCancel.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.buttonCancel.DialogResult = System.Windows.Forms.DialogResult.Cancel;
            this.buttonCancel.Location = new System.Drawing.Point(401, 6);
            this.buttonCancel.Name = "buttonCancel";
            this.buttonCancel.Size = new System.Drawing.Size(75, 23);
            this.buttonCancel.TabIndex = 2;
            this.buttonCancel.Text = "&Cancel";
            this.buttonCancel.UseVisualStyleBackColor = true;
            // 
            // tableLayoutPanelBase
            // 
            this.tableLayoutPanelBase.ColumnCount = 1;
            this.tableLayoutPanelBase.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 100F));
            this.tableLayoutPanelBase.Controls.Add(this.tableLayoutPanelButtons, 0, 2);
            this.tableLayoutPanelBase.Controls.Add(this.labelServiceCred, 0, 0);
            this.tableLayoutPanelBase.Controls.Add(this.tableLayoutPanelServiceCred, 0, 1);
            this.tableLayoutPanelBase.Dock = System.Windows.Forms.DockStyle.Fill;
            this.tableLayoutPanelBase.Location = new System.Drawing.Point(0, 0);
            this.tableLayoutPanelBase.Name = "tableLayoutPanelBase";
            this.tableLayoutPanelBase.RowCount = 3;
            this.tableLayoutPanelBase.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 30F));
            this.tableLayoutPanelBase.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 61F));
            this.tableLayoutPanelBase.RowStyles.Add(new System.Windows.Forms.RowStyle());
            this.tableLayoutPanelBase.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 20F));
            this.tableLayoutPanelBase.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 20F));
            this.tableLayoutPanelBase.Size = new System.Drawing.Size(485, 126);
            this.tableLayoutPanelBase.TabIndex = 4;
            // 
            // tableLayoutPanelButtons
            // 
            this.tableLayoutPanelButtons.ColumnCount = 3;
            this.tableLayoutPanelButtons.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 100F));
            this.tableLayoutPanelButtons.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle());
            this.tableLayoutPanelButtons.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle());
            this.tableLayoutPanelButtons.Controls.Add(this.buttonSave, 1, 0);
            this.tableLayoutPanelButtons.Controls.Add(this.buttonCancel, 2, 0);
            this.tableLayoutPanelButtons.Dock = System.Windows.Forms.DockStyle.Fill;
            this.tableLayoutPanelButtons.Location = new System.Drawing.Point(3, 94);
            this.tableLayoutPanelButtons.Name = "tableLayoutPanelButtons";
            this.tableLayoutPanelButtons.RowCount = 1;
            this.tableLayoutPanelButtons.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 32F));
            this.tableLayoutPanelButtons.Size = new System.Drawing.Size(479, 32);
            this.tableLayoutPanelButtons.TabIndex = 6;
            // 
            // labelServiceCred
            // 
            this.labelServiceCred.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Left | System.Windows.Forms.AnchorStyles.Right)));
            this.labelServiceCred.AutoSize = true;
            this.labelServiceCred.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.labelServiceCred.Location = new System.Drawing.Point(3, 8);
            this.labelServiceCred.Name = "labelServiceCred";
            this.labelServiceCred.Size = new System.Drawing.Size(479, 13);
            this.labelServiceCred.TabIndex = 0;
            this.labelServiceCred.Text = "Service Credentials";
            this.labelServiceCred.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // tableLayoutPanelServiceCred
            // 
            this.tableLayoutPanelServiceCred.ColumnCount = 2;
            this.tableLayoutPanelServiceCred.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 29.60373F));
            this.tableLayoutPanelServiceCred.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 70.39627F));
            this.tableLayoutPanelServiceCred.Controls.Add(this.labelKey_15, 0, 0);
            this.tableLayoutPanelServiceCred.Controls.Add(this.labelPassword_10, 0, 1);
            this.tableLayoutPanelServiceCred.Controls.Add(this.textBoxPwd, 1, 1);
            this.tableLayoutPanelServiceCred.Controls.Add(this.textBoxKey, 1, 0);
            this.tableLayoutPanelServiceCred.Dock = System.Windows.Forms.DockStyle.Fill;
            this.tableLayoutPanelServiceCred.Location = new System.Drawing.Point(3, 33);
            this.tableLayoutPanelServiceCred.Name = "tableLayoutPanelServiceCred";
            this.tableLayoutPanelServiceCred.RowCount = 2;
            this.tableLayoutPanelServiceCred.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 50F));
            this.tableLayoutPanelServiceCred.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 50F));
            this.tableLayoutPanelServiceCred.Size = new System.Drawing.Size(479, 55);
            this.tableLayoutPanelServiceCred.TabIndex = 5;
            // 
            // CredentialsForm
            // 
            this.AcceptButton = this.buttonSave;
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.CancelButton = this.buttonCancel;
            this.ClientSize = new System.Drawing.Size(485, 126);
            this.Controls.Add(this.tableLayoutPanelBase);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedDialog;
            this.Name = "CredentialsForm";
            this.ShowInTaskbar = false;
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterParent;
            this.Text = "Web Service Credentials";
            this.tableLayoutPanelBase.ResumeLayout(false);
            this.tableLayoutPanelBase.PerformLayout();
            this.tableLayoutPanelButtons.ResumeLayout(false);
            this.tableLayoutPanelServiceCred.ResumeLayout(false);
            this.tableLayoutPanelServiceCred.PerformLayout();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Label labelKey_15;
        private System.Windows.Forms.Label labelPassword_10;
        private System.Windows.Forms.TextBox textBoxKey;
        private System.Windows.Forms.TextBox textBoxPwd;
        private System.Windows.Forms.Button buttonSave;
        private System.Windows.Forms.Button buttonCancel;
        private System.Windows.Forms.TableLayoutPanel tableLayoutPanelBase;
        private System.Windows.Forms.TableLayoutPanel tableLayoutPanelButtons;
        private System.Windows.Forms.Label labelServiceCred;
        private System.Windows.Forms.TableLayoutPanel tableLayoutPanelServiceCred;
    }
}
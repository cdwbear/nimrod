namespace ImportCacheUtility
{
    partial class Form1
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
            this.label1 = new System.Windows.Forms.Label();
            this.textBoxClientId = new System.Windows.Forms.TextBox();
            this.label2 = new System.Windows.Forms.Label();
            this.textBoxClientInfo = new System.Windows.Forms.TextBox();
            this.buttonFindClient = new System.Windows.Forms.Button();
            this.label3 = new System.Windows.Forms.Label();
            this.comboBoxDocumentTypes = new System.Windows.Forms.ComboBox();
            this.SuspendLayout();
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(59, 96);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(117, 13);
            this.label1.TabIndex = 0;
            this.label1.Text = "&Client ID to Search For:";
            // 
            // textBoxClientId
            // 
            this.textBoxClientId.Location = new System.Drawing.Point(195, 93);
            this.textBoxClientId.Name = "textBoxClientId";
            this.textBoxClientId.Size = new System.Drawing.Size(56, 20);
            this.textBoxClientId.TabIndex = 1;
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(72, 167);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(104, 13);
            this.label2.TabIndex = 2;
            this.label2.Text = "Cliant Info &Returned:";
            // 
            // textBoxClientInfo
            // 
            this.textBoxClientInfo.Location = new System.Drawing.Point(195, 164);
            this.textBoxClientInfo.Multiline = true;
            this.textBoxClientInfo.Name = "textBoxClientInfo";
            this.textBoxClientInfo.Size = new System.Drawing.Size(168, 110);
            this.textBoxClientInfo.TabIndex = 1;
            // 
            // buttonFindClient
            // 
            this.buttonFindClient.Location = new System.Drawing.Point(195, 64);
            this.buttonFindClient.Name = "buttonFindClient";
            this.buttonFindClient.Size = new System.Drawing.Size(168, 23);
            this.buttonFindClient.TabIndex = 3;
            this.buttonFindClient.Text = "Look for Client";
            this.buttonFindClient.UseVisualStyleBackColor = true;
            this.buttonFindClient.Click += new System.EventHandler(this.buttonFindClient_Click);
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(96, 127);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(86, 13);
            this.label3.TabIndex = 4;
            this.label3.Text = "&Document Type:";
            // 
            // comboBoxDocumentTypes
            // 
            this.comboBoxDocumentTypes.FormattingEnabled = true;
            this.comboBoxDocumentTypes.Location = new System.Drawing.Point(195, 124);
            this.comboBoxDocumentTypes.Name = "comboBoxDocumentTypes";
            this.comboBoxDocumentTypes.Size = new System.Drawing.Size(168, 21);
            this.comboBoxDocumentTypes.TabIndex = 5;
            // 
            // Form1
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(679, 344);
            this.Controls.Add(this.comboBoxDocumentTypes);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.buttonFindClient);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.textBoxClientInfo);
            this.Controls.Add(this.textBoxClientId);
            this.Controls.Add(this.label1);
            this.Name = "Form1";
            this.Text = "Form1";
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.TextBox textBoxClientId;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.TextBox textBoxClientInfo;
        private System.Windows.Forms.Button buttonFindClient;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.ComboBox comboBoxDocumentTypes;
    }
}


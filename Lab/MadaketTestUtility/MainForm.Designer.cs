namespace MadaketTestUtility
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
            this.comboBoxApiVersion = new System.Windows.Forms.ComboBox();
            this.label1 = new System.Windows.Forms.Label();
            this.textBoxSiteToSearch = new System.Windows.Forms.TextBox();
            this.labelSiteToSearch = new System.Windows.Forms.Label();
            this.SuspendLayout();
            // 
            // comboBoxApiVersion
            // 
            this.comboBoxApiVersion.FormattingEnabled = true;
            this.comboBoxApiVersion.Items.AddRange(new object[] {
            "1.2"});
            this.comboBoxApiVersion.Location = new System.Drawing.Point(118, 36);
            this.comboBoxApiVersion.Name = "comboBoxApiVersion";
            this.comboBoxApiVersion.Size = new System.Drawing.Size(191, 21);
            this.comboBoxApiVersion.TabIndex = 0;
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(12, 36);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(65, 13);
            this.label1.TabIndex = 1;
            this.label1.Text = "API Version:";
            // 
            // textBoxSiteToSearch
            // 
            this.textBoxSiteToSearch.Location = new System.Drawing.Point(118, 63);
            this.textBoxSiteToSearch.Name = "textBoxSiteToSearch";
            this.textBoxSiteToSearch.Size = new System.Drawing.Size(191, 20);
            this.textBoxSiteToSearch.TabIndex = 2;
            // 
            // labelSiteToSearch
            // 
            this.labelSiteToSearch.AutoSize = true;
            this.labelSiteToSearch.Location = new System.Drawing.Point(12, 63);
            this.labelSiteToSearch.Name = "labelSiteToSearch";
            this.labelSiteToSearch.Size = new System.Drawing.Size(96, 13);
            this.labelSiteToSearch.TabIndex = 1;
            this.labelSiteToSearch.Text = "Site To Search For";
            // 
            // MainForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(684, 504);
            this.Controls.Add(this.textBoxSiteToSearch);
            this.Controls.Add(this.labelSiteToSearch);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.comboBoxApiVersion);
            this.Name = "MainForm";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Madaket Test Utility";
            this.Load += new System.EventHandler(this.MainForm_Load);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.ComboBox comboBoxApiVersion;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.TextBox textBoxSiteToSearch;
        private System.Windows.Forms.Label labelSiteToSearch;
    }
}


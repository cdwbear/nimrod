using System.Windows.Forms;

namespace CommonControls
{
    partial class ResultsControl
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

        #region Component Designer generated code

        /// <summary> 
        /// Required method for Designer support - do not modify 
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            this.tableLayoutPanelBase = new System.Windows.Forms.TableLayoutPanel();
            this.tableLayoutPanelLabels = new System.Windows.Forms.TableLayoutPanel();
            this.labelResults = new System.Windows.Forms.Label();
            this.labelRecordsFound = new System.Windows.Forms.Label();
            this._dataGridViewResults = new System.Windows.Forms.DataGridView();
            this.treeViewResultsRemit = new System.Windows.Forms.TreeView();
            this.tableLayoutPanelBaseTreeView = new System.Windows.Forms.TableLayoutPanel();
            this.treeViewResultsCs = new System.Windows.Forms.TreeView();
            this.tableLayoutPanelLabelsTreeView = new System.Windows.Forms.TableLayoutPanel();
            this.labelResultsTreeView = new System.Windows.Forms.Label();
            this.labelRecordsFoundTreeCs = new System.Windows.Forms.Label();
            this.tableLayoutPanelLabelsTreeView2 = new System.Windows.Forms.TableLayoutPanel();
            this.label1 = new System.Windows.Forms.Label();
            this.labelRecordsFoundTreeRemit = new System.Windows.Forms.Label();
            this.tableLayoutPanelBaseRichTextView = new TableLayoutPanel();
            this.tableLayoutPanelLabelsRichTextView = new TableLayoutPanel();
            this.tableLayoutPanelLabelsRichTextView2 = new TableLayoutPanel();
            this.labelRecordsFoundRichTextCs = new Label();
            this.labelRecordsFoundRichTextRemit = new Label();
            this.labelResultsRichTextView = new Label();
            this.richTextBoxResultCs = new RichTextBox();
            this.richTextBoxResultRemit = new RichTextBox();
            this.tableLayoutPanelBase.SuspendLayout();
            this.tableLayoutPanelLabels.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this._dataGridViewResults)).BeginInit();
            this.tableLayoutPanelBaseTreeView.SuspendLayout();
            this.tableLayoutPanelLabelsTreeView.SuspendLayout();
            this.tableLayoutPanelLabelsTreeView2.SuspendLayout();
            this.SuspendLayout();
            // 
            // tableLayoutPanelBase
            // 
            this.tableLayoutPanelBase.ColumnCount = 1;
            this.tableLayoutPanelBase.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 100F));
            this.tableLayoutPanelBase.Controls.Add(this.tableLayoutPanelLabels, 0, 0);
            this.tableLayoutPanelBase.Controls.Add(this._dataGridViewResults, 0, 1);
            this.tableLayoutPanelBase.Dock = System.Windows.Forms.DockStyle.Fill;
            this.tableLayoutPanelBase.Location = new System.Drawing.Point(0, 0);
            this.tableLayoutPanelBase.Name = "tableLayoutPanelBase";
            this.tableLayoutPanelBase.RowCount = 2;
            this.tableLayoutPanelBase.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 20F));
            this.tableLayoutPanelBase.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 100F));
            this.tableLayoutPanelBase.Size = new System.Drawing.Size(695, 609);
            this.tableLayoutPanelBase.TabIndex = 0;
            // 
            // tableLayoutPanelLabels
            // 
            this.tableLayoutPanelLabels.ColumnCount = 2;
            this.tableLayoutPanelLabels.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 50F));
            this.tableLayoutPanelLabels.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 50F));
            this.tableLayoutPanelLabels.Controls.Add(this.labelResults, 0, 0);
            this.tableLayoutPanelLabels.Controls.Add(this.labelRecordsFound, 1, 0);
            this.tableLayoutPanelLabels.Dock = System.Windows.Forms.DockStyle.Fill;
            this.tableLayoutPanelLabels.Location = new System.Drawing.Point(0, 0);
            this.tableLayoutPanelLabels.Margin = new System.Windows.Forms.Padding(0);
            this.tableLayoutPanelLabels.Name = "tableLayoutPanelLabels";
            this.tableLayoutPanelLabels.RowCount = 1;
            this.tableLayoutPanelLabels.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 50F));
            this.tableLayoutPanelLabels.Size = new System.Drawing.Size(695, 20);
            this.tableLayoutPanelLabels.TabIndex = 0;
            // 
            // labelResults
            // 
            this.labelResults.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this.labelResults.AutoSize = true;
            this.labelResults.Location = new System.Drawing.Point(3, 3);
            this.labelResults.Name = "labelResults";
            this.labelResults.Padding = new System.Windows.Forms.Padding(2);
            this.labelResults.Size = new System.Drawing.Size(46, 17);
            this.labelResults.TabIndex = 0;
            this.labelResults.Text = "Results";
            // 
            // labelRecordsFound
            // 
            this.labelRecordsFound.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.labelRecordsFound.AutoSize = true;
            this.labelRecordsFound.Location = new System.Drawing.Point(593, 3);
            this.labelRecordsFound.Name = "labelRecordsFound";
            this.labelRecordsFound.Padding = new System.Windows.Forms.Padding(2);
            this.labelRecordsFound.Size = new System.Drawing.Size(99, 17);
            this.labelRecordsFound.TabIndex = 1;
            this.labelRecordsFound.Text = "0 Record(s) Found";
            // 
            // _dataGridViewResults
            // 
            this._dataGridViewResults.AllowUserToAddRows = false;
            this._dataGridViewResults.AllowUserToDeleteRows = false;
            this._dataGridViewResults.AllowUserToResizeColumns = false;
            this._dataGridViewResults.AllowUserToResizeRows = false;
            this._dataGridViewResults.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this._dataGridViewResults.Dock = System.Windows.Forms.DockStyle.Fill;
            this._dataGridViewResults.Location = new System.Drawing.Point(3, 23);
            this._dataGridViewResults.Name = "_dataGridViewResults";
            this._dataGridViewResults.ReadOnly = true;
            this._dataGridViewResults.RowHeadersVisible = false;
            this._dataGridViewResults.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect;
            this._dataGridViewResults.Size = new System.Drawing.Size(689, 583);
            this._dataGridViewResults.TabIndex = 1;
            this._dataGridViewResults.ColumnHeaderMouseClick += new System.Windows.Forms.DataGridViewCellMouseEventHandler(this.dataGridViewResults_ColumnHeaderMouseClick);
            // 
            // tableLayoutPanelBaseRichTextView
            // 
            this.tableLayoutPanelBaseRichTextView.ColumnCount = 2;
            this.tableLayoutPanelBaseRichTextView.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 50F));
            this.tableLayoutPanelBaseRichTextView.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 50F));
            this.tableLayoutPanelBaseRichTextView.Controls.Add(this.richTextBoxResultCs, 0, 1);
            this.tableLayoutPanelBaseRichTextView.Controls.Add(this.tableLayoutPanelLabelsTreeView, 0, 0);
            this.tableLayoutPanelBaseRichTextView.Controls.Add(this.richTextBoxResultRemit, 0, 1);
            this.tableLayoutPanelBaseRichTextView.Controls.Add(this.tableLayoutPanelLabelsTreeView2, 1, 0);
            this.tableLayoutPanelBaseRichTextView.Dock = System.Windows.Forms.DockStyle.Fill;
            this.tableLayoutPanelBaseRichTextView.Location = new System.Drawing.Point(0, 0);
            this.tableLayoutPanelBaseRichTextView.Name = "tableLayoutPanelBaseRichTextView";
            this.tableLayoutPanelBaseRichTextView.RowCount = 1;
            this.tableLayoutPanelBaseRichTextView.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 20F));
            this.tableLayoutPanelBaseRichTextView.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 100F));
            this.tableLayoutPanelBaseRichTextView.Size = new System.Drawing.Size(695, 609);
            this.tableLayoutPanelBaseRichTextView.TabIndex = 2;
            //
            // richTextBoxResultCs
            //
            this.richTextBoxResultCs.Dock = System.Windows.Forms.DockStyle.Fill;
            this.richTextBoxResultCs.Location = new System.Drawing.Point(3, 23);
            this.richTextBoxResultCs.Name = "richTextBoxResultCs";
            this.richTextBoxResultCs.Size = new System.Drawing.Size(341, 583);
            this.richTextBoxResultCs.TabIndex = 1;
            //
            // richTextBoxResultRemit
            //
            this.richTextBoxResultRemit.Dock = System.Windows.Forms.DockStyle.Fill;
            this.richTextBoxResultRemit.Location = new System.Drawing.Point(350, 23);
            this.richTextBoxResultRemit.Name = "richTextBoxResultRemit";
            this.richTextBoxResultRemit.Size = new System.Drawing.Size(342, 583);
            this.richTextBoxResultRemit.TabIndex = 1;
            // 
            // tableLayoutPanelLabelsRichTextView
            // 
            this.tableLayoutPanelLabelsRichTextView.ColumnCount = 2;
            this.tableLayoutPanelLabelsRichTextView.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 50F));
            this.tableLayoutPanelLabelsRichTextView.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 50F));
            this.tableLayoutPanelLabelsRichTextView.Controls.Add(this.labelResultsRichTextView, 0, 0);
            this.tableLayoutPanelLabelsRichTextView.Controls.Add(this.labelRecordsFoundRichTextCs, 1, 0);
            this.tableLayoutPanelLabelsRichTextView.Dock = System.Windows.Forms.DockStyle.Fill;
            this.tableLayoutPanelLabelsRichTextView.Location = new System.Drawing.Point(0, 0);
            this.tableLayoutPanelLabelsRichTextView.Margin = new System.Windows.Forms.Padding(0);
            this.tableLayoutPanelLabelsRichTextView.Name = "tableLayoutPanelLabelsRichTextView";
            this.tableLayoutPanelLabelsRichTextView.RowCount = 1;
            this.tableLayoutPanelLabelsRichTextView.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 50F));
            this.tableLayoutPanelLabelsRichTextView.Size = new System.Drawing.Size(347, 20);
            this.tableLayoutPanelLabelsRichTextView.TabIndex = 1;
            //
            // labelResultsRichTextView
            //
            this.labelResultsRichTextView.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this.labelResultsRichTextView.AutoSize = true;
            this.labelResultsRichTextView.Location = new System.Drawing.Point(3, 3);
            this.labelResultsRichTextView.Name = "labelResultsRichTextView";
            this.labelResultsRichTextView.Padding = new System.Windows.Forms.Padding(2);
            this.labelResultsRichTextView.Size = new System.Drawing.Size(46, 17);
            this.labelResultsRichTextView.TabIndex = 0;
            this.labelResultsRichTextView.Text = "Results";
            //
            // labelRecordsFoundRichTextCs
            //
            this.labelRecordsFoundRichTextCs.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.labelRecordsFoundRichTextCs.AutoSize = true;
            this.labelRecordsFoundRichTextCs.Location = new System.Drawing.Point(245, 3);
            this.labelRecordsFoundRichTextCs.Name = "labelRecordsFoundRichTextCs";
            this.labelRecordsFoundRichTextCs.Padding = new System.Windows.Forms.Padding(2);
            this.labelRecordsFoundRichTextCs.Size = new System.Drawing.Size(99, 17);
            this.labelRecordsFoundRichTextCs.TabIndex = 1;
            this.labelRecordsFoundRichTextCs.Text = "0 Record(s) Found";
            // 
            // tableLayoutPanelLabelsRichTextView2
            // 
            this.tableLayoutPanelLabelsRichTextView2.ColumnCount = 2;
            this.tableLayoutPanelLabelsRichTextView2.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 50F));
            this.tableLayoutPanelLabelsRichTextView2.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 50F));
            this.tableLayoutPanelLabelsRichTextView2.Controls.Add(this.labelResultsRichTextView, 0, 0);
            this.tableLayoutPanelLabelsRichTextView2.Controls.Add(this.labelRecordsFoundRichTextRemit, 1, 0);
            this.tableLayoutPanelLabelsRichTextView2.Dock = System.Windows.Forms.DockStyle.Fill;
            this.tableLayoutPanelLabelsRichTextView2.Location = new System.Drawing.Point(0, 0);
            this.tableLayoutPanelLabelsRichTextView2.Margin = new System.Windows.Forms.Padding(0);
            this.tableLayoutPanelLabelsRichTextView2.Name = "tableLayoutPanelLabelsRichTextView2";
            this.tableLayoutPanelLabelsRichTextView2.RowCount = 1;
            this.tableLayoutPanelLabelsRichTextView2.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 50F));
            this.tableLayoutPanelLabelsRichTextView2.Size = new System.Drawing.Size(347, 20);
            //
            // labelRecordsFoundRichTextRemit
            //
            this.labelRecordsFoundRichTextRemit.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.labelRecordsFoundRichTextRemit.AutoSize = true;
            this.labelRecordsFoundRichTextRemit.Location = new System.Drawing.Point(246, 3);
            this.labelRecordsFoundRichTextRemit.Name = "labelRecordsFoundRichTextRemit";
            this.labelRecordsFoundRichTextRemit.Padding = new System.Windows.Forms.Padding(2);
            this.labelRecordsFoundRichTextRemit.Size = new System.Drawing.Size(99, 17);
            this.labelRecordsFoundRichTextRemit.TabIndex = 2;
            this.labelRecordsFoundRichTextRemit.Text = "0 Record(s) Found";
            // 
            // treeViewResultsRemit
            // 
            this.treeViewResultsRemit.Dock = System.Windows.Forms.DockStyle.Fill;
            this.treeViewResultsRemit.Location = new System.Drawing.Point(350, 23);
            this.treeViewResultsRemit.Name = "treeViewResultsRemit";
            this.treeViewResultsRemit.Size = new System.Drawing.Size(342, 583);
            this.treeViewResultsRemit.TabIndex = 1;
            // 
            // tableLayoutPanelBaseTreeView
            // 
            this.tableLayoutPanelBaseTreeView.ColumnCount = 2;
            this.tableLayoutPanelBaseTreeView.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 50F));
            this.tableLayoutPanelBaseTreeView.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 50F));
            this.tableLayoutPanelBaseTreeView.Controls.Add(this.treeViewResultsCs, 0, 1);
            this.tableLayoutPanelBaseTreeView.Controls.Add(this.tableLayoutPanelLabelsTreeView, 0, 0);
            this.tableLayoutPanelBaseTreeView.Controls.Add(this.treeViewResultsRemit, 0, 1);
            this.tableLayoutPanelBaseTreeView.Controls.Add(this.tableLayoutPanelLabelsTreeView2, 1, 0);
            this.tableLayoutPanelBaseTreeView.Dock = System.Windows.Forms.DockStyle.Fill;
            this.tableLayoutPanelBaseTreeView.Location = new System.Drawing.Point(0, 0);
            this.tableLayoutPanelBaseTreeView.Name = "tableLayoutPanelBaseTreeView";
            this.tableLayoutPanelBaseTreeView.RowCount = 1;
            this.tableLayoutPanelBaseTreeView.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 20F));
            this.tableLayoutPanelBaseTreeView.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 100F));
            this.tableLayoutPanelBaseTreeView.Size = new System.Drawing.Size(695, 609);
            this.tableLayoutPanelBaseTreeView.TabIndex = 2;
            // 
            // treeViewResultsCs
            // 
            this.treeViewResultsCs.Dock = System.Windows.Forms.DockStyle.Fill;
            this.treeViewResultsCs.Location = new System.Drawing.Point(3, 23);
            this.treeViewResultsCs.Name = "treeViewResultsCs";
            this.treeViewResultsCs.Size = new System.Drawing.Size(341, 583);
            this.treeViewResultsCs.TabIndex = 2;
            // 
            // tableLayoutPanelLabelsTreeView
            // 
            this.tableLayoutPanelLabelsTreeView.ColumnCount = 2;
            this.tableLayoutPanelLabelsTreeView.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 50F));
            this.tableLayoutPanelLabelsTreeView.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 50F));
            this.tableLayoutPanelLabelsTreeView.Controls.Add(this.labelResultsTreeView, 0, 0);
            this.tableLayoutPanelLabelsTreeView.Controls.Add(this.labelRecordsFoundTreeCs, 1, 0);
            this.tableLayoutPanelLabelsTreeView.Dock = System.Windows.Forms.DockStyle.Fill;
            this.tableLayoutPanelLabelsTreeView.Location = new System.Drawing.Point(0, 0);
            this.tableLayoutPanelLabelsTreeView.Margin = new System.Windows.Forms.Padding(0);
            this.tableLayoutPanelLabelsTreeView.Name = "tableLayoutPanelLabelsTreeView";
            this.tableLayoutPanelLabelsTreeView.RowCount = 1;
            this.tableLayoutPanelLabelsTreeView.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 50F));
            this.tableLayoutPanelLabelsTreeView.Size = new System.Drawing.Size(347, 20);
            this.tableLayoutPanelLabelsTreeView.TabIndex = 1;
            // 
            // labelResultsTreeView
            // 
            this.labelResultsTreeView.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this.labelResultsTreeView.AutoSize = true;
            this.labelResultsTreeView.Location = new System.Drawing.Point(3, 3);
            this.labelResultsTreeView.Name = "labelResultsTreeView";
            this.labelResultsTreeView.Padding = new System.Windows.Forms.Padding(2);
            this.labelResultsTreeView.Size = new System.Drawing.Size(46, 17);
            this.labelResultsTreeView.TabIndex = 0;
            this.labelResultsTreeView.Text = "Results";
            // 
            // labelRecordsFoundTreeCs
            // 
            this.labelRecordsFoundTreeCs.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.labelRecordsFoundTreeCs.AutoSize = true;
            this.labelRecordsFoundTreeCs.Location = new System.Drawing.Point(245, 3);
            this.labelRecordsFoundTreeCs.Name = "labelRecordsFoundTreeCs";
            this.labelRecordsFoundTreeCs.Padding = new System.Windows.Forms.Padding(2);
            this.labelRecordsFoundTreeCs.Size = new System.Drawing.Size(99, 17);
            this.labelRecordsFoundTreeCs.TabIndex = 1;
            this.labelRecordsFoundTreeCs.Text = "0 Record(s) Found";
            // 
            // tableLayoutPanelLabelsTreeView2
            // 
            this.tableLayoutPanelLabelsTreeView2.ColumnCount = 2;
            this.tableLayoutPanelLabelsTreeView2.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 50F));
            this.tableLayoutPanelLabelsTreeView2.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 50F));
            this.tableLayoutPanelLabelsTreeView2.Controls.Add(this.labelRecordsFoundTreeRemit, 0, 0);
            this.tableLayoutPanelLabelsTreeView2.Controls.Add(this.label1, 0, 0);
            this.tableLayoutPanelLabelsTreeView2.Dock = System.Windows.Forms.DockStyle.Fill;
            this.tableLayoutPanelLabelsTreeView2.Location = new System.Drawing.Point(347, 0);
            this.tableLayoutPanelLabelsTreeView2.Margin = new System.Windows.Forms.Padding(0);
            this.tableLayoutPanelLabelsTreeView2.Name = "tableLayoutPanelLabelsTreeView2";
            this.tableLayoutPanelLabelsTreeView2.RowCount = 1;
            this.tableLayoutPanelLabelsTreeView2.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 50F));
            this.tableLayoutPanelLabelsTreeView2.Size = new System.Drawing.Size(348, 20);
            this.tableLayoutPanelLabelsTreeView2.TabIndex = 3;
            // 
            // label1
            // 
            this.label1.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(3, 3);
            this.label1.Name = "label1";
            this.label1.Padding = new System.Windows.Forms.Padding(2);
            this.label1.Size = new System.Drawing.Size(46, 17);
            this.label1.TabIndex = 1;
            this.label1.Text = "Results";
            // 
            // labelRecordsFoundTreeRemit
            // 
            this.labelRecordsFoundTreeRemit.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.labelRecordsFoundTreeRemit.AutoSize = true;
            this.labelRecordsFoundTreeRemit.Location = new System.Drawing.Point(246, 3);
            this.labelRecordsFoundTreeRemit.Name = "labelRecordsFoundTreeRemit";
            this.labelRecordsFoundTreeRemit.Padding = new System.Windows.Forms.Padding(2);
            this.labelRecordsFoundTreeRemit.Size = new System.Drawing.Size(99, 17);
            this.labelRecordsFoundTreeRemit.TabIndex = 2;
            this.labelRecordsFoundTreeRemit.Text = "0 Record(s) Found";
            // 
            // ResultsControl
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.Controls.Add(this.tableLayoutPanelBaseTreeView);
            this.Controls.Add(this.tableLayoutPanelBase);
            this.Controls.Add(this.tableLayoutPanelBaseRichTextView);
            this.Name = "ResultsControl";
            this.Size = new System.Drawing.Size(695, 609);
            this.tableLayoutPanelBase.ResumeLayout(false);
            this.tableLayoutPanelLabels.ResumeLayout(false);
            this.tableLayoutPanelLabels.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this._dataGridViewResults)).EndInit();
            this.tableLayoutPanelBaseTreeView.ResumeLayout(false);
            this.tableLayoutPanelLabelsTreeView.ResumeLayout(false);
            this.tableLayoutPanelLabelsTreeView.PerformLayout();
            this.tableLayoutPanelLabelsTreeView2.ResumeLayout(false);
            this.tableLayoutPanelLabelsTreeView2.PerformLayout();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.TableLayoutPanel tableLayoutPanelBase;
        private System.Windows.Forms.TableLayoutPanel tableLayoutPanelLabels;
        private System.Windows.Forms.Label labelResults;
        private System.Windows.Forms.DataGridView _dataGridViewResults;
        public System.Windows.Forms.Label labelRecordsFound;
		private System.Windows.Forms.TreeView treeViewResultsRemit;
        private System.Windows.Forms.TableLayoutPanel tableLayoutPanelBaseTreeView;
        private System.Windows.Forms.TableLayoutPanel tableLayoutPanelLabelsTreeView;
        private System.Windows.Forms.Label labelResultsTreeView;
        public System.Windows.Forms.Label labelRecordsFoundTreeCs;
        private System.Windows.Forms.TreeView treeViewResultsCs;
        private System.Windows.Forms.TableLayoutPanel tableLayoutPanelLabelsTreeView2;
        public System.Windows.Forms.Label labelRecordsFoundTreeRemit;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.TableLayoutPanel tableLayoutPanelBaseRichTextView;
        private System.Windows.Forms.TableLayoutPanel tableLayoutPanelLabelsRichTextView;
        private System.Windows.Forms.TableLayoutPanel tableLayoutPanelLabelsRichTextView2;
        private System.Windows.Forms.Label labelResultsRichTextView;
        private System.Windows.Forms.Label labelRecordsFoundRichTextCs;
        private System.Windows.Forms.Label labelRecordsFoundRichTextRemit;
        private System.Windows.Forms.RichTextBox richTextBoxResultCs;
        private System.Windows.Forms.RichTextBox richTextBoxResultRemit;
    }
}

using System.ComponentModel;
using System.Data;
using System.Windows.Forms;
using SortableBindingList;

namespace CommonControls
{
    public partial class ResultsControl : UserControl
    {
        private int lastSortedColumnIndex = -1;

        public ResultsControl()
        {
            InitializeComponent();
        }

        public TableLayoutPanel GridViewPanel
        {
            get { return tableLayoutPanelBase; }
        }

        public TableLayoutPanel TreeViewPanel
        {
            get { return tableLayoutPanelBaseTreeView; }
        }

        public DataGridView DataGridViewResults
        {
            get { return _dataGridViewResults; }
        }

	    public TreeView TreeViewResults
	    {
		    get { return treeViewResultsRemit; }
	    }

        public TreeView TreeViewResults2
        {
            get { return treeViewResultsCs; }
        }

        public string ResultsLabel
        {
            get { return labelResults.Text; }
            set { labelResults.Text = value; }
        }

        public RichTextBox RichTextBox1
        {
            get { return richTextBoxResultCs; }
            set { richTextBoxResultCs = value; }
        }

        public RichTextBox RichTextBox2
        {
            get { return richTextBoxResultRemit; }
            set { richTextBoxResultRemit = value; }
        }

        public TableLayoutPanel RichTextViewPanel
        {
            get { return tableLayoutPanelBaseRichTextView; }
        }

        private void dataGridViewResults_ColumnHeaderMouseClick(object sender, DataGridViewCellMouseEventArgs e)
        {
            var order = _dataGridViewResults.SortOrder;

            if (_dataGridViewResults.DataSource is BindingSource)
            {
                var columnName = _dataGridViewResults.Columns[e.ColumnIndex].Name;
                var directionString = order == SortOrder.Ascending ? "ASC" : "DESC";

                if (_dataGridViewResults.DataSource != null)
                {
                    ((BindingSource) _dataGridViewResults.DataSource).Sort = string.Format("{0} {1}", columnName,
                                                                                           directionString);
                }

            }
            else
            {
                var listSortOrder = (order == SortOrder.Ascending
                                            ? ListSortDirection.Descending :
                                            ListSortDirection.Ascending);

                _dataGridViewResults.Sort(_dataGridViewResults.Columns[e.ColumnIndex], listSortOrder);
            }
        }

        public void UpdateGridHeaders(string listName)
        {
            var recordCount = _dataGridViewResults.Rows.Count;
            labelRecordsFound.Text = string.Format("Payer Records found: {0}", recordCount);
        }

        public void UpdateTreeHeaders()
        {
            labelRecordsFoundTreeCs.Text = string.Format("Claim Statuses found: {0}",
                (treeViewResultsCs.Nodes.Count > 0 ? treeViewResultsCs.Nodes[0].GetNodeCount(false).ToString() : "0"));

            labelRecordsFoundTreeRemit.Text = string.Format("Remittances found: {0}",
                (treeViewResultsRemit.Nodes.Count > 0 ? treeViewResultsRemit.Nodes[0].GetNodeCount(false).ToString() : "0"));
        }

        public void UpdateResultsGrid(DataView dataView, string listName)
        {
            var bs = new BindingSource() {DataSource = dataView};
            _dataGridViewResults.DataSource = bs;
            _dataGridViewResults.AutoResizeColumns();
            
            var columnCount = _dataGridViewResults.Columns.Count;
            if (columnCount > 0)
            {
                _dataGridViewResults.Columns[columnCount - 1].AutoSizeMode = DataGridViewAutoSizeColumnMode.Fill;
            }
            _dataGridViewResults.Refresh();

            UpdateGridHeaders(listName);
        }

        public void UpdateResultsGrid(object[] objects, string listName, int defaultSortColumn = 0)
        {
            SortableBindingList<object> sbl = new SortableBindingList<object>();
            foreach (object o in objects)
            {
                sbl.Add(o);
            }
            _dataGridViewResults.DataSource = sbl;
            _dataGridViewResults.AutoResizeColumns();

            if (false == (defaultSortColumn >= 0 && 
                defaultSortColumn < _dataGridViewResults.Columns.Count))
            {
                defaultSortColumn = 0;
            }

            UpdateGridHeaders(listName);

            if (objects.Length == 0)
                return;

            _dataGridViewResults.Sort(_dataGridViewResults.Columns[defaultSortColumn], ListSortDirection.Ascending);

            foreach (DataGridViewColumn column in _dataGridViewResults.Columns)
            {
                column.SortMode = DataGridViewColumnSortMode.Programmatic;
                column.AutoSizeMode = DataGridViewAutoSizeColumnMode.AllCells;
            }

            var columnCount = _dataGridViewResults.Columns.Count;

            if (columnCount == 0)
                return;
            
            _dataGridViewResults.Columns[columnCount - 1].AutoSizeMode = DataGridViewAutoSizeColumnMode.Fill;
        }

        public void DisplayTreeView()
        {
        }

        public bool ExportToExcel2K7(string pathAndFileName)
        {
            //using (var xlPackage = new ExcelPackage(newFile))
            //{
            //    var worksheet = xlPackage.Workbook.Worksheets.Add("Tinned Goods");

            //    worksheet.Cell(1, 1).Value = "Product";
            //    worksheet.Cell(4, 1).Value = "Peas";
            //    var cell = worksheet.Cell(2, 2);
            //    cell.Value = "15";

            //    xlPackage.Save();
            //}

            return true;
        }

        public bool ExportToCsv(string pathAndFileName)
        {
            return true;
        }
    }
}

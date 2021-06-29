using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Data.Sql;
using System.Data.SqlClient;
using System.Drawing;
using System.Linq;
using System.Runtime.Remoting.Channels;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace SqlScriptRunner
{
    public partial class MainForm : Form
    {
        private string csConnString =
            "Data Source=EC2AMAZ-M4457JL;Initial Catalog=ClaimStaker;Persist Security Info=True; Integrated Security=SSPI; Connection Timeout=600";

        private string[] fileNames = null;

        public MainForm()
        {
            InitializeComponent();
        }

        private void buttonRunScripts_Click(object sender, EventArgs e)
        {
            //   <Parameter Name="ClaimStakerDataStore.Connection" Value="Data Source=EC2AMAZ-M4457JL;Initial Catalog=ClaimStaker;Persist Security Info=True; Integrated Security=SSPI; Connection Timeout=600" />
            SqlConnection con1 = new SqlConnection(csConnString);

            // FileInfo file = new FileInfo(Server.MapPath("filename");
            // string strscript = file.OpenText().ReadToEnd();
            // server.ConnectionContext.ExecuteNonQuery(strupdatescript);
            con1.Close();

            // listBox1.Items;
        }

        private void buttonSelectFiles_Click(object sender, EventArgs e)
        {
            openFileDialog1.Multiselect = true;
            openFileDialog1.CheckFileExists = true;
            if (DialogResult.OK == openFileDialog1.ShowDialog())
            {
                var fileNames = openFileDialog1.FileNames;
            }
        }
    }
}

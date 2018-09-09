using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Data.SqlClient;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Configuration;

namespace WindowsFormsApp1
{
    public partial class Form1 : Form
    {
        SqlConnection conn = null;
        string cs = ConfigurationManager.ConnectionStrings["bookConnect"].ConnectionString;
        SqlDataAdapter adapter = null;
        private DataSet dataSet;

        public Form1()
        {
            InitializeComponent();
            conn = new SqlConnection(cs);
            //conn.ConnectionString = csb.ConnectionString;
            //conn.ConnectionString = cs;
            adapter = new SqlDataAdapter("select * from book.authors; select * from book.books;", conn);
            SqlCommandBuilder sqlcb = new SqlCommandBuilder(adapter);
            dataSet = new DataSet();
            adapter.Fill(dataSet);
            dataGridView1.DataSource = dataSet.Tables[0];
        }

        private void button2_Click(object sender, EventArgs e)
        {
            adapter.Update(dataSet.Tables[0]);
        }
    }
}

using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Data.SqlClient;

namespace ttcnQLThuVien
{
    public partial class frmView_QTV : Form
    {
        private string constr = "Data Source=DOMIA\\SQLEXPRESS;Initial Catalog=ttcnQLThuVienDB;Integrated Security=True";
        private SqlConnection con;
        private SqlCommand com;
        private SqlDataReader drQTV;
        private DataTable dtQTV;

        public frmView_QTV()
        {
            InitializeComponent();
        }
        public void display()
        {
            string ssql = "select * from tblQuanTriVien";
            com = new SqlCommand(ssql, con);
            drQTV = com.ExecuteReader();
            dtQTV = new DataTable();
            dtQTV.Load(drQTV);
            dataGridView1.DataSource = dtQTV;
        }
        private void frmView_QTV_Load(object sender, EventArgs e)
        {
            con = new SqlConnection(constr);
            con.Open();
            display();
        }
    }
}

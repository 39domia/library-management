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
    public partial class frmView_Sach : Form
    {
        private string constr = "Data Source=DOMIA\\SQLEXPRESS;Initial Catalog=ttcnQLThuVienDB;Integrated Security=True";
        private SqlConnection con;
        private SqlCommand com;
        private DataTable dtQLSach;
        private SqlDataReader drQLSach;
        private Boolean mnew;

        public frmView_Sach()
        {
            InitializeComponent();
        }

        private void frmView_Sach_Load(object sender, EventArgs e)
        {
            con = new SqlConnection(constr);
            con.Open();
            string ssql = "SELECT * FROM tblQuanLySach";
            com = new SqlCommand(ssql, con);
            drQLSach = com.ExecuteReader();
            dtQLSach = new DataTable();
            dtQLSach.Load(drQLSach);
            dataGridView1.DataSource = dtQLSach;

        }
    }
}

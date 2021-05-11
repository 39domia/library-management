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
    public partial class frmView_Doc_Gia : Form
    {
        private string constr = "Data Source=DOMIA\\SQLEXPRESS;Initial Catalog=ttcnQLThuVienDB;Integrated Security=True";
        private SqlConnection con;
        private SqlCommand com;
        private SqlDataReader drDocGia;
        private DataTable dtDocGia;

        public frmView_Doc_Gia()
        {
            InitializeComponent();
        }

        private void frmView_Doc_Gia_Load(object sender, EventArgs e)
        {

            con = new SqlConnection(constr);
            con.Open();
            string ssql = "select * from tblDocGia";
            com = new SqlCommand(ssql, con);
            drDocGia = com.ExecuteReader();
            dtDocGia = new DataTable();
            dtDocGia.Load(drDocGia);
            dataGridViewQuanLyDocGia.DataSource = dtDocGia;
        }
    }
}

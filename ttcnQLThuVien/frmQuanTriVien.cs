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
    public partial class frmQuanTriVien : Form
    {
        private string constr = "Data Source=DOMIA\\SQLEXPRESS;Initial Catalog=ttcnQLThuVienDB;Integrated Security=True";
        private SqlConnection con;
        private SqlCommand com;
        private SqlDataReader drQTV;
        private DataTable dtQTV;
        private Boolean mnew;

        public void display()
        {
            string ssql = "select * from tblQuanTriVien";
            com = new SqlCommand(ssql, con);
            drQTV = com.ExecuteReader();
            dtQTV = new DataTable();
            dtQTV.Load(drQTV);
            dataGridView1.DataSource = dtQTV;
        }
        public frmQuanTriVien()
        {
            InitializeComponent();
        }
        public void setControl(Boolean sc)
        {

            txtHoTen.Enabled = sc;
            txtDiachi.Enabled = sc;
            txtSodienthoai.Enabled = sc;
            btnThem.Enabled = !sc;
            btnSua.Enabled = !sc;
            btnXoa.Enabled = !sc;
            btnLuu.Enabled = sc;
            btnHuy.Enabled = sc;
            dateTimePicker1.Enabled = sc;
        }
        public void clear()
        {

            txtHoTen.Text = "";
            txtDiachi.Text = "";
            txtSodienthoai.Text = "";
        }

        private void btnDong_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void frmQuanTriVien_Load(object sender, EventArgs e)
        {
            con = new SqlConnection(constr);
            con.Open();
            display();
            setControl(false);
        }

        private void btnThem_Click(object sender, EventArgs e)
        {
            setControl(true);
            clear();
            mnew = true;
        }

        private void btnSua_Click(object sender, EventArgs e)
        {
            setControl(true);
            mnew = false;
        }

        private void btnXoa_Click(object sender, EventArgs e)
        {
            string ssql = "delete from tblQuanTriVien where MaQT = " + dataGridView1.CurrentRow.Cells[0].Value.ToString();
            com = new SqlCommand(ssql, con);
            com.ExecuteNonQuery();
            display();
        }

        private void btnLuu_Click(object sender, EventArgs e)
        {
            if (mnew)
            {

                string ssql = "insert into tblQuanTriVien(HotenQT, NgaysinhQT, DiachiQT, SodienthoaiQT) values (N'" + txtHoTen.Text + "','" + dateTimePicker1.Text + "',N'" + txtDiachi.Text + "','" + txtSodienthoai.Text + "')";
                com = new SqlCommand(ssql, con);
                com.ExecuteNonQuery();
                display();
                clear();
                setControl(false);
            }
            else
            {

                string ssql = "update tblQuanTriVien set " +
                    "HotenQT = N'" + txtHoTen.Text + "', NgaysinhQT = '" + dateTimePicker1.Text + "', DiachiQT = N'" + txtDiachi.Text + "', SodienthoaiQT = '" + txtSodienthoai.Text + "' where MaQT = " + dataGridView1.CurrentRow.Cells[0].Value.ToString();
                com = new SqlCommand(ssql, con);
                com.ExecuteNonQuery();
                display();
                setControl(false);
                clear();
            }
            clear();
        }

        private void btnHuy_Click(object sender, EventArgs e)
        {
            setControl(false);
            clear();

        }

        private void dataGridView1_RowEnter(object sender, DataGridViewCellEventArgs e)
        {
            DataGridViewRow row = new DataGridViewRow();
            row = dataGridView1.Rows[e.RowIndex];            
            txtHoTen.Text = row.Cells[1].Value.ToString();  
            dateTimePicker1.Text = row.Cells[2].Value.ToString();
            txtDiachi.Text = row.Cells[3].Value.ToString();
            txtSodienthoai.Text = row.Cells[4].Value.ToString();
        }
    }
}

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
    public partial class frmQuanLySach : Form
    {
        private string constr = "Data Source=DOMIA\\SQLEXPRESS;Initial Catalog=ttcnQLThuVienDB;Integrated Security=True";
        private SqlConnection con;
        private SqlCommand com;
        private DataTable dtQLSach;
        private SqlDataReader drQLSach;
        private Boolean mnew;
        

        public frmQuanLySach()
        {
            InitializeComponent();
        }
        public void display()
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

        public void setControl(Boolean sc)
        {
            txtISBN.Enabled = sc;
            txtGiaSach.Enabled = sc;
            txtNamXB.Enabled = sc;
            txtNhaXB.Enabled = sc;
            txtSoluong.Enabled = sc;
            txtTacGia.Enabled = sc;
            txtTenSach.Enabled = sc;
            btnThem.Enabled = !sc;
            btnSua.Enabled = !sc;
            btnHuy.Enabled = sc;
            btnLuu.Enabled = sc;
            btnXoa.Enabled = !sc;
        }
        public void clear()
        {
            txtTenSach.Text = "";
            txtTacGia.Text = "";
            txtNhaXB.Text = "";
            txtNamXB.Text = "";
            txtISBN.Text = "";
            txtGiaSach.Text = "";
            txtSoluong.Text = "";
        }


        private void frmQuanLySach_Load(object sender, EventArgs e)
        {
            display();
            setControl(false);

        }

        private void btnDong_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void btnThem_Click(object sender, EventArgs e)
        {
            setControl(true);
            clear();
            mnew = true;

        }
        private void btnSua_Click(object sender, EventArgs e)
        {
            mnew = false;
            setControl(true);

        }

        private void btnLuu_Click(object sender, EventArgs e)
        {

            if (txtISBN.Text.Equals(""))
            {
                MessageBox.Show("Mã ISBN không được bỏ trống");
            }
            else
                if (mnew)
                {
                    string ssql = "INSERT INTO tblQuanLySach VALUES " +
                        "(" + txtISBN.Text + ",N'" + txtTenSach.Text + "',N'" + txtTacGia.Text + "', " + txtSoluong.Text + "," + txtNamXB.Text + ",N'" + txtNhaXB.Text + "'," + txtGiaSach.Text + ")";
                    com = new SqlCommand(ssql, con);
                    com.ExecuteNonQuery();
                    setControl(false);
                }
                else
                {
                    string ssql = "UPDATE tblQuanLySach SET TenSach = N'" + txtTenSach.Text + "', TacGia = N'" + txtTacGia.Text + "', SoLuong = " + txtSoluong.Text + ", NamXB = " + txtNamXB.Text + ", NhaXB = N'" + txtNhaXB.Text + "', GiaSach = " + txtGiaSach.Text + " WHERE ISBN = " + txtISBN.Text;
                    com = new SqlCommand(ssql, con);
                    com.ExecuteNonQuery();
                }
            display();
            clear();
        }

        private void btnHuy_Click(object sender, EventArgs e)
        {
            clear();
            setControl(false);
        }

        private void dataGridView1_RowEnter(object sender, DataGridViewCellEventArgs e)
        {
            DataGridViewRow row = new DataGridViewRow();
            row = dataGridView1.Rows[e.RowIndex];
            txtISBN.Text = row.Cells[0].Value.ToString();
            txtTenSach.Text = row.Cells[1].Value.ToString();
            txtTacGia.Text = row.Cells[2].Value.ToString();
            txtSoluong.Text = row.Cells[3].Value.ToString();
            txtNamXB.Text = row.Cells[4].Value.ToString();
            txtNhaXB.Text = row.Cells[5].Value.ToString();
            txtGiaSach.Text = row.Cells[6].Value.ToString();
        }

        private void btnXoa_Click(object sender, EventArgs e)
        {
            string ssql = "delete from tblQuanLySach where ISBN = '" + txtISBN.Text + "'";
            com = new SqlCommand(ssql, con);
            com.ExecuteNonQuery();
            display();
        }


    }
}

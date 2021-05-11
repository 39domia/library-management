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
    public partial class frmDocGia : Form
    {
        private string constr = "Data Source=DOMIA\\SQLEXPRESS;Initial Catalog=ttcnQLThuVienDB;Integrated Security=True";
        private SqlConnection con;
        private SqlCommand com;
        private SqlDataReader drDocGia;
        private DataTable dtDocGia;
        private Boolean mnew;

        public frmDocGia()
        {
            InitializeComponent();
        }
        public void display()
        {
            string ssql = "select * from tblDocGia";
            com = new SqlCommand(ssql, con);
            drDocGia = com.ExecuteReader();
            dtDocGia = new DataTable();
            dtDocGia.Load(drDocGia);
            dataGridViewQuanLyDocGia.DataSource = dtDocGia;
        }
        public void setControl(Boolean sc)
        {
            
            txtHoTen.Enabled = sc;
            txtDiaChi.Enabled = sc;
            txtSoDienThoai.Enabled = sc;
            btnThem.Enabled = !sc;
            btnSua.Enabled = !sc;
            btnXoa.Enabled = !sc;
            btnLuu.Enabled = sc;
            btnHuy.Enabled = sc;
            dtkNgaySinh.Enabled = sc;
        }
        public void clear()
        {
            
            txtHoTen.Text = "";
            txtDiaChi.Text = "";
            txtSoDienThoai.Text = "";
        }

        private void frmTheDocGia_Load(object sender, EventArgs e)
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

        private void btnHuy_Click(object sender, EventArgs e)
        {
            setControl(false);
            clear();

        }

        private void btnDong_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void dataGridViewQuanLyDocGia_RowEnter(object sender, DataGridViewCellEventArgs e)
        {
            DataGridViewRow row = new DataGridViewRow();
            row = dataGridViewQuanLyDocGia.Rows[e.RowIndex];
            txtHoTen.Text = row.Cells[1].Value.ToString();
            dtkNgaySinh.Text = row.Cells[2].Value.ToString();
            txtDiaChi.Text = row.Cells[3].Value.ToString();
            txtSoDienThoai.Text = row.Cells[4].Value.ToString();
        }

        private void btnLuu_Click(object sender, EventArgs e)
        {
            if (mnew)
            {

                string ssql = "insert into tblDocGia(HotenDG, NgaySinh, DiaChi, SoDienThoai) values (N'" + txtHoTen.Text + "','" + dtkNgaySinh.Text + "',N'" + txtDiaChi.Text + "','" + txtSoDienThoai.Text + "')";
                com = new SqlCommand(ssql, con);
                com.ExecuteNonQuery();
                display();
                clear();
                setControl(false);

            }
            else
            {

                string ssql = "update tblDocGia set " +
                    "HotenDG = N'" + txtHoTen.Text + "', ngaysinh = '" + dtkNgaySinh.Text + "', DiaChi = N'" + txtDiaChi.Text + "', SoDienThoai = '" + txtSoDienThoai.Text + "' where DocGiaID = " + dataGridViewQuanLyDocGia.CurrentRow.Cells[0].Value.ToString();
                com = new SqlCommand(ssql, con);
                com.ExecuteNonQuery();
                display();
                setControl(false);
                clear();
            }
            clear();
        }

        private void btnXoa_Click(object sender, EventArgs e)
        {
            string ssql = "delete from tblDocGia where DocGiaID = " + dataGridViewQuanLyDocGia.CurrentRow.Cells[0].Value.ToString();
            com = new SqlCommand(ssql, con);
            com.ExecuteNonQuery();
            display();
        }

    }
}

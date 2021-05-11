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
    public partial class frmQLMuonSach : Form
    {
        private string constr = "Data Source=DOMIA\\SQLEXPRESS;Initial Catalog=ttcnQLThuVienDB;Integrated Security=True";
        private SqlConnection con;
        private SqlCommand com;
        private SqlDataReader drTimKiem_va_Muon_Tra;
        private DataTable dtTimKiem_va_Muon_Tra;

        public frmQLMuonSach()
        {
            InitializeComponent();
        }
        public void display()
        {
            string ssql = "select MaMuon, tblQuanLySach.ISBN, TenSach, TacGia, HotenDG, HotenQT, NgayMuon, TinhTrang  from tblMuonSach " +
                "inner join tblQuanLySach on tblMuonSach.ISBN = tblQuanLySach.ISBN " +
                "inner join tblQuanTriVien on tblMuonSach.MaQT=tblQuanTriVien.MaQT " +
                "inner join tblDocGia on tblDocGia.DocGiaID=tblMuonSach.DocGiaID";
            com = new SqlCommand(ssql, con);
            drTimKiem_va_Muon_Tra = com.ExecuteReader();
            dtTimKiem_va_Muon_Tra = new DataTable();
            dtTimKiem_va_Muon_Tra.Load(drTimKiem_va_Muon_Tra);
            dataGridView_Muon.DataSource = dtTimKiem_va_Muon_Tra;
        }
        public void setControl(Boolean sc)
        {
            txtISBN.Enabled = sc;
            txtMaDG.Enabled = sc;
            txtMaQT.Enabled = sc;
            txtTinhTrang.Enabled = sc;
            dateTimePicker_Muon.Enabled = sc;
            btnThem.Enabled = !sc;
            btnSua.Enabled = !sc;
            btnLuu.Enabled = sc;
            btnHuy.Enabled = sc;
        }
        public void clear()
        {
            txtISBN.Text = "";
            txtMaDG.Text = "";
            txtMaQT.Text = "";
            txtTinhTrang.Text = "";
        }

        private void frmQLMuonSach_Load(object sender, EventArgs e)
        {
            con = new SqlConnection(constr);
            con.Open();
            display();
            setControl(false);

        }
        private void btnDong_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void btnTimkiem_Click(object sender, EventArgs e)
        {
            string ssql = "select * from tblQuanLySach where TenSach LIKE N'%" + txtTimkiem.Text + "%' ";
            com = new SqlCommand(ssql, con);
            drTimKiem_va_Muon_Tra = com.ExecuteReader();
            dtTimKiem_va_Muon_Tra = new DataTable();
            dtTimKiem_va_Muon_Tra.Load(drTimKiem_va_Muon_Tra);
            dataGridView_Timkiem.DataSource = dtTimKiem_va_Muon_Tra;
        }

        private void btnThem_Click(object sender, EventArgs e)
        {
            setControl(true);
            clear();
            
            btnLuu.Enabled = false;
        }

        private void btnSua_Click(object sender, EventArgs e)
        {
            setControl(true);
            txtISBN.Enabled = false;
            txtMaDG.Enabled = false;
            txtMaQT.Enabled = false;
        }

        private void btnXoa_Click(object sender, EventArgs e)
        {
            
        }

        private void btnLuu_Click(object sender, EventArgs e)
        {
           
            string ssql = "update tblMuonSach set ISBN= " + txtISBN.Text + ", MaQT = " + txtMaQT.Text + ", DocGiaID = " + txtMaDG.Text + ", NgayMuon = '" + dateTimePicker_Muon.Text + "', TinhTrang = N'" + txtTinhTrang.Text + "' where MaMuon = " + dataGridView_Muon.CurrentRow.Cells[0].Value.ToString();
            com = new SqlCommand(ssql, con);
            com.ExecuteNonQuery();
            display();
            setControl(false);
            clear();

        }

        private void btnHuy_Click(object sender, EventArgs e)
        {
            clear();
            setControl(false);
        }


        private void btnMuon_Click(object sender, EventArgs e)
        {
            string ssql = "insert into tblMuonSach(ISBN, MaQT, DocGiaID, NgayMuon, TinhTrang)" +
                               "values (" + txtISBN.Text + "," + txtMaQT.Text + "," + txtMaDG.Text + ", N'" + dateTimePicker_Muon.Text + "', N'" + txtTinhTrang.Text + "' )" +
            "update tblQuanLySach set SoLuong = SoLuong-1 where ISBN = " + txtISBN.Text;
            com = new SqlCommand(ssql, con);
            com.ExecuteNonQuery();
            display();
            setControl(false);

        }

        private void btnTra_Click(object sender, EventArgs e)
        {
            string ssql = "update tblQuanLySach set SoLuong = SoLuong+1 where ISBN = " + dataGridView_Muon.CurrentRow.Cells[1].Value.ToString() + "" +
                "delete from tblMuonSach where MaMuon = " + dataGridView_Muon.CurrentRow.Cells[0].Value.ToString()+"";
            com = new SqlCommand(ssql, con);
            com.ExecuteNonQuery();
            display();
        }

        private void btnView_Sach_Click(object sender, EventArgs e)
        {
            frmView_Sach myfrmView_Sach = new frmView_Sach();
            myfrmView_Sach.Show();
        }

        private void btnView_QTV_Click(object sender, EventArgs e)
        {
            frmView_QTV myfrmView_QTV = new frmView_QTV();
            myfrmView_QTV.Show();
        }

        private void btnView_DocGia_Click(object sender, EventArgs e)
        {
            frmView_Doc_Gia myfrmView_Doc_Gia = new frmView_Doc_Gia();
            myfrmView_Doc_Gia.Show();
        }
        private void dataGridView_Muon_RowEnter(object sender, DataGridViewCellEventArgs e)
        {
            DataGridViewRow row = new DataGridViewRow();
            row = dataGridView_Muon.Rows[e.RowIndex];
            txtTinhTrang.Text = row.Cells[7].Value.ToString();
            dateTimePicker_Muon.Text = row.Cells[6].Value.ToString();
        }

    }
}

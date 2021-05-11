using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace ttcnQLThuVien
{
    public partial class frmTrangChu : Form
    {
        public frmTrangChu()
        {
            InitializeComponent();
        }

       

        private void frmTrangChu_Load(object sender, EventArgs e)
        {

        }

        private void pictureBox1_Click_1(object sender, EventArgs e)
        {
            frmQuanTriVien frmQuanTriVien = new frmQuanTriVien();
            frmQuanTriVien.Show();
        }

        private void pictureBox3_Click(object sender, EventArgs e)
        {
            frmDocGia frmTheDocGia = new frmDocGia();
            frmTheDocGia.Show();
        }

        private void pictureBox2_Click(object sender, EventArgs e)
        {
            frmQuanLySach frmQuanLySach = new frmQuanLySach();
            frmQuanLySach.Show();
        }

        private void pictureBox4_Click(object sender, EventArgs e)
        {
            frmQLMuonSach frmQLMuonSach = new frmQLMuonSach();
            frmQLMuonSach.Show();
        }
    }
}

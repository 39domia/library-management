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
    public partial class frmDangNhap : Form
    {
       
        public frmDangNhap()
        {
            InitializeComponent();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            
            if ((txtTaiKhoan.Text.Equals("admin"))  && (txtMatKhau.Text.Equals("admin")))
            {
                frmTrangChu frmTC = new frmTrangChu();
                this.Hide();
                frmTC.ShowDialog();
                this.Close();
            }
            else
            {
                MessageBox.Show("Bạn đã nhập sai tên hoặc mật khẩu", "Thông báo");
            }
        }

        

        private void button2_Click(object sender, EventArgs e)
        {
            Close();
        }

        private void frmDangNhap_Load(object sender, EventArgs e)
        {

        }

       

        

        
    }
}

using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace lab7___ADO.NET
{
    public partial class FormDangKy : Form
    {
        QLHSDataContext db = new QLHSDataContext();
        public FormDangKy()
        {
            InitializeComponent();
        }

        private void btnCancel_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void comboBox1_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (cboRole.SelectedIndex != 0)
            {
                var existID = db.USERLOGINs.Select(x => x.MASV).ToList();
                var sinhviens = db.SINHVIENs.Where(a => !existID.Contains(a.MASV));
                foreach (var sv in sinhviens)
                {
                    cboMasv.Items.Add(sv.MASV);
                }    
                cboMasv.SelectedIndex= 0;

            }
            else
            {
                cboMasv.Items.Clear();
            }
        }

        private void btnTao_Click(object sender, EventArgs e)
        {
            if (txtMatKhau.Text.ToString() == txtXacNhan.Text.ToString())
            {
                var passWHash = FormLogin.toSHA256(txtMatKhau.Text.ToString());
                try
                {
                    USERLOGIN newUser = new USERLOGIN()
                    {
                        PASSWORD = passWHash,
                        USERNAME = txtTaiKhoan.Text.ToString(),
                        VAITRO = cboRole.SelectedItem.ToString()
                    };
                    newUser.MASV = newUser.VAITRO == "sinh viên" ?cboMasv.SelectedItem.ToString() : "";
                    db.USERLOGINs.InsertOnSubmit(newUser);
                    db.SubmitChanges();
                    MessageBox.Show("Tạo tài khoản thành công");
                    txtMatKhau.ResetText();
                    txtTaiKhoan.ResetText();
                    txtXacNhan.ResetText();
                    cboRole.SelectedIndex= 0;
                }
                catch 
                {
                    MessageBox.Show("Tên tài khoản đã tồn tại");
                }

            }
            else
            {
                MessageBox.Show("Vui lòng xác nhận lại mật khẩu");
            }
        }

        private void btnXoa_Click(object sender, EventArgs e)
        {
            txtTaiKhoan.ResetText();
            txtMatKhau.ResetText();
            txtXacNhan.ResetText();
        }

        private void FormDangKy_Load(object sender, EventArgs e)
        {
            cboRole.SelectedIndex = 0;
        }
    }
}

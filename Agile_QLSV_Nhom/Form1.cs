using System;
using System.CodeDom;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Security.Cryptography;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace lab7___ADO.NET
{


    public partial class Form1 : Form
    {
         
        public ThongTinDangNhap LoginInfo { get; set; }
        public Form1()
        {
            InitializeComponent();
        }
        bool KiemTraMoFormCon(int type)
        {
            switch (type)
            {
                case 1://login
                    foreach (var f in MdiChildren)
                    {
                        var tmp = f as FormLogin;
                        if (tmp != null) return false;
                    }
                    break;
                case 2:
                    foreach (var f in MdiChildren)
                    {
                        var tmp = f as FormNhapDiem;
                        if (tmp != null) return false;
                    }
                    break;
                case 3:
                    foreach (var f in MdiChildren)
                    {
                        var tmp = f as FormTTHS;
                        if (tmp != null) return false;
                    }
                    break;
                case 4:
                    foreach (var f in MdiChildren)
                    {
                        var tmp = f as FormMoLHP;
                        if (tmp != null) return false;
                    }
                    break;
                case 5:
                    foreach (var f in MdiChildren)
                    {
                        var tmp = f as FormDangKy;
                        if (tmp != null) return false;
                    }
                    break;
                case 6:
                    foreach (var f in MdiChildren)
                    {
                        var tmp = f as FormThongKe;
                        if (tmp != null) return false;
                    }
                    break;
                default: return true;

            }
            return true;
        }
        private void đăngNhậpToolStripMenuItem_Click(object sender, EventArgs e)
        {
            if (KiemTraMoFormCon(1) && LoginInfo ==null) {
                FormLogin f = new FormLogin(this);
                f.MdiParent = this;
                f.Show();
            }
            

        }
        public void EnableMenu(bool value =true)
        {
            TStripDanhmuc.Enabled = value;
            TStripQLHS.Enabled = value;
        }

        private void Form1_Load(object sender, EventArgs e)
        {
            EnableMenu(false);
            HienThiTenDangNhap();
        }

        public void HienThiTenDangNhap()
        {
            if (LoginInfo != null)
            {
                string masvstatus = LoginInfo.Masv != "" ? $" Mã sinh viên: {LoginInfo.Masv}" : "";
                statusLogin.Text = $" Chào bạn: {LoginInfo.Username}." +
                    $" Đăng nhập từ: {LoginInfo.ThoiDiemDangNhap.ToString("dd/MM/yyyy hh/mm/ss")}" + masvstatus;
                    
            }
            else
            {
                statusLogin.Text = "Chưa đăng nhập";
            }
        }

        private void đăngXuấtToolStripMenuItem_Click(object sender, EventArgs e)
        {
            LoginInfo = null;
            HienThiTenDangNhap();
            foreach (Form f in this.MdiChildren) 
            {
                f.Close();
            
            }
            EnableMenu(false);
        }

        private void lớpToolStripMenuItem_Click(object sender, EventArgs e)
        {
            if (KiemTraMoFormCon(4))
            {
                var f = new FormMoLHP();
                f.MdiParent = this;
                f.Show();
            }

        }

        private void hồSơHọcSinhToolStripMenuItem_Click(object sender, EventArgs e)
        {
            if(KiemTraMoFormCon(3))
            {
                var f = new FormTTHS();
                f.MdiParent = this;
                f.Show();
            }
        }

        private void nhậpĐiểmToolStripMenuItem_Click(object sender, EventArgs e)
        {
            if (KiemTraMoFormCon(2))
            {
                var f = new FormNhapDiem();
                f.MdiParent = this;
                f.Show();
            }
        }

        private void thoátToolStripMenuItem_Click(object sender, EventArgs e)
        {
            Application.Exit();
        }

        private void menuStrip1_ItemClicked(object sender, ToolStripItemClickedEventArgs e)
        {

        }

        private void tạoTàiKhoảnToolStripMenuItem_Click(object sender, EventArgs e)
        {

            if (KiemTraMoFormCon(5))
            {
                var f = new FormDangKy();
                f.MdiParent = this;
                f.Show();
            }
        }


        private void thốngKêToolStripMenuItem_Click_1(object sender, EventArgs e)
        {
            if (KiemTraMoFormCon(6))
            {
                var f = new FormThongKe();
                f.MdiParent = this;
                f.Show();
            }
        }
    }
}

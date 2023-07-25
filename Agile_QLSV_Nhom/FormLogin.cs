﻿using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Data.SqlClient;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Windows.Forms.VisualStyles;

namespace lab7___ADO.NET
{
    public partial class FormLogin : Form
    {
        Form1 mainForm ;
        Bitmap img1 = Properties.Resources.unhide;
        Bitmap img2 = Properties.Resources.hide;
        QLHSDataContext db = new QLHSDataContext();
        public FormLogin(Form1 form=null)
        {
            InitializeComponent();
            mainForm = form;
            btnHide.Image = img2;
        }
        
        private void button1_Click(object sender, EventArgs e)
        {
            if (txtPassWord.Text != null && txtUserName.Text != null)
            {
                var sv = db.USERLOGINs.Where(p => p.USERNAME == txtUserName.Text && p.PASSWORD == txtPassWord.Text);
                if (sv != null)
                {

                    foreach (var s in sv)
                    {
                        string masv = "";
                        if (s.USERNAME.ToString() != "admin") masv = s.MASV.ToString();

                        mainForm.LoginInfo = new ThongTinDangNhap
                        {
                            ID = int.Parse(s.ID.ToString()),
                            Username = s.USERNAME.ToString(),
                            VaiTro = s.VAITRO.ToString(),
                            Masv = masv,
                            ThoiDiemDangNhap = DateTime.Now
                        };
                        mainForm.HienThiTenDangNhap();
                        if (masv == "")
                        {
                            mainForm.EnableMenu();
                            this.Close();
                        }
                        else
                        {
                            var f = new FormContainer(masv);
                            f.MdiParent = mainForm;
                            f.Show();
                            this.Close();
                        }
                    }


                }
                else
                {
                    MessageBox.Show("Sai thông tin đăng nhập","Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Information);
                }
            }
            else
            {
                MessageBox.Show("Không được để trống thông tin đăng nhập", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
            
        }

        private void button2_Click(object sender, EventArgs e)
        {
            this.Close();
        }

       

        private void button3_Click(object sender, EventArgs e)
        {
           
            if (btnHide.Image ==img1)
            {
                btnHide.Image = img2;
                txtPassWord.UseSystemPasswordChar = true;

            }
            else
            {
                btnHide.Image = img1;
                txtPassWord.UseSystemPasswordChar = false;
                
            }
        }
    }
}

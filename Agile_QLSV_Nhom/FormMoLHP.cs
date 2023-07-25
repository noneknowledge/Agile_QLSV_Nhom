﻿using System;
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
    public partial class FormMoLHP : Form
    {
        public FormMoLHP()
        {
            InitializeComponent();
        }
        QLHSDataContext db = new QLHSDataContext();
        private void FormMoLHP_Load(object sender, EventArgs e)
        {
            var lop = db.LOPs;
            cboLop.DataSource = lop;
            cboLop.DisplayMember = "TENLOP";
            cboLop.ValueMember= "MALOP";
            cboLop.SelectedIndex = 0;
            fillDataGridView();
            fillDataGridView2();
        }
        private void fillDataGridView()
        {
            var lophp = db.LOPHPs.Select(b =>b.MAHP);           
            var hp = db.HOCPHANs;
            var MoLhP = hp.Where(a => !lophp.Contains(a.MAHP)).Select(a => new {a.MAHP,a.TENHP,a.SOTC,a.BATBUOC,a.GHICHU});
            dataGridView1.DataSource = MoLhP;
        }

        private void dataGridView1_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            int row = dataGridView1.CurrentRow.Index;
            if (row >= 0)
            {
                txtHocPhan.Text = dataGridView1["MAHP", row].Value.ToString();
                txtTenHP.Text = dataGridView1["TENHP", row].Value.ToString();
                txtTC.Text = dataGridView1["SOTC", row].Value.ToString();               
            }
        }
        private void fillDataGridView2()
        {

            var lophp = db.LOPHPs.Where(a => a.TGKT == null);
            var hp = db.HOCPHANs.Join(lophp, a => a.MAHP, b => b.MAHP, (a, b) => new { b.MALHP,a.MAHP, a.TENHP, a.SOTC, a.BATBUOC, a.GHICHU });
            dataGridView2.DataSource = hp;


        }

        private void btnMolop_Click(object sender, EventArgs e)
        {
            if (txtHocPhan.Text != null)
            {


                if (txtLophp.Text !="")
                    try
                    {
                        LOPHP lopmoi = new LOPHP()
                        {
                            MALHP = txtLophp.Text.ToString(),
                            MALOP = cboLop.SelectedValue.ToString(),
                            MAHP = txtHocPhan.Text.ToString(),
                            TGBD = DateTime.Now,
                            TGKT = null,
                            SSTOIDA = txtSS.Text.ToString() != "" ? int.Parse(txtSS.Text.ToString()) : 30,
                        };
                        db.LOPHPs.InsertOnSubmit(lopmoi);
                        db.SubmitChanges();
                        MessageBox.Show("Đã mở lớp.");
                        dataGridView1.DataSource = null;
                        fillDataGridView();
                        txtHocPhan.ResetText();
                        txtLophp.ResetText();
                        txtSS.ResetText();
                        txtTC.ResetText();
                        txtTenHP.ResetText();
                        fillDataGridView2();
                        
                    }
                    catch
                    {
                        MessageBox.Show("Sai mã lớp học phần hoặc mã lớp.");
                    }
                else MessageBox.Show("Không được để trống mã lớp học phần.");
            }

            else MessageBox.Show("Vui lòng chọn mã lớp học phần cần mở");
        }

        private void btnDong_Click(object sender, EventArgs e)
        {
            int row = dataGridView1.CurrentRow.Index;
            if (row >=0)
            {
                try
                {
                    var malophp = dataGridView2["MALHP", row].Value.ToString();
                    var lophp = db.LOPHPs.SingleOrDefault(a => a.MALHP == malophp);
                    if (lophp != null)
                    {
                        lophp.TGKT = DateTime.Now;
                    }
                    db.SubmitChanges();
                    fillDataGridView();
                    fillDataGridView2();
                }
                catch
                {
                    MessageBox.Show("Lỗi");
                }   
            }    

        }
    }
}

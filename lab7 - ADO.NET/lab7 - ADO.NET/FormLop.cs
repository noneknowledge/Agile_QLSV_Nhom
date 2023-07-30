using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace lab7___ADO.NET
{
    public partial class FormLop : Form
    {
        public FormLop()
        {
            InitializeComponent();
        }
        QLHSDataContext db = new QLHSDataContext();
        public void fillDataGridView()
        {
            dataGridView1.DataSource = null;
            if (cboMaKhoaFil.SelectedIndex ==0)
            {
                var data_lop = db.LOPs.Select(a => new { a.MALOP, a.TENLOP, a.CHUYENNGANH, a.MAKHOA, a.NIENKHOA });
                dataGridView1.DataSource = data_lop;
            }    
            else
            {
                var data_lop = db.LOPs.Select(a => new { a.MALOP, a.TENLOP, a.CHUYENNGANH, a.MAKHOA, a.NIENKHOA });
                data_lop = data_lop.Where(a => a.MAKHOA == cboMaKhoaFil.SelectedItem.ToString());
                dataGridView1.DataSource = data_lop;
            }    

        }

        public void fillCombobox()
        {
            cboMaKhoaFil.Items.Add("Tất cả");
            
            var malop = db.LOPs.Select(a => a.MAKHOA).Distinct().ToList();
            var chuyenNganh = db.LOPs.Select(a => a.CHUYENNGANH).Distinct().ToList();
            foreach (var item in malop)
            {
                cboMaKhoaFil.Items.Add(item);
                cboMaKhoa.Items.Add(item);
            }
            foreach (var item in chuyenNganh)
            {
                cboChuyenNganh.Items.Add(item);
            }
            cboMaKhoaFil.SelectedIndex= 0;
            cboMaKhoa.SelectedIndex= 0;
            cboChuyenNganh.SelectedIndex = 0;

        }
        private void FormLop_Load(object sender, EventArgs e)
        {
            fillCombobox();
            fillDataGridView();
        }

        private void btnReset_Click(object sender, EventArgs e)
        {
            cboMaKhoaFil.SelectedIndex = 0;
            fillDataGridView();
        }

        private void btnThem_Click(object sender, EventArgs e)
        {
            if (txtTenLop.Text.Length > 0 && txtKhoa.Text.Length >0)
            {
                var maxMALOP = db.LOPs.Select(a => a.MALOP);
                int max = 0;

                foreach (var item in maxMALOP)
                {
                    int buffer;
                    if (int.TryParse(item, out buffer))
                    {
                        if (max < buffer) max = buffer;
                    }
                }
                max += 1;
                string malop = max.ToString();
                try
                {
                    LOP lopmoi = new LOP();
                    lopmoi.MALOP= malop;
                    lopmoi.TENLOP = txtTenLop.Text;
                    lopmoi.CHUYENNGANH = cboChuyenNganh.SelectedItem.ToString();
                    lopmoi.MAKHOA = cboMaKhoa.SelectedItem.ToString();
                    lopmoi.SL_SV = 0;
                    lopmoi.NIENKHOA = txtKhoa.Text.ToString();
                    db.LOPs.InsertOnSubmit(lopmoi);
                    db.SubmitChanges(); 
                    fillDataGridView();

                }
                catch
                {
                    MessageBox.Show("Không thể thêm  lớp");
                }
            }
            else
            {
                MessageBox.Show("Chưa có thông tin để thêm lớp");
            }
        }

        private void btnXoa_Click(object sender, EventArgs e)
        {
            if (txtMaLop.Text.Length > 0)
            {
                try
                {
                    var lophoc = db.LOPs.SingleOrDefault(a => a.MALOP == txtMaLop.Text);
                    if (lophoc != null)
                    {

                        db.LOPs.DeleteOnSubmit(lophoc);

                        db.SubmitChanges();
                        fillDataGridView();
                    }

                }
                catch
                {
                    MessageBox.Show("Không thể cập nhật thông tin lớp");
                }
            }
            else
            {
                MessageBox.Show("Chưa có thông tin để sửa");
            }
        }

        private void btnSua_Click(object sender, EventArgs e)
        {
            if (txtMaLop.Text.Length > 0)
            {
                try
                {
                    var lophoc = db.LOPs.SingleOrDefault(a=>a.MALOP == txtMaLop.Text);
                    if (lophoc != null) 
                    { 
                        lophoc.TENLOP = txtTenLop.Text.ToString();
                        lophoc.CHUYENNGANH =cboChuyenNganh.SelectedItem.ToString();   
                        lophoc.MAKHOA =cboMaKhoa.SelectedItem.ToString();
                        lophoc.NIENKHOA = txtKhoa.Text.ToString();
                        db.SubmitChanges();
                        MessageBox.Show("Sửa thành công");
                        fillDataGridView();
                    }

                }
                catch
                {
                    MessageBox.Show("Không thể cập nhật thông tin lớp");
                }
            }
            else
            {
                MessageBox.Show("Chưa có thông tin để sửa");
            }
        }

        private void dataGridView1_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            int row = dataGridView1.CurrentRow.Index;
            if (row > 0)
            {
               
                txtMaLop.Text = dataGridView1["MALOP", row].Value.ToString();
                txtTenLop.Text = dataGridView1["TENLOP", row].Value.ToString();
                txtKhoa.Text = dataGridView1["NIENKHOA", row].Value.ToString();
                cboChuyenNganh.SelectedItem = dataGridView1["CHUYENNGANH", row].Value.ToString();
                cboMaKhoa.SelectedItem = dataGridView1["MAKHOA", row].Value.ToString();
                
            }
        }

        private void cboMaKhoaFil_SelectedIndexChanged(object sender, EventArgs e)
        {
            fillDataGridView();
        }
    }
}

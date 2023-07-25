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
    public partial class FormTTHS : Form
    {

        QLHSDataContext db = new QLHSDataContext();
        public FormTTHS()
        {
            InitializeComponent();
        }

        private void FormTTHS_Load(object sender, EventArgs e)
        {
            cboLop.DataSource = db.LOPs;
            cboLop.DisplayMember = "TenLop";
            cboLop.ValueMember = "MaLop";
            this.dataGridView1.DefaultCellStyle.Font = new Font("Times new romance", 10);
            fillDataGridView();
            cboPhai.SelectedIndex = 0;
        }
        int currentPage = 0;
        int takeSV = 7;
        private void fillDataGridView(int page = 0)
        {
            var dsSV = db.SINHVIENs.Where(x => x.MALOP.ToString() == 
            cboLop.SelectedValue.ToString()).Skip(page*takeSV).Take(takeSV);
            dataGridView1.DataSource = dsSV.Select(x => new { x.MASV, x.HOSV,x.TENSV ,  x.MALOP, x.PHAI, x.DIACHI,x.CONGNO, x.LHDT });
        }

        private void cboLop_SelectedIndexChanged(object sender, EventArgs e)
        {
            currentPage= 0;
            fillDataGridView();
        }

        private void btnThem_Click(object sender, EventArgs e)
        {
            int congNo = 0;
            try
            {
                congNo = int.Parse(txtCongNo.Text);
            }
            catch 
            {
                congNo = 0;
            }
            try
            {
                //Tao sv moi
                SINHVIEN sv = new SINHVIEN();
                sv.MASV = txtMaSv.Text;
                sv.HOSV = txtHosv.Text;
                sv.TENSV = txtTensv.Text;
                sv.DIACHI = txtDiaChi.Text;
                sv.PHAI = cboPhai.SelectedIndex==0?"Nam":"Nu";
                sv.MALOP = cboLop.SelectedValue.ToString();
                sv.CONGNO = congNo;
                //THem sv
                db.SINHVIENs.InsertOnSubmit(sv);

                //Cap nhat db
                db.SubmitChanges();

                fillDataGridView();
            }
            catch
            {
                MessageBox.Show("Mã sinh viên bị trùng hoặc do kiểu dữ liệu công nợ");
            }
            
        }

        private void btnXoa_Click(object sender, EventArgs e)
        {
            SINHVIEN sv = db.SINHVIENs.SingleOrDefault(p => p.MASV == txtMaSv.Text);
            if (sv !=null)
            {
                try
                {
                    //Xoa sv
                    db.SINHVIENs.DeleteOnSubmit(sv);

                    //cap nhat trong db
                    db.SubmitChanges();

                    fillDataGridView();
                }
                catch
                {
                    MessageBox.Show("Không thể xóa sinh viên vì có ảnh hưởng khóa ngoại");
                }
            }    
        }

        private void dataGridView1_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            int row = dataGridView1.CurrentRow.Index;
            if (row >=0)
            {
                txtMaSv.Text = dataGridView1["MASV", row].Value.ToString();             
                txtDiaChi.Text = dataGridView1["DIACHI", row].Value.ToString();
                cboPhai.SelectedIndex = dataGridView1["PHAI", row].Value.ToString()=="Nam"?0:1;
                txtTensv.Text = dataGridView1["TENSV", row].Value.ToString();
                txtHosv.Text = dataGridView1["HOSV", row].Value.ToString();
                txtCongNo.Text = dataGridView1["CONGNO", row].Value.ToString();
            }    
        }

        private void btnSua_Click(object sender, EventArgs e)
        {
            SINHVIEN sv = db.SINHVIENs.SingleOrDefault(p => p.MASV == txtMaSv.Text);
            if (sv != null)
            {
                try
                {
                    sv.MASV = txtMaSv.Text;
                    sv.HOSV = txtHosv.Text;
                    sv.TENSV = txtTensv.Text;
                    sv.DIACHI = txtDiaChi.Text;
                    sv.PHAI = cboPhai.SelectedIndex == 0 ? "Nam" : "Nu";
                    sv.MALOP = cboLop.SelectedValue.ToString();
                    sv.CONGNO = int.Parse(txtCongNo.Text);
                    //Cap nhat db
                    db.SubmitChanges();
                    fillDataGridView();
                }
                catch
                {
                    MessageBox.Show("Mã sinh viên bị trùng");
                }

            }    
        }

        private void btnTruoc_Click(object sender, EventArgs e)
        {
            if (currentPage != 0)
            {
                currentPage--;
                fillDataGridView(currentPage);
            }    
                
        }

        private void btnSau_Click(object sender, EventArgs e)
        {
            var CountdsSV = db.SINHVIENs.Where(x => x.MALOP.ToString() ==
            cboLop.SelectedValue.ToString()).Count();
            if (currentPage < CountdsSV/takeSV)
            {
                currentPage++;
                fillDataGridView(currentPage);
            }
        }

        
    }
}

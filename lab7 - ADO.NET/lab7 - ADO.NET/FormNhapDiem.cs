using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Security.AccessControl;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace lab7___ADO.NET
{
    public partial class FormNhapDiem : Form
    {
        QLHSDataContext db = new QLHSDataContext();
        public FormNhapDiem()
        {
            InitializeComponent();
        }

        private List<string> fillCombobox()
        {
            var nam = db.LOPHPs.Select(a=>a.NAM).Distinct().ToList();
            return nam;
        }

        private void FormNhapDiem_Load(object sender, EventArgs e)
        {
            var years = fillCombobox();
            cboHocKy.SelectedIndex = 0;
            hocky = cboHocKy.SelectedItem.ToString();

            
            foreach (var year in years)
            {
                cboNam.Items.Add(year);
            }
            cboNam.SelectedIndex= 0;
            nam = cboNam.SelectedItem.ToString();


            this.dataGridView1.DefaultCellStyle.Font = new Font("Times new romance", 10);
            fillDataGridView();
            cboTim.SelectedIndex= 0;
        }
        int currentPage = 0;
        int takeSV = 7;
        int countDS;
        int condition = -1;
        string variable = null;
        string nam;
        string hocky;

        private void fillDataGridView(int page = 0)
        {
           
            var dsSV = db.SINHVIENs.Select(x => new { x.MASV, hoten = x.HOSV + " " + x.TENSV });
            var dkhp = db.DKHPs;
            var mahp = db.HOCPHANs;
            var malophp = db.LOPHPs;
            var LOPHP_HP = mahp.Join(malophp, a => a.MAHP, b => b.MAHP, (a, b) => new { a.TENHP, b.MALHP, b.NAM,b.HOCKY });
            var tenhpDKHP = dkhp.Join(LOPHP_HP, a => a.MALHP, b => b.MALHP, (a, b) => new {a.MALHP, a.MASV, a.DIEMCK, a.DIEMTKY, a.DIEMGK, a.DIEMTBHE4, a.DIEMTBHE10, b.TENHP,b.NAM,b.HOCKY });
            var result = tenhpDKHP.Join(dsSV, a => a.MASV, b => b.MASV, (a, b) => new {a.MALHP, a.MASV,b.hoten, a.TENHP, a.DIEMCK, a.DIEMTKY, a.DIEMGK, a.DIEMTBHE4, a.DIEMTBHE10,a.NAM,a.HOCKY });
            countDS = result.Count();
            var displayItems = result;
            if (condition == 0)
            {
                displayItems = result.Where(p => p.MASV == variable).Skip(page * takeSV).Take(takeSV);
                if (nam != "Tất cả")
                {
                    displayItems = displayItems.Where(a => a.NAM.ToString() == nam);
                }    
                if (hocky != "Tất cả")
                {
                    displayItems = displayItems.Where(a => a.HOCKY.ToString() == hocky);
                }    
                 
            }
            else if (condition == 1)
            {
                displayItems = result.Where(p => p.MALHP == variable).Skip(page * takeSV).Take(takeSV);
                if (nam != "Tất cả")
                {
                    displayItems = displayItems.Where(a => a.NAM.ToString() == nam);
                }
                if (hocky != "Tất cả")
                {
                    displayItems = displayItems.Where(a => a.HOCKY.ToString() == hocky);
                }
            }
            else
            {
                if (nam != "Tất cả")
                {
                    displayItems = displayItems.Where(a => a.NAM.ToString() == nam);
                }
                if (hocky != "Tất cả")
                {
                    displayItems = displayItems.Where(a => a.HOCKY.ToString() == hocky);
                }
                
            }
            //dataGridView1.DataSource = result.Skip(page * takeSV).Take(takeSV);
            dataGridView1.DataSource = displayItems.Skip(page * takeSV).Take(takeSV);

        }
        

        private void button1_Click(object sender, EventArgs e)
        {
            if (currentPage != 0)
            {
                currentPage--;
                fillDataGridView(currentPage);
            }
        }

        private void button2_Click(object sender, EventArgs e)
        {
            
            if (currentPage < countDS / takeSV)
            {
                currentPage++;
                fillDataGridView(currentPage);
            }
        }

        private void dataGridView1_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            int row = dataGridView1.CurrentRow.Index;
            if (row >=0)
            {
                txtMasv.Text = dataGridView1["MASV", row].Value.ToString();
                txtMonHoc.Text = dataGridView1["TENHP", row].Value.ToString();
                txtMaLHP.Text = dataGridView1["MALHP", row].Value.ToString();

                txtHe10.Text = dataGridView1["DIEMTBHE10", row].Value.ToString();
                txtHe4.Text = dataGridView1["DIEMTBHE4", row].Value.ToString();
                txtTKY.Text = dataGridView1["DIEMTKY", row].Value.ToString();
                txtGKY.Text = dataGridView1["DIEMGK", row].Value.ToString();
                txtCKY.Text = dataGridView1["DIEMCK", row].Value.ToString();

                txtDanhGia.Text = int.Parse(txtHe10.Text) > 8 ? "Giỏi" : int.Parse(txtHe10.Text) > 7 ? "Khá" : int.Parse(txtHe10.Text) > 5 ? "Trung bình" :
                    int.Parse(txtHe10.Text) > 4 ? "Kém" : "Yếu";
                txtDauRot.Text = int.Parse(txtHe10.Text) > 4 ? "Đậu" : "Rớt";
            }    
        }

        private void btnReset_Click(object sender, EventArgs e)
        {

            condition = -1;
            currentPage = 0;
            
            cboNam.SelectedIndex= 0;
            nam = cboNam.SelectedItem.ToString();

            cboHocKy.SelectedIndex = 0;
            hocky = cboHocKy.SelectedItem.ToString();
            dataGridView1.DataSource= null;
            fillDataGridView();
        }

        private void btnSua_Click(object sender, EventArgs e)
        {
            if (txtMasv.Text == "")
            {
                MessageBox.Show("Vui lòng chọn sinh viên");
                return;
            }
            DKHP sua = db.DKHPs.SingleOrDefault(p => p.MASV == txtMasv.Text.ToString() && p.MALHP == txtMaLHP.Text.ToString());
            if (sua != null)
            {
                try
                {
                    var diemtky = int.Parse(txtTKY.Text.ToString());
                    var diemgky = int.Parse(txtGKY.Text.ToString());
                    var diemcky = int.Parse(txtCKY.Text.ToString());
                    var diemhe10 = diemtky*20/1000 + diemcky*50/1000 + diemgky *30/1000;
                    var diemhe4 = diemhe10 * 4 / 10;
                    sua.DIEMTKY = diemtky;
                    sua.DIEMGK = diemgky;
                    sua.DIEMCK = diemcky;
                    sua.DIEMTBHE10 = diemhe10;
                    sua.DIEMTBHE4 = diemhe4;

                    db.SubmitChanges();
                    fillDataGridView(currentPage);
                }
                catch
                {
                    MessageBox.Show("Lỗi kiểu dữ liệu");
                }
            }
            else MessageBox.Show($"Không tìm thấy sinh viên có mã sinh viên là {txtMasv.Text.ToString()}");

        }

        private void btnFind_Click(object sender, EventArgs e)
        {
            currentPage = 0;
            string keyword = txtTim.Text.ToString();
            if (keyword.Length > 0)
            {
                condition = cboTim.SelectedIndex;
                variable= txtTim.Text.ToString();
                fillDataGridView();
                    
            }
            else fillDataGridView();
        }

        private void cboNam_SelectedIndexChanged(object sender, EventArgs e)
        {
            currentPage = 0;
            nam = cboNam.SelectedItem.ToString();
            fillDataGridView();
            
        }

        private void cboHocKy_SelectedIndexChanged(object sender, EventArgs e)
        {
            currentPage = 0;
            hocky = cboHocKy.SelectedIndex.ToString();
            fillDataGridView();
        }
    }
}

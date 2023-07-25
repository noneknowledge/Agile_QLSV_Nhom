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
    public partial class FormDKHP : Form
    {
        string Masv = "20002";
        public FormDKHP(string masv = null)
        {
            InitializeComponent();
            Masv = masv == null ? "20002" :masv;
        }
        QLHSDataContext db = new QLHSDataContext();
        
        private void FormDKHP_Load(object sender, EventArgs e)
        {
            fillDataGridView();

        }
        private void fillDataGridView()
        {
            var malop = db.SINHVIENs.SingleOrDefault(a=>a.MASV == Masv);
            if (malop == null) 
            {
                lblThongBao.Visible = true;
                return;
            }
            var lop = db.LOPs.SingleOrDefault(a => a.MALOP == malop.MALOP);
            var mabomon = db.BOMONs.Where(a => a.MAKHOA == lop.MAKHOA).Select(a=>a.MABM);
            var hocphan = db.HOCPHANs.Where(a => mabomon.Contains(a.MABM)).Select(a=>a.MAHP).ToList();
            


            var dkhp = db.DKHPs.Where(a => a.MASV == Masv).Select(a => a.MALHP);
            var dkhp_sv = db.DKHPs.Where(a => a.MASV == Masv);
            var lophpdahoc = db.LOPHPs.Join(dkhp_sv, a => a.MALHP, b => b.MALHP, (a, b) => new { a.MAHP }).Select(a=>a.MAHP);
            var lophp = db.LOPHPs.Where(a => a.TGKT == null).Select(a => new { a.MALHP ,a.MALOP,a.MAHP,a.SSTOIDA});
            var MoLhP1 = lophp.Where(a => !dkhp.Contains(a.MALHP));
            var MoLhp = MoLhP1.Where(a => !lophpdahoc.Contains(a.MAHP) );
            var Molop = db.HOCPHANs.Join(MoLhp, b => b.MAHP, a => a.MAHP, (b, a) => new { a.MALOP, b.TENHP,b.SOTC, a.SSTOIDA, a.MALHP, a.MAHP });
            //var LopCoTheDK = Molop.Where(a => hocphan.Contains(a.MAHP));
            //dataGridView1.DataSource = LopCoTheDK;
            dataGridView1.DataSource = Molop;


        }

        private void btnMolop_Click(object sender, EventArgs e)
        {
            try
            {

                DKHP svMoi = new DKHP()
                {
                    MALHP = txtMalophp.Text,
                    MASV = Masv,
                    DIEMTKY = 0,
                    DIEMCK = 0,
                    DIEMGK = 0,
                    DIEMTBHE10 = 0,
                    DIEMTBHE4 = 0,
                    HOCPHI =  int.Parse(txtHocPhi.Text),
                    TTRANGHP = "chua thu",
                    GHICHU = null  
                };
                db.DKHPs.InsertOnSubmit(svMoi);
                db.SubmitChanges();
                LOPHP lophp = db.LOPHPs.SingleOrDefault(a => a.MALHP == txtMalophp.Text);
                if (lophp != null)
                {
                    int dadkHP = db.DKHPs.Where(a => a.MALHP == txtMalophp.Text).Count();
                    lophp.DADK = dadkHP;
                    db.SubmitChanges();
                    MessageBox.Show("Đã đăng ký +1");
                }
                if (lophp == null)
                {
                    MessageBox.Show("ko tim thay lop hoc phan");
                }
                dataGridView1.DataSource = null;
                fillDataGridView();
                txtMalophp.ResetText();
                txtMalop.ResetText();
                txtDaDK .ResetText();
                txtHocPhi.ResetText();
                txtTC.ResetText();
                txtTenHP.ResetText();

                

            }
            catch
            {
                MessageBox.Show("Vui lòng chọn học phần cần đăng ký hoặc lựa chọn một cột có hiển thị");
                
            }
        }

        private void dataGridView1_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            int row = dataGridView1.CurrentRow.Index;
            btnMolop.Enabled = true;
            if (row>=0)
            {  
                txtTC.Text = dataGridView1["SOTC", row].Value.ToString();
                txtMalophp.Text = dataGridView1["MALHP", row].Value.ToString();
                txtSSToiDa.Text = dataGridView1["SSTOIDA", row].Value.ToString();
                txtTenHP.Text = dataGridView1["TENHP", row].Value.ToString();
                var dadkHP = db.DKHPs.Where(a => a.MALHP == txtMalophp.Text).Count();
                txtDaDK.Text = dadkHP.ToString();
                txtMalop.Text = dataGridView1["MALOP", row].Value.ToString();
                txtHocPhi.Text = (int.Parse(txtTC.Text) * 1000000).ToString();
                if (dadkHP == int.Parse(txtSSToiDa.Text))
                {
                    btnMolop.Enabled = false;
                }
            }    
        }
    }
}

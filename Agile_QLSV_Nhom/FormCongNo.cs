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
    public partial class FormCongNo : Form
    {
        string masv;
        public FormCongNo(string MSSV = null)
        {
            InitializeComponent();
            masv = MSSV == null ? "20001" : MSSV;
            
        }
        
        QLHSDataContext db = new QLHSDataContext();

        private void FormCongNo_Load(object sender, EventArgs e)
        {
            var dkhp = db.DKHPs.Where(a => a.MASV == masv).Select(a => new {a.MALHP, a.HOCPHI, a.TTRANGHP });
            var lophp = db.LOPHPs;
            var hocphan = db.HOCPHANs;
            var TenHocPhan = lophp.Join(hocphan, a => a.MAHP, b => b.MAHP, (a, b) => new { a.MALHP, b.TENHP });
            var tenhpCuaHs = dkhp.Join(TenHocPhan, a => a.MALHP, b => b.MALHP, (a, b) => new { a.MALHP, b.TENHP, a.HOCPHI, a.TTRANGHP });
            dataGridView1.DataSource = tenhpCuaHs;
            int ?Tong = tenhpCuaHs.Sum(a => a.HOCPHI);
            int ?DaNop = tenhpCuaHs.Where(a =>a.TTRANGHP == "da thu").Sum(a => a.HOCPHI);
            int? no = Tong - DaNop;
            lblNo.Text = no.ToString() + " Đ";
            lblTong.Text = Tong.ToString() + " Đ";
            lblNop.Text = DaNop.ToString() + " Đ";



        }
    }
}

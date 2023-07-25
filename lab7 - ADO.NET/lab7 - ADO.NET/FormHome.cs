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
    public partial class FormHome : Form
    {
        string Masv;
        string nam;
        int hocky;

        public FormHome(string masv = null)
        {
            InitializeComponent();
            System.Drawing.Drawing2D.GraphicsPath gp = new System.Drawing.Drawing2D.GraphicsPath();
            gp.AddEllipse(0, 0, pictureBox1.Width - 3, pictureBox1.Height - 3);
            Region rg = new Region(gp);
            pictureBox1.Region = rg;
            Masv = masv;
        }

        private void loadDsDiem()
        {
            nam = cboNam.SelectedItem.ToString();
            hocky = cboHocKy.SelectedIndex + 1;

            QLHSDataContext db = new QLHSDataContext();
            var dkhp = db.DKHPs.Select(x => new { x.DIEMTBHE10, x.MALHP, x.MASV }).Where(sv => sv.MASV == Masv);
            var dsLophp = db.LOPHPs.Select(a => new { a.NAM, a.HOCKY, a.MAHP, a.MALHP });
            var dsdkhp = dkhp.Join(dsLophp, a => a.MALHP, b => b.MALHP, (a,b) => new {b.MAHP,b.NAM,b.HOCKY,a.DIEMTBHE10});
            var dsHocphan = db.HOCPHANs.Select(a => new { a.MAHP, a.TENHP });
            var dsCaNhan = dsdkhp.Join(dsHocphan, a=> a.MAHP, b=>b.MAHP ,(a,b) => new {b.TENHP,a.DIEMTBHE10, a.NAM, a.HOCKY});
            var dsDiemSpe = dsCaNhan.Where(a => a.NAM.ToString() == nam && a.HOCKY == hocky);
            chartDiem.Series["Diem"].Points.Clear();
            if( dsDiemSpe.Count() == 0)
            {
                lblThongbao.Visible = true;
            }
            else
            {
                lblThongbao.Visible = false;
            } 
                
            foreach (var mon in dsDiemSpe)
            {
                chartDiem.Series["Diem"].Points.AddXY(mon.TENHP, mon.DIEMTBHE10);
            }
            nam = cboNam.SelectedItem.ToString();
            hocky = cboHocKy.SelectedIndex + 1;
            
        }

        private void FormHome_Load(object sender, EventArgs e)
        {
            QLHSDataContext db = new QLHSDataContext();
            var ttHS = db.SINHVIENs.FirstOrDefault(s => s.MASV == Masv);
            string malop = "";
            int tongTC;
            string Makhoa = "";         
            if(ttHS != null)
            {
                lblTen.Text = ttHS.HOSV + " " + ttHS.TENSV;
                label1.Text = $"Xin chào {ttHS.HOSV} {ttHS.TENSV}";
                lblMasv.Text = ttHS.MASV;
                lblDiachi.Text = ttHS.DIACHI;
                DateTime date = ttHS.NAMSINH.Value.Date;
                lblNgaySinh.Text = date.ToString("dd/MM/yyyy");
                malop = ttHS.MALOP;
                var dsLop = db.LOPs.FirstOrDefault(x => x.MALOP == malop);
                lblMaLop.Text = ttHS.MALOP;
                if (dsLop != null)
                {
                    Makhoa = dsLop.MAKHOA;
                    lblChuyenNganh.Text = dsLop.CHUYENNGANH.ToString();
                }
                 
            }
            
            
            

           
            
            var dsLophp = db.LOPHPs.Select(p => new { p.MALHP, p.MAHP,p.MALOP,p.NAM,p.HOCKY });
            var dsHp = db.HOCPHANs.Select(p => new { p.MAHP,p.TENHP, p.SOTC,p.MABM});
            var dsDiem = db.DKHPs;
            var dsDiemHp = dsLophp.Join(dsHp, a => a.MAHP, b => b.MAHP, (a, b) => new { a.MAHP, b.TENHP, b.SOTC, a.MALHP,a.NAM,a.HOCKY })
                .Join(dsDiem, x => x.MALHP, y => y.MALHP, (x, y) => new { x.TENHP, y.DIEMTBHE10,y.MASV,x.SOTC ,x.MALHP,x.NAM,x.HOCKY});
            var dsDiemCaNhan = dsDiemHp.Where(sv => sv.MASV == Masv);
            var dsnam = dsDiemCaNhan.Select(sv => sv.NAM).Distinct();
            
            
            foreach (var nam in dsnam)
            {
                cboNam.Items.Add(nam);
            }
            cboNam.SelectedIndex = 0;
            cboHocKy.SelectedIndex = 0;
            nam = cboNam.SelectedItem.ToString();
            hocky = cboHocKy.SelectedIndex + 1;
            loadDsDiem();
            
            var tinChi = dsDiemCaNhan.Sum(x => x.SOTC);
            if (Makhoa == "10001")
            {
                tongTC = dsHp.Where(x => x.MABM == "10100").Sum(x=>x.SOTC.Value); 
            }
            else
            {
                tongTC = dsHp.Where(x => x.MABM != "10100").Sum(x => x.SOTC.Value);
            }
            int tcchuadat = (int)(tongTC - tinChi);
            //chartDiem.Series["Diem"].Points.AddXY("Lập trình",10);
            //chartDiem.Series["Diem"].Points.AddXY("Kinh doanh",8);
            //chartDiem.Series["Diem"].Points.AddXY("Kinh doanh thông minh",6);
            //chartDiem.Series["Diem"].Points.AddXY("Dịch vụ hành chính",3);

            TCChart.Series["TinChi"].Points.AddXY($"Tín chỉ đạt ({tinChi.ToString()})"  , tinChi);
            TCChart.Series["TinChi"].Points.AddXY($"Tín chỉ chưa đạt ({tcchuadat.ToString()})", tcchuadat);

            





        }

        private void cboNam_SelectedIndexChanged(object sender, EventArgs e)
        {
            loadDsDiem();
            
        }

        private void cboHocKy_SelectedIndexChanged(object sender, EventArgs e)
        {
            loadDsDiem();
        }

        
    }
}

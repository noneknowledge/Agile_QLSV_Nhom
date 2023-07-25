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
    public partial class FormDiemSv : Form
    {
        string masv;
        public FormDiemSv(string MAsv = null)
        {
            InitializeComponent();
            masv = MAsv != null ? MAsv : "20010";
        }
        
        bool select = false;
        bool selectHocKy = false;
        int countGet = 0;
        QLHSDataContext db = new QLHSDataContext();

        private IQueryable GetData(string nam = null, int hocky = 0)
        {
            if (countGet == 0) countGet++;

            var dkhp = db.DKHPs.Where(x => x.MASV == masv).Select(x => new { x.MASV, x.MALHP, x.DIEMTBHE4, x.DIEMTBHE10 ,x.DIEMCK,x.DIEMGK,x.DIEMTKY});
            if (dkhp.Count() > 0)
            {
                var malophp = db.LOPHPs.Select(x => new { x.MALHP, x.MAHP, x.NAM,x.HOCKY });
                var mahp = db.HOCPHANs.Select(x => new { x.MAHP, x.TENHP, x.SOTC });
                var result = dkhp.Join(malophp, x => x.MALHP, b => b.MALHP, (x, b) => new
                {
                    b.MAHP,
                    x.MASV,
                    x.MALHP,  
                    x.DIEMCK,
                    x.DIEMGK,
                    x.DIEMTKY,
                    x.DIEMTBHE4,
                    x.DIEMTBHE10,
                    b.NAM,
                    b.HOCKY
                });
                var final_result = result.Join(mahp, x => x.MAHP, y => y.MAHP, (x, y) => new
                {
                    x.MAHP,
                    y.TENHP,
                    y.SOTC,
                    x.HOCKY,
                    x.DIEMCK,
                    x.DIEMGK,
                    x.DIEMTKY,
                    x.DIEMTBHE4,
                    x.DIEMTBHE10,
                    x.NAM
                });
                if (nam != null)
                {
                    final_result = final_result.Where(x => x.NAM.ToString() == nam);
                    if (hocky == 0)
                        return final_result;
                    else
                        return final_result.Where(x => x.HOCKY == hocky);
                        
                        
                }
                else
                {
                    if (countGet == 1)
                    {
                        var diem10tb = final_result.Average(p => p.DIEMTBHE10);
                        txtDiem4.Text = final_result.Average(p => p.DIEMTBHE4).ToString();
                        txtDiem10.Text = diem10tb.ToString();
                        txtHocLuc.Text = diem10tb > 8 ? "Giỏi" : diem10tb > 7 ? "Khá" : diem10tb > 5 ? "Trung Bình" : "Yếu";
                    }
                    return final_result;
                }
            }
            else return null;
        }

        private IQueryable GetDataYear(string Typ = null, string data = null)
        {
            if (countGet == 0) countGet++;
            var dkhp = db.DKHPs.Where(x => x.MASV == masv).Select(x => new { x.MASV, x.MALHP, x.DIEMTBHE4, x.DIEMTBHE10 ,x.DIEMCK,x.DIEMGK,x.DIEMTKY});
            if (dkhp.Count() > 0)
            {
                var malophp = db.LOPHPs.Select(x => new { x.MALHP, x.MAHP, x.NAM });
                var mahp = db.HOCPHANs.Select(x => new { x.MAHP, x.TENHP, x.SOTC });
                var result = dkhp.Join(malophp, x => x.MALHP, b => b.MALHP, (x, b) => new
                {
                    b.MAHP,
                    x.MASV,
                    x.MALHP,  
                    x.DIEMCK,
                    x.DIEMGK,
                    x.DIEMTKY,
                    x.DIEMTBHE4,
                    x.DIEMTBHE10,
                    b.NAM
                });
                var final_result = result.Join(mahp, x => x.MAHP, y => y.MAHP, (x, y) => new
                {
                    x.MAHP,
                    y.TENHP,
                    y.SOTC,
                    x.DIEMCK,
                    x.DIEMGK,
                    x.DIEMTKY,
                    x.DIEMTBHE4,
                    x.DIEMTBHE10,
                    x.NAM
                });
                if (data != null && Typ != null)
                {
                    if (Typ == "Nam")
                        return final_result.Where(x => x.NAM.ToString() == "2021");
                    else
                        return final_result;
                }
                else
                {
                    if (countGet == 1)
                    {
                        var diem10tb = final_result.Average(p => p.DIEMTBHE10);
                        txtDiem4.Text = final_result.Average(p => p.DIEMTBHE4).ToString();
                        txtDiem10.Text = diem10tb.ToString();
                        txtHocLuc.Text = diem10tb > 8 ? "Giỏi" : diem10tb > 7 ? "Khá" : diem10tb > 5 ? "Trung Bình" : "Yếu";
                    }
                    return final_result.Select(x=>x.NAM).Distinct();
                }
            }
            else return null;
        }

        private void FormDiemSv_Load(object sender, EventArgs e)
        {
            cboHocKy.SelectedIndex = 0;
            this.dataGridView1.DefaultCellStyle.Font = new Font("Times new romance", 10);
            var final_result = GetData();
            if (final_result != null)
            {
                dataGridView1.DataSource = final_result;

                var years = GetDataYear();
                cboMon.DataSource = years;
                
            }
        }

        private void cboMon_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (select)
            {
                var data = cboMon.SelectedItem.ToString();
                var final_result = GetData(data);
                if (final_result != null)
                {
                    dataGridView1.DataSource = null;
                    dataGridView1.DataSource = final_result;
                }

                label6.Text = cboMon.SelectedItem.ToString();
            }
        }

        private void button1_Click(object sender, EventArgs e)
        {
            select = false;
            selectHocKy= false;
            var final_result = GetData();
            dataGridView1.DataSource = null;
            dataGridView1.DataSource = final_result;
        }

        private void cboMon_Click(object sender, EventArgs e)
        {
            select = true;
           
        }

        private void cboHocKy_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (selectHocKy)
            {
                int hocky = 0;
                if (cboHocKy.SelectedIndex != 0)
                {
                    hocky = cboHocKy.SelectedIndex;
                }

                var data = cboMon.SelectedItem.ToString();
                var final_result = GetData(data, hocky);
                if (final_result != null)
                {
                    dataGridView1.DataSource = null;
                    dataGridView1.DataSource = final_result;
                }

                label6.Text = cboMon.SelectedItem.ToString();
            }    
            
        }

        private void cboHocKy_Click(object sender, EventArgs e)
        {
            selectHocKy = true;
        }
    }
}

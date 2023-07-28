using System;
using System.Data;
using System.Linq;
using System.Windows.Forms;

namespace lab7___ADO.NET
{
    public partial class FormThongKe : Form
    {
        string Masv;
        QLHSDataContext db = new QLHSDataContext();
        bool flag = false;
        public FormThongKe(string masv = null)
        {
            InitializeComponent();
            Masv = masv;
        }



        private void AddDataChart_GT(ref bool flag, int index)
        {
            var SUM_SV = (from sv in db.SINHVIENs
                          select sv).Count();
            var GT_NAM = (from sv in db.SINHVIENs
                          where sv.PHAI == "Nam"
                          select sv).Count();
            var GT_NU = SUM_SV - GT_NAM;
            var GT = from sv in db.SINHVIENs
                     group sv by sv.PHAI into g
                     select new { Giới_Tính = g.Key, Số_Lượng = g.Count() };
            var GT_CN = from sv in db.SINHVIENs
                        group sv by sv.MALOP into g
                        select new
                        {
                            MALOP = g.Key,
                            NAM = g.Count(sv => sv.PHAI == "Nam"),
                            NU = g.Count(sv => sv.PHAI == "Nu")
                        };


            var LoaiHB = from hb in db.HOCBONGs
                         group hb by hb.LOAIHB into g
                         select new { LOAIHB = g.Key, SLHB = g.Count() };
            var SLSV_HB = from hb in db.HOCBONGs
                          select new { hb.MASV, hb.LOAIHB, hb.MOTAHB };
            var Sum_SV_HB = (from sv in db.SINHVIENs
                             join hb in db.HOCBONGs on sv.MASV equals hb.MASV
                             select sv).Count();

            var Sum_SV_0HB = SUM_SV - Sum_SV_HB;

            var SUM_CN_CT = (from dkhp in db.DKHPs where dkhp.TTRANGHP == "chua thu" select dkhp.HOCPHI).Sum();
            var SUM_CN_DT = (from dkhp in db.DKHPs where dkhp.TTRANGHP == "da thu" select dkhp.HOCPHI).Sum();
            var query = from dkhp in db.DKHPs where dkhp.TTRANGHP == "chua thu" group dkhp by dkhp.MASV into g select new { MASV = g.Key, SO_LUONG = g.Count() };

            var SUM_SV_CT = new { SO_LUONG_CHUATHU = query.Distinct().Count(), TONG_SO = query.Sum(x => x.SO_LUONG) };
            var SL_DT = SUM_SV - SUM_SV_CT.SO_LUONG_CHUATHU;
            var SV_CN = from dk in db.DKHPs
                        group dk by dk.MASV into g
                        select new
                        {
                            MASV = g.Key,
                            DATHU = g.Sum(dk => dk.TTRANGHP == "da thu" ? dk.HOCPHI : 0),
                            CHUATHU = g.Sum(dk => dk.TTRANGHP == "chua thu" ? dk.HOCPHI : 0)
                        };


            var DS_LCN = db.LOPs.Select(x => new { x.MALOP, x.TENLOP, x.CHUYENNGANH, x.SL_SV });

            var DS_LHP = from lp in db.LOPHPs
                         join hp in db.HOCPHANs on lp.MAHP equals hp.MAHP
                         where lp.TGKT != null
                         select new { lp.MALHP, lp.MALOP, lp.MAHP, hp.TENHP, lp.SSTOIDA, lp.DADK };
            switch (index)
            {
                case 0:
                    {
                        dataGridView1.DataSource = SLSV_HB;
                    }
                    break;
                case 1:
                    {
                        dataGridView1.DataSource = GT_CN;
                    }
                    break;
                case 2:
                    {
                        dataGridView1.DataSource = SV_CN;
                    }
                    break;
                case 3:
                    {
                        dataGridView1.DataSource = DS_LCN;
                    }
                    break;
                case 4:
                    {
                        dataGridView1.DataSource = DS_LHP;
                    }
                    break;
            }
            if (flag == false)
            {
                foreach (var hb in LoaiHB)
                {
                    chart6.Series["HB"].Points.AddXY(hb.LOAIHB, hb.SLHB);
                }

                foreach (var CN in DS_LCN)
                {
                    chart4.Series["SLCN"].Points.AddXY(CN.MALOP, CN.SL_SV);
                }

                foreach (var HP in DS_LHP)
                {
                    chart5.Series["Tên HP"].Points.AddXY(HP.MALHP, HP.DADK);
                }
                foreach (var GTCN in GT_CN)
                {
                    chart7.Series["Nam"].Points.AddXY(GTCN.MALOP, GTCN.NAM);

                }
                foreach (var GTCN in GT_CN)
                {
                    chart7.Series["Nu"].Points.AddXY(GTCN.MALOP, GTCN.NU);

                }
                chart3.Series["CN"].Points.AddXY($"Tổng sinh viên còn nợ({SUM_SV_CT.SO_LUONG_CHUATHU.ToString()})", SUM_SV_CT.SO_LUONG_CHUATHU);
                chart3.Series["CN"].Points.AddXY($"Tổng sinh viên đã đóng({SL_DT.ToString()})", SL_DT);

                chart8.Series["SUMCN"].Points.AddXY($"Tổng công nợ chưa thu({SUM_CN_CT.ToString()})", SUM_CN_CT);
                chart8.Series["SUMCN"].Points.AddXY($"Tổng công nợ đã thu({SUM_CN_DT.ToString()})", SUM_CN_DT);


                chart2.Series["GT"].Points.AddXY($"Nam ({GT_NAM.ToString()})", GT_NAM);
                chart2.Series["GT"].Points.AddXY($"Nữ({GT_NU.ToString()})", GT_NU);


                chart1.Series["HB"].Points.AddXY($"Có học bổng ({Sum_SV_HB.ToString()})", Sum_SV_HB);
                chart1.Series["HB"].Points.AddXY($"Không có học bổng({Sum_SV_0HB.ToString()})", Sum_SV_0HB);



                flag = true;
            }


        }
        //Hoàn thành kiểm thử chức năng thống kê: không có lỗi
        private void FormThongKe_Load(object sender, EventArgs e)
        {

        }
        private void comboBox1_SelectedIndexChanged(object sender, EventArgs e)
        {
            var index = comboBox1.SelectedIndex;
            chart1.Visible = false;
            chart2.Visible = false;
            chart3.Visible = false;
            chart4.Visible = false;
            chart5.Visible = false;
            chart6.Visible = false;
            chart7.Visible = false;
            chart8.Visible = false;



            switch (index)
            {
                case 0:
                    {
                        chart1.Visible = true;
                        chart6.Visible = true;
                        AddDataChart_GT(ref flag, index);

                    }
                    break;
                case 1:
                    {
                        chart2.Visible = true;
                        chart7.Visible = true;
                        AddDataChart_GT(ref flag, index);


                    }
                    break;
                case 2:
                    {
                        chart3.Visible = true;
                        chart8.Visible = true;
                        AddDataChart_GT(ref flag, index);
                    }
                    break;
                case 3:
                    {
                        chart4.Visible = true;
                        AddDataChart_GT(ref flag, index);
                    }
                    break;
                case 4:
                    {
                        chart5.Visible = true;
                        AddDataChart_GT(ref flag, index);
                    }
                    break;
                case 5:
                    {
                        chart6.Visible = true;
                        AddDataChart_GT(ref flag, index);
                    }
                    break;

            }

        }
    }
}
//Hoàn thành code cho form thống kê
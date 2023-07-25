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
    public partial class FormContainer : Form
    {
        string Masv;
        public FormContainer(string masv=null)
        {
            InitializeComponent();
            Masv = masv==null?"20001":masv;
        }

        private void btnHome_Click(object sender, EventArgs e)
        {
            RemoveControl();
            var f = new FormHome(Masv);
            f.TopLevel = false;
            pnlContent.Controls.Add(f);
            f.Show();
        }

        void RemoveControl()
        {
            if (this.pnlContent.Controls.Count > 0)
            {
                pnlContent.Controls.RemoveAt(0);
            }
        }
        private void btnDiem_Click(object sender, EventArgs e)
        {
            RemoveControl();   
            var f = new FormDiemSv(Masv);
            f.TopLevel = false;
            pnlContent.Controls.Add(f);
            f.Show();
        }

        private void btnGhiChu_Click(object sender, EventArgs e)
        {
            RemoveControl();
            var f = new FormDKHP(Masv);
            f.TopLevel = false;
            pnlContent.Controls.Add(f);
            f.Show();
        }

        private void btnCongNo_Click(object sender, EventArgs e)
        {
            RemoveControl();
            var f = new FormCongNo(Masv);
            f.TopLevel = false;
            pnlContent.Controls.Add(f);
            f.Show();
        }
    }
}

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
            cboMaKhoa.Items.Add("Tất cả");

            var malop = db.LOPs.Select(a=> a.MAKHOA).Distinct().ToList();
            foreach (var item in malop)
            {
                cboMaKhoa.Items.Add(item);
            }

        }
        

        private void FormLop_Load(object sender, EventArgs e)
        {
            fillDataGridView();
        }
    }
}

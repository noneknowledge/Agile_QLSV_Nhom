namespace lab7___ADO.NET
{
    partial class FormContainer
    {
        /// <summary>
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code

        /// <summary>
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            this.panel1 = new System.Windows.Forms.Panel();
            this.btnGhiChu = new System.Windows.Forms.Button();
            this.btnDiem = new System.Windows.Forms.Button();
            this.btnHome = new System.Windows.Forms.Button();
            this.panel2 = new System.Windows.Forms.Panel();
            this.pnlContent = new System.Windows.Forms.FlowLayoutPanel();
            this.btnCongNo = new System.Windows.Forms.Button();
            this.panel1.SuspendLayout();
            this.SuspendLayout();
            // 
            // panel1
            // 
            this.panel1.BackColor = System.Drawing.Color.SteelBlue;
            this.panel1.Controls.Add(this.btnCongNo);
            this.panel1.Controls.Add(this.btnGhiChu);
            this.panel1.Controls.Add(this.btnDiem);
            this.panel1.Controls.Add(this.btnHome);
            this.panel1.Dock = System.Windows.Forms.DockStyle.Left;
            this.panel1.Location = new System.Drawing.Point(0, 0);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(125, 526);
            this.panel1.TabIndex = 0;
            // 
            // btnGhiChu
            // 
            this.btnGhiChu.BackColor = System.Drawing.Color.CadetBlue;
            this.btnGhiChu.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnGhiChu.ForeColor = System.Drawing.SystemColors.ControlText;
            this.btnGhiChu.Image = global::lab7___ADO.NET.Properties.Resources.note;
            this.btnGhiChu.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.btnGhiChu.Location = new System.Drawing.Point(10, 320);
            this.btnGhiChu.Name = "btnGhiChu";
            this.btnGhiChu.Size = new System.Drawing.Size(109, 52);
            this.btnGhiChu.TabIndex = 2;
            this.btnGhiChu.Text = "DKHP";
            this.btnGhiChu.UseVisualStyleBackColor = false;
            this.btnGhiChu.Click += new System.EventHandler(this.btnGhiChu_Click);
            // 
            // btnDiem
            // 
            this.btnDiem.BackColor = System.Drawing.Color.CadetBlue;
            this.btnDiem.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnDiem.ForeColor = System.Drawing.SystemColors.ControlText;
            this.btnDiem.Image = global::lab7___ADO.NET.Properties.Resources.open_book;
            this.btnDiem.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.btnDiem.Location = new System.Drawing.Point(10, 220);
            this.btnDiem.Name = "btnDiem";
            this.btnDiem.Size = new System.Drawing.Size(109, 52);
            this.btnDiem.TabIndex = 1;
            this.btnDiem.Text = "Điểm";
            this.btnDiem.UseVisualStyleBackColor = false;
            this.btnDiem.Click += new System.EventHandler(this.btnDiem_Click);
            // 
            // btnHome
            // 
            this.btnHome.BackColor = System.Drawing.Color.CadetBlue;
            this.btnHome.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnHome.ForeColor = System.Drawing.SystemColors.ControlText;
            this.btnHome.Image = global::lab7___ADO.NET.Properties.Resources.home_page;
            this.btnHome.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.btnHome.Location = new System.Drawing.Point(10, 120);
            this.btnHome.Name = "btnHome";
            this.btnHome.Size = new System.Drawing.Size(109, 52);
            this.btnHome.TabIndex = 0;
            this.btnHome.Text = "Trang chủ";
            this.btnHome.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            this.btnHome.UseVisualStyleBackColor = false;
            this.btnHome.Click += new System.EventHandler(this.btnHome_Click);
            // 
            // panel2
            // 
            this.panel2.BackColor = System.Drawing.Color.LightGreen;
            this.panel2.Dock = System.Windows.Forms.DockStyle.Top;
            this.panel2.Location = new System.Drawing.Point(125, 0);
            this.panel2.Name = "panel2";
            this.panel2.Size = new System.Drawing.Size(703, 29);
            this.panel2.TabIndex = 1;
            // 
            // pnlContent
            // 
            this.pnlContent.Dock = System.Windows.Forms.DockStyle.Fill;
            this.pnlContent.Location = new System.Drawing.Point(125, 29);
            this.pnlContent.Name = "pnlContent";
            this.pnlContent.Size = new System.Drawing.Size(703, 497);
            this.pnlContent.TabIndex = 2;
            // 
            // btnCongNo
            // 
            this.btnCongNo.BackColor = System.Drawing.Color.CadetBlue;
            this.btnCongNo.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnCongNo.ForeColor = System.Drawing.SystemColors.ControlText;
            this.btnCongNo.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.btnCongNo.Location = new System.Drawing.Point(10, 420);
            this.btnCongNo.Name = "btnCongNo";
            this.btnCongNo.Size = new System.Drawing.Size(109, 52);
            this.btnCongNo.TabIndex = 3;
            this.btnCongNo.Text = "Công nợ";
            this.btnCongNo.UseVisualStyleBackColor = false;
            this.btnCongNo.Click += new System.EventHandler(this.btnCongNo_Click);
            // 
            // FormContainer
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(828, 526);
            this.Controls.Add(this.pnlContent);
            this.Controls.Add(this.panel2);
            this.Controls.Add(this.panel1);
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.Name = "FormContainer";
            this.Text = "FormContainer";
            this.panel1.ResumeLayout(false);
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Panel panel1;
        private System.Windows.Forms.Button btnGhiChu;
        private System.Windows.Forms.Button btnDiem;
        private System.Windows.Forms.Button btnHome;
        private System.Windows.Forms.Panel panel2;
        private System.Windows.Forms.FlowLayoutPanel pnlContent;
        private System.Windows.Forms.Button btnCongNo;
    }
}
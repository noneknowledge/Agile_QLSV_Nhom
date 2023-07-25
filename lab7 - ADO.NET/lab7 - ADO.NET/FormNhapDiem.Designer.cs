namespace lab7___ADO.NET
{
    partial class FormNhapDiem
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
            this.dataGridView1 = new System.Windows.Forms.DataGridView();
            this.label1 = new System.Windows.Forms.Label();
            this.button1 = new System.Windows.Forms.Button();
            this.button2 = new System.Windows.Forms.Button();
            this.txtTim = new System.Windows.Forms.TextBox();
            this.cboTim = new System.Windows.Forms.ComboBox();
            this.label2 = new System.Windows.Forms.Label();
            this.label3 = new System.Windows.Forms.Label();
            this.label4 = new System.Windows.Forms.Label();
            this.txtMonHoc = new System.Windows.Forms.TextBox();
            this.txtMasv = new System.Windows.Forms.TextBox();
            this.txtGKY = new System.Windows.Forms.TextBox();
            this.label5 = new System.Windows.Forms.Label();
            this.label6 = new System.Windows.Forms.Label();
            this.txtHe4 = new System.Windows.Forms.TextBox();
            this.label8 = new System.Windows.Forms.Label();
            this.label9 = new System.Windows.Forms.Label();
            this.txtDanhGia = new System.Windows.Forms.TextBox();
            this.txtDauRot = new System.Windows.Forms.TextBox();
            this.label10 = new System.Windows.Forms.Label();
            this.txtHe10 = new System.Windows.Forms.TextBox();
            this.txtTKY = new System.Windows.Forms.TextBox();
            this.btnFind = new System.Windows.Forms.Button();
            this.btnReset = new System.Windows.Forms.Button();
            this.btnSua = new System.Windows.Forms.Button();
            this.label7 = new System.Windows.Forms.Label();
            this.txtCKY = new System.Windows.Forms.TextBox();
            this.txtMaLHP = new System.Windows.Forms.TextBox();
            this.label11 = new System.Windows.Forms.Label();
            this.cboNam = new System.Windows.Forms.ComboBox();
            this.cboHocKy = new System.Windows.Forms.ComboBox();
            this.label12 = new System.Windows.Forms.Label();
            this.label13 = new System.Windows.Forms.Label();
            ((System.ComponentModel.ISupportInitialize)(this.dataGridView1)).BeginInit();
            this.SuspendLayout();
            // 
            // dataGridView1
            // 
            this.dataGridView1.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dataGridView1.Location = new System.Drawing.Point(12, 261);
            this.dataGridView1.Name = "dataGridView1";
            this.dataGridView1.Size = new System.Drawing.Size(754, 255);
            this.dataGridView1.TabIndex = 0;
            this.dataGridView1.CellClick += new System.Windows.Forms.DataGridViewCellEventHandler(this.dataGridView1_CellClick);
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("Microsoft Sans Serif", 10F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label1.Location = new System.Drawing.Point(22, 23);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(64, 17);
            this.label1.TabIndex = 1;
            this.label1.Text = "Tìm kiếm";
            // 
            // button1
            // 
            this.button1.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.button1.Location = new System.Drawing.Point(204, 525);
            this.button1.Name = "button1";
            this.button1.Size = new System.Drawing.Size(98, 41);
            this.button1.TabIndex = 2;
            this.button1.Text = "<< Trước";
            this.button1.UseVisualStyleBackColor = true;
            this.button1.Click += new System.EventHandler(this.button1_Click);
            // 
            // button2
            // 
            this.button2.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.button2.Location = new System.Drawing.Point(453, 522);
            this.button2.Name = "button2";
            this.button2.Size = new System.Drawing.Size(102, 41);
            this.button2.TabIndex = 3;
            this.button2.Text = "Sau >>";
            this.button2.UseVisualStyleBackColor = true;
            this.button2.Click += new System.EventHandler(this.button2_Click);
            // 
            // txtTim
            // 
            this.txtTim.Font = new System.Drawing.Font("Microsoft Sans Serif", 10F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtTim.Location = new System.Drawing.Point(87, 20);
            this.txtTim.Name = "txtTim";
            this.txtTim.Size = new System.Drawing.Size(100, 23);
            this.txtTim.TabIndex = 4;
            // 
            // cboTim
            // 
            this.cboTim.Font = new System.Drawing.Font("Microsoft Sans Serif", 10F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.cboTim.FormattingEnabled = true;
            this.cboTim.Items.AddRange(new object[] {
            "Mã sinh viên",
            "Mã lớp học phần"});
            this.cboTim.Location = new System.Drawing.Point(210, 19);
            this.cboTim.Name = "cboTim";
            this.cboTim.Size = new System.Drawing.Size(121, 24);
            this.cboTim.TabIndex = 5;
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Font = new System.Drawing.Font("Microsoft Sans Serif", 10F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label2.Location = new System.Drawing.Point(201, 67);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(66, 17);
            this.label2.TabIndex = 6;
            this.label2.Text = "Môn học:";
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Font = new System.Drawing.Font("Microsoft Sans Serif", 10F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label3.Location = new System.Drawing.Point(25, 68);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(91, 17);
            this.label3.TabIndex = 7;
            this.label3.Text = "Mã sinh viên:";
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Font = new System.Drawing.Font("Microsoft Sans Serif", 10F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label4.Location = new System.Drawing.Point(25, 119);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(106, 17);
            this.label4.TabIndex = 8;
            this.label4.Text = "Điểm thường kỳ";
            // 
            // txtMonHoc
            // 
            this.txtMonHoc.Enabled = false;
            this.txtMonHoc.Font = new System.Drawing.Font("Microsoft Sans Serif", 10F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtMonHoc.Location = new System.Drawing.Point(264, 62);
            this.txtMonHoc.Name = "txtMonHoc";
            this.txtMonHoc.Size = new System.Drawing.Size(208, 23);
            this.txtMonHoc.TabIndex = 13;
            // 
            // txtMasv
            // 
            this.txtMasv.Enabled = false;
            this.txtMasv.Font = new System.Drawing.Font("Microsoft Sans Serif", 10F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtMasv.Location = new System.Drawing.Point(113, 65);
            this.txtMasv.Name = "txtMasv";
            this.txtMasv.Size = new System.Drawing.Size(74, 23);
            this.txtMasv.TabIndex = 14;
            // 
            // txtGKY
            // 
            this.txtGKY.Font = new System.Drawing.Font("Microsoft Sans Serif", 10F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtGKY.Location = new System.Drawing.Point(137, 160);
            this.txtGKY.Name = "txtGKY";
            this.txtGKY.Size = new System.Drawing.Size(50, 23);
            this.txtGKY.TabIndex = 20;
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Font = new System.Drawing.Font("Microsoft Sans Serif", 10F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label5.Location = new System.Drawing.Point(433, 163);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(148, 17);
            this.label5.TabIndex = 17;
            this.label5.Text = "Điểm trung bình hệ 10";
            // 
            // label6
            // 
            this.label6.AutoSize = true;
            this.label6.Font = new System.Drawing.Font("Microsoft Sans Serif", 10F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label6.Location = new System.Drawing.Point(42, 163);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(89, 17);
            this.label6.TabIndex = 16;
            this.label6.Text = "Điểm giữa kỳ";
            // 
            // txtHe4
            // 
            this.txtHe4.Enabled = false;
            this.txtHe4.Font = new System.Drawing.Font("Microsoft Sans Serif", 10F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtHe4.Location = new System.Drawing.Point(345, 160);
            this.txtHe4.Name = "txtHe4";
            this.txtHe4.Size = new System.Drawing.Size(82, 23);
            this.txtHe4.TabIndex = 22;
            // 
            // label8
            // 
            this.label8.AutoSize = true;
            this.label8.Font = new System.Drawing.Font("Microsoft Sans Serif", 10F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label8.Location = new System.Drawing.Point(199, 163);
            this.label8.Name = "label8";
            this.label8.Size = new System.Drawing.Size(140, 17);
            this.label8.TabIndex = 21;
            this.label8.Text = "Điểm trung bình hệ 4";
            // 
            // label9
            // 
            this.label9.AutoSize = true;
            this.label9.Font = new System.Drawing.Font("Microsoft Sans Serif", 10F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label9.Location = new System.Drawing.Point(225, 206);
            this.label9.Name = "label9";
            this.label9.Size = new System.Drawing.Size(69, 17);
            this.label9.TabIndex = 23;
            this.label9.Text = "Đánh giá:";
            // 
            // txtDanhGia
            // 
            this.txtDanhGia.Enabled = false;
            this.txtDanhGia.Font = new System.Drawing.Font("Microsoft Sans Serif", 10F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtDanhGia.Location = new System.Drawing.Point(333, 203);
            this.txtDanhGia.Name = "txtDanhGia";
            this.txtDanhGia.Size = new System.Drawing.Size(94, 23);
            this.txtDanhGia.TabIndex = 24;
            // 
            // txtDauRot
            // 
            this.txtDauRot.Enabled = false;
            this.txtDauRot.Font = new System.Drawing.Font("Microsoft Sans Serif", 10F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtDauRot.Location = new System.Drawing.Point(555, 200);
            this.txtDauRot.Name = "txtDauRot";
            this.txtDauRot.Size = new System.Drawing.Size(99, 23);
            this.txtDauRot.TabIndex = 26;
            // 
            // label10
            // 
            this.label10.AutoSize = true;
            this.label10.Font = new System.Drawing.Font("Microsoft Sans Serif", 10F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label10.Location = new System.Drawing.Point(468, 203);
            this.label10.Name = "label10";
            this.label10.Size = new System.Drawing.Size(64, 17);
            this.label10.TabIndex = 25;
            this.label10.Text = "Đậu/ Rớt";
            // 
            // txtHe10
            // 
            this.txtHe10.Enabled = false;
            this.txtHe10.Font = new System.Drawing.Font("Microsoft Sans Serif", 10F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtHe10.Location = new System.Drawing.Point(587, 160);
            this.txtHe10.Name = "txtHe10";
            this.txtHe10.Size = new System.Drawing.Size(67, 23);
            this.txtHe10.TabIndex = 29;
            // 
            // txtTKY
            // 
            this.txtTKY.Font = new System.Drawing.Font("Microsoft Sans Serif", 10F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtTKY.Location = new System.Drawing.Point(137, 116);
            this.txtTKY.Name = "txtTKY";
            this.txtTKY.Size = new System.Drawing.Size(50, 23);
            this.txtTKY.TabIndex = 31;
            // 
            // btnFind
            // 
            this.btnFind.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnFind.Location = new System.Drawing.Point(393, 15);
            this.btnFind.Name = "btnFind";
            this.btnFind.Size = new System.Drawing.Size(107, 41);
            this.btnFind.TabIndex = 32;
            this.btnFind.Text = "Tìm";
            this.btnFind.UseVisualStyleBackColor = true;
            this.btnFind.Click += new System.EventHandler(this.btnFind_Click);
            // 
            // btnReset
            // 
            this.btnReset.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnReset.Location = new System.Drawing.Point(522, 14);
            this.btnReset.Name = "btnReset";
            this.btnReset.Size = new System.Drawing.Size(114, 42);
            this.btnReset.TabIndex = 33;
            this.btnReset.Text = "Reset";
            this.btnReset.UseVisualStyleBackColor = true;
            this.btnReset.Click += new System.EventHandler(this.btnReset_Click);
            // 
            // btnSua
            // 
            this.btnSua.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnSua.Location = new System.Drawing.Point(650, 14);
            this.btnSua.Name = "btnSua";
            this.btnSua.Size = new System.Drawing.Size(116, 42);
            this.btnSua.TabIndex = 34;
            this.btnSua.Text = "Sửa";
            this.btnSua.UseVisualStyleBackColor = true;
            this.btnSua.Click += new System.EventHandler(this.btnSua_Click);
            // 
            // label7
            // 
            this.label7.AutoSize = true;
            this.label7.Font = new System.Drawing.Font("Microsoft Sans Serif", 10F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label7.Location = new System.Drawing.Point(48, 206);
            this.label7.Name = "label7";
            this.label7.Size = new System.Drawing.Size(88, 17);
            this.label7.TabIndex = 15;
            this.label7.Text = "Điểm cuối kỳ";
            // 
            // txtCKY
            // 
            this.txtCKY.Font = new System.Drawing.Font("Microsoft Sans Serif", 10F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtCKY.Location = new System.Drawing.Point(137, 203);
            this.txtCKY.Name = "txtCKY";
            this.txtCKY.Size = new System.Drawing.Size(50, 23);
            this.txtCKY.TabIndex = 30;
            // 
            // txtMaLHP
            // 
            this.txtMaLHP.Enabled = false;
            this.txtMaLHP.Font = new System.Drawing.Font("Microsoft Sans Serif", 10F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtMaLHP.Location = new System.Drawing.Point(324, 116);
            this.txtMaLHP.Name = "txtMaLHP";
            this.txtMaLHP.Size = new System.Drawing.Size(103, 23);
            this.txtMaLHP.TabIndex = 36;
            // 
            // label11
            // 
            this.label11.AutoSize = true;
            this.label11.Font = new System.Drawing.Font("Microsoft Sans Serif", 10F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label11.Location = new System.Drawing.Point(198, 116);
            this.label11.Name = "label11";
            this.label11.Size = new System.Drawing.Size(113, 17);
            this.label11.TabIndex = 35;
            this.label11.Text = "Mã lớp học phần";
            // 
            // cboNam
            // 
            this.cboNam.Font = new System.Drawing.Font("Microsoft Sans Serif", 10F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.cboNam.FormattingEnabled = true;
            this.cboNam.Items.AddRange(new object[] {
            "Tất cả"});
            this.cboNam.Location = new System.Drawing.Point(634, 68);
            this.cboNam.Name = "cboNam";
            this.cboNam.Size = new System.Drawing.Size(121, 24);
            this.cboNam.TabIndex = 37;
            this.cboNam.SelectedIndexChanged += new System.EventHandler(this.cboNam_SelectedIndexChanged);
            // 
            // cboHocKy
            // 
            this.cboHocKy.Font = new System.Drawing.Font("Microsoft Sans Serif", 10F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.cboHocKy.FormattingEnabled = true;
            this.cboHocKy.Items.AddRange(new object[] {
            "Tất cả",
            "Học kỳ 1",
            "Học kỳ 2",
            "Học kỳ 3"});
            this.cboHocKy.Location = new System.Drawing.Point(634, 119);
            this.cboHocKy.Name = "cboHocKy";
            this.cboHocKy.Size = new System.Drawing.Size(121, 24);
            this.cboHocKy.TabIndex = 38;
            this.cboHocKy.SelectedIndexChanged += new System.EventHandler(this.cboHocKy_SelectedIndexChanged);
            // 
            // label12
            // 
            this.label12.AutoSize = true;
            this.label12.Font = new System.Drawing.Font("Microsoft Sans Serif", 10F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label12.Location = new System.Drawing.Point(539, 71);
            this.label12.Name = "label12";
            this.label12.Size = new System.Drawing.Size(64, 17);
            this.label12.TabIndex = 39;
            this.label12.Text = "Năm học";
            // 
            // label13
            // 
            this.label13.AutoSize = true;
            this.label13.Font = new System.Drawing.Font("Microsoft Sans Serif", 10F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label13.Location = new System.Drawing.Point(552, 122);
            this.label13.Name = "label13";
            this.label13.Size = new System.Drawing.Size(51, 17);
            this.label13.TabIndex = 40;
            this.label13.Text = "Học kỳ";
            // 
            // FormNhapDiem
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(778, 578);
            this.Controls.Add(this.label13);
            this.Controls.Add(this.label12);
            this.Controls.Add(this.cboHocKy);
            this.Controls.Add(this.cboNam);
            this.Controls.Add(this.txtMaLHP);
            this.Controls.Add(this.label11);
            this.Controls.Add(this.btnSua);
            this.Controls.Add(this.btnReset);
            this.Controls.Add(this.btnFind);
            this.Controls.Add(this.txtTKY);
            this.Controls.Add(this.txtCKY);
            this.Controls.Add(this.txtHe10);
            this.Controls.Add(this.txtDauRot);
            this.Controls.Add(this.label10);
            this.Controls.Add(this.txtDanhGia);
            this.Controls.Add(this.label9);
            this.Controls.Add(this.txtHe4);
            this.Controls.Add(this.label8);
            this.Controls.Add(this.txtGKY);
            this.Controls.Add(this.label5);
            this.Controls.Add(this.label6);
            this.Controls.Add(this.label7);
            this.Controls.Add(this.txtMasv);
            this.Controls.Add(this.txtMonHoc);
            this.Controls.Add(this.label4);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.cboTim);
            this.Controls.Add(this.txtTim);
            this.Controls.Add(this.button2);
            this.Controls.Add(this.button1);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.dataGridView1);
            this.Name = "FormNhapDiem";
            this.Text = "FormNhapDiem";
            this.Load += new System.EventHandler(this.FormNhapDiem_Load);
            ((System.ComponentModel.ISupportInitialize)(this.dataGridView1)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.DataGridView dataGridView1;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Button button1;
        private System.Windows.Forms.Button button2;
        private System.Windows.Forms.TextBox txtTim;
        private System.Windows.Forms.ComboBox cboTim;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.TextBox txtMonHoc;
        private System.Windows.Forms.TextBox txtMasv;
        private System.Windows.Forms.TextBox txtGKY;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.Label label6;
        private System.Windows.Forms.TextBox txtHe4;
        private System.Windows.Forms.Label label8;
        private System.Windows.Forms.Label label9;
        private System.Windows.Forms.TextBox txtDanhGia;
        private System.Windows.Forms.TextBox txtDauRot;
        private System.Windows.Forms.Label label10;
        private System.Windows.Forms.TextBox txtHe10;
        private System.Windows.Forms.TextBox txtTKY;
        private System.Windows.Forms.Button btnFind;
        private System.Windows.Forms.Button btnReset;
        private System.Windows.Forms.Button btnSua;
        private System.Windows.Forms.Label label7;
        private System.Windows.Forms.TextBox txtCKY;
        private System.Windows.Forms.TextBox txtMaLHP;
        private System.Windows.Forms.Label label11;
        private System.Windows.Forms.ComboBox cboNam;
        private System.Windows.Forms.ComboBox cboHocKy;
        private System.Windows.Forms.Label label12;
        private System.Windows.Forms.Label label13;
    }
}
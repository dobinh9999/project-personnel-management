namespace qlnv_admin
{
    partial class KHENTHUONG
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
            this.components = new System.ComponentModel.Container();
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(KHENTHUONG));
            this.groupBox1 = new System.Windows.Forms.GroupBox();
            this.dataGridView1 = new System.Windows.Forms.DataGridView();
            this.mAKTDataGridViewTextBoxColumn = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.mANVDataGridViewTextBoxColumn = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.sOKTDataGridViewTextBoxColumn = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.nOIDUNGDataGridViewTextBoxColumn = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.tIENTHUONGDataGridViewTextBoxColumn = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.nGAYKYQDDataGridViewTextBoxColumn = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.kHENTHUONGBindingSource = new System.Windows.Forms.BindingSource(this.components);
            this.quanLyNhanVienv2DataSet2 = new qlnv_admin.QuanLyNhanVienv2DataSet2();
            this.groubox = new System.Windows.Forms.GroupBox();
            this.tb_ngaykyqd = new System.Windows.Forms.DateTimePicker();
            this.label6 = new System.Windows.Forms.Label();
            this.tb_tt = new System.Windows.Forms.TextBox();
            this.label5 = new System.Windows.Forms.Label();
            this.tb_nd = new System.Windows.Forms.TextBox();
            this.label4 = new System.Windows.Forms.Label();
            this.tb_sokt = new System.Windows.Forms.TextBox();
            this.label3 = new System.Windows.Forms.Label();
            this.tb_manv = new System.Windows.Forms.TextBox();
            this.label2 = new System.Windows.Forms.Label();
            this.tb_makt = new System.Windows.Forms.TextBox();
            this.label1 = new System.Windows.Forms.Label();
            this.groupBox3 = new System.Windows.Forms.GroupBox();
            this.button6 = new System.Windows.Forms.Button();
            this.button5 = new System.Windows.Forms.Button();
            this.button3 = new System.Windows.Forms.Button();
            this.button4 = new System.Windows.Forms.Button();
            this.button2 = new System.Windows.Forms.Button();
            this.button1 = new System.Windows.Forms.Button();
            this.groupBox4 = new System.Windows.Forms.GroupBox();
            this.tb_timkiem = new System.Windows.Forms.TextBox();
            this.button8 = new System.Windows.Forms.Button();
            this.button7 = new System.Windows.Forms.Button();
            this.kHENTHUONGTableAdapter = new qlnv_admin.QuanLyNhanVienv2DataSet2TableAdapters.KHENTHUONGTableAdapter();
            this.groupBox1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dataGridView1)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.kHENTHUONGBindingSource)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.quanLyNhanVienv2DataSet2)).BeginInit();
            this.groubox.SuspendLayout();
            this.groupBox3.SuspendLayout();
            this.groupBox4.SuspendLayout();
            this.SuspendLayout();
            // 
            // groupBox1
            // 
            this.groupBox1.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.groupBox1.BackColor = System.Drawing.SystemColors.ButtonHighlight;
            this.groupBox1.Controls.Add(this.dataGridView1);
            this.groupBox1.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.groupBox1.Location = new System.Drawing.Point(12, 313);
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.Size = new System.Drawing.Size(1346, 282);
            this.groupBox1.TabIndex = 0;
            this.groupBox1.TabStop = false;
            this.groupBox1.Text = "DANH SÁCH";
            // 
            // dataGridView1
            // 
            this.dataGridView1.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.dataGridView1.AutoGenerateColumns = false;
            this.dataGridView1.AutoSizeColumnsMode = System.Windows.Forms.DataGridViewAutoSizeColumnsMode.Fill;
            this.dataGridView1.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dataGridView1.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.mAKTDataGridViewTextBoxColumn,
            this.mANVDataGridViewTextBoxColumn,
            this.sOKTDataGridViewTextBoxColumn,
            this.nOIDUNGDataGridViewTextBoxColumn,
            this.tIENTHUONGDataGridViewTextBoxColumn,
            this.nGAYKYQDDataGridViewTextBoxColumn});
            this.dataGridView1.DataSource = this.kHENTHUONGBindingSource;
            this.dataGridView1.Location = new System.Drawing.Point(7, 20);
            this.dataGridView1.Name = "dataGridView1";
            this.dataGridView1.Size = new System.Drawing.Size(1331, 253);
            this.dataGridView1.TabIndex = 0;
            this.dataGridView1.CellClick += new System.Windows.Forms.DataGridViewCellEventHandler(this.dataGridView1_CellClick);
            // 
            // mAKTDataGridViewTextBoxColumn
            // 
            this.mAKTDataGridViewTextBoxColumn.DataPropertyName = "MAKT";
            this.mAKTDataGridViewTextBoxColumn.HeaderText = "MÃ KHEN THƯỞNG";
            this.mAKTDataGridViewTextBoxColumn.Name = "mAKTDataGridViewTextBoxColumn";
            this.mAKTDataGridViewTextBoxColumn.ReadOnly = true;
            // 
            // mANVDataGridViewTextBoxColumn
            // 
            this.mANVDataGridViewTextBoxColumn.DataPropertyName = "MANV";
            this.mANVDataGridViewTextBoxColumn.HeaderText = "MÃ NHÂN VIÊN ";
            this.mANVDataGridViewTextBoxColumn.Name = "mANVDataGridViewTextBoxColumn";
            this.mANVDataGridViewTextBoxColumn.ReadOnly = true;
            // 
            // sOKTDataGridViewTextBoxColumn
            // 
            this.sOKTDataGridViewTextBoxColumn.DataPropertyName = "SOKT";
            this.sOKTDataGridViewTextBoxColumn.HeaderText = "SỐ KHEN THƯỞNG";
            this.sOKTDataGridViewTextBoxColumn.Name = "sOKTDataGridViewTextBoxColumn";
            this.sOKTDataGridViewTextBoxColumn.ReadOnly = true;
            // 
            // nOIDUNGDataGridViewTextBoxColumn
            // 
            this.nOIDUNGDataGridViewTextBoxColumn.DataPropertyName = "NOIDUNG";
            this.nOIDUNGDataGridViewTextBoxColumn.HeaderText = "NỘI DUNG";
            this.nOIDUNGDataGridViewTextBoxColumn.Name = "nOIDUNGDataGridViewTextBoxColumn";
            this.nOIDUNGDataGridViewTextBoxColumn.ReadOnly = true;
            // 
            // tIENTHUONGDataGridViewTextBoxColumn
            // 
            this.tIENTHUONGDataGridViewTextBoxColumn.DataPropertyName = "TIENTHUONG";
            this.tIENTHUONGDataGridViewTextBoxColumn.HeaderText = "TIỀN THƯỞNG ";
            this.tIENTHUONGDataGridViewTextBoxColumn.Name = "tIENTHUONGDataGridViewTextBoxColumn";
            this.tIENTHUONGDataGridViewTextBoxColumn.ReadOnly = true;
            // 
            // nGAYKYQDDataGridViewTextBoxColumn
            // 
            this.nGAYKYQDDataGridViewTextBoxColumn.DataPropertyName = "NGAYKYQD";
            this.nGAYKYQDDataGridViewTextBoxColumn.HeaderText = "NGÀY KÝ QUYẾT ĐỊNH";
            this.nGAYKYQDDataGridViewTextBoxColumn.Name = "nGAYKYQDDataGridViewTextBoxColumn";
            this.nGAYKYQDDataGridViewTextBoxColumn.ReadOnly = true;
            // 
            // kHENTHUONGBindingSource
            // 
            this.kHENTHUONGBindingSource.DataMember = "KHENTHUONG";
            this.kHENTHUONGBindingSource.DataSource = this.quanLyNhanVienv2DataSet2;
            // 
            // quanLyNhanVienv2DataSet2
            // 
            this.quanLyNhanVienv2DataSet2.DataSetName = "QuanLyNhanVienv2DataSet2";
            this.quanLyNhanVienv2DataSet2.SchemaSerializationMode = System.Data.SchemaSerializationMode.IncludeSchema;
            // 
            // groubox
            // 
            this.groubox.BackColor = System.Drawing.SystemColors.ButtonHighlight;
            this.groubox.Controls.Add(this.tb_ngaykyqd);
            this.groubox.Controls.Add(this.label6);
            this.groubox.Controls.Add(this.tb_tt);
            this.groubox.Controls.Add(this.label5);
            this.groubox.Controls.Add(this.tb_nd);
            this.groubox.Controls.Add(this.label4);
            this.groubox.Controls.Add(this.tb_sokt);
            this.groubox.Controls.Add(this.label3);
            this.groubox.Controls.Add(this.tb_manv);
            this.groubox.Controls.Add(this.label2);
            this.groubox.Controls.Add(this.tb_makt);
            this.groubox.Controls.Add(this.label1);
            this.groubox.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.groubox.Location = new System.Drawing.Point(12, 12);
            this.groubox.Name = "groubox";
            this.groubox.Size = new System.Drawing.Size(705, 295);
            this.groubox.TabIndex = 0;
            this.groubox.TabStop = false;
            this.groubox.Text = "THÔNG TIN";
            this.groubox.Enter += new System.EventHandler(this.groupBox2_Enter);
            // 
            // tb_ngaykyqd
            // 
            this.tb_ngaykyqd.Format = System.Windows.Forms.DateTimePickerFormat.Short;
            this.tb_ngaykyqd.Location = new System.Drawing.Point(397, 234);
            this.tb_ngaykyqd.Name = "tb_ngaykyqd";
            this.tb_ngaykyqd.Size = new System.Drawing.Size(135, 26);
            this.tb_ngaykyqd.TabIndex = 3;
            // 
            // label6
            // 
            this.label6.AutoSize = true;
            this.label6.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label6.Location = new System.Drawing.Point(391, 207);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(157, 20);
            this.label6.TabIndex = 0;
            this.label6.Text = "Ngày Ký Quyết Định :";
            // 
            // tb_tt
            // 
            this.tb_tt.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.tb_tt.Location = new System.Drawing.Point(397, 151);
            this.tb_tt.Name = "tb_tt";
            this.tb_tt.Size = new System.Drawing.Size(244, 26);
            this.tb_tt.TabIndex = 1;
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label5.Location = new System.Drawing.Point(394, 124);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(105, 20);
            this.label5.TabIndex = 0;
            this.label5.Text = "Tiền Thưởng :";
            // 
            // tb_nd
            // 
            this.tb_nd.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.tb_nd.Location = new System.Drawing.Point(395, 67);
            this.tb_nd.Name = "tb_nd";
            this.tb_nd.Size = new System.Drawing.Size(244, 26);
            this.tb_nd.TabIndex = 1;
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label4.Location = new System.Drawing.Point(393, 44);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(83, 20);
            this.label4.TabIndex = 0;
            this.label4.Text = "Nội Dung :";
            // 
            // tb_sokt
            // 
            this.tb_sokt.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.tb_sokt.Location = new System.Drawing.Point(71, 234);
            this.tb_sokt.Name = "tb_sokt";
            this.tb_sokt.Size = new System.Drawing.Size(244, 26);
            this.tb_sokt.TabIndex = 1;
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label3.Location = new System.Drawing.Point(68, 207);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(136, 20);
            this.label3.TabIndex = 0;
            this.label3.Text = "Số Khen Thưởng :";
            // 
            // tb_manv
            // 
            this.tb_manv.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.tb_manv.Location = new System.Drawing.Point(72, 151);
            this.tb_manv.Name = "tb_manv";
            this.tb_manv.Size = new System.Drawing.Size(244, 26);
            this.tb_manv.TabIndex = 1;
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label2.Location = new System.Drawing.Point(69, 124);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(117, 20);
            this.label2.TabIndex = 0;
            this.label2.Text = "Mã Nhân Viên :";
            // 
            // tb_makt
            // 
            this.tb_makt.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.tb_makt.Location = new System.Drawing.Point(71, 67);
            this.tb_makt.Name = "tb_makt";
            this.tb_makt.Size = new System.Drawing.Size(244, 26);
            this.tb_makt.TabIndex = 1;
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label1.Location = new System.Drawing.Point(68, 40);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(138, 20);
            this.label1.TabIndex = 0;
            this.label1.Text = "Mã Khen Thưởng :";
            // 
            // groupBox3
            // 
            this.groupBox3.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.groupBox3.BackColor = System.Drawing.SystemColors.ButtonHighlight;
            this.groupBox3.Controls.Add(this.button6);
            this.groupBox3.Controls.Add(this.button5);
            this.groupBox3.Controls.Add(this.button3);
            this.groupBox3.Controls.Add(this.button4);
            this.groupBox3.Controls.Add(this.button2);
            this.groupBox3.Controls.Add(this.button1);
            this.groupBox3.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.groupBox3.Location = new System.Drawing.Point(723, 12);
            this.groupBox3.Name = "groupBox3";
            this.groupBox3.Size = new System.Drawing.Size(635, 193);
            this.groupBox3.TabIndex = 0;
            this.groupBox3.TabStop = false;
            this.groupBox3.Text = "CHỨC NĂNG";
            this.groupBox3.Enter += new System.EventHandler(this.groupBox3_Enter);
            // 
            // button6
            // 
            this.button6.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.button6.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.button6.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.button6.Location = new System.Drawing.Point(422, 113);
            this.button6.Name = "button6";
            this.button6.Size = new System.Drawing.Size(129, 45);
            this.button6.TabIndex = 0;
            this.button6.Text = "button1";
            this.button6.UseVisualStyleBackColor = true;
            // 
            // button5
            // 
            this.button5.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.button5.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.button5.Image = global::qlnv_admin.Properties.Resources.Dakirby309_Simply_Styled_Microsoft_Excel_2013_16;
            this.button5.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.button5.Location = new System.Drawing.Point(269, 113);
            this.button5.Name = "button5";
            this.button5.Size = new System.Drawing.Size(129, 45);
            this.button5.TabIndex = 0;
            this.button5.Text = "Excel";
            this.button5.UseVisualStyleBackColor = true;
            this.button5.Click += new System.EventHandler(this.button5_Click);
            // 
            // button3
            // 
            this.button3.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.button3.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.button3.Image = global::qlnv_admin.Properties.Resources.Multivitamin_Multiminimal_Trash_empty_16;
            this.button3.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.button3.Location = new System.Drawing.Point(422, 37);
            this.button3.Name = "button3";
            this.button3.Size = new System.Drawing.Size(129, 45);
            this.button3.TabIndex = 0;
            this.button3.Text = "Xóa";
            this.button3.UseVisualStyleBackColor = true;
            this.button3.Click += new System.EventHandler(this.button3_Click);
            // 
            // button4
            // 
            this.button4.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.button4.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.button4.Image = global::qlnv_admin.Properties.Resources.Fasticon_Essential_Toolbar_Refresh1;
            this.button4.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.button4.Location = new System.Drawing.Point(112, 113);
            this.button4.Name = "button4";
            this.button4.Size = new System.Drawing.Size(129, 45);
            this.button4.TabIndex = 0;
            this.button4.Text = "Mới";
            this.button4.UseVisualStyleBackColor = true;
            this.button4.Click += new System.EventHandler(this.button4_Click);
            // 
            // button2
            // 
            this.button2.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.button2.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.button2.Image = global::qlnv_admin.Properties.Resources.Oxygen_Icons_org_Oxygen_Apps_system_software_update_16;
            this.button2.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.button2.Location = new System.Drawing.Point(269, 37);
            this.button2.Name = "button2";
            this.button2.Size = new System.Drawing.Size(129, 45);
            this.button2.TabIndex = 0;
            this.button2.Text = "Sửa";
            this.button2.UseVisualStyleBackColor = true;
            this.button2.Click += new System.EventHandler(this.button2_Click);
            // 
            // button1
            // 
            this.button1.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.button1.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.button1.Image = global::qlnv_admin.Properties.Resources.Custom_Icon_Design_Pretty_Office_7_Save_16;
            this.button1.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.button1.Location = new System.Drawing.Point(112, 37);
            this.button1.Name = "button1";
            this.button1.Size = new System.Drawing.Size(129, 45);
            this.button1.TabIndex = 0;
            this.button1.Text = "Thêm";
            this.button1.UseVisualStyleBackColor = true;
            this.button1.Click += new System.EventHandler(this.button1_Click);
            // 
            // groupBox4
            // 
            this.groupBox4.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.groupBox4.BackColor = System.Drawing.SystemColors.ButtonHighlight;
            this.groupBox4.Controls.Add(this.tb_timkiem);
            this.groupBox4.Controls.Add(this.button8);
            this.groupBox4.Controls.Add(this.button7);
            this.groupBox4.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.groupBox4.Location = new System.Drawing.Point(723, 211);
            this.groupBox4.Name = "groupBox4";
            this.groupBox4.Size = new System.Drawing.Size(635, 96);
            this.groupBox4.TabIndex = 0;
            this.groupBox4.TabStop = false;
            this.groupBox4.Text = "TÌM KIẾM";
            // 
            // tb_timkiem
            // 
            this.tb_timkiem.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.tb_timkiem.Location = new System.Drawing.Point(62, 43);
            this.tb_timkiem.Name = "tb_timkiem";
            this.tb_timkiem.Size = new System.Drawing.Size(244, 26);
            this.tb_timkiem.TabIndex = 1;
            // 
            // button8
            // 
            this.button8.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.button8.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.button8.Image = global::qlnv_admin.Properties.Resources.Fasticon_Essential_Toolbar_Refresh1;
            this.button8.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.button8.Location = new System.Drawing.Point(422, 37);
            this.button8.Name = "button8";
            this.button8.Size = new System.Drawing.Size(182, 39);
            this.button8.TabIndex = 0;
            this.button8.Text = "  Hiển Thị Lại Dữ Liệu";
            this.button8.UseVisualStyleBackColor = true;
            this.button8.Click += new System.EventHandler(this.button8_Click);
            // 
            // button7
            // 
            this.button7.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.button7.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.button7.Image = ((System.Drawing.Image)(resources.GetObject("button7.Image")));
            this.button7.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.button7.Location = new System.Drawing.Point(312, 37);
            this.button7.Name = "button7";
            this.button7.Size = new System.Drawing.Size(104, 39);
            this.button7.TabIndex = 0;
            this.button7.Text = "   Tìm Kiếm";
            this.button7.UseVisualStyleBackColor = true;
            this.button7.Click += new System.EventHandler(this.button7_Click);
            // 
            // kHENTHUONGTableAdapter
            // 
            this.kHENTHUONGTableAdapter.ClearBeforeFill = true;
            // 
            // KHENTHUONG
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.DodgerBlue;
            this.ClientSize = new System.Drawing.Size(1370, 607);
            this.Controls.Add(this.groupBox4);
            this.Controls.Add(this.groupBox3);
            this.Controls.Add(this.groubox);
            this.Controls.Add(this.groupBox1);
            this.Name = "KHENTHUONG";
            this.Text = "KHEN THƯỞNG";
            this.Load += new System.EventHandler(this.KHENTHUONG_Load);
            this.groupBox1.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.dataGridView1)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.kHENTHUONGBindingSource)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.quanLyNhanVienv2DataSet2)).EndInit();
            this.groubox.ResumeLayout(false);
            this.groubox.PerformLayout();
            this.groupBox3.ResumeLayout(false);
            this.groupBox4.ResumeLayout(false);
            this.groupBox4.PerformLayout();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.GroupBox groupBox1;
        private System.Windows.Forms.GroupBox groubox;
        private System.Windows.Forms.GroupBox groupBox3;
        private System.Windows.Forms.GroupBox groupBox4;
        private System.Windows.Forms.DataGridView dataGridView1;
        private System.Windows.Forms.TextBox tb_makt;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label label6;
        private System.Windows.Forms.TextBox tb_tt;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.TextBox tb_nd;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.TextBox tb_sokt;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.TextBox tb_manv;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Button button6;
        private System.Windows.Forms.Button button5;
        private System.Windows.Forms.Button button3;
        private System.Windows.Forms.Button button4;
        private System.Windows.Forms.Button button2;
        private System.Windows.Forms.Button button1;
        private System.Windows.Forms.TextBox tb_timkiem;
        private System.Windows.Forms.Button button8;
        private System.Windows.Forms.Button button7;
        private QuanLyNhanVienv2DataSet2 quanLyNhanVienv2DataSet2;
        private System.Windows.Forms.BindingSource kHENTHUONGBindingSource;
        private QuanLyNhanVienv2DataSet2TableAdapters.KHENTHUONGTableAdapter kHENTHUONGTableAdapter;
        private System.Windows.Forms.DataGridViewTextBoxColumn mAKTDataGridViewTextBoxColumn;
        private System.Windows.Forms.DataGridViewTextBoxColumn mANVDataGridViewTextBoxColumn;
        private System.Windows.Forms.DataGridViewTextBoxColumn sOKTDataGridViewTextBoxColumn;
        private System.Windows.Forms.DataGridViewTextBoxColumn nOIDUNGDataGridViewTextBoxColumn;
        private System.Windows.Forms.DataGridViewTextBoxColumn tIENTHUONGDataGridViewTextBoxColumn;
        private System.Windows.Forms.DataGridViewTextBoxColumn nGAYKYQDDataGridViewTextBoxColumn;
        private System.Windows.Forms.DateTimePicker tb_ngaykyqd;
    }
}
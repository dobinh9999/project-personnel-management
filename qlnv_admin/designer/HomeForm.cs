using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Reflection.Emit;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace qlnv_admin
{
    public partial class HomeForm : Form
    {
        public HomeForm()
        {
            InitializeComponent();
        }

        private void hệThốngToolStripMenuItem_Click(object sender, EventArgs e)
        {

        }
        private Form currentFormChild; // hiện form con

        private void OpenChildForm(Form childForm)
        {
            if (currentFormChild != null)
            {
                currentFormChild.Close();
            }
            currentFormChild = childForm;
            childForm.TopLevel = false;
            childForm.FormBorderStyle = FormBorderStyle.None;
            childForm.Dock = DockStyle.Fill;
            panel_body.Controls.Add(childForm);
            panel_body.Tag = childForm;
            childForm.BringToFront();
            childForm.Show();
        }
        private void nhânViênToolStripMenuItem_Click(object sender, EventArgs e)
        {

            NHANVIEN NV = new NHANVIEN();
            OpenChildForm(NV);
            label2.Text = NV.Text;
        }

        private void phòngBanToolStripMenuItem_Click(object sender, EventArgs e)
        {
            PHONGBAN PB = new PHONGBAN();
            OpenChildForm(PB);
            label2.Text = PB.Text;
        }

        private void bộPhậnToolStripMenuItem_Click(object sender, EventArgs e)
        {
            BOPHAN BP = new BOPHAN();
            OpenChildForm(BP);
            label2.Text = BP.Text;
        }

        private void chứcToolStripMenuItem_Click(object sender, EventArgs e)
        {
            CHUCVU CV = new CHUCVU();
            OpenChildForm(CV);
            label2.Text = CV.Text;
        }

        private void khenthuongToolStripMenuItem_Click(object sender, EventArgs e)
        {
            KHENTHUONG KT = new KHENTHUONG();
            OpenChildForm(KT);
            label2.Text = KT.Text;
        }

        private void kỷluậtToolStripMenuItem_Click(object sender, EventArgs e)
        {
            KYLUAT KL = new KYLUAT();
            OpenChildForm(KL);
            label2.Text = KL.Text;
        }

        private void BảohiểmToolStripMenuItem_Click(object sender, EventArgs e)
        {
            BAOHIEM BH = new BAOHIEM();
            OpenChildForm(BH);
            label2.Text = BH.Text;
        }

        private void hợpĐồngLaoĐộngToolStripMenuItem_Click(object sender, EventArgs e)
        {
            HDLD hDLD = new HDLD();
            OpenChildForm(hDLD);
            label2.Text = hDLD.Text;
        }

        private void bảngPhụCấpToolStripMenuItem1_Click(object sender, EventArgs e)
        {
            PHUCAP PK = new PHUCAP();
            OpenChildForm(PK);
            label2.Text = PK.Text;
        }

        private void nhânViênPhụCấpToolStripMenuItem_Click(object sender, EventArgs e)
        {
            NVPHUCAP NVPK = new NVPHUCAP();
            OpenChildForm(NVPK);
            label2.Text = NVPK.Text;
        }

        private void bảngCôngToolStripMenuItem_Click(object sender, EventArgs e)
        {
            BANGCONG BC = new BANGCONG();
            OpenChildForm(BC);
            label2.Text = BC.Text;
        }

        private void tăngCaToolStripMenuItem1_Click(object sender, EventArgs e)
        {
            TANGCA TK = new TANGCA();
            OpenChildForm(TK);
            label2.Text = TK.Text;
        }

        private void tínhLươngToolStripMenuItem1_Click(object sender, EventArgs e)
        {
            TINHLUONG TL = new TINHLUONG();
            OpenChildForm(TL);
            label2.Text = TL.Text;
        }

        private void ứngLươngToolStripMenuItem1_Click(object sender, EventArgs e)
        {
            UNGLUONG UL = new UNGLUONG();
            OpenChildForm(UL);
            label2.Text = UL.Text;
        }

        private void thốngKêToolStripMenuItem_Click(object sender, EventArgs e)
        {
            THONGKE TK = new THONGKE();
            OpenChildForm(TK);
            label2.Text = TK.Text;
        }

        private void trợGiúpToolStripMenuItem_Click(object sender, EventArgs e)
        {
            TROGIUP TG = new TROGIUP();
            OpenChildForm(TG);
            label2.Text = TG.Text;
        }

        private void quảnLýTàiKhoảnToolStripMenuItem_Click(object sender, EventArgs e)
        {
            QUANLYTAIKHOAN QLTK = new QUANLYTAIKHOAN();
            OpenChildForm(QLTK);
            label2.Text = QLTK.Text;
        }

        private void homeToolStripMenuItem_Click(object sender, EventArgs e)
        {
            if (currentFormChild != null)
            {
                currentFormChild.Close();

            }
            label2.Text = "HOME";
        }


        private void quảnLýLươngToolStripMenuItem_Click(object sender, EventArgs e)
        {

        }

        private void label2_Click(object sender, EventArgs e)
        {
            
        }

        private void HomeForm_Load(object sender, EventArgs e)
        {
            
        }

        private void danhMụcToolStripMenuItem_Click(object sender, EventArgs e)
        {

        }

        private void pictureBox1_Click(object sender, EventArgs e)
        {
            
        }

        private void đăngXuấtToolStripMenuItem_Click(object sender, EventArgs e)
        {
            DialogResult result = MessageBox.Show("Bạn có chắc chắn muốn đăng xuất không ?", "Xác nhận", MessageBoxButtons.YesNo, MessageBoxIcon.Question);

            if (result == DialogResult.Yes)
            {
                // Đóng form hiện tại
                this.Close();

                // Mở form đăng nhập
                login form1 = new login();

                form1.Show();
            }
        }
    }
}

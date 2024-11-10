using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using static System.Windows.Forms.VisualStyles.VisualStyleElement;

namespace qlnv_admin
{
    public partial class login : Form
    {
        private ErrorProvider errorProvider1;
        private string placeholderText = "user name";
        private string placeholderText1 = "PassWord";
        public login()
        {
            InitializeComponent();
            matkhau.UseSystemPasswordChar = true;
            // Trong nơi tạo đối tượng của HomeForm

            errorProvider1 = new ErrorProvider();
            // Thiết lập placeholder

            ten.Text = placeholderText;
            ten.ForeColor = SystemColors.GrayText;
            // Gắn sự kiện
            ten.Enter += ten_Enter;
            ten.Leave += ten_Leave;
            //
            matkhau.Text = placeholderText1;
            matkhau.ForeColor = SystemColors.GrayText;
            //
            matkhau.Enter += matkhau_Enter;
            matkhau.Leave += matkhau_Leave;

        }
        private void ten_Enter(object sender, EventArgs e)
        {
            // Xóa placeholder khi TextBox được chọn
            if (ten.Text == placeholderText)
            {
                ten.Text = "";
                ten.ForeColor = SystemColors.WindowText; // Màu chữ khi đã nhập


            }
        }

        private void ten_Leave(object sender, EventArgs e)
        {
            // Khôi phục placeholder nếu không có ký tự nào được nhập
            if (string.IsNullOrWhiteSpace(ten.Text) || ten.Text == placeholderText)
            {
                ten.Text = placeholderText;
                ten.ForeColor = SystemColors.GrayText; // Màu chữ mặc định


            }
        }

        private void matkhau_Enter(object sender, EventArgs e)
        {
            // Xóa placeholder khi TextBox được chọn
            if (matkhau.Text == placeholderText1)
            {
                matkhau.Text = "";
                matkhau.ForeColor = SystemColors.WindowText; // Màu chữ khi đã nhập
            }
        }

        private void matkhau_Leave(object sender, EventArgs e)
        {
            // Khôi phục placeholder nếu không có ký tự nào được nhập
            if (string.IsNullOrWhiteSpace(matkhau.Text) || matkhau.Text == placeholderText1)
            {
                matkhau.Text = placeholderText1;
                matkhau.ForeColor = SystemColors.GrayText; // Màu chữ mặc định


            }
        }
       
        public class Account
        {

            public string Username { get; set; }
            public string Password { get; set; }
            public string Role { get; set; } // Ví dụ: 'admin' hoặc 'user'

        }
        public string UserRole { get; private set; }
        List<Account> accounts = new List<Account>
        {
            new Account { Username = "admin", Password = "123", Role = "admin" },
            new Account { Username = "binh_handsome", Password = "123", Role = "admin" },
            new Account { Username = "nv", Password = "123", Role = "user" },
            // Thêm các tài khoản khác nếu cần thiết
        };
        private void button1_Click_1(object sender, EventArgs e)
        {
            string username = ten.Text;
            string password = matkhau.Text;
            errorProvider1.Clear();
            if (ten.Text == placeholderText)
            {
                errorProvider1.SetError(ten,"Vui lòng nhập tên đăng nhập!");
            }
            else if (matkhau.Text == placeholderText1)
            {
                errorProvider1.SetError(matkhau, "Vui lòng nhập mật khẩu!");
            }


            if (ten.Text == placeholderText || matkhau.Text == placeholderText1)
            {
                MessageBox.Show("Vui lòng nhập đủ thông tin", "Thông báo!");
            }
            else
            {
                // tìm kiếm tài khoản từ danh sách 
                Account matchedAccount = accounts.FirstOrDefault(acc => acc.Username == username && acc.Password == password);

                if (matchedAccount != null)
                {


                    // Lấy quyền hạn của tài khoản
                    string role = matchedAccount.Role;

                    // Kiểm tra quyền hạn và thực hiện các hành động tương ứng
                    if (role == "admin")
                    {

                        MessageBox.Show("Đăng nhập thành công", "ADMIN");

                        // Thực hiện hành động cho quyền admin
                        HomeForm form2 = new HomeForm();               
                        form2.Show();
                        

                    }

                    else if (role == "user")
                    {
                        MessageBox.Show("Đăng nhập thành công", "User");

                        UserRole = matchedAccount.Role;
                        // Mở HomeForm



                        HomeForm form2 = new HomeForm();
                        //form2.MainFormReference = this; // Truyền tham chiếu đến MainForm 
                        form2.Show();

                        
                    }

                    // Làm sạch sau khi đăng nhập
                    ten.Text = "";
                    matkhau.Text = "";
                }

                else
                {
                    MessageBox.Show("Tài khoản hoặc mật khẩu không chính xác , vui lòng nhập lại!", "Thông báo!");
                }


            }

        }

        private void checkpass_CheckedChanged(object sender, EventArgs e)
        {
            if (checkpass.Checked)
            {
                // Hiển thị mật khẩu
                matkhau.UseSystemPasswordChar = false;
            }
            else
            {
                // Ẩn mật khẩu
                matkhau.UseSystemPasswordChar = true;
            }
            // Khi checkbox được thay đổi, chuyển đổi giữa PasswordChar và rỗng
            
        }

        

        private void groupBox1_Enter(object sender, EventArgs e)
        {
            
        }

        private void linkLabel1_LinkClicked(object sender, LinkLabelLinkClickedEventArgs e)
        {
            MessageBox.Show("Liên hệ admin bình đẹp trai vừa vừa <3 \n Phone : 0123456789 \n Gmail : Binhking69@gmail.com \n => admin chỉ hơi bịp tí thôi :))", "");
        }
       
        private void login_Load(object sender, EventArgs e)
        {
          
        }


    }
}

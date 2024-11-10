using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Data.SqlClient;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace qlnv_admin
{
    public partial class themnv : Form
    {

        private Timer expandTimer;
        private int targetWidth = 1166; // Kích thước cuối cùng bạn muốn đạt được
        private int targetHeight = 515; // Chiều cao cuối cùng bạn muốn đạt được
        private int currentWidth;
        private int currentHeight;
        private int step = 5; // Số pixel tăng mỗi lần
        private bool expandingWidth = false; // Biến để xác định xem đang mở rộng theo chiều rộng hay chiều cao
        private bool isExpanding = false;
        public themnv()
        {
            InitializeComponent();
            // Khởi tạo Timer
            expandTimer = new Timer();
            expandTimer.Interval = 10; // 10 milliseconds
            expandTimer.Tick += timer1_Tick;

            // Thiết lập kích thước ban đầu của form
            this.Width = 350;
            this.Height = 330;

            // Đăng ký sự kiện Click cho Button
            button1.Click += button1_Click;
            button2.Click += button2_Click;
        }
        private void themnv_Load(object sender, EventArgs e)
        {
          
        }

        private void LoadData(string manv)
        {
            try
            {
                using (SqlConnection connection = SqlConnectionData.connect())
                {
                    connection.Open();

                    string sql = "SELECT * FROM nhanvien WHERE manv = @manv";
                    using (SqlCommand sqlCommand = new SqlCommand(sql, connection))
                    {
                        sqlCommand.Parameters.AddWithValue("@manv", manv);

                        // Sử dụng SqlDataAdapter để lấy dữ liệu từ SqlCommand
                        using (SqlDataAdapter adapter = new SqlDataAdapter(sqlCommand))
                        {
                            // Khởi tạo DataTable để chứa dữ liệu
                            DataTable dataTable = new DataTable();

                            // Đổ dữ liệu từ adapter vào DataTable
                            adapter.Fill(dataTable);

                            // Gán DataTable làm nguồn dữ liệu cho DataGridView
                            dataGridView.DataSource = dataTable;

                            // Tự động điều chỉnh kích thước của các dòng để phù hợp với nội dung
                            dataGridView.AutoResizeRows(DataGridViewAutoSizeRowsMode.AllCells);
                        }
                    }
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("Lỗi khi load dữ liệu: " + ex.Message, "Thông báo");
            }
        }
        public void sqlrefresh()
        {
            tb_manv.Text = "";
            tb_tennv.Text = "";
            tb_gioitinh.Text = "";
            tb_dantoc.Text = "";
            tb_ngaysinh.Value = DateTime.Now;
            tb_diachi.Text = "";
            tb_sdt.Text = "";
            tb_tdhv.Text = "";
            tb_mabp.Text = "";
            tb_macv.Text = "";
        }
        private void button1_Click(object sender, EventArgs e)// nhập  chi tiết
        {
            // Bắt đầu Timer khi nhấn Button1 để mở rộng theo chiều rộng
            if (!isExpanding)
            {
                ExpandForm(this.Width, this.Height, true);
            }
        }
        private void button2_Click(object sender, EventArgs e)// lưu
        {
            // Bắt đầu Timer khi nhấn Button2 để mở rộng theo chiều cao
            if (!isExpanding)
            {
                ExpandForm(this.Width, this.Height, false);
            }

            try
            {
                using (SqlConnection connection = SqlConnectionData.connect())
                {
                    connection.Open();

                    // Kiểm tra mã nhân viên
                    SqlCommand checkCommand = new SqlCommand("SELECT COUNT(*) FROM nhanvien WHERE manv = @manv", connection);
                    checkCommand.Parameters.AddWithValue("@manv", tb_manv.Text);
                    int count = (int)checkCommand.ExecuteScalar();
                    if (count > 0)
                    {
                        MessageBox.Show(" Mã nhân viên đã được thêm vào dữ liệu của bạn .", "Thông báo");
                        return;
                    }
                    if (tb_mabp.Text == "")
                    {
                        MessageBox.Show("Hãy nhập mã bộ phận.", "Thông báo");
                        return;
                    }
                    if (tb_macv.Text == "")
                    {
                        MessageBox.Show("Hãy nhập mã công việc.", "Thông báo");
                        return;
                    }

                    SqlCommand command = connection.CreateCommand();
                    command.CommandText = "INSERT INTO nhanvien VALUES(@manv, @tennv, @GT, @dantoc, @ngaysinh, @diachi, @sdt, @tdhv, @mabp, @macv)";
                    command.Parameters.AddWithValue("@manv", tb_manv.Text);
                    command.Parameters.AddWithValue("@tennv", tb_tennv.Text);
                    command.Parameters.AddWithValue("@GT", tb_gioitinh.Text);
                    command.Parameters.AddWithValue("@dantoc", tb_dantoc.Text);
                    command.Parameters.AddWithValue("@ngaysinh", tb_ngaysinh.Value);
                    command.Parameters.AddWithValue("@diachi", tb_diachi.Text);
                    command.Parameters.AddWithValue("@sdt", tb_sdt.Text);
                    command.Parameters.AddWithValue("@tdhv", tb_tdhv.Text);
                    command.Parameters.AddWithValue("@mabp", tb_mabp.Text);
                    command.Parameters.AddWithValue("@macv", tb_macv.Text);
                    command.ExecuteNonQuery();

                    MessageBox.Show(" Thêm dữ liệu thành công .", "Thông báo");

                    string manv = tb_manv.Text;
                    string sql = "select * from nhanvien where manv = @manv";
                    using (SqlCommand sqlCommand = new SqlCommand(sql, connection))
                    {
                        sqlCommand.Parameters.AddWithValue("@manv", manv);

                        // Sử dụng SqlDataAdapter để lấy dữ liệu từ SqlCommand
                        using (SqlDataAdapter adapter = new SqlDataAdapter(sqlCommand))
                        {
                            // Khởi tạo DataTable để chứa dữ liệu
                            DataTable dataTable = new DataTable();

                            // Đổ dữ liệu từ adapter vào DataTable
                            adapter.Fill(dataTable);

                            // Gán DataTable làm nguồn dữ liệu cho DataGridView
                            dataGridView.DataSource = dataTable;

                            // Tự động điều chỉnh kích thước của các dòng để phù hợp với nội dung
                            dataGridView.AutoResizeRows(DataGridViewAutoSizeRowsMode.AllCells);
                        
                        }
                    }

                    MessageBox.Show("Thêm nhân viên thành công.", "Thông báo");
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("Lỗi: " + ex.Message, "Thông báo");
            }
        }
        private void button5_Click(object sender, EventArgs e)// chức năng sửa
        {
            try
            {
                using (SqlConnection connection = SqlConnectionData.connect())
                {
                    connection.Open();

                    // Kiểm tra xem có mã khoa nào khác với mã khoa hiện tại không nếu có là đang sửa mã khoa 
                    SqlCommand checkCommand = new SqlCommand("SELECT COUNT(*) FROM nhanvien WHERE manv = @manv", connection);
                    checkCommand.Parameters.AddWithValue("@manv", tb_manv.Text);
                    int existingRecords = (int)checkCommand.ExecuteScalar();
                    if (existingRecords > 0)
                    {
                        // Tạo câu lệnh SQL để cập nhật nhân viên theo mã nhân viên
                        string updateQuery = "UPDATE nhanvien SET tennv = @tennv, GT = @GT, dantoc = @dantoc, ngaysinh = @ngaysinh, diachi = @diachi, sdt = @sdt, tdhv = @tdhv, mabp = @mabp, macv = @macv WHERE manv = @manv";
                        SqlCommand updateCommand = new SqlCommand(updateQuery, connection);

                        // Điền thông tin cập nhật vào tham số
                        updateCommand.Parameters.AddWithValue("@manv", tb_manv.Text);
                        updateCommand.Parameters.AddWithValue("@tennv", tb_tennv.Text);
                        updateCommand.Parameters.AddWithValue("@GT", tb_gioitinh.Text);
                        updateCommand.Parameters.AddWithValue("@dantoc", tb_dantoc.Text);
                        updateCommand.Parameters.AddWithValue("@ngaysinh", tb_ngaysinh.Value);
                        updateCommand.Parameters.AddWithValue("@diachi", tb_diachi.Text);
                        updateCommand.Parameters.AddWithValue("@sdt", tb_sdt.Text);
                        updateCommand.Parameters.AddWithValue("@tdhv", tb_tdhv.Text);
                        updateCommand.Parameters.AddWithValue("@mabp", tb_mabp.Text);
                        updateCommand.Parameters.AddWithValue("@macv", tb_macv.Text);

                        // Thực hiện lệnh cập nhật
                        updateCommand.ExecuteNonQuery();

                        // Hiển thị thông báo cập nhật thành công
                        MessageBox.Show("Cập nhật dữ liệu nhân viên thành công.", "Thông báo");

                        LoadData(tb_manv.Text);

                    }

                  
                }

            }

            catch (Exception ex)
            {
                MessageBox.Show("Lỗi: " + ex.Message, "Thông báo");
            }
        }
        private void timer1_Tick(object sender, EventArgs e)
        {
            // Tăng kích thước của form
            if (expandingWidth)
            {
                this.Width += step;
            }
            else
            { 
               
                this.Height += step;
               
            }

            // Kiểm tra xem đã đạt kích thước mong muốn chưa
            if ((expandingWidth && this.Width >= targetWidth) || (!expandingWidth && this.Height >= targetHeight))
            {
                // Dừng Timer khi đã đạt kích thước mong muốn
                expandTimer.Stop();
                isExpanding = false;
            }
           
        }
        private void ExpandForm(int newWidth, int newHeight, bool expandWidth)
        {
            // Thiết lập kích thước ban đầu cho mỗi lần nhấn nút
            this.Width = currentWidth;
            this.Height = currentHeight;

            targetWidth = expandWidth ? targetWidth : currentWidth;
            targetHeight = expandWidth ? currentHeight : targetHeight;

            expandingWidth = expandWidth;
           

            this.currentWidth =1166 ;
            this.currentHeight = 515;
            isExpanding = true;
            // Bắt đầu Timer
            expandTimer.Start();
        }
        private void label1_Click(object sender, EventArgs e)
        {

        }

        private void groupBox1_Enter(object sender, EventArgs e)
        {

        }

        private void groupBox3_Enter(object sender, EventArgs e)
        {

        }

        private void button4_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void button3_Click(object sender, EventArgs e)// CHỨC NĂNG HỦY 
        {
            
            sqlrefresh();
        }

        
    }
}

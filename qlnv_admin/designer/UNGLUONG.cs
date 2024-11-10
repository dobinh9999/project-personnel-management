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
    public partial class UNGLUONG : Form
    {
        public UNGLUONG()
        {
            InitializeComponent();
        }

        private void UNGLUONG_Load(object sender, EventArgs e)
        {
            // TODO: This line of code loads data into the 'quanLyNhanVienv2DataSet2.UNGLUONG' table. You can move, or remove it, as needed.
            // this.uNGLUONGTableAdapter.Fill(this.quanLyNhanVienv2DataSet2.UNGLUONG);
            string sql = "select * from ungluong";
            dataGridView1.DataSource = ketnoi_sql.getData(sql);
        }
        public void loaddata()
        {
            string sql = "select * from ungluong";
            dataGridView1.DataSource = ketnoi_sql.getData(sql);
        }
        public void sqlrefresh()
        {
            tb_maul.Text = "";
            tb_manv.Text = "";
            tb_nam.Text = "";
            tb_thang.Text = "";
            tb_ngay.Text = "";
            tb_tienul.Text = "";
            tb_trangthai.Text = "";
        }
        private void dataGridView1_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            int i = e.RowIndex;
            if (i < 0)
            {
                MessageBox.Show("Vui lòng chọn lại !", "thông báo !");
                return;
            }

            tb_maul.Text = dataGridView1.Rows[i].Cells[0].Value?.ToString();
            tb_manv.Text = dataGridView1.Rows[i].Cells[1].Value?.ToString();
            tb_nam.Text = dataGridView1.Rows[i].Cells[2].Value?.ToString();
            tb_thang.Text = dataGridView1.Rows[i].Cells[3].Value?.ToString();
            tb_ngay.Text = dataGridView1.Rows[i].Cells[4].Value?.ToString();
            tb_tienul.Text = dataGridView1.Rows[i].Cells[5].Value?.ToString();
            tb_trangthai.Text = dataGridView1.Rows[i].Cells[6].Value?.ToString();
        }
        private void button1_Click(object sender, EventArgs e)//  them
        {
            try
            {
                // Kiểm tra xem tất cả các trường bắt buộc có được điền đầy đủ hay không
                if (string.IsNullOrWhiteSpace(tb_maul.Text) || string.IsNullOrWhiteSpace(tb_manv.Text) || string.IsNullOrWhiteSpace(tb_nam.Text)
                    || string.IsNullOrWhiteSpace(tb_thang.Text) || string.IsNullOrWhiteSpace(tb_ngay.Text)
                    || string.IsNullOrWhiteSpace(tb_tienul.Text) || string.IsNullOrWhiteSpace(tb_trangthai.Text))
                {
                    MessageBox.Show("Nhập đầy đủ dữ liệu trước khi thêm.", "Thông báo");
                    return;
                }

                using (SqlConnection connection = SqlConnectionData.connect())
                {
                    connection.Open();

                    // Kiểm tra xem bản ghi với cùng một ID đã tồn tại hay chưa
                    SqlCommand checkCommand = new SqlCommand("SELECT COUNT(*) FROM ungluong WHERE maul = @maul", connection);
                    checkCommand.Parameters.AddWithValue("@maul", tb_maul.Text);
                    int count = (int)checkCommand.ExecuteScalar();
                    if (count > 0)
                    {
                        MessageBox.Show("Mã ưng lương đã tồn tại trong dữ liệu.", "Thông báo");
                        return;
                    }

                    // Thêm bản ghi mới vào bảng UNGLUONG
                    SqlCommand command = connection.CreateCommand();
                    command.CommandText = "INSERT INTO ungluong (maul, manv, nam, thang, ngay, tienul, trangthai) VALUES (@maul, @manv, @nam, @thang, @ngay, @tienul, @trangthai)";
                    command.Parameters.AddWithValue("@maul", tb_maul.Text);
                    command.Parameters.AddWithValue("@manv", tb_manv.Text);
                    command.Parameters.AddWithValue("@nam", tb_nam.Text);
                    command.Parameters.AddWithValue("@thang", tb_thang.Text);
                    command.Parameters.AddWithValue("@ngay", tb_ngay.Text);
                    command.Parameters.AddWithValue("@tienul", tb_tienul.Text);
                    command.Parameters.AddWithValue("@trangthai", tb_trangthai.Text);

                    command.ExecuteNonQuery();

                    // Làm mới dataGridView sau khi thêm một bản ghi mới
                    loaddata();

                    MessageBox.Show("Thêm dữ liệu thành công.", "Thông báo");
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("Lỗi: " + ex.Message, "Thông báo");
            }
        }

        private void button2_Click(object sender, EventArgs e)// sua
        {
            try
            {
                if (string.IsNullOrWhiteSpace(tb_maul.Text))
                {
                    MessageBox.Show("Hãy chọn dữ liệu để sửa.", "Thông báo");
                    return;
                }

                using (SqlConnection connection = SqlConnectionData.connect())
                {
                    connection.Open();

                    // Kiểm tra xem mã ưng lương có tồn tại không
                    SqlCommand checkCommand = new SqlCommand("SELECT COUNT(*) FROM ungluong WHERE maul = @maul", connection);
                    checkCommand.Parameters.AddWithValue("@maul", tb_maul.Text);
                    int count = (int)checkCommand.ExecuteScalar();

                    if (count == 0)
                    {
                        MessageBox.Show("Không sửa mã ưng lương trong dữ liệu.", "Thông báo");
                        return;
                    }

                    // Nếu tồn tại, thực hiện lệnh cập nhật
                    SqlCommand command = connection.CreateCommand();
                    command.CommandText = "UPDATE ungluong SET manv = @manv, nam = @nam, thang = @thang, ngay = @ngay, tienul = @tienul, trangthai = @trangthai WHERE maul = @maul";
                    command.Parameters.AddWithValue("@maul", tb_maul.Text);
                    command.Parameters.AddWithValue("@manv", tb_manv.Text);
                    command.Parameters.AddWithValue("@nam", tb_nam.Text);
                    command.Parameters.AddWithValue("@thang", tb_thang.Text);
                    command.Parameters.AddWithValue("@ngay", tb_ngay.Text);
                    command.Parameters.AddWithValue("@tienul", tb_tienul.Text);
                    command.Parameters.AddWithValue("@trangthai", tb_trangthai.Text);

                    command.ExecuteNonQuery();

                    // Làm mới dataGridView sau khi cập nhật một bản ghi
                    loaddata();

                    MessageBox.Show("Cập nhật dữ liệu thành công.", "Thông báo");
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("Lỗi: " + ex.Message, "Thông báo");
            }
        }

        private void button3_Click(object sender, EventArgs e)// xoa
        {
            try
            {
                if (string.IsNullOrWhiteSpace(tb_maul.Text))
                {
                    MessageBox.Show("Hãy chọn dữ liệu để xóa.", "Thông báo");
                    return;
                }

                using (SqlConnection connection = SqlConnectionData.connect())
                {
                    connection.Open();

                    DialogResult result = MessageBox.Show("Bạn có chắc chắn muốn xóa dữ liệu này?", "Xác nhận", MessageBoxButtons.YesNo, MessageBoxIcon.Question);
                    if (result == DialogResult.Yes)
                    {
                        // Kiểm tra xem mã ưng lương có tồn tại không
                        SqlCommand checkCommand = new SqlCommand("SELECT COUNT(*) FROM ungluong WHERE maul = @maul", connection);
                        checkCommand.Parameters.AddWithValue("@maul", tb_maul.Text);
                        int count = (int)checkCommand.ExecuteScalar();

                        if (count == 0)
                        {
                            MessageBox.Show("Không tìm thấy dữ liệu.", "Thông báo");
                            return;
                        }

                        // Nếu tồn tại, thực hiện lệnh xóa
                        SqlCommand command = connection.CreateCommand();
                        command.CommandText = "DELETE FROM ungluong WHERE maul = @maul";
                        command.Parameters.AddWithValue("@maul", tb_maul.Text);

                        command.ExecuteNonQuery();

                        // Làm mới dataGridView sau khi xóa một bản ghi
                        loaddata();

                        // Xóa các ô đầu vào
                        sqlrefresh();

                        MessageBox.Show("Xóa dữ liệu thành công.", "Thông báo");
                    }
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("Lỗi: " + ex.Message, "Thông báo");
            }
        }

        private void button4_Click(object sender, EventArgs e)// moi
        {
            sqlrefresh();
        }

        private void button8_Click(object sender, EventArgs e)// loaddata
        {
            loaddata();
        }

        private void dataGridView1_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {
         
        }

        private void button7_Click(object sender, EventArgs e)// tìm kiếm
        {
            try
            {
                using (SqlConnection connection = SqlConnectionData.connect())
                {
                    connection.Open();

                    // Kiểm tra xem mã ứng lương có tồn tại không
                    SqlCommand checkCommand = new SqlCommand("SELECT COUNT(*) FROM ungluong WHERE maul = @maul", connection);
                    checkCommand.Parameters.AddWithValue("@maul", tb_timkiem.Text);
                    int count = (int)checkCommand.ExecuteScalar();

                    if (count > 0)
                    {
                        // Nếu tồn tại, thực hiện lệnh SELECT để lấy thông tin và hiển thị trong dataGridView
                        SqlCommand selectCommand = new SqlCommand("SELECT * FROM ungluong WHERE maul = @maul", connection);
                        selectCommand.Parameters.AddWithValue("@maul", tb_timkiem.Text);

                        SqlDataAdapter adapter = new SqlDataAdapter(selectCommand);
                        DataTable dataTable = new DataTable();
                        adapter.Fill(dataTable);

                        // Hiển thị kết quả trong dataGridView1
                        dataGridView1.DataSource = dataTable;

                        MessageBox.Show("Tìm kiếm thành công.", "Thông báo");
                    }
                    else
                    {
                        MessageBox.Show("Không tìm thấy mã ứng lương.", "Thông báo");
                        return;
                    }
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("Lỗi: " + ex.Message, "Thông báo");
            }
        }
    }
}

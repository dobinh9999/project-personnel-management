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
    public partial class PHUCAP : Form
    {
        public PHUCAP()
        {
            InitializeComponent();
        }

        private void groupBox2_Enter(object sender, EventArgs e)
        {

        }

        private void label2_Click(object sender, EventArgs e)
        {

        }

        private void PHUCAP_Load(object sender, EventArgs e)
        {
            // TODO: This line of code loads data into the 'quanLyNhanVienv2DataSet2.PHUCAP' table. You can move, or remove it, as needed.
            //this.pHUCAPTableAdapter.Fill(this.quanLyNhanVienv2DataSet2.PHUCAP);
            string sql = "select * from phucap";
            dataGridView1.DataSource = ketnoi_sql.getData(sql);
        }
        public void loaddata()
        {
            string sql = "select * from phucap";
            dataGridView1.DataSource = ketnoi_sql.getData(sql);
        }
        public void sqlrefresh()
        {
            tb_mapc.Text = "";
            tb_nd.Text = "";
            tb_tienpc.Text = "";
        }

        private void dataGridView1_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            int i = e.RowIndex;
            if (i < 0)
            {
                MessageBox.Show("Vui lòng chọn lại !", "thông báo !");
                return;
            }

            tb_mapc.Text = dataGridView1.Rows[i].Cells[0].Value?.ToString();
            tb_nd.Text = dataGridView1.Rows[i].Cells[1].Value?.ToString();
            tb_tienpc.Text = dataGridView1.Rows[i].Cells[2].Value?.ToString();
        }

        private void button1_Click(object sender, EventArgs e)//them
        {
            try
            {
                // Kiểm tra xem có ô TextBox nào trống không
                if (string.IsNullOrWhiteSpace(tb_mapc.Text) || string.IsNullOrWhiteSpace(tb_nd.Text)
                    || string.IsNullOrWhiteSpace(tb_tienpc.Text))
                {
                    MessageBox.Show("Nhập đầy đủ dữ liệu trước khi thêm.", "Thông báo");
                    return;
                }

                using (SqlConnection connection = SqlConnectionData.connect())
                {
                    connection.Open();

                    // Kiểm tra mã khen thưởng
                    SqlCommand checkCommand = new SqlCommand("SELECT COUNT(*) FROM phucap WHERE mapc = @mapc", connection);
                    checkCommand.Parameters.AddWithValue("@mapc", tb_mapc.Text);
                    int count = (int)checkCommand.ExecuteScalar();

                    if (count > 0)
                    {
                        MessageBox.Show("Mã phụ cấp đã tồn tại trong dữ liệu.", "Thông báo");
                        return;
                    }

                    SqlCommand command = connection.CreateCommand();
                    command.CommandText = "INSERT INTO phucap VALUES(  @mapc,@nd,@tienpc)";

                    command.Parameters.AddWithValue("@mapc", tb_mapc.Text);
                    command.Parameters.AddWithValue("@nd", tb_nd.Text);
                    command.Parameters.AddWithValue("@tienpc", tb_tienpc.Text);


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

        private void button2_Click(object sender, EventArgs e)//sua
        {
            try
            {
                if (string.IsNullOrWhiteSpace(tb_mapc.Text))
                {
                    MessageBox.Show(" Hãy chọn dữ liệu để sửa . ", "Thông báo");
                    return;
                }
                using (SqlConnection connection = SqlConnectionData.connect())
                {
                    connection.Open();

                    // Kiểm tra xem mã khen thưởng có tồn tại không
                    SqlCommand checkCommand = new SqlCommand("SELECT COUNT(*) FROM phucap WHERE mapc = @mapc", connection);
                    checkCommand.Parameters.AddWithValue("@mapc", tb_mapc.Text);
                    int count = (int)checkCommand.ExecuteScalar();

                    if (count == 0)
                    {
                        MessageBox.Show(" Không sửa mã phụ cấp trong dữ liệu.", "Thông báo");
                        return;
                    }

                    // Nếu tồn tại, thực hiện lệnh cập nhật
                    SqlCommand command = connection.CreateCommand();
                    command.CommandText = "UPDATE phucap SET noidung = @nd, tienpc = @tienpc WHERE mapc = @mapc";
                    command.Parameters.AddWithValue("@mapc", tb_mapc.Text);
                    command.Parameters.AddWithValue("@nd", tb_nd.Text);
                    command.Parameters.AddWithValue("@tienpc", tb_tienpc.Text);


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

        private void button3_Click(object sender, EventArgs e)//xoa
        {
            try
            {
                if (string.IsNullOrWhiteSpace(tb_mapc.Text))
                {
                    MessageBox.Show(" Hãy chọn dữ liệu để xóa. ", "Thông báo");
                    return;
                }
                using (SqlConnection connection = SqlConnectionData.connect())
                {
                    connection.Open();

                    DialogResult result = MessageBox.Show("Bạn có chắc chắn muốn xóa dữ liệu này?", "Xác nhận", MessageBoxButtons.YesNo, MessageBoxIcon.Question);
                    if (result == DialogResult.Yes)
                    {
                        // Kiểm tra xem mã bộ phận có tồn tại không
                        SqlCommand checkCommand = new SqlCommand("SELECT COUNT(*) FROM phucap WHERE mapc = @mapc", connection);
                        checkCommand.Parameters.AddWithValue("@mapc", tb_mapc.Text);
                        int count = (int)checkCommand.ExecuteScalar();

                        if (count == 0)
                        {
                            MessageBox.Show("Không tìm thấy dữ liệu.", "Thông báo");
                            return;
                        }

                        // Nếu tồn tại, thì thực hiện lệnh xóa
                        SqlCommand command = connection.CreateCommand();
                        command.CommandText = "DELETE FROM phucap WHERE mapc = @mapc";
                        command.Parameters.AddWithValue("@mapc", tb_mapc.Text);

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

        private void button6_Click(object sender, EventArgs e)//moi
        {
            sqlrefresh();
        }

        private void button7_Click(object sender, EventArgs e)// loaddata
        {
            loaddata();
        }

        private void button8_Click(object sender, EventArgs e)// tìm kiếm
        {
            try
            {
                using (SqlConnection connection = SqlConnectionData.connect())
                {
                    connection.Open();

                    // Kiểm tra xem mã phụ cấp có tồn tại không
                    SqlCommand checkCommand = new SqlCommand("SELECT COUNT(*) FROM phucap WHERE mapc = @mapc", connection);
                    checkCommand.Parameters.AddWithValue("@mapc", tb_timkiem.Text);
                    int count = (int)checkCommand.ExecuteScalar();

                    if (count > 0)
                    {
                        // Nếu tồn tại, thực hiện lệnh SELECT để lấy thông tin và hiển thị trong dataGridView
                        SqlCommand selectCommand = new SqlCommand("SELECT * FROM phucap WHERE mapc = @mapc", connection);
                        selectCommand.Parameters.AddWithValue("@mapc", tb_timkiem.Text);

                        SqlDataAdapter adapter = new SqlDataAdapter(selectCommand);
                        DataTable dataTable = new DataTable();
                        adapter.Fill(dataTable);

                        // Hiển thị kết quả trong dataGridView1
                        dataGridView1.DataSource = dataTable;

                        MessageBox.Show("Tìm kiếm thành công.", "Thông báo");
                    }
                    else
                    {
                        MessageBox.Show("Không tìm thấy mã phụ cấp.", "Thông báo");
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

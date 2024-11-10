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
using static System.Windows.Forms.VisualStyles.VisualStyleElement.Rebar;

namespace qlnv_admin
{
    public partial class HDLD : Form
    {
        public HDLD()
        {
            InitializeComponent();
        }

        private void groupBox3_Enter(object sender, EventArgs e)
        {

        }

        private void HDLD_Load(object sender, EventArgs e)
        {
            // TODO: This line of code loads data into the 'quanLyNhanVienv2DataSet2.HDLD' table. You can move, or remove it, as needed.
            //this.hDLDTableAdapter.Fill(this.quanLyNhanVienv2DataSet2.HDLD);
            string sql = "select * from HDLD";
            dataGridView1.DataSource = ketnoi_sql.getData(sql);
        }
        public void loaddata()
        {
            string sql = "select * from HDLD";
            dataGridView1.DataSource = ketnoi_sql.getData(sql);
        }
        public void sqlrefresh()
        {
            tb_mahd.Text = "";
            tb_manv.Text = "";
            tb_loaihd.Text = "";
            tb_thoihan.Text = "";
            tb_ngayky.Text = "";
            tb_ngaybatdau.Text = "";
            tb_ngayketthuc.Text = "";
            tb_heso.Text = "";
            tb_lcb.Text = "";
        }
        private void dataGridView1_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            int i = e.RowIndex;
            if (i < 0)
            {
                MessageBox.Show("Vui lòng chọn lại !", "thông báo !");
                return;
            }

            tb_mahd.Text = dataGridView1.Rows[i].Cells[0].Value?.ToString();
            tb_manv.Text = dataGridView1.Rows[i].Cells[1].Value?.ToString();
            tb_loaihd.Text = dataGridView1.Rows[i].Cells[2].Value?.ToString();
            tb_thoihan.Text = dataGridView1.Rows[i].Cells[3].Value?.ToString();
            tb_ngayky.Text = dataGridView1.Rows[i].Cells[4].Value?.ToString();
            tb_ngaybatdau.Text = dataGridView1.Rows[i].Cells[5].Value?.ToString();
            tb_ngayketthuc.Text = dataGridView1.Rows[i].Cells[6].Value?.ToString();           
            tb_heso.Text = dataGridView1.Rows[i].Cells[7].Value?.ToString();
            tb_lcb.Text = dataGridView1.Rows[i].Cells[8].Value?.ToString();        
        }

        private void button1_Click(object sender, EventArgs e)// them
        {
            try
            {
                // Kiểm tra xem có ô TextBox nào trống không
                if (string.IsNullOrWhiteSpace(tb_mahd.Text) || string.IsNullOrWhiteSpace(tb_manv.Text)
                    || string.IsNullOrWhiteSpace(tb_loaihd.Text) || string.IsNullOrWhiteSpace(tb_thoihan.Text)
                    || string.IsNullOrWhiteSpace(tb_ngayky.Text) || string.IsNullOrWhiteSpace(tb_ngaybatdau.Text)
                     || string.IsNullOrWhiteSpace(tb_ngayketthuc.Text) || string.IsNullOrWhiteSpace(tb_heso.Text)
                      || string.IsNullOrWhiteSpace(tb_lcb.Text))
                {
                    MessageBox.Show("Nhập đầy đủ dữ liệu trước khi thêm.", "Thông báo");
                    return;
                }

                using (SqlConnection connection = SqlConnectionData.connect())
                {
                    connection.Open();

                    // Kiểm tra mã khen thưởng
                    SqlCommand checkCommand = new SqlCommand("SELECT COUNT(*) FROM HDLD WHERE mahd= @mahd", connection);
                    checkCommand.Parameters.AddWithValue("@mahd", tb_mahd.Text);
                    int count = (int)checkCommand.ExecuteScalar();

                    if (count > 0)
                    {
                        MessageBox.Show("Mã hợp đồng đã tồn tại trong dữ liệu.", "Thông báo");
                        return;
                    }

                    SqlCommand command = connection.CreateCommand();
                    command.CommandText = "INSERT INTO hdld VALUES(@mahd, @manv, @loaihd, @thoihan, @ngayky, @ngaybatdau, @ngayketthuc , @heso, @lcb)";
                    command.Parameters.AddWithValue("@mahd", tb_mahd.Text);
                    command.Parameters.AddWithValue("@manv", tb_manv.Text);
                    command.Parameters.AddWithValue("@loaihd", tb_loaihd.Text);
                    command.Parameters.AddWithValue("@thoihan", tb_thoihan.Text);
                    command.Parameters.AddWithValue("@ngayky", tb_ngayky.Value);
                    command.Parameters.AddWithValue("@ngaybatdau", tb_ngaybatdau.Value);
                    command.Parameters.AddWithValue("@ngayketthuc", tb_ngayketthuc.Value);
                    command.Parameters.AddWithValue("@heso", tb_heso.Text);
                    command.Parameters.AddWithValue("@lcb", tb_lcb.Text);

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
                if (string.IsNullOrWhiteSpace(tb_mahd.Text))
                {
                    MessageBox.Show(" Hãy chọn dữ liệu để sửa . ", "Thông báo");
                    return;
                }
                using (SqlConnection connection = SqlConnectionData.connect())
                {
                    connection.Open();

                    // Kiểm tra xem mã khen thưởng có tồn tại không
                    SqlCommand checkCommand = new SqlCommand("SELECT COUNT(*) FROM hdld WHERE mahd = @mahd", connection);
                    checkCommand.Parameters.AddWithValue("@mahd", tb_mahd.Text);
                    int count = (int)checkCommand.ExecuteScalar();

                    if (count == 0)
                    {
                        MessageBox.Show(" Không sửa mã hợp đồng trong dữ liệu.", "Thông báo");
                        return;
                    }

                    // Nếu tồn tại, thực hiện lệnh cập nhật
                    SqlCommand command = connection.CreateCommand();
                    command.CommandText = "UPDATE hdld SET manv = @manv, loaihd = @loaihd, thoihan = @thoihan, ngayky = @ngayky, ngaybatdau = @ngaybatdau, ngayketthuc = @ngayketthuc, heso = @heso, lcb = @lcb WHERE mahd = @mahd";
                    command.Parameters.AddWithValue("@mahd", tb_mahd.Text);
                    command.Parameters.AddWithValue("@manv", tb_manv.Text);
                    command.Parameters.AddWithValue("@loaihd", tb_loaihd.Text);
                    command.Parameters.AddWithValue("@thoihan", tb_thoihan.Text);
                    command.Parameters.AddWithValue("@ngayky", tb_ngayky.Value);
                    command.Parameters.AddWithValue("@ngaybatdau", tb_ngaybatdau.Value);
                    command.Parameters.AddWithValue("@ngayketthuc", tb_ngayketthuc.Value);
                    command.Parameters.AddWithValue("@heso", tb_heso.Text);
                    command.Parameters.AddWithValue("@lcb", tb_lcb.Text);

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
                if (string.IsNullOrWhiteSpace(tb_mahd.Text))
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
                        SqlCommand checkCommand = new SqlCommand("SELECT COUNT(*) FROM hdld WHERE mahd = @mahd", connection);
                        checkCommand.Parameters.AddWithValue("@mahd", tb_mahd.Text);
                        int count = (int)checkCommand.ExecuteScalar();

                        if (count == 0)
                        {
                            MessageBox.Show("Không tìm thấy dữ liệu.", "Thông báo");
                            return;
                        }

                        // Nếu tồn tại, thì thực hiện lệnh xóa
                        SqlCommand command = connection.CreateCommand();
                        command.CommandText = "DELETE FROM hdld WHERE mahd = @mahd";
                        command.Parameters.AddWithValue("@mahd", tb_mahd.Text);

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

        private void button6_Click(object sender, EventArgs e)// moi
        {
            sqlrefresh();
        }

        private void button7_Click(object sender, EventArgs e)// loaddata
        {
            loaddata();
        }

        private void button8_Click(object sender, EventArgs e)// tim kiếm
        {
            try
            {
                using (SqlConnection connection = SqlConnectionData.connect())
                {
                    connection.Open();

                    // Kiểm tra xem mã hợp đồng lao động có tồn tại không
                    SqlCommand checkCommand = new SqlCommand("SELECT COUNT(*) FROM hdld WHERE mahd = @mahd", connection);
                    checkCommand.Parameters.AddWithValue("@mahd", tb_timkiem.Text);
                    int count = (int)checkCommand.ExecuteScalar();

                    if (count > 0)
                    {
                        // Nếu tồn tại, thực hiện lệnh SELECT để lấy thông tin và hiển thị trong dataGridView
                        SqlCommand selectCommand = new SqlCommand("SELECT * FROM hdld WHERE mahd = @mahd", connection);
                        selectCommand.Parameters.AddWithValue("@mahd", tb_timkiem.Text);

                        SqlDataAdapter adapter = new SqlDataAdapter(selectCommand);
                        DataTable dataTable = new DataTable();
                        adapter.Fill(dataTable);

                        // Hiển thị kết quả trong dataGridView1
                        dataGridView1.DataSource = dataTable;

                        MessageBox.Show("Tìm kiếm thành công.", "Thông báo");
                    }
                    else
                    {
                        MessageBox.Show("Không tìm thấy mã hợp đồng lao động.", "Thông báo");
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

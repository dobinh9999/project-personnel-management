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
    public partial class BANGCONG : Form
    {
        public BANGCONG()
        {
            InitializeComponent();
        }

        private void groupBox2_Enter(object sender, EventArgs e)
        {

        }

        private void BANGCONG_Load(object sender, EventArgs e)
        {
            // TODO: This line of code loads data into the 'quanLyNhanVienv2DataSet.BANGCONG' table. You can move, or remove it, as needed.
            //this.bANGCONGTableAdapter.Fill(this.quanLyNhanVienv2DataSet.BANGCONG);
            // TODO: This line of code loads data into the 'quanLyNhanVienv2DataSet2.BANGCONG' table. You can move, or remove it, as needed.
            //this.bANGCONGTableAdapter.Fill(this.quanLyNhanVienv2DataSet2.BANGCONG);
            string sql = "select * from bangcong";
            dataGridView1.DataSource = ketnoi_sql.getData(sql);
        }
        public void loaddata()
        {
            string sql = "select * from bangcong";
            dataGridView1.DataSource = ketnoi_sql.getData(sql);
        }
        public void sqlrefresh()
        {
            tb_mabc.Text = "";
            tb_manv.Text = "";
            
            
            tb_ngay.Text = "";
            tb_giovao.Text = "";
            tb_giora.Text = "";
            
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

            tb_mabc.Text = dataGridView1.Rows[i].Cells[0].Value?.ToString();
            tb_manv.Text = dataGridView1.Rows[i].Cells[1].Value?.ToString();          
            tb_ngay.Text = dataGridView1.Rows[i].Cells[2].Value?.ToString();
            tb_giovao.Text = dataGridView1.Rows[i].Cells[3].Value?.ToString();
            tb_giora.Text = dataGridView1.Rows[i].Cells[4].Value?.ToString();
            tb_trangthai.Text = dataGridView1.Rows[i].Cells[5].Value?.ToString();
        }

        private void button1_Click(object sender, EventArgs e)// them
        {

            try
            {
                // Kiểm tra xem có ô TextBox nào trống không
                if (string.IsNullOrWhiteSpace(tb_manv.Text) || string.IsNullOrWhiteSpace(tb_mabc.Text) 
                    || string.IsNullOrWhiteSpace(tb_ngay.Text) || string.IsNullOrWhiteSpace(tb_giora.Text) 
                    || string.IsNullOrWhiteSpace(tb_giovao.Text) || string.IsNullOrWhiteSpace(tb_trangthai.Text))
                {
                    MessageBox.Show("Nhập đầy đủ dữ liệu trước khi thêm.", "Thông báo");
                    return;
                }

                using (SqlConnection connection = SqlConnectionData.connect())
                {
                    connection.Open();

                    // Kiểm tra mã khen thưởng
                    SqlCommand checkCommand = new SqlCommand("SELECT COUNT(*) FROM bangcong WHERE mabc = @mabc", connection);
                    checkCommand.Parameters.AddWithValue("@mabc", tb_manv.Text);
                    int count = (int)checkCommand.ExecuteScalar();

                    if (count > 0)
                    {
                        MessageBox.Show("Mã kỷ luật đã tồn tại trong dữ liệu.", "Thông báo");
                        return;
                    }

                    SqlCommand command = connection.CreateCommand();
                    command.CommandText = "INSERT INTO bangcong (mabc,manv,ngaycong, giovao, giora, trangthai) VALUES (@mabc,@manv, @ngay, @giovao, @giora, @trangthai)";
                    command.Parameters.AddWithValue("@mabc", tb_mabc.Text);
                    command.Parameters.AddWithValue("@manv", tb_manv.Text);
                    command.Parameters.AddWithValue("@ngay", tb_ngay.Value);
                    command.Parameters.AddWithValue("@giovao", tb_giovao.Value);                 
                    command.Parameters.AddWithValue("@giora", tb_giora.Value);                    
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
                if (string.IsNullOrWhiteSpace(tb_manv.Text))
                {
                    MessageBox.Show(" Hãy chọn dữ liệu để sửa . ", "Thông báo");
                    return;
                }
                using (SqlConnection connection = SqlConnectionData.connect())
                {
                    connection.Open();

                    // Kiểm tra xem mã khen thưởng có tồn tại không
                    SqlCommand checkCommand = new SqlCommand("SELECT COUNT(*) FROM bangcong WHERE manv = @manv", connection);
                    checkCommand.Parameters.AddWithValue("@manv", tb_manv.Text);
                    int count = (int)checkCommand.ExecuteScalar();

                    if (count == 0)
                    {
                        MessageBox.Show(" Không sửa mã bảng công trong dữ liệu.", "Thông báo");
                        return;
                    }

                    // Nếu tồn tại, thực hiện lệnh cập nhật
                    SqlCommand command = connection.CreateCommand();
                    command.CommandText = "UPDATE bangcong SET manv = @manv, ngaycong = @ngay, giovao = @giovao,giora = @giora, trangthai = @trangthai WHERE mabc = @mabc";
                    command.Parameters.AddWithValue("@mabc", tb_mabc.Text);
                    command.Parameters.AddWithValue("@manv", tb_manv.Text);                 
                    command.Parameters.AddWithValue("@ngay", tb_ngay.Value);
                    command.Parameters.AddWithValue("@giovao", tb_giovao.Value);
                    command.Parameters.AddWithValue("@giora", tb_giora.Value);                  
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
                if (string.IsNullOrWhiteSpace(tb_manv.Text))
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
                        SqlCommand checkCommand = new SqlCommand("SELECT COUNT(*) FROM bangcong WHERE mabc = @mabc", connection);
                        checkCommand.Parameters.AddWithValue("@mabc", tb_mabc.Text);
                        int count = (int)checkCommand.ExecuteScalar();

                        if (count == 0)
                        {
                            MessageBox.Show("Không tìm thấy dữ liệu.", "Thông báo");
                            return;
                        }

                        // Nếu tồn tại, thì thực hiện lệnh xóa
                        SqlCommand command = connection.CreateCommand();
                        command.CommandText = "DELETE FROM bangcong WHERE mabc = @mabc";
                        command.Parameters.AddWithValue("@mabc", tb_mabc.Text);

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

        private void button4_Click(object sender, EventArgs e)
        {
            sqlrefresh();
        }

        private void button8_Click(object sender, EventArgs e)
        {
            loaddata();
        }

        private void button7_Click(object sender, EventArgs e)// tìm kiếm
        {
            try
            {
                using (SqlConnection connection = SqlConnectionData.connect())
                {
                    connection.Open();

                    // Kiểm tra xem mã bảng công có tồn tại không
                    SqlCommand checkCommand = new SqlCommand("SELECT COUNT(*) FROM bangcong WHERE mabc = @mabc", connection);
                    checkCommand.Parameters.AddWithValue("@mabc", tb_timkiem.Text);
                    int count = (int)checkCommand.ExecuteScalar();

                    if (count > 0)
                    {
                        // Nếu tồn tại, thực hiện lệnh SELECT để lấy thông tin và hiển thị trong dataGridView
                        SqlCommand selectCommand = new SqlCommand("SELECT * FROM bangcong WHERE mabc = @mabc", connection);
                        selectCommand.Parameters.AddWithValue("@mabc", tb_timkiem.Text);

                        SqlDataAdapter adapter = new SqlDataAdapter(selectCommand);
                        DataTable dataTable = new DataTable();
                        adapter.Fill(dataTable);

                        // Hiển thị kết quả trong dataGridView1
                        dataGridView1.DataSource = dataTable;

                        MessageBox.Show("Tìm kiếm thành công.", "Thông báo");
                    }
                    else
                    {
                        MessageBox.Show("Không tìm thấy mã bảng công.", "Thông báo");
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

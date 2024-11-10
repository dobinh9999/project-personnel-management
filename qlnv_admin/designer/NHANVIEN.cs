using DocumentFormat.OpenXml.Drawing;
using OfficeOpenXml;
using OfficeOpenXml.Style;
using System;
using System.Collections;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Data.SqlClient;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;


namespace qlnv_admin
{
    public partial class NHANVIEN : Form
    {

        public NHANVIEN()
        {
            InitializeComponent();    
        }

       
        private void NHANVIEN_Load(object sender, EventArgs e)
        {
            // TODO: This line of code loads data into the 'quanLyNhanVienv2DataSet2.NHANVIEN' table. You can move, or remove it, as needed.
            //this.nHANVIENTableAdapter.Fill(this.quanLyNhanVienv2DataSet2.NHANVIEN);
            string sql = "select * from nhanvien";
            dataGridView.DataSource = ketnoi_sql.getData(sql);

           
        }
        public void load()
        {
            string sql = "select * from nhanvien";
            dataGridView.DataSource = ketnoi_sql.getData(sql);
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
        private void dataGridView_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            int i = e.RowIndex;
            if (i < 0)
            {
                MessageBox.Show("Vui lòng chọn lại !", "thông báo !");
                return;
            }

            tb_manv.Text = dataGridView.Rows[i].Cells[0].Value?.ToString();
            tb_tennv.Text = dataGridView.Rows[i].Cells[1].Value?.ToString();
            tb_gioitinh.Text = dataGridView.Rows[i].Cells[2].Value?.ToString();
            tb_dantoc.Text = dataGridView.Rows[i].Cells[3].Value?.ToString();
            tb_ngaysinh.Text = dataGridView.Rows[i].Cells[4].Value?.ToString();
            tb_diachi.Text = dataGridView.Rows[i].Cells[5].Value?.ToString();
            tb_sdt.Text = dataGridView.Rows[i].Cells[6].Value?.ToString();
            tb_tdhv.Text = dataGridView.Rows[i].Cells[7].Value?.ToString();
            tb_mabp.Text = dataGridView.Rows[i].Cells[8].Value?.ToString();
            tb_macv.Text = dataGridView.Rows[i].Cells[9].Value?.ToString();
        }
         private void button3_Click(object sender, EventArgs e)// cn thêm 
        {
            themnv themnv = new themnv();
            themnv.Show();
            
        }
        private void groupBox1_Enter(object sender, EventArgs e)
        {

        }

        private void textBox1_TextChanged(object sender, EventArgs e)
        {

        }

        private void label7_Click(object sender, EventArgs e)
        {

        }



       

        private void button4_Click(object sender, EventArgs e)// chức năng sửa 
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

                        // Load lại dữ liệu vào DataGridView
                        load();
                    }
                    else
                    {
                        // Hiển thị thông báo chọn dữ liệu cần sửa
                        MessageBox.Show("Vui lòng chọn dữ liệu nhân viên .", "Thông báo");
                    }
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("Lỗi: " + ex.Message, "Thông báo");
            }
        }

        private void button8_Click(object sender, EventArgs e)// reset textbox
        {
            // xóa dữ liệu trong textbox  
            sqlrefresh();
        }

        private string manvToDelete;
        private DataGridView dataGridViewToUpdate;
        private void button5_Click(object sender, EventArgs e)// chức năng xóa
        {


            DialogResult result = MessageBox.Show("Bạn có chắc chắn muốn xóa dữ liệu này?", "Xác nhận", MessageBoxButtons.YesNo, MessageBoxIcon.Question);
            if (result == DialogResult.Yes)
            {
                // Kiểm tra xem đã chọn dòng nào để xóa chưa
                if (!string.IsNullOrEmpty(tb_manv.Text))
                {
                    // Lấy mã nhân viên từ TextBox
                    manvToDelete = tb_manv.Text;

                    // khởi tạo DataGridView
                    DataGridView data = new DataGridView();

                    // Gọi phương thức xóa               
                    // Tạo một đối tượng detlete
                    delete delete1 = new delete();
                    delete1.XoaNhanVien(manvToDelete, data);

                    // xóa dữ liệu trong các textbox
                    sqlrefresh();


                    // load lại dữ liệu 
                    load();

                }
                else
                {
                    MessageBox.Show("Vui lòng chọn nhân viên cần xóa.", "Thông báo");
                }
            }
        }
        private void button2_Click(object sender, EventArgs e)
        {
            load();
        }

        private void button6_Click(object sender, EventArgs e)// thêm trực tiếp

        {
           
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
                            MessageBox.Show("Mã nhân viên đã tồn tại trong dữ liệu .", "Thông báo");
                            return;
                        }

                        SqlCommand command = connection.CreateCommand();
                        command.CommandText = "INSERT INTO nhanvien VALUES(@manv, @tennv, @gioitinh, @dantoc, @ngaysinh, @diachi, @sdt, @tdhv, @mabp, @macv)";
                        command.Parameters.AddWithValue("@manv", tb_manv.Text);
                        command.Parameters.AddWithValue("@tennv", tb_tennv.Text);
                        command.Parameters.AddWithValue("@gioitinh", tb_gioitinh.Text);
                        command.Parameters.AddWithValue("@dantoc", tb_dantoc.Text);
                        command.Parameters.AddWithValue("@ngaysinh", tb_ngaysinh.Value);
                        command.Parameters.AddWithValue("@diachi", tb_diachi.Text);
                        command.Parameters.AddWithValue("@sdt", tb_sdt.Text);
                        command.Parameters.AddWithValue("@tdhv", tb_tdhv.Text);
                        command.Parameters.AddWithValue("@mabp", tb_mabp.Text);
                        command.Parameters.AddWithValue("@macv", tb_macv.Text);
                        command.ExecuteNonQuery();

                        // Làm mới dataGridView sau khi thêm một bản ghi mới
                        string selectQuery = "SELECT * FROM nhanvien";
                        dataGridView.DataSource = ketnoi_sql.getData(selectQuery);

                        // Xóa các ô đầu vào
                        sqlrefresh();

                        MessageBox.Show("Thêm nhân viên thành công.", "Thông báo");
                    }
                }
                catch (Exception ex)
                {
                    MessageBox.Show("Lỗi: " + ex.Message, "Thông báo");
                }
            }

        private void button7_Click(object sender, EventArgs e)// excel
        {
            try
            {
                using (SaveFileDialog saveFileDialog = new SaveFileDialog())
                {
                    saveFileDialog.Filter = "Excel Files (*.xlsx)|*.xlsx";
                    saveFileDialog.FileName = "output_DanhSachNhanVien.xlsx";
                    if (saveFileDialog.ShowDialog() == DialogResult.OK)
                    {
                        FileInfo excelFile = new FileInfo(saveFileDialog.FileName);
                        using (ExcelPackage package = new ExcelPackage(excelFile))
                        {
                            ExcelWorksheet worksheet = package.Workbook.Worksheets.Add("DANH SÁCH NHÂN VIÊN");

                            // Thêm tiêu đề "Danh sách nhân viên"
                            worksheet.Cells["A1"].Value = "DANH SÁCH NHÂN VIÊN";
                            worksheet.Cells["A2"].Value = "Thông tin chi tiết";
                            worksheet.Cells["A1"].Style.Font.Size = 25; // Đặt kích thước font cho tiêu đề
                            worksheet.Cells["A2"].Style.Font.Size = 20; // Đặt kích thước font cho tiêu đề
                            worksheet.Cells["A1:J1"].Merge = true; // Merge các ô từ A1 đến D1
                            worksheet.Cells["A2:J2"].Merge = true; // Merge các ô từ A1 đến D1                          
                            worksheet.Cells["A3:J3"].Style.Fill.PatternType = ExcelFillStyle.Solid;
                            worksheet.Cells["A3:J3"].Style.Fill.BackgroundColor.SetColor(System.Drawing.Color.Yellow);
                            worksheet.Cells["A3:J3"].Style.Font.Size = 12; // Đặt kích thước font cho tiêu đề         
                            worksheet.Cells["A1"].Style.Font.Bold = true; // Đặt đậm cho tiêu đề
                            worksheet.Cells["A1"].Style.HorizontalAlignment = OfficeOpenXml.Style.ExcelHorizontalAlignment.Center; // Căn giữa tiêu đề
                            worksheet.Cells["A2"].Style.HorizontalAlignment = OfficeOpenXml.Style.ExcelHorizontalAlignment.Center; // Căn giữa tiêu đề

                            // Tạo hàng ngang
                            worksheet.Cells["A1:J1"].Style.Border.Bottom.Style = OfficeOpenXml.Style.ExcelBorderStyle.Thin; // Đặt kiểu đường viền cho hàng ngang
                            worksheet.Cells["A2:J2"].Style.Border.Bottom.Style = OfficeOpenXml.Style.ExcelBorderStyle.Thin; // Đặt kiểu đường viền cho hàng ngang
                            worksheet.Cells["A3:J3"].Style.Border.Bottom.Style = OfficeOpenXml.Style.ExcelBorderStyle.Thin; // Đặt kiểu đường viền cho hàng ngang                          

                            // tạo hàng dọc
                            worksheet.Cells["A1:A3"].Style.Border.Right.Style = OfficeOpenXml.Style.ExcelBorderStyle.Thin; // Đặt kiểu đường viền cho hàng dọc
                            worksheet.Cells["A1:J3"].Style.Border.Right.Style = OfficeOpenXml.Style.ExcelBorderStyle.Thin; // Đặt kiểu đường viền cho hàng dọc

                            // Xuất tiêu đề cột từ DataGridView
                            for (int i = 0; i < dataGridView.Columns.Count; i++)
                            {
                                worksheet.Cells[3, i + 1].Value = dataGridView.Columns[i].HeaderText;
                            }
                            // Xuất dữ liệu từ DataGridView
                            for (int i = 1; i <= dataGridView.Rows.Count; i++)
                            {
                                for (int j = 1; j <= dataGridView.Columns.Count; j++)
                                {
                                    worksheet.Cells[i + 3, j].Value = dataGridView[j - 1, i - 1].Value;
                                    worksheet.Cells[i + 3, j].Style.Border.Bottom.Style = OfficeOpenXml.Style.ExcelBorderStyle.Thin; // Đặt kiểu đường viền cho hàng ngang
                                    worksheet.Cells[i + 3, j].Style.Border.Right.Style = OfficeOpenXml.Style.ExcelBorderStyle.Thin; // Đặt kiểu đường viền cho hàng dọc
                                }
                            }

                            // Tự động điều chỉnh độ rộng của các cột trong Excel sau khi thêm tiêu đề
                            worksheet.Cells[worksheet.Dimension.Address].AutoFitColumns();

                            package.Save();
                            MessageBox.Show("Xuất dữ liệu thành công!", "Thông báo");
                        }                        
                    }
                }                
            }
            catch (Exception ex)
            {
                MessageBox.Show("Lỗi: " + ex.Message, "Thông báo lỗi");
            }
        }

        private void button1_Click(object sender, EventArgs e)// TIMKIEM
        {
            string searchText = tb_timkiem.Text.Trim();

            // Tạo DataTable để lưu trữ dữ liệu tìm kiếm
            DataTable dataTable = new DataTable();

            // Biến để kiểm tra xem có dữ liệu tìm thấy hay không
            bool dataFound = false;

            if (!string.IsNullOrEmpty(searchText))
            {
                try
                {
                    // Mở kết nối đến cơ sở dữ liệu
                    using (SqlConnection connection = SqlConnectionData.connect())
                    {
                        connection.Open();

                        // Tạo truy vấn SQL SELECT với điều kiện WHERE để tìm kiếm
                        string query = "SELECT * FROM nhanvien WHERE " +
                                       "manv LIKE @searchText OR " +
                                       "tennv LIKE @searchText OR " +
                                       "gt LIKE @searchText OR " +
                                       "dantoc LIKE @searchText OR " +
                                       "ngaysinh LIKE @searchText OR " +
                                       "diachi LIKE @searchText OR " +
                                       "sdt LIKE @searchText OR " +
                                       "tdhv LIKE @searchText OR " +
                                       "mabp LIKE @searchText OR " +
                                       "macv LIKE @searchText";

                        // Tạo SqlCommand với truy vấn và kết nối
                        using (SqlCommand command = new SqlCommand(query, connection))
                        {
                            // Thêm tham số cho truy vấn để tránh tình trạng SQL Injection
                            command.Parameters.AddWithValue("@searchText", "%" + searchText + "%");

                            // Thực hiện truy vấn SELECT
                            SqlDataReader reader = command.ExecuteReader();

                            // Tạo cấu trúc cho DataTable
                            dataTable.Columns.Add("manv");
                            dataTable.Columns.Add("tennv");
                            dataTable.Columns.Add("gt");
                            dataTable.Columns.Add("dantoc");
                            dataTable.Columns.Add("ngaysinh");
                            dataTable.Columns.Add("diachi");
                            dataTable.Columns.Add("sdt");
                            dataTable.Columns.Add("tdhv");
                            dataTable.Columns.Add("mabp");
                            dataTable.Columns.Add("macv");

                            // Thêm các dòng vào DataTable
                            while (reader.Read())
                            {
                                DataRow newRow = dataTable.NewRow();
                                newRow["manv"] = reader["manv"].ToString();
                                newRow["tennv"] = reader["tennv"].ToString();
                                newRow["gt"] = reader["gt"].ToString();
                                newRow["dantoc"] = reader["dantoc"].ToString();
                                newRow["ngaysinh"] = reader["ngaysinh"].ToString();
                                newRow["diachi"] = reader["diachi"].ToString();
                                newRow["sdt"] = reader["sdt"].ToString();
                                newRow["tdhv"] = reader["tdhv"].ToString();
                                newRow["mabp"] = reader["mabp"].ToString();
                                newRow["macv"] = reader["macv"].ToString();
                                dataTable.Rows.Add(newRow);

                                // Đặt biến kiểm tra dữ liệu tìm thấy thành true
                                dataFound = true;
                            }

                            // Đóng SqlDataReader
                            reader.Close();
                        }
                    }

                    // Gán DataTable làm nguồn dữ liệu cho DataGridView
                    dataGridView.DataSource = dataTable;
                }
                catch (Exception ex)
                {
                    MessageBox.Show("Lỗi: " + ex.Message, "Thông báo lỗi");
                }

                // Kiểm tra xem có dữ liệu nào tìm thấy không
                if (!dataFound)
                {
                    MessageBox.Show("Không tìm thấy dữ liệu phù hợp.", "Thông báo!");
                }
            }
            else
            {
                MessageBox.Show("Vui lòng nhập yêu cầu để tìm kiếm thông tin.", "Thông báo!");
            }
        }
    }
}
    
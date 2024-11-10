using OfficeOpenXml.Style;
using OfficeOpenXml;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Data.SqlClient;
using System.Diagnostics.Eventing.Reader;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace qlnv_admin
{
    public partial class PHONGBAN : Form
    {
        public PHONGBAN()
        {
            InitializeComponent();
        }

        private void PHONGBAN_Load(object sender, EventArgs e)
        {
            // TODO: This line of code loads data into the 'quanLyNhanVienv2DataSet2.PHONGBAN' table. You can move, or remove it, as needed.
            //this.pHONGBANTableAdapter.Fill(this.quanLyNhanVienv2DataSet2.PHONGBAN);
            string sql = "select * from phongban";
            dataGridView.DataSource = ketnoi_sql.getData(sql);
        }
        public void loaddata()
        {
            string sql = "select * from phongban";
            dataGridView.DataSource = ketnoi_sql.getData(sql);
        }
        public void sqlrefresh()
        {
            tb_mapb.Text = "";
            tb_tenpb.Text = ""; 
        }
        private void groupBox1_Enter(object sender, EventArgs e)
        {

        }

        private void groupBox3_Enter(object sender, EventArgs e)
        {

        }
        private void dataGridView_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            int i = e.RowIndex;
            if (i < 0)
            {
                MessageBox.Show("Vui lòng chọn lại !", "thông báo !");
                return;
            }

            tb_mapb.Text = dataGridView.Rows[i].Cells[0].Value?.ToString();
            tb_tenpb.Text = dataGridView.Rows[i].Cells[1].Value?.ToString();
        }
        private void button1_Click(object sender, EventArgs e)// thêm
        {
            try
            {
                // Kiểm tra xem có ô TextBox nào trống không
                if (string.IsNullOrWhiteSpace(tb_mapb.Text) || string.IsNullOrWhiteSpace(tb_tenpb.Text))
                {
                    MessageBox.Show("Nhập đầy đủ dữ liệu trước khi thêm.", "Thông báo");
                    return;
                }

                using (SqlConnection connection = SqlConnectionData.connect())
                {
                    connection.Open();

                    // Kiểm tra mã nhân viên
                    SqlCommand checkCommand = new SqlCommand("SELECT COUNT(*) FROM phongban WHERE mapb = @mapb", connection);
                    checkCommand.Parameters.AddWithValue("@mapb", tb_mapb.Text);
                    int count = (int)checkCommand.ExecuteScalar();

                    if (count > 0)
                    {
                        MessageBox.Show("Mã phòng ban đã tồn tại trong dữ liệu .", "Thông báo");
                        return;
                    }

                    SqlCommand command = connection.CreateCommand();
                    command.CommandText = "INSERT INTO phongban VALUES(@mapb, @tenpb)";
                    command.Parameters.AddWithValue("@mapb", tb_mapb.Text);
                    command.Parameters.AddWithValue("@tenpb", tb_tenpb.Text);
                  
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

        private void button3_Click(object sender, EventArgs e)// xóa
        {

            try
            {
                using (SqlConnection connection = SqlConnectionData.connect())
                {
                    connection.Open();

                    DialogResult result = MessageBox.Show("Bạn có chắc chắn muốn xóa dữ liệu này?", "Xác nhận", MessageBoxButtons.YesNo, MessageBoxIcon.Question);
                    if (result == DialogResult.Yes)
                    {
                        // Kiểm tra xem mã phòng ban có tồn tại không
                        SqlCommand checkCommand = new SqlCommand("SELECT COUNT(*) FROM phongban WHERE mapb = @mapb", connection);
                        checkCommand.Parameters.AddWithValue("@mapb", tb_mapb.Text);
                        int count = (int)checkCommand.ExecuteScalar();

                        if (count == 0)
                        {
                            MessageBox.Show("Không tìm thấy dữ liệu.", "Thông báo");
                            return;
                        }

                        // Nếu tồn tại, thì thực hiện lệnh xóa
                        SqlCommand command = connection.CreateCommand();
                        command.CommandText = "DELETE FROM phongban WHERE mapb = @mapb";
                        command.Parameters.AddWithValue("@mapb", tb_mapb.Text);

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

        private void button2_Click(object sender, EventArgs e)// sửa 
        {
            try
            {

                using (SqlConnection connection = SqlConnectionData.connect())
                {
                    connection.Open();

                   
                    // Kiểm tra xem mã phòng ban có tồn tại không
                    SqlCommand checkCommand = new SqlCommand("SELECT COUNT(*) FROM phongban WHERE mapb = @mapb", connection);
                    checkCommand.Parameters.AddWithValue("@mapb", tb_mapb.Text);
                    int count = (int)checkCommand.ExecuteScalar();

                    if (count > 0)
                    {
                        // Nếu tồn tại, thì thực hiện lệnh cập nhật
                        SqlCommand command = connection.CreateCommand();
                        command.CommandText = "UPDATE phongban SET tenpb = @tenpb WHERE mapb = @mapb";
                        command.Parameters.AddWithValue("@mapb", tb_mapb.Text);
                        command.Parameters.AddWithValue("@tenpb", tb_tenpb.Text);

                        command.ExecuteNonQuery();

                        // Làm mới dataGridView sau khi cập nhật một bản ghi
                        loaddata();

                        

                        MessageBox.Show("Cập nhật dữ liệu thành công.", "Thông báo");
                    }
                    else
                    {
                        MessageBox.Show(" Không được sửa mã phòng ban . ", "Thông báo");
                        return;

                    }
                }
                    
            }
            catch (Exception ex)
            {
                MessageBox.Show("Lỗi: " + ex.Message, "Thông báo");
            }
        }

        private void button6_Click(object sender, EventArgs e)// reset 
        {
            sqlrefresh();
        }

        private void button7_Click(object sender, EventArgs e)//tìm kiếm
        {
            try
            {
                string searchText = tb_timkiem.Text.Trim();

                using (SqlConnection connection = SqlConnectionData.connect())
                {
                    connection.Open();

                    // Kiểm tra xem mã phòng ban có tồn tại không
                    SqlCommand checkCommand = new SqlCommand("SELECT COUNT(*) FROM phongban WHERE mapb = @mapb", connection);
                    checkCommand.Parameters.AddWithValue("@mapb", tb_timkiem.Text);
                    int count = (int)checkCommand.ExecuteScalar();

                    if (count > 0)
                    {
                        // Nếu tồn tại, thực hiện lệnh SELECT để lấy thông tin và hiển thị trong dataGridView
                        SqlCommand selectCommand = new SqlCommand("SELECT * FROM phongban WHERE mapb = @mapb", connection);
                        selectCommand.Parameters.AddWithValue("@mapb", tb_timkiem.Text);

                        SqlDataAdapter adapter = new SqlDataAdapter(selectCommand);
                        DataTable dataTable = new DataTable();
                        adapter.Fill(dataTable);

                        // Hiển thị kết quả trong dataGridView
                        dataGridView.DataSource = dataTable;

                        MessageBox.Show("Tìm kiếm thành công.", "Thông báo");
                    }
                    else
                    {
                        MessageBox.Show("Không tìm thấy mã phòng ban.", "Thông báo");
                        return;
                    }
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("Lỗi: " + ex.Message, "Thông báo");
            }
        }

        private void button8_Click(object sender, EventArgs e)// load
        {
            loaddata();
        }

        private void button5_Click(object sender, EventArgs e)// ex
        {
            try
            {
                using (SaveFileDialog saveFileDialog = new SaveFileDialog())
                {
                    saveFileDialog.Filter = "Excel Files (*.xlsx)|*.xlsx";
                    saveFileDialog.FileName = "output_DanhSachphongban.xlsx";
                    if (saveFileDialog.ShowDialog() == DialogResult.OK)
                    {
                        FileInfo excelFile = new FileInfo(saveFileDialog.FileName);
                        using (ExcelPackage package = new ExcelPackage(excelFile))
                        {
                            ExcelWorksheet worksheet = package.Workbook.Worksheets.Add("DANH SÁCH PHÒNG BAN");

                            // Thêm tiêu đề "Danh sách nhân viên"
                            worksheet.Cells["A1"].Value = "DS PHÒNG BAN";
                            worksheet.Cells["A2"].Value = "Thông tin chi tiết";
                            worksheet.Cells["A1"].Style.Font.Size = 25; // Đặt kích thước font cho tiêu đề
                            worksheet.Cells["A2"].Style.Font.Size = 20; // Đặt kích thước font cho tiêu đề
                            worksheet.Cells["A1:B1"].Merge = true; // Merge các ô từ A1 đến D1
                            worksheet.Cells["A2:B2"].Merge = true; // Merge các ô từ A1 đến D1                          
                            worksheet.Cells["A3:B3"].Style.Fill.PatternType = ExcelFillStyle.Solid;
                            worksheet.Cells["A3:B3"].Style.Fill.BackgroundColor.SetColor(System.Drawing.Color.Yellow);
                            worksheet.Cells["A3:B3"].Style.Font.Size = 12; // Đặt kích thước font cho tiêu đề         
                            worksheet.Cells["A1"].Style.Font.Bold = true; // Đặt đậm cho tiêu đề
                            worksheet.Cells["A1"].Style.HorizontalAlignment = OfficeOpenXml.Style.ExcelHorizontalAlignment.Center; // Căn giữa tiêu đề
                            worksheet.Cells["A2"].Style.HorizontalAlignment = OfficeOpenXml.Style.ExcelHorizontalAlignment.Center; // Căn giữa tiêu đề

                            // Tạo hàng ngang
                            worksheet.Cells["A1:B1"].Style.Border.Bottom.Style = OfficeOpenXml.Style.ExcelBorderStyle.Thin; // Đặt kiểu đường viền cho hàng ngang
                            worksheet.Cells["A2:B2"].Style.Border.Bottom.Style = OfficeOpenXml.Style.ExcelBorderStyle.Thin; // Đặt kiểu đường viền cho hàng ngang
                            worksheet.Cells["A3:B3"].Style.Border.Bottom.Style = OfficeOpenXml.Style.ExcelBorderStyle.Thin; // Đặt kiểu đường viền cho hàng ngang                          

                            // tạo hàng dọc
                            worksheet.Cells["A1:A3"].Style.Border.Right.Style = OfficeOpenXml.Style.ExcelBorderStyle.Thin; // Đặt kiểu đường viền cho hàng dọc
                            worksheet.Cells["A1:B3"].Style.Border.Right.Style = OfficeOpenXml.Style.ExcelBorderStyle.Thin; // Đặt kiểu đường viền cho hàng dọc

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
    }
}

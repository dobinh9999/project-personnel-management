using OfficeOpenXml.Style;
using OfficeOpenXml;
using System;
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
using static System.Windows.Forms.VisualStyles.VisualStyleElement.Rebar;

namespace qlnv_admin
{
    public partial class BAOHIEM : Form
    {
        public BAOHIEM()
        {
            InitializeComponent();
        }

        private void groupBox2_Enter(object sender, EventArgs e)
        {

        }

       

        private void BAOHIEM_Load(object sender, EventArgs e)
        {
            // TODO: This line of code loads data into the 'quanLyNhanVienv2DataSet2.BAOHIEM' table. You can move, or remove it, as needed.
            //this.bAOHIEMTableAdapter.Fill(this.quanLyNhanVienv2DataSet2.BAOHIEM);
            string sql = "select * from baohiem";
            dataGridView1.DataSource = ketnoi_sql.getData(sql);
        }
        public void loaddata()
        {
            string sql = "select * from baohiem";
            dataGridView1.DataSource = ketnoi_sql.getData(sql);
        }
        public void sqlrefresh()
        {
            tb_mabh.Text = "";
            tb_manv.Text = "";
            tb_sobh.Text = "";
            tb_ngaycap.Text = "";
            tb_noicap.Text = "";
        }

        private void dataGridView1_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            int i = e.RowIndex;
            if (i < 0)
            {
                MessageBox.Show("Vui lòng chọn lại !", "thông báo !");
                return;
            }

            tb_mabh.Text = dataGridView1.Rows[i].Cells[0].Value?.ToString();
            tb_manv.Text = dataGridView1.Rows[i].Cells[1].Value?.ToString();
            tb_sobh.Text = dataGridView1.Rows[i].Cells[2].Value?.ToString();
            tb_ngaycap.Text = dataGridView1.Rows[i].Cells[3].Value?.ToString();
            tb_noicap .Text = dataGridView1.Rows[i].Cells[4].Value?.ToString();
           
        }

        private void button1_Click(object sender, EventArgs e)//thêm
        {
            try
            {
                // Kiểm tra xem có ô TextBox nào trống không
                if (string.IsNullOrWhiteSpace(tb_mabh.Text) || string.IsNullOrWhiteSpace(tb_manv.Text)
                    || string.IsNullOrWhiteSpace(tb_sobh.Text) || string.IsNullOrWhiteSpace(tb_ngaycap.Text)
                    || string.IsNullOrWhiteSpace(tb_noicap.Text))
                {
                    MessageBox.Show("Nhập đầy đủ dữ liệu trước khi thêm.", "Thông báo");
                    return;
                }

                using (SqlConnection connection = SqlConnectionData.connect())
                {
                    connection.Open();

                    // Kiểm tra mã bảo hiểm
                    SqlCommand checkCommand = new SqlCommand("SELECT COUNT(*) FROM baohiem WHERE mabh = @mabh ", connection);
                    checkCommand.Parameters.AddWithValue("@mabh", tb_mabh.Text);
                    int count = (int)checkCommand.ExecuteScalar();

                    if (count > 0)
                    {
                        MessageBox.Show("Mã bảo hiểm đã tồn tại trong dữ liệu.", "Thông báo");
                        return;
                    }
                    // Kiểm tra số bảo hiểm
                    SqlCommand checkCommand1 = new SqlCommand("SELECT COUNT(*) FROM baohiem WHERE sobh = @sobh ", connection);
                    checkCommand1.Parameters.AddWithValue("@sobh", tb_sobh.Text);
                    int count1 = (int)checkCommand1.ExecuteScalar();
                    if(count1 > 0)
                    {
                        MessageBox.Show("Số bảo hiểm đã tồn tại trong dữ liệu.", "Thông báo");
                        return;
                    }
                    SqlCommand command = connection.CreateCommand();
                    command.CommandText = "INSERT INTO baohiem VALUES(@mabh, @manv, @sobh, @ngaycap, @noicap)";
                    command.Parameters.AddWithValue("@mabh", tb_mabh.Text);
                    command.Parameters.AddWithValue("@manv", tb_manv.Text);
                    command.Parameters.AddWithValue("@sobh", tb_sobh.Text);
                    command.Parameters.AddWithValue("@ngaycap", tb_ngaycap.Text);
                    command.Parameters.AddWithValue("@noicap", tb_noicap.Text);
                   

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
                if (string.IsNullOrWhiteSpace(tb_mabh.Text))
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
                        SqlCommand checkCommand = new SqlCommand("SELECT COUNT(*) FROM baohiem WHERE mabh = @mabh", connection);
                        checkCommand.Parameters.AddWithValue("@mabh", tb_mabh.Text);
                        int count = (int)checkCommand.ExecuteScalar();

                        if (count == 0)
                        {
                            MessageBox.Show("Không tìm thấy dữ liệu.", "Thông báo");
                            return;
                        }

                        // Nếu tồn tại, thì thực hiện lệnh xóa
                        SqlCommand command = connection.CreateCommand();
                        command.CommandText = "DELETE FROM baohiem WHERE mabh = @mabh";
                        command.Parameters.AddWithValue("@mabh", tb_mabh.Text);

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

        private void button2_Click(object sender, EventArgs e)//sửa
        {
            try
            {
                if (string.IsNullOrWhiteSpace(tb_mabh.Text))
                {
                    MessageBox.Show(" Hãy chọn dữ liệu để sửa . ", "Thông báo");
                    return;
                }
                using (SqlConnection connection = SqlConnectionData.connect())
                {
                    connection.Open();

                    // Kiểm tra xem mã khen thưởng có tồn tại không
                    SqlCommand checkCommand = new SqlCommand("SELECT COUNT(*) FROM baohiem WHERE mabh = @mabh", connection);
                    checkCommand.Parameters.AddWithValue("@mabh", tb_mabh.Text);
                    int count = (int)checkCommand.ExecuteScalar();

                    if (count == 0)
                    {
                        MessageBox.Show("Không được sửa mã bảo hiểm trong dữ liệu.", "Thông báo");
                        return;
                    }

                    // Nếu tồn tại, thực hiện lệnh cập nhật
                    SqlCommand command = connection.CreateCommand();
                    command.CommandText = "UPDATE baohiem SET manv = @manv, sobh = @sobh, ngaycap = @ngaycap, noicap = @noicap WHERE mabh = @mabh";
                    command.Parameters.AddWithValue("@mabh", tb_mabh.Text);
                    command.Parameters.AddWithValue("@manv", tb_manv.Text);
                    command.Parameters.AddWithValue("@sobh", tb_sobh.Text);
                    command.Parameters.AddWithValue("@ngaycap", tb_ngaycap.Value);
                    command.Parameters.AddWithValue("@noicap", tb_noicap.Text);
                    

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

        private void button4_Click(object sender, EventArgs e)// moi
        {
            sqlrefresh();
        }

        private void button7_Click(object sender, EventArgs e)// loaddata
        {
            loaddata();
        }
        private void button8_Click(object sender, EventArgs e)//timkiem
        {
            try
            {
                using (SqlConnection connection = SqlConnectionData.connect())
                {
                    connection.Open();

                    // Kiểm tra xem mã bảo hiểm có tồn tại không
                    SqlCommand checkCommand = new SqlCommand("SELECT COUNT(*) FROM baohiem WHERE mabh = @mabh", connection);
                    checkCommand.Parameters.AddWithValue("@mabh", tb_timkiem.Text);
                    int count = (int)checkCommand.ExecuteScalar();

                    if (count > 0)
                    {
                        // Nếu tồn tại, thực hiện lệnh SELECT để lấy thông tin và hiển thị trong dataGridView
                        SqlCommand selectCommand = new SqlCommand("SELECT * FROM baohiem WHERE mabh = @mabh", connection);
                        selectCommand.Parameters.AddWithValue("@mabh", tb_timkiem.Text);

                        SqlDataAdapter adapter = new SqlDataAdapter(selectCommand);
                        DataTable dataTable = new DataTable();
                        adapter.Fill(dataTable);

                        // Hiển thị kết quả trong dataGridView1
                        dataGridView1.DataSource = dataTable;

                        MessageBox.Show("Tìm kiếm thành công.", "Thông báo");
                    }
                    else
                    {
                        MessageBox.Show("Không tìm thấy mã bảo hiểm.", "Thông báo");
                        return;
                    }
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("Lỗi: " + ex.Message, "Thông báo");
            }
        }

        private void button5_Click(object sender, EventArgs e)//EX
        {
            try
            {
                using (SaveFileDialog saveFileDialog = new SaveFileDialog())
                {
                    saveFileDialog.Filter = "Excel Files (*.xlsx)|*.xlsx";
                    saveFileDialog.FileName = "output_DanhSachBAOHIEM.xlsx";
                    if (saveFileDialog.ShowDialog() == DialogResult.OK)
                    {
                        FileInfo excelFile = new FileInfo(saveFileDialog.FileName);
                        using (ExcelPackage package = new ExcelPackage(excelFile))
                        {
                            ExcelWorksheet worksheet = package.Workbook.Worksheets.Add("DANH SÁCH BẢO HIỂM");

                            // Thêm tiêu đề "Danh sách nhân viên"
                            worksheet.Cells["A1"].Value = "DANH SÁCH KHEN THƯỞNG";
                            worksheet.Cells["A2"].Value = "Thông tin chi tiết";
                            worksheet.Cells["A1"].Style.Font.Size = 25; // Đặt kích thước font cho tiêu đề
                            worksheet.Cells["A2"].Style.Font.Size = 20; // Đặt kích thước font cho tiêu đề
                            worksheet.Cells["A1:F1"].Merge = true; // Merge các ô từ A1 đến D1
                            worksheet.Cells["A2:F2"].Merge = true; // Merge các ô từ A1 đến D1                          
                            worksheet.Cells["A3:F3"].Style.Fill.PatternType = ExcelFillStyle.Solid;
                            worksheet.Cells["A3:F3"].Style.Fill.BackgroundColor.SetColor(System.Drawing.Color.Yellow);
                            worksheet.Cells["A3:F3"].Style.Font.Size = 12; // Đặt kích thước font cho tiêu đề         
                            worksheet.Cells["A1"].Style.Font.Bold = true; // Đặt đậm cho tiêu đề
                            worksheet.Cells["A1"].Style.HorizontalAlignment = OfficeOpenXml.Style.ExcelHorizontalAlignment.Center; // Căn giữa tiêu đề
                            worksheet.Cells["A2"].Style.HorizontalAlignment = OfficeOpenXml.Style.ExcelHorizontalAlignment.Center; // Căn giữa tiêu đề

                            // Tạo hàng ngang
                            worksheet.Cells["A1:F1"].Style.Border.Bottom.Style = OfficeOpenXml.Style.ExcelBorderStyle.Thin; // Đặt kiểu đường viền cho hàng ngang
                            worksheet.Cells["A2:F2"].Style.Border.Bottom.Style = OfficeOpenXml.Style.ExcelBorderStyle.Thin; // Đặt kiểu đường viền cho hàng ngang
                            worksheet.Cells["A3:F3"].Style.Border.Bottom.Style = OfficeOpenXml.Style.ExcelBorderStyle.Thin; // Đặt kiểu đường viền cho hàng ngang                          

                            // tạo hàng dọc
                            worksheet.Cells["A1:A3"].Style.Border.Right.Style = OfficeOpenXml.Style.ExcelBorderStyle.Thin; // Đặt kiểu đường viền cho hàng dọc
                            worksheet.Cells["A1:F3"].Style.Border.Right.Style = OfficeOpenXml.Style.ExcelBorderStyle.Thin; // Đặt kiểu đường viền cho hàng dọc

                            // Xuất tiêu đề cột từ DataGridView
                            for (int i = 0; i < dataGridView1.Columns.Count; i++)
                            {
                                worksheet.Cells[3, i + 1].Value = dataGridView1.Columns[i].HeaderText;
                            }
                            // Xuất dữ liệu từ DataGridView
                            for (int i = 1; i <= dataGridView1.Rows.Count; i++)
                            {
                                for (int j = 1; j <= dataGridView1.Columns.Count; j++)
                                {
                                    worksheet.Cells[i + 3, j].Value = dataGridView1[j - 1, i - 1].Value;
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

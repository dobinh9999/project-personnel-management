using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using Microsoft.VisualBasic;
using OfficeOpenXml.Style;
using OfficeOpenXml;
using static System.Windows.Forms.VisualStyles.VisualStyleElement.Rebar;

namespace qlnv_admin
{
    public partial class TINHLUONG : Form
    {
        public TINHLUONG()
        {
            InitializeComponent();
        }

        private void button1_Click(object sender, EventArgs e)
        {

            DialogResult dialogResult = MessageBox.Show("Bạn có muốn tính lương cho tất cả nhân viên .", "Xác Nhận Tính Lương", MessageBoxButtons.YesNo);

            if (dialogResult == DialogResult.Yes)
            {

                try
                {
                    // Truy vấn SQL
                    string sql_tinhluong = @"
            INSERT INTO LUONG (MANV, TENNV, LCB, TIENPC, TIENUL, TIENTHUONG, TIENPHAT, SONGAYCONG, SOGIOTC, TONGTIENLUONG)
            SELECT 
                NV.MANV   ,
                NV.TENNV  ,
                HDLD.LCB  ,
                NVPC.TIENPC ,
                UL.TIENUL ,
                MAX(KT.TIENTHUONG) AS 'TỔNG TIỀN THƯỞNG',
                MAX(KL.TIENPHAT) AS 'TỔNG TIỀN PHẠT',
                COUNT(DISTINCT BC.NGAYCONG) AS 'SỐ NGÀY CÔNG',
                MAX(TC.SOGIOTC) AS 'SỐ GIỜ TĂNG CA' ,
                ISNULL(HDLD.LCB, 0) * ISNULL(COUNT(DISTINCT BC.NGAYCONG), 0) +
                ISNULL(NVPC.TIENPC, 0) +
                ISNULL(MAX(KT.TIENTHUONG), 0) +
                ISNULL(MAX(TC.SOGIOTC) * 100000, 0) -
                ISNULL(MAX(KL.TIENPHAT), 0) -
                ISNULL(UL.TIENUL, 0) AS 'TỔNG TIỀN LƯƠNG'
            FROM
                NHANVIEN NV
                JOIN HDLD ON NV.MANV = HDLD.MANV
                LEFT JOIN NHANVIENPC NVPC ON NV.MANV = NVPC.MANV
                LEFT JOIN UNGLUONG UL ON NV.MANV = UL.MANV
                LEFT JOIN KHENTHUONG KT ON NV.MANV = KT.MANV
                LEFT JOIN KYLUAT KL ON NV.MANV = KL.MANV
                LEFT JOIN BANGCONG BC ON NV.MANV = BC.MANV
                LEFT JOIN TANGCA TC ON NV.MANV = TC.MANV
            GROUP BY
                NV.MANV, NV.TENNV, HDLD.LCB, NVPC.TIENPC, UL.TIENUL;
        ";

                    // Gọi execQuery để thực hiện lệnh SQL
                    ketnoi_sql.execQuery(sql_tinhluong);


                    // Lấy dữ liệu từ cơ sở dữ liệu và gán vào DataGridView
                    string selectCommand = "SELECT * FROM LUONG";
                    DataTable dataTable = ketnoi_sql.getData(selectCommand);

                    // Gán dữ liệu vào DataGridView
                    dataGridView1.DataSource = dataTable;

                    MessageBox.Show("Dữ liệu đã được tính và hiển thị thành công!");
                }
                catch (Exception ex)
                {
                    MessageBox.Show("Lỗi: " + ex.Message);
                }
            }
        }

        private void TINHLUONG_Load(object sender, EventArgs e)
        {
            // TODO: This line of code loads data into the 'quanLyNhanVienv2DataSet1.LUONG' table. You can move, or remove it, as needed.
            //this.lUONGTableAdapter.Fill(this.quanLyNhanVienv2DataSet1.LUONG);
            string sql = "select * from luong";
            dataGridView1.DataSource = ketnoi_sql.getData(sql);

        }
        public void loaddata()
        {
            string sql = "select * from luong";
            dataGridView1.DataSource = ketnoi_sql.getData(sql);
        }
        public void sqlrefresh()
        {
           
            tb_manv.Text = "";
            tb_tennv.Text = "";
            tb_lcb.Text = "";
            tb_tpc.Text = "";
            tb_tul.Text = "";
            tb_ttt.Text = "";
            tb_ttp.Text = "";
            tb_snc.Text = "";
            tb_sgc.Text = "";
            tb_ttl.Text = "";

        }
        private void dataGridView1_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            int i = e.RowIndex;
            if (i < 0)
            {
                MessageBox.Show("Vui lòng chọn lại !", "thông báo !");
                return;
            }


            tb_manv.Text = dataGridView1.Rows[i].Cells[0].Value?.ToString();
            tb_tennv.Text = dataGridView1.Rows[i].Cells[1].Value?.ToString();            
            tb_lcb.Text = dataGridView1.Rows[i].Cells[2].Value?.ToString();
            tb_tpc.Text = dataGridView1.Rows[i].Cells[3].Value?.ToString();
            tb_tul.Text = dataGridView1.Rows[i].Cells[4].Value?.ToString();
            tb_ttt.Text = dataGridView1.Rows[i].Cells[5].Value?.ToString();
            tb_ttp.Text = dataGridView1.Rows[i].Cells[6].Value?.ToString();
            tb_snc.Text = dataGridView1.Rows[i].Cells[7].Value?.ToString();
            tb_sgc.Text = dataGridView1.Rows[i].Cells[8].Value?.ToString();
            tb_ttl.Text = dataGridView1.Rows[i].Cells[9].Value?.ToString();
        }
        private void button4_Click(object sender, EventArgs e)// SỬA TENNV
        {
            try
            {
                // Lấy mã nhân viên từ TextBox
                string maNV = tb_manv.Text.Trim();

                // Kiểm tra xem TextBox có dữ liệu không
                if (string.IsNullOrEmpty(maNV))
                {
                    MessageBox.Show("Vui lòng nhập mã nhân viên cần sửa!", "Thông báo");
                    return;
                }

                // Hiển thị hộp thoại nhập tên mới
                string tenNVMoi = Interaction.InputBox("Nhập tên mới cho nhân viên có mã " + maNV + ":", "Sửa tên nhân viên", "");

                // Kiểm tra xem người dùng đã nhập tên mới hay chưa
                if (!string.IsNullOrEmpty(tenNVMoi))
                {
                    // Cập nhật giá trị trong cơ sở dữ liệu
                    string updateCommand = "UPDATE LUONG SET TENNV  = N'" + tenNVMoi + "' WHERE MANV = '" + maNV + "'";
                    ketnoi_sql.execQuery(updateCommand);

                    // Cập nhật lại DataGridView sau khi sửa
                    loaddata();
                    // REFECT 
                    sqlrefresh ();
                    MessageBox.Show("Sửa tên nhân viên thành công!", " Thông báo");
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("Lỗi: " + ex.Message);
            }
        }

        private void button7_Click(object sender, EventArgs e) // XÓA THEO MÃ HOẶC XÓA TOÀN BỘ 
        {
            try
            {
                // Lấy mã nhân viên từ TextBox
                string MANV = tb_manv.Text.Trim();

                // Kiểm tra xem TextBox có dữ liệu không
                if (string.IsNullOrEmpty(MANV))
                {
                    MessageBox.Show("Vui lòng nhập mã nhân viên cần xóa!", "Thông báo");
                    return;
                }

                // Hiển thị hộp thoại xác nhận xóa
                DialogResult dialogResult = MessageBox.Show("Bạn có chắc chắn muốn xóa nhân viên có mã " + MANV + "?", "Xác nhận xóa", MessageBoxButtons.YesNo);

                if (dialogResult == DialogResult.Yes)
                {
                    // Thực hiện truy vấn xóa nhân viên
                    string deleteCommand = "DELETE FROM LUONG WHERE MANV = '" + MANV + "'";
                    ketnoi_sql.execQuery(deleteCommand);

                    // Cập nhật lại DataGridView sau khi xóa
                    loaddata();
                    // refect
                    sqlrefresh();


                    MessageBox.Show("Xóa nhân viên thành công!", "Thông báo");
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("Lỗi: " + ex.Message);
            }
        }

        private void button_Click(object sender, EventArgs e) // THÊM
        {
            try
            {
                // Lấy thông tin từ các TextBox
                string maNV = tb_manv.Text.Trim();
                string tenNV = tb_tennv.Text.Trim();
                string lcb = tb_lcb.Text.Trim();
                string tpc = tb_tpc.Text.Trim();
                string tul = tb_tul.Text.Trim();
                string ttt = tb_ttt.Text.Trim();
                string ttp = tb_ttp.Text.Trim();
                string snc = tb_snc.Text.Trim();
                string sgc = tb_sgc.Text.Trim();
                string ttl = tb_ttl.Text.Trim();

                // Kiểm tra xem TextBox mã nhân viên có dữ liệu không
                if (string.IsNullOrEmpty(maNV))
                {
                    MessageBox.Show("Vui lòng nhập mã nhân viên!", "Thông báo");
                    return;
                }

                // Thực hiện truy vấn thêm nhân viên mới
                string insertCommand = $@"
            INSERT INTO LUONG (MANV, TENNV, LCB, TIENPC, TIENUL, TIENTHUONG, TIENPHAT, SONGAYCONG, SOGIOTC, TONGTIENLUONG)
            VALUES (
                '{maNV}', N'{tenNV}', {lcb}, {tpc}, {tul}, {ttt}, {ttp}, {snc}, {sgc}, {ttl}
            )";

                ketnoi_sql.execQuery(insertCommand);

                // Cập nhật lại DataGridView sau khi thêm
                loaddata();

                MessageBox.Show("Thêm nhân viên thành công!", " Thông báo");
            }
            catch (Exception ex)
            {
                MessageBox.Show("Lỗi: " + ex.Message);
            }
        }

        private void button5_Click(object sender, EventArgs e)
        {
            try
            {
                // Hiển thị hộp thoại xác nhận xóa toàn bộ nhân viên
                DialogResult dialogResult = MessageBox.Show("Bạn có chắc chắn muốn xóa toàn bộ nhân viên?", "Xác nhận xóa", MessageBoxButtons.YesNo);

                if (dialogResult == DialogResult.Yes)
                {
                    // Thực hiện truy vấn xóa toàn bộ nhân viên
                    string deleteAllCommand = "DELETE FROM LUONG";
                    ketnoi_sql.execQuery(deleteAllCommand);

                    // Cập nhật lại DataGridView sau khi xóa
                    loaddata();

                    MessageBox.Show("Xóa toàn bộ nhân viên thành công!"," Thông báo" );
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("Lỗi: " + ex.Message);
            }
        }

        private void button2_Click(object sender, EventArgs e)// excel
        {
            try
            {
                using (SaveFileDialog saveFileDialog = new SaveFileDialog())
                {
                    saveFileDialog.Filter = "Excel Files (*.xlsx)|*.xlsx";
                    saveFileDialog.FileName = "output_DanhSachLUONGNhanVien.xlsx";
                    if (saveFileDialog.ShowDialog() == DialogResult.OK)
                    {
                        FileInfo excelFile = new FileInfo(saveFileDialog.FileName);
                        using (ExcelPackage package = new ExcelPackage(excelFile))
                        {
                            ExcelWorksheet worksheet = package.Workbook.Worksheets.Add("DANH SÁCH LƯƠNG NHÂN VIÊN");
                            
                            // Thêm tiêu đề "Danh sách nhân viên"
                            worksheet.Cells["A1"].Value = "DANH SÁCH LƯƠNG NHÂN VIÊN";
                            worksheet.Cells["A2"].Value = "Thông Tin Chi Tiết";
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

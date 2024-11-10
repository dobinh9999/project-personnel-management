using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace qlnv_admin
{
    public class delete
    {
        public void XoaNhanVien(string manv, DataGridView dataGridView)
        {
            try
            {

                if (dataGridView == null)
                {
                    MessageBox.Show("DataGridView không được khởi tạo.", "Thông báo");
                    return;
                }
               
                    using (SqlConnection connection = SqlConnectionData.connect())
                    {
                        connection.Open();

                        // Tạo câu lệnh SQL để xóa nhân viên theo mã nhân viên
                        string deleteQuery = "DELETE FROM nhanvien WHERE manv = @manv";
                        SqlCommand deleteCommand = new SqlCommand(deleteQuery, connection);
                        deleteCommand.Parameters.AddWithValue("@manv", manv);

                        // Thực hiện lệnh xóa
                        deleteCommand.ExecuteNonQuery();

                        // Hiển thị thông báo xóa thành công
                        MessageBox.Show("Xóa nhân viên thành công.", "Thông báo");

                        // Load lại dữ liệu vào DataGridView
                        string reloadQuery = "select * from nhanvien";
                        dataGridView.DataSource = ketnoi_sql.getData(reloadQuery);
                    }
                
                
            }
            catch (Exception ex)
            {
                MessageBox.Show("Lỗi: " + ex.Message, "Thông báo");
            }

               
        }
    }
}

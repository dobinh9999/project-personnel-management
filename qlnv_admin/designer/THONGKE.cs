using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace qlnv_admin
{
    public partial class THONGKE : Form
    {
        public THONGKE()
        {
            InitializeComponent();
        }

        private void THONGKE_Load(object sender, EventArgs e)
        {
            comboBox1.Items.Add("Số lượng nhân viên của từng bộ phận");
            comboBox1.Items.Add("Danh sách nhân viên trên 30 tuổi");
            comboBox1.Items.Add("Danh sách nhân viên dưới 30 tuổi");
            comboBox1.Items.Add("Danh sách nhân viên theo tiền phụ cấp");
            comboBox1.Items.Add("Số lượng nhân viên theo giới tính");
            comboBox1.Items.Add("Số lượng nhân viên theo từng trình độ học vấn");            
        }

        private void button1_Click(object sender, EventArgs e)
        {
            if (string.IsNullOrWhiteSpace(comboBox1.Text))
            {
                MessageBox.Show("Vui lòng nhập thông tin.", "thông báo !");
                return;
            }

            string selectedOption = comboBox1.SelectedItem.ToString();
            DataTable dataTable = new DataTable();


            try
            {
                switch (selectedOption)
                {
                    case "Số lượng nhân viên của từng bộ phận":
                        string query1 = "SELECT mabp, COUNT(*) AS soluong FROM nhanvien GROUP BY mabp";
                        dataTable = ketnoi_sql.getData(query1);
                        break;

                    case "Danh sách nhân viên trên 30 tuổi":
                        string query2 = "SELECT * FROM nhanvien WHERE DATEDIFF(YEAR, ngaysinh, GETDATE()) > 30";
                        dataTable = ketnoi_sql.getData(query2);
                        break;

                    case "Danh sách nhân viên dưới 30 tuổi":
                        string query3 = "SELECT * FROM nhanvien WHERE DATEDIFF(YEAR, ngaysinh, GETDATE()) <= 30";
                        dataTable = ketnoi_sql.getData(query3);
                        break;

                    case "Danh sách nhân viên theo tiền phụ cấp":
                        string query4 = "SELECT NV.manv AS 'MÃ NHÂN VIÊN', NV.tennv  AS 'TÊN NHÂN VIÊN' ,  ISNULL( NVPC.TIENPC,0)  AS 'PHỤ CẤP NHÂN VIÊN' FROM  nhanvien NV  JOIN NHANVIENPC NVPC ON NV.MANV = NVPC.MANV  GROUP BY NV.manv, NV.tennv, NVPC.TIENPC ";
                        dataTable = ketnoi_sql.getData(query4);
                        break;

                    case "Số lượng nhân viên theo giới tính":
                        string query5 = "SELECT GT AS 'GIỚI TÍNH', COUNT(*) AS 'SỐ LƯỢNG' FROM nhanvien GROUP BY GT";
                        dataTable = ketnoi_sql.getData(query5);
                        break;

                    case "Số lượng nhân viên theo từng trình độ học vấn":
                        string query6 = "SELECT tdhv, COUNT(*) AS soluong FROM nhanvien GROUP BY tdhv";
                        dataTable = ketnoi_sql.getData(query6);
                        break;

                    default:
                        MessageBox.Show("Lựa chọn không hợp lệ.", "Thông báo!");
                        return;
                }

                // Hiển thị kết quả trong DataGridView hoặc thực hiện bất kỳ xử lý nào bạn muốn với dataTable
                dataGridView1.DataSource = dataTable;
            }
            catch (Exception ex)
            {
                MessageBox.Show("Lỗi: " + ex.Message, "Thông báo lỗi");
            }
        }
    }
}

using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace qlnv_admin
{
        public class SqlConnectionData
        {
            // tao chuoi ket noi co so du lieu

            public static SqlConnection connect()
            {

                string str = @"Data Source=LAPTOP-D90-DOXU\SQLEXPRESS;Initial Catalog=QuanLyNhanVienv2;Integrated Security=True";
                SqlConnection con = new SqlConnection(str); // khoi tao connect
                return con;
            }
        }
    
        public class ketnoi_sql
        {
            // ham do du lieu vao datable
            public static DataTable getData(string query)
            {
                SqlConnection conn = SqlConnectionData.connect();
                DataTable tb = new DataTable();
                SqlDataAdapter da = new SqlDataAdapter(query, conn);
                da.Fill(tb);
                conn.Close();
                return tb;
            }

            public static void execQuery(string sql)
            {
                SqlConnection conn = SqlConnectionData.connect();
                SqlCommand cmd = new SqlCommand(sql, conn);
                conn.Open();
                cmd.ExecuteNonQuery();
                conn.Close();
                cmd.Dispose();
            }

        }
    }

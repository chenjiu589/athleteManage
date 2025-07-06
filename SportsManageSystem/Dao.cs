using System;
using System.Data.SqlClient;
using System.Windows.Forms;

namespace SportsManageSystem
{
    internal class Dao
    {
        SqlConnection sc;
        public SqlConnection connect()
        {
            string str = @"Data Source=ROG;Initial catalog=SportsManageSystem;
            Integrated Security=True";
            sc = new SqlConnection(str);
            sc.Open();
            return sc;
        }
        public SqlCommand command(string sql)
        {
            SqlCommand cmd = new SqlCommand(sql, connect());
            return cmd;
        }
        //public int Execute(string sql)
        //{
        //    return command(sql).ExecuteNonQuery();
        //}

        public int Execute(string sql)
        {
            SqlConnection connection = null;
            SqlCommand cmd = null;

            try
            {
                connection = connect(); // 获取连接
                cmd = new SqlCommand(sql, connection);
                return cmd.ExecuteNonQuery();
            }
            catch (SqlException ex) when (ex.Number == 2627) // 主键冲突
            {
                Console.WriteLine("错误: 数据已存在（主键冲突）");
                return -1; // 返回特定错误码
            }
            catch (SqlException ex) when (ex.Number == 547) // 外键约束
            {
                Console.WriteLine("错误: 违反外键约束");
                MessageBox.Show("错误: 违反外键约束");
                return -2;
            }
            catch (SqlException ex)
            {
                Console.WriteLine($"数据库错误: {ex.Message}");
                MessageBox.Show($"数据库错误: {ex.Message}");
                return -3;
            }
            catch (Exception ex)
            {
                Console.WriteLine($"系统错误: {ex.Message}");
                MessageBox.Show($"系统错误: {ex.Message}");
                return -99;
            }
            finally
            {
                // 确保资源释放
                cmd?.Dispose();
                connection?.Close();
                connection?.Dispose();
            }
        }
        public SqlDataReader read(string sql)
        {
            return command(sql).ExecuteReader();
        }
        public void DaoClose()
        {
            sc.Close();
        }
    }
}
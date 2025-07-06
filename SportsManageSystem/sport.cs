using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Reflection.Emit;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace SportsManageSystem
{
    public partial class sport : Form
    {
        public sport()
        {
            InitializeComponent();
        }

        private void sport_Load(object sender, EventArgs e)
        {
            table();
        }

        public void table()
        {
            dataGridView1.Rows.Clear(); //清空旧数据
            Dao dao = new Dao();
            string sql = "select * from event";
            IDataReader dc = dao.read(sql);
            while (dc.Read())
            {
                dataGridView1.Rows.Add(dc[0].ToString(), dc[1].ToString(), dc[2].ToString(), dc[3].ToString(), dc[4].ToString(), dc[5].ToString());
            }
            dc.Close(); dao.DaoClose();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            sport1 sport = new sport1();
            sport.ShowDialog();
        }

        private void button6_Click(object sender, EventArgs e)
        {
            string ResultID = dataGridView1.SelectedRows[0].Cells[0].Value.ToString();
            int flag = int.Parse(ResultID);
            sport2 sport = new sport2(flag);
            sport.ShowDialog();
            table();

        }

        private void dataGridView1_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {

        }

        private void button3_Click(object sender, EventArgs e)
        {
            table();
        }

        private void button2_Click(object sender, EventArgs e)
        {
            try
            {
                string id = dataGridView1.SelectedRows[0].Cells[0].Value.ToString();//获取书号
            
                DialogResult dc = MessageBox.Show("确认删除吗?", "提示信息", MessageBoxButtons.OKCancel, MessageBoxIcon.Question);
                if (dc == DialogResult.OK)
                {
                    string sql = $"delete from event where eventID='{id}'";
                    Dao dao = new Dao();
                    if (dao.Execute(sql) > 0)
                    {
                        MessageBox.Show("删除成功！");
                        table();
                    }
                    else
                    {
                        MessageBox.Show("删除失败!" + sql);
                    }
                    dao.DaoClose();
                }
            }
            catch
            {
                MessageBox.Show("请先在表格中选择要删除的记录", "提示信息", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }
    }
}

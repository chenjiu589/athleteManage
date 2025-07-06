using System;
using System.Collections.Concurrent;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Security.Cryptography;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace SportsManageSystem
{
    public partial class admin2 : Form
    {
        public admin2()
        {
            InitializeComponent();

        }

        private void admin2_Load(object sender, EventArgs e)
        {
            table();
            label2.Text = dataGridView1.SelectedRows[0].Cells[0].Value.ToString() + ' ' + dataGridView1.SelectedRows[0].Cells[1].Value.ToString() + ' ' + dataGridView1.SelectedRows[0].Cells[2].Value.ToString();//获取书号
        }
        //从数据库读取数据显示在表格中
        public void table()
        {
            dataGridView1.Rows.Clear(); //清空旧数据
            Dao dao = new Dao();
            string sql = "select ResultID,AthleteID,result.EventID,Score,defaultunit ,Rank,IsRecord\r\nfrom result inner join event\r\non result.EventID=event.EventID";
            IDataReader dc = dao.read(sql);
            while (dc.Read())
            {
                dataGridView1.Rows.Add(dc[0].ToString(), dc[1].ToString(), dc[2].ToString(), dc[3].ToString(), dc[4].ToString(), dc[5].ToString());
            }
            dc.Close(); dao.DaoClose();
        }
        private void textBox1_TextChanged(object sender, EventArgs e)
        {

        }

        private void button1_Click(object sender, EventArgs e)
        {
            admin21 admin = new admin21();
            admin.ShowDialog();
        }

        private void dataGridView1_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {

        }

        private void button4_Click(object sender, EventArgs e)
        {
            try
            {
                string id = dataGridView1.SelectedRows[0].Cells[0].Value.ToString();//获取书号
                label2.Text = id + ' ' + dataGridView1.SelectedRows[0].Cells[1].Value.ToString() + ' ' + dataGridView1.SelectedCells[2].Value.ToString();
                DialogResult dc = MessageBox.Show("确认删除吗?", "提示信息", MessageBoxButtons.OKCancel, MessageBoxIcon.Question);
                if (dc == DialogResult.OK)
                {
                    string sql = $"delete from result where resultID='{id}'";
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

        private void label1_Click(object sender, EventArgs e)
        {

        }

        private void dataGridView1_Click(object sender, EventArgs e)
        {
            label2.Text = dataGridView1.SelectedRows[0].Cells[0].Value.ToString() + ' ' + dataGridView1.SelectedRows[0].Cells[1].Value.ToString() + ' ' + dataGridView1.SelectedRows[0].Cells[2].Value.ToString();//获取书号
        }

        private void button6_Click(object sender, EventArgs e)
        {
            //try
            //{
            //    string ResultID = dataGridView1.SelectedRows[0].Cells[0].Value.ToString();
            //    //string AthleteID = dataGridView1.SelectedRows[0].Cells[1].Value.ToString();
            //    //string EventID = dataGridView1.SelectedRows[0].Cells[2].Value.ToString();
            //    //string Score = dataGridView1.SelectedRows[0].Cells[3].Value.ToString();
            //    //string Rank = dataGridView1.SelectedRows[0].Cells[4].Value.ToString();
            //    //string IsRecord = dataGridView1.SelectedRows[0].Cells[5].Value.ToString();
            //    int flag = int.Parse(ResultID);
            //    admin22 admin = new admin22(flag);
            //    admin.ShowDialog();
            //    table();
            //}
            //catch
            //{
            //    MessageBox.Show("ERROR");
            //}
            string ResultID = dataGridView1.SelectedRows[0].Cells[0].Value.ToString();
            int flag = int.Parse(ResultID);
            admin22 admin = new admin22(flag);
            admin.ShowDialog();
            table();
        }
        public void athleteQuery()
        {
            dataGridView1.Rows.Clear(); //清空旧数据
            if (!int.TryParse(textBox1.Text, out int athleteID))
            {
                MessageBox.Show("请输入合法的运动员ID！");
                return;
            }
            Dao dao = new Dao();
            string sql = $"select * from result where athleteID = {athleteID}";
            IDataReader dc = dao.read(sql);
            while (dc.Read())
            {
                dataGridView1.Rows.Add(dc[0].ToString(), dc[1].ToString(), dc[2].ToString(), dc[3].ToString(), dc[4].ToString(), dc[5].ToString());
            }
            dc.Close();
            dao.DaoClose();
        }
        public void eventQuery()
        {
            dataGridView1.Rows.Clear(); //清空旧数据
            if (!int.TryParse(textBox2.Text, out int eventID))
            {
                MessageBox.Show("请输入合法的比赛ID！");
                return;
            }
            Dao dao = new Dao();
            string sql = $"select * from result where eventID = {eventID}";
            IDataReader dc = dao.read(sql);
            while (dc.Read())
            {
                dataGridView1.Rows.Add(dc[0].ToString(), dc[1].ToString(), dc[2].ToString(), dc[3].ToString(), dc[4].ToString(), dc[5].ToString());
            }
            dc.Close();
            dao.DaoClose();
        }
        private void button2_Click(object sender, EventArgs e)
        {
            athleteQuery();
        }

        private void button3_Click(object sender, EventArgs e)
        {
            eventQuery();
        }

        private void button5_Click(object sender, EventArgs e)
        {
            table();
            textBox1.Text = "";
            textBox2.Text = "";
        }

        private void label2_Click(object sender, EventArgs e)
        {

        }

        private void button7_Click(object sender, EventArgs e)
        {
            admin23 admin = new admin23();
            admin.ShowDialog();
        }

        private void button8_Click(object sender, EventArgs e)
        {
            dataGridView1.Rows.Clear(); //清空旧数据
            Dao dao = new Dao();
            string sql = $"UPDATE r\r\nSET r.[rank] = rd.new_rank\r\nFROM result r\r\nINNER JOIN (\r\n    SELECT \r\n        athleteID, \r\n        eventID, \r\n        RANK() OVER (\r\n            PARTITION BY eventID \r\n            ORDER BY TRY_CAST(score AS DECIMAL(10,2)) DESC\r\n        ) AS new_rank\r\n    FROM result\r\n) rd ON r.athleteID = rd.athleteID AND r.eventID = rd.eventID;";
            IDataReader dc = dao.read(sql);
            while (dc.Read())
            {
                dataGridView1.Rows.Add(dc[0].ToString(), dc[1].ToString(), dc[2].ToString(), dc[3].ToString(), dc[4].ToString(), dc[5].ToString());
            }
            dc.Close();
            dao.DaoClose();
           
        }
    }
}
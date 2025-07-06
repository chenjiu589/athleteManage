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
    public partial class user13 : Form
    {
        public user13()
        {
            InitializeComponent();
        }

        private void user13_Load(object sender, EventArgs e)
        {
            table();
         
        }

        private void dataGridView1_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {
           
        }
        public void table()
        {
            dataGridView1.Rows.Clear(); //清空旧数据
            Dao dao = new Dao();
            string sql = "SELECT registrationID,a.name AS athlete_name,e.EventName AS event_name,rt.registrationTime FROM RegistrationTest rt INNER JOIN athlete a ON rt.athleteID = a.athleteID INNER JOIN  event e ON rt.eventID = e.eventID;";
            IDataReader dc = dao.read(sql);
            while (dc.Read())
            {
                dataGridView1.Rows.Add(dc[0].ToString(), dc[1].ToString(), dc[2].ToString(), dc[3].ToString());
            }
            dc.Close(); dao.DaoClose();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            //try
            //{
                string id = dataGridView1.SelectedRows[0].Cells[0].Value.ToString();
                label3.Text = id ;
                DialogResult dc = MessageBox.Show("确认删除吗?", "提示信息", MessageBoxButtons.OKCancel, MessageBoxIcon.Question);
                if (dc == DialogResult.OK)
                {
                    string sql = $"delete from registrationTest where registrationID='{label3.Text}'";
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
            //}
            //catch
            //{
            //    MessageBox.Show("请先在表格中选择要删除的记录", "提示信息", MessageBoxButtons.OK, MessageBoxIcon.Error);
            //}
        }

        private void label1_Click(object sender, EventArgs e)
        {

        }

        private void label2_Click(object sender, EventArgs e)
        {

        }

        private void label3_Click(object sender, EventArgs e)
        {

        }

        private void dataGridView1_Click(object sender, EventArgs e)
        {
          
        }

        private void button3_Click(object sender, EventArgs e)
        {
            user14 user = new user14();
            user.ShowDialog();  
        }

        private void button2_Click(object sender, EventArgs e)
        {
            //admin2 admin = new admin2();
            //admin.ShowDialog();
        }

        private void button4_Click(object sender, EventArgs e)
        {
            table();
        }

        private void button5_Click(object sender, EventArgs e)
        {
            user11 user = new user11(); 
            user.ShowDialog();
        }

        private void button6_Click(object sender, EventArgs e)
        {
            athleteTable athleteTable = new athleteTable();
            athleteTable.ShowDialog();
        }
    }
}

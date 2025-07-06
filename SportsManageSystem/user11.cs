using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace SportsManageSystem
{
    public partial class user11 : Form
    {
        public user11()
        {
            InitializeComponent();
        }

        private void user11_Load(object sender, EventArgs e)
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
            string sql = "select * from event";
            IDataReader dc = dao.read(sql);
            while (dc.Read())
            {
                dataGridView1.Rows.Add(dc[0].ToString(), dc[1].ToString(), dc[2].ToString(), dc[3].ToString(), dc[4].ToString());
            }
            dc.Close(); dao.DaoClose();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            this.Hide();

        }
    }
}

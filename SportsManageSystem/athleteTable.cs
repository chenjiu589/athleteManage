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
    public partial class athleteTable : Form
    {
        public athleteTable()
        {
            InitializeComponent();
        }

        private void athleteTable_Load(object sender, EventArgs e)
        {
            table();

        }

        public void table()
        {
            dataGridView1.Rows.Clear(); //清空旧数据
            Dao dao = new Dao();
            string sql = "select * from athlete";
            IDataReader dc = dao.read(sql);
            while (dc.Read())
            {
                dataGridView1.Rows.Add(dc[0].ToString(), dc[1].ToString(), dc[2].ToString(), dc[3].ToString(), dc[4].ToString(), dc[5].ToString(),dc[6].ToString());
            }
            dc.Close(); dao.DaoClose();
        }

        private void button5_Click(object sender, EventArgs e)
        {
            string id = dataGridView1.SelectedRows[0].Cells[0].Value.ToString();
            int athleteID = int.Parse(id);
            AltAthTab altTab = new AltAthTab(athleteID); 
            altTab.ShowDialog();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            table();
        }
    }
}

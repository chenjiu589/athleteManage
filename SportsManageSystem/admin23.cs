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
    public partial class admin23 : Form
    {
        public admin23()
        {
            InitializeComponent();
        }

        private void dataGridView1_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {

        }

        private void admin23_Load(object sender, EventArgs e)
        {
            table();
        }
        public void table()
        {
            dataGridView1.Rows.Clear(); //清空旧数据
            Dao dao = new Dao();
            string sql = "select result.athleteID,athlete.Name,result.EventID,EventName,result.score\r\nfrom result\r\ninner join athlete on athlete.AthleteID=result.AthleteID\r\ninner join event on event.EventID=result.EventID\r\norder by AthleteID";
            IDataReader dc = dao.read(sql);
            while (dc.Read())
            {
                dataGridView1.Rows.Add(dc[0].ToString(), dc[1].ToString(), dc[2].ToString(), dc[3].ToString(), dc[4].ToString());
            }
            dc.Close(); dao.DaoClose();
        }
    }
}

using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Diagnostics;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Xml.Linq;

namespace SportsManageSystem
{
   
    public partial class AltAthTab : Form
    {
        int flag = 0;
        public AltAthTab()
        {
            InitializeComponent();
        }
        public AltAthTab(int athleteID)
        {
            InitializeComponent();
            flag= athleteID;
            Dao dao = new Dao();
            string sql = $"select * from athlete where athleteID = '{athleteID}'";
            IDataReader dr = dao.read(sql);
            while (dr.Read())
            {
                textBox1.Text = dr[1].ToString();
                textBox7.Text = dr[2].ToString();
                textBox2.Text = dr[3].ToString();
                textBox4.Text = dr[4].ToString();
                textBox5.Text = dr[5].ToString();
                textBox6.Text = dr[6].ToString();
            }

        }

        private void button2_Click(object sender, EventArgs e)
        {

            string sql = $"UPDATE athlete set name ='{textBox1.Text}',gender ='{textBox7.Text}',grade ='{textBox2.Text}',birth ='{textBox4.Text}',ClassID ='{textBox5.Text}',phone ='{textBox6.Text}' where AthleteID ={flag}";

            Dao dao = new Dao();

            int result = dao.Execute(sql);

            if (result > 0)
            {
                MessageBox.Show("修改成功！");
                this.Close();
            }
            else
            {
                MessageBox.Show("修改失败！");
            }
            flag = 0;
        }

        private void AltAthTab_Load(object sender, EventArgs e)
        {
       
        }

        private void textBox1_TextChanged(object sender, EventArgs e)
        {

        }
    }
}

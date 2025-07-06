using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using static System.Windows.Forms.VisualStyles.VisualStyleElement;

namespace SportsManageSystem
{
    public partial class user14 : Form
    {
        public user14()
        {
            InitializeComponent();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            if (textBox5.Text != null && textBox6.Text != null)
            {
                Dao dao = new Dao();
                string sql = $"insert into registrationTest(athleteID,eventID) values('{textBox5.Text}','{textBox6.Text}') ;insert into result(athleteID,eventID) values('{textBox5.Text}','{textBox6.Text}') ;";
                int n = dao.Execute(sql);

                if (n > 0 )
                {
                    MessageBox.Show("添加成功");
                }
                else
                {
                    MessageBox.Show("添加失败");
                }

                textBox5.Text = ""; textBox6.Text = "";
            }
            else
            {
                MessageBox.Show("输入不允许有空!");
            }
        }
    }
}

using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Diagnostics;
using System.Drawing;
using System.Linq;
using System.Net.NetworkInformation;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace SportsManageSystem
{
    public partial class user12 : Form
    {
        public user12()
        {
            InitializeComponent();
        }

        private void label7_Click(object sender, EventArgs e)
        {

        }

        private void textBox7_TextChanged(object sender, EventArgs e)
        {

        }

        private void button2_Click(object sender, EventArgs e)
        {
            try
            {
                if (textBox2.Text != null && textBox3.Text != null && textBox4.Text != null && textBox5.Text != null && textBox6.Text != null)
                {
                    Dao dao = new Dao();
                    string sql = $"INSERT INTO Athlete(Name, Gender,grade,birth, classID, Phone)VALUES('{textBox2.Text}', '{textBox4.Text}', '{textBox9.Text}','{textBox8.Text}',{textBox5.Text}, '{textBox6.Text}');DECLARE @last_athlete_id INT; SET @last_athlete_id = SCOPE_IDENTITY(); INSERT INTO RegistrationTest(AthleteID, EventID)VALUES(@last_athlete_id, '{textBox7.Text}');insert into result(athleteID,eventID) values(@last_athlete_id, '{textBox7.Text}')";
                    int n = dao.Execute(sql);
                    if (n > 0)
                    {
                        MessageBox.Show("添加成功");
                    }
                    else
                    {
                       // MessageBox.Show("添加失败");
                    }
                    textBox7.Text = "";

                }
                else
                {
                    MessageBox.Show("输入不允许有空!");
                }
            }
            catch (Exception ex) {

                throw;
            }
         }

        private void button1_Click(object sender, EventArgs e)
        {
            textBox2.Text = ""; textBox4.Text = ""; textBox7.Text = "";
            textBox5.Text = ""; textBox6.Text = ""; textBox8.Text = ""; textBox9.Text = "";
        }

        private void button3_Click(object sender, EventArgs e)
        {
            user13 user = new user13();
            user.ShowDialog();
        }

        private void button4_Click(object sender, EventArgs e)
        {
             athleteTable athleteTable = new athleteTable();
            athleteTable.ShowDialog();

        }

        private void label1_Click(object sender, EventArgs e)
        {

        }

        private void button5_Click(object sender, EventArgs e)
        {

        }
    }
}

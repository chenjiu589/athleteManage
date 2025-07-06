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
    public partial class login : Form
    {
        public login()
        {
            InitializeComponent();
        }

        private void Form1_Load(object sender, EventArgs e)
        {

        }

        private void label1_Click(object sender, EventArgs e)
        {

        }

        private void button1_Click(object sender, EventArgs e)
        {
            if (textBox1.Text != "" && textBox2.Text != "")
            {
                Login();
            }
            else
            {
                MessageBox.Show("输入有空项，请重新输入");
            }

        }
        public void Login()
        {
            if (radioButtonUser.Checked == true)
            {

                Dao dao = new Dao();
                //string sql = "select * from Athlete where AthleteID = '"+textBox1.Text+"'and phone = '"+textBox2.Text+"'";
                string sql = $"select* from Athlete where AthleteID = '{textBox1.Text}' and phone='{textBox2.Text}'";
                //MessageBox.Show(sql);
                IDataReader dc = dao.read(sql);
                if (dc.Read())
                {
                    Data.UID = dc["AthleteID"].ToString();
                    Data.UName = dc["name"].ToString();

                    MessageBox.Show("登录成功!");

                    user1 user = new user1();
                    this.Hide();
                    user.ShowDialog();
                    this.Show();
                }
                else
                {
                    MessageBox.Show("登录失败!");

                }
                dao.DaoClose();
                //MessageBox.Show(dc[0].ToString()+dc["Name"].ToString());
            }
            if (radioButtonAdmin.Checked == true)
            {


                Dao dao = new Dao();
                string sql = $"select* from Judge where JudgeID = '{textBox1.Text}' and phone='{textBox2.Text}'";
                IDataReader dc = dao.read(sql);
                if (dc.Read())
                {
                    Data.UID = dc["JudgeID"].ToString();
                    Data.UName = dc["name"].ToString();

                    MessageBox.Show("登录成功!");
                    admin1 admin = new admin1();
                    this.Hide();
                    admin.ShowDialog();
                    this.Show();
                }
                else
                {
                    MessageBox.Show("登录失败！");

                }
                dao.DaoClose();
                //MessageBox.Show(dc[0].ToString()+dc["Name"].ToString());
            }
            //MessageBox.Show("单选框请先选中");


            if (radioButton1.Checked == true)
            {


                Dao dao = new Dao();
                string sql = $"select* from Judge where JudgeID = '{textBox1.Text}' and phone='{textBox2.Text}'";
                IDataReader dc = dao.read(sql);
                if(textBox1.Text=="1"&& textBox2.Text == "123456789")
                {
                    if (dc.Read())
                    {
                        Data.UID = dc["JudgeID"].ToString();
                        Data.UName = dc["name"].ToString();

                        MessageBox.Show("登录成功!");
                        sport admin = new sport();
                        this.Hide();
                        admin.ShowDialog();
                        this.Show();
                    }
                    else
                    {
                        MessageBox.Show("登录失败！");

                    }
                    dao.DaoClose();
                    //MessageBox.Show(dc[0].ToString()+dc["Name"].ToString())
                }
     
                else
                {
                    MessageBox.Show("不是超级管理员！");
                }

            }


        }


        private void radioButtonAdmin_CheckedChanged(object sender, EventArgs e)
        {

        }
    }
}

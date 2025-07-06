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
    public partial class sport1 : Form
    {
        public sport1()
        {
            InitializeComponent();
        }

        private void button2_Click(object sender, EventArgs e)
        {
            if (textBox1.Text != null && textBox2.Text != null && textBox4.Text != null && textBox5.Text != null && textBox6.Text != null&& textBox3.Text != null)
            {
                Dao dao = new Dao();
                string sql = $"insert into event values('{textBox1.Text}','{textBox2.Text}','{textBox4.Text}','{textBox5.Text}','{textBox6.Text}','{textBox3.Text}')";
                int n = dao.Execute(sql);
                if (n > 0)
                {
                    MessageBox.Show("添加成功");
                }
                else
                {
                    MessageBox.Show("添加失败");
                }
                textBox1.Text = ""; textBox2.Text = ""; textBox4.Text = "";
                textBox5.Text = ""; textBox6.Text = ""; textBox3.Text = "";
            }
            else
            {
                MessageBox.Show("输入不允许有空!");
            }
        }

        private void button1_Click(object sender, EventArgs e)
        {
            textBox1.Text = ""; textBox2.Text = ""; textBox4.Text = "";
            textBox5.Text = ""; textBox6.Text = ""; textBox3.Text = "";
        }
    }
}

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
    public partial class sport2 : Form
    {
        int ID;
        public sport2()
        {
            InitializeComponent();
        }
        public sport2(int flag)
        {
            InitializeComponent();
            ID = flag;
            Dao dao = new Dao();
            string sql = $"select * from event where eventID = '{ID}'";
            IDataReader dr = dao.read(sql);
            while (dr.Read())
            {
                textBox1.Text = dr[0].ToString();
               
                textBox2.Text = dr[1].ToString();
                textBox4.Text = dr[2].ToString();
                textBox6.Text = dr[3].ToString();
                textBox5.Text = dr[4].ToString();
                textBox3.Text = dr[5].ToString();
            }

        }
        private void button2_Click(object sender, EventArgs e)
        {
            string sql = $"update event set defaultunit = '{textBox3.Text}' where eventID = {ID}";





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
        }
    }
}

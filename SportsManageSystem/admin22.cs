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
    public partial class admin22 : Form
    {
        int ID;
        public admin22()
        {
            InitializeComponent();
        }
        //public admin22(string ResultID, string AthleteID, string  EventID, string Score, string Rank, string IsRecord)
        //{
        //    InitializeComponent();
        //    //ID=textBox1.Text = ResultID;
        //    //textBox7.Text = AthleteID; 
        //    //textBox2.Text = EventID;
        //    //textBox4.Text = Score;
        //    //textBox5.Text = Rank;
        //    //textBox6.Text = IsRecord;

            
        //    if (int.TryParse(ResultID, out int number))
        //    {
        //        // 转换成功，将 number 显示在 TextBox
        //        textBox1.Text = number.ToString(); // 直接赋值
        //        ID = textBox1.Text;
        //    }
           
        //    if (int.TryParse(AthleteID, out int number1))
        //    {
        //        // 转换成功，将 number 显示在 TextBox
        //        textBox7.Text = number1.ToString(); // 直接赋值
          
        //    }

        //    if (int.TryParse(EventID, out int number2))
        //    {
        //        // 转换成功，将 number 显示在 TextBox
        //        textBox2.Text = number2.ToString(); // 直接赋值

        //    }

        //    textBox4.Text = Score;

        //    if (int.TryParse(Rank, out int number3))
        //    {
        //        // 转换成功，将 number 显示在 TextBox
        //        textBox5.Text = number3.ToString(); // 直接赋值

        //    }

        //    if (bool.TryParse(IsRecord, out bool number4))
        //    {
        //        // 转换成功，将 number 显示在 TextBox
        //        textBox6.Text = number4.ToString(); // 直接赋值

        //    }
        //}
        public admin22(int flag)
        {
            InitializeComponent();
            ID= flag;
            Dao dao = new Dao();
            string sql = $"select * from result where ResultID = '{ID}'";
            IDataReader dr = dao.read(sql);
            while (dr.Read())
            {
                textBox1.Text = dr[0].ToString();
                textBox7.Text = dr[1].ToString();
                textBox2.Text = dr[2].ToString();
                textBox4.Text = dr[3].ToString();
                textBox5.Text = dr[4].ToString();
                textBox6.Text = dr[5].ToString();
            }

        }
        private void button2_Click(object sender, EventArgs e)
        {
            //string sql = $"update result set ResultID ={textBox1.Text} ,AthleteID={textBox7.Text},Score ='{textBox4.Text}',EventID ={textBox2.Text},[Rank] ={textBox5.Text},IsRecord ={textBox6.Text} where ResultID={ID}";

            //if (dao.Execute(sql)>0)
            //{
            //    MessageBox.Show("修改成功！");
            //    this.Close();

            //}
 

            string sql = $"update result set " +
        
        $"Score = '{textBox4.Text}'" +
      
        $"where ResultID = {ID}";

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

        private void admin22_Load(object sender, EventArgs e)
        {

        }
    }
}

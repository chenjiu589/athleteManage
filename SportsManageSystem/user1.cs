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
    public partial class user1 : Form
    {
        public user1()
        {
            InitializeComponent();
        }

        private void user1_Load(object sender, EventArgs e)
        {

        }

        private void button2_Click(object sender, EventArgs e)
        {

        }

        private void button1_Click(object sender, EventArgs e)
        {
            user11 user = new user11();
           
            user.ShowDialog();
        }

        private void button3_Click(object sender, EventArgs e)
        {
            user12 user = new user12();

            user.ShowDialog();
        }
    }
}

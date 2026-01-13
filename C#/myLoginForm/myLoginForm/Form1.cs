using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace myLoginForm
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }
        Operations op = new Operations();
        User user = new User();
        private void button2_Click(object sender, EventArgs e)
        {
            this.Hide();
            Form2 frm = new Form2();
            frm.Show();
        }

        private void button1_Click(object sender, EventArgs e)
        {

           user.username = this.textBox1.Text;
            user.password = this.textBox2.Text;


            if (op.login(user))
            {
            
                this.Hide();
                Form4 frm = new Form4();
                frm.Show();

                MessageBox.Show("login success!");

            }
            else
            {
                MessageBox.Show("Invalid!");
            }
        }

        private void Form1_Load(object sender, EventArgs e)
        {

        }

        private void linkLabel1_LinkClicked(object sender, LinkLabelLinkClickedEventArgs e)
        {
            this.Hide();
            Form5 f3 = new Form5();
            f3.Show();
        }
    }
}

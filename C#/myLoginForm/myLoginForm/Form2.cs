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
    public partial class Form2 : Form
    {
        public Form2()
        {
            InitializeComponent();
        }
         Operations op = new Operations();
        User user = new User();
   
        private void button2_Click(object sender, EventArgs e)
        {
            user.firstname = textBox1.Text;
            user.lastname = textBox2.Text;
            user.username = textBox3.Text;
            user.password = textBox4.Text;

            if (op.validUser(user)) {
                op.addUser(user);
                MessageBox.Show("User Added");

            }
            else
            {
                MessageBox.Show("üser alredy exist");
            }

            
        }

        private void Form2_Load(object sender, EventArgs e)
        {
            
        }

        private void button1_Click(object sender, EventArgs e)
        {
            this.Hide();
            Form3 f3 = new Form3(); 
            f3.Show();
        }

        private void linkLabel1_LinkClicked(object sender, LinkLabelLinkClickedEventArgs e)
        {
            this.Hide();
            Form5 f3 = new Form5();
            f3.Show();
        }
    }
}

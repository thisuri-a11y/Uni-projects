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
    public partial class Form3 : Form
    {
        public Form3()
        {
            InitializeComponent();
        }

        Operations obj = new Operations();

        private void button1_Click(object sender, EventArgs e)
        {
            string username = this.textBox1.Text;
           var user = obj.view(username);

            label8.Text = user.firstname;
            label7.Text = user.lastname;
            label6.Text = user.username;
            label5.Text = user.password;

        }

        private void textBox1_TextChanged(object sender, EventArgs e)
        {

        }

        private void Form3_Load(object sender, EventArgs e)
        {
          
        }

        private void linkLabel1_LinkClicked(object sender, LinkLabelLinkClickedEventArgs e)
        {
            this.Hide();
            Form5 f3 = new Form5();
            f3.Show();
        }

        private void button2_Click(object sender, EventArgs e)
        {
            string username  = label6.Text;
            string newUsername = textBox1.Text;
            obj.updateUser(username,newUsername);
        }

        private void button3_Click(object sender, EventArgs e)
        {
            string username = label6.Text;
            obj.deleteUser(username);
        }
    }
}

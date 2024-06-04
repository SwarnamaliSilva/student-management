using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using MySql.Data.MySqlClient;


namespace Student_Registration_System
{
    public partial class Form2 : Form
    {
        MySqlConnection connect = new MySqlConnection("Data Source = localhost; Initial Catalog=studentregistrationsystem;" +
            "User ID=root; Password=admin;");
         
        public Form2()
        {
            InitializeComponent();
        }

        private void textBox2_TextChanged(object sender, EventArgs e)
        {

        }

        private void panel1_Paint(object sender, PaintEventArgs e)
        {
            
        }

        private void Form2_Load(object sender, EventArgs e)
        {
            
        }

        

        private void button3_Click(object sender, EventArgs e)
        {
            Form1 f1 = new Form1();
            f1.Show();
            Visible = false;
        }

        private void button1_Click(object sender, EventArgs e)
        {
            if (this.username.Text.Length == 0 || this.password.Text.Length == 0)
            {
                MessageBox.Show("All fields are required!");
            }

            else
            {

                String uname = username.Text.ToString();
                String pass = password.Text.ToString();

                connect.Open();

                String query = "select * from admin_details where username='" + uname + "' and password='" + pass + "'";

                MySqlDataAdapter sqlDA = new MySqlDataAdapter(query, connect);
                DataTable dt = new DataTable();
                sqlDA.Fill(dt);

                if (dt.Rows.Count == 1)
                {

                    if (MessageBox.Show("Login Successful!", "Message", MessageBoxButtons.OK, MessageBoxIcon.Information) == DialogResult.OK)
                    {
                        Form3 ff3 = new Form3();
                        ff3.Show();
                        Visible = false;
                    }
                    connect.Close();

                }
                else
                {
                    if (MessageBox.Show("Please Try Again!", "Message", MessageBoxButtons.OK, MessageBoxIcon.Information) == DialogResult.OK)
                    {
                        username.Text = "";
                        password.Text = "";
                        connect.Close();
                    }

                }

            }

         


        }

        private void showPassword_CheckedChanged(object sender, EventArgs e)
        {
            if(showPassword.Checked == true)
            {
                password.UseSystemPasswordChar = false;
            }

            else
            {
                password.UseSystemPasswordChar = true;
            }
        }
    }
}
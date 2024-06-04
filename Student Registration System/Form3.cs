using MySql.Data.MySqlClient;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;


namespace Student_Registration_System
{
    public partial class Form3 : Form
    {
        MySqlConnection connect = new MySqlConnection("Data Source = localhost; Initial Catalog=studentregistrationsystem;" +
           "User ID=root; Password=admin;");

        public Form3()
        {
            InitializeComponent();
        }

        private void label1_Click(object sender, EventArgs e)
        {

        }

        private void button4_Click(object sender, EventArgs e)
        {
            Form2 f2 = new Form2();
            f2.Show();
            Visible = false;
        }

        private void button5_Click(object sender, EventArgs e)
        {
            Application.Exit();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            AddStudent addstudent = new AddStudent();
            addstudent.Show();
            Visible = false;
        }

        private void UpdateStudent_Click(object sender, EventArgs e)
        {
            UpdateStudent updatestudent = new UpdateStudent();
            updatestudent.Show();
            Visible = false;
        }

        private void RemoveStudent_Click(object sender, EventArgs e)
        {
            RemoveStudent removestudent = new RemoveStudent();
            removestudent.Show();
            Visible = false;
        }

        private void button1_Click_1(object sender, EventArgs e)
        {
            DisplayStudents displaystud = new DisplayStudents();
            displaystud.Show();
            Visible = false;
        }
    }
}

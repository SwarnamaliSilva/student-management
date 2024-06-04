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
    public partial class DisplayStudents : Form
    {
        MySqlConnection connect = new MySqlConnection("Data Source = localhost; Initial Catalog=studentregistrationsystem;" +
           "User ID=root; Password=admin;");

        public DisplayStudents()
        {
            InitializeComponent();
        }

        private void DisplayStudents_Load(object sender, EventArgs e)
        {
            connect.Open();

            MySqlDataAdapter sqlda = new MySqlDataAdapter("select * from student_details", connect);
            DataTable dt = new DataTable();
            sqlda.Fill(dt);

            studentDetails.DataSource = dt;

            connect.Close();


        }

        private void close_Click(object sender, EventArgs e)
        {
            Application.Exit();
        }

        private void Back_Click(object sender, EventArgs e)
        {
            Form3 f3 = new Form3();
            f3.Show();
            Visible = false;
        }
    }
}

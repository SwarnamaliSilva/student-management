using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Xml.Linq;
using MySql.Data.MySqlClient;
using Mysqlx.Crud;
using static System.Windows.Forms.VisualStyles.VisualStyleElement.ListView;
using static System.Windows.Forms.VisualStyles.VisualStyleElement.StartPanel;

namespace Student_Registration_System
{
    public partial class RemoveStudent : Form
    {
        MySqlConnection connect = new MySqlConnection("Data Source = localhost; Initial Catalog=studentregistrationsystem;" +
           "User ID=root; Password=admin;");


        public RemoveStudent()
        {
            InitializeComponent();
        }

        private void Back_Click(object sender, EventArgs e)
        {
            Form3 f3 = new Form3();
            f3.Show();
            Visible = false;
        }

        private void Clear_Click(object sender, EventArgs e)
        {
            enrollno.Text = "";
        }

        private void Remove_Click(object sender, EventArgs e)
        {
            try
            {
                if (enrollno.Text.Length == 0)
                {
                    MessageBox.Show("Student enroll number is required!");
                }
                else
                {
                    DialogResult result = MessageBox.Show("Are you sure you want to remove this student?", "Confirmation", MessageBoxButtons.YesNo, MessageBoxIcon.Question);

                    if (result == DialogResult.Yes)
                    {

                        string deletequry = "delete from student_details where enroll = '" + enrollno.Text + "'";

                        connect.Open();

                        MySqlCommand cmd = new MySqlCommand(deletequry, connect);

                        if (cmd.ExecuteNonQuery() == 1)
                        {
                            MessageBox.Show("Student removed successful!", "Message", MessageBoxButtons.OK, MessageBoxIcon.Information);
                        }

                        else
                        {
                            MessageBox.Show("Student removed unsuccessful!", "Message", MessageBoxButtons.OK, MessageBoxIcon.Information);
                        }

                    }
                    enrollno.Text = "";
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("Can not remove student details!  " + ex.Message);
            }

            connect.Close();

        }
    }
}

using MySql.Data.MySqlClient;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Runtime.Remoting.Contexts;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Text.RegularExpressions;

using static System.Windows.Forms.VisualStyles.VisualStyleElement.StartPanel;
using System.Xml.Linq;

namespace Student_Registration_System
{
    public partial class UpdateStudent : Form
    {
        MySqlConnection connect = new MySqlConnection("Data Source = localhost; Initial Catalog=studentregistrationsystem;" +
           "User ID=root; Password=admin;");

        public UpdateStudent()
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
            nic.Text = "";
            name.Text = "";
            email.Text = "";
            phone.Text = "";
            address.Text = "";

            Male.Checked = false;
            Female.Checked = false;

            birthday.Value = DateTime.Now;
            joindate.Value = DateTime.Now;
        }

        private void update_Click(object sender, EventArgs e)
        {

            try
            {

                if (this.enrollno.Text.Length == 0 || this.nic.Text.Length == 0 || this.name.Text.Length == 0
                || this.email.Text.Length == 0 || this.phone.Text.Length == 0 || this.address.Text.Length == 0
                || this.birthday.Text.Length == 0 || this.joindate.Text.Length == 0)
                {
                    MessageBox.Show("All fields are required!");
                }

                else
                {
                    String enroll = enrollno.Text;
                    String nicnum = nic.Text;
                    String sname = name.Text;
                    String emaill = email.Text;
                    String phonenum = phone.Text;
                    String homeaddress = address.Text;

                    String sgender = Male.Checked ? "Male" : "Female";

                    DateTime birth = birthday.Value;
                    DateTime joinday = joindate.Value;

                    Regex regex = new Regex(@"^([\w-\.]+)@((\[0-9]{1,3}\.[0-9]{1,3}\.)|(([\w-]+\.)+))([a-zA-Z]{2,4}|[0-9]{1,3})(\]?)$");
                    bool isValid = regex.IsMatch(email.Text);
                    if (!isValid)
                    {
                        MessageBox.Show("Invalid email pattern");
                    }

                    else
                    {

                        if (!Male.Checked && !Female.Checked)
                        {
                            MessageBox.Show("Please select a gender.");

                        }

                        else
                        {

                            connect.Open();

                            string query = $"UPDATE student_details SET nicnum = '{nicnum}', sname = '{sname}', " +
                            $"emaill = '{emaill}', phonenum = '{phonenum}', homeaddress = '{homeaddress}'," +
                            $"sgender = '{sgender}', birth = '{birth}', joinday = '{joinday}'" +
                            $" WHERE enroll = '{enrollno.Text}'";

                            MySqlCommand command = new MySqlCommand(query, connect);


                            if (command.ExecuteNonQuery() == 1)
                            {
                                MessageBox.Show("Student updated successful!", "Message", MessageBoxButtons.OK, MessageBoxIcon.Information);
                            }

                            else
                            {
                                MessageBox.Show("Student updated unsuccessful!", "Message", MessageBoxButtons.OK, MessageBoxIcon.Information);
                            }
                        }

                    }
                    enrollno.Text = "";
                    nic.Text = "";
                    name.Text = "";
                    email.Text = "";
                    phone.Text = "";
                    address.Text = "";

                    Male.Checked = false;
                    Female.Checked = false;

                    birthday.Value = DateTime.Now;
                    joindate.Value = DateTime.Now;
                }
                connect.Close();
            }

            catch (Exception ex)
            {
                 MessageBox.Show("Can not update student details!" + ex.Message);
            }
            
            connect.Close();

        }

        private void Submit_Click(object sender, EventArgs e)
        {

            //display relevant data
            try
            {
                if (enrollno.Text.Length == 0)
                {
                    MessageBox.Show("Student enroll number is required!");
                }

                else
                {
                    string deletequry = "select * from student_details where enroll = '" + enrollno.Text + "'";

                    connect.Open();

                    MySqlCommand cmd = new MySqlCommand(deletequry, connect);

                    using (MySqlDataReader reader = cmd.ExecuteReader())
                    {
                        if (reader.Read())
                        {
                            
                            nic.Text = reader["nicnum"].ToString();
                            name.Text = reader["sname"].ToString();
                            email.Text = reader["emaill"].ToString();
                            phone.Text = reader["phonenum"].ToString();
                            address.Text = reader["homeaddress"].ToString();

                            if (reader["sgender"].ToString() == "Male")
                                Male.Checked = true;

                            else if (reader["sgender"].ToString() == "Female")
                                Female.Checked = true;


                            birthday.Value = Convert.ToDateTime(reader["birth"]);
                            joindate.Value = Convert.ToDateTime(reader["joinday"]);
                        }

                        else
                        {
                            MessageBox.Show("Enter correct student enrollment number!", "Message", MessageBoxButtons.OK, MessageBoxIcon.Error);
                            enrollno.Text = "";
                        }
                    }                   
                }
            }

    
            catch (Exception ex)
            {
                MessageBox.Show("Can not find student enroll number! " + ex.Message);
                enrollno.Text = "";
            }

            connect.Close();


        }
    }
}

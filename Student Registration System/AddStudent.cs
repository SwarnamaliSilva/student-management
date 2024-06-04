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
using System.Text.RegularExpressions;

namespace Student_Registration_System
{
    public partial class AddStudent : Form
    {
        MySqlConnection connect = new MySqlConnection("Data Source = localhost; Initial Catalog=studentregistrationsystem;" +
           "User ID=root; Password=admin;");
        public AddStudent()
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

        private void Add_Click(object sender, EventArgs e)
        {
            
            try
            {
                //add deatils 


                if (this.enrollno.Text.Length == 0 || this.nic.Text.Length == 0 || this.name.Text.Length == 0
                    || this.email.Text.Length == 0 || this.phone.Text.Length == 0 || this.address.Text.Length == 0
                    || this.birthday.Text.Length == 0 || this.joindate.Text.Length == 0)
                {
                    MessageBox.Show("All fields are required!");
                }

                else
                {

                    String enroll = enrollno.Text.ToString();
                    String nicnum = nic.Text.ToString();
                    String sname = name.Text.ToString();
                    String emaill = email.Text.ToString();
                    String phonenum = phone.Text.ToString();
                    String homeaddress = address.Text.ToString();

                    String sgender;

                    if (Male.Checked)
                        sgender = "Male";
                    else
                        sgender = "Female";

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

                        connect.Open();

                        MySqlCommand cmdenrol = new MySqlCommand("select enroll from student_details where enroll = '" +enrollno.Text+ "'",connect);
                        string enrollnum = (string)cmdenrol.ExecuteScalar();

                        if (enrollnum == enrollno.Text)
                        {
                            MessageBox.Show("Already exist enrollment number!");
                        }

                        else
                        {
                            if (!Male.Checked && !Female.Checked)
                            {
                                MessageBox.Show("Please select a gender.");
                                
                            }


                            else
                            {

                                String query = "insert into student_details(enroll,nicnum,sname,emaill,phonenum,homeaddress," +
                                    "sgender,birth,joinday)" +
                                    "values ('" + enroll + "','" + nicnum + "','" + sname + "','" + emaill + "','" + phonenum + "','" + homeaddress + "','" + sgender + "','" + birth + "','" + joinday + "')";

                                MySqlCommand cmd = new MySqlCommand(query, connect);
                                int x = cmd.ExecuteNonQuery();

                                if (x >= 1)
                                    MessageBox.Show("Student added successful!", "Message", MessageBoxButtons.OK, MessageBoxIcon.Information);


                                else
                                    MessageBox.Show("Student added unsuccessful!", "Message", MessageBoxButtons.OK, MessageBoxIcon.Information);
                            }

                        }
                    }
                }
                connect.Close();

            }

            catch (Exception ec)
            {
                MessageBox.Show("Can not add student details!" + ec.Message);
                connect.Close();

            }

            Clear_Click(sender, e);
        }
    }
}

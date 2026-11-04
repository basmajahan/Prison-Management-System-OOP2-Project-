using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Data.SqlClient;
using static System.Windows.Forms.VisualStyles.VisualStyleElement;

namespace Prison_Management_System
{
    public partial class HomePage : Form
    {
        public HomePage()
        {
            InitializeComponent();
            textBox1.PasswordChar = '●';
            button4.Visible = true;
            button5.Visible = false;
        }

        private void button1_Click(object sender, EventArgs e)
        {
            Application.Exit();
        }

        private void button2_Click(object sender, EventArgs e)
        {
            Registration reg = new Registration();
            reg.Show();
            this.Hide();
        }

        private void button3_Click(object sender, EventArgs e)
        {

            if (comboBox1.SelectedItem == null)
            {
                MessageBox.Show("Please select a role first.", "Validation Error", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }


            if (string.IsNullOrWhiteSpace(textBox5.Text) || string.IsNullOrWhiteSpace(textBox1.Text))
            {
                MessageBox.Show("Please enter NID and Password.", "Validation Error", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            string selectedRole = comboBox1.SelectedItem.ToString();
            string enteredNID = textBox5.Text.Trim();
            string enteredPassword = textBox1.Text.Trim();

            if (enteredNID.Length != 8)
            {
                MessageBox.Show("NID must be exactly 8 digits long.", "Validation Error", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                textBox5.Focus();
                return;
            }


            string connectionString = "Data Source=.\\SQLEXPRESS;Initial Catalog=\"Prison Mnagement System\";Integrated Security=True;Encrypt=True;TrustServerCertificate=True";

            if (selectedRole == "Admin")
            {

                string query = @"SELECT Admin_NID, Admin_Email 
                 FROM Admin
                 WHERE Admin_NID = @Admin_NID 
                 AND Password = @Password";

                try
                {
                    using (SqlConnection con = new SqlConnection(connectionString))
                    {
                        con.Open();
                        using (SqlCommand cmd = new SqlCommand(query, con))
                        {
                            cmd.Parameters.AddWithValue("@Admin_NID", enteredNID);
                            cmd.Parameters.AddWithValue("@Password", enteredPassword);

                            using (SqlDataReader reader = cmd.ExecuteReader())
                            {
                                if (reader.Read())
                                {
                                    string adminEmail = reader["Admin_Email"] != DBNull.Value
                                ? reader["Admin_Email"].ToString()
                                : "";

                                    if (string.IsNullOrWhiteSpace(adminEmail))
                                    {
                                        MessageBox.Show(
                                            "No email found for this Admin account.\n\n" +
                                            "Please run this SQL first:\n" +
                                            "UPDATE Admin SET Admin_Email = 'your@gmail.com'\n" +
                                            "WHERE Admin_NID = '" + enteredNID + "'",
                                            "Email Not Set",
                                            MessageBoxButtons.OK,
                                            MessageBoxIcon.Warning);
                                        return;
                                    }

                                    Admin admin = new Admin();
                                    admin.Show();
                                    this.Hide();
                                }
                                else
                                {
                                    MessageBox.Show("Incorrect Admin NID or Password.\nPlease try again.", "Access Denied", MessageBoxButtons.OK, MessageBoxIcon.Error);
                                }
                            }
                        }
                    }
                }
                catch (SqlException ex)
                {
                    MessageBox.Show("Database Error:\n" + ex.Message, "SQL Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
                catch (Exception ex)
                {
                    MessageBox.Show("Unexpected Error:\n" + ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
            }

            else if (selectedRole == "Officer")
            {

                string query = @"SELECT Officer_NID 
                         FROM Officers
                         WHERE Officer_NID = @Officer_NID 
                         AND Create_Password = @Password";

                try
                {
                    using (SqlConnection con = new SqlConnection(connectionString))
                    {
                        con.Open();
                        using (SqlCommand cmd = new SqlCommand(query, con))
                        {
                            cmd.Parameters.AddWithValue("@Officer_NID", enteredNID);
                            cmd.Parameters.AddWithValue("@Password", enteredPassword);

                            using (SqlDataReader reader = cmd.ExecuteReader())
                            {
                                if (reader.Read())
                                {
                                    // This passes the active NID securely to your updated constructor
                                    Officer_Dashboard_ od1 = new Officer_Dashboard_(enteredNID);
                                    od1.Show();
                                    this.Hide();
                                }
                                else
                                {
                                    MessageBox.Show("Incorrect Officer NID or Password.\nPlease try again.", "Access Denied", MessageBoxButtons.OK, MessageBoxIcon.Error);
                                }
                            }
                        }
                    }
                }
                catch (SqlException ex)
                {
                    MessageBox.Show("Database Error:\n" + ex.Message, "SQL Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
                catch (Exception ex)
                {
                    MessageBox.Show("Unexpected Error:\n" + ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
            }
            else if (selectedRole == "Visitor")
            {

                string query = @"SELECT 
                            Visitor_NID, 
                            Visitor_Name, 
                            Email, 
                            Prisoner_ID 
                         FROM Visitors 
                         WHERE Visitor_NID      = @Visitor_NID 
                         AND   Create_Password  = @Password";

                try
                {
                    using (SqlConnection con = new SqlConnection(connectionString))
                    {
                        con.Open();
                        using (SqlCommand cmd = new SqlCommand(query, con))
                        {
                            cmd.Parameters.AddWithValue("@Visitor_NID", enteredNID);
                            cmd.Parameters.AddWithValue("@Password", enteredPassword);

                            using (SqlDataReader reader = cmd.ExecuteReader())
                            {
                                if (reader.Read())
                                {
                                    string visitorNID = reader["Visitor_NID"].ToString();
                                    string visitorName = reader["Visitor_Name"].ToString();
                                    string visitorEmail = reader["Email"].ToString();
                                    int prisonerID = Convert.ToInt32(reader["Prisoner_ID"]);

                                    Visit visitPage = new Visit(
                                        visitorNID,
                                        visitorName,
                                        visitorEmail,
                                        prisonerID
                                    );
                                    visitPage.Show();
                                    this.Hide();
                                }
                                else
                                {
                                    MessageBox.Show(
                                        "Incorrect NID or Password.\nPlease try again.",
                                        "Access Denied",
                                        MessageBoxButtons.OK,
                                        MessageBoxIcon.Error
                                    );
                                }
                            }
                        }
                    }
                }
                catch (SqlException ex)
                {
                    MessageBox.Show("Database Error:\n" + ex.Message, "SQL Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
                catch (Exception ex)
                {
                    MessageBox.Show("Unexpected Error:\n" + ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }

            }
            else
            {
                MessageBox.Show("Invalid role selected.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void textBox5_TextChanged(object sender, EventArgs e)
        {
            string input = textBox5.Text;

            string digitsOnly = new string(input.Where(char.IsDigit).ToArray());
            if (input != digitsOnly)
            {
                int cursorPos = textBox5.SelectionStart - (input.Length - digitsOnly.Length);
                textBox5.Text = digitsOnly;
                textBox5.SelectionStart = Math.Max(0, cursorPos);
            }
        }

        private void button4_Click(object sender, EventArgs e)
        {
            textBox1.PasswordChar = '\0';
            button4.Visible = false;
            button5.Visible = true;
            textBox1.Focus();
        }

        private void button5_Click(object sender, EventArgs e)
        {
            textBox1.PasswordChar = '●';
            button5.Visible = false;
            button4.Visible = true;
            textBox1.Focus();
        }

        private void HomePage_Load(object sender, EventArgs e)
        {
            textBox5.MaxLength = 8;
        }

        private void textBox1_TextChanged(object sender, EventArgs e)
        {
        }

        private void comboBox1_SelectedIndexChanged(object sender, EventArgs e)
        {
        }

        private void pictureBox1_Click(object sender, EventArgs e)
        {

        }

        private void label1_Click(object sender, EventArgs e)
        {

        }
    }
}
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Data.SqlClient;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using TextBox = System.Windows.Forms.TextBox;
using static System.Windows.Forms.VisualStyles.VisualStyleElement;

namespace Prison_Management_System
{
    public partial class Registration : Form
    {
        public Registration()
        {
            InitializeComponent();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            HomePage home = new HomePage();

            home.Show();

            this.Close();
        }

        private void comboBox2_SelectedIndexChanged(object sender, EventArgs e)
        {

        }

        private void textBox2_TextChanged(object sender, EventArgs e)
        {
            string input = textBox2.Text.Trim();

            string[] allowed = { "Father", "Mother", "Brother", "Sister", "Lawyer", "Friends" };

            if (allowed.Contains(input))
            {
                textBox2.ForeColor = Color.Green;
            }
            else
            {
                if (input.Length > 7)
                {
                    MessageBox.Show("Permission Denied");
                    textBox2.Clear();
                }
            }
        }

        private void button2_Click(object sender, EventArgs e)
        {

            List<TextBox> allInputs = new List<TextBox> { textBox1, textBox2, textBox3, textBox4, textBox5 };

                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                   
            bool isAnyFieldEmpty = allInputs.Any(tb => string.IsNullOrWhiteSpace(tb.Text));

            if (isAnyFieldEmpty)
            {
                MessageBox.Show("Please do not leave any textbox blank.", "Validation Error", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }


            string[] allowed = { "Father", "Mother", "Brother", "Sister", "Lawyer", "Friends" };
            string relationInput = textBox2.Text.Trim();


            if (allowed.Any(r => r.Equals(relationInput, StringComparison.OrdinalIgnoreCase)))
            {

                string connectionString = "Data Source=.\\SQLEXPRESS;Initial Catalog=\"Prison Mnagement System\";Integrated Security=True;Encrypt=True;TrustServerCertificate=True";

                string query = @"INSERT INTO Visitors 
                            (Visitor_NID, Visitor_Name, Date_Of_Birth, Gender, Prisoner_ID, Relation, Email, Create_Password)
                         VALUES 
                            (@Visitor_NID, @Visitor_Name, @Date_Of_Birth, @Gender, @Prisoner_ID, @Relation, @Email, @Create_Password)";

                try
                {
                    using (SqlConnection con = new SqlConnection(connectionString))
                    {
                        con.Open();

                        using (SqlCommand cmd = new SqlCommand(query, con))
                        {
                            cmd.Parameters.AddWithValue("@Visitor_NID", textBox4.Text.Trim());
                            cmd.Parameters.AddWithValue("@Visitor_Name", textBox5.Text.Trim());
                            cmd.Parameters.AddWithValue("@Date_Of_Birth", dateTimePicker1.Value.Date);
                            cmd.Parameters.AddWithValue("@Gender", comboBox1.Text.Trim());
                            cmd.Parameters.AddWithValue("@Prisoner_ID", int.Parse(textBox6.Text.Trim()));
                            cmd.Parameters.AddWithValue("@Relation", textBox2.Text.Trim());
                            cmd.Parameters.AddWithValue("@Email", textBox1.Text.Trim());
                            cmd.Parameters.AddWithValue("@Create_Password", textBox3.Text.Trim());

                            int rowsAffected = cmd.ExecuteNonQuery();

                            if (rowsAffected > 0)
                            {
                                MessageBox.Show("Registration Successful!", "Success", MessageBoxButtons.OK, MessageBoxIcon.Information);
                                HomePage home = new HomePage();
                                home.Show();
                                this.Close();
                            }
                            else
                            {
                                MessageBox.Show("Registration failed. Please try again.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                            }
                        }
                    }
                }
                catch (SqlException ex)
                {
                    if (ex.Number == 2627 || ex.Number == 2601)
                    {
                        MessageBox.Show("This Visitor NID already exists in the system.", "Duplicate Entry", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    }
                    else
                    {
                        MessageBox.Show("Database Error:\n" + ex.Message, "SQL Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    }
                }
                catch (FormatException)
                {
                    MessageBox.Show("Prisoner ID must be a valid number.", "Format Error", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                }
                catch (Exception ex)
                {
                    MessageBox.Show("Unexpected Error:\n" + ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }

            }
            else
            {
                MessageBox.Show("Permission Denied. Only specific relations are allowed.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                textBox2.Clear();
                textBox2.Focus();
            }
        }
        private void textBox1_TextChanged(object sender, EventArgs e)
        {

        }

        private void textBox4_TextChanged(object sender, EventArgs e)
        {
            textBox4.MaxLength = 8;

            string input = textBox4.Text;


            string digitsOnly = new string(input.Where(char.IsDigit).ToArray());

            if (input != digitsOnly)
            {
                int cursorPos = textBox4.SelectionStart - (input.Length - digitsOnly.Length);
                textBox4.Text = digitsOnly;
                textBox4.SelectionStart = Math.Max(0, cursorPos); 
            }
        }

        private void label5_Click(object sender, EventArgs e)
        {

        }

        private void textBox6_TextChanged(object sender, EventArgs e)
        {


            string input = textBox6.Text;

            string digitsOnly = new string(input.Where(char.IsDigit).ToArray());

            if (input != digitsOnly)
            {
                int cursorPos = textBox6.SelectionStart - (input.Length - digitsOnly.Length);
                textBox6.Text = digitsOnly;
                textBox6.SelectionStart = Math.Max(0, cursorPos);
            }
        }

        private void comboBox1_SelectedIndexChanged(object sender, EventArgs e)
        {

        }

        private void textBox3_TextChanged(object sender, EventArgs e)
        {
            
        }

        private void textBox5_TextChanged(object sender, EventArgs e)
        {

        }

        private void dateTimePicker1_ValueChanged(object sender, EventArgs e)
        {
            if (dateTimePicker1.Value.Date > DateTime.Today)
            {
                MessageBox.Show("Date of Birth cannot be in the future.", "Validation Error", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                dateTimePicker1.Focus();
                return;
            }
        }

        private void textBox1_TextChanged_1(object sender, EventArgs e)
        {

        }
    }
}

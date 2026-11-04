using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data.SqlClient;
using System.Windows.Forms;

namespace Prison_Management_System
{
    public partial class Visit : Form
    {
        private string _visitorNID;
        private string _visitorName;
        private string _visitorEmail;
        private int _prisonerID;

        public Visit(string visitorNID, string visitorName, string visitorEmail, int prisonerID)
        {
            InitializeComponent();
            _visitorNID = visitorNID;
            _visitorName = visitorName;
            _visitorEmail = visitorEmail;
            _prisonerID = prisonerID;
        }

        private void Visit_Load(object sender, EventArgs e)
        {

            label1.Text = $"Welcome, {_visitorName}";


            dateTimePicker1.MinDate = DateTime.Today;


            comboBox1.SelectedIndex = 0; 
            comboBox2.SelectedIndex = 0; 
        }


        private void button2_Click(object sender, EventArgs e)
        {

            if (comboBox1.SelectedIndex == -1 ||
                comboBox2.SelectedIndex == -1)
            {
                MessageBox.Show(
                    "Please select Visit Hour and Duration.",
                    "Validation Error",
                    MessageBoxButtons.OK,
                    MessageBoxIcon.Warning
                );
                return;
            }


            if (dateTimePicker1.Value.Date < DateTime.Today)
            {
                MessageBox.Show(
                    "Visit Date cannot be in the past.",
                    "Validation Error",
                    MessageBoxButtons.OK,
                    MessageBoxIcon.Warning
                );
                return;
            }


            string connectionString = "Data Source=.\\SQLEXPRESS;Initial Catalog=\"Prison Mnagement System\";Integrated Security=True;Encrypt=True;TrustServerCertificate=True";

            string query = @"INSERT INTO VisitRequests 
                                (Visitor_NID, Visitor_Name, Visitor_Email, Prisoner_ID, 
                                 Visit_Date, Visit_Hour, Visit_Duration, Status)
                             VALUES 
                                (@Visitor_NID, @Visitor_Name, @Visitor_Email, @Prisoner_ID,
                                 @Visit_Date, @Visit_Hour, @Visit_Duration, 'Pending')";

            try
            {
                using (SqlConnection con = new SqlConnection(connectionString))
                {
                    con.Open();
                    using (SqlCommand cmd = new SqlCommand(query, con))
                    {
                        cmd.Parameters.AddWithValue("@Visitor_NID", _visitorNID);
                        cmd.Parameters.AddWithValue("@Visitor_Name", _visitorName);
                        cmd.Parameters.AddWithValue("@Visitor_Email", _visitorEmail);
                        cmd.Parameters.AddWithValue("@Prisoner_ID", _prisonerID);
                        cmd.Parameters.AddWithValue("@Visit_Date", dateTimePicker1.Value.Date);
                        cmd.Parameters.AddWithValue("@Visit_Hour", comboBox1.SelectedItem.ToString());
                        cmd.Parameters.AddWithValue("@Visit_Duration", comboBox2.SelectedItem.ToString());

                        int rowsAffected = cmd.ExecuteNonQuery();

                        if (rowsAffected > 0)
                        {
                            MessageBox.Show(
                                "Your visit request has been submitted successfully!\n\n" +
                                $"Visit Date     : {dateTimePicker1.Value.Date.ToString("yyyy-MM-dd")}\n" +
                                $"Visit Hour     : {comboBox1.SelectedItem}\n" +
                                $"Visit Duration : {comboBox2.SelectedItem}\n\n" +
                                "Please wait for Admin approval.\nYou will receive an email once decided.",
                                "Request Submitted",
                                MessageBoxButtons.OK,
                                MessageBoxIcon.Information
                            );


                            dateTimePicker1.Value = DateTime.Today;
                            comboBox1.SelectedIndex = 0;
                            comboBox2.SelectedIndex = 0;
                        }
                    }
                }
            }
            catch (SqlException ex)
            {
                MessageBox.Show(
                    "Database Error:\n" + ex.Message,
                    "SQL Error",
                    MessageBoxButtons.OK,
                    MessageBoxIcon.Error
                );
            }
            catch (Exception ex)
            {
                MessageBox.Show(
                    "Unexpected Error:\n" + ex.Message,
                    "Error",
                    MessageBoxButtons.OK,
                    MessageBoxIcon.Error
                );
            }
        }


        private void button1_Click(object sender, EventArgs e)
        {
            HomePage home = new HomePage();
            home.Show();
            this.Hide();
        }

        private void comboBox1_SelectedIndexChanged(object sender, EventArgs e)
        {

        }
    }
}
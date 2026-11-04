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

namespace Prison_Management_System
{
    public partial class Prisoner_Dashboard_ : Form
    {
        public Prisoner_Dashboard_()
        {
            InitializeComponent();
        }

        private void Prisoner_Dashboard__Load(object sender, EventArgs e)
        {

        }

        private void button1_Click(object sender, EventArgs e)
        {
            Officer_Dashboard_ od1 = new Officer_Dashboard_();
            od1.Show();
            this.Hide();
        }

        private void label1_Click(object sender, EventArgs e)
        {

        }

        private void button2_Click(object sender, EventArgs e)
        {

            if (string.IsNullOrWhiteSpace(textBox1.Text) || string.IsNullOrWhiteSpace(textBox2.Text))
            {
                MessageBox.Show("Pleasae fill up Prisoner Name and Prisoner ID first", "Validation Error", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            if (!int.TryParse(textBox2.Text.Trim(), out int prisonerID))
            {
                MessageBox.Show("Prisoner ID must be matched", "Validation Error", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                textBox2.Focus();
                return;
            }

            string prisonerName = textBox1.Text.Trim();

            string connectionString = "Data Source=.\\SQLEXPRESS;Initial Catalog=\"Prison Mnagement System\";Integrated Security=True;Encrypt=True;TrustServerCertificate=True";

            string query = @"SELECT 
                        Prisoner_ID, 
                        Prisoner_Name, 
                        Prisoner_NID, 
                        Prisoner_Age, 
                        Date_Of_Birth, 
                        Crime_Type, 
                        Admission_Date, 
                        Discharge_Date, 
                        Cell_ID, 
                        Prisoner_Rating 
                     FROM Prisoners 
                     WHERE Prisoner_ID = @PrisonerID AND Prisoner_Name LIKE @PrisonerName";

            try
            {
                using (SqlConnection con = new SqlConnection(connectionString))
                {
                    con.Open();

                    using (SqlCommand cmd = new SqlCommand(query, con))
                    {

                        cmd.Parameters.AddWithValue("@PrisonerID", prisonerID);

                        cmd.Parameters.AddWithValue("@PrisonerName", "%" + prisonerName + "%");

                        SqlDataAdapter adapter = new SqlDataAdapter(cmd);
                        DataTable dt = new DataTable();
                        adapter.Fill(dt);

                        if (dt.Rows.Count > 0)
                        {

                            dataGridView1.DataSource = dt;
                            dataGridView1.Visible = true;

                            dataGridView1.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.Fill;
                            dataGridView1.RowHeadersVisible = false;
                            dataGridView1.AllowUserToAddRows = false;
                            dataGridView1.ReadOnly = true;
                            dataGridView1.SelectionMode = DataGridViewSelectionMode.FullRowSelect;
                            dataGridView1.BackgroundColor = System.Drawing.Color.White;
                            dataGridView1.BorderStyle = BorderStyle.None;
                            dataGridView1.ColumnHeadersDefaultCellStyle.Font = new System.Drawing.Font("Segoe UI", 10f, System.Drawing.FontStyle.Bold);
                            dataGridView1.DefaultCellStyle.Font = new System.Drawing.Font("Segoe UI", 9f);
                            dataGridView1.AlternatingRowsDefaultCellStyle.BackColor = System.Drawing.Color.FromArgb(240, 240, 240);

                            if (label1 != null)
                            {
                                label1.Text = $"Found {dt.Rows.Count} Prisoner Record(s).";
                                label1.Visible = true;
                            }
                        }
                        else
                        {

                            dataGridView1.DataSource = null;
                            MessageBox.Show("No prisoner information was found based on the Name and ID provided.", "Information not found.", MessageBoxButtons.OK, MessageBoxIcon.Information);

                            if (label1 != null) label1.Visible = false;
                        }
                    }
                }
            }
            catch (SqlException ex)
            {
                MessageBox.Show("Error:\n" + ex.Message, "SQL Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
            catch (Exception ex)
            {
                MessageBox.Show("An unexpected error occurred.:\n" + ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void textBox1_TextChanged(object sender, EventArgs e)
        {

        }

        private void textBox2_TextChanged(object sender, EventArgs e)
        {

        }
    }
}

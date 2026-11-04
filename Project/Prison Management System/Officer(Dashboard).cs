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
    public partial class Officer_Dashboard_ : Form
    {
        private string _officerNID = "";


        public Officer_Dashboard_()
        {
            InitializeComponent();
        }


        public Officer_Dashboard_(string nid)
        {
            InitializeComponent();
            _officerNID = nid;
        }

        private void button3_Click(object sender, EventArgs e)
        {
            Prisoner_Dashboard_ pd1 = new Prisoner_Dashboard_();
            pd1.Show();
            this.Hide();
        }

        private void button5_Click(object sender, EventArgs e)
        {
            HomePage hp1 = new HomePage();
            hp1.Show();
            this.Hide();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            Prisoner_Rating_ pr1 = new Prisoner_Rating_();
            pr1.Show();
            this.Hide();
        }

        private void label1_Click(object sender, EventArgs e)
        {

        }

        private void button2_Click(object sender, EventArgs e)
        {

        }

        private void button4_Click(object sender, EventArgs e)
        {

            if (string.IsNullOrEmpty(_officerNID))
            {
                MessageBox.Show("Officer session expired or NID not found. Please log in again.", "Session Error", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            string connectionString = "Data Source=.\\SQLEXPRESS;Initial Catalog=\"Prison Mnagement System\";Integrated Security=True;Encrypt=True;TrustServerCertificate=True";


            string query = "SELECT Officer_ID, Officer_Name, Officer_NID, Shift FROM Officers WHERE Officer_NID = @OfficerNID";

            try
            {
                using (SqlConnection con = new SqlConnection(connectionString))
                {
                    con.Open();
                    using (SqlCommand cmd = new SqlCommand(query, con))
                    {
                        cmd.Parameters.AddWithValue("@OfficerNID", _officerNID);

                        SqlDataAdapter adapter = new SqlDataAdapter(cmd);
                        DataTable dt = new DataTable();
                        adapter.Fill(dt);


                        dataGridView2.Columns.Clear();

                        if (dt.Rows.Count > 0)
                        {

                            dataGridView1.Visible = false;



                            dataGridView2.DataSource = dt;
                            dataGridView2.Visible = true;


                            dataGridView2.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.Fill;
                            dataGridView2.RowHeadersVisible = false;
                            dataGridView2.AllowUserToAddRows = false;
                            dataGridView2.ReadOnly = true;
                            dataGridView2.SelectionMode = DataGridViewSelectionMode.FullRowSelect;
                            dataGridView2.BackgroundColor = System.Drawing.Color.White;
                            dataGridView2.BorderStyle = BorderStyle.None;
                            dataGridView2.ColumnHeadersDefaultCellStyle.Font = new System.Drawing.Font("Segoe UI", 10f, System.Drawing.FontStyle.Bold);
                            dataGridView2.DefaultCellStyle.Font = new System.Drawing.Font("Segoe UI", 9f);
                            dataGridView2.AlternatingRowsDefaultCellStyle.BackColor = System.Drawing.Color.FromArgb(240, 240, 240);
                        }
                        else
                        {
                            dataGridView2.DataSource = null;
                            MessageBox.Show("No shift records or active assignments were found for your NID profile.", "Data Unavailable", MessageBoxButtons.OK, MessageBoxIcon.Information);
                        }
                    }
                }
            }
            catch (SqlException ex)
            {
                MessageBox.Show("Database Connection Error:\n" + ex.Message, "SQL Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
            catch (Exception ex)
            {
                MessageBox.Show("An unexpected layout or runtime error occurred:\n" + ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void Officer_Dashboard__Load(object sender, EventArgs e)
        {

        }

        private void dataGridView2_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {

        }
    }
}
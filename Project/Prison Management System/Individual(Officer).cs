using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Data.SqlClient;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Prison_Management_System
{
    public partial class Individual_Officer_ : Form
    {
        private readonly string connectionString =
            "Data Source=.\\SQLEXPRESS;Initial Catalog=\"Prison Mnagement System\";Integrated Security=True;Encrypt=True;TrustServerCertificate=True";

        public Individual_Officer_()
        {
            InitializeComponent();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            Admin adm = new Admin();
            adm.Show();
            this.Hide();
        }


        private void button2_Click(object sender, EventArgs e)
        {
            if (string.IsNullOrWhiteSpace(textBox1.Text) ||
                string.IsNullOrWhiteSpace(textBox2.Text))
            {
                MessageBox.Show("Please enter both Officer Name and Officer ID to search.",
                    "Validation Error", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            if (!int.TryParse(textBox2.Text.Trim(), out int officerID))
            {
                MessageBox.Show("Officer ID must be a valid number.",
                    "Validation Error", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                textBox2.Focus();
                return;
            }

            string query = @"SELECT 
                        Officer_ID,
                        Officer_NID,
                        Officer_Contact,
                        Email,
                        Shift,
                        Status,
                        Officer_Photo
                     FROM Officers
                     WHERE Officer_Name = @Officer_Name 
                     AND Officer_ID = @Officer_ID";

            try
            {
                using (SqlConnection con = new SqlConnection(connectionString))
                {
                    con.Open();

                    using (SqlCommand cmd = new SqlCommand(query, con))
                    {
                        cmd.Parameters.AddWithValue("@Officer_Name", textBox1.Text.Trim());
                        cmd.Parameters.AddWithValue("@Officer_ID", officerID);

                        using (SqlDataReader reader = cmd.ExecuteReader())
                        {
                            if (reader.Read())
                            {
                                string officerNID = reader["Officer_NID"].ToString();
                                string officerContact = reader["Officer_Contact"].ToString();
                                string email = reader["Email"].ToString();
                                string shift = reader["Shift"].ToString();
                                string status = reader["Status"].ToString();


                                if (reader["Officer_Photo"] != DBNull.Value)
                                {
                                    byte[] photoBytes = (byte[])reader["Officer_Photo"];
                                    using (MemoryStream ms = new MemoryStream(photoBytes))
                                    {
                                        pictureBox1.Image = Image.FromStream(ms);
                                        pictureBox1.SizeMode = PictureBoxSizeMode.Zoom;
                                    }
                                }
                                else
                                {

                                    pictureBox1.Image = SystemIcons.Shield.ToBitmap();
                                    pictureBox1.SizeMode = PictureBoxSizeMode.Zoom;
                                }

                                string message =
                                    $"========== Officer Information ==========\n\n" +
                                    $"Officer ID       : {officerID}\n" +
                                    $"Officer Name     : {textBox1.Text.Trim()}\n" +
                                    $"Officer NID      : {officerNID}\n" +
                                    $"Officer Contact  : {officerContact}\n" +
                                    $"Email            : {email}\n" +
                                    $"Shift            : {shift}\n" +
                                    $"Status           : {status}\n\n" +
                                    $"=========================================";

                                MessageBox.Show(message, "Officer Found",
                                    MessageBoxButtons.OK, MessageBoxIcon.Information);
                            }
                            else
                            {

                                pictureBox1.Image = SystemIcons.Shield.ToBitmap();

                                MessageBox.Show(
                                    "No Officer found with the given Name and ID.\nPlease check and try again.",
                                    "Not Found", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                            }
                        }
                    }
                }
            }
            catch (SqlException ex)
            {
                MessageBox.Show("Database Error:\n" + ex.Message, "SQL Error",
                    MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
            catch (Exception ex)
            {
                MessageBox.Show("Unexpected Error:\n" + ex.Message, "Error",
                    MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }


        private void button3_Click(object sender, EventArgs e)
        {
            if (string.IsNullOrWhiteSpace(textBox1.Text) ||
                string.IsNullOrWhiteSpace(textBox2.Text))
            {
                MessageBox.Show("Please enter both Officer Name and Officer ID to delete.",
                    "Validation Error", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            if (!int.TryParse(textBox2.Text.Trim(), out int officerID))
            {
                MessageBox.Show("Officer ID must be a valid number.",
                    "Validation Error", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                textBox2.Focus();
                return;
            }

            DialogResult confirm = MessageBox.Show(
                $"Are you sure you want to delete Officer:\n\n" +
                $"Name : {textBox1.Text.Trim()}\n" +
                $"ID   : {officerID}\n\n" +
                $"⚠️ This will also delete the Officer's photo.\n" +
                $"This action cannot be undone!",
                "Confirm Delete",
                MessageBoxButtons.YesNo,
                MessageBoxIcon.Warning);

            if (confirm == DialogResult.No) return;

            string checkQuery = @"SELECT COUNT(*) FROM Officers 
                                  WHERE Officer_Name = @Officer_Name 
                                  AND Officer_ID = @Officer_ID";


            string clearPhotoQuery = @"UPDATE Officers 
                                       SET Officer_Photo = NULL 
                                       WHERE Officer_Name = @Officer_Name 
                                       AND Officer_ID = @Officer_ID";

            string deleteQuery = @"DELETE FROM Officers 
                                   WHERE Officer_Name = @Officer_Name 
                                   AND Officer_ID = @Officer_ID";

            try
            {
                using (SqlConnection con = new SqlConnection(connectionString))
                {
                    con.Open();


                    using (SqlCommand checkCmd = new SqlCommand(checkQuery, con))
                    {
                        checkCmd.Parameters.AddWithValue("@Officer_Name", textBox1.Text.Trim());
                        checkCmd.Parameters.AddWithValue("@Officer_ID", officerID);

                        int count = (int)checkCmd.ExecuteScalar();

                        if (count == 0)
                        {
                            MessageBox.Show(
                                "No Officer found with the given Name and ID.\nDeletion cancelled.",
                                "Not Found", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                            return;
                        }
                    }


                    using (SqlCommand clearPhotoCmd = new SqlCommand(clearPhotoQuery, con))
                    {
                        clearPhotoCmd.Parameters.AddWithValue("@Officer_Name", textBox1.Text.Trim());
                        clearPhotoCmd.Parameters.AddWithValue("@Officer_ID", officerID);
                        clearPhotoCmd.ExecuteNonQuery();
                    }

                    using (SqlCommand deleteCmd = new SqlCommand(deleteQuery, con))
                    {
                        deleteCmd.Parameters.AddWithValue("@Officer_Name", textBox1.Text.Trim());
                        deleteCmd.Parameters.AddWithValue("@Officer_ID", officerID);

                        int rowsAffected = deleteCmd.ExecuteNonQuery();

                        if (rowsAffected > 0)
                        {
                            MessageBox.Show(
                                $"✅ Officer '{textBox1.Text.Trim()}' (ID: {officerID})\n" +
                                $"And removed photo sucessfully",
                                "Deleted Successfully",
                                MessageBoxButtons.OK,
                                MessageBoxIcon.Information);


                            textBox1.Clear();
                            textBox2.Clear();
                            pictureBox1.Image = SystemIcons.Shield.ToBitmap();
                            pictureBox1.SizeMode = PictureBoxSizeMode.Zoom;
                        }
                        else
                        {
                            MessageBox.Show("Deletion failed. Please try again.", "Error",
                                MessageBoxButtons.OK, MessageBoxIcon.Error);
                        }
                    }
                }
            }
            catch (SqlException ex)
            {
                if (ex.Number == 547)
                {
                    MessageBox.Show(
                        "Cannot delete this Officer because they are referenced in another table.\nRemove related records first.",
                        "Foreign Key Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
                else
                {
                    MessageBox.Show("Database Error:\n" + ex.Message, "SQL Error",
                        MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("Unexpected Error:\n" + ex.Message, "Error",
                    MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void textBox1_TextChanged(object sender, EventArgs e) { }
        private void textBox2_TextChanged(object sender, EventArgs e) { }
    }
}
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
    public partial class Individual_Prisoner_ : Form
    {
        private readonly string connectionString =
            "Data Source=.\\SQLEXPRESS;Initial Catalog=\"Prison Mnagement System\";Integrated Security=True;Encrypt=True;TrustServerCertificate=True";

        public Individual_Prisoner_()
        {
            InitializeComponent();
        }

        private void Individual_Prisoner__Load(object sender, EventArgs e)
        {
            // ✅ Default placeholder
            pictureBox1.Image = SystemIcons.Shield.ToBitmap();
            pictureBox1.SizeMode = PictureBoxSizeMode.Zoom;
        }

        private void button1_Click(object sender, EventArgs e)
        {
            Admin adm = new Admin();
            adm.Show();
            this.Hide();
        }

        // ===================== SEARCH PRISONER =====================
        private void button2_Click(object sender, EventArgs e)
        {
            if (string.IsNullOrWhiteSpace(textBox1.Text) ||
                string.IsNullOrWhiteSpace(textBox2.Text))
            {
                MessageBox.Show("Please enter both Prisoner Name and Prisoner ID to search.",
                    "Validation Error", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            if (!int.TryParse(textBox2.Text.Trim(), out int prisonerID))
            {
                MessageBox.Show("Prisoner ID must be a valid number.",
                    "Validation Error", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                textBox2.Focus();
                return;
            }

            // ✅ Prisoner_Photo ও fetch করুন
            string query = @"SELECT 
                        Prisoner_ID, Prisoner_NID, Prisoner_Age,
                        Date_Of_Birth, Crime_Type, Admission_Date,
                        Discharge_Date, Cell_ID, Prisoner_Rating,
                        Prisoner_Photo
                     FROM Prisoners
                     WHERE Prisoner_Name = @Prisoner_Name 
                     AND Prisoner_ID = @Prisoner_ID";

            try
            {
                using (SqlConnection con = new SqlConnection(connectionString))
                {
                    con.Open();
                    using (SqlCommand cmd = new SqlCommand(query, con))
                    {
                        cmd.Parameters.AddWithValue("@Prisoner_Name", textBox1.Text.Trim());
                        cmd.Parameters.AddWithValue("@Prisoner_ID", prisonerID);

                        using (SqlDataReader reader = cmd.ExecuteReader())
                        {
                            if (reader.Read())
                            {
                                string prisonerNID = reader["Prisoner_NID"].ToString();
                                string prisonerAge = reader["Prisoner_Age"].ToString();
                                string dateOfBirth = reader["Date_Of_Birth"] != DBNull.Value
                                                        ? Convert.ToDateTime(reader["Date_Of_Birth"]).ToString("yyyy-MM-dd") : "N/A";
                                string crimeType = reader["Crime_Type"].ToString();
                                string admissionDate = reader["Admission_Date"] != DBNull.Value
                                                        ? Convert.ToDateTime(reader["Admission_Date"]).ToString("yyyy-MM-dd") : "N/A";
                                string dischargeDate = reader["Discharge_Date"] != DBNull.Value
                                                        ? Convert.ToDateTime(reader["Discharge_Date"]).ToString("yyyy-MM-dd") : "N/A";
                                string cellID = reader["Cell_ID"].ToString();
                                int ratingValue = reader["Prisoner_Rating"] != DBNull.Value
                                                        ? Convert.ToInt32(reader["Prisoner_Rating"]) : 0;
                                string ratingStars = ratingValue > 0
                                                        ? new string('★', ratingValue) + new string('☆', 5 - ratingValue)
                                                        : "Not Rated";

                                // ✅ Photo দেখান
                                if (reader["Prisoner_Photo"] != DBNull.Value)
                                {
                                    byte[] photoBytes = (byte[])reader["Prisoner_Photo"];
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
                                    $"========== Prisoner Information ==========\n\n" +
                                    $"Prisoner ID      : {prisonerID}\n" +
                                    $"Prisoner NID     : {prisonerNID}\n" +
                                    $"Prisoner Age     : {prisonerAge}\n" +
                                    $"Date Of Birth    : {dateOfBirth}\n" +
                                    $"Crime Type       : {crimeType}\n" +
                                    $"Admission Date   : {admissionDate}\n" +
                                    $"Discharge Date   : {dischargeDate}\n" +
                                    $"Cell ID          : {cellID}\n" +
                                    $"Prisoner Rating  : {ratingStars}\n\n" +
                                    $"==========================================";

                                MessageBox.Show(message, "Prisoner Found",
                                    MessageBoxButtons.OK, MessageBoxIcon.Information);
                            }
                            else
                            {
                                // ✅ না পাওয়া গেলে pictureBox reset
                                pictureBox1.Image = SystemIcons.Shield.ToBitmap();

                                MessageBox.Show(
                                    "No Prisoner found with the given Name and ID.\nPlease check and try again.",
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

        // ===================== DELETE PRISONER =====================
        private void button3_Click(object sender, EventArgs e)
        {
            if (string.IsNullOrWhiteSpace(textBox1.Text) ||
                string.IsNullOrWhiteSpace(textBox2.Text))
            {
                MessageBox.Show("Please enter both Prisoner Name and Prisoner ID to delete.",
                    "Validation Error", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            if (!int.TryParse(textBox2.Text.Trim(), out int prisonerID))
            {
                MessageBox.Show("Prisoner ID must be a valid number.",
                    "Validation Error", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                textBox2.Focus();
                return;
            }

            DialogResult confirm = MessageBox.Show(
                $"Are you sure you want to delete Prisoner:\n\n" +
                $"Name : {textBox1.Text.Trim()}\n" +
                $"ID   : {prisonerID}\n\n" +
                $"⚠️ This will also delete their Photo and all Visit Requests.\n" +
                $"This action cannot be undone!",
                "Confirm Delete",
                MessageBoxButtons.YesNo,
                MessageBoxIcon.Warning);

            if (confirm == DialogResult.No) return;

            string checkQuery = @"SELECT COUNT(*) FROM Prisoners 
                                  WHERE Prisoner_Name = @Prisoner_Name 
                                  AND Prisoner_ID = @Prisoner_ID";

            // ✅ আগে Photo NULL করুন
            string clearPhotoQuery = @"UPDATE Prisoners 
                                       SET Prisoner_Photo = NULL 
                                       WHERE Prisoner_Name = @Prisoner_Name 
                                       AND Prisoner_ID = @Prisoner_ID";

            // ✅ তারপর VisitRequests delete করুন
            string deleteVisitsQuery = @"DELETE FROM VisitRequests 
                                         WHERE Prisoner_ID = @Prisoner_ID";

            // ✅ সবশেষে Prisoner delete করুন
            string deletePrisonerQuery = @"DELETE FROM Prisoners 
                                           WHERE Prisoner_Name = @Prisoner_Name 
                                           AND Prisoner_ID = @Prisoner_ID";

            try
            {
                using (SqlConnection con = new SqlConnection(connectionString))
                {
                    con.Open();

                    // Step 1: Prisoner আছে কিনা check
                    using (SqlCommand checkCmd = new SqlCommand(checkQuery, con))
                    {
                        checkCmd.Parameters.AddWithValue("@Prisoner_Name", textBox1.Text.Trim());
                        checkCmd.Parameters.AddWithValue("@Prisoner_ID", prisonerID);

                        int count = (int)checkCmd.ExecuteScalar();

                        if (count == 0)
                        {
                            MessageBox.Show(
                                "No Prisoner found with the given Name and ID.\nDeletion cancelled.",
                                "Not Found", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                            return;
                        }
                    }

                    // ✅ Step 2: Photo NULL করুন
                    using (SqlCommand clearPhotoCmd = new SqlCommand(clearPhotoQuery, con))
                    {
                        clearPhotoCmd.Parameters.AddWithValue("@Prisoner_Name", textBox1.Text.Trim());
                        clearPhotoCmd.Parameters.AddWithValue("@Prisoner_ID", prisonerID);
                        clearPhotoCmd.ExecuteNonQuery();
                    }

                    // ✅ Step 3: VisitRequests delete করুন
                    using (SqlCommand deleteVisitsCmd = new SqlCommand(deleteVisitsQuery, con))
                    {
                        deleteVisitsCmd.Parameters.AddWithValue("@Prisoner_ID", prisonerID);
                        deleteVisitsCmd.ExecuteNonQuery();
                    }

                    // ✅ Step 4: Prisoner delete করুন
                    using (SqlCommand deletePrisonerCmd = new SqlCommand(deletePrisonerQuery, con))
                    {
                        deletePrisonerCmd.Parameters.AddWithValue("@Prisoner_Name", textBox1.Text.Trim());
                        deletePrisonerCmd.Parameters.AddWithValue("@Prisoner_ID", prisonerID);

                        int rowsAffected = deletePrisonerCmd.ExecuteNonQuery();

                        if (rowsAffected > 0)
                        {
                            MessageBox.Show(
                                $"✅ Prisoner '{textBox1.Text.Trim()}' (ID: {prisonerID})\n" +
                                $"Photo এবং সকল Visit Request সহ সফলভাবে মুছে ফেলা হয়েছে।",
                                "Deleted Successfully",
                                MessageBoxButtons.OK,
                                MessageBoxIcon.Information);

                            // ✅ Form reset
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
                        "Cannot delete this Prisoner because they are still referenced in another table.\n" +
                        "Please contact system administrator.",
                        "Foreign Key Error",
                        MessageBoxButtons.OK,
                        MessageBoxIcon.Error);
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
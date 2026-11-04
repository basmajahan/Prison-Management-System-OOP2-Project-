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
    public partial class Prisoner : Form
    {
        // ✅ Class level এ photo bytes রাখুন
        private byte[] selectedPhotoBytes = null;

        private readonly string connectionString =
            "Data Source=.\\SQLEXPRESS;Initial Catalog=\"Prison Mnagement System\";Integrated Security=True;Encrypt=True;TrustServerCertificate=True";

        public Prisoner()
        {
            InitializeComponent();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            Admin adm1 = new Admin();
            adm1.Show();
            this.Hide();
        }

        // ===================== BROWSE PHOTO =====================
        private void pictureBox1_Click(object sender, EventArgs e)
        {
            using (OpenFileDialog ofd = new OpenFileDialog())
            {
                ofd.Title = "Select Prisoner Photo";
                ofd.Filter = "Image Files|*.jpg;*.jpeg;*.png;*.bmp";
                ofd.Multiselect = false;

                if (ofd.ShowDialog() == DialogResult.OK)
                {
                    string filePath = ofd.FileName;

                    // ✅ File size check — 5MB এর বেশি হলে reject
                    FileInfo fi = new FileInfo(filePath);
                    if (fi.Length > 5 * 1024 * 1024)
                    {
                        MessageBox.Show(
                            "Photo size must be less than 5MB.\nPlease choose a smaller image.",
                            "File Too Large",
                            MessageBoxButtons.OK,
                            MessageBoxIcon.Warning);
                        return;
                    }

                    // ✅ Preview দেখান
                    pictureBox1.Image = Image.FromFile(filePath);
                    pictureBox1.SizeMode = PictureBoxSizeMode.Zoom;

                    // ✅ Bytes এ convert করে রাখুন
                    selectedPhotoBytes = File.ReadAllBytes(filePath);

                    MessageBox.Show(
                        "Photo selected successfully!",
                        "Photo Ready",
                        MessageBoxButtons.OK,
                        MessageBoxIcon.Information);
                }
            }
        }

        private void dateTimePicker1_ValueChanged(object sender, EventArgs e)
        {
            if (dateTimePicker1.Value.Date > DateTime.Today)
            {
                MessageBox.Show("Date of Birth cannot be in the future.",
                    "Validation Error", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                dateTimePicker1.Focus();
                return;
            }
        }

        // ===================== SAVE PRISONER =====================
        private void button2_Click(object sender, EventArgs e)
        {
            // Validation
            if (string.IsNullOrWhiteSpace(textBox1.Text) ||
                string.IsNullOrWhiteSpace(textBox7.Text) ||
                string.IsNullOrWhiteSpace(textBox6.Text) ||
                string.IsNullOrWhiteSpace(textBox3.Text) ||
                string.IsNullOrWhiteSpace(textBox4.Text) ||
                string.IsNullOrWhiteSpace(textBox5.Text) ||
                string.IsNullOrWhiteSpace(textBox9.Text))
            {
                MessageBox.Show("Please fill all fields before saving.",
                    "Validation Error", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            if (!int.TryParse(textBox6.Text.Trim(), out int prisonerAge))
            {
                MessageBox.Show("Prisoner Age must be a valid number.",
                    "Validation Error", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                textBox6.Focus();
                return;
            }

            if (!int.TryParse(textBox9.Text.Trim(), out int cellID))
            {
                MessageBox.Show("Cell ID must be a valid number.",
                    "Validation Error", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                textBox9.Focus();
                return;
            }

            if (!DateTime.TryParse(textBox4.Text.Trim(), out DateTime admissionDate))
            {
                MessageBox.Show("Admission Date is not valid. Use format: YYYY-MM-DD",
                    "Validation Error", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                textBox4.Focus();
                return;
            }

            if (!DateTime.TryParse(textBox5.Text.Trim(), out DateTime dischargeDate))
            {
                MessageBox.Show("Discharge Date is not valid. Use format: YYYY-MM-DD",
                    "Validation Error", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                textBox5.Focus();
                return;
            }

            // ✅ Photo না দিলে warning
            if (selectedPhotoBytes == null)
            {
                DialogResult photoConfirm = MessageBox.Show(
                    "No photo selected. Do you want to save without a photo?",
                    "No Photo",
                    MessageBoxButtons.YesNo,
                    MessageBoxIcon.Question);

                if (photoConfirm == DialogResult.No) return;
            }

            // ✅ Photo সহ INSERT query
            string query = @"INSERT INTO Prisoners 
                        (Prisoner_Name, Prisoner_NID, Prisoner_Age, Date_Of_Birth, 
                         Crime_Type, Admission_Date, Discharge_Date, Cell_ID, 
                         Prisoner_Rating, Prisoner_Photo)
                     VALUES 
                        (@Prisoner_Name, @Prisoner_NID, @Prisoner_Age, @Date_Of_Birth, 
                         @Crime_Type, @Admission_Date, @Discharge_Date, @Cell_ID, 
                         @Prisoner_Rating, @Prisoner_Photo)";

            try
            {
                using (SqlConnection con = new SqlConnection(connectionString))
                {
                    con.Open();

                    using (SqlCommand cmd = new SqlCommand(query, con))
                    {
                        cmd.Parameters.AddWithValue("@Prisoner_Name", textBox1.Text.Trim());
                        cmd.Parameters.AddWithValue("@Prisoner_NID", textBox7.Text.Trim());
                        cmd.Parameters.AddWithValue("@Prisoner_Age", prisonerAge);
                        cmd.Parameters.AddWithValue("@Date_Of_Birth", dateTimePicker1.Value.Date);
                        cmd.Parameters.AddWithValue("@Crime_Type", textBox3.Text.Trim());
                        cmd.Parameters.AddWithValue("@Admission_Date", admissionDate);
                        cmd.Parameters.AddWithValue("@Discharge_Date", dischargeDate);
                        cmd.Parameters.AddWithValue("@Cell_ID", cellID);
                        cmd.Parameters.AddWithValue("@Prisoner_Rating", DBNull.Value);

                        // ✅ Photo null হলে DBNull, নাহলে bytes
                        if (selectedPhotoBytes != null)
                            cmd.Parameters.AddWithValue("@Prisoner_Photo", selectedPhotoBytes);
                        else
                            cmd.Parameters.AddWithValue("@Prisoner_Photo", DBNull.Value);

                        int rowsAffected = cmd.ExecuteNonQuery();

                        if (rowsAffected > 0)
                        {
                            MessageBox.Show(
                                "✅ Prisoner Registered Successfully!",
                                "Success",
                                MessageBoxButtons.OK,
                                MessageBoxIcon.Information);

                            // ✅ Form reset
                            Prisoner p1 = new Prisoner();
                            p1.Show();
                            this.Hide();
                        }
                        else
                        {
                            MessageBox.Show("Registration failed. Please try again.",
                                "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                        }
                    }
                }
            }
            catch (SqlException ex)
            {
                if (ex.Number == 2627 || ex.Number == 2601)
                {
                    MessageBox.Show("Prisoner NID already exists in the system.",
                        "Duplicate Entry", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                }
                else if (ex.Number == 547)
                {
                    MessageBox.Show("Cell ID does not exist. Please enter a valid Cell ID.",
                        "Foreign Key Error", MessageBoxButtons.OK, MessageBoxIcon.Warning);
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
        private void textBox8_TextChanged(object sender, EventArgs e) { }
        private void textBox7_TextChanged(object sender, EventArgs e) { textBox7.MaxLength = 8; }
        private void textBox6_TextChanged(object sender, EventArgs e) { }
        private void textBox2_TextChanged(object sender, EventArgs e) { }
        private void textBox3_TextChanged(object sender, EventArgs e) { }
        private void textBox4_TextChanged(object sender, EventArgs e) { }
        private void textBox5_TextChanged(object sender, EventArgs e) { }
        private void textBox9_TextChanged(object sender, EventArgs e) { }

        private void button3_Click(object sender, EventArgs e)
        {
            using (OpenFileDialog ofd = new OpenFileDialog())
            {
                ofd.Title = "Select Prisoner Photo";
                ofd.Filter = "Image Files|*.jpg;*.jpeg;*.png;*.bmp";
                ofd.Multiselect = false;

                if (ofd.ShowDialog() == DialogResult.OK)
                {
                    string filePath = ofd.FileName;

                    // ✅ File size check — 5MB এর বেশি হলে reject
                    FileInfo fi = new FileInfo(filePath);
                    if (fi.Length > 5 * 1024 * 1024)
                    {
                        MessageBox.Show(
                            "Photo size must be less than 5MB.\nPlease choose a smaller image.",
                            "File Too Large",
                            MessageBoxButtons.OK,
                            MessageBoxIcon.Warning);
                        return;
                    }

                    // ✅ PictureBox এ preview দেখান
                    pictureBox1.Image = Image.FromFile(filePath);
                    pictureBox1.SizeMode = PictureBoxSizeMode.Zoom;

                    // ✅ Database এ save করার জন্য bytes এ রাখুন
                    selectedPhotoBytes = File.ReadAllBytes(filePath);

                    MessageBox.Show(
                        "✅ Photo selected successfully!",
                        "Photo Ready",
                        MessageBoxButtons.OK,
                        MessageBoxIcon.Information);
                }
            }
        }

        private void pictureBox1_Click_1(object sender, EventArgs e)
        {

        }
    }
}
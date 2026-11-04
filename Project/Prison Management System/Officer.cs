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
    public partial class Officer : Form
    {

        private byte[] selectedPhotoBytes = null;

        private readonly string connectionString =
            "Data Source=.\\SQLEXPRESS;Initial Catalog=\"Prison Mnagement System\";Integrated Security=True;Encrypt=True;TrustServerCertificate=True";

        public Officer()
        {
            InitializeComponent();
        }

        private void Officer_Load(object sender, EventArgs e)
        {

            pictureBox1.Image = SystemIcons.Shield.ToBitmap();
            pictureBox1.SizeMode = PictureBoxSizeMode.Zoom;
        }

        private void button1_Click(object sender, EventArgs e)
        {
            Admin a1 = new Admin();
            a1.Show();
            this.Hide();
        }


        private void pictureBox1_Click(object sender, EventArgs e)
        {
            using (OpenFileDialog ofd = new OpenFileDialog())
            {
                ofd.Title = "Select Officer Photo";
                ofd.Filter = "Image Files|*.jpg;*.jpeg;*.png;*.bmp";
                ofd.Multiselect = false;

                if (ofd.ShowDialog() == DialogResult.OK)
                {
                    string filePath = ofd.FileName;


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


                    pictureBox1.Image = Image.FromFile(filePath);
                    pictureBox1.SizeMode = PictureBoxSizeMode.Zoom;


                    selectedPhotoBytes = File.ReadAllBytes(filePath);

                    MessageBox.Show(
                        "Photo selected successfully!",
                        "Photo Ready",
                        MessageBoxButtons.OK,
                        MessageBoxIcon.Information);
                }
            }
        }


        private void button2_Click(object sender, EventArgs e)
        {
            // ১. সব ফিল্ড পূরণ করা হয়েছে কি না চেক
            if (string.IsNullOrWhiteSpace(textBox6.Text) ||
                string.IsNullOrWhiteSpace(textBox5.Text) ||
                string.IsNullOrWhiteSpace(textBox4.Text) ||
                string.IsNullOrWhiteSpace(textBox1.Text) ||
                string.IsNullOrWhiteSpace(textBox3.Text) ||
                string.IsNullOrWhiteSpace(textBox2.Text) ||
                string.IsNullOrWhiteSpace(textBox7.Text) ||
                comboBox1.SelectedIndex == -1)
            {
                MessageBox.Show(
                    "Please fill all fields before saving.",
                    "Validation Error",
                    MessageBoxButtons.OK,
                    MessageBoxIcon.Warning);
                return;
            }

            // ২. Officer ID ভ্যালিড সংখ্যা কি না চেক
            if (!int.TryParse(textBox5.Text.Trim(), out int officerID))
            {
                MessageBox.Show(
                    "Officer ID must be a valid number.",
                    "Validation Error",
                    MessageBoxButtons.OK,
                    MessageBoxIcon.Warning);
                textBox5.Focus();
                return;
            }

            // ৩. নতুন কন্ডিশন: Officer NID (textBox4) ঠিক ৮ ডিজিটের হতে হবে
            string enteredNID = textBox4.Text.Trim();
            if (enteredNID.Length != 8)
            {
                MessageBox.Show(
                    "Officer NID must be exactly 8 digits long.",
                    "Validation Error",
                    MessageBoxButtons.OK,
                    MessageBoxIcon.Warning);
                textBox4.Focus();
                return;
            }

            // ৪. ফটো সিলেক্ট করা হয়েছে কি না চেক
            if (selectedPhotoBytes == null)
            {
                DialogResult photoConfirm = MessageBox.Show(
                    "No photo selected. Do you want to save without a photo?",
                    "No Photo",
                    MessageBoxButtons.YesNo,
                    MessageBoxIcon.Question);

                if (photoConfirm == DialogResult.No) return;
            }

            string query = @"INSERT INTO Officers 
        (Officer_ID, Officer_Name, Officer_NID, Officer_Contact, 
         Email, Create_Password, Shift, Status, Officer_Photo)
     VALUES 
        (@Officer_ID, @Officer_Name, @Officer_NID, @Officer_Contact, 
         @Email, @Create_Password, @Shift, @Status, @Officer_Photo)";

            try
            {
                using (SqlConnection con = new SqlConnection(connectionString))
                {
                    con.Open();

                    using (SqlCommand cmd = new SqlCommand(query, con))
                    {
                        cmd.Parameters.AddWithValue("@Officer_ID", officerID);
                        cmd.Parameters.AddWithValue("@Officer_Name", textBox6.Text.Trim());
                        cmd.Parameters.AddWithValue("@Officer_NID", enteredNID); // এখানে ভ্যালিডেট হওয়া NID পাস হবে
                        cmd.Parameters.AddWithValue("@Officer_Contact", textBox1.Text.Trim());
                        cmd.Parameters.AddWithValue("@Email", textBox3.Text.Trim());
                        cmd.Parameters.AddWithValue("@Create_Password", textBox7.Text.Trim());
                        cmd.Parameters.AddWithValue("@Shift", comboBox1.SelectedItem.ToString());
                        cmd.Parameters.AddWithValue("@Status", textBox2.Text.Trim());

                        if (selectedPhotoBytes != null)
                            cmd.Parameters.AddWithValue("@Officer_Photo", selectedPhotoBytes);
                        else
                            cmd.Parameters.AddWithValue("@Officer_Photo", DBNull.Value);

                        int rowsAffected = cmd.ExecuteNonQuery();

                        if (rowsAffected > 0)
                        {
                            MessageBox.Show(
                                "✅ Officer Registered Successfully!",
                                "Success",
                                MessageBoxButtons.OK,
                                MessageBoxIcon.Information);

                            Officer o1 = new Officer();
                            o1.Show();
                            this.Hide();
                        }
                        else
                        {
                            MessageBox.Show(
                                "Registration failed. Please try again.",
                                "Error",
                                MessageBoxButtons.OK,
                                MessageBoxIcon.Error);
                        }
                    }
                }
            }
            catch (SqlException ex)
            {
                if (ex.Number == 2627 || ex.Number == 2601)
                {
                    MessageBox.Show(
                        "Officer ID, NID or Email already exists in the system.",
                        "Duplicate Entry",
                        MessageBoxButtons.OK,
                        MessageBoxIcon.Warning);
                }
                else
                {
                    MessageBox.Show(
                        "Database Error:\n" + ex.Message,
                        "SQL Error",
                        MessageBoxButtons.OK,
                        MessageBoxIcon.Error);
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(
                    "Unexpected Error:\n" + ex.Message,
                    "Error",
                    MessageBoxButtons.OK,
                    MessageBoxIcon.Error);
            }
        }

        private void textBox6_TextChanged(object sender, EventArgs e) { }
        private void textBox5_TextChanged(object sender, EventArgs e) { }
        private void textBox4_TextChanged(object sender, EventArgs e) { textBox4.MaxLength = 8; }
        private void textBox1_TextChanged(object sender, EventArgs e) { }
        private void textBox3_TextChanged(object sender, EventArgs e) { }
        private void comboBox1_SelectedIndexChanged(object sender, EventArgs e) { }
        private void textBox2_TextChanged(object sender, EventArgs e) { }
        private void textBox7_TextChanged(object sender, EventArgs e) { }
        private void label7_Click(object sender, EventArgs e) { }

        private void btnBrowse_Click(object sender, EventArgs e)
        {
            using (OpenFileDialog ofd = new OpenFileDialog())
            {
                ofd.Title = "Select Officer Photo";
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
        //private void pictureBox1_Click(object sender, EventArgs e) { }
    }
}
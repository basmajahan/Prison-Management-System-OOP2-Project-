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
    public partial class Prisoner_Rating_ : Form
    {
        private int _currentRating = 0;
        private int _hoverRating = 0;
        private Button[] _starButtons = new Button[5];

        public Prisoner_Rating_()
        {
            InitializeComponent();
            AddStarRating();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            Officer_Dashboard_ od1 = new Officer_Dashboard_();
            od1.Show();
            this.Hide();
        }

        private void AddStarRating()
        {
            int startX = label2.Right + 10;
            int startY = label2.Top - 17;

            for (int i = 0; i < 5; i++)
            {
                int starValue = i + 1;

                var star = new Button
                {
                    Name = "btnStar" + starValue,
                    Text = "☆",
                    Tag = starValue,
                    Font = new Font("Segoe UI", 22f, FontStyle.Bold),
                    ForeColor = Color.FromArgb(180, 180, 180),
                    BackColor = Color.Transparent,
                    FlatStyle = FlatStyle.Flat,
                    Size = new Size(44, 44),
                    Location = new Point(startX + i * 46, startY),
                    Cursor = Cursors.Hand,
                    TabStop = false,
                    TextAlign = ContentAlignment.MiddleCenter,
                    UseVisualStyleBackColor = false
                };

                star.FlatAppearance.BorderSize = 0;
                star.FlatAppearance.MouseOverBackColor = Color.Transparent;
                star.FlatAppearance.MouseDownBackColor = Color.Transparent;

                star.MouseEnter += Star_MouseEnter;
                star.MouseLeave += Star_MouseLeave;
                star.Click += Star_Click;

                _starButtons[i] = star;
                this.Controls.Add(star);
                star.BringToFront();
            }
        }

        private void Star_MouseEnter(object sender, EventArgs e)
        {
            _hoverRating = (int)((Button)sender).Tag;
            PaintStars(_hoverRating);
        }

        private void Star_MouseLeave(object sender, EventArgs e)
        {
            _hoverRating = 0;
            PaintStars(_currentRating);
        }

        private void Star_Click(object sender, EventArgs e)
        {
            _currentRating = (int)((Button)sender).Tag;
            PaintStars(_currentRating);
        }

        private void PaintStars(int rating)
        {
            for (int i = 0; i < 5; i++)
            {
                bool filled = i < rating;
                _starButtons[i].Text = filled ? "★" : "☆";
                _starButtons[i].ForeColor = filled
                    ? Color.FromArgb(255, 193, 7)
                    : Color.FromArgb(180, 180, 180);
            }
        }

        private void label2_Click(object sender, EventArgs e)
        {

        }

        private void button2_Click(object sender, EventArgs e)
        {

            if (string.IsNullOrWhiteSpace(textBox2.Text))
            {
                MessageBox.Show("Please enter Prisoner ID", "Validation Error", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                textBox2.Focus();
                return;
            }


            if (!int.TryParse(textBox2.Text.Trim(), out int prisonerID))
            {
                MessageBox.Show("Prisoner ID must be valid", "Validation Error", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                textBox2.Focus();
                return;
            }

            if (_currentRating == 0)
            {
                MessageBox.Show("Please select among 1 to 5", "Not rated", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            string connectionString = "Data Source=.\\SQLEXPRESS;Initial Catalog=\"Prison Mnagement System\";Integrated Security=True;Encrypt=True;TrustServerCertificate=True";
            string query = "UPDATE Prisoners SET Prisoner_Rating = @Rating WHERE Prisoner_ID = @PrisonerID";

            try
            {
                using (SqlConnection con = new SqlConnection(connectionString))
                {
                    con.Open();

                    using (SqlCommand cmd = new SqlCommand(query, con))
                    {

                        cmd.Parameters.AddWithValue("@Rating", _currentRating);
                        cmd.Parameters.AddWithValue("@PrisonerID", prisonerID);

                        int rowsAffected = cmd.ExecuteNonQuery();

                        if (rowsAffected > 0)
                        {
                            MessageBox.Show($"Star rating of {_currentRating} for Prisoner ID {prisonerID} has been successfully submitted to the database!", "Success", MessageBoxButtons.OK, MessageBoxIcon.Information);



                            textBox1.Clear();
                            textBox2.Clear();
                            _currentRating = 0;
                            PaintStars(0); 

                        }
                        else
                        {
                            MessageBox.Show("No prisoner was found in the database according to the provided Prisoner ID. Check the ID again.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                        }
                    }
                }
            }
            catch (SqlException ex)
            {
                MessageBox.Show("DataBase Error:\n" + ex.Message, "SQL Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
            catch (Exception ex)
            {
                MessageBox.Show("একটি অপ্রত্যাশিত ত্রুটি ঘটেছে:\n" + ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void label1_Click(object sender, EventArgs e)
        {

        }

        private void Prisoner_Rating__Load(object sender, EventArgs e)
        {

        }

        private void textBox1_TextChanged(object sender, EventArgs e)
        {

        }

        private void textBox2_TextChanged(object sender, EventArgs e)
        {

        }

        public int SelectedRating => _currentRating;
    }
}
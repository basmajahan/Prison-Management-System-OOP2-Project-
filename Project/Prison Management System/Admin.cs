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
    public partial class Admin : Form
    {
        private readonly string connectionString =
            "Data Source=.\\SQLEXPRESS;Initial Catalog=\"Prison Mnagement System\";Integrated Security=True;";


        private readonly string adminEmail = "lanyfung8@gmail.com";
        private readonly string adminAppPassword = "fuyqzabaddvlwobi";

        public Admin(string email)
        {
            InitializeComponent();
            adminEmail = email;
        }

        public Admin()
        {
            InitializeComponent();
        }

        private void Admin_Load(object sender, EventArgs e)
        {
            dataGridView1.Visible = false;
            dataGridView2.Visible = false;
            dataGridView3.Visible = false;
            dataGridView4.Visible = false;
            label1.Visible = false;
        }

        private void button3_Click(object sender, EventArgs e)
        {
            HomePage home = new HomePage();
            home.Show();
            this.Hide();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            contextMenuStrip4.Show(button1, new Point(0, button1.Height));
        }

        private void button2_Click(object sender, EventArgs e)
        {
            contextMenuStrip5.Show(button2, new Point(0, button2.Height));
        }

        private void individualToolStripMenuItem2_Click(object sender, EventArgs e)
        {
            Individual_Officer_ i1 = new Individual_Officer_();
            i1.Show();
            this.Hide();
        }

        private void individualToolStripMenuItem3_Click(object sender, EventArgs e)
        {
            Individual_Prisoner_ i2 = new Individual_Prisoner_();
            i2.Show();
            this.Hide();
        }

        private void button5_Click(object sender, EventArgs e)
        {
            Officer o1 = new Officer();
            o1.Show();
            this.Hide();
        }

        private void button7_Click(object sender, EventArgs e)
        {
            Prisoner p1 = new Prisoner();
            p1.Show();
            this.Hide();
        }

        private void dataGridView1_CellContentClick(object sender, DataGridViewCellEventArgs e) { }
        private void dataGridView2_CellContentClick(object sender, DataGridViewCellEventArgs e) { }


        private void allToolStripMenuItem1_Click(object sender, EventArgs e)
        {
            string query = @"SELECT 
                                Officer_ID, Officer_Name, Officer_NID,
                                Officer_Contact, Email, Shift, Status, Create_Password
                             FROM Officers ORDER BY Officer_ID ASC";
            try
            {
                using (SqlConnection con = new SqlConnection(connectionString))
                {
                    con.Open();
                    SqlDataAdapter adapter = new SqlDataAdapter(query, con);
                    DataTable dt = new DataTable();
                    adapter.Fill(dt);

                    dataGridView2.Visible = false;
                    dataGridView3.Visible = false;
                    dataGridView4.Visible = false;
                    dataGridView1.DataSource = dt;
                    dataGridView1.Visible = true;
                    ApplyProfessionalStyles(dataGridView1);

                    label1.Text = $"Total Officers: {dt.Rows.Count}";
                    label1.Visible = true;
                }
            }
            catch (Exception ex)
            {
                ShowError(ex);
            }
        }

        // ===================== ALL PRISONERS =====================
        private void allToolStripMenuItem2_Click(object sender, EventArgs e)
        {
            string query = @"SELECT 
                                Prisoner_ID, Prisoner_Name, Prisoner_NID,
                                Prisoner_Age, Date_Of_Birth, Crime_Type,
                                Admission_Date, Discharge_Date, Cell_ID, Prisoner_Rating
                             FROM Prisoners ORDER BY Prisoner_ID ASC";
            try
            {
                using (SqlConnection con = new SqlConnection(connectionString))
                {
                    con.Open();
                    SqlDataAdapter adapter = new SqlDataAdapter(query, con);
                    DataTable dt = new DataTable();
                    adapter.Fill(dt);

                    dt.Columns.Add("Rating", typeof(string));
                    foreach (DataRow row in dt.Rows)
                    {
                        if (row["Prisoner_Rating"] != DBNull.Value)
                        {
                            int rating = Convert.ToInt32(row["Prisoner_Rating"]);
                            row["Rating"] = new string('★', rating) + new string('☆', 5 - rating);
                        }
                        else row["Rating"] = "Not Rated";
                    }
                    dt.Columns.Remove("Prisoner_Rating");

                    dataGridView2.Visible = false;
                    dataGridView3.Visible = false;
                    dataGridView4.Visible = false;
                    dataGridView1.DataSource = dt;
                    dataGridView1.Visible = true;
                    ApplyProfessionalStyles(dataGridView1);

                    label1.Text = $"Total Prisoners: {dt.Rows.Count}";
                    label1.Visible = true;
                }
            }
            catch (Exception ex)
            {
                ShowError(ex);
            }
        }


        private void button6_Click(object sender, EventArgs e)
        {
            string query = @"SELECT Cell_ID, Block_Name, Cell_Type, Cell_Capacity
                             FROM Cells ORDER BY Cell_ID ASC";
            try
            {
                using (SqlConnection con = new SqlConnection(connectionString))
                {
                    con.Open();
                    SqlDataAdapter adapter = new SqlDataAdapter(query, con);
                    DataTable dt = new DataTable();
                    adapter.Fill(dt);

                    dataGridView1.Visible = false;
                    dataGridView2.Visible = false;
                    dataGridView4.Visible = false;
                    dataGridView3.DataSource = dt;
                    dataGridView3.Visible = true;
                    ApplyProfessionalStyles(dataGridView3);

                    label1.Text = $"Total Cells: {dt.Rows.Count}";
                    label1.Visible = true;
                }
            }
            catch (Exception ex)
            {
                ShowError(ex);
            }
        }


        private void button4_Click(object sender, EventArgs e)
        {
            string query = @"SELECT 
                        Request_ID, Visitor_NID, Visitor_Name,
                        Visitor_Email, Prisoner_ID, Visit_Date,
                        Visit_Hour, Visit_Duration, Status
                     FROM VisitRequests
                     ORDER BY Visit_Date ASC";
            try
            {
                using (SqlConnection con = new SqlConnection(connectionString))
                {
                    con.Open();
                    SqlDataAdapter adapter = new SqlDataAdapter(query, con);
                    DataTable dt = new DataTable();
                    adapter.Fill(dt);

                    dataGridView1.Visible = false;
                    dataGridView2.Visible = false;
                    dataGridView3.Visible = false;

                    dataGridView4.DataSource = dt;
                    dataGridView4.Visible = true;

                    ApplyProfessionalStyles(dataGridView4);

                    if (!dataGridView4.Columns.Contains("AccessBtn"))
                    {
                        DataGridViewButtonColumn accessBtn = new DataGridViewButtonColumn();
                        accessBtn.Name = "AccessBtn";
                        accessBtn.HeaderText = "Access";
                        accessBtn.Text = "✔ Access";
                        accessBtn.UseColumnTextForButtonValue = true;
                        accessBtn.Width = 100;
                        accessBtn.FlatStyle = FlatStyle.Flat;
                        accessBtn.DefaultCellStyle.BackColor = Color.FromArgb(40, 167, 69);
                        accessBtn.DefaultCellStyle.ForeColor = Color.White;
                        accessBtn.DefaultCellStyle.Font = new Font("Segoe UI", 9f, FontStyle.Bold);
                        accessBtn.DefaultCellStyle.SelectionBackColor = Color.FromArgb(40, 167, 69);
                        accessBtn.DefaultCellStyle.SelectionForeColor = Color.White;
                        dataGridView4.Columns.Add(accessBtn);
                    }

                    if (!dataGridView4.Columns.Contains("DeniedBtn"))
                    {
                        DataGridViewButtonColumn deniedBtn = new DataGridViewButtonColumn();
                        deniedBtn.Name = "DeniedBtn";
                        deniedBtn.HeaderText = "Denied";
                        deniedBtn.Text = "✖ Denied";
                        deniedBtn.UseColumnTextForButtonValue = true;
                        deniedBtn.Width = 100;
                        deniedBtn.FlatStyle = FlatStyle.Flat;
                        deniedBtn.DefaultCellStyle.BackColor = Color.FromArgb(220, 53, 69);
                        deniedBtn.DefaultCellStyle.ForeColor = Color.White;
                        deniedBtn.DefaultCellStyle.Font = new Font("Segoe UI", 9f, FontStyle.Bold);
                        deniedBtn.DefaultCellStyle.SelectionBackColor = Color.FromArgb(220, 53, 69); 
                        deniedBtn.DefaultCellStyle.SelectionForeColor = Color.White;
                        dataGridView4.Columns.Add(deniedBtn);
                    }

                    foreach (DataGridViewColumn col in dataGridView4.Columns)
                    {
                        if (col.Name != "AccessBtn" && col.Name != "DeniedBtn")
                            col.ReadOnly = true;
                    }

                    label1.Text = $"Total Visit Requests: {dt.Rows.Count}";
                    label1.Visible = true;

                    dataGridView4.CellClick -= DataGridView4_CellClick;
                    dataGridView4.CellClick += DataGridView4_CellClick;


                    dataGridView4.CellPainting -= new DataGridViewCellPaintingEventHandler(DataGridView4_CellPainting);
                    dataGridView4.CellPainting += new DataGridViewCellPaintingEventHandler(DataGridView4_CellPainting);
                }
            }
            catch (Exception ex)
            {
                ShowError(ex);
            }
        }
        private void DataGridView4_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            if (e.RowIndex < 0) return;

            string columnName = dataGridView4.Columns[e.ColumnIndex].Name;

            if (columnName != "AccessBtn" && columnName != "DeniedBtn") return;

            int requestID = Convert.ToInt32(dataGridView4.Rows[e.RowIndex].Cells["Request_ID"].Value);
            string visitorName = dataGridView4.Rows[e.RowIndex].Cells["Visitor_Name"].Value?.ToString();
            string visitorEmail = dataGridView4.Rows[e.RowIndex].Cells["Visitor_Email"].Value?.ToString();
            string visitDate = Convert.ToDateTime(dataGridView4.Rows[e.RowIndex].Cells["Visit_Date"].Value).ToString("dd MMM yyyy");
            string visitHour = dataGridView4.Rows[e.RowIndex].Cells["Visit_Hour"].Value?.ToString();
            string visitDuration = dataGridView4.Rows[e.RowIndex].Cells["Visit_Duration"].Value?.ToString();
            string prisonerID = dataGridView4.Rows[e.RowIndex].Cells["Prisoner_ID"].Value?.ToString();
            bool isAccepted = columnName == "AccessBtn";


            if (string.IsNullOrWhiteSpace(visitorEmail))
            {
                MessageBox.Show(
                    "This Visitor does not have an email address.",
                    "Email not found.",
                    MessageBoxButtons.OK,
                    MessageBoxIcon.Warning);
                return;
            }


            string confirmMsg = isAccepted
                ? $"Would you want to APPROVE {visitorName} Request? \nEmail to: {visitorEmail}"
                : $"Would you want to DENY {visitorName} Request? \nEmail to: {visitorEmail}";

            DialogResult confirm = MessageBox.Show(
                confirmMsg,
                "Confirm",
                MessageBoxButtons.YesNo,
                MessageBoxIcon.Question);

            if (confirm != DialogResult.Yes) return;

            UpdateRequestStatus(requestID, isAccepted ? "Approved" : "Denied");
            SendEmailToVisitor(visitorEmail, visitorName, prisonerID, visitDate, visitHour, visitDuration, isAccepted);
        }

        private void DataGridView4_CellPainting(object sender, DataGridViewCellPaintingEventArgs e)
        {
            if (e.RowIndex < 0 || e.ColumnIndex < 0) return;

            string colName = dataGridView4.Columns[e.ColumnIndex].Name;

            if (colName == "AccessBtn" || colName == "DeniedBtn")
            {

                Color btnColor = colName == "AccessBtn"
                    ? Color.FromArgb(40, 167, 69)   
                    : Color.FromArgb(220, 53, 69);  

                string btnText = colName == "AccessBtn" ? "✔ Access" : "✖ Denied";


                using (SolidBrush brush = new SolidBrush(btnColor))
                {
                    e.Graphics.FillRectangle(brush, e.CellBounds);
                }


                using (Pen pen = new Pen(Color.FromArgb(255, 255, 255, 255), 1))
                {
                    e.Graphics.DrawRectangle(pen, new Rectangle(
                        e.CellBounds.X,
                        e.CellBounds.Y,
                        e.CellBounds.Width - 1,
                        e.CellBounds.Height - 1));
                }


                TextRenderer.DrawText(
                    e.Graphics,
                    btnText,
                    new Font("Segoe UI", 9f, FontStyle.Bold),
                    e.CellBounds,
                    Color.White,
                    TextFormatFlags.HorizontalCenter | TextFormatFlags.VerticalCenter);

                e.Handled = true; 
            }
        }

        


        private void UpdateRequestStatus(int requestID, string status)
        {
            string query = "UPDATE VisitRequests SET Status = @Status WHERE Request_ID = @Request_ID";
            try
            {
                using (SqlConnection con = new SqlConnection(connectionString))
                {
                    con.Open();
                    using (SqlCommand cmd = new SqlCommand(query, con))
                    {
                        cmd.Parameters.AddWithValue("@Status", status);
                        cmd.Parameters.AddWithValue("@Request_ID", requestID);
                        cmd.ExecuteNonQuery();
                    }
                }
            }
            catch (Exception ex)
            {
                ShowError(ex);
            }
        }


        private void SendEmailToVisitor(
            string toEmail,
            string visitorName,
            string prisonerID,
            string visitDate,
            string visitHour,
            string visitDuration,
            bool isAccepted)
        {
            string subject = isAccepted
                ? "✅ Visit Request — ACCESS GRANTED"
                : "❌ Visit Request — ACCESS DENIED";

            string body = isAccepted
                ? $"Dear {visitorName},\n\n" +
                  $"Your visit request has been APPROVED ✅\n\n" +
                  $"━━━━━━━━━━━━━━━━━━━━━━━━\n" +
                  $"📋 Visit Details:\n" +
                  $"  • Prisoner ID   : {prisonerID}\n" +
                  $"  • Visit Date    : {visitDate}\n" +
                  $"  • Visit Hour    : {visitHour}\n" +
                  $"  • Visit Duration: {visitDuration}\n" +
                  $"━━━━━━━━━━━━━━━━━━━━━━━━\n\n" +
                  $"⚠️ Please arrive on time with a valid Government ID.\n\n" +
                  $"Regards,\nPrison Management System"
                : $"Dear {visitorName},\n\n" +
                  $"Your visit request has been DENIED ❌\n\n" +
                  $"━━━━━━━━━━━━━━━━━━━━━━━━\n" +
                  $"📋 Visit Details:\n" +
                  $"  • Prisoner ID   : {prisonerID}\n" +
                  $"  • Visit Date    : {visitDate}\n" +
                  $"  • Visit Hour    : {visitHour}\n" +
                  $"  • Visit Duration: {visitDuration}\n" +
                  $"━━━━━━━━━━━━━━━━━━━━━━━━\n\n" +
                  $"For more information, please contact prison administration.\n\n" +
                  $"Regards,\nPrison Management System";

            try
            {
                using (var smtp = new System.Net.Mail.SmtpClient("smtp.gmail.com", 587))
                {
                    smtp.DeliveryMethod = System.Net.Mail.SmtpDeliveryMethod.Network;
                    smtp.UseDefaultCredentials = false;
                    smtp.EnableSsl = true;
                    smtp.Credentials = new System.Net.NetworkCredential(adminEmail, adminAppPassword);

                    var mail = new System.Net.Mail.MailMessage();
                    mail.From = new System.Net.Mail.MailAddress(adminEmail, "Prison Management System");
                    mail.To.Add(toEmail); 
                    mail.Subject = subject;
                    mail.Body = body;
                    mail.IsBodyHtml = false;

                    smtp.Send(mail);

                    MessageBox.Show(
                        $"✅ Email has been sent successfully!\n\nTo: {visitorName}\nEmail: {toEmail}",
                        isAccepted ? "Access Granted" : "Access Denied",
                        MessageBoxButtons.OK,
                        isAccepted ? MessageBoxIcon.Information : MessageBoxIcon.Warning);

                    button4_Click(this, EventArgs.Empty); 
                }
            }
            catch (System.Net.Mail.SmtpException ex)
            {
                MessageBox.Show(
                    "❌ Email Could not be sent.!\n\nBecause: " + ex.Message +
                    "\n\n💡 Solution:\n" +
                    "1. Check Gmail App Password \n" +
                    "2. Check Internet connection \n" +
                    "3. Check 2-Step Verification is on",
                    "SMTP Error",
                    MessageBoxButtons.OK,
                    MessageBoxIcon.Error);
            }
            catch (Exception ex)
            {
                ShowError(ex);
            }
        }

        private void ApplyProfessionalStyles(DataGridView dgv)
        {
            dgv.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.Fill;
            dgv.RowHeadersVisible = false;
            dgv.AllowUserToAddRows = false;

            dgv.SelectionMode = DataGridViewSelectionMode.FullRowSelect;

            dgv.BackgroundColor = Color.White;
            dgv.BorderStyle = BorderStyle.None;
            dgv.ColumnHeadersDefaultCellStyle.Font = new Font("Segoe UI", 10f, FontStyle.Bold);
            dgv.DefaultCellStyle.Font = new Font("Segoe UI", 9f);
            dgv.AlternatingRowsDefaultCellStyle.BackColor = Color.FromArgb(240, 240, 240);
        }

        private void ShowError(Exception ex)
        {
            MessageBox.Show(
                "Error: " + ex.Message,
                "System Error",
                MessageBoxButtons.OK,
                MessageBoxIcon.Error);
        }
    }
}
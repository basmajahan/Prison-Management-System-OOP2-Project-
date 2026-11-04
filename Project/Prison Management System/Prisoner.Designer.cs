namespace Prison_Management_System
{
    partial class Prisoner
    {
        /// <summary>
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code

        /// <summary>
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(Prisoner));
            label1 = new Label();
            label5 = new Label();
            textBox1 = new TextBox();
            button1 = new Button();
            label2 = new Label();
            label3 = new Label();
            label4 = new Label();
            label6 = new Label();
            label7 = new Label();
            label8 = new Label();
            label9 = new Label();
            button2 = new Button();
            textBox3 = new TextBox();
            textBox4 = new TextBox();
            textBox5 = new TextBox();
            textBox6 = new TextBox();
            textBox7 = new TextBox();
            textBox8 = new TextBox();
            textBox9 = new TextBox();
            label10 = new Label();
            dateTimePicker1 = new DateTimePicker();
            btnBrowse = new Button();
            pictureBox1 = new PictureBox();
            ((System.ComponentModel.ISupportInitialize)pictureBox1).BeginInit();
            SuspendLayout();
            // 
            // label1
            // 
            label1.AutoSize = true;
            label1.Font = new Font("Monospac821 BT", 21.75F, FontStyle.Bold, GraphicsUnit.Point, 0);
            label1.ForeColor = SystemColors.ActiveCaptionText;
            label1.Location = new Point(375, 9);
            label1.Name = "label1";
            label1.Size = new Size(219, 35);
            label1.TabIndex = 2;
            label1.Text = "Add Prisoner";
            // 
            // label5
            // 
            label5.AutoSize = true;
            label5.BackColor = Color.White;
            label5.Font = new Font("RomanD", 12F, FontStyle.Bold, GraphicsUnit.Point, 0);
            label5.Location = new Point(254, 104);
            label5.Name = "label5";
            label5.Size = new Size(177, 23);
            label5.TabIndex = 10;
            label5.Text = "Prisoner Name :";
            // 
            // textBox1
            // 
            textBox1.Location = new Point(480, 104);
            textBox1.Name = "textBox1";
            textBox1.Size = new Size(232, 23);
            textBox1.TabIndex = 11;
            textBox1.TextChanged += textBox1_TextChanged;
            // 
            // button1
            // 
            button1.BackColor = Color.White;
            button1.Cursor = Cursors.Hand;
            button1.Font = new Font("Trebuchet MS", 12F, FontStyle.Bold, GraphicsUnit.Point, 0);
            button1.Location = new Point(331, 570);
            button1.Name = "button1";
            button1.Size = new Size(93, 41);
            button1.TabIndex = 12;
            button1.Text = "Back";
            button1.UseVisualStyleBackColor = false;
            button1.Click += button1_Click;
            // 
            // label2
            // 
            label2.AutoSize = true;
            label2.BackColor = Color.White;
            label2.Font = new Font("RomanD", 12F, FontStyle.Bold, GraphicsUnit.Point, 0);
            label2.Location = new Point(254, 398);
            label2.Name = "label2";
            label2.Size = new Size(173, 23);
            label2.TabIndex = 13;
            label2.Text = "Admission Date:";
            // 
            // label3
            // 
            label3.AutoSize = true;
            label3.BackColor = Color.White;
            label3.Font = new Font("RomanD", 12F, FontStyle.Bold, GraphicsUnit.Point, 0);
            label3.Location = new Point(254, 348);
            label3.Name = "label3";
            label3.Size = new Size(169, 23);
            label3.TabIndex = 14;
            label3.Text = "Crime Type   :";
            // 
            // label4
            // 
            label4.AutoSize = true;
            label4.BackColor = Color.White;
            label4.Font = new Font("RomanD", 12F, FontStyle.Bold, GraphicsUnit.Point, 0);
            label4.Location = new Point(254, 293);
            label4.Name = "label4";
            label4.Size = new Size(178, 23);
            label4.TabIndex = 15;
            label4.Text = "Date of Birth  :";
            // 
            // label6
            // 
            label6.AutoSize = true;
            label6.BackColor = Color.White;
            label6.Font = new Font("RomanD", 12F, FontStyle.Bold, GraphicsUnit.Point, 0);
            label6.Location = new Point(254, 243);
            label6.Name = "label6";
            label6.Size = new Size(171, 23);
            label6.TabIndex = 16;
            label6.Text = "Prisoner Age  :";
            // 
            // label7
            // 
            label7.AutoSize = true;
            label7.BackColor = Color.White;
            label7.Font = new Font("RomanD", 12F, FontStyle.Bold, GraphicsUnit.Point, 0);
            label7.Location = new Point(254, 194);
            label7.Name = "label7";
            label7.Size = new Size(168, 23);
            label7.TabIndex = 17;
            label7.Text = "Prisoner NID  :";
            // 
            // label8
            // 
            label8.AutoSize = true;
            label8.BackColor = Color.White;
            label8.Font = new Font("RomanD", 12F, FontStyle.Bold, GraphicsUnit.Point, 0);
            label8.Location = new Point(254, 151);
            label8.Name = "label8";
            label8.Size = new Size(168, 23);
            label8.TabIndex = 18;
            label8.Text = "Prisoner ID   :";
            // 
            // label9
            // 
            label9.AutoSize = true;
            label9.BackColor = Color.White;
            label9.Font = new Font("RomanD", 12F, FontStyle.Bold, GraphicsUnit.Point, 0);
            label9.Location = new Point(254, 453);
            label9.Name = "label9";
            label9.Size = new Size(169, 23);
            label9.TabIndex = 19;
            label9.Text = "Discharge Date:";
            // 
            // button2
            // 
            button2.BackColor = Color.White;
            button2.Cursor = Cursors.Hand;
            button2.Font = new Font("Trebuchet MS", 12F, FontStyle.Bold, GraphicsUnit.Point, 0);
            button2.Location = new Point(547, 570);
            button2.Name = "button2";
            button2.Size = new Size(93, 41);
            button2.TabIndex = 20;
            button2.Text = "Add";
            button2.UseVisualStyleBackColor = false;
            button2.Click += button2_Click;
            // 
            // textBox3
            // 
            textBox3.Location = new Point(480, 348);
            textBox3.Name = "textBox3";
            textBox3.Size = new Size(232, 23);
            textBox3.TabIndex = 22;
            textBox3.TextChanged += textBox3_TextChanged;
            // 
            // textBox4
            // 
            textBox4.Location = new Point(480, 398);
            textBox4.Name = "textBox4";
            textBox4.Size = new Size(232, 23);
            textBox4.TabIndex = 23;
            textBox4.TextChanged += textBox4_TextChanged;
            // 
            // textBox5
            // 
            textBox5.Location = new Point(480, 453);
            textBox5.Name = "textBox5";
            textBox5.Size = new Size(232, 23);
            textBox5.TabIndex = 24;
            textBox5.TextChanged += textBox5_TextChanged;
            // 
            // textBox6
            // 
            textBox6.Location = new Point(480, 243);
            textBox6.Name = "textBox6";
            textBox6.Size = new Size(232, 23);
            textBox6.TabIndex = 25;
            textBox6.TextChanged += textBox6_TextChanged;
            // 
            // textBox7
            // 
            textBox7.Location = new Point(480, 196);
            textBox7.Name = "textBox7";
            textBox7.Size = new Size(232, 23);
            textBox7.TabIndex = 26;
            textBox7.TextChanged += textBox7_TextChanged;
            // 
            // textBox8
            // 
            textBox8.Location = new Point(480, 151);
            textBox8.Name = "textBox8";
            textBox8.Size = new Size(232, 23);
            textBox8.TabIndex = 27;
            textBox8.TextChanged += textBox8_TextChanged;
            // 
            // textBox9
            // 
            textBox9.Location = new Point(480, 512);
            textBox9.Name = "textBox9";
            textBox9.Size = new Size(232, 23);
            textBox9.TabIndex = 29;
            textBox9.TextChanged += textBox9_TextChanged;
            // 
            // label10
            // 
            label10.AutoSize = true;
            label10.BackColor = Color.White;
            label10.Font = new Font("RomanD", 12F, FontStyle.Bold, GraphicsUnit.Point, 0);
            label10.Location = new Point(254, 512);
            label10.Name = "label10";
            label10.Size = new Size(163, 23);
            label10.TabIndex = 28;
            label10.Text = "Cell ID      :";
            // 
            // dateTimePicker1
            // 
            dateTimePicker1.Location = new Point(480, 293);
            dateTimePicker1.Name = "dateTimePicker1";
            dateTimePicker1.Size = new Size(232, 23);
            dateTimePicker1.TabIndex = 30;
            dateTimePicker1.ValueChanged += dateTimePicker1_ValueChanged;
            // 
            // btnBrowse
            // 
            btnBrowse.BackColor = Color.White;
            btnBrowse.Font = new Font("RomanD", 9.75F, FontStyle.Regular, GraphicsUnit.Point, 0);
            btnBrowse.Location = new Point(808, 272);
            btnBrowse.Name = "btnBrowse";
            btnBrowse.Size = new Size(150, 36);
            btnBrowse.TabIndex = 33;
            btnBrowse.Text = "Browse Photo";
            btnBrowse.UseVisualStyleBackColor = false;
            btnBrowse.Click += button3_Click;
            // 
            // pictureBox1
            // 
            pictureBox1.BorderStyle = BorderStyle.FixedSingle;
            pictureBox1.Location = new Point(808, 116);
            pictureBox1.Name = "pictureBox1";
            pictureBox1.Size = new Size(150, 150);
            pictureBox1.SizeMode = PictureBoxSizeMode.Zoom;
            pictureBox1.TabIndex = 32;
            pictureBox1.TabStop = false;
            pictureBox1.Click += pictureBox1_Click_1;
            // 
            // Prisoner
            // 
            AutoScaleDimensions = new SizeF(7F, 15F);
            AutoScaleMode = AutoScaleMode.Font;
            BackColor = Color.White;
            BackgroundImage = (Image)resources.GetObject("$this.BackgroundImage");
            BackgroundImageLayout = ImageLayout.Stretch;
            ClientSize = new Size(1003, 641);
            Controls.Add(btnBrowse);
            Controls.Add(pictureBox1);
            Controls.Add(dateTimePicker1);
            Controls.Add(textBox9);
            Controls.Add(label10);
            Controls.Add(textBox8);
            Controls.Add(textBox7);
            Controls.Add(textBox6);
            Controls.Add(textBox5);
            Controls.Add(textBox4);
            Controls.Add(textBox3);
            Controls.Add(button2);
            Controls.Add(label9);
            Controls.Add(label8);
            Controls.Add(label7);
            Controls.Add(label6);
            Controls.Add(label4);
            Controls.Add(label3);
            Controls.Add(label2);
            Controls.Add(button1);
            Controls.Add(textBox1);
            Controls.Add(label5);
            Controls.Add(label1);
            DoubleBuffered = true;
            Name = "Prisoner";
            Text = "Prisoner";
            ((System.ComponentModel.ISupportInitialize)pictureBox1).EndInit();
            ResumeLayout(false);
            PerformLayout();
        }

        #endregion

        private Label label1;
        private Label label5;
        private TextBox textBox1;
        private Button button1;
        private Label label2;
        private Label label3;
        private Label label4;
        private Label label6;
        private Label label7;
        private Label label8;
        private Label label9;
        private Button button2;
        private TextBox textBox3;
        private TextBox textBox4;
        private TextBox textBox5;
        private TextBox textBox6;
        private TextBox textBox7;
        private TextBox textBox8;
        private TextBox textBox9;
        private Label label10;
        private DateTimePicker dateTimePicker1;
        private Button btnBrowse;
        private PictureBox pictureBox1;
    }
}
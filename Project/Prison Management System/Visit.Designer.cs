namespace Prison_Management_System
{
    partial class Visit
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(Visit));
            button2 = new Button();
            label1 = new Label();
            button1 = new Button();
            label5 = new Label();
            label2 = new Label();
            comboBox1 = new ComboBox();
            comboBox2 = new ComboBox();
            dateTimePicker1 = new DateTimePicker();
            label3 = new Label();
            SuspendLayout();
            // 
            // button2
            // 
            button2.BackColor = Color.Snow;
            button2.Cursor = Cursors.Hand;
            button2.Font = new Font("Trebuchet MS", 12F, FontStyle.Bold, GraphicsUnit.Point, 0);
            button2.Location = new Point(503, 340);
            button2.Name = "button2";
            button2.Size = new Size(158, 41);
            button2.TabIndex = 21;
            button2.Text = "Submit Request";
            button2.UseVisualStyleBackColor = false;
            button2.Click += button2_Click;
            // 
            // label1
            // 
            label1.AutoSize = true;
            label1.Font = new Font("Monospac821 BT", 21.75F, FontStyle.Bold, GraphicsUnit.Point, 0);
            label1.Location = new Point(268, 30);
            label1.Name = "label1";
            label1.Size = new Size(270, 35);
            label1.TabIndex = 16;
            label1.Text = "Visit Dashboard";
            // 
            // button1
            // 
            button1.BackColor = Color.Snow;
            button1.Cursor = Cursors.Hand;
            button1.Font = new Font("Trebuchet MS", 12F, FontStyle.Bold, GraphicsUnit.Point, 0);
            button1.Location = new Point(142, 340);
            button1.Name = "button1";
            button1.Size = new Size(158, 41);
            button1.TabIndex = 15;
            button1.Text = "Back";
            button1.UseVisualStyleBackColor = false;
            button1.Click += button1_Click;
            // 
            // label5
            // 
            label5.AutoSize = true;
            label5.BackColor = Color.White;
            label5.Font = new Font("RomanD", 12F, FontStyle.Bold, GraphicsUnit.Point, 0);
            label5.Location = new Point(216, 193);
            label5.Name = "label5";
            label5.Size = new Size(156, 23);
            label5.TabIndex = 23;
            label5.Text = "Visit Hour   :";
            // 
            // label2
            // 
            label2.AutoSize = true;
            label2.BackColor = Color.White;
            label2.Font = new Font("RomanD", 12F, FontStyle.Bold, GraphicsUnit.Point, 0);
            label2.Location = new Point(216, 239);
            label2.Name = "label2";
            label2.Size = new Size(154, 23);
            label2.TabIndex = 22;
            label2.Text = "Visit Duration:";
            // 
            // comboBox1
            // 
            comboBox1.FormattingEnabled = true;
            comboBox1.Items.AddRange(new object[] { "9 am - 11 am", "3 pm - 5 pm" });
            comboBox1.Location = new Point(391, 193);
            comboBox1.Name = "comboBox1";
            comboBox1.Size = new Size(197, 23);
            comboBox1.TabIndex = 24;
            comboBox1.SelectedIndexChanged += comboBox1_SelectedIndexChanged;
            // 
            // comboBox2
            // 
            comboBox2.FormattingEnabled = true;
            comboBox2.Items.AddRange(new object[] { "For 10 minutes", "For 15 minutes" });
            comboBox2.Location = new Point(391, 241);
            comboBox2.Name = "comboBox2";
            comboBox2.Size = new Size(197, 23);
            comboBox2.TabIndex = 25;
            // 
            // dateTimePicker1
            // 
            dateTimePicker1.Location = new Point(391, 145);
            dateTimePicker1.Name = "dateTimePicker1";
            dateTimePicker1.Size = new Size(197, 23);
            dateTimePicker1.TabIndex = 29;
            // 
            // label3
            // 
            label3.AutoSize = true;
            label3.BackColor = Color.White;
            label3.Font = new Font("RomanD", 12F, FontStyle.Bold, GraphicsUnit.Point, 0);
            label3.Location = new Point(216, 145);
            label3.Name = "label3";
            label3.Size = new Size(154, 23);
            label3.TabIndex = 28;
            label3.Text = "Visit Date   :";
            // 
            // Visit
            // 
            AutoScaleDimensions = new SizeF(7F, 15F);
            AutoScaleMode = AutoScaleMode.Font;
            BackColor = Color.Snow;
            BackgroundImage = (Image)resources.GetObject("$this.BackgroundImage");
            BackgroundImageLayout = ImageLayout.Stretch;
            ClientSize = new Size(800, 450);
            Controls.Add(dateTimePicker1);
            Controls.Add(label3);
            Controls.Add(comboBox2);
            Controls.Add(comboBox1);
            Controls.Add(label5);
            Controls.Add(label2);
            Controls.Add(button2);
            Controls.Add(label1);
            Controls.Add(button1);
            DoubleBuffered = true;
            Name = "Visit";
            Text = "Visit";
            Load += Visit_Load;
            ResumeLayout(false);
            PerformLayout();
        }

        #endregion

        private Button button2;
        private Label label1;
        private Button button1;
        private Label label5;
        private Label label2;
        private ComboBox comboBox1;
        private ComboBox comboBox2;
        private DateTimePicker dateTimePicker1;
        private Label label3;
    }
}
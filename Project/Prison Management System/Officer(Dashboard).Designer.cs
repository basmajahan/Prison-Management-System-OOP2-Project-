namespace Prison_Management_System
{
    partial class Officer_Dashboard_
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(Officer_Dashboard_));
            label1 = new Label();
            button1 = new Button();
            button3 = new Button();
            button4 = new Button();
            button5 = new Button();
            dataGridView1 = new DataGridView();
            dataGridView2 = new DataGridView();
            ((System.ComponentModel.ISupportInitialize)dataGridView1).BeginInit();
            ((System.ComponentModel.ISupportInitialize)dataGridView2).BeginInit();
            SuspendLayout();
            // 
            // label1
            // 
            label1.AutoSize = true;
            label1.Font = new Font("Monospac821 BT", 21.75F, FontStyle.Bold, GraphicsUnit.Point, 0);
            label1.Location = new Point(467, 9);
            label1.Name = "label1";
            label1.Size = new Size(304, 35);
            label1.TabIndex = 16;
            label1.Text = "Officer Dashboard";
            label1.Click += label1_Click;
            // 
            // button1
            // 
            button1.BackColor = Color.White;
            button1.Cursor = Cursors.Hand;
            button1.Font = new Font("Trebuchet MS", 12F, FontStyle.Bold, GraphicsUnit.Point, 0);
            button1.Location = new Point(529, 121);
            button1.Name = "button1";
            button1.Size = new Size(162, 52);
            button1.TabIndex = 15;
            button1.Text = "Prisoner Rating";
            button1.UseVisualStyleBackColor = false;
            button1.Click += button1_Click;
            // 
            // button3
            // 
            button3.BackColor = Color.White;
            button3.Cursor = Cursors.Hand;
            button3.Font = new Font("Trebuchet MS", 12F, FontStyle.Bold, GraphicsUnit.Point, 0);
            button3.Location = new Point(860, 121);
            button3.Name = "button3";
            button3.Size = new Size(162, 52);
            button3.TabIndex = 22;
            button3.Text = "Search Prisoner";
            button3.UseVisualStyleBackColor = false;
            button3.Click += button3_Click;
            // 
            // button4
            // 
            button4.BackColor = Color.White;
            button4.Cursor = Cursors.Hand;
            button4.Font = new Font("Trebuchet MS", 12F, FontStyle.Bold, GraphicsUnit.Point, 0);
            button4.Location = new Point(191, 121);
            button4.Name = "button4";
            button4.Size = new Size(162, 52);
            button4.TabIndex = 23;
            button4.Text = "View My Shift ";
            button4.UseVisualStyleBackColor = false;
            button4.Click += button4_Click;
            // 
            // button5
            // 
            button5.BackColor = Color.White;
            button5.Cursor = Cursors.Hand;
            button5.Font = new Font("Trebuchet MS", 12F, FontStyle.Bold, GraphicsUnit.Point, 0);
            button5.Location = new Point(529, 555);
            button5.Name = "button5";
            button5.Size = new Size(212, 52);
            button5.TabIndex = 24;
            button5.Text = "Back to Home Page";
            button5.UseVisualStyleBackColor = false;
            button5.Click += button5_Click;
            // 
            // dataGridView1
            // 
            dataGridView1.BackgroundColor = Color.Thistle;
            dataGridView1.ColumnHeadersHeightSizeMode = DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            dataGridView1.Location = new Point(12, 226);
            dataGridView1.Name = "dataGridView1";
            dataGridView1.Size = new Size(1192, 313);
            dataGridView1.TabIndex = 25;
            // 
            // dataGridView2
            // 
            dataGridView2.BackgroundColor = Color.Thistle;
            dataGridView2.ColumnHeadersHeightSizeMode = DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            dataGridView2.Location = new Point(12, 226);
            dataGridView2.Name = "dataGridView2";
            dataGridView2.Size = new Size(1192, 313);
            dataGridView2.TabIndex = 26;
            dataGridView2.CellContentClick += dataGridView2_CellContentClick;
            // 
            // Officer_Dashboard_
            // 
            AutoScaleDimensions = new SizeF(7F, 15F);
            AutoScaleMode = AutoScaleMode.Font;
            BackColor = Color.White;
            BackgroundImage = (Image)resources.GetObject("$this.BackgroundImage");
            BackgroundImageLayout = ImageLayout.Stretch;
            ClientSize = new Size(1218, 619);
            Controls.Add(dataGridView2);
            Controls.Add(dataGridView1);
            Controls.Add(button5);
            Controls.Add(button4);
            Controls.Add(button3);
            Controls.Add(label1);
            Controls.Add(button1);
            DoubleBuffered = true;
            Name = "Officer_Dashboard_";
            Text = "Officer_Dashboard_";
            Load += Officer_Dashboard__Load;
            ((System.ComponentModel.ISupportInitialize)dataGridView1).EndInit();
            ((System.ComponentModel.ISupportInitialize)dataGridView2).EndInit();
            ResumeLayout(false);
            PerformLayout();
        }

        #endregion
        private Label label1;
        private Button button1;
        private Button button3;
        private Button button4;
        private Button button5;
        private DataGridView dataGridView1;
        private DataGridView dataGridView2;
    }
}
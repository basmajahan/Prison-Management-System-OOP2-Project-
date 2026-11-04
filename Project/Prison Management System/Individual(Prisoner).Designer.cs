namespace Prison_Management_System
{
    partial class Individual_Prisoner_
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(Individual_Prisoner_));
            button2 = new Button();
            label4 = new Label();
            textBox2 = new TextBox();
            label3 = new Label();
            textBox1 = new TextBox();
            label1 = new Label();
            button1 = new Button();
            button3 = new Button();
            pictureBox1 = new PictureBox();
            ((System.ComponentModel.ISupportInitialize)pictureBox1).BeginInit();
            SuspendLayout();
            // 
            // button2
            // 
            button2.BackColor = Color.SandyBrown;
            button2.Cursor = Cursors.Hand;
            button2.Font = new Font("Trebuchet MS", 12F, FontStyle.Bold, GraphicsUnit.Point, 0);
            button2.Location = new Point(390, 361);
            button2.Name = "button2";
            button2.Size = new Size(165, 41);
            button2.TabIndex = 21;
            button2.Text = "View";
            button2.UseVisualStyleBackColor = false;
            button2.Click += button2_Click;
            // 
            // label4
            // 
            label4.AutoSize = true;
            label4.BackColor = Color.LightCyan;
            label4.Font = new Font("RomanD", 12F, FontStyle.Bold, GraphicsUnit.Point, 0);
            label4.Location = new Point(207, 228);
            label4.Name = "label4";
            label4.Size = new Size(155, 23);
            label4.TabIndex = 20;
            label4.Text = "Prisoner ID  :";
            // 
            // textBox2
            // 
            textBox2.BackColor = Color.LightCyan;
            textBox2.Location = new Point(385, 228);
            textBox2.Name = "textBox2";
            textBox2.Size = new Size(153, 23);
            textBox2.TabIndex = 19;
            textBox2.TextChanged += textBox2_TextChanged;
            // 
            // label3
            // 
            label3.AutoSize = true;
            label3.BackColor = Color.LightCyan;
            label3.Font = new Font("RomanD", 12F, FontStyle.Bold, GraphicsUnit.Point, 0);
            label3.Location = new Point(207, 172);
            label3.Name = "label3";
            label3.Size = new Size(164, 23);
            label3.TabIndex = 18;
            label3.Text = "Prisoner Name:";
            // 
            // textBox1
            // 
            textBox1.BackColor = Color.LightCyan;
            textBox1.Location = new Point(385, 172);
            textBox1.Name = "textBox1";
            textBox1.Size = new Size(153, 23);
            textBox1.TabIndex = 17;
            textBox1.TextChanged += textBox1_TextChanged;
            // 
            // label1
            // 
            label1.AutoSize = true;
            label1.BackColor = Color.Gainsboro;
            label1.Font = new Font("Monospac821 BT", 21.75F, FontStyle.Bold, GraphicsUnit.Point, 0);
            label1.Location = new Point(207, 23);
            label1.Name = "label1";
            label1.Size = new Size(542, 35);
            label1.TabIndex = 16;
            label1.Text = "Individual Prisoner Information";
            // 
            // button1
            // 
            button1.BackColor = Color.SandyBrown;
            button1.Cursor = Cursors.Hand;
            button1.Font = new Font("Trebuchet MS", 12F, FontStyle.Bold, GraphicsUnit.Point, 0);
            button1.Location = new Point(117, 361);
            button1.Name = "button1";
            button1.Size = new Size(165, 41);
            button1.TabIndex = 15;
            button1.Text = "Back";
            button1.UseVisualStyleBackColor = false;
            button1.Click += button1_Click;
            // 
            // button3
            // 
            button3.BackColor = Color.SandyBrown;
            button3.Cursor = Cursors.Hand;
            button3.Font = new Font("Trebuchet MS", 12F, FontStyle.Bold, GraphicsUnit.Point, 0);
            button3.Location = new Point(640, 361);
            button3.Name = "button3";
            button3.Size = new Size(165, 41);
            button3.TabIndex = 22;
            button3.Text = "Remove Prisoner";
            button3.UseVisualStyleBackColor = false;
            button3.Click += button3_Click;
            // 
            // pictureBox1
            // 
            pictureBox1.BackColor = Color.LightCyan;
            pictureBox1.BorderStyle = BorderStyle.FixedSingle;
            pictureBox1.Location = new Point(666, 133);
            pictureBox1.Name = "pictureBox1";
            pictureBox1.Size = new Size(150, 150);
            pictureBox1.SizeMode = PictureBoxSizeMode.Zoom;
            pictureBox1.TabIndex = 31;
            pictureBox1.TabStop = false;
            // 
            // Individual_Prisoner_
            // 
            AutoScaleDimensions = new SizeF(7F, 15F);
            AutoScaleMode = AutoScaleMode.Font;
            BackColor = Color.White;
            BackgroundImage = (Image)resources.GetObject("$this.BackgroundImage");
            BackgroundImageLayout = ImageLayout.Stretch;
            ClientSize = new Size(914, 450);
            Controls.Add(pictureBox1);
            Controls.Add(button3);
            Controls.Add(button2);
            Controls.Add(label4);
            Controls.Add(textBox2);
            Controls.Add(label3);
            Controls.Add(textBox1);
            Controls.Add(label1);
            Controls.Add(button1);
            Name = "Individual_Prisoner_";
            Text = "Individual_Prisoner_";
            Load += Individual_Prisoner__Load;
            ((System.ComponentModel.ISupportInitialize)pictureBox1).EndInit();
            ResumeLayout(false);
            PerformLayout();
        }

        #endregion

        private Button button2;
        private Label label4;
        private TextBox textBox2;
        private Label label3;
        private TextBox textBox1;
        private Label label1;
        private Button button1;
        private Button button3;
        private PictureBox pictureBox1;
    }
}
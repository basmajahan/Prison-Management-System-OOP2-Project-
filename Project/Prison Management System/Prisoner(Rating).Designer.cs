namespace Prison_Management_System
{
    partial class Prisoner_Rating_
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(Prisoner_Rating_));
            button2 = new Button();
            label4 = new Label();
            textBox2 = new TextBox();
            label3 = new Label();
            textBox1 = new TextBox();
            label1 = new Label();
            button1 = new Button();
            label2 = new Label();
            SuspendLayout();
            // 
            // button2
            // 
            button2.BackColor = Color.White;
            button2.Cursor = Cursors.Hand;
            button2.Font = new Font("Trebuchet MS", 12F, FontStyle.Bold, GraphicsUnit.Point, 0);
            button2.Location = new Point(508, 365);
            button2.Name = "button2";
            button2.Size = new Size(95, 41);
            button2.TabIndex = 28;
            button2.Text = "Submit";
            button2.UseVisualStyleBackColor = false;
            button2.Click += button2_Click;
            // 
            // label4
            // 
            label4.AutoSize = true;
            label4.BackColor = Color.White;
            label4.Font = new Font("RomanD", 12F, FontStyle.Bold, GraphicsUnit.Point, 0);
            label4.Location = new Point(216, 201);
            label4.Name = "label4";
            label4.Size = new Size(168, 23);
            label4.TabIndex = 27;
            label4.Text = "Prisoner ID   :";
            // 
            // textBox2
            // 
            textBox2.Font = new Font("RomanD", 12F, FontStyle.Bold, GraphicsUnit.Point, 0);
            textBox2.Location = new Point(407, 201);
            textBox2.Name = "textBox2";
            textBox2.Size = new Size(196, 30);
            textBox2.TabIndex = 26;
            textBox2.TextChanged += textBox2_TextChanged;
            // 
            // label3
            // 
            label3.AutoSize = true;
            label3.BackColor = Color.White;
            label3.Font = new Font("RomanD", 12F, FontStyle.Bold, GraphicsUnit.Point, 0);
            label3.Location = new Point(216, 145);
            label3.Name = "label3";
            label3.Size = new Size(164, 23);
            label3.TabIndex = 25;
            label3.Text = "Prisoner Name:";
            // 
            // textBox1
            // 
            textBox1.Font = new Font("RomanD", 12F, FontStyle.Bold, GraphicsUnit.Point, 0);
            textBox1.Location = new Point(407, 145);
            textBox1.Name = "textBox1";
            textBox1.Size = new Size(196, 30);
            textBox1.TabIndex = 24;
            textBox1.TextChanged += textBox1_TextChanged;
            // 
            // label1
            // 
            label1.AutoSize = true;
            label1.Font = new Font("Monospac821 BT", 21.75F, FontStyle.Bold, GraphicsUnit.Point, 0);
            label1.Location = new Point(272, 39);
            label1.Name = "label1";
            label1.Size = new Size(270, 35);
            label1.TabIndex = 23;
            label1.Text = "Prisoner Rating";
            label1.Click += label1_Click;
            // 
            // button1
            // 
            button1.BackColor = Color.White;
            button1.Cursor = Cursors.Hand;
            button1.Font = new Font("Trebuchet MS", 12F, FontStyle.Bold, GraphicsUnit.Point, 0);
            button1.Location = new Point(216, 365);
            button1.Name = "button1";
            button1.Size = new Size(95, 41);
            button1.TabIndex = 22;
            button1.Text = "Back";
            button1.UseVisualStyleBackColor = false;
            button1.Click += button1_Click;
            // 
            // label2
            // 
            label2.AutoSize = true;
            label2.BackColor = Color.White;
            label2.Font = new Font("RomanD", 12F, FontStyle.Bold, GraphicsUnit.Point, 0);
            label2.Location = new Point(216, 264);
            label2.Name = "label2";
            label2.Size = new Size(171, 23);
            label2.TabIndex = 29;
            label2.Text = "Prisoner Rating:";
            label2.Click += label2_Click;
            // 
            // Prisoner_Rating_
            // 
            AutoScaleDimensions = new SizeF(7F, 15F);
            AutoScaleMode = AutoScaleMode.Font;
            BackColor = Color.White;
            BackgroundImage = (Image)resources.GetObject("$this.BackgroundImage");
            BackgroundImageLayout = ImageLayout.Stretch;
            ClientSize = new Size(800, 450);
            Controls.Add(label2);
            Controls.Add(button2);
            Controls.Add(label4);
            Controls.Add(textBox2);
            Controls.Add(label3);
            Controls.Add(textBox1);
            Controls.Add(label1);
            Controls.Add(button1);
            DoubleBuffered = true;
            Name = "Prisoner_Rating_";
            Text = "Prisoner_Rating_";
            Load += Prisoner_Rating__Load;
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
        private Label label2;
    }
}
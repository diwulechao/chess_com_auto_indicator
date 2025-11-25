namespace chessindicator
{
    partial class Form1
    {
        /// <summary>
        ///  Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        ///  Clean up any resources being used.
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
        ///  Required method for Designer support - do not modify
        ///  the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            panel1 = new Panel();
            radioButton2 = new RadioButton();
            radioButton1 = new RadioButton();
            panel2 = new Panel();
            label3 = new Label();
            radioButton12 = new RadioButton();
            textBox4 = new TextBox();
            radioButton6 = new RadioButton();
            radioButton5 = new RadioButton();
            radioButton4 = new RadioButton();
            radioButton11 = new RadioButton();
            radioButton3 = new RadioButton();
            radioButton10 = new RadioButton();
            radioButton9 = new RadioButton();
            radioButton7 = new RadioButton();
            label2 = new Label();
            radioButton8 = new RadioButton();
            textBox1 = new TextBox();
            panel3 = new Panel();
            textBox2 = new TextBox();
            panel4 = new Panel();
            checkBox1 = new CheckBox();
            checkBox2 = new CheckBox();
            checkBox3 = new CheckBox();
            textBox3 = new TextBox();
            checkBox4 = new CheckBox();
            checkBox5 = new CheckBox();
            checkBox6 = new CheckBox();
            btnRecalculate = new Button();
            panel1.SuspendLayout();
            panel2.SuspendLayout();
            SuspendLayout();
            // 
            // panel1
            // 
            panel1.Controls.Add(radioButton2);
            panel1.Controls.Add(radioButton1);
            panel1.Location = new Point(31, 5);
            panel1.Name = "panel1";
            panel1.Size = new Size(168, 33);
            panel1.TabIndex = 0;
            // 
            // radioButton2
            // 
            radioButton2.AutoSize = true;
            radioButton2.Location = new Point(87, 3);
            radioButton2.Name = "radioButton2";
            radioButton2.Size = new Size(53, 19);
            radioButton2.TabIndex = 1;
            radioButton2.Text = "Black";
            radioButton2.UseVisualStyleBackColor = true;
            radioButton2.CheckedChanged += radioButton2_CheckedChanged;
            // 
            // radioButton1
            // 
            radioButton1.AutoSize = true;
            radioButton1.Checked = true;
            radioButton1.Location = new Point(25, 3);
            radioButton1.Name = "radioButton1";
            radioButton1.Size = new Size(56, 19);
            radioButton1.TabIndex = 0;
            radioButton1.TabStop = true;
            radioButton1.Text = "White";
            radioButton1.UseVisualStyleBackColor = true;
            radioButton1.CheckedChanged += radioButton1_CheckedChanged;
            // 
            // panel2
            // 
            panel2.Controls.Add(label3);
            panel2.Controls.Add(radioButton12);
            panel2.Controls.Add(textBox4);
            panel2.Controls.Add(radioButton6);
            panel2.Controls.Add(radioButton5);
            panel2.Controls.Add(radioButton4);
            panel2.Controls.Add(radioButton11);
            panel2.Controls.Add(radioButton3);
            panel2.Controls.Add(radioButton10);
            panel2.Controls.Add(radioButton9);
            panel2.Controls.Add(radioButton7);
            panel2.Controls.Add(label2);
            panel2.Controls.Add(radioButton8);
            panel2.Location = new Point(31, 44);
            panel2.Name = "panel2";
            panel2.Size = new Size(168, 194);
            panel2.TabIndex = 1;
            // 
            // label3
            // 
            label3.AutoSize = true;
            label3.Location = new Point(45, 139);
            label3.Name = "label3";
            label3.Size = new Size(38, 15);
            label3.TabIndex = 13;
            label3.Text = "depth";
            // 
            // radioButton12
            // 
            radioButton12.AutoSize = true;
            radioButton12.Location = new Point(99, 109);
            radioButton12.Name = "radioButton12";
            radioButton12.Size = new Size(56, 19);
            radioButton12.TabIndex = 11;
            radioButton12.Text = "5 secs";
            radioButton12.UseVisualStyleBackColor = true;
            radioButton12.CheckedChanged += radioButton12_CheckedChanged;
            // 
            // textBox4
            // 
            textBox4.Location = new Point(12, 135);
            textBox4.Name = "textBox4";
            textBox4.Size = new Size(28, 23);
            textBox4.TabIndex = 12;
            textBox4.TextChanged += textBox4_TextChanged;
            // 
            // radioButton6
            // 
            radioButton6.AutoSize = true;
            radioButton6.Location = new Point(99, 9);
            radioButton6.Name = "radioButton6";
            radioButton6.Size = new Size(59, 19);
            radioButton6.TabIndex = 3;
            radioButton6.Text = "100ms";
            radioButton6.UseVisualStyleBackColor = true;
            radioButton6.CheckedChanged += radioButton6_CheckedChanged;
            // 
            // radioButton5
            // 
            radioButton5.AutoSize = true;
            radioButton5.Location = new Point(99, 84);
            radioButton5.Name = "radioButton5";
            radioButton5.Size = new Size(56, 19);
            radioButton5.TabIndex = 2;
            radioButton5.Text = "2 secs";
            radioButton5.UseVisualStyleBackColor = true;
            radioButton5.CheckedChanged += radioButton5_CheckedChanged;
            // 
            // radioButton4
            // 
            radioButton4.AutoSize = true;
            radioButton4.Location = new Point(99, 59);
            radioButton4.Name = "radioButton4";
            radioButton4.Size = new Size(51, 19);
            radioButton4.TabIndex = 1;
            radioButton4.Text = "1 sec";
            radioButton4.UseVisualStyleBackColor = true;
            radioButton4.CheckedChanged += radioButton4_CheckedChanged;
            // 
            // radioButton11
            // 
            radioButton11.AutoSize = true;
            radioButton11.Location = new Point(12, 110);
            radioButton11.Name = "radioButton11";
            radioButton11.Size = new Size(65, 19);
            radioButton11.TabIndex = 10;
            radioButton11.Text = "6 depth";
            radioButton11.UseVisualStyleBackColor = true;
            radioButton11.CheckedChanged += radioButton11_CheckedChanged;
            // 
            // radioButton3
            // 
            radioButton3.AutoSize = true;
            radioButton3.Location = new Point(99, 34);
            radioButton3.Name = "radioButton3";
            radioButton3.Size = new Size(59, 19);
            radioButton3.TabIndex = 0;
            radioButton3.Text = "500ms";
            radioButton3.UseVisualStyleBackColor = true;
            radioButton3.CheckedChanged += radioButton3_CheckedChanged;
            // 
            // radioButton10
            // 
            radioButton10.AutoSize = true;
            radioButton10.Location = new Point(12, 85);
            radioButton10.Name = "radioButton10";
            radioButton10.Size = new Size(65, 19);
            radioButton10.TabIndex = 9;
            radioButton10.Text = "5 depth";
            radioButton10.UseVisualStyleBackColor = true;
            radioButton10.CheckedChanged += radioButton10_CheckedChanged;
            // 
            // radioButton9
            // 
            radioButton9.AutoSize = true;
            radioButton9.Location = new Point(12, 10);
            radioButton9.Name = "radioButton9";
            radioButton9.Size = new Size(65, 19);
            radioButton9.TabIndex = 6;
            radioButton9.Text = "2 depth";
            radioButton9.UseVisualStyleBackColor = true;
            radioButton9.CheckedChanged += radioButton9_CheckedChanged;
            // 
            // radioButton7
            // 
            radioButton7.AutoSize = true;
            radioButton7.Checked = true;
            radioButton7.Location = new Point(12, 60);
            radioButton7.Name = "radioButton7";
            radioButton7.Size = new Size(65, 19);
            radioButton7.TabIndex = 4;
            radioButton7.TabStop = true;
            radioButton7.Text = "4 depth";
            radioButton7.UseVisualStyleBackColor = true;
            radioButton7.CheckedChanged += radioButton7_CheckedChanged;
            // 
            // label2
            // 
            label2.Location = new Point(3, 161);
            label2.Name = "label2";
            label2.Size = new Size(169, 33);
            label2.TabIndex = 8;
            label2.Text = "limit depth to avoid get caught";
            // 
            // radioButton8
            // 
            radioButton8.AutoSize = true;
            radioButton8.Location = new Point(12, 35);
            radioButton8.Name = "radioButton8";
            radioButton8.Size = new Size(65, 19);
            radioButton8.TabIndex = 5;
            radioButton8.Text = "3 depth";
            radioButton8.UseVisualStyleBackColor = true;
            radioButton8.CheckedChanged += radioButton8_CheckedChanged;
            // 
            // textBox1
            // 
            textBox1.Anchor = AnchorStyles.Top | AnchorStyles.Bottom | AnchorStyles.Left | AnchorStyles.Right;
            textBox1.Location = new Point(4, 273);
            textBox1.Multiline = true;
            textBox1.Name = "textBox1";
            textBox1.ReadOnly = true;
            textBox1.ScrollBars = ScrollBars.Vertical;
            textBox1.Size = new Size(317, 485);
            textBox1.TabIndex = 2;
            // 
            // panel3
            // 
            panel3.Location = new Point(4, 1);
            panel3.Name = "panel3";
            panel3.Size = new Size(18, 205);
            panel3.TabIndex = 3;
            // 
            // textBox2
            // 
            textBox2.Location = new Point(4, 244);
            textBox2.Name = "textBox2";
            textBox2.ReadOnly = true;
            textBox2.Size = new Size(57, 23);
            textBox2.TabIndex = 4;
            // 
            // panel4
            // 
            panel4.BackColor = SystemColors.ActiveCaption;
            panel4.Location = new Point(4, 101);
            panel4.Name = "panel4";
            panel4.Size = new Size(20, 3);
            panel4.TabIndex = 5;
            // 
            // checkBox1
            // 
            checkBox1.AutoSize = true;
            checkBox1.Checked = true;
            checkBox1.CheckState = CheckState.Checked;
            checkBox1.Location = new Point(205, 5);
            checkBox1.Name = "checkBox1";
            checkBox1.Size = new Size(66, 19);
            checkBox1.TabIndex = 6;
            checkBox1.Text = "Overlay";
            checkBox1.UseVisualStyleBackColor = true;
            checkBox1.CheckedChanged += checkBox1_CheckedChanged;
            // 
            // checkBox2
            // 
            checkBox2.AutoSize = true;
            checkBox2.Location = new Point(204, 28);
            checkBox2.Name = "checkBox2";
            checkBox2.Size = new Size(123, 19);
            checkBox2.TabIndex = 7;
            checkBox2.Text = "ur move detection";
            checkBox2.UseVisualStyleBackColor = true;
            // 
            // checkBox3
            // 
            checkBox3.AutoSize = true;
            checkBox3.Location = new Point(204, 54);
            checkBox3.Name = "checkBox3";
            checkBox3.Size = new Size(124, 19);
            checkBox3.TabIndex = 8;
            checkBox3.Text = "auto play vs player";
            checkBox3.UseVisualStyleBackColor = true;
            checkBox3.CheckedChanged += checkBox3_CheckedChanged;
            // 
            // textBox3
            // 
            textBox3.Location = new Point(67, 244);
            textBox3.Name = "textBox3";
            textBox3.ReadOnly = true;
            textBox3.Size = new Size(54, 23);
            textBox3.TabIndex = 9;
            // 
            // checkBox4
            // 
            checkBox4.AutoSize = true;
            checkBox4.Location = new Point(204, 78);
            checkBox4.Name = "checkBox4";
            checkBox4.Size = new Size(110, 19);
            checkBox4.TabIndex = 10;
            checkBox4.Text = "auto play vs bot";
            checkBox4.UseVisualStyleBackColor = true;
            checkBox4.CheckedChanged += checkBox4_CheckedChanged;
            // 
            // checkBox5
            // 
            checkBox5.AutoSize = true;
            checkBox5.Location = new Point(204, 101);
            checkBox5.Name = "checkBox5";
            checkBox5.Size = new Size(108, 19);
            checkBox5.TabIndex = 11;
            checkBox5.Text = "auto new game";
            checkBox5.UseVisualStyleBackColor = true;
            checkBox5.CheckedChanged += checkBox5_CheckedChanged;
            // 
            // checkBox6
            // 
            checkBox6.AutoSize = true;
            checkBox6.Location = new Point(204, 126);
            checkBox6.Name = "checkBox6";
            checkBox6.Size = new Size(117, 19);
            checkBox6.TabIndex = 12;
            checkBox6.Text = "auto switch color";
            checkBox6.UseVisualStyleBackColor = true;
            checkBox6.CheckedChanged += checkBox6_CheckedChanged;
            // 
            // btnRecalculate
            // 
            btnRecalculate.Location = new Point(31, 151);
            btnRecalculate.Name = "btnRecalculate";
            btnRecalculate.Size = new Size(100, 30);
            btnRecalculate.TabIndex = 13;
            btnRecalculate.Text = "Recalculate";
            btnRecalculate.UseVisualStyleBackColor = true;
            btnRecalculate.Click += btnRecalculate_Click;
            // 
            // Form1
            // 
            AutoScaleDimensions = new SizeF(7F, 15F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(333, 800);
            Controls.Add(btnRecalculate);
            Controls.Add(checkBox6);
            Controls.Add(checkBox5);
            Controls.Add(checkBox4);
            Controls.Add(textBox3);
            Controls.Add(checkBox3);
            Controls.Add(checkBox2);
            Controls.Add(checkBox1);
            Controls.Add(panel4);
            Controls.Add(textBox2);
            Controls.Add(panel3);
            Controls.Add(textBox1);
            Controls.Add(panel2);
            Controls.Add(panel1);
            Name = "Form1";
            Text = "auto indicator";
            Load += Form1_Load;
            panel1.ResumeLayout(false);
            panel1.PerformLayout();
            panel2.ResumeLayout(false);
            panel2.PerformLayout();
            ResumeLayout(false);
            PerformLayout();
        }

        #endregion

        private Panel panel1;
        public RadioButton radioButton2;
        public RadioButton radioButton1;
        private Panel panel2;
        private RadioButton radioButton5;
        private RadioButton radioButton4;
        private RadioButton radioButton3;
        private RadioButton radioButton6;
        private RadioButton radioButton8;
        private RadioButton radioButton7;
        private RadioButton radioButton9;
        private TextBox textBox1;
        public Panel panel3;
        public TextBox textBox2;
        private Panel panel4;
        private Label label2;
        private RadioButton radioButton12;
        private RadioButton radioButton11;
        private RadioButton radioButton10;
        public CheckBox checkBox1;
        public CheckBox checkBox2;
        public CheckBox checkBox3;
        public TextBox textBox3;
        public CheckBox checkBox4;
        private Label label3;
        private TextBox textBox4;
        public CheckBox checkBox5;
        public CheckBox checkBox6;
        private Button btnRecalculate;
    }
}

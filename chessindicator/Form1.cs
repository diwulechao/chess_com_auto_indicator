namespace chessindicator
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            this.TopMost = true;
            this.FormClosed += new FormClosedEventHandler(MainForm_FormClosed);
            InitializeComponent();

            this.panel3.Paint += new System.Windows.Forms.PaintEventHandler(this.panelEvalBar_Paint);
        }
        private void MainForm_FormClosed(object sender, FormClosedEventArgs e)
        {
            Application.Exit();
        }

        private void Form1_Load(object sender, EventArgs e)
        {
            // Get the working area of the screen where the form is displayed (excludes taskbar)
            var workingArea = Screen.GetWorkingArea(this);

            // Position the form so its right edge touches the right edge of the screen
            this.Location = new Point(workingArea.Right - this.Width, workingArea.Top);
        }

        private void radioButton1_CheckedChanged(object sender, EventArgs e)
        {
            if (radioButton1.Checked)
            {
                Program.chess_color = 'w';
                textBox1.Text = "switched to white\n";
            }
        }

        private void radioButton2_CheckedChanged(object sender, EventArgs e)
        {
            if (radioButton2.Checked)
            {
                Program.chess_color = 'b';
                textBox1.Text = "switched to black\n";
            }
        }

        private void radioButton3_CheckedChanged(object sender, EventArgs e)
        {
            if (radioButton3.Checked)
            {
                Program.chess_speed = "500";
            }
        }

        private void radioButton4_CheckedChanged(object sender, EventArgs e)
        {
            if (radioButton4.Checked)
            {
                Program.chess_speed = "1000";
            }
        }

        private void radioButton5_CheckedChanged(object sender, EventArgs e)
        {
            if (radioButton5.Checked)
            {
                Program.chess_speed = "2000";
            }
        }

        private void radioButton6_CheckedChanged(object sender, EventArgs e)
        {
            if (radioButton6.Checked)
            {
                Program.chess_speed = "100";
            }
        }

        private void radioButton8_CheckedChanged(object sender, EventArgs e)
        {
            if (radioButton8.Checked)
            {
                Program.chess_speed = "3";
            }
        }

        private void radioButton9_CheckedChanged(object sender, EventArgs e)
        {
            if (radioButton9.Checked)
            {
                Program.chess_speed = "2";
            }
        }

        private void radioButton7_CheckedChanged(object sender, EventArgs e)
        {
            if (radioButton7.Checked)
            {
                Program.chess_speed = "4";
            }
        }

        public void AppendToConsole(string message)
        {
            if (textBox1.InvokeRequired)
            {
                textBox1.Invoke(new Action(() => AppendToConsole(message)));
                return;
            }

            textBox1.AppendText(message + Environment.NewLine);
            textBox1.SelectionStart = textBox1.Text.Length;
            textBox1.ScrollToCaret();
        }

        public double evalBarValue = 0.5; // 0.0 = all Black, 1.0 = all White

        private void panelEvalBar_Paint(object sender, PaintEventArgs e)
        {
            var g = e.Graphics;
            int height = panel3.Height;
            int width = panel3.Width;

            // Calculate white portion (on bottom)
            int whiteHeight = (int)(height * evalBarValue);
            int blackHeight = height - whiteHeight;

            if (Program.chess_color == 'w')
            {
                g.FillRectangle(Brushes.Black, 0, 0, width, blackHeight);
                g.FillRectangle(Brushes.White, 0, blackHeight, width, whiteHeight);
            }
            else
            {
                g.FillRectangle(Brushes.White, 0, 0, width, blackHeight);
                g.FillRectangle(Brushes.Black, 0, blackHeight, width, whiteHeight);
            }
            
        }
    }
}

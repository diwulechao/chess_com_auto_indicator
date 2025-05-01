namespace chessindicator
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            this.TopMost = true;
            this.FormClosed += new FormClosedEventHandler(MainForm_FormClosed);
            InitializeComponent();
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
            }
        }

        private void radioButton2_CheckedChanged(object sender, EventArgs e)
        {
            if (radioButton2.Checked)
            {
                Program.chess_color = 'b';
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
    }
}

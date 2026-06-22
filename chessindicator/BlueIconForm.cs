using System;
using System.Drawing;
using System.Runtime.InteropServices;
using System.Windows.Forms;

public class BlueIconForm : Form
{
    public BlueIconForm(Point location)
    {
        this.FormBorderStyle = FormBorderStyle.None;
        this.StartPosition = FormStartPosition.Manual;
        this.Location = location;
        this.Size = new Size(8, 8); // icon size
        this.TopMost = true;
        this.BackColor = Color.Blue;
        this.ShowInTaskbar = false;

        SetStyle(ControlStyles.SupportsTransparentBackColor, true);
        this.BackColor = Color.Blue;
        this.TransparencyKey = Color.Lime; // choose a key color if needed
    }

    protected override bool ShowWithoutActivation => true;

    protected override CreateParams CreateParams
    {
        get
        {
            const int WS_EX_LAYERED = 0x80000;
            const int WS_EX_TRANSPARENT = 0x20;
            const int WS_EX_TOOLWINDOW = 0x80;
            const int WS_EX_NOACTIVATE = 0x08000000;

            CreateParams cp = base.CreateParams;
            cp.ExStyle |= WS_EX_LAYERED | WS_EX_TRANSPARENT | WS_EX_TOOLWINDOW | WS_EX_NOACTIVATE;
            return cp;
        }
    }

    protected override void OnPaint(PaintEventArgs e)
    {
        // Draw a red circle
        using (SolidBrush brush = new SolidBrush(Color.Blue))
        {
            e.Graphics.FillEllipse(brush, 0, 0, 32, 32);
        }
    }
}

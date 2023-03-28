using System;
using System.Windows.Forms;
using System.Drawing;
using System.ComponentModel;

namespace Music_media.customControl
{
    internal class customTextbox : TextBox
    {
        [Browsable(true)]
        public Color BorderColor { get; set; }
        private bool hasFocus = false;
        protected override void OnPaint(PaintEventArgs e)
        {
            base.OnPaint(e);
            if (hasFocus)
            {
                ControlPaint.DrawBorder(e.Graphics, this.ClientRectangle, BorderColor, ButtonBorderStyle.Solid);
            }
            using (Pen pen = new Pen(BorderColor, 1))
            {
                e.Graphics.DrawRectangle(pen, 0, 0, Width - 1, Height - 1);
            }
        }

        protected override void OnEnter(EventArgs e)
        {
            base.OnEnter(e);
            hasFocus = true;
            this.Invalidate();
        }

        protected override void OnLeave(EventArgs e)
        {
            base.OnLeave(e);
            hasFocus = false;
            this.Invalidate();
        }
    }
}

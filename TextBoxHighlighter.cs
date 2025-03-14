using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace WinForms.Extension
{
    /// <summary>
    /// Helper class with methods to activate customizable highlighting on a collection of System.Windows.Forms.TextBox on their Enter event.
    /// </summary>
    public class TextBoxHighlighter
    {
        private readonly float _borderWidth = 2.5f;
        private readonly int _outerVariance = 2;

        public TextBoxHighlighter() { }

        /// <summary>
        /// Creates an instance of TextBoxHighlighter with custom border width and variance to the border.
        /// </summary>
        /// <param name="borderWidth">Sets the border width in pixels.</param>
        /// <param name="outerVariance">Sets the variance / tolerance / margin to the border in pixels.</param>
        public TextBoxHighlighter(float borderWidth, int outerVariance)
        {
            _borderWidth = borderWidth;
            _outerVariance = outerVariance;
        }

        /// <summary>
        /// Activates highlighting of all TextBoxes in a form on their Enter event.
        /// </summary>
        /// <param name="frm">Sets the form in which the TextBoxes will be highlighted.</param>
        public void ActivateTextBoxHighlight(Form frm)
        {
            //get all textboxes in the form and set their Enter / Leave events
            foreach (Control ctrl in frm.Controls)
            {
                if (ctrl.GetType() == typeof(TextBox))
                {
                    ctrl.Enter += Tb_Enter;
                    ctrl.Leave += Ctrl_Leave;
                }
            }
        }

        /// <summary>
        /// Activates highlighting of all TextBoxes in a form on their Enter event.
        /// </summary>
        /// <param name="tbHighlighting">The collection of TextBoxes that will be highlighted.</param>
        public void ActivateTextBoxHighlight(ICollection<TextBox> tbHighlighting)
        {
            foreach (TextBox tb in tbHighlighting)
            {
                tb.Enter += Tb_Enter;
                tb.Leave += Ctrl_Leave;
            }
        }

        protected void Ctrl_Leave(object? sender, EventArgs e)
        {
            //clear all borders via a repaint of the form
            TextBox tb = (TextBox)sender!;
            tb.FindForm().Invalidate();
        }

        protected void Tb_Enter(object? sender, EventArgs e)
        {
            TextBox tb = (TextBox)sender!;
            Highlight(tb, new PaintEventArgs(tb.FindForm().CreateGraphics(), tb.FindForm().ClientRectangle));
        }

        protected void Highlight(TextBox sender, PaintEventArgs e)
        {
            //clear all borders
            sender.FindForm().Refresh();
            //draw border
            Pen p = new Pen(Color.Yellow, _borderWidth);
            Graphics g = e.Graphics;

            g.DrawRectangle(p, new Rectangle(sender.Location.X - _outerVariance, sender.Location.Y - _outerVariance, 
                sender.Width + _outerVariance, sender.Height + _outerVariance));
        }
    }
}

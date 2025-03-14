using System;
using System.CodeDom;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace WinForms.Extension
{
    public static class FormExtension
    {
        private static List<Form> _srcFrms = new List<Form>();
        private static List<Form> _topMostFrms = new List<Form>();
        private static List<frmDarkening> _darkFrms = new List<frmDarkening>();

        /// <summary>
        /// Darkens the form. This event is usually called before showing another form on top.
        /// </summary>
        /// <param name="sourceFrm">Sets the form that will be darkened.</param>
        /// <param name="topMostForm">Sets the form that will be showed over the darkened source form.</param>
        public static void DarkenForm(this Form sourceFrm, Form topMostForm)
        {
            SetFormsAndEvents(sourceFrm, topMostForm);

            //instanciate darkening form and show it
            _darkFrms.Add(new frmDarkening(sourceFrm));
            _darkFrms.Last().Show();
        }

        /// <summary>
        /// Darkens the form. This event is usually called before showing another form on top.
        /// </summary>
        /// <param name="sourceFrm">Sets the form that will be darkened.</param>
        /// <param name="topMostForm">Sets the form that will be showed over the darkened source form.</param>
        /// <param name="darkenOpacity">Sets the opacity in % for the darkened form. The lower the value, the more transparent is the source form.</param>
        /// <param name="darkenColor">Sets the color of the darkened source form.</param>
        public static void DarkenForm(this Form sourceFrm, Form topMostForm, byte darkenOpacity = 80, Color? darkenColor = null)
        {
            SetFormsAndEvents(sourceFrm, topMostForm);
            
            //set default color
            darkenColor = darkenColor ?? Color.FromArgb(64, 64, 64);

            //instanciate darkening form and show it
            _darkFrms.Add(new frmDarkening(sourceFrm));
            _darkFrms.Last().Opacity = (double)darkenOpacity / 100;
            _darkFrms.Last().BackColor = (Color)darkenColor;
            _darkFrms.Last().Show();
        }

        private static void SetFormsAndEvents(Form sourceFrm, Form topMostForm)
        {
            _srcFrms.Add(sourceFrm);
            _topMostFrms.Add(topMostForm);

            //set events
            _topMostFrms.Last().FormClosing += _topMostfrm_FormClosing;
            _topMostFrms.Last().GotFocus += _topMostfrm_GotFocus;
        }

        private static void _topMostfrm_FormClosing(object? sender, FormClosingEventArgs e)
        {
            //close dark form (topmost is that the closing of the dark form looks clean)
            _srcFrms.Last().TopMost = true;
            _darkFrms.Last().Dispose();
            _srcFrms.Last().TopMost = false;

            _topMostFrms.Last().Dispose();

            _darkFrms.Remove(_darkFrms.Last());
            _topMostFrms.Remove(_topMostFrms.Last());

            _srcFrms.Remove(_srcFrms.Last());
        }

        private static void _topMostfrm_GotFocus(object? sender, EventArgs e)
        {
            _darkFrms.Last().Visible = true;
        }
    }
}

using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace WinForms.Extension
{
    internal sealed partial class frmDarkening : Form
    {
        private readonly Form _srcFrm;

        public frmDarkening(Form srcFrm)
        {
            _srcFrm = srcFrm;
            InitializeComponent();
            InitPositionAndSize();
        }

        private void InitPositionAndSize()
        {
            int yOffsetToolbar = 0;
            int xOffset = 0;

            if (_srcFrm.FormBorderStyle != FormBorderStyle.None)
            {
                yOffsetToolbar = 31;
                xOffset = 8;
            }

            Size = _srcFrm.ClientRectangle.Size;
            Location = new Point(_srcFrm.Location.X + xOffset, _srcFrm.Location.Y + yOffsetToolbar);
        }
    }
}

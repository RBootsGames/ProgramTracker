using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace ProgramTracker
{
    public partial class Ctrl_ButtonWithX : UserControl
    {
        [Category("Appearance")]
        public string ButtonText
        {
            get => btn_Main.Text;
            set => btn_Main.Text = value;
        }

        [Category("Action")]
        public event EventHandler ClickButton;

        [Category("Action")]
        public event EventHandler ClickX;

        public Ctrl_ButtonWithX()
        {
            InitializeComponent();
        }

        private void btn_Main_Click(object sender, EventArgs e)
        {
            if (ClickButton != null)
                ClickButton(this, e);
        }

        private void btn_X_Click(object sender, EventArgs e)
        {
            if (ClickX != null)
                ClickX(this, e);
        }

        private void Ctrl_ButtonWithX_AutoSizeChanged(object sender, EventArgs e)
        {
            btn_Main.AutoSize = AutoSize;
        }

        private void Ctrl_ButtonWithX_Resize(object sender, EventArgs e)
        {
            btn_Main.Width = this.Width - btn_X.Width;
        }
    }
}

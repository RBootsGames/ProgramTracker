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
    public partial class Ctrl_IconRadio : UserControl
    {
        bool l_Selected = false;


        [Category("User Settings")]
        public bool Selected
        {
            get => l_Selected;
            set
            {
                l_Selected = value;
                if (value == true)
                {
                    foreach (Ctrl_IconRadio item in this.Parent.Controls.OfType<Ctrl_IconRadio>().Where(x => x != this))
                    {
                        item.Selected = false;
                    }

                    BackColor = Color.DodgerBlue;
                    //BorderStyle = BorderStyle.Fixed3D;
                }
                else
                {
                    BackColor = Color.Empty;
                    //BorderStyle = BorderStyle.None;
                }
            }
        }

        [Category("User Settings")]
        public Image Icon
        {
            get => pictureBox1.Image;
            set => pictureBox1.Image = value;
        }

        [Category("Action")]
        public event EventHandler ClickIcon;

        [Category("Action")]
        public event EventHandler DoubleClickIcon;

        public Ctrl_IconRadio()
        {
            InitializeComponent();
        }

        private void pictureBox1_Click(object sender, EventArgs e)
        {
            Selected = true;
            ClickIcon?.Invoke(this, e);
        }

        private void pictureBox1_DoubleClick(object sender, EventArgs e)
        {
            Selected = true;
            DoubleClickIcon?.Invoke(this, e);
        }
    }
}

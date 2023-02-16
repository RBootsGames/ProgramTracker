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
    public partial class Frm_PopupTextbox : Form
    {
        bool l_TextChanged = false;
        string l_StartingText = "";

        public string ReturnText = "";
        public bool TextWasChanged => l_TextChanged;


        public Frm_PopupTextbox(string labelText, string windowTitle, string startingText="", string acceptButtonText="Save")
        {
            InitializeComponent();
            this.Text = windowTitle;
            btn_Accept.Text = acceptButtonText;

            l_StartingText = startingText;

            lbl_Caption.Text = labelText;
            tbx_DisplayName.Text = startingText;
            tbx_DisplayName.SelectAll();
        }

        private void Frm_RenameProc_Load(object sender, EventArgs e)
        {
            Frm_Main main = Frm_Main.MainForm;
            int left = (main.Location.X + main.Width / 2) - Width / 2;
            int top = (main.Location.Y + main.Height / 2) - Height / 2;
            Location = new Point(left, top);

        }

        private void btn_Accept_Click(object sender, EventArgs e)
        {
            ReturnText = tbx_DisplayName.Text.Trim();
            l_TextChanged = (l_StartingText != tbx_DisplayName.Text);
            DialogResult = DialogResult.OK;
            Close();
        }

        private void btn_Cancel_Click(object sender, EventArgs e)
        {
            Close();
        }
    }
}

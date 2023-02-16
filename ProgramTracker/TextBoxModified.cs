using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Runtime.InteropServices;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace ProgramTracker
{
    public partial class TextBoxModified : TextBox
    {
        string l_TextPlaceholder;
        Color l_TextPlaceholderColor = Color.Gray;
        Color l_DefaultForeColor;
        bool userEnteredText = false;
        bool isChangingPlaceholder = false;

        [Category("Appearance")]
        public string TextPlaceholder
        {
            get => l_TextPlaceholder;
            set
            {
                l_TextPlaceholder = value;
                Text = TextPlaceholder;

                if (string.IsNullOrEmpty(TextPlaceholder))
                    ForeColor = l_DefaultForeColor;
                else
                    ForeColor = TextPlaceholderColor;
            }
        }

        [Category("Appearance")]
        public Color TextPlaceholderColor
        {
            get => l_TextPlaceholderColor;
            set => l_TextPlaceholderColor = value;
        }


        //[Category("Property Changed"), Description("DON'T USE THIS ONE! IT CAUSES ISSUES!")]
        //public new event EventHandler TextChanged;

        [Category("Property Changed"), Description("This needs to be used for text changed events. The original causes issues.")]
        public event EventHandler TextChangedFixed;


        public string RealText
        {
            get
            {
                if (!string.IsNullOrEmpty(TextPlaceholder) && Text == TextPlaceholder)
                    return "";
                else
                    return Text;
            }
            set => Text = value;
        }

        public TextBoxModified()
        {
            InitializeComponent();

            this.TextChanged += eventOnTextChanged;
            Enter += eventEnter;
            Leave += eventLeave;
            l_DefaultForeColor = this.ForeColor;
            if (!string.IsNullOrEmpty(l_TextPlaceholder))
                ForeColor = TextPlaceholderColor;
        }

        protected override void OnPaint(PaintEventArgs e)
        {
            base.OnPaint(e);
        }

        protected void eventOnTextChanged(object sender, EventArgs e)
        {

            if (TextChangedFixed != null && isChangingPlaceholder == false)
                TextChangedFixed(this, new EventArgs());
        }

        /// <summary>
        /// Use this instead of Clear().
        /// </summary>
        internal void ClearText()
        {
            Text = "";
            eventLeave(this, EventArgs.Empty);
        }

        protected void eventEnter(object sender, EventArgs e)
        {
            if (string.IsNullOrEmpty(TextPlaceholder))
                return;
            
            if (!userEnteredText)
            {
                isChangingPlaceholder = true;

                SelectionStart = 0;
                SelectionLength = 0;
                ForeColor = l_DefaultForeColor;
                Text = "";

                isChangingPlaceholder = false;
            }
        }

        protected void eventLeave(object sender, EventArgs e)
        {
            if (string.IsNullOrEmpty(TextPlaceholder))
                return;


            if (string.IsNullOrEmpty(Text))
            {
                isChangingPlaceholder = true;
                userEnteredText = false;
                ForeColor = TextPlaceholderColor;
                Text = TextPlaceholder;
                isChangingPlaceholder = false;
            }
            else
                userEnteredText = true;
        }
    }
}

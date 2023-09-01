using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Drawing.Imaging;
using System.IO;
using System.Linq;
using System.Security.Cryptography;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace ProgramTracker
{
    public partial class Frm_SetIcon : Form
    {
        public Image SelectedIcon;
        public bool IconChanged = false;

        string SelectedProcessName;

        public Frm_SetIcon(string processName)
        {
            InitializeComponent();

            SelectedProcessName = processName;

            string iconPath = Path.Combine(Settings.GetIconsDirectory());

            //var icons = Directory.GetFiles(iconPath, "*.png").Select(x => Image.FromFile(x));

            List<Image> icons = new List<Image>();
            var paths = Directory.GetFiles(iconPath, "*.png").ToList();
            List<string> hashes = new List<string>();

            // filter out duplicate images
            using (SHA1 sha = SHA1.Create())
            {
                foreach (var file in paths)
                {
                    using (FileStream stream = File.OpenRead(file))
                    {
                        try
                        {
                            stream.Position = 0;
                            byte[] value = sha.ComputeHash(stream);
                            string hash = Encoding.Default.GetString(value);

                            if (!hashes.Contains(hash))
                            {
                                hashes.Add(hash);
                                icons.Add(Image.FromStream(stream));
                            }
                        }
                        catch { }
                    }
                }
            }


            foreach (var icon in icons)
            {
                Ctrl_IconRadio iRad = new Ctrl_IconRadio();
                iRad.Icon = icon;
                iRad.Size = new Size(48, 48);

                iRad.DoubleClickIcon += btn_Accept_Click;

                pnl_IconLibrary.Controls.Add(iRad);
            }
        }

        Image GetSelectedIcon()
        {
            Ctrl_IconRadio selection = null;
            foreach (var icon in pnl_IconLibrary.Controls.OfType<Ctrl_IconRadio>())
            {
                if (icon.Selected)
                {
                    selection = icon;
                    break;
                }
            }

            return (selection != null) ? selection.Icon : null;
        }

        private void btn_Cancel_Click(object sender, EventArgs e)
        {
            SelectedIcon = null;
            Close();
        }

        private void btn_Accept_Click(object sender, EventArgs e)
        {
            SelectedIcon = GetSelectedIcon();
            if (SelectedIcon != null)
            {
                CustomExtensions.SaveIconFromImage(SelectedProcessName, SelectedIcon);
                IconChanged = true;
                Close();
            }
            else
            {
                MessageBox.Show("An icon needs to be selected.", "Invalid selection",
                                MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
        }

        private void btn_Custom_Click(object sender, EventArgs e)
        {
            if (diag_LoadIcon.ShowDialog() == DialogResult.OK)
            {
                if (Path.GetExtension(diag_LoadIcon.FileName) == ".exe")
                {
                    CustomExtensions.SaveIconFromExe(SelectedProcessName, diag_LoadIcon.FileName, true, true);
                }
                else
                {
                    try
                    {
                        Image image = Image.FromFile(diag_LoadIcon.FileName);
                        CustomExtensions.SaveIconFromImage(SelectedProcessName, image);
                    }
                    catch (Exception ex)
                    {
                        Console.WriteLine(ex.Message);
                    }
                }

                IconChanged = true;
                Close();
            }
        }
    }
}

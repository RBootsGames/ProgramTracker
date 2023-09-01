namespace ProgramTracker
{
    partial class Frm_SetIcon
    {
        /// <summary>
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code

        /// <summary>
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            this.pnl_IconLibrary = new System.Windows.Forms.FlowLayoutPanel();
            this.pnl_Bottom = new System.Windows.Forms.Panel();
            this.btn_Custom = new System.Windows.Forms.Button();
            this.btn_Cancel = new System.Windows.Forms.Button();
            this.btn_Accept = new System.Windows.Forms.Button();
            this.label1 = new System.Windows.Forms.Label();
            this.diag_LoadIcon = new System.Windows.Forms.OpenFileDialog();
            this.pnl_Bottom.SuspendLayout();
            this.SuspendLayout();
            // 
            // pnl_IconLibrary
            // 
            this.pnl_IconLibrary.AllowDrop = true;
            this.pnl_IconLibrary.AutoScroll = true;
            this.pnl_IconLibrary.BackColor = System.Drawing.Color.White;
            this.pnl_IconLibrary.Dock = System.Windows.Forms.DockStyle.Fill;
            this.pnl_IconLibrary.Location = new System.Drawing.Point(0, 13);
            this.pnl_IconLibrary.Name = "pnl_IconLibrary";
            this.pnl_IconLibrary.Size = new System.Drawing.Size(354, 265);
            this.pnl_IconLibrary.TabIndex = 0;
            // 
            // pnl_Bottom
            // 
            this.pnl_Bottom.Controls.Add(this.btn_Custom);
            this.pnl_Bottom.Controls.Add(this.btn_Cancel);
            this.pnl_Bottom.Controls.Add(this.btn_Accept);
            this.pnl_Bottom.Dock = System.Windows.Forms.DockStyle.Bottom;
            this.pnl_Bottom.Location = new System.Drawing.Point(0, 278);
            this.pnl_Bottom.Name = "pnl_Bottom";
            this.pnl_Bottom.Size = new System.Drawing.Size(354, 36);
            this.pnl_Bottom.TabIndex = 0;
            // 
            // btn_Custom
            // 
            this.btn_Custom.Location = new System.Drawing.Point(12, 6);
            this.btn_Custom.Name = "btn_Custom";
            this.btn_Custom.Size = new System.Drawing.Size(79, 23);
            this.btn_Custom.TabIndex = 2;
            this.btn_Custom.Text = "Custom Icon";
            this.btn_Custom.UseVisualStyleBackColor = true;
            this.btn_Custom.Click += new System.EventHandler(this.btn_Custom_Click);
            // 
            // btn_Cancel
            // 
            this.btn_Cancel.DialogResult = System.Windows.Forms.DialogResult.Cancel;
            this.btn_Cancel.FlatStyle = System.Windows.Forms.FlatStyle.Popup;
            this.btn_Cancel.Location = new System.Drawing.Point(186, 6);
            this.btn_Cancel.Name = "btn_Cancel";
            this.btn_Cancel.Size = new System.Drawing.Size(75, 23);
            this.btn_Cancel.TabIndex = 1;
            this.btn_Cancel.Text = "Cancel";
            this.btn_Cancel.UseVisualStyleBackColor = true;
            this.btn_Cancel.Click += new System.EventHandler(this.btn_Cancel_Click);
            // 
            // btn_Accept
            // 
            this.btn_Accept.Location = new System.Drawing.Point(267, 6);
            this.btn_Accept.Name = "btn_Accept";
            this.btn_Accept.Size = new System.Drawing.Size(75, 23);
            this.btn_Accept.TabIndex = 0;
            this.btn_Accept.Text = "Select";
            this.btn_Accept.UseVisualStyleBackColor = true;
            this.btn_Accept.Click += new System.EventHandler(this.btn_Accept_Click);
            // 
            // label1
            // 
            this.label1.Dock = System.Windows.Forms.DockStyle.Top;
            this.label1.Location = new System.Drawing.Point(0, 0);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(354, 13);
            this.label1.TabIndex = 0;
            this.label1.Text = "Existing Icons";
            // 
            // diag_LoadIcon
            // 
            this.diag_LoadIcon.FileName = "Select Icon";
            this.diag_LoadIcon.Filter = "executable files|*.exe| images|*.png;*.jpg;*.jpeg|all files|*.*";
            // 
            // Frm_SetIcon
            // 
            this.AcceptButton = this.btn_Accept;
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.CancelButton = this.btn_Cancel;
            this.ClientSize = new System.Drawing.Size(354, 314);
            this.Controls.Add(this.pnl_IconLibrary);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.pnl_Bottom);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.SizableToolWindow;
            this.Name = "Frm_SetIcon";
            this.Text = "Set Icon";
            this.pnl_Bottom.ResumeLayout(false);
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.FlowLayoutPanel pnl_IconLibrary;
        private System.Windows.Forms.Panel pnl_Bottom;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Button btn_Cancel;
        private System.Windows.Forms.Button btn_Accept;
        private System.Windows.Forms.Button btn_Custom;
        private System.Windows.Forms.OpenFileDialog diag_LoadIcon;
    }
}
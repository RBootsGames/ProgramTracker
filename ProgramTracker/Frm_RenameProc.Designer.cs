namespace ProgramTracker
{
    partial class Frm_PopupTextbox
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
            this.lbl_Caption = new System.Windows.Forms.Label();
            this.tbx_DisplayName = new System.Windows.Forms.TextBox();
            this.btn_Accept = new System.Windows.Forms.Button();
            this.btn_Cancel = new System.Windows.Forms.Button();
            this.SuspendLayout();
            // 
            // lbl_Caption
            // 
            this.lbl_Caption.AutoSize = true;
            this.lbl_Caption.Location = new System.Drawing.Point(12, 9);
            this.lbl_Caption.Name = "lbl_Caption";
            this.lbl_Caption.Size = new System.Drawing.Size(62, 13);
            this.lbl_Caption.TabIndex = 0;
            this.lbl_Caption.Text = "caption text";
            // 
            // tbx_DisplayName
            // 
            this.tbx_DisplayName.Location = new System.Drawing.Point(12, 28);
            this.tbx_DisplayName.Margin = new System.Windows.Forms.Padding(3, 6, 3, 3);
            this.tbx_DisplayName.Name = "tbx_DisplayName";
            this.tbx_DisplayName.Size = new System.Drawing.Size(281, 20);
            this.tbx_DisplayName.TabIndex = 1;
            // 
            // btn_Accept
            // 
            this.btn_Accept.Location = new System.Drawing.Point(137, 54);
            this.btn_Accept.Name = "btn_Accept";
            this.btn_Accept.Size = new System.Drawing.Size(75, 23);
            this.btn_Accept.TabIndex = 2;
            this.btn_Accept.Text = "Save";
            this.btn_Accept.UseVisualStyleBackColor = true;
            this.btn_Accept.Click += new System.EventHandler(this.btn_Accept_Click);
            // 
            // btn_Cancel
            // 
            this.btn_Cancel.DialogResult = System.Windows.Forms.DialogResult.Cancel;
            this.btn_Cancel.FlatStyle = System.Windows.Forms.FlatStyle.Popup;
            this.btn_Cancel.Location = new System.Drawing.Point(218, 54);
            this.btn_Cancel.Name = "btn_Cancel";
            this.btn_Cancel.Size = new System.Drawing.Size(75, 23);
            this.btn_Cancel.TabIndex = 3;
            this.btn_Cancel.Text = "Cancel";
            this.btn_Cancel.UseVisualStyleBackColor = true;
            this.btn_Cancel.Click += new System.EventHandler(this.btn_Cancel_Click);
            // 
            // Frm_RenameProc
            // 
            this.AcceptButton = this.btn_Accept;
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.CancelButton = this.btn_Cancel;
            this.ClientSize = new System.Drawing.Size(305, 87);
            this.Controls.Add(this.btn_Cancel);
            this.Controls.Add(this.btn_Accept);
            this.Controls.Add(this.tbx_DisplayName);
            this.Controls.Add(this.lbl_Caption);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedToolWindow;
            this.Name = "Frm_RenameProc";
            this.Text = "Window Title";
            this.Load += new System.EventHandler(this.Frm_RenameProc_Load);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label lbl_Caption;
        private System.Windows.Forms.TextBox tbx_DisplayName;
        private System.Windows.Forms.Button btn_Accept;
        private System.Windows.Forms.Button btn_Cancel;
    }
}
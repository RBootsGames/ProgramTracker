namespace ProgramTracker
{
    partial class Ctrl_UnmergeTemplate
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

        #region Component Designer generated code

        /// <summary> 
        /// Required method for Designer support - do not modify 
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            this.processList = new System.Windows.Forms.CheckedListBox();
            this.lbl_Title = new System.Windows.Forms.Label();
            this.SuspendLayout();
            // 
            // processList
            // 
            this.processList.CheckOnClick = true;
            this.processList.Dock = System.Windows.Forms.DockStyle.Fill;
            this.processList.FormattingEnabled = true;
            this.processList.Location = new System.Drawing.Point(0, 21);
            this.processList.Name = "processList";
            this.processList.Size = new System.Drawing.Size(179, 127);
            this.processList.TabIndex = 0;
            // 
            // lbl_Title
            // 
            this.lbl_Title.Dock = System.Windows.Forms.DockStyle.Top;
            this.lbl_Title.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lbl_Title.Location = new System.Drawing.Point(0, 0);
            this.lbl_Title.Name = "lbl_Title";
            this.lbl_Title.Size = new System.Drawing.Size(179, 21);
            this.lbl_Title.TabIndex = 1;
            this.lbl_Title.Text = "Master: ";
            this.lbl_Title.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // Ctrl_UnmergeTemplate
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.White;
            this.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.Controls.Add(this.processList);
            this.Controls.Add(this.lbl_Title);
            this.Name = "Ctrl_UnmergeTemplate";
            this.Size = new System.Drawing.Size(179, 148);
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.CheckedListBox processList;
        private System.Windows.Forms.Label lbl_Title;
    }
}

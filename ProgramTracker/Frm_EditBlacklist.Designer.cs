namespace ProgramTracker
{
    partial class Frm_EditBlacklist
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
            this.pnl_Left = new System.Windows.Forms.Panel();
            this.btn_Save = new System.Windows.Forms.Button();
            this.btn_Cancel = new System.Windows.Forms.Button();
            this.btn_Delete = new System.Windows.Forms.Button();
            this.btn_Deselect = new System.Windows.Forms.Button();
            this.btn_Select = new System.Windows.Forms.Button();
            this.listBox = new System.Windows.Forms.CheckedListBox();
            this.pnl_Left.SuspendLayout();
            this.SuspendLayout();
            // 
            // pnl_Left
            // 
            this.pnl_Left.Controls.Add(this.btn_Save);
            this.pnl_Left.Controls.Add(this.btn_Cancel);
            this.pnl_Left.Controls.Add(this.btn_Delete);
            this.pnl_Left.Controls.Add(this.btn_Deselect);
            this.pnl_Left.Controls.Add(this.btn_Select);
            this.pnl_Left.Dock = System.Windows.Forms.DockStyle.Left;
            this.pnl_Left.Location = new System.Drawing.Point(0, 0);
            this.pnl_Left.Name = "pnl_Left";
            this.pnl_Left.Size = new System.Drawing.Size(162, 450);
            this.pnl_Left.TabIndex = 0;
            // 
            // btn_Save
            // 
            this.btn_Save.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.064F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btn_Save.Location = new System.Drawing.Point(12, 170);
            this.btn_Save.Name = "btn_Save";
            this.btn_Save.Size = new System.Drawing.Size(144, 29);
            this.btn_Save.TabIndex = 4;
            this.btn_Save.Text = "Save";
            this.btn_Save.UseVisualStyleBackColor = true;
            this.btn_Save.Click += new System.EventHandler(this.btn_Save_Click);
            // 
            // btn_Cancel
            // 
            this.btn_Cancel.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.064F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btn_Cancel.Location = new System.Drawing.Point(12, 135);
            this.btn_Cancel.Name = "btn_Cancel";
            this.btn_Cancel.Size = new System.Drawing.Size(144, 29);
            this.btn_Cancel.TabIndex = 3;
            this.btn_Cancel.Text = "Cancel";
            this.btn_Cancel.UseVisualStyleBackColor = true;
            this.btn_Cancel.Click += new System.EventHandler(this.btn_Cancel_Click);
            // 
            // btn_Delete
            // 
            this.btn_Delete.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.064F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btn_Delete.Location = new System.Drawing.Point(12, 100);
            this.btn_Delete.Name = "btn_Delete";
            this.btn_Delete.Size = new System.Drawing.Size(144, 29);
            this.btn_Delete.TabIndex = 2;
            this.btn_Delete.Text = "Delete Selection";
            this.btn_Delete.UseVisualStyleBackColor = true;
            this.btn_Delete.Click += new System.EventHandler(this.btn_Delete_Click);
            // 
            // btn_Deselect
            // 
            this.btn_Deselect.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.064F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btn_Deselect.Location = new System.Drawing.Point(12, 47);
            this.btn_Deselect.Name = "btn_Deselect";
            this.btn_Deselect.Size = new System.Drawing.Size(144, 29);
            this.btn_Deselect.TabIndex = 1;
            this.btn_Deselect.Text = "Deselect All";
            this.btn_Deselect.UseVisualStyleBackColor = true;
            this.btn_Deselect.Click += new System.EventHandler(this.btn_Deselect_Click);
            // 
            // btn_Select
            // 
            this.btn_Select.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.064F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btn_Select.Location = new System.Drawing.Point(12, 12);
            this.btn_Select.Name = "btn_Select";
            this.btn_Select.Size = new System.Drawing.Size(144, 29);
            this.btn_Select.TabIndex = 0;
            this.btn_Select.Text = "Select All";
            this.btn_Select.UseVisualStyleBackColor = true;
            this.btn_Select.Click += new System.EventHandler(this.btn_Select_Click);
            // 
            // listBox
            // 
            this.listBox.CheckOnClick = true;
            this.listBox.Dock = System.Windows.Forms.DockStyle.Fill;
            this.listBox.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.792F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.listBox.FormattingEnabled = true;
            this.listBox.Location = new System.Drawing.Point(162, 0);
            this.listBox.Name = "listBox";
            this.listBox.Size = new System.Drawing.Size(638, 450);
            this.listBox.TabIndex = 100;
            // 
            // Frm_EditBlacklist
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(800, 450);
            this.Controls.Add(this.listBox);
            this.Controls.Add(this.pnl_Left);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.SizableToolWindow;
            this.Name = "Frm_EditBlacklist";
            this.Text = "Edit Ignore List";
            this.pnl_Left.ResumeLayout(false);
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Panel pnl_Left;
        private System.Windows.Forms.Button btn_Save;
        private System.Windows.Forms.Button btn_Cancel;
        private System.Windows.Forms.Button btn_Delete;
        private System.Windows.Forms.Button btn_Deselect;
        private System.Windows.Forms.Button btn_Select;
        private System.Windows.Forms.CheckedListBox listBox;
    }
}
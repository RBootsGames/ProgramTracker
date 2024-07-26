namespace ProgramTracker
{
    partial class Frm_AddProcess
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
            this.listBox = new System.Windows.Forms.CheckedListBox();
            this.pnl_Top = new System.Windows.Forms.Panel();
            this.btn_Cancel = new System.Windows.Forms.Button();
            this.label1 = new System.Windows.Forms.Label();
            this.textBox1 = new System.Windows.Forms.TextBox();
            this.btn_AddSelection = new System.Windows.Forms.Button();
            this.btn_Deselect = new System.Windows.Forms.Button();
            this.pnl_Top.SuspendLayout();
            this.SuspendLayout();
            // 
            // listBox
            // 
            this.listBox.CheckOnClick = true;
            this.listBox.Dock = System.Windows.Forms.DockStyle.Fill;
            this.listBox.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.792F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.listBox.FormattingEnabled = true;
            this.listBox.Location = new System.Drawing.Point(0, 55);
            this.listBox.Name = "listBox";
            this.listBox.Size = new System.Drawing.Size(800, 395);
            this.listBox.TabIndex = 101;
            this.listBox.TabStop = false;
            this.listBox.SelectedValueChanged += new System.EventHandler(this.listBox_SelectedValueChanged);
            // 
            // pnl_Top
            // 
            this.pnl_Top.Controls.Add(this.btn_Cancel);
            this.pnl_Top.Controls.Add(this.label1);
            this.pnl_Top.Controls.Add(this.textBox1);
            this.pnl_Top.Controls.Add(this.btn_AddSelection);
            this.pnl_Top.Controls.Add(this.btn_Deselect);
            this.pnl_Top.Dock = System.Windows.Forms.DockStyle.Top;
            this.pnl_Top.Location = new System.Drawing.Point(0, 0);
            this.pnl_Top.Name = "pnl_Top";
            this.pnl_Top.Size = new System.Drawing.Size(800, 55);
            this.pnl_Top.TabIndex = 102;
            // 
            // btn_Cancel
            // 
            this.btn_Cancel.DialogResult = System.Windows.Forms.DialogResult.Cancel;
            this.btn_Cancel.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btn_Cancel.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.064F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btn_Cancel.Location = new System.Drawing.Point(278, 12);
            this.btn_Cancel.Name = "btn_Cancel";
            this.btn_Cancel.Size = new System.Drawing.Size(88, 29);
            this.btn_Cancel.TabIndex = 9;
            this.btn_Cancel.Text = "Cancel";
            this.btn_Cancel.UseVisualStyleBackColor = true;
            this.btn_Cancel.Click += new System.EventHandler(this.btn_Cancel_Click);
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(395, 19);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(50, 16);
            this.label1.TabIndex = 8;
            this.label1.Text = "Search";
            // 
            // textBox1
            // 
            this.textBox1.Location = new System.Drawing.Point(451, 16);
            this.textBox1.Name = "textBox1";
            this.textBox1.Size = new System.Drawing.Size(258, 22);
            this.textBox1.TabIndex = 7;
            this.textBox1.TextChanged += new System.EventHandler(this.textBox1_TextChanged);
            // 
            // btn_AddSelection
            // 
            this.btn_AddSelection.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.064F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btn_AddSelection.Location = new System.Drawing.Point(145, 12);
            this.btn_AddSelection.Name = "btn_AddSelection";
            this.btn_AddSelection.Size = new System.Drawing.Size(127, 29);
            this.btn_AddSelection.TabIndex = 6;
            this.btn_AddSelection.Text = "Add Selections";
            this.btn_AddSelection.UseVisualStyleBackColor = true;
            this.btn_AddSelection.Click += new System.EventHandler(this.btn_AddSelection_Click);
            // 
            // btn_Deselect
            // 
            this.btn_Deselect.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.064F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btn_Deselect.Location = new System.Drawing.Point(12, 12);
            this.btn_Deselect.Name = "btn_Deselect";
            this.btn_Deselect.Size = new System.Drawing.Size(127, 29);
            this.btn_Deselect.TabIndex = 5;
            this.btn_Deselect.Text = "Deselect All";
            this.btn_Deselect.UseVisualStyleBackColor = true;
            this.btn_Deselect.Click += new System.EventHandler(this.btn_Deselect_Click);
            // 
            // Frm_AddProcess
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.CancelButton = this.btn_Cancel;
            this.ClientSize = new System.Drawing.Size(800, 450);
            this.Controls.Add(this.listBox);
            this.Controls.Add(this.pnl_Top);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedToolWindow;
            this.Name = "Frm_AddProcess";
            this.Text = "Add Process";
            this.pnl_Top.ResumeLayout(false);
            this.pnl_Top.PerformLayout();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.CheckedListBox listBox;
        private System.Windows.Forms.Panel pnl_Top;
        private System.Windows.Forms.Button btn_AddSelection;
        private System.Windows.Forms.Button btn_Deselect;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.TextBox textBox1;
        private System.Windows.Forms.Button btn_Cancel;
    }
}
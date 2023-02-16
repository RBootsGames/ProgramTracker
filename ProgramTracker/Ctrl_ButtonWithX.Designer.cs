namespace ProgramTracker
{
    partial class Ctrl_ButtonWithX
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
            this.btn_Main = new System.Windows.Forms.Button();
            this.btn_X = new System.Windows.Forms.Button();
            this.SuspendLayout();
            // 
            // btn_Main
            // 
            this.btn_Main.Dock = System.Windows.Forms.DockStyle.Left;
            this.btn_Main.Location = new System.Drawing.Point(0, 0);
            this.btn_Main.Margin = new System.Windows.Forms.Padding(0);
            this.btn_Main.Name = "btn_Main";
            this.btn_Main.Size = new System.Drawing.Size(113, 31);
            this.btn_Main.TabIndex = 0;
            this.btn_Main.Text = "button";
            this.btn_Main.UseVisualStyleBackColor = true;
            this.btn_Main.Click += new System.EventHandler(this.btn_Main_Click);
            // 
            // btn_X
            // 
            this.btn_X.Dock = System.Windows.Forms.DockStyle.Right;
            this.btn_X.FlatAppearance.BorderSize = 0;
            this.btn_X.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btn_X.Location = new System.Drawing.Point(113, 0);
            this.btn_X.Margin = new System.Windows.Forms.Padding(0);
            this.btn_X.Name = "btn_X";
            this.btn_X.Size = new System.Drawing.Size(20, 31);
            this.btn_X.TabIndex = 1;
            this.btn_X.Text = "X";
            this.btn_X.UseVisualStyleBackColor = true;
            this.btn_X.Click += new System.EventHandler(this.btn_X_Click);
            // 
            // Ctrl_ButtonWithX
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.Controls.Add(this.btn_Main);
            this.Controls.Add(this.btn_X);
            this.Margin = new System.Windows.Forms.Padding(4, 4, 4, 4);
            this.Name = "Ctrl_ButtonWithX";
            this.Size = new System.Drawing.Size(133, 31);
            this.AutoSizeChanged += new System.EventHandler(this.Ctrl_ButtonWithX_AutoSizeChanged);
            this.Resize += new System.EventHandler(this.Ctrl_ButtonWithX_Resize);
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Button btn_Main;
        private System.Windows.Forms.Button btn_X;
    }
}


namespace Proj1
{
    partial class Panel_data
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(Panel_data));
            this.Label_X = new Bunifu.UI.WinForms.BunifuLabel();
            this.Label_welcome = new Bunifu.UI.WinForms.BunifuLabel();
            this.Label_user = new Bunifu.UI.WinForms.BunifuLabel();
            this.SuspendLayout();
            // 
            // Label_X
            // 
            this.Label_X.AllowParentOverrides = false;
            this.Label_X.AutoEllipsis = false;
            this.Label_X.Cursor = System.Windows.Forms.Cursors.Hand;
            this.Label_X.CursorType = System.Windows.Forms.Cursors.Hand;
            this.Label_X.Font = new System.Drawing.Font("Microsoft Sans Serif", 14.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.Label_X.ForeColor = System.Drawing.Color.White;
            this.Label_X.Location = new System.Drawing.Point(1034, 12);
            this.Label_X.Name = "Label_X";
            this.Label_X.RightToLeft = System.Windows.Forms.RightToLeft.No;
            this.Label_X.Size = new System.Drawing.Size(15, 24);
            this.Label_X.TabIndex = 5;
            this.Label_X.Text = "X";
            this.Label_X.TextAlignment = System.Drawing.ContentAlignment.TopCenter;
            this.Label_X.TextFormat = Bunifu.UI.WinForms.BunifuLabel.TextFormattingOptions.Default;
            this.Label_X.Click += new System.EventHandler(this.Label_X_Click);
            this.Label_X.MouseEnter += new System.EventHandler(this.Label_X_MouseEnter);
            // 
            // Label_welcome
            // 
            this.Label_welcome.AllowParentOverrides = false;
            this.Label_welcome.AutoEllipsis = false;
            this.Label_welcome.CursorType = System.Windows.Forms.Cursors.Default;
            this.Label_welcome.Font = new System.Drawing.Font("JetBrains Mono", 18F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.Label_welcome.ForeColor = System.Drawing.Color.White;
            this.Label_welcome.Location = new System.Drawing.Point(28, 70);
            this.Label_welcome.Name = "Label_welcome";
            this.Label_welcome.RightToLeft = System.Windows.Forms.RightToLeft.No;
            this.Label_welcome.Size = new System.Drawing.Size(112, 31);
            this.Label_welcome.TabIndex = 6;
            this.Label_welcome.Text = "Welcome,";
            this.Label_welcome.TextAlignment = System.Drawing.ContentAlignment.TopLeft;
            this.Label_welcome.TextFormat = Bunifu.UI.WinForms.BunifuLabel.TextFormattingOptions.Default;
            // 
            // Label_user
            // 
            this.Label_user.AllowParentOverrides = false;
            this.Label_user.AutoEllipsis = false;
            this.Label_user.CursorType = null;
            this.Label_user.Font = new System.Drawing.Font("JetBrains Mono", 18F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.Label_user.ForeColor = System.Drawing.Color.White;
            this.Label_user.Location = new System.Drawing.Point(143, 71);
            this.Label_user.Name = "Label_user";
            this.Label_user.RightToLeft = System.Windows.Forms.RightToLeft.No;
            this.Label_user.Size = new System.Drawing.Size(56, 31);
            this.Label_user.TabIndex = 7;
            this.Label_user.Text = "Name";
            this.Label_user.TextAlignment = System.Drawing.ContentAlignment.TopLeft;
            this.Label_user.TextFormat = Bunifu.UI.WinForms.BunifuLabel.TextFormattingOptions.Default;
            // 
            // Panel_data
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(29)))), ((int)(((byte)(29)))), ((int)(((byte)(29)))));
            this.ClientSize = new System.Drawing.Size(1072, 610);
            this.Controls.Add(this.Label_user);
            this.Controls.Add(this.Label_welcome);
            this.Controls.Add(this.Label_X);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.None;
            this.Name = "Panel_data";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "MainForm";
            this.Load += new System.EventHandler(this.MainForm_Load);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private Bunifu.UI.WinForms.BunifuLabel Label_X;
        private Bunifu.UI.WinForms.BunifuLabel Label_welcome;
        private Bunifu.UI.WinForms.BunifuLabel Label_user;
    }
}
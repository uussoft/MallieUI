﻿namespace Mallie.UI
{
    partial class UIHeaderMainFrame
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
            this.Header = new Mallie.UI.UINavBar();
            this.SuspendLayout();
            // 
            // Main
            // 
            this.Main.ItemSize = new System.Drawing.Size(0, 1);
            this.Main.Location = new System.Drawing.Point(1, 145);
            this.Main.Size = new System.Drawing.Size(798, 304);
            this.Main.TabVisible = false;
            // 
            // Header
            // 
            this.Header.Dock = System.Windows.Forms.DockStyle.Top;
            this.Header.Font = new System.Drawing.Font("微软雅黑", 12F);
            this.Header.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(48)))), ((int)(((byte)(48)))), ((int)(((byte)(48)))));
            this.Header.Location = new System.Drawing.Point(1, 35);
            this.Header.MenuHoverColor = System.Drawing.Color.FromArgb(((int)(((byte)(230)))), ((int)(((byte)(230)))), ((int)(((byte)(230)))));
            this.Header.MenuStyle = Mallie.UI.UIMenuStyle.White;
            this.Header.Name = "Header";
            this.Header.Size = new System.Drawing.Size(798, 110);
            this.Header.TabIndex = 1;
            this.Header.Text = "uiNavBar1";
            // 
            // UIHeaderMainFrame
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(10F, 21F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(800, 450);
            this.Controls.Add(this.Header);
            this.Name = "UIHeaderMainFrame";
            this.Text = "UIHeaderMainFrame";
            this.Controls.SetChildIndex(this.Header, 0);
            this.Controls.SetChildIndex(this.Main, 0);
            this.ResumeLayout(false);

        }

        #endregion

        protected UINavBar Header;
    }
}
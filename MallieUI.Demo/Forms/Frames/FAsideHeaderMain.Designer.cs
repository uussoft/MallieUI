﻿namespace Mallie.UI.Demo
{
    partial class FAsideHeaderMain
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
            this.SuspendLayout();
            // 
            // Header
            // 
            this.Header.FillColor = System.Drawing.Color.FromArgb(((int)(((byte)(76)))), ((int)(((byte)(76)))), ((int)(((byte)(76)))));
            this.Header.ForeColor = System.Drawing.Color.White;
            this.Header.Size = new System.Drawing.Size(774, 57);
            this.Header.Style = Mallie.UI.UIStyle.Custom;
            this.Header.StyleCustomMode = true;
            // 
            // Aside
            // 
            this.Aside.Size = new System.Drawing.Size(250, 685);
            this.Aside.Style = Mallie.UI.UIStyle.Blue;
            this.Aside.MenuItemClick += new Mallie.UI.UINavMenu.OnMenuItemClick(this.Aside_MenuItemClick);
            // 
            // Main
            // 
            this.Main.Size = new System.Drawing.Size(774, 628);
            this.Main.Style = Mallie.UI.UIStyle.Blue;
            // 
            // FAsideHeaderMain
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(10F, 21F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1024, 720);
            this.Name = "FAsideHeaderMain";
            this.Style = Mallie.UI.UIStyle.Blue;
            this.Text = "FAsideHeaderMain";
            this.ResumeLayout(false);

        }

        #endregion
    }
}
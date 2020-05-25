﻿namespace Mallie.UI
{
    partial class UIAsideHeaderMainFrame
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
            this.Header = new Mallie.UI.UIPanel();
            this.SuspendLayout();
            // 
            // Aside
            // 
            this.Aside.LineColor = System.Drawing.Color.Black;
            this.Aside.TabControl = this.Main;
            // 
            // Main
            // 
            this.Main.Location = new System.Drawing.Point(250, 92);
            this.Main.Size = new System.Drawing.Size(550, 358);
            // 
            // Header
            // 
            this.Header.Dock = System.Windows.Forms.DockStyle.Top;
            this.Header.Font = new System.Drawing.Font("微软雅黑", 12F);
            this.Header.Location = new System.Drawing.Point(250, 35);
            this.Header.Margin = new System.Windows.Forms.Padding(4, 5, 4, 5);
            this.Header.Name = "Header";
            this.Header.RadiusSides = Mallie.UI.UICornerRadiusSides.None;
            this.Header.RectSides = System.Windows.Forms.ToolStripStatusLabelBorderSides.None;
            this.Header.Size = new System.Drawing.Size(550, 57);
            this.Header.TabIndex = 2;
            this.Header.Text = null;
            // 
            // UIAsideHeaderMainFrame
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(10F, 21F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(800, 450);
            this.Controls.Add(this.Header);
            this.Name = "UIAsideHeaderMainFrame";
            this.Text = "UIAsideHeaderMainFrame";
            this.Controls.SetChildIndex(this.Aside, 0);
            this.Controls.SetChildIndex(this.Header, 0);
            this.Controls.SetChildIndex(this.Main, 0);
            this.ResumeLayout(false);

        }

        #endregion

        protected UIPanel Header;
    }
}
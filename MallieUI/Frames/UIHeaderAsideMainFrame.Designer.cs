﻿namespace Mallie.UI
{
    partial class UIHeaderAsideMainFrame
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
            this.Aside = new Mallie.UI.UINavMenu();
            this.SuspendLayout();
            // 
            // Header
            // 
            this.Header.Location = new System.Drawing.Point(0, 35);
            this.Header.Size = new System.Drawing.Size(800, 110);
            // 
            // Main
            // 
            this.Main.Location = new System.Drawing.Point(250, 145);
            this.Main.Size = new System.Drawing.Size(550, 305);
            // 
            // Aside
            // 
            this.Aside.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(56)))), ((int)(((byte)(56)))), ((int)(((byte)(56)))));
            this.Aside.BorderStyle = System.Windows.Forms.BorderStyle.None;
            this.Aside.Dock = System.Windows.Forms.DockStyle.Left;
            this.Aside.DrawMode = System.Windows.Forms.TreeViewDrawMode.OwnerDrawAll;
            this.Aside.Font = new System.Drawing.Font("微软雅黑", 12F);
            this.Aside.ItemHeight = 50;
            this.Aside.Location = new System.Drawing.Point(0, 145);
            this.Aside.Name = "Aside";
            this.Aside.Size = new System.Drawing.Size(250, 305);
            this.Aside.TabControl = this.Main;
            this.Aside.TabIndex = 2;
            // 
            // UIHeaderAsideMainFrame
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(10F, 21F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(800, 450);
            this.Controls.Add(this.Aside);
            this.Name = "UIHeaderAsideMainFrame";
            this.Text = "UIHeaderAsideMainFrame";
            this.Controls.SetChildIndex(this.Header, 0);
            this.Controls.SetChildIndex(this.Aside, 0);
            this.Controls.SetChildIndex(this.Main, 0);
            this.ResumeLayout(false);

        }

        #endregion

        protected UINavMenu Aside;
    }
}
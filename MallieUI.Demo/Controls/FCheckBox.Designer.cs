﻿namespace Mallie.UI.Demo
{
    partial class FCheckBox
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
            this.uiCheckBox1 = new Mallie.UI.UICheckBox();
            this.uiLine1 = new Mallie.UI.UILine();
            this.uiCheckBox3 = new Mallie.UI.UICheckBox();
            this.uiCheckBox4 = new Mallie.UI.UICheckBox();
            this.uiCheckBox2 = new Mallie.UI.UICheckBox();
            this.uiCheckBoxGroup1 = new Mallie.UI.UICheckBoxGroup();
            this.PagePanel.SuspendLayout();
            this.SuspendLayout();
            // 
            // PagePanel
            // 
            this.PagePanel.Controls.Add(this.uiCheckBoxGroup1);
            this.PagePanel.Controls.Add(this.uiCheckBox2);
            this.PagePanel.Controls.Add(this.uiCheckBox4);
            this.PagePanel.Controls.Add(this.uiCheckBox3);
            this.PagePanel.Controls.Add(this.uiLine1);
            this.PagePanel.Controls.Add(this.uiCheckBox1);
            this.PagePanel.Size = new System.Drawing.Size(800, 521);
            // 
            // uiCheckBox1
            // 
            this.uiCheckBox1.Checked = true;
            this.uiCheckBox1.Cursor = System.Windows.Forms.Cursors.Hand;
            this.uiCheckBox1.Font = new System.Drawing.Font("微软雅黑", 12F);
            this.uiCheckBox1.Location = new System.Drawing.Point(30, 48);
            this.uiCheckBox1.Name = "uiCheckBox1";
            this.uiCheckBox1.Padding = new System.Windows.Forms.Padding(22, 0, 0, 0);
            this.uiCheckBox1.Size = new System.Drawing.Size(150, 35);
            this.uiCheckBox1.TabIndex = 0;
            this.uiCheckBox1.Text = "uiCheckBox1";
            // 
            // uiLine1
            // 
            this.uiLine1.Font = new System.Drawing.Font("微软雅黑", 12F);
            this.uiLine1.Location = new System.Drawing.Point(30, 20);
            this.uiLine1.MinimumSize = new System.Drawing.Size(16, 16);
            this.uiLine1.Name = "uiLine1";
            this.uiLine1.Size = new System.Drawing.Size(670, 20);
            this.uiLine1.TabIndex = 19;
            this.uiLine1.Text = "UICheckBox";
            this.uiLine1.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // uiCheckBox3
            // 
            this.uiCheckBox3.Checked = true;
            this.uiCheckBox3.Cursor = System.Windows.Forms.Cursors.Hand;
            this.uiCheckBox3.Enabled = false;
            this.uiCheckBox3.Font = new System.Drawing.Font("微软雅黑", 12F);
            this.uiCheckBox3.Location = new System.Drawing.Point(354, 46);
            this.uiCheckBox3.Name = "uiCheckBox3";
            this.uiCheckBox3.Padding = new System.Windows.Forms.Padding(22, 0, 0, 0);
            this.uiCheckBox3.Size = new System.Drawing.Size(150, 35);
            this.uiCheckBox3.TabIndex = 21;
            this.uiCheckBox3.Text = "uiCheckBox3";
            // 
            // uiCheckBox4
            // 
            this.uiCheckBox4.Cursor = System.Windows.Forms.Cursors.Hand;
            this.uiCheckBox4.Enabled = false;
            this.uiCheckBox4.Font = new System.Drawing.Font("微软雅黑", 12F);
            this.uiCheckBox4.Location = new System.Drawing.Point(516, 46);
            this.uiCheckBox4.Name = "uiCheckBox4";
            this.uiCheckBox4.Padding = new System.Windows.Forms.Padding(22, 0, 0, 0);
            this.uiCheckBox4.Size = new System.Drawing.Size(150, 35);
            this.uiCheckBox4.TabIndex = 22;
            this.uiCheckBox4.Text = "uiCheckBox4";
            // 
            // uiCheckBox2
            // 
            this.uiCheckBox2.Cursor = System.Windows.Forms.Cursors.Hand;
            this.uiCheckBox2.Font = new System.Drawing.Font("微软雅黑", 12F);
            this.uiCheckBox2.Location = new System.Drawing.Point(192, 48);
            this.uiCheckBox2.Name = "uiCheckBox2";
            this.uiCheckBox2.Padding = new System.Windows.Forms.Padding(22, 0, 0, 0);
            this.uiCheckBox2.Size = new System.Drawing.Size(150, 35);
            this.uiCheckBox2.TabIndex = 39;
            this.uiCheckBox2.Text = "uiCheckBox2";
            // 
            // uiCheckBoxGroup1
            // 
            this.uiCheckBoxGroup1.ColumnCount = 2;
            this.uiCheckBoxGroup1.Font = new System.Drawing.Font("微软雅黑", 12F);
            this.uiCheckBoxGroup1.Items.AddRange(new object[] {
            "0",
            "1",
            "2",
            "3",
            "4",
            "5",
            "6",
            "7",
            "8"});
            this.uiCheckBoxGroup1.Location = new System.Drawing.Point(30, 91);
            this.uiCheckBoxGroup1.Margin = new System.Windows.Forms.Padding(4, 5, 4, 5);
            this.uiCheckBoxGroup1.Name = "uiCheckBoxGroup1";
            this.uiCheckBoxGroup1.Size = new System.Drawing.Size(670, 211);
            this.uiCheckBoxGroup1.TabIndex = 41;
            this.uiCheckBoxGroup1.Text = "UICheckBoxGroup";
            this.uiCheckBoxGroup1.ValueChanged += new Mallie.UI.UICheckBoxGroup.OnValueChanged(this.uiCheckBoxGroup1_ValueChanged);
            // 
            // FCheckBox
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(10F, 21F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(800, 556);
            this.Name = "FCheckBox";
            this.PageIndex = 1002;
            this.Text = "CheckBox";
            this.PagePanel.ResumeLayout(false);
            this.ResumeLayout(false);

        }

        #endregion

        private UICheckBox uiCheckBox1;
        private UILine uiLine1;
        private UICheckBox uiCheckBox4;
        private UICheckBox uiCheckBox3;
        private UICheckBox uiCheckBox2;
        private UICheckBoxGroup uiCheckBoxGroup1;
    }
}
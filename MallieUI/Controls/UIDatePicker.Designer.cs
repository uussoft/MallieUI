﻿namespace Mallie.UI
{
    partial class UIDatePicker
    {
        /// <summary> 
        /// 必需的设计器变量。
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary> 
        /// 清理所有正在使用的资源。
        /// </summary>
        /// <param name="disposing">如果应释放托管资源，为 true；否则为 false。</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region 组件设计器生成的代码

        /// <summary> 
        /// 设计器支持所需的方法 - 不要修改
        /// 使用代码编辑器修改此方法的内容。
        /// </summary>
        private void InitializeComponent()
        {
            SuspendLayout();
            // 
            // UIDatePicker
            // 
            AutoScaleDimensions = new System.Drawing.SizeF(10F, 21F);
            AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            DropDownStyle = Mallie.UI.UIDropDownStyle.DropDownList;
            Name = "UIDatePicker";
            Padding = new System.Windows.Forms.Padding(0, 0, 30, 0);
            ButtonClick += new System.EventHandler(UIDatetimePicker_ButtonClick);
            ResumeLayout(false);
            PerformLayout();

        }

        #endregion
    }
}

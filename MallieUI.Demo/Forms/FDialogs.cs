﻿using System;
using System.Collections.Generic;

namespace Mallie.UI.Demo
{
    public partial class FDialogs : UITitlePage
    {
        public FDialogs()
        {
            InitializeComponent();
        }

        private void btnAsk_Click(object sender, EventArgs e)
        {
            if (this.ShowAskDialog("确认信息提示框"))
            {
                this.ShowInfoDialog("您点击了确定按钮");
            }
            else
            {
                this.ShowErrorDialog("您点击了取消按钮");
            }
        }

        private void btnAuto_Click(object sender, EventArgs e)
        {
            this.ShowInfoDialog("跟随界面主题风格信息提示框", Style);
        }

        private void btnSuccess_Click(object sender, EventArgs e)
        {
            this.ShowSuccessDialog("正确信息提示框");
        }

        private void btnWarn_Click(object sender, EventArgs e)
        {
            this.ShowWarningDialog("警告信息提示框");
        }

        private void btnError_Click(object sender, EventArgs e)
        {
            this.ShowErrorDialog("错误信息提示框");
        }

        private void btnStatus2_Click(object sender, EventArgs e)
        {
            ShowStatus("提示", "数据加载中......");
            for (int i = 0; i < 100; i++)
            {
                SystemEx.Delay(50);
                StatusStepIt();
            }
        }

        private void btnInfo_Click(object sender, EventArgs e)
        {
            this.ShowInfoDialog("默认信息提示框");
        }

        private void btnStringInput_Click(object sender, EventArgs e)
        {
            string value = "请输入字符串";
            if (this.InputStringDialog(ref value))
            {
                this.ShowInfoDialog(value);
            }
        }

        private void btnIntInput_Click(object sender, EventArgs e)
        {
            int value = 0;
            if (this.InputIntegerDialog(ref value))
            {
                this.ShowInfoDialog(value.ToString());
            }
        }

        private void btnDoubleInput_Click(object sender, EventArgs e)
        {
            double value = 0;
            if (this.InputDoubleDialog(ref value))
            {
                this.ShowInfoDialog(value.ToString("F2"));
            }
        }

        private void btnPasswordInput_Click(object sender, EventArgs e)
        {
            string value = "";
            if (this.InputPasswordDialog(ref value))
            {
                this.ShowInfoDialog(value);
            }
        }

        private void uiSymbolButton1_Click(object sender, EventArgs e)
        {
            List<string> items = new List<string>() { "0", "1", "2", "3", "4" };
            int index = 2;
            if (this.ShowSelectDialog(ref index, items))
            {
                this.ShowInfoDialog(index.ToString());
            }
        }

        private void uiSymbolButton2_Click(object sender, EventArgs e)
        {
            this.ShowInfoNotifier("Info");
        }

        private void uiSymbolButton6_Click(object sender, EventArgs e)
        {
            this.ShowSuccessNotifier("Success");
        }

        private void uiSymbolButton5_Click(object sender, EventArgs e)
        {
            this.ShowWarningNotifier("Warning");
        }

        private void uiSymbolButton4_Click(object sender, EventArgs e)
        {
            this.ShowErrorNotifier("Error");
        }
    }
}
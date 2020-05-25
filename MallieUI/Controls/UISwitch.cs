﻿/******************************************************************************
 * MallieUI 开源控件库、工具类库、扩展类库、多页面开发框架。
 * CopyRight (C) 2012-2020 ShenYongHua(沈永华).
 * QQ群：56829229 QQ：17612584 EMail：MallieUI@qq.com
 *
 * Blog:   https://www.cnblogs.com/yhuse
 * Gitee:  https://gitee.com/yhuse/MallieUI
 * GitHub: https://github.com/yhuse/MallieUI
 *
 * MallieUI.dll can be used for free under the GPL-3.0 license.
 * If you use this code, please keep this note.
 * 如果您使用此代码，请保留此说明。
 ******************************************************************************
 * 文件名称: UISwitch.cs
 * 文件说明: 开关
 * 当前版本: V2.2
 * 创建日期: 2020-01-01
 *
 * 2020-01-01: V2.2.0 增加文件说明
 * 2020-04-25: V2.2.4 更新主题配置类
******************************************************************************/

using System;
using System.ComponentModel;
using System.Drawing;
using System.Drawing.Drawing2D;

namespace Mallie.UI
{
    [DefaultEvent("ValueChanged")]
    [DefaultProperty("ActiveValue")]
    [ToolboxItem(true)]
    public sealed class UISwitch : UIControl
    {
        public delegate void OnValueChanged(object sender, bool value);

        public UISwitch()
        {
            Height = 29;
            Width = 75;
            ShowText = false;
            ShowRect = false;
            foreColor = Color.White;
            inActiveColor = Color.Silver;
            fillColor = Color.White;
        }

        public event OnValueChanged ValueChanged;

        /// <summary>
        /// 字体颜色
        /// </summary>
        [Description("字体颜色"), Category("自定义")]
        [DefaultValue(typeof(Color), "White")]
        public override Color ForeColor
        {
            get => foreColor;
            set => SetForeColor(value);
        }

        private bool activeValue;

        [DefaultValue(false)]
        public bool Active
        {
            get => activeValue;
            set
            {
                activeValue = value;
                ValueChanged?.Invoke(this, value);
                Invalidate();
            }
        }

        private string activeText = "开";

        [DefaultValue("开")]
        public string ActiveText
        {
            get => activeText;
            set
            {
                activeText = value;
                Invalidate();
            }
        }

        private string inActiveText = "关";

        [DefaultValue("关")]
        public string InActiveText
        {
            get => inActiveText;
            set
            {
                inActiveText = value;
                Invalidate();
            }
        }

        private Color inActiveColor;

        [DefaultValue(typeof(Color), "Silver")]
        public Color InActiveColor
        {
            get => inActiveColor;
            set
            {
                inActiveColor = value;
                Invalidate();
            }
        }

        /// <summary>
        /// 填充颜色，当值为背景色或透明色或空值则不填充
        /// </summary>
        [Description("填充颜色"), Category("自定义")]
        [DefaultValue(typeof(Color), "White")]
        public Color ButtonColor
        {
            get => fillColor;
            set => SetFillColor(value);
        }

        /// <summary>
        /// 边框颜色
        /// </summary>
        [Description("选中颜色"), Category("自定义")]
        [DefaultValue(typeof(Color), "80, 160, 255")]
        public Color ActiveColor
        {
            get => rectColor;
            set => SetRectColor(value);
        }

        protected override void OnClick(EventArgs e)
        {
            base.OnClick(e);
            Active = !Active;
        }

        public override void SetStyleColor(UIBaseStyle uiColor)
        {
            base.SetStyleColor(uiColor);
            if (uiColor.IsCustom()) return;

            rectColor = uiColor.SwitchActiveColor;
            fillColor = uiColor.SwitchFillColor;
            inActiveColor = uiColor.SwitchInActiveColor;
            Invalidate();
        }

        protected override void OnPaintFill(Graphics g, GraphicsPath path)
        {
            Width = (int)(Height * 2.6);
            Rectangle rect = new Rectangle(0, 0, Width - 1, Height - 1);
            g.FillRoundRectangle(Active ? ActiveColor : InActiveColor, rect, rect.Height);

            int width = Width - 3 - 1 - 3 - (rect.Height - 6);
            if (!Active)
            {
                g.FillEllipse(fillColor.IsValid() ? fillColor : Color.White, 3, 3, rect.Height - 6, rect.Height - 6);
                SizeF sf = g.MeasureString(InActiveText, Font);
                g.DrawString(InActiveText, Font, fillColor.IsValid() ? fillColor : Color.White, 3 + rect.Height - 6 + (width - sf.Width) / 2, 3 + (rect.Height - 6 - sf.Height) / 2);
            }
            else
            {
                g.FillEllipse(fillColor.IsValid() ? fillColor : Color.White, Width - 3 - 1 - (rect.Height - 6), 3, rect.Height - 6, rect.Height - 6);
                SizeF sf = g.MeasureString(ActiveText, Font);
                g.DrawString(ActiveText, Font, fillColor.IsValid() ? fillColor : Color.White, 3 + (width - sf.Width) / 2, 3 + (rect.Height - 6 - sf.Height) / 2);
            }
        }
    }
}
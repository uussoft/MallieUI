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
 * 文件名称: UIDatePicker.cs
 * 文件说明: 日期选择框
 * 当前版本: V2.2
 * 创建日期: 2020-01-01
 *
 * 2020-01-01: V2.2.0 增加文件说明
******************************************************************************/

using System;
using System.ComponentModel;
using System.Windows.Forms;

namespace Mallie.UI
{
    [ToolboxItem(true)]
    public sealed partial class UIDatePicker : UIDropControl
    {
        public delegate void OnDateTimeChanged(object sender, DateTime value);

        public UIDatePicker()
        {
            InitializeComponent();
            Value = DateTime.Now;
        }

        public event OnDateTimeChanged ValueChanged;

        protected override void ItemForm_ValueChanged(object sender, object value)
        {
            Value = (DateTime)value;
            Text = Value.ToString(dateFormat);
            Invalidate();
            ValueChanged?.Invoke(this, Value);
        }

        private readonly UIDateTimeControl item = new UIDateTimeControl();

        protected override void CreateInstance()
        {
            ItemForm = new UIDropDown(item);
        }

        private MonthCalendar MonthCalendar
        {
            get
            {
                return item.MonthCalendar;
            }
        }

        public DateTime Value
        {
            get => MonthCalendar.SelectionStart.Date;
            set
            {
                Text = value.ToString(dateFormat);
                MonthCalendar.SelectionStart = value;
            }
        }

        private void UIDatetimePicker_ButtonClick(object sender, EventArgs e)
        {
            ItemForm.Show(this);
        }

        private string dateFormat = "yyyy-MM-dd";

        [Description("日期格式化掩码"), Category("自定义")]
        [DefaultValue("yyyy-MM-dd")]
        public string DateFormat
        {
            get => dateFormat;
            set
            {
                dateFormat = value;
                Text = Value.ToString(dateFormat);
            }
        }
    }
}
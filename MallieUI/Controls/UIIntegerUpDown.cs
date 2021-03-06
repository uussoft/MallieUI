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
 * 文件名称: UIIntegerUpDown.cs
 * 文件说明: 数字上下选择框
 * 当前版本: V2.2
 * 创建日期: 2020-01-01
 *
 * 2020-01-01: V2.2.0 增加文件说明
 * 2020-04-25: V2.2.4 更新主题配置类
******************************************************************************/

using System;
using System.ComponentModel;

namespace Mallie.UI
{
    [DefaultEvent("ValueChanged")]
    [DefaultProperty("Value")]
    public sealed partial class UIIntegerUpDown : UIPanel
    {
        public delegate void OnValueChanged(object sender, int value);

        public UIIntegerUpDown()
        {
            InitializeComponent();
            ShowText = false;
        }

        public event OnValueChanged ValueChanged;

        private int _value;

        [DefaultValue(0)]
        public int Value
        {
            get => _value;
            set
            {
                value = CheckMaxMin(value);
                _value = value;
                pnlValue.Text = _value.ToString();
                ValueChanged?.Invoke(this, _value);
            }
        }

        private int step = 1;

        [DefaultValue(1)]
        public int Step
        {
            get => step;
            set { step = Math.Max(1, value); }
        }

        private void btnAdd_Click(object sender, EventArgs e)
        {
            Value += Step;
        }

        private void btnDec_Click(object sender, EventArgs e)
        {
            Value -= Step;
        }

        private int _maximum = int.MaxValue;
        private int _minimum = int.MinValue;

        [DefaultValue(int.MaxValue)]
        public int Maximum
        {
            get => _maximum;
            set
            {
                _maximum = value;
                if (_maximum < _minimum)
                    _minimum = _maximum;

                Value = CheckMaxMin(Value);
                Invalidate();
            }
        }

        [DefaultValue(int.MinValue)]
        public int Minimum
        {
            get => _minimum;
            set
            {
                _minimum = value;
                if (_minimum > _maximum)
                    _maximum = _minimum;

                Value = CheckMaxMin(Value);
                Invalidate();
            }
        }

        private int CheckMaxMin(int value)
        {
            if (hasMaximum)
            {
                if (value > _maximum)
                    value = _maximum;
            }

            if (hasMinimum)
            {
                if (value < _minimum)
                    value = _minimum;
            }

            return value;
        }

        private bool hasMaximum;
        private bool hasMinimum;

        [DefaultValue(false)]
        public bool HasMaximum
        {
            get => hasMaximum;
            set
            {
                if (hasMaximum != value)
                {
                    hasMaximum = value;
                    Value = CheckMaxMin(Value);
                    Invalidate();
                }
            }
        }

        [DefaultValue(false)]
        public bool HasMinimum
        {
            get => hasMinimum;
            set
            {
                if (hasMinimum != value)
                {
                    hasMinimum = value;
                    Value = CheckMaxMin(Value);
                    Invalidate();
                }
            }
        }
    }
}
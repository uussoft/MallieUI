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
 * 文件名称: UITabControlMenu.cs
 * 文件说明: 标签菜单控件
 * 当前版本: V2.2
 * 创建日期: 2020-01-01
 *
 * 2020-01-01: V2.2.0 增加文件说明
******************************************************************************/

using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Windows.Forms;

namespace Mallie.UI
{
    public sealed class UITabControlMenu : TabControl, IStyleInterface
    {
        public UITabControlMenu()
        {
            SetStyle(ControlStyles.AllPaintingInWmPaint | ControlStyles.UserPaint | ControlStyles.ResizeRedraw | ControlStyles.DoubleBuffer, true);

            ItemSize = new Size(40, 200);
            DrawMode = TabDrawMode.OwnerDrawFixed;
            Font = UIFontColor.Font;
            AfterSetFillColor(FillColor);
            Size = new Size(450, 270);
            Version = UIGlobal.Version;
        }

        [DefaultValue(false)]
        public bool StyleCustomMode { get; set; }

        [DefaultValue(null)]
        public string TagString { get; set; }

        public string Version { get; }

        private HorizontalAlignment textAlignment = HorizontalAlignment.Center;

        public HorizontalAlignment TextAlignment
        {
            get => textAlignment;
            set
            {
                textAlignment = value;
                Invalidate();
            }
        }

        private Color _fillColor = UIColor.LightBlue;
        private Color tabBackColor = Color.FromArgb(56, 56, 56);

        /// <summary>
        /// 当使用边框时填充颜色，当值为背景色或透明色或空值则不填充
        /// </summary>
        [Description("当使用边框时填充颜色，当值为背景色或透明色或空值则不填充"), Category("自定义")]
        [DefaultValue(typeof(Color), "235, 243, 255")]
        public Color FillColor
        {
            get => _fillColor;
            set
            {
                _fillColor = value;
                AfterSetFillColor(value);
                _style = UIStyle.Custom;
                Invalidate();
            }
        }

        /// <summary>
        /// 边框颜色
        /// </summary>
        [Description("边框颜色"), Category("自定义")]
        [DefaultValue(typeof(Color), "56, 56, 56")]
        public Color TabBackColor
        {
            get => tabBackColor;
            set
            {
                tabBackColor = value;
                _menuStyle = UIMenuStyle.Custom;
                Invalidate();
            }
        }

        private Color tabSelectedColor = Color.FromArgb(36, 36, 36);

        /// <summary>
        /// 边框颜色
        /// </summary>
        [Description("选中Tab页背景色"), Category("自定义")]
        [DefaultValue(typeof(Color), "36, 36, 36")]
        public Color TabSelectedColor
        {
            get => tabSelectedColor;
            set
            {
                tabSelectedColor = value;
                _menuStyle = UIMenuStyle.Custom;
                Invalidate();
            }
        }

        private Color tabSelectedForeColor = UIColor.Blue;

        /// <summary>
        /// 边框颜色
        /// </summary>
        [Description("选中Tab页字体色"), Category("自定义")]
        [DefaultValue(typeof(Color), "80, 160, 255")]
        public Color TabSelectedForeColor
        {
            get => tabSelectedForeColor;
            set
            {
                tabSelectedForeColor = value;
                _style = UIStyle.Custom;
                Invalidate();
            }
        }

        private Color tabUnSelectedForeColor = Color.Silver;

        /// <summary>
        /// 边框颜色
        /// </summary>
        [Description("未选中Tab页字体色"), Category("自定义")]
        [DefaultValue(typeof(Color), "Silver")]
        public Color TabUnSelectedForeColor
        {
            get => tabUnSelectedForeColor;
            set
            {
                tabUnSelectedForeColor = value;
                _menuStyle = UIMenuStyle.Custom;
                Invalidate();
            }
        }

        private Color tabSelectedHighColor = UIColor.Blue;

        /// <summary>
        /// 边框颜色
        /// </summary>
        [Description("选中Tab页高亮"), Category("自定义")]
        [DefaultValue(typeof(Color), "80, 160, 255")]
        public Color TabSelectedHighColor

        {
            get => tabSelectedHighColor;
            set
            {
                tabSelectedHighColor = value;
                _style = UIStyle.Custom;
                Invalidate();
            }
        }

        private UIStyle _style = UIStyle.Blue;

        [DefaultValue(UIStyle.Blue)]
        public UIStyle Style
        {
            get => _style;
            set => SetStyle(value);
        }

        public override Rectangle DisplayRectangle
        {
            get
            {
                Rectangle rect = base.DisplayRectangle;
                return new Rectangle(rect.Left - 3, rect.Top - 4, rect.Width + 7, rect.Height + 8);
            }
        }

        private void AfterSetFillColor(Color color)
        {
            foreach (TabPage page in TabPages)
            {
                page.BackColor = color;
            }
        }

        public void SetStyle(UIStyle style)
        {
            SetStyleColor(UIStyles.GetStyleColor(style));
            _style = style;
        }

        public void SetStyleColor(UIBaseStyle uiColor)
        {
            if (uiColor.IsCustom()) return;

            tabSelectedForeColor = tabSelectedHighColor = uiColor.MenuSelectedColor;
            _fillColor = uiColor.PlainColor;
            Invalidate();
        }

        private UIMenuStyle _menuStyle = UIMenuStyle.Black;

        [DefaultValue(UIMenuStyle.Black)]
        public UIMenuStyle MenuStyle
        {
            get => _menuStyle;
            set
            {
                if (value != UIMenuStyle.Custom)
                {
                    SetMenuStyle(UIStyles.MenuColors[value]);
                }

                _menuStyle = value;
            }
        }

        private void SetMenuStyle(UIMenuColor uiColor)
        {
            TabBackColor = uiColor.BackColor;
            TabSelectedColor = uiColor.SelectedColor;
            TabUnSelectedForeColor = uiColor.UnSelectedForeColor;
        }

        protected override void CreateHandle()
        {
            base.CreateHandle();
            DoubleBuffered = true;
            SizeMode = TabSizeMode.Fixed;
            Appearance = TabAppearance.Normal;
            Alignment = TabAlignment.Left;
        }

        protected override void OnControlAdded(ControlEventArgs e)
        {
            base.OnControlAdded(e);
            if (e.Control is TabPage)
            {
                //e.Control.BackColor = FillColor;
                e.Control.Padding = new Padding(0);
            }
        }

        protected override void OnPaint(PaintEventArgs e)
        {
            base.OnPaint(e);

            // 绘制背景色
            e.Graphics.Clear(TabBackColor);
            for (int index = 0; index <= TabCount - 1; index++)
            {
                Rectangle TabRect = new Rectangle(GetTabRect(index).Location.X - 2, GetTabRect(index).Location.Y - 2, ItemSize.Height + 4, ItemSize.Width);
                SizeF sf = e.Graphics.MeasureString(TabPages[index].Text, Font);
                int textLeft = 4 + 6 + 4 + (ImageList?.ImageSize.Width ?? 0);
                if (TextAlignment == HorizontalAlignment.Right)
                    textLeft = (int)(TabRect.Width - 4 - sf.Width);
                if (TextAlignment == HorizontalAlignment.Center)
                    textLeft = textLeft + (int)((TabRect.Width - textLeft - sf.Width) / 2.0f);

                if (index == SelectedIndex)
                {
                    // 绘制Tab选中背景色
                    e.Graphics.FillRectangle(TabSelectedColor, TabRect.X, TabRect.Y, TabRect.Width, TabRect.Height + 4);

                    // 绘制Tab选中高亮
                    e.Graphics.FillRectangle(TabSelectedHighColor, TabRect.X, TabRect.Y, 4, TabRect.Height + 3);
                }

                // 绘制标题
                Color textColor = index == SelectedIndex ? tabSelectedForeColor : TabUnSelectedForeColor;
                e.Graphics.DrawString(TabPages[index].Text, Font, textColor, textLeft, TabRect.Top + 2 + (TabRect.Height - sf.Height) / 2.0f);

                // 绘制图标
                if (ImageList != null)
                {
                    int imageIndex = TabPages[index].ImageIndex;
                    if (imageIndex >= 0 && imageIndex < ImageList.Images.Count)
                    {
                        e.Graphics.DrawImage(ImageList.Images[imageIndex], TabRect.X + 4 + 6, TabRect.Y + 2 + (TabRect.Height - ImageList.ImageSize.Height) / 2.0f, ImageList.ImageSize.Width, ImageList.ImageSize.Height);
                    }
                }
            }
        }

        protected override void OnSelectedIndexChanged(EventArgs e)
        {
            base.OnSelectedIndexChanged(e);
            Init(SelectedIndex);
        }

        public void Init(int index = 0)
        {
            if (index < 0 || index >= TabPages.Count)
            {
                return;
            }

            if (SelectedIndex != index)
                SelectedIndex = index;

            List<UIPage> pages = TabPages[SelectedIndex].GetControls<UIPage>();
            foreach (var page in pages)
            {
                page.Init();
            }

            List<UITabControlMenu> leftTabControls = TabPages[SelectedIndex].GetControls<UITabControlMenu>();
            foreach (var tabControl in leftTabControls)
            {
                tabControl.Init();
            }

            List<UITabControl> topTabControls = TabPages[SelectedIndex].GetControls<UITabControl>();
            foreach (var tabControl in topTabControls)
            {
                tabControl.Init();
            }
        }
    }

    public static class UITabControlHelper
    {
        public static UIPage AddPage(this TabControl tabControl, int pageIndex, UIPage page)
        {
            page.PageIndex = pageIndex;
            return tabControl.AddPage(page);
        }

        public static UIPage AddPage(this TabControl tabControl, UIPage page)
        {
            if (page.PageIndex < 0)
            {
                page.PageIndex = RandomEx.RandomNumber(8).ToInt();
            }

            TabPage tagPage = tabControl.CreateTabIfNotExists(page.PageIndex);
            tagPage.Controls.Add(page);
            tagPage.Text = page.Text;
            page.Show();

            return page;
        }

        public static void AddPages(this TabControl tabControl, params UIPage[] pages)
        {
            foreach (var page in pages)
            {
                tabControl.AddPage(page);
            }
        }

        public static void AddPage(this TabControl tabControl, int index, UITabControlMenu page)
        {
            tabControl.CreateTabIfNotExists(index);
            tabControl.TabPages[index].Controls.Add(page);
            page.Show();
            page.Dock = DockStyle.Fill;
        }

        public static void AddPage(this TabControl tabControl, int index, UITabControl page)
        {
            tabControl.CreateTabIfNotExists(index);
            tabControl.TabPages[index].Controls.Add(page);
            page.Show();
            page.Dock = DockStyle.Fill;
        }

        private static TabPage CreateTabIfNotExists(this TabControl tabControl, int index)
        {
            if (index < 0) return null;
            for (int i = 0; i < tabControl.TabPages.Count; i++)
            {
                TabPage existPage = tabControl.TabPages[i];

                if (existPage.Tag == null)
                {
                    if (existPage.Controls.Count > 0)
                    {
                        continue;
                    }
                    else
                    {
                        existPage.Tag = index;
                        return existPage;
                    }
                }

                if (tabControl.TabPages[i].Tag.ToString() == index.ToString())
                {
                    return tabControl.TabPages[i];
                }
            }

            TabPage page = new TabPage();
            page.SuspendLayout();
            page.Tag = index;
            page.Text = "tabPage" + tabControl.TabPages.Count;
            tabControl.Controls.Add(page);
            page.ResumeLayout();
            return page;
        }

        public static void SelectPage(this TabControl tabControl, int pageIndex)
        {
            if (pageIndex < 0) return;

            for (int i = 0; i < tabControl.TabPages.Count; i++)
            {
                if (tabControl.TabPages[i].Tag != null && tabControl.TabPages[i].Tag.ToString() == pageIndex.ToString())
                {
                    tabControl.SelectedIndex = i;
                }
            }
        }
    }
}
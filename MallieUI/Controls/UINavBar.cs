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
 * 文件名称: UINavBar.cs
 * 文件说明: 导航栏
 * 当前版本: V2.2
 * 创建日期: 2020-01-01
 *
 * 2020-01-01: V2.2.0 增加文件说明
******************************************************************************/

using System;
using System.ComponentModel;
using System.Drawing;
using System.Windows.Forms;

namespace Mallie.UI
{
    [DefaultEvent("MenuItemClick")]
    [DefaultProperty("Nodes")]
    public sealed partial class UINavBar : ScrollableControl, IStyleInterface
    {
        public readonly UINavMenu Menu = new UINavMenu();

        private readonly UIContextMenuStrip NavBarMenu = new UIContextMenuStrip();

        public UINavBar()
        {
            InitializeComponent();

            SetStyle(ControlStyles.AllPaintingInWmPaint, true);
            SetStyle(ControlStyles.DoubleBuffer, true);
            SetStyle(ControlStyles.ResizeRedraw, true);
            SetStyle(ControlStyles.Selectable, true);
            SetStyle(ControlStyles.SupportsTransparentBackColor, true);
            SetStyle(ControlStyles.UserPaint, true);
            SetStyle(ControlStyles.OptimizedDoubleBuffer, true);
            DoubleBuffered = true;
            UpdateStyles();
            Font = UIFontColor.Font;

            NavBarMenu.VisibleChanged += NavBarMenu_VisibleChanged;
            Dock = DockStyle.Top;
            Width = 500;
            Height = 110;
            Version = UIGlobal.Version;
        }

        [DefaultValue(null)]
        public TabControl TabControl { get; set; }

        public void SetNodeItem(TreeNode node, NavMenuItem item)
        {
            MenuHelper.Add(node, item);
        }

        public void SetNodePageIndex(TreeNode node, int pageIndex)
        {
            MenuHelper.SetPageIndex(node, pageIndex);
        }

        [DefaultValue(null)]
        public string TagString { get; set; }

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

        private Color foreColor = Color.Silver;

        /// <summary>
        /// 字体颜色
        /// </summary>
        [Description("字体颜色"), Category("自定义")]
        [DefaultValue(typeof(Color), "Silver")]
        public override Color ForeColor
        {
            get => foreColor;
            set
            {
                foreColor = value;
                _menuStyle = UIMenuStyle.Custom;
                Invalidate();
            }
        }

        protected override void OnBackColorChanged(EventArgs e)
        {
            base.OnBackColorChanged(e);
            _menuStyle = UIMenuStyle.Custom;
        }

        private Color backColor = Color.FromArgb(56, 56, 56);

        public override Color BackColor
        {
            get => backColor;
            set
            {
                backColor = value;
                _menuStyle = UIMenuStyle.Custom;
                Invalidate();
            }
        }

        private void SetMenuStyle(UIMenuColor uiColor)
        {
            foreColor = uiColor.UnSelectedForeColor;
            backColor = uiColor.BackColor;
            menuHoverColor = uiColor.HoverColor;
            Invalidate();
        }

        private Color menuHoverColor = Color.FromArgb(76, 76, 76);

        [DefaultValue(typeof(Color), "76, 76, 76")]
        public Color MenuHoverColor
        {
            get => menuHoverColor;
            set
            {
                menuHoverColor = value;
                _menuStyle = UIMenuStyle.Custom;
            }
        }

        private Color selectedHighColor = UIColor.Blue;

        /// <summary>
        /// 边框颜色
        /// </summary>
        [Description("选中Tab页高亮"), Category("自定义")]
        [DefaultValue(typeof(Color), "80, 160, 255")]
        public Color SelectedHighColor

        {
            get => selectedHighColor;
            set
            {
                selectedHighColor = value;
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

        private void NavBarMenu_VisibleChanged(object sender, EventArgs e)
        {
            Invalidate();
        }

        [DesignerSerializationVisibility(DesignerSerializationVisibility.Content)]
        [Localizable(true)]
        [MergableProperty(false)]
        public TreeNodeCollection Nodes => Menu.Nodes;

        [DefaultValue(null)]
        public ImageList ImageList
        {
            get => Menu.ImageList;
            set => Menu.ImageList = value;
        }

        [DefaultValue(null)]
        public ImageList DropMenuImageList
        {
            get => NavBarMenu.ImageList;
            set => NavBarMenu.ImageList = value;
        }

        private StringAlignment nodeAlignment = StringAlignment.Far;

        [DefaultValue(StringAlignment.Far)]
        public StringAlignment NodeAlignment
        {
            get => nodeAlignment;
            set
            {
                nodeAlignment = value;
                Invalidate();
            }
        }

        private int NodeX;
        private int NodeY;
        private int ActiveIndex = -1;

        private int selectedIndex = -1;

        private readonly NavMenuHelper MenuHelper = new NavMenuHelper();

        [DefaultValue(-1)]
        public int SelectedIndex
        {
            get => selectedIndex;
            set
            {
                if (Nodes.Count > 0 && value >= 0 && value < Nodes.Count)
                {
                    selectedIndex = value;

                    if (Nodes[value].Nodes.Count == 0)
                    {
                        MenuItemClick?.Invoke(Nodes[SelectedIndex].Text, selectedIndex, MenuHelper.GetPageIndex(Nodes[SelectedIndex]));
                        TabControl?.SelectPage(MenuHelper.GetPageIndex(Nodes[SelectedIndex]));
                    }

                    Invalidate();
                }
            }
        }

        private Color selectedForeColor = UIColor.Blue;

        [DefaultValue(typeof(Color), "80, 160, 255")]
        public Color SelectedForeColor
        {
            get => selectedForeColor;
            set
            {
                if (selectedForeColor != value)
                {
                    selectedForeColor = value;
                    _style = UIStyle.Custom;
                    Invalidate();
                }
            }
        }

        protected override void OnPaint(PaintEventArgs e)
        {
            base.OnPaint(e);

            e.Graphics.Clear(BackColor);
            NodeX = 0;
            NodeY = Height - NodeSize.Height;

            switch (NodeAlignment)
            {
                case StringAlignment.Near:
                    NodeX = NodeInterval;
                    break;

                case StringAlignment.Center:
                    NodeX = (Width - Nodes.Count * NodeSize.Width) * 2;
                    break;

                case StringAlignment.Far:
                    NodeX = Width - Nodes.Count * NodeSize.Width - NodeInterval;
                    break;
            }

            for (int i = 0; i < Nodes.Count; i++)
            {
                Rectangle rect = new Rectangle(NodeX + i * NodeSize.Width, NodeY, NodeSize.Width, NodeSize.Height);

                SizeF sf = e.Graphics.MeasureString(Nodes[i].Text, Font);
                Color textColor = ForeColor;

                if (i == ActiveIndex)
                {
                    e.Graphics.FillRectangle(MenuHoverColor, rect);
                    textColor = SelectedForeColor;
                }

                if (i == SelectedIndex)
                {
                    if (!NavBarMenu.Visible)
                    {
                        e.Graphics.FillRectangle(new SolidBrush(SelectedHighColor), rect.X, Height - 4, rect.Width, 4);
                    }

                    textColor = SelectedForeColor;
                }

                e.Graphics.DrawString(Nodes[i].Text, Font, new SolidBrush(textColor), NodeX + i * NodeSize.Width + (NodeSize.Width - sf.Width) / 2.0f, NodeY + (NodeSize.Height - sf.Height) / 2);
                if (Nodes[i].Nodes.Count > 0)
                {
                    SizeF imageSize = e.Graphics.GetFontImageSize(61703, 24);
                    if (i != SelectedIndex)
                    {
                        e.Graphics.DrawFontImage(61703, 24, textColor, NodeX + i * NodeSize.Width + rect.Width - 24, rect.Top + (rect.Height - imageSize.Height) / 2);
                    }
                    else
                    {
                        e.Graphics.DrawFontImage(NavBarMenu.Visible ? 61702 : 61703, 24, textColor, NodeX + i * NodeSize.Width + rect.Width - 24, rect.Top + (rect.Height - imageSize.Height) / 2);
                    }
                }
            }
        }

        private int _nodeInterval = 100;

        [DefaultValue(100)]
        public int NodeInterval
        {
            get => _nodeInterval;
            set
            {
                if (_nodeInterval != value)
                {
                    _nodeInterval = value;
                    Invalidate();
                }
            }
        }

        private Size nodeSize = new Size(130, 45);

        [DefaultValue(typeof(Size), "130, 45")]
        public Size NodeSize
        {
            get => nodeSize;
            set
            {
                if (nodeSize != value)
                {
                    nodeSize = value;
                    Invalidate();
                }
            }
        }

        protected override void OnMouseLeave(EventArgs e)
        {
            base.OnMouseLeave(e);
            ActiveIndex = -1;
            Invalidate();
        }

        protected override void OnMouseMove(MouseEventArgs e)
        {
            base.OnMouseMove(e);

            if (e.X < NodeX || e.X > NodeX + Nodes.Count * NodeSize.Width || e.Y < NodeY)
            {
                if (ActiveIndex != -1)
                {
                    ActiveIndex = -1;
                    Invalidate();
                }

                return;
            }

            int index = (e.X - NodeX) / NodeSize.Width;
            if (ActiveIndex != index)
            {
                ActiveIndex = index;
                Invalidate();
            }
        }

        private int NodeMenuLeft(int index)
        {
            return NodeX + index * NodeSize.Width;
        }

        protected override void OnMouseClick(MouseEventArgs e)
        {
            base.OnMouseClick(e);

            if (ActiveIndex == -1) return;
            SelectedIndex = ActiveIndex;
            Invalidate();

            if (Nodes[selectedIndex].Nodes.Count == 0)
            {
                return;
            }

            NavBarMenu.Style = Style;
            NavBarMenu.Items.Clear();
            foreach (TreeNode node in Nodes[SelectedIndex].Nodes)
            {
                ToolStripMenuItem item = new ToolStripMenuItem(node.Text) { Tag = node.Tag };
                item.Click += Item_Click;
                NavBarMenu.Items.Add(item);

                if (node.Nodes.Count > 0)
                {
                    AddMenu(item, node);
                }
            }

            if (NavBarMenu.Width < NodeSize.Width)
            {
                NavBarMenu.AutoSize = false;
                NavBarMenu.Width = NodeSize.Width;
            }

            foreach (ToolStripItem item in NavBarMenu.Items)
            {
                item.AutoSize = false;
                item.Width = NavBarMenu.Width - 1;
                item.Height = 30;
            }

            NavBarMenu.CalcHeight();
            NavBarMenu.Show(this, NodeMenuLeft(SelectedIndex), Height);
        }

        private void Item_Click(object sender, EventArgs e)
        {
            ToolStripMenuItem item = (ToolStripMenuItem)sender;
            if (item.Tag != null && item.Tag is NavMenuItem mi)
            {
                TabControl?.SelectPage(mi.PageIndex);
                MenuItemClick?.Invoke(item.Text, selectedIndex, mi.PageIndex);
            }
        }

        public delegate void OnMenuItemClick(string text, int menuIndex, int pageIndex);

        public event OnMenuItemClick MenuItemClick;

        private void AddMenu(ToolStripMenuItem item, TreeNode node)
        {
            foreach (TreeNode childNode in node.Nodes)
            {
                ToolStripMenuItem childItem = new ToolStripMenuItem(childNode.Text) { Tag = childNode.Tag };
                item.DropDownItems.Add(childItem);

                if (childNode.Nodes.Count > 0)
                {
                    AddMenu(childItem, childNode);
                }
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

            selectedForeColor = selectedHighColor = uiColor.MenuSelectedColor;
            Invalidate();
        }

        [DefaultValue(false)]
        public bool StyleCustomMode { get; set; }

        public string Version { get; }
    }
}
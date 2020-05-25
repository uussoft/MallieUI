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
 * 文件名称: UGDI.cs
 * 文件说明: GDI扩展类
 * 当前版本: V2.2
 * 创建日期: 2020-01-01
 *
 * 2020-01-01: V2.2.0 增加文件说明
******************************************************************************/

using System;
using System.Drawing;
using System.Drawing.Drawing2D;
using System.Windows.Forms;

namespace Mallie.UI
{
    public static class GDIEx
    {
        /// <summary>
        /// 九宫切图背景填充，#，http://st233.com/blog.php?id=24
        /// 例如按钮是图片分成九个区域 然后只需要将四角填充到目标区域 其余的拉伸就可以了
        /// </summary>
        /// <param name="g"></param>
        /// <param name="img"></param>
        /// <param name="rect"></param>
        /// <param name="angleSize"></param>
        public static void DrawImageWithNineCut(this Graphics g, Image img, Rectangle rect, int angleSize = 5)
        {
            //填充四个角
            g.DrawImage(img, new Rectangle(rect.X, rect.Y, angleSize, angleSize),
                new Rectangle(0, 0, angleSize, angleSize), GraphicsUnit.Pixel);
            g.DrawImage(img, new Rectangle(rect.Right - angleSize, rect.Y, angleSize, angleSize),
                new Rectangle(img.Width - angleSize, 0, angleSize, angleSize), GraphicsUnit.Pixel);
            g.DrawImage(img, new Rectangle(rect.X, rect.Bottom - angleSize, angleSize, angleSize),
                new Rectangle(0, img.Height - angleSize, angleSize, angleSize), GraphicsUnit.Pixel);
            g.DrawImage(img, new Rectangle(rect.Right - angleSize, rect.Bottom - angleSize, angleSize, angleSize),
                new Rectangle(img.Width - angleSize, img.Height - angleSize, angleSize, angleSize), GraphicsUnit.Pixel);
            //四边
            g.DrawImage(img, new Rectangle(rect.X, rect.Y + angleSize, angleSize, rect.Height - 10),
                new Rectangle(0, angleSize, angleSize, img.Height - 10), GraphicsUnit.Pixel);
            g.DrawImage(img, new Rectangle(rect.X + angleSize, rect.Y, rect.Width - 10, angleSize),
                new Rectangle(angleSize, 0, img.Width - 10, angleSize), GraphicsUnit.Pixel);
            g.DrawImage(img, new Rectangle(rect.Right - angleSize, rect.Y + angleSize, angleSize, rect.Height - 10),
                new Rectangle(img.Width - angleSize, angleSize, angleSize, img.Height - 10), GraphicsUnit.Pixel);
            g.DrawImage(img, new Rectangle(rect.X + angleSize, rect.Bottom - angleSize, rect.Width - 10, angleSize),
                new Rectangle(angleSize, img.Height - angleSize, img.Width - 10, angleSize), GraphicsUnit.Pixel);
            //中间
            g.DrawImage(img,
                new Rectangle(rect.X + angleSize, rect.Y + angleSize, rect.Width - 10, rect.Height - 10),
                new Rectangle(angleSize, angleSize, img.Width - 10, img.Height - 10), GraphicsUnit.Pixel);
        }

        public static Color[] GradientColors(Color startColor, Color endColor, int count)
        {
            count = Math.Max(count, 2);
            Bitmap image = new Bitmap(1024, 3);
            Graphics g = image.Graphics();
            Brush br = new LinearGradientBrush(image.Bounds(), startColor, endColor, 0.0F);
            g.FillRectangle(br, image.Bounds());
            br.Dispose();
            g.Dispose();

            Color[] colors = new Color[count];
            colors[0] = startColor;
            colors[count - 1] = endColor;

            if (count > 2)
            {
                FastBitmap fb = new FastBitmap(image);
                fb.Lock();
                for (int i = 1; i < count - 1; i++)
                {
                    colors[i] = fb.GetPixel(image.Width * i / (count - 1), 1);
                }

                fb.Unlock();
                fb.Dispose();
            }

            image.Dispose();
            return colors;
        }

        public static bool InRect(this Point point, Rectangle rect)
        {
            return point.X >= rect.Left && point.X <= rect.Right && point.Y >= rect.Top && point.Y <= rect.Bottom;
        }

        public static bool InRect(this Point point, RectangleF rect)
        {
            return point.X >= rect.Left && point.X <= rect.Right && point.Y >= rect.Top && point.Y <= rect.Bottom;
        }

        public static bool InRect(this PointF point, Rectangle rect)
        {
            return point.X >= rect.Left && point.X <= rect.Right && point.Y >= rect.Top && point.Y <= rect.Bottom;
        }

        public static bool InRect(this PointF point, RectangleF rect)
        {
            return point.X >= rect.Left && point.X <= rect.Right && point.Y >= rect.Top && point.Y <= rect.Bottom;
        }

        public static void Smooth(this Graphics graphics, bool smooth = true)
        {
            if (smooth)
            {
                graphics.SetHighQuality();
            }
            else
            {
                graphics.SetDefaultQuality();
            }
        }

        public static void DrawString(this Graphics g, string text, Font font, Color color, int x, int y)
        {
            using (Brush br = new SolidBrush(color))
            {
                g.DrawString(text, font, br, x, y);
            }
        }

        public static void DrawString(this Graphics g, string text, Font font, Color color, RectangleF rect, StringFormat format)
        {
            using (Brush br = new SolidBrush(color))
            {
                g.DrawString(text, font, br, rect, format);
            }
        }

        public static void DrawString(this Graphics g, string text, Font font, Color color, Point pt)
        {
            g.DrawString(text, font, color, pt.X, pt.Y);
        }

        public static void DrawString(this Graphics g, string text, Font font, Color color, float x, float y)
        {
            using (Brush br = new SolidBrush(color))
            {
                g.DrawString(text, font, br, x, y);
            }
        }

        public static void DrawString(this Graphics g, string text, Font font, Color color, PointF pt)
        {
            g.DrawString(text, font, color, pt.X, pt.Y);
        }

        public static void DrawLines(this Graphics g, Color color, Point[] points, bool smooth = false)
        {
            using (Pen pen = new Pen(color))
            {
                g.Smooth(smooth);
                g.DrawLines(pen, points);
                g.Smooth(false);
            }
        }

        public static void DrawLines(this Graphics g, Color color, PointF[] points, bool smooth = false)
        {
            using (Pen pen = new Pen(color))
            {
                g.Smooth(smooth);
                g.DrawLines(pen, points);
                g.Smooth(false);
            }
        }

        public static void DrawLine(this Graphics g, Color color, int x1, int y1, int x2, int y2, bool smooth = false)
        {
            using (Pen pen = new Pen(color))
            {
                g.Smooth(smooth);
                g.DrawLine(pen, x1, y1, x2, y2);
                g.Smooth(false);
            }
        }

        public static void DrawLine(this Graphics g, Color color, Point pt1, Point pt2, bool smooth = false)
        {
            using (Pen pen = new Pen(color))
            {
                g.Smooth(smooth);
                g.DrawLine(pen, pt1, pt2);
                g.Smooth(false);
            }
        }

        public static void DrawArc(this Graphics g, Color color, int x, int y, int width, int height, int startAngle, int sweepAngle, bool smooth = true)
        {
            using (Pen pen = new Pen(color))
            {
                g.Smooth(smooth);
                g.DrawArc(pen, x, y, width, height, startAngle, sweepAngle);
                g.Smooth(false);
            }
        }

        public static void DrawArc(this Graphics g, Color color, float x, float y, float width, float height, float startAngle, float sweepAngle, bool smooth = true)
        {
            using (Pen pen = new Pen(color))
            {
                g.Smooth(smooth);
                g.DrawArc(pen, x, y, width, height, startAngle, sweepAngle);
                g.Smooth(false);
            }
        }

        public static void FillPath(this Graphics g, Color color, GraphicsPath path, bool smooth = true)
        {
            using (SolidBrush sb = new SolidBrush(color))
            {
                g.Smooth(smooth);
                g.FillPath(sb, path);
                g.Smooth(false);
            }
        }

        public static void DrawPath(this Graphics g, Color color, GraphicsPath path, bool smooth = true)
        {
            using (Pen pn = new Pen(color))
            {
                g.Smooth(smooth);
                g.DrawPath(pn, path);
                g.Smooth(false);
            }
        }

        public static void FillEllipse(this Graphics g, Color color, Rectangle rect, bool smooth = true)
        {
            using (SolidBrush sb = new SolidBrush(color))
            {
                g.Smooth(smooth);
                g.FillEllipse(sb, rect);
                g.Smooth(false);
            }
        }

        public static void DrawEllipse(this Graphics g, Color color, Rectangle rect, bool smooth = true)
        {
            using (Pen pn = new Pen(color))
            {
                g.Smooth(smooth);
                g.DrawEllipse(pn, rect);
                g.Smooth(false);
            }
        }

        public static void FillEllipse(this Graphics g, Color color, RectangleF rect, bool smooth = true)
        {
            using (SolidBrush sb = new SolidBrush(color))
            {
                g.Smooth(smooth);
                g.FillEllipse(sb, rect);
                g.Smooth(false);
            }
        }

        public static void DrawEllipse(this Graphics g, Color color, RectangleF rect, bool smooth = true)
        {
            using (Pen pn = new Pen(color))
            {
                g.Smooth(smooth);
                g.DrawEllipse(pn, rect);
                g.Smooth(false);
            }
        }

        public static void FillEllipse(this Graphics g, Color color, int left, int top, int width, int height, bool smooth = true)
        {
            g.FillEllipse(color, new Rectangle(left, top, width, height), smooth);
        }

        public static void DrawEllipse(this Graphics g, Color color, int left, int top, int width, int height, bool smooth = true)
        {
            g.DrawEllipse(color, new Rectangle(left, top, width, height), smooth);
        }

        public static void FillEllipse(this Graphics g, Color color, float left, float top, float width, float height, bool smooth = true)
        {
            g.FillEllipse(color, new RectangleF(left, top, width, height), smooth);
        }

        public static void DrawEllipse(this Graphics g, Color color, float left, float top, float width, float height, bool smooth = true)
        {
            g.DrawEllipse(color, new RectangleF(left, top, width, height), smooth);
        }

        public static void FillRectangle(this Graphics g, Color color, Rectangle rect, bool smooth = false)
        {
            using (SolidBrush sb = new SolidBrush(color))
            {
                g.Smooth(smooth);
                g.FillRectangle(sb, rect);
                g.Smooth(false);
            }
        }

        public static void DrawRectangle(this Graphics g, Color color, Rectangle rect, bool smooth = false)
        {
            using (Pen pn = new Pen(color))
            {
                g.Smooth(smooth);
                g.DrawRectangle(pn, rect);
                g.Smooth(false);
            }
        }

        public static void FillRectangle(this Graphics g, Color color, RectangleF rect, bool smooth = false)
        {
            using (SolidBrush sb = new SolidBrush(color))
            {
                g.Smooth(smooth);
                g.FillRectangle(sb, rect);
                g.Smooth(false);
            }
        }

        public static void DrawRectangle(this Graphics g, Color color, RectangleF rect, bool smooth = false)
        {
            using (Pen pn = new Pen(color))
            {
                g.Smooth(smooth);
                g.DrawRectangle(pn, rect.X, rect.Y, rect.Width, rect.Height);
                g.Smooth(false);
            }
        }

        public static void FillRectangle(this Graphics g, Color color, int left, int top, int width, int height, bool smooth = false)
        {
            g.FillRectangle(color, new Rectangle(left, top, width, height), smooth);
        }

        public static void DrawRectangle(this Graphics g, Color color, int left, int top, int width, int height, bool smooth = false)
        {
            g.DrawRectangle(color, new Rectangle(left, top, width, height), smooth);
        }

        public static void FillRectangle(this Graphics g, Color color, float left, float top, float width, float height, bool smooth = false)
        {
            g.FillRectangle(color, new RectangleF(left, top, width, height), smooth);
        }

        public static void DrawRectangle(this Graphics g, Color color, float left, float top, float width, float height, bool smooth = false)
        {
            g.DrawRectangle(color, new RectangleF(left, top, width, height), smooth);
        }

        public static void DrawRoundRectangle(this Graphics g, Pen pen, Rectangle rect, int cornerRadius, bool smooth = true)
        {
            using (GraphicsPath path = CreateRoundedRectanglePath(rect, cornerRadius))
            {
                g.Smooth(smooth);
                g.DrawPath(pen, path);
                g.Smooth(false);
            }
        }

        public static void FillRoundRectangle(this Graphics g, Brush brush, Rectangle rect, int cornerRadius, bool smooth = true)
        {
            using (GraphicsPath path = CreateRoundedRectanglePath(rect, cornerRadius))
            {
                g.Smooth(smooth);
                g.FillPath(brush, path);
                g.Smooth(false);
            }
        }

        public static void DrawRoundRectangle(this Graphics g, Pen pen, int left, int top, int width, int height, int cornerRadius, bool smooth = true)
        {
            g.DrawRoundRectangle(pen, new Rectangle(left, top, width, height), cornerRadius, smooth);
        }

        public static void FillRoundRectangle(this Graphics g, Brush brush, int left, int top, int width, int height, int cornerRadius, bool smooth = true)
        {
            g.FillRoundRectangle(brush, new Rectangle(left, top, width, height), cornerRadius, smooth);
        }

        public static void DrawRoundRectangle(this Graphics g, Color color, Rectangle rect, int cornerRadius, bool smooth = true)
        {
            using (GraphicsPath path = CreateRoundedRectanglePath(rect, cornerRadius))
            {
                g.DrawPath(color, path, smooth);
            }
        }

        public static void FillRoundRectangle(this Graphics g, Color color, Rectangle rect, int cornerRadius, bool smooth = true)
        {
            using (GraphicsPath path = CreateRoundedRectanglePath(rect, cornerRadius))
            {
                g.FillPath(color, path, smooth);
            }
        }

        public static void DrawRoundRectangle(this Graphics g, Color color, int left, int top, int width, int height, int cornerRadius, bool smooth = true)
        {
            g.DrawRoundRectangle(color, new Rectangle(left, top, width, height), cornerRadius, smooth);
        }

        public static void FillRoundRectangle(this Graphics g, Color color, int left, int top, int width, int height, int cornerRadius, bool smooth = true)
        {
            g.FillRoundRectangle(color, new Rectangle(left, top, width, height), cornerRadius, smooth);
        }

        public static GraphicsPath CreateRoundedRectanglePath(this Graphics g, Rectangle rect, int radius, UICornerRadiusSides radiusSides)
        {
            return rect.CreateRoundedRectanglePath(radius, radiusSides);
        }

        public static GraphicsPath CreateRoundedRectanglePath(this Graphics g, Rectangle rect, int radius, bool cornerLeftTop = true, bool cornerRightTop = true, bool cornerRightBottom = true, bool cornerLeftBottom = true)
        {
            return rect.CreateRoundedRectanglePath(radius, cornerLeftTop, cornerRightTop, cornerRightBottom, cornerLeftBottom);
        }

        public static GraphicsPath CreateRoundedRectanglePath(this Rectangle rect, int radius, UICornerRadiusSides radiusSides)
        {
            GraphicsPath path;

            if (radiusSides == UICornerRadiusSides.None || radius == 0)
            {
                Point[] points = new Point[] { new Point(0, 0), new Point(rect.Width, 0), new Point(rect.Width, rect.Height), new Point(0, rect.Height), new Point(0, 0), };
                path = points.Path();
            }
            else
            {
                //IsRadius为True时，显示左上圆角
                bool RadiusLeftTop = radiusSides.GetValue(UICornerRadiusSides.LeftTop);
                //IsRadius为True时，显示左下圆角
                bool RadiusLeftBottom = radiusSides.GetValue(UICornerRadiusSides.LeftBottom);
                //IsRadius为True时，显示右上圆角
                bool RadiusRightTop = radiusSides.GetValue(UICornerRadiusSides.RightTop);
                //IsRadius为True时，显示右下圆角
                bool RadiusRightBottom = radiusSides.GetValue(UICornerRadiusSides.RightBottom);
                path = rect.CreateRoundedRectanglePath(radius, RadiusLeftTop, RadiusRightTop, RadiusRightBottom, RadiusLeftBottom);
            }

            return path;
        }

        public static GraphicsPath CreateFanPath(this Graphics g, Point center, int d1, int d2, float startAngle, float sweepAngle)
        {
            return center.CreateFanPath(d1, d2, startAngle, sweepAngle);
        }

        public static GraphicsPath CreateFanPath(this Point center, int d1, int d2, float startAngle, float sweepAngle)
        {
            GraphicsPath path = new GraphicsPath();
            path.AddArc(center.X - d1, center.Y - d1, d1 * 2, d1 * 2, startAngle, sweepAngle);
            path.AddArc(center.X - d2, center.Y - d2, d2 * 2, d2 * 2, startAngle + sweepAngle, -sweepAngle);
            path.AddArc(center.X - d1, center.Y - d1, d1 * 2, d1 * 2, startAngle, 0.1f);
            return path;
        }

        public static void DrawCross(this Graphics g, Color color, Point center, int size = 3)
        {
            g.DrawLine(color, center.X - size, center.Y, center.X + size, center.Y);
            g.DrawLine(color, center.X, center.Y - size, center.X, center.Y + size);
        }

        public static void DrawFan(this Graphics g, Color color, Point center, int d1, int d2, float startAngle, float sweepAngle, bool smooth = true)
        {
            GraphicsPath path = g.CreateFanPath(center, d1, d2, startAngle, sweepAngle);
            g.DrawPath(color, path, smooth);
            path.Dispose();
        }

        public static void FillFan(this Graphics g, Color color, Point center, int d1, int d2, float startAngle, float sweepAngle, bool smooth = true)
        {
            GraphicsPath path = g.CreateFanPath(center, d1, d2, startAngle, sweepAngle);
            g.FillPath(color, path, smooth);
            path.Dispose();
        }

        public static GraphicsPath CreateRoundedRectanglePath(this Rectangle rect, int radius, bool cornerLeftTop = true, bool cornerRightTop = true, bool cornerRightBottom = true, bool cornerLeftBottom = true)
        {
            GraphicsPath path = new GraphicsPath();
            if (cornerLeftTop)
                path.AddArc(rect.X, rect.Y, radius, radius, 180, 90);
            else
                path.AddLine(new Point(rect.X, rect.Y + 1), new Point(rect.X, rect.Y));

            if (cornerRightTop)
                path.AddArc(rect.X + rect.Width - radius, rect.Y, radius, radius, 270, 90);
            else
                path.AddLine(new Point(rect.X + rect.Width - 1, rect.Y), new Point(rect.X + rect.Width, rect.Y));

            if (cornerRightBottom)
                path.AddArc(rect.X + rect.Width - radius, rect.Y + rect.Height - radius, radius, radius, 0, 90);
            else
                path.AddLine(new Point(rect.X + rect.Width, rect.Y + rect.Height), new Point(rect.X + rect.Width, rect.Y + rect.Height));

            if (cornerLeftBottom)
                path.AddArc(rect.X, rect.Bottom - radius, radius, radius, 90, 90);
            else
                path.AddLine(new Point(rect.X + 1, rect.Y + rect.Height), new Point(rect.X, rect.Y + rect.Height));

            path.CloseFigure();
            return path;
        }

        public static void DrawString(this Graphics g, string str, Font font, Color color, Size size, Padding padding, ContentAlignment align)
        {
            SizeF sf = g.MeasureString(str, font);
            using (Brush br = new SolidBrush(color))
            {
                switch (align)
                {
                    case ContentAlignment.MiddleCenter:
                        g.DrawString(str, font, br, padding.Left + (size.Width - sf.Width - padding.Left - padding.Right) / 2.0f,
                            padding.Top + (size.Height - sf.Height - padding.Top - padding.Bottom) / 2.0f);
                        break;

                    case ContentAlignment.TopLeft:
                        g.DrawString(str, font, br, padding.Left, padding.Top);
                        break;

                    case ContentAlignment.TopCenter:
                        g.DrawString(str, font, br, padding.Left + (size.Width - sf.Width - padding.Left - padding.Right) / 2.0f, padding.Top);
                        break;

                    case ContentAlignment.TopRight:
                        g.DrawString(str, font, br, size.Width - sf.Width - padding.Right, padding.Top);
                        break;

                    case ContentAlignment.MiddleLeft:
                        g.DrawString(str, font, br, padding.Left, padding.Top + (size.Height - sf.Height - padding.Top - padding.Bottom) / 2.0f);
                        break;

                    case ContentAlignment.MiddleRight:
                        g.DrawString(str, font, br, size.Width - sf.Width - padding.Right, padding.Top + (size.Height - sf.Height - padding.Top - padding.Bottom) / 2.0f);
                        break;

                    case ContentAlignment.BottomLeft:
                        g.DrawString(str, font, br, padding.Left, size.Height - sf.Height - padding.Bottom);
                        break;

                    case ContentAlignment.BottomCenter:
                        g.DrawString(str, font, br, padding.Left + (size.Width - sf.Width - padding.Left - padding.Right) / 2.0f, size.Height - sf.Height - padding.Bottom);
                        break;

                    case ContentAlignment.BottomRight:
                        g.DrawString(str, font, br, size.Width - sf.Width - padding.Right, size.Height - sf.Height - padding.Bottom);
                        break;
                }
            }
        }
    }
}
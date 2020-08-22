using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Drawing.Drawing2D;
using System.Windows.Forms;
using System.Drawing;
using SnakeEatBean.models;

namespace SnakeEatBean.library
{
    /// <summary>
    /// 地图操作相关
    /// </summary>
    public class MapHelper
    {
        /// <summary>
        /// 创建地图  create map
        /// </summary>
        /// <param name="rowCount"></param>
        /// <param name="colCount"></param>
        /// <param name="boxWidth"></param>
        /// <param name="boxHeight"></param>
        /// <param name="line"></param>
        /// <param name="box"></param>
        /// <returns></returns>
        public static ModelMap GenMap(int rowCount, int colCount, int boxWidth, int boxHeight, Color line, Color box)
        {
            var map = new ModelMap
            {
                Row = rowCount,
                Column = colCount,
                Box = new ModelBox
                {
                    Width = boxWidth,
                    Height = boxHeight
                },
                Line = line,
                Color = box,
                Body = new List<ModelElement>()
            };
            #region 初始化地图实体
            for (int ri = 0; ri < rowCount; ri++)
            {
                for (int ci = 0; ci < colCount; ci++)
                {
                    map.Body.Add(new ModelElement
                    {
                        Abscissa = ri,
                        Ordinate = ci
                    });
                }
            }
            #endregion

            return map;
        }

        /// <summary>
        /// 地图描边 
        /// </summary>
        /// <param name="panel"></param>
        /// <param name="map"></param>
        public static void DrawMap(Panel panel, ModelMap map)
        {
            #region 勾画地图
            var g = panel.CreateGraphics();
            #region 画横线
            for (int ri = 0; ri <= map.Row; ri++)
            {
                g.DrawLine(new Pen(Color.Black), 0, ri * map.Box.Height, map.Column * map.Box.Width, ri * map.Box.Height);
            }

            #endregion
            #region 画竖线
            for (int ci = 0; ci <= map.Column; ci++)
            {
                g.DrawLine(new Pen(Color.Black), ci * map.Box.Width, 0, ci * map.Box.Height, map.Row * map.Box.Width);
            }
            #endregion
            #region 勾画方块
            foreach (var b in map.Body)
            {
                DrawMapBox(panel, map.Color, b.Abscissa, b.Ordinate, map.Box.Width, map.Box.Height);
            }
            #endregion
            #endregion
        }

        /// <summary>
        /// 格子颜色填充 fill grid color 
        /// </summary>
        /// <param name="panel"></param>
        /// <param name="color"></param>
        /// <param name="x"></param>
        /// <param name="y"></param>
        /// <param name="width"></param>
        /// <param name="height"></param>
        public static void DrawMapBox(Panel panel, Color color, int x, int y, int width, int height)
        {
            var g = panel.CreateGraphics();
            g.FillRectangle(new HatchBrush(HatchStyle.Percent90, color), x * width + 1, y * height + 1, width - 1, height - 1);
        }
    }
}

    
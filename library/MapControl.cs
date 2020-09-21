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
        /// init snake entity, set default coordinate 
        /// </summary>
        /// <param name="speed"></param>
        /// <param name="color"></param>
        /// <returns></returns>
        public static ModelMapSnake GenSnake(int speed, Color color)
        {
            return new ModelMapSnake
            {
                Color = color,
                Speed = speed,
                Direction = ModelEnum.Direction.Down,
                Body = new List<ModelElement>
                        {
                            new ModelElement
                                {
                                    Abscissa = 0,
                                    Ordinate = 0
                                }
                        }
            };
        }

        /// <summary>
        /// 格子颜色填充 draw grid for map or snake body
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
            //g.FillRectangle(new HatchBrush(HatchStyle.Percent90, color), x * width + 1, y * height + 1, width - 1, height - 1);
            g.FillRectangle(new SolidBrush(color), x * width + 1, y * height + 1, width - 1, height - 1);
        }

        /// <summary>
        /// using a grid (two groups of coordinate) represents a body of snake
        /// </summary>
        /// <param name="map"></param>
        /// <param name="snake"></param>
        /// <returns></returns>
        public static ModelMapSnake GenSnakeOnMap(ModelMap map, ModelMapSnake snake)  
        {
            var sk = snake;
            var centerX = map.Row / 2;
            var centerY = map.Column / 2;
            sk.Body = new List<ModelElement>
                {
                    new ModelElement
                        {
                            Abscissa = centerX,
                            Ordinate = centerY
                        },
                    new ModelElement
                        {
                            Abscissa = centerX,
                            Ordinate = centerY - 1
                        }
                };
            return sk;
        }

        /// <summary>
        /// 蛇身在移动图上移动  moving snake
        /// </summary>
        /// <param name="panel"></param>
        /// <param name="map"></param>
        /// <param name="snake"></param>
        /// <param name="direction"></param>
        /// <param name="enableBack"></param>
        /// <param name="dead"></param>
        /// <returns></returns>
        public static ModelMapSnake MoveSnakeOnMap(Panel panel, ModelMap map, ModelMapSnake snake, ModelEnum.Direction direction )
        {
        
         
             if (direction.Equals(ModelEnum.Direction.Up) && snake.Direction.Equals(ModelEnum.Direction.Down))
                    direction = snake.Direction;
             else if (direction.Equals(ModelEnum.Direction.Down) && snake.Direction.Equals(ModelEnum.Direction.Up))
                    direction = snake.Direction;
             else if (direction.Equals(ModelEnum.Direction.Left) && snake.Direction.Equals(ModelEnum.Direction.Right))
                    direction = snake.Direction;
             else if (direction.Equals(ModelEnum.Direction.Right) && snake.Direction.Equals(ModelEnum.Direction.Left))
                    direction = snake.Direction;
            

            var head = new ModelElement
            {
                Abscissa = snake.Body[0].Abscissa,
                Ordinate = snake.Body[0].Ordinate
            };
            switch (direction)
            {
                case ModelEnum.Direction.Left:
                    head.Abscissa--;
                    break;
                case ModelEnum.Direction.Right:
                    head.Abscissa++;
                    break;
                case ModelEnum.Direction.Up:
                    head.Ordinate--;
                    break;
                case ModelEnum.Direction.Down:
                    head.Ordinate++;
                    break;
            }
            if (head.Abscissa < 0) head.Abscissa = map.Column - 1;
            else if (head.Abscissa == map.Column) head.Abscissa = 0;
            if (head.Ordinate < 0) head.Ordinate = map.Row - 1;
            else if (head.Ordinate == map.Row) head.Ordinate = 0;

                   

            var tail = snake.Body[snake.Body.Count - 1];
            var m = map.Body.SingleOrDefault(t => t.Bean && t.Abscissa == tail.Abscissa && t.Ordinate == tail.Ordinate);
            if (m == null)
            {
                DrawMapBox(panel, map.Color, tail.Abscissa, tail.Ordinate, map.Box.Width, map.Box.Height);
                snake.Body.Remove(tail);
            }
            else
            {
                DrawMapBox(panel, snake.Color, head.Abscissa, head.Ordinate, map.Box.Width, map.Box.Height);
                m.Bean = false;
            }

            DrawMapBox(panel, snake.Color, head.Abscissa, head.Ordinate, map.Box.Width, map.Box.Height);
            snake.Body.Insert(0, head);
            snake.Direction = direction;

            return snake;
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="panel"></param>
        /// <param name="map"></param>
        /// <param name="snake"></param>
        /// <returns></returns>
        public static ModelMapSnake DrawSnakeOnMap(Panel panel, ModelMap map, ModelMapSnake snake)
        {
            snake = GenSnakeOnMap(map, snake);
            foreach (var b in snake.Body)
            {
                DrawMapBox(panel, snake.Color, b.Abscissa, b.Ordinate, map.Box.Width, map.Box.Height);
            }
            return snake;
        }

        public static ModelElement NewBonus(int x, int y)
        {
            var rm = new Random();
            var bonus = new ModelElement
            {
                Abscissa = rm.Next(0, x),
                Ordinate = rm.Next(0, y),
                Bean = true
            };
            return bonus;
        }
        public static ModelMap ShowBonus(Panel panel, ModelMap map, ModelMapSnake snake, Color color)
        {
            var b = NewBonus(map.Row - 1, map.Column - 1);
            while (snake.Body.Count(s => s.Equals(b)) > 0)
            {
                b = NewBonus(map.Row - 1, map.Column - 1);
            }
            var m = map.Body.SingleOrDefault(t => t.Abscissa == b.Abscissa && t.Ordinate == b.Ordinate);
            if (m != null)
            {
                DrawMapBox(panel, color, m.Abscissa, m.Ordinate, map.Box.Width, map.Box.Height);
                m.Bean = true;
            }
            return map;
        }

        public static ModelMap HideBonus(Panel panel, ModelMap map)
        {
            var ms = map.Body.Where(t => t.Bean);
            foreach (var m in ms)
            {
                DrawMapBox(panel, map.Color, m.Abscissa, m.Ordinate, map.Box.Width, map.Box.Height);
                m.Bean = false;
            }
            return map;
        }
    }

   
}

    
using System.Collections.Generic;
using System.Drawing;
using MongoDB.Bson;
using MongoDB.Driver;
using MongoDB.Driver.Core;


namespace SnakeEatBean.models
{
    /// <summary>
    /// 格子实体  grid model
    /// </summary>
    public class ModelElement
    {
        /// <summary>
        /// 横坐标
        /// </summary>
        public int Abscissa { get; set; }
        /// <summary>
        /// 纵坐标
        /// </summary>
        public int Ordinate { get; set; }
        /// <summary>
        /// 初始化格子
        /// </summary>
        public ModelElement()
        {
            Abscissa = 0;
            Ordinate = 0; 
        }

        /// 奖励属性
        /// </summary>
        public bool Bean { get; set; }
    }

    /// <summary>
    /// 地图格子大小属性实体  map grid size model
    /// </summary>
    public class ModelBox
    {
        /// <summary>
        /// 格子宽度
        /// </summary>
        public int Width { get; set; }
        /// <summary>
        /// 格子高度
        /// </summary>
        public int Height { get; set; }
    }

    /// <summary>
    /// 地图视图
    /// </summary>
    public class ModelMap
    {
        /// <summary>
        /// 行数
        /// </summary>
        public int Row { get; set; }
        /// <summary>
        /// 列数
        /// </summary>
        public int Column { get; set; }
        /// <summary>
        /// 棋盘纹路颜色
        /// </summary>
        public Color Line { get; set; }
        /// <summary>
        /// 棋盘格子颜色
        /// </summary>
        public Color Color { get; set; }
        /// <summary>
        /// 棋盘格子大小
        /// </summary>
        public ModelBox Box { get; set; }
        /// <summary>
        /// 棋盘格子实体集合
        /// </summary>
        public List<ModelElement> Body { get; set; }
    }
    /// <summary>
    /// 运动方向   move direction 
    /// </summary>
    public class ModelEnum
    {
        public enum Direction
        {
            Up = 0,
            Left = 1,
            Down = 2,
            Right = 3
        }
    }
    /// <summary>
    /// 蛇身实体  snake body model
    /// </summary>
    public class ModelMapSnake
    {
        /// <summary>
        /// 移动速度  moving speed
        /// </summary>
        public int Speed { get; set; }
        /// <summary>
        /// 蛇身颜色  snake body color
        /// </summary>
        public Color Color { get; set; }
        /// <summary>
        /// 运动方向  moving direction
        /// </summary>
        public ModelEnum.Direction Direction { get; set; }
        /// <summary>
        /// 蛇身格子实体结合 
        /// </summary>
        public List<ModelElement> Body { get; set; }
    }
    /// <summary>
    /// 初始化参数  initial parameters ,configuration class 
    /// </summary>
    public class ConfigHelper
    {
        public static int RowCount = 16;
        public static int ColCount = 16;
        public static int BoxWidth = 25;
        public static int BoxHeight = 25;

        public static int Speed = 400;
        public static int radius = 20; //Bean's radius 
        public static Color SnakeColor = Color.DarkBlue;
        public static Color MapColor = Color.LightBlue;
        public static Color LineColor = Color.LightBlue;
        public static int SnakeClimbNum = 0;
        public static bool b_debug = false;
        public static Color BeanColor= Color.Brown;
        public const int BeanShowTime = 20;
        public static string player_nickname = "no name";
        public static int lengthSnake = 2;
        public static int i_playtime = 0;


        public static string __connectString = "mongodb://127.0.0.1:27017";
        public static string __dbName = "snake";
        public static IMongoClient __client;
        public static IMongoDatabase __database;
        public static IMongoCollection<BsonDocument> __collection;
        public static bool __connectSuccess = true;



    }
}

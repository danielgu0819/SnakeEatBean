using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using SnakeEatBean.models;
using SnakeEatBean.library;
using Microsoft.VisualBasic;
using MongoDB.Bson;
using MongoDB.Driver;
using MongoDB.Driver.Core;

namespace SnakeEatBean
{
    public partial class MainForm : Form
    {
        private ModelMap _map;
        private ModelMapSnake _snake;
        private ModelEnum.Direction _direction;
        private bool b_initMap = false;
        private bool b_initSnake = false;
        private bool b_startMove = false;
        private int corSwitch = 0;

        protected static IMongoClient __client;
        protected static IMongoDatabase __database;
        private static List<BsonDocument> __dataset;

        public MainForm()
        {
            InitializeComponent();
        }

        private void MainForm_Load(object sender, EventArgs e)
        {
            this.FormClosing += new FormClosingEventHandler(MainForm_Closing);
             
          
            //connect database
             MongoHelper.connMongoDatabase();
             

            if (ConfigHelper.__connectSuccess)
            {
                //query records,形成字串
                string textShow = MongoHelper.queryMongo();
                //展示在textbox上
                textBox1.AppendText(textShow);
            }
            else
            {
                textBox1.Hide();
                label2.Hide();
            }

            return;
        }

        private void MainForm_Closing(object sender, CancelEventArgs e)
        {
            if (ConfigHelper.player_nickname != "no name" && ConfigHelper.player_nickname != ""&& ConfigHelper.player_nickname != "input your nickname")
            {
                MessageBox.Show("see you later，guy！", ConfigHelper.player_nickname);

                MongoHelper.insertMongo(ConfigHelper.player_nickname, ConfigHelper.lengthSnake.ToString() );

            }
            else
            {
                MessageBox.Show("see you later！", ConfigHelper.player_nickname);
            }
                
        }

        private void BtnIniMap_Click_1(object sender, EventArgs e)
        {
            if (ConfigHelper.b_debug)
                MessageBox.Show("Map");

            if(corSwitch == 1)
            {
                ConfigHelper.MapColor = Color.LightGreen;
                corSwitch = 0;
            }else
            {
                ConfigHelper.MapColor = Color.LightBlue;
                corSwitch = 1;
            }

            _map = MapHelper.GenMap(ConfigHelper.RowCount, ConfigHelper.ColCount, ConfigHelper.BoxWidth, ConfigHelper.BoxHeight, ConfigHelper.LineColor, ConfigHelper.MapColor);
            MapHelper.DrawMap(palMap, _map);
            b_initMap = true;
        }

        private void BtnIniSnake_Click_1(object sender, EventArgs e)
        {
            if (ConfigHelper.b_debug)
                MessageBox.Show("snake");

            if (b_initSnake&&b_startMove)
                return;

            if (!b_initMap)
            {
                MessageBox.Show("There is no Map, Please click initMap firstly");
                return;
            }
            b_initSnake = true;

   
            _snake = MapHelper.GenSnake(ConfigHelper.Speed, ConfigHelper.SnakeColor);  
            _snake = MapHelper.DrawSnakeOnMap(palMap, _map, _snake);
            _direction = _snake.Direction;
             
        }

        /// <summary>
        /// using time class to move snake
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void BtnStartMove_Click_1(object sender, EventArgs e)
        {
            if (ConfigHelper.b_debug)
                MessageBox.Show("move");

            if(ConfigHelper.__connectSuccess)
                ConfigHelper.player_nickname = Interaction.InputBox("Hello guy, do you want a contest?", "Who is the winner", "input your nickname", -1, -1);
            


            if (!b_initSnake)
            {
                MessageBox.Show("There is no Snake, Please click initSnake firstly");
                
                return;
            }
            b_startMove = true;

            tmControl.Interval = _snake.Speed;

            tmControl.Start();

        }

        private void TmControl_Tick(object sender, EventArgs e)
        {
            tmControl.Stop();
            tmControl.Interval = _snake.Speed;

            _snake = MapHelper.MoveSnakeOnMap(palMap, _map, _snake, _direction );

            if (ConfigHelper.SnakeClimbNum == 0)
                _map = MapHelper.ShowBonus(palMap, _map, _snake, ConfigHelper.BeanColor);
            else if (ConfigHelper.SnakeClimbNum == ConfigHelper.BeanShowTime)
            {
                _map = MapHelper.HideBonus(palMap, _map);
                ConfigHelper.SnakeClimbNum = -1;
            }

            ConfigHelper.SnakeClimbNum++;

            ConfigHelper.i_playtime++;
            if (ConfigHelper.i_playtime  == 500)
            {
                MessageBox.Show("Hi,young man, too long you have played !");
                ConfigHelper.i_playtime = 0;
            }
                                
            

            tmControl.Start();
        }


     

        protected override bool ProcessCmdKey(ref Message msg, Keys keyData)
        {
            if (ConfigHelper.b_debug)
                MessageBox.Show("ProcessCmdKey is processing ");

            if (keyData == (Keys.Up | Keys.Shift)) //增速 increase moving speed
            {
                if (_snake.Speed > 50)
                    _snake.Speed -= 50;
            }
            else if(keyData == (Keys.Down | Keys.Shift))
            {
                _snake.Speed += 50; 
            }

            if (keyData == Keys.Left)
            {
                _direction = ModelEnum.Direction.Left;
            }
            else if(keyData == Keys.Right)
            {
                _direction = ModelEnum.Direction.Right;
            }
            else if(keyData == Keys.Up)
            {
                _direction = ModelEnum.Direction.Up;
            }
            else if(keyData == Keys.Down)
            {
                _direction = ModelEnum.Direction.Down;
            }
       
            return base.ProcessCmdKey(ref msg, keyData);
        }

       
    }
}

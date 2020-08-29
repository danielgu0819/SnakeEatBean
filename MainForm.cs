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

namespace SnakeEatBean
{
    public partial class MainForm : Form
    {
        private ModelMap _map;
        private ModelMapSnake _snake;
        private ModelEnum.Direction _direction;
        private bool b_initMap = false;
        private bool b_initSnake = false;
       

        public MainForm()
        {
            InitializeComponent();
        }

        private void MainForm_Load(object sender, EventArgs e)
        {
            return;
        }
         
        private void BtnIniMap_Click_1(object sender, EventArgs e)
        {
            if (ConfigHelper.b_debug)
                MessageBox.Show("Map");
            _map = MapHelper.GenMap(ConfigHelper.RowCount, ConfigHelper.ColCount, ConfigHelper.BoxWidth, ConfigHelper.BoxHeight, ConfigHelper.LineColor, ConfigHelper.MapColor);
            MapHelper.DrawMap(palMap, _map);
            b_initMap = true;
        }

        private void BtnIniSnake_Click_1(object sender, EventArgs e)
        {
            if (ConfigHelper.b_debug)
                MessageBox.Show("snake");

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

        private void BtnStartMove_Click_1(object sender, EventArgs e)
        {
            if (ConfigHelper.b_debug)
                MessageBox.Show("move");

            if (!b_initSnake)
            {
                MessageBox.Show("There is no Snake, Please click initSnake firstly");
                return;
            }

        }

        protected override bool ProcessCmdKey(ref Message msg, Keys keyData)
        {

            if(keyData == Keys.Left)
            {
                MessageBox.Show("There is Left ");
            }
            else if(keyData == Keys.Right)
            {
                MessageBox.Show("There is Right ");
            }else if(keyData == Keys.Up)
            {
                MessageBox.Show("There is Up ");
            }else if(keyData == Keys.Down)
            {
                MessageBox.Show("There is Down ");
            }
            else
            {
                MessageBox.Show("There is others");
            }

            return base.ProcessCmdKey(ref msg, keyData);
        }


    }
}

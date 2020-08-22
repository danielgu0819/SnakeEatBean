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
            MessageBox.Show("Map");
            _map = MapHelper.GenMap(ConfigHelper.RowCount, ConfigHelper.ColCount, ConfigHelper.BoxWidth, ConfigHelper.BoxHeight, ConfigHelper.LineColor, ConfigHelper.MapColor);
            MapHelper.DrawMap(palMap, _map);
        }

        private void BtnIniSnake_Click_1(object sender, EventArgs e)
        {
            MessageBox.Show("snake");

        }

        private void BtnStartMove_Click_1(object sender, EventArgs e)
        {
            MessageBox.Show("move");
        }
    }
}

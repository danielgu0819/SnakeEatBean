﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace SnakeEatBean
{
    static class Program
    {
        /// <summary>
        /// 应用程序的主入口点。
        /// </summary>
        [STAThread]
        static void Main()
        {
            /*int i_playtime = 0;
            Application.Idle += delegate
            {                
                if(i_playtime == 10)
                {
                    MessageBox.Show("Too long you have played this game!");                   
                }
                i_playtime++;
            }*/

            Application.EnableVisualStyles();
            Application.SetCompatibleTextRenderingDefault(false);
            Application.Run(new MainForm());
        }
    }
}
using System;
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

             /*               
            Application.Idle += Application_Idle;
            void Application_Idle(object sender, EventArgs e)
            {
                if (i_playtime == 1000)
                {
                    MessageBox.Show("Hi,young man, too long you have played !");
                    i_playtime = 0;
                }
                i_playtime++;               
            }*/

            Application.EnableVisualStyles();
            Application.SetCompatibleTextRenderingDefault(false);
            //Application.ApplicationExit += new EventHandler(Application_ApplicationExit);
            //AppDomain.CurrentDomain.ProcessExit += new EventHandler(CurrentDomain_ProcessExit);

            Application.Run(new MainForm());




        }
    }
}

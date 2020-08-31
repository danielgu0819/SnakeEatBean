namespace SnakeEatBean
{
    partial class MainForm
    {
        /// <summary>
        /// 必需的设计器变量。
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// 清理所有正在使用的资源。
        /// </summary>
        /// <param name="disposing">如果应释放托管资源，为 true；否则为 false。</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows 窗体设计器生成的代码

        /// <summary>
        /// 设计器支持所需的方法 - 不要修改
        /// 使用代码编辑器修改此方法的内容。
        /// </summary>
        private void InitializeComponent()
        {
            this.palMap = new System.Windows.Forms.Panel();
            this.btnIniMap = new System.Windows.Forms.Button();
            this.btnIniSnake = new System.Windows.Forms.Button();
            this.btnStartMove = new System.Windows.Forms.Button();
            this.components = new System.ComponentModel.Container();
            this.tmControl = new System.Windows.Forms.Timer(this.components);
            this.SuspendLayout();

            // 
            // palMap
            // 
            this.palMap.Dock = System.Windows.Forms.DockStyle.Left;
            this.palMap.Location = new System.Drawing.Point(0, 0);
            this.palMap.Name = "palMap";
            this.palMap.Size = new System.Drawing.Size(400, 450);
            this.palMap.TabIndex = 0;
            // 
            // btnIniMap
            // 
            this.btnIniMap.Location = new System.Drawing.Point(430, 12);
            this.btnIniMap.Name = "btnIniMap";
            this.btnIniMap.Size = new System.Drawing.Size(95, 23);
            this.btnIniMap.TabIndex = 1;
            this.btnIniMap.Text = "InitTheMap";
            this.btnIniMap.UseVisualStyleBackColor = true;
            this.btnIniMap.Click += new System.EventHandler(this.BtnIniMap_Click_1);
            // 
            // btnIniSnake
            // 
            this.btnIniSnake.Location = new System.Drawing.Point(430, 41);
            this.btnIniSnake.Name = "btnIniSnake";
            this.btnIniSnake.Size = new System.Drawing.Size(95, 23);
            this.btnIniSnake.TabIndex = 2;
            this.btnIniSnake.Text = "InitTheSnake";
            this.btnIniSnake.UseVisualStyleBackColor = true;
            this.btnIniSnake.Click += new System.EventHandler(this.BtnIniSnake_Click_1);
            // 
            // btnStartMove
            // 
            this.btnStartMove.Location = new System.Drawing.Point(430, 70);
            this.btnStartMove.Name = "btnStartMove";
            this.btnStartMove.Size = new System.Drawing.Size(95, 23);
            this.btnStartMove.TabIndex = 3;
            this.btnStartMove.Text = "PlayTheGame";
            this.btnStartMove.UseVisualStyleBackColor = true;
            this.btnStartMove.Click += new System.EventHandler(this.BtnStartMove_Click_1);

            //
            //tmControl , using time class 
            //
            this.tmControl.Interval = 1000;
            this.tmControl.Tick += new System.EventHandler(this.TmControl_Tick);

            // 
            // MainForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 12F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(600, 450);
            this.Controls.Add(this.btnStartMove);
            this.Controls.Add(this.btnIniSnake);
            this.Controls.Add(this.btnIniMap);
            this.Controls.Add(this.palMap);
            this.KeyPreview = true;
            this.Name = "MainForm";
            this.Text = "SankeEatBean";
            this.Load += new System.EventHandler(this.MainForm_Load);
            this.ResumeLayout(false);

        }

        #endregion
        private System.Windows.Forms.Panel palMap;
        private System.Windows.Forms.Button btnIniMap;
        private System.Windows.Forms.Button btnIniSnake;
        private System.Windows.Forms.Button btnStartMove;
        private System.Windows.Forms.Timer tmControl;
    }
}


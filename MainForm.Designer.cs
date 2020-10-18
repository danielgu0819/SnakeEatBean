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
            this.components = new System.ComponentModel.Container();
            this.palMap = new System.Windows.Forms.Panel();
            this.btnIniMap = new System.Windows.Forms.Button();
            this.btnIniSnake = new System.Windows.Forms.Button();
            this.btnStartMove = new System.Windows.Forms.Button();
            this.tmControl = new System.Windows.Forms.Timer(this.components);
            this.splitter1 = new System.Windows.Forms.Splitter();
            this.textBox1 = new System.Windows.Forms.TextBox();
            this.label1 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
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
            // tmControl
            // 
            this.tmControl.Interval = 1000;
            this.tmControl.Tick += new System.EventHandler(this.TmControl_Tick);
            // 
            // splitter1
            // 
            this.splitter1.Location = new System.Drawing.Point(400, 0);
            this.splitter1.Name = "splitter1";
            this.splitter1.Size = new System.Drawing.Size(3, 450);
            this.splitter1.TabIndex = 4;
            this.splitter1.TabStop = false;
            // 
            // textBox1
            // 
            this.textBox1.Location = new System.Drawing.Point(430, 182);
            this.textBox1.Multiline = true;
            this.textBox1.Name = "textBox1";
            this.textBox1.ScrollBars = System.Windows.Forms.ScrollBars.Both;
            this.textBox1.Size = new System.Drawing.Size(158, 153);
            this.textBox1.TabIndex = 5;
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(430, 167);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(0, 12);
            this.label1.TabIndex = 6;
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(430, 157);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(65, 12);
            this.label2.TabIndex = 7;
            this.label2.Text = "Records ：";
            // 
            // MainForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 12F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(600, 450);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.textBox1);
            this.Controls.Add(this.splitter1);
            this.Controls.Add(this.btnStartMove);
            this.Controls.Add(this.btnIniSnake);
            this.Controls.Add(this.btnIniMap);
            this.Controls.Add(this.palMap);
            this.KeyPreview = true;
            this.Name = "MainForm";
            this.Text = "SankeEatBean";
            this.Load += new System.EventHandler(this.MainForm_Load);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion
        private System.Windows.Forms.Panel palMap;
        private System.Windows.Forms.Button btnIniMap;
        private System.Windows.Forms.Button btnIniSnake;
        private System.Windows.Forms.Button btnStartMove;
        private System.Windows.Forms.Timer tmControl; 
        public static int SnakeClimbNum = 0;
        private System.Windows.Forms.Splitter splitter1;
        public System.Windows.Forms.TextBox textBox1;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label label2;
    }
}


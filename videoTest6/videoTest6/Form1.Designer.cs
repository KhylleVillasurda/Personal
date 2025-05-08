namespace videoTest6
{
    partial class Form1
    {
        /// <summary>
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code

        /// <summary>
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            this.components = new System.ComponentModel.Container();
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(Form1));
            this.pnlGanttChart = new System.Windows.Forms.Panel();
            this.rtbOutput = new System.Windows.Forms.RichTextBox();
            this.btnAddProcess = new System.Windows.Forms.Button();
            this.btnCalculate = new System.Windows.Forms.Button();
            this.dgvProcesses = new System.Windows.Forms.DataGridView();
            this.timerGif = new System.Windows.Forms.Timer(this.components);
            this.minecraftLoad = new System.Windows.Forms.PictureBox();
            this.panel1 = new System.Windows.Forms.Panel();
            this.nextBtn = new System.Windows.Forms.Button();
            this.panel2 = new System.Windows.Forms.Panel();
            this.pictureBox1 = new System.Windows.Forms.PictureBox();
            this.secretLabel = new System.Windows.Forms.Label();
            this.picBoxExit = new System.Windows.Forms.PictureBox();
            this.playpauseHere = new System.Windows.Forms.Button();
            this.richTextBox1 = new System.Windows.Forms.RichTextBox();
            this.toolTip1 = new System.Windows.Forms.ToolTip(this.components);
            ((System.ComponentModel.ISupportInitialize)(this.dgvProcesses)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.minecraftLoad)).BeginInit();
            this.panel2.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.picBoxExit)).BeginInit();
            this.SuspendLayout();
            // 
            // pnlGanttChart
            // 
            this.pnlGanttChart.AllowDrop = true;
            this.pnlGanttChart.AutoScroll = true;
            this.pnlGanttChart.BackColor = System.Drawing.Color.Transparent;
            this.pnlGanttChart.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Center;
            this.pnlGanttChart.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D;
            this.pnlGanttChart.Font = new System.Drawing.Font("Minecraftia", 10.8F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.pnlGanttChart.ForeColor = System.Drawing.Color.White;
            this.pnlGanttChart.Location = new System.Drawing.Point(496, 379);
            this.pnlGanttChart.Name = "pnlGanttChart";
            this.pnlGanttChart.Size = new System.Drawing.Size(786, 103);
            this.pnlGanttChart.TabIndex = 0;
            this.toolTip1.SetToolTip(this.pnlGanttChart, "Gantt Chart Area");
            this.pnlGanttChart.Paint += new System.Windows.Forms.PaintEventHandler(this.pnlGanttChart_Paint);
            // 
            // rtbOutput
            // 
            this.rtbOutput.BackColor = System.Drawing.SystemColors.InactiveBorder;
            this.rtbOutput.Font = new System.Drawing.Font("Minecraftia", 7.8F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.rtbOutput.Location = new System.Drawing.Point(496, 234);
            this.rtbOutput.Name = "rtbOutput";
            this.rtbOutput.Size = new System.Drawing.Size(787, 139);
            this.rtbOutput.TabIndex = 1;
            this.rtbOutput.Text = "";
            this.rtbOutput.TextChanged += new System.EventHandler(this.rtbOutput_TextChanged);
            // 
            // btnAddProcess
            // 
            this.btnAddProcess.BackgroundImage = global::videoTest6.Properties.Resources.btn;
            this.btnAddProcess.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnAddProcess.Font = new System.Drawing.Font("Minecraftia", 7.8F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnAddProcess.Location = new System.Drawing.Point(12, 383);
            this.btnAddProcess.Name = "btnAddProcess";
            this.btnAddProcess.Size = new System.Drawing.Size(236, 43);
            this.btnAddProcess.TabIndex = 2;
            this.btnAddProcess.Text = "Add Process";
            this.toolTip1.SetToolTip(this.btnAddProcess, "Adds a process, althought its automatic");
            this.btnAddProcess.UseVisualStyleBackColor = true;
            this.btnAddProcess.Click += new System.EventHandler(this.btnAddProcess_Click);
            // 
            // btnCalculate
            // 
            this.btnCalculate.BackgroundImage = global::videoTest6.Properties.Resources.btn;
            this.btnCalculate.BackgroundImageLayout = System.Windows.Forms.ImageLayout.None;
            this.btnCalculate.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnCalculate.Font = new System.Drawing.Font("Minecraftia", 7.8F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnCalculate.Location = new System.Drawing.Point(254, 383);
            this.btnCalculate.Name = "btnCalculate";
            this.btnCalculate.Size = new System.Drawing.Size(236, 43);
            this.btnCalculate.TabIndex = 3;
            this.btnCalculate.Text = "Calculate";
            this.toolTip1.SetToolTip(this.btnCalculate, "Main Function");
            this.btnCalculate.UseVisualStyleBackColor = true;
            this.btnCalculate.Click += new System.EventHandler(this.btnCalculate_Click);
            // 
            // dgvProcesses
            // 
            this.dgvProcesses.BackgroundColor = System.Drawing.SystemColors.WindowFrame;
            this.dgvProcesses.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dgvProcesses.Location = new System.Drawing.Point(12, 46);
            this.dgvProcesses.Name = "dgvProcesses";
            this.dgvProcesses.RowHeadersWidth = 51;
            this.dgvProcesses.RowTemplate.Height = 24;
            this.dgvProcesses.Size = new System.Drawing.Size(477, 332);
            this.dgvProcesses.TabIndex = 4;
            this.dgvProcesses.CellContentClick += new System.Windows.Forms.DataGridViewCellEventHandler(this.dgvProcesses_CellContentClick);
            // 
            // minecraftLoad
            // 
            this.minecraftLoad.Image = global::videoTest6.Properties.Resources.minecraftLoading;
            this.minecraftLoad.Location = new System.Drawing.Point(12, 44);
            this.minecraftLoad.Name = "minecraftLoad";
            this.minecraftLoad.Size = new System.Drawing.Size(477, 332);
            this.minecraftLoad.TabIndex = 5;
            this.minecraftLoad.TabStop = false;
            this.toolTip1.SetToolTip(this.minecraftLoad, "Please Wait");
            this.minecraftLoad.Click += new System.EventHandler(this.minecraftLoad_Click);
            // 
            // panel1
            // 
            this.panel1.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D;
            this.panel1.Font = new System.Drawing.Font("Minecraftia", 7.8F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.panel1.Location = new System.Drawing.Point(789, 45);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(493, 183);
            this.panel1.TabIndex = 7;
            this.panel1.Paint += new System.Windows.Forms.PaintEventHandler(this.panel1_Paint);
            // 
            // nextBtn
            // 
            this.nextBtn.BackColor = System.Drawing.Color.Transparent;
            this.nextBtn.BackgroundImage = global::videoTest6.Properties.Resources.btn;
            this.nextBtn.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.nextBtn.Font = new System.Drawing.Font("Minecraftia", 7.8F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.nextBtn.Location = new System.Drawing.Point(12, 439);
            this.nextBtn.Name = "nextBtn";
            this.nextBtn.Size = new System.Drawing.Size(236, 43);
            this.nextBtn.TabIndex = 9;
            this.nextBtn.Text = "Next";
            this.toolTip1.SetToolTip(this.nextBtn, "Proceed to the next video");
            this.nextBtn.UseVisualStyleBackColor = false;
            this.nextBtn.Visible = false;
            this.nextBtn.Click += new System.EventHandler(this.nextBtn_Click);
            // 
            // panel2
            // 
            this.panel2.BackgroundImage = ((System.Drawing.Image)(resources.GetObject("panel2.BackgroundImage")));
            this.panel2.Controls.Add(this.pictureBox1);
            this.panel2.Controls.Add(this.secretLabel);
            this.panel2.Controls.Add(this.picBoxExit);
            this.panel2.Dock = System.Windows.Forms.DockStyle.Top;
            this.panel2.Location = new System.Drawing.Point(0, 0);
            this.panel2.Name = "panel2";
            this.panel2.Size = new System.Drawing.Size(1298, 39);
            this.panel2.TabIndex = 10;
            this.panel2.Paint += new System.Windows.Forms.PaintEventHandler(this.panel2_Paint);
            this.panel2.MouseDown += new System.Windows.Forms.MouseEventHandler(this.panel2_MouseDown);
            this.panel2.MouseMove += new System.Windows.Forms.MouseEventHandler(this.panel2_MouseMove);
            this.panel2.MouseUp += new System.Windows.Forms.MouseEventHandler(this.panel2_MouseUp);
            // 
            // pictureBox1
            // 
            this.pictureBox1.BackColor = System.Drawing.Color.Transparent;
            this.pictureBox1.BackgroundImage = global::videoTest6.Properties.Resources.icon3;
            this.pictureBox1.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Center;
            this.pictureBox1.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.pictureBox1.Location = new System.Drawing.Point(3, 3);
            this.pictureBox1.Name = "pictureBox1";
            this.pictureBox1.Size = new System.Drawing.Size(37, 31);
            this.pictureBox1.TabIndex = 2;
            this.pictureBox1.TabStop = false;
            this.pictureBox1.Click += new System.EventHandler(this.pictureBox1_Click);
            // 
            // secretLabel
            // 
            this.secretLabel.AutoSize = true;
            this.secretLabel.BackColor = System.Drawing.Color.Transparent;
            this.secretLabel.Font = new System.Drawing.Font("Minecraftia", 13.8F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.secretLabel.ForeColor = System.Drawing.Color.Aqua;
            this.secretLabel.Location = new System.Drawing.Point(72, 3);
            this.secretLabel.Name = "secretLabel";
            this.secretLabel.Size = new System.Drawing.Size(466, 40);
            this.secretLabel.TabIndex = 1;
            this.secretLabel.Text = "BlockScheduler(FCFS Algorithm)";
            this.toolTip1.SetToolTip(this.secretLabel, "First Come First Serve Algorithm");
            this.secretLabel.Click += new System.EventHandler(this.secretLabel_Click);
            // 
            // picBoxExit
            // 
            this.picBoxExit.BackColor = System.Drawing.Color.Transparent;
            this.picBoxExit.BackgroundImageLayout = System.Windows.Forms.ImageLayout.None;
            this.picBoxExit.Image = global::videoTest6.Properties.Resources.exitImage;
            this.picBoxExit.Location = new System.Drawing.Point(1266, 5);
            this.picBoxExit.Name = "picBoxExit";
            this.picBoxExit.Size = new System.Drawing.Size(29, 29);
            this.picBoxExit.SizeMode = System.Windows.Forms.PictureBoxSizeMode.StretchImage;
            this.picBoxExit.TabIndex = 0;
            this.picBoxExit.TabStop = false;
            this.picBoxExit.Click += new System.EventHandler(this.picBoxExit_Click);
            this.picBoxExit.Paint += new System.Windows.Forms.PaintEventHandler(this.pictureBox1_Paint);
            // 
            // playpauseHere
            // 
            this.playpauseHere.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(107)))), ((int)(((byte)(107)))), ((int)(((byte)(107)))));
            this.playpauseHere.BackgroundImage = global::videoTest6.Properties.Resources.btn;
            this.playpauseHere.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.playpauseHere.Font = new System.Drawing.Font("Minecraftia", 7.8F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.playpauseHere.Location = new System.Drawing.Point(254, 439);
            this.playpauseHere.Name = "playpauseHere";
            this.playpauseHere.Size = new System.Drawing.Size(236, 43);
            this.playpauseHere.TabIndex = 11;
            this.playpauseHere.Text = "Play/Pause";
            this.toolTip1.SetToolTip(this.playpauseHere, "Toggle Play Or Pause");
            this.playpauseHere.UseVisualStyleBackColor = false;
            this.playpauseHere.Visible = false;
            this.playpauseHere.Click += new System.EventHandler(this.playpauseHere_Click);
            // 
            // richTextBox1
            // 
            this.richTextBox1.Font = new System.Drawing.Font("Minecraftia", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.richTextBox1.Location = new System.Drawing.Point(495, 45);
            this.richTextBox1.Name = "richTextBox1";
            this.richTextBox1.Size = new System.Drawing.Size(288, 183);
            this.richTextBox1.TabIndex = 12;
            this.richTextBox1.Text = "Index:\nAT : Arrival Time\nBT : Burst Time or CPU Time                  \nCT:  Compl" +
    "etion Time\nTAT : Turn Around Time\nWT : Waiting Time\n";
            this.richTextBox1.TextChanged += new System.EventHandler(this.richTextBox1_TextChanged);
            // 
            // Form1
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackgroundImage = global::videoTest6.Properties.Resources.backgroundOfficial;
            this.ClientSize = new System.Drawing.Size(1298, 507);
            this.Controls.Add(this.btnCalculate);
            this.Controls.Add(this.btnAddProcess);
            this.Controls.Add(this.minecraftLoad);
            this.Controls.Add(this.richTextBox1);
            this.Controls.Add(this.playpauseHere);
            this.Controls.Add(this.panel2);
            this.Controls.Add(this.nextBtn);
            this.Controls.Add(this.panel1);
            this.Controls.Add(this.rtbOutput);
            this.Controls.Add(this.pnlGanttChart);
            this.Controls.Add(this.dgvProcesses);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.None;
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.Name = "Form1";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "+";
            this.Load += new System.EventHandler(this.Form1_Load);
            ((System.ComponentModel.ISupportInitialize)(this.dgvProcesses)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.minecraftLoad)).EndInit();
            this.panel2.ResumeLayout(false);
            this.panel2.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.picBoxExit)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Panel pnlGanttChart;
        private System.Windows.Forms.RichTextBox rtbOutput;
        private System.Windows.Forms.Button btnAddProcess;
        private System.Windows.Forms.Button btnCalculate;
        private System.Windows.Forms.DataGridView dgvProcesses;
        private System.Windows.Forms.PictureBox minecraftLoad;
        private System.Windows.Forms.Timer timerGif;
        private System.Windows.Forms.Panel panel1;
        private System.Windows.Forms.Button nextBtn;
        private System.Windows.Forms.Panel panel2;
        private System.Windows.Forms.PictureBox picBoxExit;
        private System.Windows.Forms.Button playpauseHere;
        private System.Windows.Forms.RichTextBox richTextBox1;
        private System.Windows.Forms.Label secretLabel;
        private System.Windows.Forms.PictureBox pictureBox1;
        private System.Windows.Forms.ToolTip toolTip1;
    }
}


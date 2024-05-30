namespace Sokoban_Game
{
    partial class Form1
    {
        /// <summary>
        ///  Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        ///  Clean up any resources being used.
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
        ///  Required method for Designer support - do not modify
        ///  the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            components = new System.ComponentModel.Container();
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(Form1));
            pictureBox_map = new PictureBox();
            pictureBox_player = new PictureBox();
            pictureBox_target2 = new PictureBox();
            pictureBox_box1 = new PictureBox();
            pictureBox_box2 = new PictureBox();
            pictureBox_box4 = new PictureBox();
            pictureBox_box3 = new PictureBox();
            pictureBox_target1 = new PictureBox();
            pictureBox_target4 = new PictureBox();
            pictureBox_target3 = new PictureBox();
            lblTime = new Label();
            timer1 = new System.Windows.Forms.Timer(components);
            ((System.ComponentModel.ISupportInitialize)pictureBox_map).BeginInit();
            ((System.ComponentModel.ISupportInitialize)pictureBox_player).BeginInit();
            ((System.ComponentModel.ISupportInitialize)pictureBox_target2).BeginInit();
            ((System.ComponentModel.ISupportInitialize)pictureBox_box1).BeginInit();
            ((System.ComponentModel.ISupportInitialize)pictureBox_box2).BeginInit();
            ((System.ComponentModel.ISupportInitialize)pictureBox_box4).BeginInit();
            ((System.ComponentModel.ISupportInitialize)pictureBox_box3).BeginInit();
            ((System.ComponentModel.ISupportInitialize)pictureBox_target1).BeginInit();
            ((System.ComponentModel.ISupportInitialize)pictureBox_target4).BeginInit();
            ((System.ComponentModel.ISupportInitialize)pictureBox_target3).BeginInit();
            SuspendLayout();
            // 
            // pictureBox_map
            // 
            pictureBox_map.Image = Properties.Resources.地圖Level_1;
            pictureBox_map.Location = new Point(0, 0);
            pictureBox_map.Margin = new Padding(2);
            pictureBox_map.Name = "pictureBox_map";
            pictureBox_map.Size = new Size(311, 316);
            pictureBox_map.TabIndex = 0;
            pictureBox_map.TabStop = false;
            // 
            // pictureBox_player
            // 
            pictureBox_player.BackColor = SystemColors.Control;
            pictureBox_player.Image = (Image)resources.GetObject("pictureBox_player.Image");
            pictureBox_player.Location = new Point(124, 158);
            pictureBox_player.Margin = new Padding(2);
            pictureBox_player.Name = "pictureBox_player";
            pictureBox_player.Size = new Size(31, 32);
            pictureBox_player.TabIndex = 1;
            pictureBox_player.TabStop = false;
            pictureBox_player.Paint += MainForm_Paint;
            // 
            // pictureBox_target2
            // 
            pictureBox_target2.BackColor = SystemColors.Control;
            pictureBox_target2.Image = Properties.Resources.目標點;
            pictureBox_target2.Location = new Point(218, 158);
            pictureBox_target2.Margin = new Padding(2);
            pictureBox_target2.Name = "pictureBox_target2";
            pictureBox_target2.Size = new Size(31, 32);
            pictureBox_target2.TabIndex = 2;
            pictureBox_target2.TabStop = false;
            // 
            // pictureBox_box1
            // 
            pictureBox_box1.Image = Properties.Resources.箱子;
            pictureBox_box1.Location = new Point(156, 95);
            pictureBox_box1.Margin = new Padding(2);
            pictureBox_box1.Name = "pictureBox_box1";
            pictureBox_box1.Size = new Size(31, 32);
            pictureBox_box1.TabIndex = 3;
            pictureBox_box1.TabStop = false;
            pictureBox_box1.Tag = "box";
            // 
            // pictureBox_box2
            // 
            pictureBox_box2.Image = Properties.Resources.箱子;
            pictureBox_box2.Location = new Point(187, 158);
            pictureBox_box2.Margin = new Padding(2);
            pictureBox_box2.Name = "pictureBox_box2";
            pictureBox_box2.Size = new Size(31, 32);
            pictureBox_box2.TabIndex = 4;
            pictureBox_box2.TabStop = false;
            pictureBox_box2.Tag = "box";
            // 
            // pictureBox_box4
            // 
            pictureBox_box4.Image = Properties.Resources.箱子;
            pictureBox_box4.Location = new Point(93, 126);
            pictureBox_box4.Margin = new Padding(2);
            pictureBox_box4.Name = "pictureBox_box4";
            pictureBox_box4.Size = new Size(31, 32);
            pictureBox_box4.TabIndex = 5;
            pictureBox_box4.TabStop = false;
            pictureBox_box4.Tag = "box";
            // 
            // pictureBox_box3
            // 
            pictureBox_box3.Image = Properties.Resources.箱子;
            pictureBox_box3.Location = new Point(124, 189);
            pictureBox_box3.Margin = new Padding(2);
            pictureBox_box3.Name = "pictureBox_box3";
            pictureBox_box3.Size = new Size(31, 32);
            pictureBox_box3.TabIndex = 6;
            pictureBox_box3.TabStop = false;
            pictureBox_box3.Tag = "box";
            // 
            // pictureBox_target1
            // 
            pictureBox_target1.BackColor = SystemColors.Control;
            pictureBox_target1.Image = Properties.Resources.目標點;
            pictureBox_target1.Location = new Point(156, 64);
            pictureBox_target1.Margin = new Padding(2);
            pictureBox_target1.Name = "pictureBox_target1";
            pictureBox_target1.Size = new Size(31, 32);
            pictureBox_target1.TabIndex = 7;
            pictureBox_target1.TabStop = false;
            // 
            // pictureBox_target4
            // 
            pictureBox_target4.BackColor = SystemColors.Control;
            pictureBox_target4.Image = Properties.Resources.目標點;
            pictureBox_target4.Location = new Point(62, 126);
            pictureBox_target4.Margin = new Padding(2);
            pictureBox_target4.Name = "pictureBox_target4";
            pictureBox_target4.Size = new Size(31, 32);
            pictureBox_target4.TabIndex = 8;
            pictureBox_target4.TabStop = false;
            // 
            // pictureBox_target3
            // 
            pictureBox_target3.BackColor = SystemColors.Control;
            pictureBox_target3.Image = Properties.Resources.目標點;
            pictureBox_target3.Location = new Point(124, 221);
            pictureBox_target3.Margin = new Padding(2);
            pictureBox_target3.Name = "pictureBox_target3";
            pictureBox_target3.Size = new Size(31, 32);
            pictureBox_target3.TabIndex = 9;
            pictureBox_target3.TabStop = false;
            // 
            // lblTime
            // 
            lblTime.AutoSize = true;
            lblTime.Location = new Point(257, 9);
            lblTime.Name = "lblTime";
            lblTime.Size = new Size(35, 15);
            lblTime.TabIndex = 10;
            lblTime.Text = "Time";
            // 
            // Form1
            // 
            AutoScaleDimensions = new SizeF(7F, 15F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(311, 316);
            Controls.Add(lblTime);
            Controls.Add(pictureBox_target3);
            Controls.Add(pictureBox_target4);
            Controls.Add(pictureBox_target1);
            Controls.Add(pictureBox_box3);
            Controls.Add(pictureBox_box4);
            Controls.Add(pictureBox_box2);
            Controls.Add(pictureBox_box1);
            Controls.Add(pictureBox_target2);
            Controls.Add(pictureBox_player);
            Controls.Add(pictureBox_map);
            Margin = new Padding(2);
            Name = "Form1";
            Text = "Form1";
            Load += Form1_Load;
            KeyDown += Form1_KeyDown;
            ((System.ComponentModel.ISupportInitialize)pictureBox_map).EndInit();
            ((System.ComponentModel.ISupportInitialize)pictureBox_player).EndInit();
            ((System.ComponentModel.ISupportInitialize)pictureBox_target2).EndInit();
            ((System.ComponentModel.ISupportInitialize)pictureBox_box1).EndInit();
            ((System.ComponentModel.ISupportInitialize)pictureBox_box2).EndInit();
            ((System.ComponentModel.ISupportInitialize)pictureBox_box4).EndInit();
            ((System.ComponentModel.ISupportInitialize)pictureBox_box3).EndInit();
            ((System.ComponentModel.ISupportInitialize)pictureBox_target1).EndInit();
            ((System.ComponentModel.ISupportInitialize)pictureBox_target4).EndInit();
            ((System.ComponentModel.ISupportInitialize)pictureBox_target3).EndInit();
            ResumeLayout(false);
            PerformLayout();
        }

        #endregion

        private PictureBox pictureBox_map;
        private PictureBox pictureBox_player;
        private PictureBox pictureBox_target2;
        private PictureBox pictureBox_box1;
        private PictureBox pictureBox_box2;
        private PictureBox pictureBox_box4;
        private PictureBox pictureBox_box3;
        private PictureBox pictureBox_target1;
        private PictureBox pictureBox_target4;
        private PictureBox pictureBox_target3;
        private Label lblTime;
        private System.Windows.Forms.Timer timer1;
    }
}

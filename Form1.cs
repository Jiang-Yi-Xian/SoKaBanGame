using Timer = System.Windows.Forms.Timer;
using System.Drawing;

namespace Sokoban_Game
{
    public partial class Form1 : Form
    {
        private List<int[,]> maps = new List<int[,]>();//地圖清單
        private List<Point> playerPoints = new List<Point>();
        public int currentMapIndex = 0;//當前地圖的索引值
        int WD = 382 / 10;
        int HD = 354 / 10;

        //玩家圖像
        private Image playerImageLeft;
        private Image playerImageRight;
        private Image playerImageUp;
        private Image playerImageDown;
            
        public Form1()
        {
            // 載入玩家圖像
            playerImageLeft = Properties.Resources.玩家左邊;
            playerImageRight = Properties.Resources.玩家右邊;
            playerImageUp = Properties.Resources.玩家後;
            playerImageDown = Properties.Resources.玩家前;

            // 初始化計時器
            timer = new Timer();
            timer.Interval = 1000; // 每秒觸發一次
            timer.Tick += Timer_Tick;

            // 遊戲開始時啟動計時器
            StartTimer();
            //
            InitializeComponent();
            InitializeMaps();
            InitializeMapElements();
            InitializePlayerPositions();
        }
        private void Form1_Load(object sender, EventArgs e)
        {
            this.SetBounds(0, 0, 400, 400); //設定視窗大小
            UpdateCurrentMap();
        }
        private void InitializeMaps() //初始化地圖
        {
            int[,] map1 =
            {
                {0,0,0,0,0,0,0,0,0,0},
                {0,0,0,0,0,0,0,0,0,0},
                {0,0,0,0,0,2,0,0,0,0},
                {0,0,0,0,0,3,0,0,0,0},
                {0,0,2,3,1,1,0,0,0,0},
                {0,0,0,0,1,1,3,2,0,0},
                {0,0,0,0,3,0,0,0,0,0},
                {0,0,0,0,2,0,0,0,0,0},
                {0,0,0,0,0,0,0,0,0,0},
                {0,0,0,0,0,0,0,0,0,0},
            };
            int[,] map2 =
            {
                {0,0,0,0,0,0,0,0,0,0},
                {0,1,1,1,0,0,0,0,0,0},
                {0,1,3,3,0,0,0,0,0,0},
                {0,1,3,1,0,0,0,2,0,0},
                {0,0,0,1,0,0,0,2,0,0},
                {0,0,0,1,1,1,1,2,0,0},
                {0,0,1,1,1,0,1,1,0,0},
                {0,0,1,1,1,0,0,0,0,0},
                {0,0,0,0,0,0,0,0,0,0},
                {0,0,0,0,0,0,0,0,0,0},
            };
            int[,] map3 =
            {
                {0,0,0,0,0,0,0,0,0,0},
                {0,0,0,0,0,0,0,0,0,0},
                {0,0,1,1,1,1,1,0,0,0},
                {0,0,3,0,0,0,1,1,1,0},
                {0,1,1,1,3,1,1,3,1,0},
                {0,1,2,2,0,1,3,1,0,0},
                {0,0,2,2,0,1,1,1,0,0},
                {0,0,0,0,0,0,0,0,0,0},
                {0,0,0,0,0,0,0,0,0,0},
                {0,0,0,0,0,0,0,0,0,0},
            };
            maps.Add(map1);
            maps.Add(map2);
            maps.Add(map3);
        }
        //將各個地圖元素的背景透明化
        private void InitializeMapElements()
        {
            pictureBox_map.Controls.Add(pictureBox_player);
            pictureBox_player.BackColor = Color.Transparent;
            pictureBox_map.Controls.Add(pictureBox_target1);
            pictureBox_target1.BackColor = Color.Transparent;
            pictureBox_map.Controls.Add(pictureBox_target2);
            pictureBox_target2.BackColor = Color.Transparent;
            pictureBox_map.Controls.Add(pictureBox_target3);
            pictureBox_target3.BackColor = Color.Transparent;
            pictureBox_map.Controls.Add(pictureBox_target4);
            pictureBox_target4.BackColor = Color.Transparent;
        }
        private void InitializePlayerPositions()
        {
            playerPoints.Add(new Point(4, 5));
            playerPoints.Add(new Point(1, 1));
            playerPoints.Add(new Point(2, 4));
        }
        //更新遊戲地圖的各個元素位置
        private void UpdateCurrentMap()
        {
            Point currentPlayer1 = playerPoints[currentMapIndex];
            if (currentMapIndex == 0)
            {
                pictureBox_player.Location = new Point(currentPlayer1.X * WD, currentPlayer1.Y * HD);
                pictureBox_box1.Location = new Point(5 * WD, 3 * HD);
                pictureBox_box2.Location = new Point(6 * WD, 5 * HD);
                pictureBox_box3.Location = new Point(4 * WD, 6 * HD);
                pictureBox_box4.Location = new Point(3 * WD, 4 * HD);
                pictureBox_target1.Location = new Point(5 * WD, 2 * HD);
                pictureBox_target2.Location = new Point(7 * WD, 5 * HD);
                pictureBox_target3.Location = new Point(4 * WD, 7 * HD);
                pictureBox_target4.Location = new Point(2 * WD, 4 * HD);
            }
            if (currentMapIndex == 1)
            {
                pictureBox_player.Location = new Point(currentPlayer1.X * WD, currentPlayer1.Y * HD);
                pictureBox_box1.Location = new Point(2 * WD, 2 * HD);
                pictureBox_box2.Location = new Point(3 * WD, 2 * HD);
                pictureBox_box3.Location = new Point(2 * WD, 3 * HD);
                pictureBox_box4.Visible = false;
                pictureBox_box4.Location = new Point(0 * WD, 0 * HD);
                pictureBox_target1.Location = new Point(7 * WD, 3 * HD);
                pictureBox_target2.Location = new Point(7 * WD, 4 * HD);
                pictureBox_target3.Location = new Point(7 * WD, 5 * HD);
                pictureBox_target4.Visible = false;
                pictureBox_target4.Location = new Point(0 * WD, 0 * HD);
            }
            if (currentMapIndex == 2)
            {
                pictureBox_player.Location = new Point(currentPlayer1.X * WD, currentPlayer1.Y * HD);
                pictureBox_box1.Location = new Point(2 * WD, 3 * HD);
                pictureBox_box2.Location = new Point(4 * WD, 4 * HD);
                pictureBox_box3.Location = new Point(6 * WD, 5 * HD);
                pictureBox_box4.Visible = true;
                pictureBox_box4.Location = new Point(7 * WD, 4 * HD);
                pictureBox_target1.Location = new Point(2 * WD, 5 * HD);
                pictureBox_target2.Location = new Point(3 * WD, 5 * HD);
                pictureBox_target3.Location = new Point(2 * WD, 6 * HD);
                pictureBox_target4.Visible = true;
                pictureBox_target4.Location = new Point(3 * WD, 6 * HD);
            }
        }
        private void Form1_KeyDown(object sender, KeyEventArgs e)
        {
            this.Refresh();
            CheckLevelCompletion();
            MovePlayer(e.KeyCode);
        }
        private void MovePlayer(Keys key)
        {
            Point currentPlayer = playerPoints[currentMapIndex];
            if (key == Keys.Left)
            {
                pictureBox_player.Image = playerImageLeft;
                if (currentPlayer.X > 0 && (maps[currentMapIndex][currentPlayer.Y, currentPlayer.X - 1] == 1 || maps[currentMapIndex][currentPlayer.Y, currentPlayer.X - 1] == 2))
                {
                    currentPlayer.X -= 1;
                    pictureBox_player.Left -= WD;
                }
                else if (currentPlayer.X > 1 && maps[currentMapIndex][currentPlayer.Y, currentPlayer.X - 1] == 3)
                {
                    if (maps[currentMapIndex][currentPlayer.Y, currentPlayer.X - 2] == 1 || maps[currentMapIndex][currentPlayer.Y, currentPlayer.X - 2] == 2)
                    {
                        maps[currentMapIndex][currentPlayer.Y, currentPlayer.X - 1] = 1;
                        if (maps[currentMapIndex][currentPlayer.Y, currentPlayer.X - 2] == 2)
                        {
                            maps[currentMapIndex][currentPlayer.Y, currentPlayer.X - 2] = 4;
                        }
                        else
                        {
                            maps[currentMapIndex][currentPlayer.Y, currentPlayer.X - 2] = 3;
                        }
                        currentPlayer.X -= 1;
                        pictureBox_player.Left -= WD;
                        ChangBoxLocation(-WD, 0);
                    }
                }
                else if (maps[currentMapIndex][currentPlayer.Y, currentPlayer.X - 1] == 4 && maps[currentMapIndex][currentPlayer.Y, currentPlayer.X - 2] == 2)
                {
                    maps[currentMapIndex][currentPlayer.Y, currentPlayer.X - 1] = 2; maps[currentMapIndex][currentPlayer.Y, currentPlayer.X - 2] = 4;
                    currentPlayer.X -= 1;
                    pictureBox_player.Left -= WD;
                    ChangBoxLocation(-WD, 0);
                }
            }

            if (key == Keys.Right)
            {
                pictureBox_player.Image = playerImageRight;
                if (currentPlayer.X < 9 && (maps[currentMapIndex][currentPlayer.Y, currentPlayer.X + 1] == 1 || maps[currentMapIndex][currentPlayer.Y, currentPlayer.X + 1] == 2))
                {
                    currentPlayer.X += 1;
                    pictureBox_player.Left += WD;
                }
                else if (currentPlayer.X < 8 && maps[currentMapIndex][currentPlayer.Y, currentPlayer.X + 1] == 3)
                {
                    if (maps[currentMapIndex][currentPlayer.Y, currentPlayer.X + 2] == 1 || maps[currentMapIndex][currentPlayer.Y, currentPlayer.X + 2] == 2)
                    {
                        maps[currentMapIndex][currentPlayer.Y, currentPlayer.X + 1] = 1;
                        if (maps[currentMapIndex][currentPlayer.Y, currentPlayer.X + 2] == 2)
                        {
                            maps[currentMapIndex][currentPlayer.Y, currentPlayer.X + 2] = 4;
                        }
                        else
                        {
                            maps[currentMapIndex][currentPlayer.Y, currentPlayer.X + 2] = 3;
                        }
                        currentPlayer.X += 1;
                        pictureBox_player.Left += WD;
                        ChangBoxLocation(WD, 0);
                    }
                }
                else if (maps[currentMapIndex][currentPlayer.Y, currentPlayer.X + 1] == 4 && maps[currentMapIndex][currentPlayer.Y, currentPlayer.X + 2] == 2)
                {
                    maps[currentMapIndex][currentPlayer.Y, currentPlayer.X + 1] = 2; maps[currentMapIndex][currentPlayer.Y, currentPlayer.X + 2] = 4;
                    currentPlayer.X += 1;
                    pictureBox_player.Left += WD;
                    ChangBoxLocation(+WD, 0);
                }
            }

            if (key == Keys.Up)
            {
                pictureBox_player.Image = playerImageUp;
                if (currentPlayer.Y > 0 && (maps[currentMapIndex][currentPlayer.Y - 1, currentPlayer.X] == 1 || maps[currentMapIndex][currentPlayer.Y - 1, currentPlayer.X] == 2))
                {
                    currentPlayer.Y -= 1;
                    pictureBox_player.Top -= HD;
                }
                else if (currentPlayer.Y > 1 && maps[currentMapIndex][currentPlayer.Y - 1, currentPlayer.X] == 3)
                {
                    if (maps[currentMapIndex][currentPlayer.Y - 2, currentPlayer.X] == 1 || maps[currentMapIndex][currentPlayer.Y - 2, currentPlayer.X] == 2)
                    {
                        maps[currentMapIndex][currentPlayer.Y - 1, currentPlayer.X] = 1;
                        if (maps[currentMapIndex][currentPlayer.Y - 2, currentPlayer.X] == 2)
                        {
                            maps[currentMapIndex][currentPlayer.Y - 2, currentPlayer.X] = 4;
                        }
                        else
                        {
                            maps[currentMapIndex][currentPlayer.Y - 2, currentPlayer.X] = 3;
                        }
                        currentPlayer.Y -= 1;
                        pictureBox_player.Top -= HD;
                        ChangBoxLocation(0, -HD);
                    }
                }
                else if (maps[currentMapIndex][currentPlayer.Y - 1, currentPlayer.X] == 4 && maps[currentMapIndex][currentPlayer.Y - 2, currentPlayer.X] == 2) 
                {
                    maps[currentMapIndex][currentPlayer.Y - 2, currentPlayer.X] = 4; maps[currentMapIndex][currentPlayer.Y - 1, currentPlayer.X] = 2;
                    currentPlayer.Y -= 1;
                    pictureBox_player.Top -= HD;
                    ChangBoxLocation(0, -HD);
                }
            }

            if (key == Keys.Down)
            {
                pictureBox_player.Image = playerImageDown;
                if (currentPlayer.Y < 9 && (maps[currentMapIndex][currentPlayer.Y + 1, currentPlayer.X] == 1 || maps[currentMapIndex][currentPlayer.Y + 1, currentPlayer.X] == 2))
                {
                    currentPlayer.Y += 1;
                    pictureBox_player.Top += HD;
                }
                else if (currentPlayer.Y < 8 && maps[currentMapIndex][currentPlayer.Y + 1, currentPlayer.X] == 3)
                {
                    if (maps[currentMapIndex][currentPlayer.Y + 2, currentPlayer.X] == 1 || maps[currentMapIndex][currentPlayer.Y + 2, currentPlayer.X] == 2)
                    {
                        maps[currentMapIndex][currentPlayer.Y + 1, currentPlayer.X] = 1;
                        if (maps[currentMapIndex][currentPlayer.Y + 2, currentPlayer.X] == 2)
                        {
                            maps[currentMapIndex][currentPlayer.Y + 2, currentPlayer.X] = 4;
                        }
                        else
                        {
                            maps[currentMapIndex][currentPlayer.Y + 2, currentPlayer.X] = 3;
                        }
                        currentPlayer.Y += 1;
                        pictureBox_player.Top += HD;
                        ChangBoxLocation(0, HD);
                    }
                }
                else if (maps[currentMapIndex][currentPlayer.Y + 1, currentPlayer.X] == 4 && maps[currentMapIndex][currentPlayer.Y + 2, currentPlayer.X] == 2)
                {
                    maps[currentMapIndex][currentPlayer.Y + 2, currentPlayer.X] = 4; maps[currentMapIndex][currentPlayer.Y + 1, currentPlayer.X] = 2;
                    currentPlayer.Y += 1;
                    pictureBox_player.Top += HD;
                    ChangBoxLocation(0, +HD);
                }
            }
            playerPoints[currentMapIndex] = currentPlayer;
        }
        public void ChangBoxLocation(int move_x, int move_y) //判斷玩家是否與箱子接觸
        {
            foreach (Control x in this.Controls)
            {
                if (x.Tag == "box" && pictureBox_player.Bounds.IntersectsWith(x.Bounds))
                {
                    x.Location = new Point(x.Left + move_x, x.Top + move_y);
                }
            }
        }
        private void CheckLevelCompletion()
        {
            if (currentMapIndex == 0)
            {
                if (maps[currentMapIndex][2, 5] == 4 && maps[currentMapIndex][5, 7] == 4 && maps[currentMapIndex][7, 4] == 4 && maps[currentMapIndex][4, 2] == 4)
                {
                    currentMapIndex += 1;
                    DialogResult result = MessageBox.Show("是否前往下一關?", "恭喜過關!!!", MessageBoxButtons.YesNo);
                    if (result == DialogResult.Yes)
                    {
                        UpdateCurrentMap();
                        pictureBox_map.Image = Properties.Resources.map2;
                    }
                    else
                    {
                        Application.Exit();
                    }
                }
            }
            if (currentMapIndex == 1)
            {
                if (maps[currentMapIndex][3, 7] == 4 && maps[currentMapIndex][4, 7] == 4 && maps[currentMapIndex][5, 7] == 4)
                {
                    currentMapIndex += 1;
                    DialogResult result = MessageBox.Show("是否前往下一關?", "恭喜過關!!!", MessageBoxButtons.YesNo);
                    if (result == DialogResult.Yes)
                    {
                        UpdateCurrentMap();
                        pictureBox_map.Image = Properties.Resources.map3;
                    }
                    else
                    {
                        Application.Exit();
                    }
                }
            }
            if (currentMapIndex == 2)
            {
                if (maps[currentMapIndex][5, 2] == 4 && maps[currentMapIndex][5, 3] == 4 && maps[currentMapIndex][6, 2] == 4 && maps[currentMapIndex][6, 3] == 4)
                {
                    TimeSpan timeTaken = endTime - startTime;
                    DialogResult result = MessageBox.Show("是否要退出?", "恭喜過關!!! " + " 通關時間：" + timeTaken.ToString(@"hh\:mm\:ss"), MessageBoxButtons.YesNo);
                    if (result == DialogResult.Yes)
                    {
                        Application.Exit();
                    }
                }
            }
        }
        // 計時器
        private Timer timer;
        private DateTime startTime;
        private DateTime endTime;
        private void Timer_Tick(object sender, EventArgs e)
        {
            endTime = DateTime.Now;
            TimeSpan elapsedTime = DateTime.Now - startTime;
            lblTime.Text = string.Format("{0:mm\\:ss}", elapsedTime);
            TimeSpan timeTaken = endTime - startTime;
        }
        private void StartTimer()
        {
            // 開始計時
            startTime = DateTime.Now;
            timer.Start();
        }

        private void StopTimer()
        {
            // 停止計時
            timer.Stop();
        }
    }
}

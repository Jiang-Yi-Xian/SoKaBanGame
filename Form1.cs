using Timer = System.Windows.Forms.Timer;
using System.Drawing;

namespace Sokoban_Game


{
    public partial class Form1 : Form
    {
        private List<int[,]> maps = new List<int[,]>();//地圖清單
        public int currentMapIndex = 0;//當前地圖的索引值
        int Firstply_x = 4, Firstply_y = 5;//map1 玩家的初始位置
        int Scenodply_x = 1, Scenodply_y = 1;//map2 玩家的初始位置
        int Thirdply_x = 2, Thirdply_y = 4;//map3 玩家的初始位置

        //玩家圖像
        private Image playerImageLeft;
        private Image playerImageRight;
        private Image playerImageUp;
        private Image playerImageDown;
        private Image currentPlayerImage;

        private void MainForm_Paint(object sender, PaintEventArgs e)
        {
            // 繪製玩家角色
            e.Graphics.DrawImage(currentPlayerImage, Firstply_x, Firstply_y);
        }

        public Form1()
        {
            // 載入玩家圖像
            playerImageLeft = Properties.Resources.玩家左;
            playerImageRight = Properties.Resources.玩家右;
            playerImageUp = Properties.Resources.玩家背面;
            playerImageDown = Properties.Resources.玩家正面;
            currentPlayerImage = playerImageRight; // 初始圖像設為右

            this.Paint += MainForm_Paint;

            // 初始化計時器
            timer = new Timer();
            timer.Interval = 1000; // 每秒觸發一次
            timer.Tick += Timer_Tick;

            // 遊戲開始時啟動計時器
            StartTimer();

            currentMapIndex = 0;
            //int[,] currentMap =  maps[currentMapIndex];
            //
            InitializeComponent();
            InitializeMaps();
            //將各個地圖元素的背景透明化
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
        private void Form1_Load(object sender, EventArgs e)
        {
            this.SetBounds(0, 0, 418, 447); //設定視窗大小
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
        //更新遊戲地圖的各個元素位置
        private void UpdateCurrentMap()
        {
            if (currentMapIndex == 0)
            {
                pictureBox_player.Location = new Point(Firstply_x * (this.Width / 10) - 2, Firstply_y * (this.Width / 10) - 3);
                pictureBox_box1.Location = new Point(5 * (this.Width / 10) - 4, 3 * (this.Width / 10) - 3);
                pictureBox_box2.Location = new Point(6 * (this.Width / 10) - 4, 5 * (this.Width / 10) - 4);
                pictureBox_box3.Location = new Point(4 * (this.Width / 10) - 4, 6 * (this.Width / 10) - 4);
                pictureBox_box4.Location = new Point(3 * (this.Width / 10) - 4, 4 * (this.Width / 10) - 3);
                pictureBox_target1.Location = new Point(5 * (this.Width / 10) - 4, 2 * (this.Width / 10) - 3);
                pictureBox_target2.Location = new Point(7 * (this.Width / 10) - 4, 5 * (this.Width / 10) - 4);
                pictureBox_target3.Location = new Point(4 * (this.Width / 10) - 4, 7 * (this.Width / 10) - 4);
                pictureBox_target4.Location = new Point(2 * (this.Width / 10) - 4, 4 * (this.Width / 10) - 3);
            }
            if (currentMapIndex == 1)
            {
                pictureBox_player.Location = new Point(Scenodply_x * (this.Width / 10) - 2, Scenodply_y * (this.Width / 10) - 3);
                pictureBox_box1.Location = new Point(2 * (this.Width / 10) - 4, 2 * (this.Width / 10) - 3);
                pictureBox_box2.Location = new Point(3 * (this.Width / 10) - 4, 2 * (this.Width / 10) - 4);
                pictureBox_box3.Location = new Point(2 * (this.Width / 10) - 4, 3 * (this.Width / 10) - 4);
                pictureBox_box4.Visible = false;
                pictureBox_target1.Location = new Point(7 * (this.Width / 10) - 4, 3 * (this.Width / 10) - 3);
                pictureBox_target2.Location = new Point(7 * (this.Width / 10) - 4, 4 * (this.Width / 10) - 4);
                pictureBox_target3.Location = new Point(7 * (this.Width / 10) - 4, 5 * (this.Width / 10) - 4);
                pictureBox_target4.Visible = false;
            }
            if (currentMapIndex == 2)
            {
                pictureBox_player.Location = new Point(Thirdply_x * (this.Width / 10) - 2, Thirdply_y * (this.Width / 10) - 3);
                pictureBox_box1.Location = new Point(2 * (this.Width / 10) - 4, 3 * (this.Width / 10) - 3);
                pictureBox_box2.Location = new Point(4 * (this.Width / 10) - 4, 4 * (this.Width / 10) - 4);
                pictureBox_box3.Location = new Point(6 * (this.Width / 10) - 4, 5 * (this.Width / 10) - 4);
                pictureBox_box4.Visible = true;
                pictureBox_box4.Location = new Point(7 * (this.Width / 10) - 4, 4 * (this.Width / 10) - 3);
                pictureBox_target1.Location = new Point(2 * (this.Width / 10) - 4, 5 * (this.Width / 10) - 3);
                pictureBox_target2.Location = new Point(3 * (this.Width / 10) - 4, 5 * (this.Width / 10) - 4);
                pictureBox_target3.Location = new Point(2 * (this.Width / 10) - 4, 6 * (this.Width / 10) - 4);
                pictureBox_target4.Visible = true;
                pictureBox_target4.Location = new Point(3 * (this.Width / 10) - 4, 6 * (this.Width / 10) - 3);
            }
        }
        //出BUG的部分(maybe)&需要想辦法簡化
        private void Form1_KeyDown(object sender, KeyEventArgs e)
        {
            this.Refresh();
            //map1 的鍵盤判斷
            if (currentMapIndex == 0)
            {
                if (e.KeyCode == Keys.Left)
                {
                    currentPlayerImage = playerImageLeft;
                    if (maps[currentMapIndex][Firstply_y, Firstply_x - 1] == 1 || maps[currentMapIndex][Firstply_y, Firstply_x - 1] == 2)
                    {
                        Firstply_x -= 1;
                        pictureBox_player.Left -= (this.Width / 10) - 4;
                    }
                    else if (maps[currentMapIndex][Firstply_y, Firstply_x - 1] == 3)
                    {
                        if (maps[currentMapIndex][Firstply_y, Firstply_x - 2] == 1)
                        {
                            maps[currentMapIndex][Firstply_y, Firstply_x - 1] = 1; maps[currentMapIndex][Firstply_y, Firstply_x - 2] = 3;
                            Firstply_x -= 1;
                            pictureBox_player.Left -= (this.Width / 10) - 4;
                            ChangBoxLocation(-(this.Width / 10), 0);
                        }
                        else if (maps[currentMapIndex][Firstply_y, Firstply_x - 2] == 2)
                        {
                            maps[currentMapIndex][Firstply_y, Firstply_x - 1] = 1; maps[currentMapIndex][Firstply_y, Firstply_x - 2] = 4;
                            Firstply_x -= 1;
                            pictureBox_player.Left -= (this.Width / 10) - 4;
                            ChangBoxLocation(-(this.Width / 10), 0);
                        }
                    }
                    else if (maps[currentMapIndex][Firstply_y, Firstply_x - 1] == 4 && maps[currentMapIndex][Firstply_y, Firstply_x - 2] == 2)
                    {
                        maps[currentMapIndex][Firstply_y, Firstply_x - 1] = 2; maps[currentMapIndex][Firstply_y, Firstply_x - 2] = 4;
                        Firstply_x -= 1;
                        pictureBox_player.Left -= (this.Width / 10) - 4;
                        ChangBoxLocation(-(this.Width / 10), 0);
                    }
                }
                //
                if (e.KeyCode == Keys.Right)
                {
                    currentPlayerImage = playerImageRight;
                    if (maps[currentMapIndex][Firstply_y, Firstply_x + 1] == 1 || maps[currentMapIndex][Firstply_y, Firstply_x + 1] == 2)
                    {
                        Firstply_x += 1;
                        pictureBox_player.Left += (this.Width / 10) - 4;
                    }
                    else if (maps[currentMapIndex][Firstply_y, Firstply_x + 1] == 3)
                    {
                        if (maps[currentMapIndex][Firstply_y, Firstply_x + 2] == 1)
                        {
                            maps[currentMapIndex][Firstply_y, Firstply_x + 1] = 1; maps[currentMapIndex][Firstply_y, Firstply_x + 2] = 3;
                            Firstply_x += 1;
                            pictureBox_player.Left += (this.Width / 10) - 4;
                            ChangBoxLocation(+(this.Width / 10), 0);
                        }
                        else if (maps[currentMapIndex][Firstply_y, Firstply_x + 2] == 2)
                        {
                            maps[currentMapIndex][Firstply_y, Firstply_x + 1] = 1; maps[currentMapIndex][Firstply_y, Firstply_x + 2] = 4;
                            Firstply_x += 1;
                            pictureBox_player.Left += (this.Width / 10) - 4;
                            ChangBoxLocation(+(this.Width / 10), 0);
                        }
                    }
                    else if (maps[currentMapIndex][Firstply_y, Firstply_x + 1] == 4 && maps[currentMapIndex][Firstply_y, Firstply_x + 2] == 2)
                    {
                        maps[currentMapIndex][Firstply_y, Firstply_x + 1] = 2; maps[currentMapIndex][Firstply_y, Firstply_x + 2] = 4;
                        Firstply_x += 1;
                        pictureBox_player.Left += (this.Width / 10) - 4;
                        ChangBoxLocation(+(this.Width / 10), 0);
                    }
                }
                //
                if (e.KeyCode == Keys.Up)
                {
                    currentPlayerImage = playerImageUp;
                    if (maps[currentMapIndex][Firstply_y - 1, Firstply_x] == 1 || maps[currentMapIndex][Firstply_y - 1, Firstply_x] == 2)
                    {
                        Firstply_y -= 1;
                        pictureBox_player.Top -= (this.Height / 10) - 3;
                    }
                    else if (maps[currentMapIndex][Firstply_y - 1, Firstply_x] == 3)
                    {
                        if (maps[currentMapIndex][Firstply_y - 2, Firstply_x] == 1)
                        {
                            maps[currentMapIndex][Firstply_y - 1, Firstply_x] = 1; maps[currentMapIndex][Firstply_y - 2, Firstply_x] = 3;
                            Firstply_y -= 1;
                            pictureBox_player.Top -= (this.Height / 10) - 4;
                            ChangBoxLocation(0, -(this.Height / 10));
                        }
                        else if (maps[currentMapIndex][Firstply_y - 2, Firstply_x] == 2)
                        {
                            maps[currentMapIndex][Firstply_y - 1, Firstply_x] = 1; maps[currentMapIndex][Firstply_y - 2, Firstply_x] = 4;
                            Firstply_y -= 1;
                            pictureBox_player.Top -= (this.Height / 10) - 4;
                            ChangBoxLocation(0, -(this.Height / 10));
                        }
                    }
                    else if (maps[currentMapIndex][Firstply_y - 1, Firstply_x] == 4 && maps[currentMapIndex][Firstply_y - 2, Firstply_x] == 2)
                    {
                        maps[currentMapIndex][Firstply_y - 1, Firstply_x] = 2; maps[currentMapIndex][Firstply_y - 2, Firstply_x] = 4;
                        Firstply_y -= 1;
                        pictureBox_player.Top -= (this.Height / 10) - 4;
                        ChangBoxLocation(0, -(this.Height / 10));
                    }
                }
                //
                if (e.KeyCode == Keys.Down)
                {
                    currentPlayerImage = playerImageDown;
                    if (maps[currentMapIndex][Firstply_y + 1, Firstply_x] == 1 || maps[currentMapIndex][Firstply_y + 1, Firstply_x] == 2)
                    {
                        Firstply_y += 1;
                        pictureBox_player.Top += (this.Height / 10) - 3;
                    }
                    else if (maps[currentMapIndex][Firstply_y + 1, Firstply_x] == 3)
                    {
                        if (maps[currentMapIndex][Firstply_y + 2, Firstply_x] == 1)
                        {
                            maps[currentMapIndex][Firstply_y + 1, Firstply_x] = 1; maps[currentMapIndex][Firstply_y + 2, Firstply_x] = 3;
                            Firstply_y += 1;
                            pictureBox_player.Top += (this.Height / 10) - 4;
                            ChangBoxLocation(0, +(this.Width / 10));
                        }
                        else if (maps[currentMapIndex][Firstply_y + 2, Firstply_x] == 2)
                        {
                            maps[currentMapIndex][Firstply_y + 1, Firstply_x] = 1; maps[currentMapIndex][Firstply_y + 2, Firstply_x] = 4;
                            Firstply_y += 1;
                            pictureBox_player.Top += (this.Height / 10) - 4;
                            ChangBoxLocation(0, +(this.Width / 10));
                        }
                    }
                    else if (maps[currentMapIndex][Firstply_y + 1, Firstply_x] == 4 && maps[currentMapIndex][Firstply_y + 2, Firstply_x] == 2)
                    {
                        maps[currentMapIndex][Firstply_y + 1, Firstply_x] = 2; maps[currentMapIndex][Firstply_y + 2, Firstply_x] = 4;
                        Firstply_y += 1;
                        pictureBox_player.Top += (this.Height / 10) - 4;
                        ChangBoxLocation(0, +(this.Width / 10));
                    }
                }
                //判斷箱子是否都在目標點上
                if (maps[currentMapIndex][2, 5] == 4 && maps[currentMapIndex][5, 7] == 4 && maps[currentMapIndex][7, 4] == 4 && maps[currentMapIndex][4, 2] == 4)
                {
                    currentMapIndex += 1;
                    DialogResult result = MessageBox.Show("是否前往下一關?", "恭喜過關!!!", MessageBoxButtons.YesNo);
                    if (result == DialogResult.Yes)
                    {
                        UpdateCurrentMap();
                        pictureBox_map.Image = Properties.Resources.地圖Level_2;
                    }
                    else
                    {
                        Application.Exit();
                    }
                }
            }

            //map2 的鍵盤判斷
            if (currentMapIndex == 1)
            {
                currentPlayerImage = playerImageLeft;
                if (e.KeyCode == Keys.Left)
                {
                    if (maps[currentMapIndex][Scenodply_y, Scenodply_x - 1] == 1 || maps[currentMapIndex][Scenodply_y, Scenodply_x - 1] == 2)
                    {
                        Scenodply_x -= 1;
                        pictureBox_player.Left -= (this.Width / 10) - 4;
                    }
                    else if (maps[currentMapIndex][Scenodply_y, Scenodply_x - 1] == 3)
                    {
                        if (maps[currentMapIndex][Scenodply_y, Scenodply_x - 2] == 1)
                        {
                            maps[currentMapIndex][Scenodply_y, Scenodply_x - 1] = 1; maps[currentMapIndex][Scenodply_y, Scenodply_x - 2] = 3;
                            Scenodply_x -= 1;
                            pictureBox_player.Left -= (this.Width / 10) - 4;
                            ChangBoxLocation(-(this.Width / 10), 0);
                        }
                        else if (maps[currentMapIndex][Scenodply_y, Scenodply_x - 2] == 2)
                        {
                            maps[currentMapIndex][Scenodply_y, Scenodply_x - 1] = 1; maps[currentMapIndex][Scenodply_y, Scenodply_x - 2] = 4;
                            Scenodply_x -= 1;
                            pictureBox_player.Left -= (this.Width / 10) - 4;
                            ChangBoxLocation(-(this.Width / 10), 0);
                        }
                    }
                    else if (maps[currentMapIndex][Scenodply_y, Scenodply_x - 1] == 4 && maps[currentMapIndex][Scenodply_y, Scenodply_x - 2] == 2)
                    {
                        maps[currentMapIndex][Scenodply_y, Scenodply_x - 1] = 2; maps[currentMapIndex][Scenodply_y, Scenodply_x - 2] = 4;
                        Scenodply_x -= 1;
                        pictureBox_player.Left -= (this.Width / 10) - 4;
                        ChangBoxLocation(-(this.Width / 10), 0);
                    }
                }
                //
                if (e.KeyCode == Keys.Right)
                {
                    currentPlayerImage = playerImageRight;
                    if (maps[currentMapIndex][Scenodply_y, Scenodply_x + 1] == 1 || maps[currentMapIndex][Scenodply_y, Scenodply_x + 1] == 2)
                    {
                        Scenodply_x += 1;
                        pictureBox_player.Left += (this.Width / 10) - 4;
                    }
                    else if (maps[currentMapIndex][Scenodply_y, Scenodply_x + 1] == 3)
                    {
                        if (maps[currentMapIndex][Scenodply_y, Scenodply_x + 2] == 1)
                        {
                            maps[currentMapIndex][Scenodply_y, Scenodply_x + 1] = 1; maps[currentMapIndex][Scenodply_y, Scenodply_x + 2] = 3;
                            Scenodply_x += 1;
                            pictureBox_player.Left += (this.Width / 10) - 4;
                            ChangBoxLocation(+(this.Width / 10), 0);
                        }
                        else if (maps[currentMapIndex][Scenodply_y, Scenodply_x + 2] == 2)
                        {
                            maps[currentMapIndex][Scenodply_y, Scenodply_x + 1] = 1; maps[currentMapIndex][Scenodply_y, Scenodply_x + 2] = 4;
                            Scenodply_x += 1;
                            pictureBox_player.Left += (this.Width / 10) - 4;
                            ChangBoxLocation(+(this.Width / 10), 0);
                        }
                    }
                    else if (maps[currentMapIndex][Scenodply_y, Scenodply_x + 1] == 4 && maps[currentMapIndex][Scenodply_y, Scenodply_x + 2] == 2)
                    {
                        maps[currentMapIndex][Scenodply_y, Scenodply_x + 1] = 2; maps[currentMapIndex][Scenodply_y, Scenodply_x + 2] = 4;
                        Scenodply_x += 1;
                        pictureBox_player.Left += (this.Width / 10) - 4;
                        ChangBoxLocation(+(this.Width / 10), 0);
                    }
                }
                //
                if (e.KeyCode == Keys.Up)
                {
                    currentPlayerImage = playerImageUp;
                    if (maps[currentMapIndex][Scenodply_y - 1, Scenodply_x] == 1 || maps[currentMapIndex][Scenodply_y - 1, Scenodply_x] == 2)
                    {
                        Scenodply_y -= 1;
                        pictureBox_player.Top -= (this.Height / 10) - 3;
                    }
                    else if (maps[currentMapIndex][Scenodply_y - 1, Scenodply_x] == 3)
                    {
                        if (maps[currentMapIndex][Scenodply_y - 2, Scenodply_x] == 1)
                        {
                            maps[currentMapIndex][Scenodply_y - 1, Scenodply_x] = 1; maps[currentMapIndex][Scenodply_y - 2, Scenodply_x] = 3;
                            Scenodply_y -= 1;
                            pictureBox_player.Top -= (this.Height / 10) - 4;
                            ChangBoxLocation(0, -(this.Height / 10));
                        }
                        else if (maps[currentMapIndex][Scenodply_y - 2, Scenodply_x] == 2)
                        {
                            maps[currentMapIndex][Scenodply_y - 1, Scenodply_x] = 1; maps[currentMapIndex][Scenodply_y - 2, Scenodply_x] = 4;
                            Scenodply_y -= 1;
                            pictureBox_player.Top -= (this.Height / 10) - 4;
                            ChangBoxLocation(0, -(this.Height / 10));
                        }
                    }
                    else if (maps[currentMapIndex][Scenodply_y - 1, Scenodply_x] == 4 && maps[currentMapIndex][Scenodply_y - 2, Scenodply_x] == 2)
                    {
                        maps[currentMapIndex][Scenodply_y - 1, Scenodply_x] = 2; maps[currentMapIndex][Scenodply_y - 2, Scenodply_x] = 4;
                        Scenodply_y -= 1;
                        pictureBox_player.Top -= (this.Height / 10) - 4;
                        ChangBoxLocation(0, -(this.Height / 10));
                    }
                }
                //
                if (e.KeyCode == Keys.Down)
                {
                    currentPlayerImage = playerImageDown;
                    if (maps[currentMapIndex][Scenodply_y + 1, Scenodply_x] == 1 || maps[currentMapIndex][Scenodply_y + 1, Scenodply_x] == 2)
                    {
                        Scenodply_y += 1;
                        pictureBox_player.Top += (this.Height / 10) - 3;
                    }
                    else if (maps[currentMapIndex][Scenodply_y + 1, Scenodply_x] == 3)
                    {
                        if (maps[currentMapIndex][Scenodply_y + 2, Scenodply_x] == 1)
                        {
                            maps[currentMapIndex][Scenodply_y + 1, Scenodply_x] = 1; maps[currentMapIndex][Scenodply_y + 2, Scenodply_x] = 3;
                            Scenodply_y += 1;
                            pictureBox_player.Top += (this.Height / 10) - 4;
                            ChangBoxLocation(0, +(this.Width / 10));
                        }
                        else if (maps[currentMapIndex][Scenodply_y + 2, Scenodply_x] == 2)
                        {
                            maps[currentMapIndex][Scenodply_y + 1, Scenodply_x] = 1; maps[currentMapIndex][Scenodply_y + 2, Scenodply_x] = 4;
                            Scenodply_y += 1;
                            pictureBox_player.Top += (this.Height / 10) - 4;
                            ChangBoxLocation(0, +(this.Width / 10));
                        }
                    }
                    else if (maps[currentMapIndex][Scenodply_y + 1, Scenodply_x] == 4 && maps[currentMapIndex][Scenodply_y + 2, Scenodply_x] == 2)
                    {
                        maps[currentMapIndex][Scenodply_y + 1, Scenodply_x] = 2; maps[currentMapIndex][Scenodply_y + 2, Scenodply_x] = 4;
                        Scenodply_y += 1;
                        pictureBox_player.Top += (this.Height / 10) - 4;
                        ChangBoxLocation(0, +(this.Width / 10));
                    }
                }
                if (maps[currentMapIndex][7, 3] == 4 && maps[currentMapIndex][7, 4] == 4 && maps[currentMapIndex][7, 5] == 4)
                {
                    currentMapIndex += 1;
                    DialogResult result = MessageBox.Show("是否前往下一關?", "恭喜過關!!!", MessageBoxButtons.YesNo);
                    if (result == DialogResult.Yes)
                    {
                        UpdateCurrentMap();
                        pictureBox_map.Image = Properties.Resources.地圖Level_3;
                    }
                    else
                    {
                        Application.Exit();
                    }
                }
            }
            //map3 的鍵盤判斷
            if (currentMapIndex == 2)
            {
                currentPlayerImage = playerImageLeft;
                if (e.KeyCode == Keys.Left)
                {
                    if (maps[currentMapIndex][Thirdply_y, Thirdply_x - 1] == 1 || maps[currentMapIndex][Thirdply_y, Thirdply_x - 1] == 2)
                    {
                        Thirdply_x -= 1;
                        pictureBox_player.Left -= (this.Width / 10) - 4;
                    }
                    else if (maps[currentMapIndex][Thirdply_y, Thirdply_x - 1] == 3)
                    {
                        if (maps[currentMapIndex][Thirdply_y, Thirdply_x - 2] == 1)
                        {
                            maps[currentMapIndex][Thirdply_y, Thirdply_x - 1] = 1; maps[currentMapIndex][Thirdply_y, Thirdply_x - 2] = 3;
                            Thirdply_x -= 1;
                            pictureBox_player.Left -= (this.Width / 10) - 4;
                            ChangBoxLocation(-(this.Width / 10), 0);
                        }
                        else if (maps[currentMapIndex][Thirdply_y, Thirdply_x - 2] == 2)
                        {
                            maps[currentMapIndex][Thirdply_y, Thirdply_x - 1] = 1; maps[currentMapIndex][Thirdply_y, Thirdply_x - 2] = 4;
                            Thirdply_x -= 1;
                            pictureBox_player.Left -= (this.Width / 10) - 4;
                            ChangBoxLocation(-(this.Width / 10), 0);
                        }
                    }
                    else if (maps[currentMapIndex][Thirdply_y, Thirdply_x - 1] == 4 && maps[currentMapIndex][Thirdply_y, Thirdply_x - 2] == 2)
                    {
                        maps[currentMapIndex][Thirdply_y, Thirdply_x - 1] = 2; maps[currentMapIndex][Thirdply_y, Thirdply_x - 2] = 4;
                        Thirdply_x -= 1;
                        pictureBox_player.Left -= (this.Width / 10) - 4;
                        ChangBoxLocation(-(this.Width / 10), 0);
                    }
                }
                //
                if (e.KeyCode == Keys.Right)
                {
                    currentPlayerImage = playerImageRight;
                    if (maps[currentMapIndex][Thirdply_y, Thirdply_x + 1] == 1 || maps[currentMapIndex][Thirdply_y, Thirdply_x + 1] == 2)
                    {
                        Thirdply_x += 1;
                        pictureBox_player.Left += (this.Width / 10) - 4;
                    }
                    else if (maps[currentMapIndex][Thirdply_y, Thirdply_x + 1] == 3)
                    {
                        if (maps[currentMapIndex][Thirdply_y, Thirdply_x + 2] == 1)
                        {
                            maps[currentMapIndex][Thirdply_y, Thirdply_x + 1] = 1; maps[currentMapIndex][Thirdply_y, Thirdply_x + 2] = 3;
                            Thirdply_x += 1;
                            pictureBox_player.Left += (this.Width / 10) - 4;
                            ChangBoxLocation(+(this.Width / 10), 0);
                        }
                        else if (maps[currentMapIndex][Thirdply_y, Thirdply_x + 2] == 2)
                        {
                            maps[currentMapIndex][Thirdply_y, Thirdply_x + 1] = 1; maps[currentMapIndex][Thirdply_y, Thirdply_x + 2] = 4;
                            Thirdply_x += 1;
                            pictureBox_player.Left += (this.Width / 10) - 4;
                            ChangBoxLocation(+(this.Width / 10), 0);
                        }
                    }
                    else if (maps[currentMapIndex][Thirdply_y, Thirdply_x + 1] == 4 && maps[currentMapIndex][Thirdply_y, Thirdply_x + 2] == 2)
                    {
                        maps[currentMapIndex][Thirdply_y, Thirdply_x + 1] = 2; maps[currentMapIndex][Thirdply_y, Thirdply_x + 2] = 4;
                        Thirdply_x += 1;
                        pictureBox_player.Left += (this.Width / 10) - 4;
                        ChangBoxLocation(+(this.Width / 10), 0);
                    }
                }
                //
                if (e.KeyCode == Keys.Up)
                {
                    currentPlayerImage = playerImageUp;
                    if (maps[currentMapIndex][Thirdply_y - 1, Thirdply_x] == 1 || maps[currentMapIndex][Thirdply_y - 1, Thirdply_x] == 2)
                    {
                        Thirdply_y -= 1;
                        pictureBox_player.Top -= (this.Height / 10) - 3;
                    }
                    else if (maps[currentMapIndex][Thirdply_y - 1, Thirdply_x] == 3)
                    {
                        if (maps[currentMapIndex][Thirdply_y - 2, Thirdply_x] == 1)
                        {
                            maps[currentMapIndex][Thirdply_y - 1, Thirdply_x] = 1; maps[currentMapIndex][Thirdply_y - 2, Thirdply_x] = 3;
                            Thirdply_y -= 1;
                            pictureBox_player.Top -= (this.Height / 10) - 4;
                            ChangBoxLocation(0, -(this.Height / 10));
                        }
                        else if (maps[currentMapIndex][Thirdply_y - 2, Thirdply_x] == 2)
                        {
                            maps[currentMapIndex][Thirdply_y - 1, Thirdply_x] = 1; maps[currentMapIndex][Thirdply_y - 2, Thirdply_x] = 4;
                            Thirdply_y -= 1;
                            pictureBox_player.Top -= (this.Height / 10) - 4;
                            ChangBoxLocation(0, -(this.Height / 10));
                        }
                    }
                    else if (maps[currentMapIndex][Thirdply_y - 1, Thirdply_x] == 4 && maps[currentMapIndex][Thirdply_y - 2, Thirdply_x] == 2)
                    {
                        maps[currentMapIndex][Thirdply_y - 1, Thirdply_x] = 2; maps[currentMapIndex][Thirdply_y - 2, Thirdply_x] = 4;
                        Thirdply_y -= 1;
                        pictureBox_player.Top -= (this.Height / 10) - 4;
                        ChangBoxLocation(0, -(this.Height / 10));
                    }
                }
                //
                if (e.KeyCode == Keys.Down)
                {
                    currentPlayerImage = playerImageDown;
                    if (maps[currentMapIndex][Thirdply_y + 1, Thirdply_x] == 1 || maps[currentMapIndex][Thirdply_y + 1, Thirdply_x] == 2)
                    {
                        Thirdply_y += 1;
                        pictureBox_player.Top += (this.Height / 10) - 3;
                    }
                    else if (maps[currentMapIndex][Thirdply_y + 1, Thirdply_x] == 3)
                    {
                        if (maps[currentMapIndex][Thirdply_y + 2, Thirdply_x] == 1)
                        {
                            maps[currentMapIndex][Thirdply_y + 1, Thirdply_x] = 1; maps[currentMapIndex][Thirdply_y + 2, Thirdply_x] = 3;
                            Thirdply_y += 1;
                            pictureBox_player.Top += (this.Height / 10) - 4;
                            ChangBoxLocation(0, +(this.Width / 10));
                        }
                        else if (maps[currentMapIndex][Thirdply_y + 2, Thirdply_x] == 2)
                        {
                            maps[currentMapIndex][Thirdply_y + 1, Thirdply_x] = 1; maps[currentMapIndex][Thirdply_y + 2, Thirdply_x] = 4;
                            Thirdply_y += 1;
                            pictureBox_player.Top += (this.Height / 10) - 4;
                            ChangBoxLocation(0, +(this.Width / 10));
                        }
                    }
                    else if (maps[currentMapIndex][Thirdply_y + 1, Thirdply_x] == 4 && maps[currentMapIndex][Thirdply_y + 2, Thirdply_x] == 2)
                    {
                        maps[currentMapIndex][Thirdply_y + 1, Thirdply_x] = 2; maps[currentMapIndex][Thirdply_y + 2, Thirdply_x] = 4;
                        Thirdply_y += 1;
                        pictureBox_player.Top += (this.Height / 10) - 4;
                        ChangBoxLocation(0, +(this.Width / 10));
                    }
                }
                if (maps[currentMapIndex][2, 5] == 4 && maps[currentMapIndex][5, 7] == 4 && maps[currentMapIndex][7, 4] == 4 && maps[currentMapIndex][4, 2] == 4)
                {
                    currentMapIndex += 1;
                    DialogResult result = MessageBox.Show("是否要退出?", "恭喜過關!!!", MessageBoxButtons.YesNo);
                    if (result == DialogResult.Yes)
                    {
                        Application.Exit();
                    }
                }
            }
        }
        public void ChangBoxLocation(int move_x, int move_y) //判斷玩家是否與箱子接觸
        {
            foreach (Control x in this.Controls)
            {
                if (x.Tag == "box" && pictureBox_player.Bounds.IntersectsWith(x.Bounds))
                {
                    x.Location = new Point(pictureBox_player.Left + move_x, pictureBox_player.Top + move_y);
                }
            }
        }

        // 計時器
        private Timer timer;
        private DateTime startTime;
        private void Timer_Tick(object sender, EventArgs e)
        {
            TimeSpan elapsedTime = DateTime.Now - startTime;
            lblTime.Text = string.Format("{0:mm\\:ss}", elapsedTime);
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

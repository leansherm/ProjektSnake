using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace SnakeCoding
{
    public partial class Form1 : Form
    {
        // управление
        private int dirX, dirY; 
        // еда
        private PictureBox pbFruit;
        private int randomX, randomY;
        // голова змеи
        private PictureBox[] snakeHead = new PictureBox[400];
        
///////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////

        public Form1()
        {
            InitializeComponent();
            new Settings();

            gameTimer.Tick += new EventHandler(UpdateScreen);
            gameTimer.Interval = 80; //скорость
            gameTimer.Start(); //запуск таймера

            dirX = 1;
            dirY = 0;
            
            StartGame();
        }

        private void StartGame()
        {
            new Settings();

            pbFruit = new PictureBox
            {
                BackColor = Color.Crimson,
                Size = new Size(Settings.boxSize, Settings.boxSize)
            };

            snakeHead[0] = new PictureBox
            {
                Location = new Point(201, 201),
                Size = new Size(Settings.boxSize - 1, Settings.boxSize - 1),
                BackColor = Color.Black
            };
            this.Controls.Add(snakeHead[0]);

            this.KeyDown += new KeyEventHandler(InputControll); // управление (взаимосвяза

            pbFruit_Generate();
            lblGameOver.Visible = false;
            button1.Enabled = false;
        }

        // обновление отображения игры
        private void UpdateScreen(Object objectOne, EventArgs eventsArgs)
        {
            MoveSnake();
            Eat();
            CheckBorders();
            pbCanvas.SendToBack();
        }

        
        
        // случайное появление еды на карте
        private void pbFruit_Generate()
        {
            // определение границ канваса
            int maxYPos = pbCanvas.Size.Height;

            Random random = new Random();
            randomX = random.Next(0, maxYPos - Settings.boxSize);
            int randomResultX = randomX % Settings.boxSize;
            randomX -= randomResultX;

            randomY = random.Next(0, maxYPos - Settings.boxSize);
            int randomResultY = randomY % Settings.boxSize;
            randomY -= randomResultY;

            randomX++;
            randomY++;
            
            pbFruit.Location = new Point(randomX, randomY);
            this.Controls.Add(pbFruit);
        }


        // движение всей змеи
        private void MoveSnake()
        {
            for (int i = Settings.score; i >= 1; i--)
            {
                snakeHead[i].Location = snakeHead[i - 1].Location;
            }
            snakeHead[0].Location = new Point(snakeHead[0].Location.X + dirX * (Settings.boxSize), snakeHead[0].Location.Y + dirY * (Settings.boxSize));

            // eatself
            for (int n = 1; n < Settings.score; n++)
            {
                if (snakeHead[0].Location == snakeHead[n].Location)
                {
                    for (int k = n; k <= Settings.score; k++)
                        this.Controls.Remove(snakeHead[k]); // удаление
                    Settings.score = Settings.score - (Settings.score - n + 1);
                    lblScore.Text = " " + Settings.score;
                }
            }
        }




        private void Eat()
        {
            if(snakeHead[0].Location.X == randomX && snakeHead[0].Location.Y == randomY)
            {
                lblScore.Text = " " + ++Settings.score + 0;
                // создание хвоста змеи
                snakeHead[Settings.score] = new PictureBox
                {
                    Location = new Point(snakeHead[Settings.score - 1].Location.X + 40 * dirX, snakeHead[Settings.score - 1].Location.Y - 40 * dirY),
                    Size = new Size(Settings.boxSize -1, Settings.boxSize -1),
                    BackColor = Color.Green
                };
                this.Controls.Add(snakeHead[Settings.score]);

                pbFruit_Generate();
            }
        }

        private void button1_Click(object sender, EventArgs e)
        {
            StartGame();
            Invalidate();
        }

        private void CheckBorders()
        {
            // определение границ канваса
            int maxYPos = pbCanvas.Size.Height;
            int maxXPos = pbCanvas.Size.Width;

            if(snakeHead[0].Location.X < 0 || snakeHead[0].Location.Y < 0 || snakeHead[0].Location.X >= maxXPos || snakeHead[0].Location.Y >= maxYPos)
            {
                lblGameOver.Visible = true;
                button1.Enabled = true;
                Settings.GameOver = true;
            }
            /*
            if (snakeHead[0].Location.X < 0)
            {
                lblGameOver.Visible = true;
                button1.Visible = true;
            }
            if (snakeHead[0].Location.X > Settings.height)
            {
                lblGameOver.Visible = true;
                button1.Visible = true;
            }
            if (snakeHead[0].Location.Y < 0)
            {
                lblGameOver.Visible = true;
                button1.Visible = true;
            }
            if (snakeHead[0].Location.Y > Settings.height)
            {
                lblGameOver.Visible = true;
                button1.Visible = true;
            }
            */
        }



        // управление 
        private void InputControll(object sender, KeyEventArgs e)
        {
            switch (e.KeyCode.ToString())
            {
                case "Right":
                    dirX = 1;
                    dirY = 0;
                    break;
                case "Left":
                    dirX = -1;
                    dirY = 0;
                    break;
                case "Up":
                    dirY = -1;
                    dirX = 0;
                    break;
                case "Down":
                    dirY = 1;
                    dirX = 0;
                    break;

            }

            
        }
        





    }
}

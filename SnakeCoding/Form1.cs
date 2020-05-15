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
        // размеры
        private int width = 600;
        private int height = 500;
        private int boxSize = 25;

        private int dirX, dirY; // управление

        // еда
        private PictureBox fruit;
        private int randomX, randomY;

        // голова змеи
        private PictureBox[] snakeHead = new PictureBox[400];

        private int score = 0; // счет
        //private Label lblScore;
   ///////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////

        public void Constructor(int _width, int _height, int _boxSize)
        {
            width = _width;
            height = _height;
            boxSize = _boxSize;
        }


        public Form1()
        {
            InitializeComponent();
            //this.Width = width;
            //this.Height = height;


            gameTimer.Tick += new EventHandler(UpdateScreen);
            gameTimer.Interval = 80; //скорость
            gameTimer.Start(); //запуск таймера

           StartGame();
        }

        // game start
        private void StartGame()
        {
            dirX = 1;
            dirY = 0;

            fruit = new PictureBox
            {
                BackColor = Color.Crimson,
                Size = new Size(boxSize, boxSize)
            };
   
            snakeHead[0] = new PictureBox
            {
                Location = new Point(201, 201),
                Size = new Size(boxSize - 1, boxSize - 1),
                BackColor = Color.Black
            };
            this.Controls.Add(snakeHead[0]);



            this.KeyDown += new KeyEventHandler(InputControll); // управление (взаимосвяза

            Fruit_Generate();
            lblGameOver.Visible = false;
            button1.Visible = false;
        }

        // обновление отображения игры
        private void UpdateScreen(Object objectOne, EventArgs eventsArgs)
        {
            MoveSnake();
            Eat();
            CheckBorders();
        }

        
        
        // случайное появление еды на карте
        private void Fruit_Generate()
        {
            Random random = new Random();
            randomX = random.Next(0, height - boxSize);
            int randomResultX = randomX % boxSize;
            randomX -= randomResultX;

            randomY = random.Next(0, height - boxSize);
            int randomResultY = randomY % boxSize;
            randomY -= randomResultY;

            randomX++;
            randomY++;
            
            fruit.Location = new Point(randomX, randomY);
            this.Controls.Add(fruit);
        }


        // движение всей змеи
        private void MoveSnake()
        {
            for (int i = score; i >= 1; i--)
            {
                snakeHead[i].Location = snakeHead[i - 1].Location;
            }
            snakeHead[0].Location = new Point(snakeHead[0].Location.X + dirX * (boxSize), snakeHead[0].Location.Y + dirY * (boxSize));

            // eatself
            for (int n = 1; n < score; n++)
            {
                if (snakeHead[0].Location == snakeHead[n].Location)
                {
                    for (int k = n; k <= score; k++)
                        this.Controls.Remove(snakeHead[k]); // удаление
                    score = score - (score - n + 1);
                    lblScore.Text = " " + score;
                }
            }
        }




        private void Eat()
        {
            if(snakeHead[0].Location.X == randomX && snakeHead[0].Location.Y == randomY)
            {
                lblScore.Text = " " + ++score + 0;
                // создание хвоста змеи
                snakeHead[score] = new PictureBox
                {
                    Location = new Point(snakeHead[score - 1].Location.X + 40 * dirX, snakeHead[score - 1].Location.Y - 40 * dirY),
                    Size = new Size(boxSize-1, boxSize-1),
                    BackColor = Color.Green
                };
                this.Controls.Add(snakeHead[score]);

                Fruit_Generate();
            }
        }

        private void button1_Click(object sender, EventArgs e)
        {
            StartGame();
            //Invalidate();
        }

        private void CheckBorders()
        {
            if (snakeHead[0].Location.X < 0)
            {
                lblGameOver.Visible = true;
                button1.Visible = true;
            }
            if (snakeHead[0].Location.X > height)
            {
                lblGameOver.Visible = true;
                button1.Visible = true;
            }
            if (snakeHead[0].Location.Y < 0)
            {
                lblGameOver.Visible = true;
                button1.Visible = true;
            }
            if (snakeHead[0].Location.Y > height)
            {
                lblGameOver.Visible = true;
                button1.Visible = true;
            }
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

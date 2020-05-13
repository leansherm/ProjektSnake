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
        private Label lblScore;
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

        private void StartGame()
        {
            dirX = 1;
            dirY = 0;

            fruit = new PictureBox
            {
                BackColor = Color.Red,
                Size = new Size(boxSize, boxSize)
            };

            
            snakeHead[0] = new PictureBox
            {
                Location = new Point(201, 201),
                Size = new Size(boxSize - 1, boxSize - 1),
                BackColor = Color.Black
            };
            this.Controls.Add(snakeHead[0]);

            lblScore = new Label
            {
                Text = "SCORE: 0",
                Location = new Point(510, 20)
            };
            this.Controls.Add(lblScore);


            this.KeyDown += new KeyEventHandler(InputControll); // управление (взаимосвязаны)

            pbMap_Paint();
            Fruit_Generate();
            //snakeHead[0].Invalidate();
            lblGameOver.Visible = false;
            pbGameOver.Visible = false;
            button1.Visible = false;
        }

        // обновление отображения игры
        private void UpdateScreen(Object objectOne, EventArgs eventsArgs)
        {
            MoveSnake();
            Eat();
            CheckBorders();

            

        }

        //рисовка карты
        private void pbMap_Paint()
        {
            for (int i = 0; i < width / boxSize; i++)
            {
                PictureBox pic = new PictureBox
                {
                    BackColor = Color.WhiteSmoke,
                    Location = new Point(0, boxSize * i),
                    Size = new Size(width - 100, 1)
                };
                this.Controls.Add(pic);
            }
            for (int i = 0; i <= height / boxSize; i++)
            {
                PictureBox pic = new PictureBox
                {
                    BackColor = Color.WhiteSmoke,
                    Location = new Point(boxSize * i, 0),
                    Size = new Size(1, width)
                };
                this.Controls.Add(pic);
            }
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

            for (int d = 1; d < score; d++)
            {
                if (snakeHead[0].Location == snakeHead[d].Location)
                {
                    lblGameOver.Visible = true;
                    pbGameOver.Visible = true;
                    button1.Visible = true;

                    /*if (Input.KeyPressed(Keys.Enter))
                    {
                        StartGame();
                    }*/
                }
            }
        }




        private void Eat()
        {
            if(snakeHead[0].Location.X == randomX && snakeHead[0].Location.Y == randomY)
            {
                lblScore.Text = "Score: " + ++score;
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
                pbGameOver.Visible = true;
                button1.Visible = true;
            }
            if (snakeHead[0].Location.X > height)
            {
                lblGameOver.Visible = true;
                pbGameOver.Visible = true;
                button1.Visible = true;
            }
            if (snakeHead[0].Location.Y < 0)
            {
                lblGameOver.Visible = true;
                pbGameOver.Visible = true;
                button1.Visible = true;
            }
            if (snakeHead[0].Location.Y > height)
            {
                lblGameOver.Visible = true;
                pbGameOver.Visible = true;
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

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

        public Form1()
        {
            InitializeComponent();
            //this.Width = width;
            //this.Height = height;
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
                Size = new Size(boxSize-1, boxSize-1),
                BackColor = Color.Black
            };
            this.Controls.Add(snakeHead[0]);

            lblScore = new Label
            {
                Text = "SCORE: 0",
                Location = new Point(510, 20)
            };
            this.Controls.Add(lblScore);

            gameTimer.Tick += new EventHandler(UpdateScreen);
            gameTimer.Interval = 80; //скорость
            gameTimer.Start(); //запуск таймера


            this.KeyDown += new KeyEventHandler(Input); // управление (взаимосвязаны)

            pbMap_Paint();
            Fruit_Generate();
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
            randomX = random.Next(0, width - boxSize);
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

        // обновление отображения игры
        private void UpdateScreen(Object objectOne, EventArgs eventsArgs)
        {
            MoveSnake();
            Eat();
            //pbSnake.Location = new Point(pbSnake.Location.X + dirX * boxSize, pbSnake.Location.Y + dirY * boxSize);
        }

        // движение всей змеи
        private void MoveSnake()
        {
            for (int i = score; i >= 1; i--)
            {
                snakeHead[i].Location = snakeHead[i - 1].Location;
            }
            snakeHead[0].Location = new Point(snakeHead[0].Location.X + dirX * (boxSize), snakeHead[0].Location.Y + dirY * (boxSize));

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


        // управление 
        private void Input(object sender, KeyEventArgs e)
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

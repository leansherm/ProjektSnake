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
        // sterowanie
        private int DirX, DirY; 
        // jedzenie
        private PictureBox pbFruit;
        private int RandomX, RandomY;
        // głowa węża
        private PictureBox[] snakeHead = new PictureBox[400];
        
///////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////

        public Form1()
        {
            InitializeComponent();
            new Settings();

            gameTimer.Tick += new EventHandler(UpdateScreen); // delegat
            gameTimer.Interval = Settings.Speed; //prędkość
            gameTimer.Start(); //uruchomienie licznika

            DirX = 1;
            DirY = 0;

            StartGame();
        }

        /// rozpoczęcie gry
        public void StartGame()
        {
            new Settings();

            pbFruit = new PictureBox
            {
                BackColor = Color.Crimson,
                Size = new Size(Settings.BoxSize, Settings.BoxSize)
            };

            snakeHead[0] = new PictureBox
            {
                Location = new Point(201, 201),
                Size = new Size(Settings.BoxSize - 1, Settings.BoxSize - 1),
                BackColor = Color.Black
            };
            Controls.Add(snakeHead[0]);

            KeyDown += new KeyEventHandler(InputControll); // zarządzanie

            pbFruit_Generate();
            lblGameOver.Visible = false;
            BttnRestart.Enabled = false;
        }

        /// aktualizacja wyświetlania gry
        private void UpdateScreen(Object objectOne, EventArgs eventsArgs)
        {
            MoveSnake();
            Eat();
            CheckBorders();
            pbCanvas.SendToBack();
        }

        /// losowe pojawienie się jedzenia na mapie
        private void pbFruit_Generate()
        {
            // definiowanie granic canvasa
            int maxYPos = pbCanvas.Size.Height;

            // losowanie
            Random random = new Random();
            RandomX = random.Next(0, maxYPos - Settings.BoxSize);
            int randomResultX = RandomX % Settings.BoxSize;
            RandomX -= randomResultX;

            RandomY = random.Next(0, maxYPos - Settings.BoxSize);
            int randomResultY = RandomY % Settings.BoxSize;
            RandomY -= randomResultY;

            RandomX++;
            RandomY++;
            
            pbFruit.Location = new Point(RandomX, RandomY);
            Controls.Add(pbFruit);
        }

        /// ruch całego węża + zderzenie
        private void MoveSnake()
        {
            for (int i = Settings.Score; i >= 1; i--)
            {
                snakeHead[i].Location = snakeHead[i - 1].Location;
            }
            snakeHead[0].Location = new Point(snakeHead[0].Location.X + DirX * (Settings.BoxSize), snakeHead[0].Location.Y + DirY * (Settings.BoxSize));

            // zderzenie głowy z ogonem = usunienie ogonów + usunienie punktów
            for (int n = 1; n < Settings.Score; n++)
            {
                if (snakeHead[0].Location == snakeHead[n].Location)
                {
                    for (int k = n; k <= Settings.Score; k++)
                        Controls.Remove(snakeHead[k]);
                    Settings.Score = Settings.Score - (Settings.Score - n + 1);
                    lblScore.Text = " " + Settings.Score + 0;
                }
            }
        }

        /// jedzenie owoców = dodanie punktów + dodanie ogonów węża
        private void Eat()
        {
            if(snakeHead[0].Location.X == RandomX && snakeHead[0].Location.Y == RandomY)
            {
                lblScore.Text = " " + ++Settings.Score + 0;
                // tworzenie ogonów węża
                snakeHead[Settings.Score] = new PictureBox
                {
                    Location = new Point(snakeHead[Settings.Score - 1].Location.X + 40 * DirX, snakeHead[Settings.Score - 1].Location.Y - 40 * DirY),
                    Size = new Size(Settings.BoxSize -1, Settings.BoxSize -1),
                    BackColor = Color.Green
                };
                Controls.Add(snakeHead[Settings.Score]);

                pbFruit_Generate();
            }
        }

        /// wznowienie gry po naciśnięciu przycisku
        private void Button1_Click(object sender, EventArgs e)
        {
            StartGame();
        }

        /// zakończenie gry kiedy wąż napotyka granicę
        private void CheckBorders()
        {
            // definiowanie granic canvasa
            int maxYPos = pbCanvas.Size.Height;
            int maxXPos = pbCanvas.Size.Width;

            // wyświetlanie wiadomości, że gra jest skończona
            if (snakeHead[0].Location.X < 0 || snakeHead[0].Location.Y < 0 || snakeHead[0].Location.X >= maxXPos || snakeHead[0].Location.Y >= maxYPos)
            {
                lblGameOver.Visible = true;
                BttnRestart.Enabled = true;
                Settings.GameOver = true;
                Controls.Remove(pbFruit);
            }
        }

        /// sterowanie
        private void InputControll(object sender, KeyEventArgs e)
        {
            switch (e.KeyCode.ToString())
            {
                case "Right":
                    DirX = 1;
                    DirY = 0;
                    break;
                case "Left":
                    DirX = -1;
                    DirY = 0;
                    break;
                case "Up":
                    DirY = -1;
                    DirX = 0;
                    break;
                case "Down":
                    DirY = 1;
                    DirX = 0;
                    break;

            }
        }
    }
}

using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Drawing;

namespace SnakeCoding
{
    public class Game
    {
        public static PictureBox pbFruit;

        public static PictureBox[] snakeHead = new PictureBox[400];
        private readonly KeyEventHandler KeyDown;

        public Game()
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
            //this.Controls.Add(snakeHead[0]);

            this.KeyDown += new KeyEventHandler(Form1.InputControll); // управление (взаимосвяза

            //Form1.pbFruit_Generate();
            //Form1.lblGameOver.Visible = false;
            //Form1.button1.Enabled = false;
        }
    }
}

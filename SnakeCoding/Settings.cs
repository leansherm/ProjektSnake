using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SnakeCoding
{
    /// regulowanie
    public class Settings
    {
        public static int Width { get; set; }
        public static int Height { get; set; }
        public static int BoxSize { get; set; }
        public static int Score { get; set; }
        public static bool GameOver { get; set; }
        public static int Speed { get; set; }


        /// regulowanie
        public Settings()
        {
            Width = 600;
            Height = 600;
            BoxSize = 25;
            Score = 0;
            GameOver = false;
            Speed = 80;
        }





    }
}

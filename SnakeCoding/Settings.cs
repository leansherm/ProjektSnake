using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SnakeCoding
{
    class Settings
    {
        public static int width { get; set; }
        public static int height { get; set; }
        public static int boxSize { get; set; }
        public static int score { get; set; }
        public static bool GameOver { get; set; }



        public Settings()
        {
            width = 600;
            height = 600;
            boxSize = 25;
            score = 0;
            GameOver = false;

        }





    }
}

using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Collections; // для - 'Hastable'

namespace SnakeCoding
{
    class Input
    {

        // загрузить список доступных кнопок клавиатуры
        private static Hashtable keyTable = new Hashtable();

        // Выполните проверку, чтобы увидеть, нажата ли конкретная кнопка
        public static bool KeyPressed(Keys key)
        {
            if (keyTable[key] == null)
            {
                return false;
            }
            return (bool)keyTable[key];
        }

        // определить, нажата ли клавиатура
        public static void ChangeState(Keys key, bool state)
        {
            keyTable[key] = state;
        }

    }
}

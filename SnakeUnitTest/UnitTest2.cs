using System;
using SnakeCoding;
using System.Windows.Forms;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace SnakeUnitTest
{
    [TestClass]
    public class UnitTest2
    {
        [TestMethod]
        public void TestMethod2()
        {

            /* Следующий тест должен подтвердить, что когда игра запускается, 
               значение gameOver bool не соответствует действительности.
            Następny test powinien potwierdzić, że po uruchomieniu gry wartość gameOver bool nie jest prawdziwa.
            */

            // 1
            Settings.GameOver = true;
            new Form1();
            new Game();
            // 2
            Assert.IsFalse(Settings.GameOver);
        }
    }
}
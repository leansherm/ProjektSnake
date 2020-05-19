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
            //Następny test powinien potwierdzić, że po uruchomieniu gry wartość GameOver bool nie jest prawdziwa.
            // 1
            Settings.GameOver = true;
            // 2
            Form1 form = new Form1();
            new Form1();
            form.StartGame();
            // 3
            Assert.IsFalse(Settings.GameOver);
        }
    }
}
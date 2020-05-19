using System;
using SnakeCoding;
using System.Windows.Forms;
using System.Drawing;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace SnakeUnitTest
{
    [TestClass]
    public class UnitTest1
    {
        [TestMethod]
        public void TestMethod1()
        {
            //1
            int result = 0;
            //2
            Form1 form = new Form1();
            new Form1();
            form.StartGame();
            //3
            Assert.AreEqual(Settings.Score, result);

        }
    }
}
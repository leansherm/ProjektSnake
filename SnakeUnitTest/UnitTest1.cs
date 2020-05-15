using System;
using SnakeCoding;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace SnakeUnitTest
{
    [TestClass]
    public class UnitTest1
    {
        [TestMethod]
        public void TestMethod1()
        {
            // arange

            // act
            Input s;
            // assert


        }
    }
}


// сделать проверку генерации еды на ИКС и ИГРЕК - проверка на эквавалентность мест. Икс и Игрек должны или не должны находится на олной координате
/*
AreEqual<T>(T, T);
AreEqual<T>(T, T, string)
Утверждает, что два объекта типа T имеют одно и то же значение

AreNotEqual<T>(T, T);
AreNotEqual<T>(T, T, string)
Утверждает, что два объекта типа T не имеют одно и то же значение

AreSame<T>(T, T);
AreSame<T>(T, T, string)
Утверждает, что две переменные ссылаются на один и тот же объект

AreNotSame<T>(T, T);
AreNotSame<T>(T, T, string)
Утверждает, что две переменные ссылаются на разные объекты

Fail();
Fail(string)
Отрицательный результат утверждения - никакие условия не проверены

Inconclusive();
Inconclusive(string)
Показывает, что результат модульного теста не может быть однозначно установлен

IsTrue(bool);
IsTrue(bool, string)
Утверждает, что булевское значение равно true - чаще всего используется для оценки выражения, возвращающего булевский результат

IsFalse(bool);
IsFalse(bool, string)
Утверждает, что булевское значение равно false

IsNull(object);
IsNull(object, string)
Утверждает, что переменная не присвоена объектной ссылке

IsNotNull(object);
IsNotNull(object, string)
Утверждает, что переменная присвоена объектной ссылке
*/

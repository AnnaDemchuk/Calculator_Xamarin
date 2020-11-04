using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading.Tasks;
using NUnit.Framework;
using UI_TestProj.Scrins;

namespace UI_TestProj
{
    public class TestClass
    {
        MainScreen _mainScreen = new MainScreen();

        [SetUp]
        public void BeforeEach()
        {
            AppInitializer.StartApp();
        }

        //[Test]
        //public void Test()
        //{
        //    //  MainScreen.Repl
        //    _mainScreen.TapOnOne().TapOnPlus().TapOnTwo().TapOnEquals();
        //    Assert.AreEqual("3", _mainScreen.GetTextFromField());
        //}

        [TestCase("3", "4", "7")] //успешно
        [TestCase("0", "4", "4")] //успешно
        [TestCase("0", "0", "0")] // System.Exception : Error while performing Query(Id("input"))
        [TestCase("11", "3", "14")] //успешно
        [TestCase("20", "5", "25")] // Ошибка (все что имеет ноль- обнуляет)   Expected: "25" But was:  "5"
        [TestCase("11111111", "22222222", "33333333")]//успешно
        [TestCase("-3", "8", "5")] //успешно
        [TestCase("6", "-4", "2")]//успешно
        [TestCase("-5", "-4", "-9")]//успешно
        [TestCase("7", "-7", "0")]//успешно
        [TestCase("-5", "3", "-2")]//успешно
        public void AddTwoIntegerNumbers(string first, string second, string exectedResult)
        {
            GetArrey(first);
            _mainScreen.TapOnPlus();
            GetArrey(second);
            _mainScreen.TapOnEquals();

            Assert.AreEqual(exectedResult, _mainScreen.GetTextFromField());
        }

        [TestCase("3", "1,3", "4,3")] //успешно
        [TestCase("1,5", "4", "5,5")] //успешно
        [TestCase("4", "0,4", "4,4")] // System.Exception : Error while performing Query(Id("input"))
        [TestCase("0,1", "3", "3,1")] //успешно
        [TestCase("0,01", "0,002", "0,012")]// System.Exception : Error while performing Query(Id("input"))
        public void AddTwoDoubleNumbers(string first, string second, string exectedResult)
        {
            GetArrey(first);
            _mainScreen.TapOnPlus();
            GetArrey(second);
            _mainScreen.TapOnEquals();

            Assert.AreEqual(exectedResult, _mainScreen.GetTextFromField());
        }

        [TestCase("0", "0", "0")] // ошибка System.Exception : Error while performing Query(Id("input"))
        [TestCase("0", "4", "-4")]//успешно
        [TestCase("5", "0", "0")]// ошибка System.Exception :
        [TestCase("5", "4", "1")]//успешно
        [TestCase("5", "8", "-3")]//успешно
        [TestCase("6", "6", "0")]//успешно
        [TestCase("50", "5", "45")]//ошибка, округление с нолями -5
        [TestCase("-5", "4", "-9")] //успешно
        [TestCase("3", "-2", "5")]//ошибка 1
        [TestCase("-7", "-1", "-6")]//ошибка -8
        [TestCase("-1", "-1", "0")]//ошибка -2
        public void MunusTwoIntegerNumbers(string first, string second, string exectedResult)
        {
            GetArrey(first);
            _mainScreen.TapOnMinus();
            GetArrey(second);
            _mainScreen.TapOnEquals();

            Assert.AreEqual(exectedResult, _mainScreen.GetTextFromField());
        }


        [TestCase("3", "1,3", "1,7")]//успешно
        [TestCase("5,5", "4", "1,5")]//успешно
        [TestCase("4", "0,4", "3,6")] //System.Exception : Error while performing Query(Id("input"))
        [TestCase("3", "0,1", "2,9")] //System.Exception : Error while performing Query(Id("input"))
        [TestCase("0,02", "0,001", "0,019")] //System.Exception : Error while performing Query(Id("input"))

        public void MunusTwoDoubleNumbers(string first, string second, string exectedResult)
        {
            GetArrey(first);
            _mainScreen.TapOnMinus();
            GetArrey(second);
            _mainScreen.TapOnEquals();

            Assert.AreEqual(exectedResult, _mainScreen.GetTextFromField());
        }


        public void ClickToNumber(char chars)
        {

            switch (chars)
            {
                case '0':
                    _mainScreen.TapOnZero();
                    break;
                case '1':
                    _mainScreen.TapOnOne();
                    break;
                case '2':
                    _mainScreen.TapOnTwo();
                    break;
                case '3':
                    _mainScreen.TapOnThree();
                    break;
                case '4':
                    _mainScreen.TapOnFour();
                    break;
                case '5':
                    _mainScreen.TapOnFive();
                    break;
                case '6':
                    _mainScreen.TapOnSix();
                    break;
                case '7':
                    _mainScreen.TapOnSeven();
                    break;
                case '8':
                    _mainScreen.TapOnEight();
                    break;
                case '9':
                    _mainScreen.TapOnNine();
                    break;
                case ',':
                    _mainScreen.TapOnComma();
                    break;
                case '-':
                    _mainScreen.TapOnMinus();
                    break;
                case '+':
                    _mainScreen.TapOnPlus();
                    break;
            }
        }

        public void GetArrey(string number)
        {
            char[] chars = number.ToCharArray();

            for (int i = 0; i < chars.Length; i++)
            {
                ClickToNumber(chars[i]);
            }

        }
    }
}

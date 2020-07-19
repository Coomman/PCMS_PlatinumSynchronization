using System.IO;
using System.Text;

using Lab6;
using NUnit.Framework;
using FluentAssertions;

namespace CodeChallenge.Tests.Lab6
{
    internal class TestTextWriter : TextWriter
    {
        private readonly StringBuilder _buffer = new StringBuilder();

        public override Encoding Encoding { get; } = Encoding.UTF8;

        public override void Write(char value)
        {
            _buffer.Append(value);
        }
        public override void WriteLine(int value)
        {
            _buffer.Append(value);
            _buffer.Append("\n");
        }

        public string GetBuffer()
            => _buffer.ToString();
    }

    internal class TaskD : ITestClass
    {
        private TestTextWriter _writer;
        private QuackInterpreter _quack;

        [SetUp]
        public void SetUp()
        {
            _writer = new TestTextWriter();
            _quack = new QuackInterpreter(_writer);
        }

        [Test]
        public void ExampleTest()
        {
            _quack.AddCommand("100");
            _quack.AddCommand("0");
            _quack.AddCommand(":start");
            _quack.AddCommand(">a");
            _quack.AddCommand("Zaend");
            _quack.AddCommand("<a");
            _quack.AddCommand("<a");
            _quack.AddCommand("1");
            _quack.AddCommand("+");
            _quack.AddCommand("-");
            _quack.AddCommand(">b");
            _quack.AddCommand("<b");
            _quack.AddCommand("Jstart");
            _quack.AddCommand(":end");
            _quack.AddCommand("P");

            _quack.Run();

            _writer.GetBuffer().Should().Be("5050\n");
        }

        [Test]
        public void ExampleTest2()
        {
            var rightAnswer = new StringBuilder();

            #region Source code

            _quack.AddCommand("58");
            rightAnswer.Append("58");
            rightAnswer.Append("\n");

            _quack.AddCommand("49");
            rightAnswer.Append("49");
            rightAnswer.Append("\n");

            _quack.AddCommand("10");
            rightAnswer.Append("10");
            rightAnswer.Append("\n");

            _quack.AddCommand("62");
            rightAnswer.Append("62");
            rightAnswer.Append("\n");

            _quack.AddCommand("97");
            rightAnswer.Append("97");
            rightAnswer.Append("\n");

            _quack.AddCommand("10");
            rightAnswer.Append("10");
            rightAnswer.Append("\n");

            _quack.AddCommand("80");
            rightAnswer.Append("80");
            rightAnswer.Append("\n");

            _quack.AddCommand("97");
            rightAnswer.Append("97");
            rightAnswer.Append("\n");

            _quack.AddCommand("10");
            rightAnswer.Append("10");
            rightAnswer.Append("\n");

            _quack.AddCommand("90");
            rightAnswer.Append("90");
            rightAnswer.Append("\n");

            _quack.AddCommand("97");
            rightAnswer.Append("97");
            rightAnswer.Append("\n");

            _quack.AddCommand("50");
            rightAnswer.Append("50");
            rightAnswer.Append("\n");

            _quack.AddCommand("10");
            rightAnswer.Append("10");
            rightAnswer.Append("\n");

            _quack.AddCommand("60");
            rightAnswer.Append("60");
            rightAnswer.Append("\n");

            _quack.AddCommand("97");
            rightAnswer.Append("97");
            rightAnswer.Append("\n");

            _quack.AddCommand("10");
            rightAnswer.Append("10");
            rightAnswer.Append("\n");

            _quack.AddCommand("74");
            rightAnswer.Append("74");
            rightAnswer.Append("\n");

            _quack.AddCommand("49");
            rightAnswer.Append("49");
            rightAnswer.Append("\n");

            _quack.AddCommand("10");
            rightAnswer.Append("10");
            rightAnswer.Append("\n");

            _quack.AddCommand("58");
            rightAnswer.Append("58");
            rightAnswer.Append("\n");

            _quack.AddCommand("50");
            rightAnswer.Append("50");
            rightAnswer.Append("\n");

            _quack.AddCommand("10");
            rightAnswer.Append("10");
            rightAnswer.Append("\n");

            _quack.AddCommand("48");
            rightAnswer.Append("48");
            rightAnswer.Append("\n");

            _quack.AddCommand("10");
            rightAnswer.Append("10");
            rightAnswer.Append("\n");

            _quack.AddCommand("58");
            rightAnswer.Append("58");
            rightAnswer.Append("\n");

            _quack.AddCommand("51");
            rightAnswer.Append("51");
            rightAnswer.Append("\n");

            _quack.AddCommand("10");
            rightAnswer.Append("10");
            rightAnswer.Append("\n");

            _quack.AddCommand("62");
            rightAnswer.Append("62");
            rightAnswer.Append("\n");

            _quack.AddCommand("97");
            rightAnswer.Append("97");
            rightAnswer.Append("\n");

            _quack.AddCommand("10");
            rightAnswer.Append("10");
            rightAnswer.Append("\n");

            _quack.AddCommand("90");
            rightAnswer.Append("90");
            rightAnswer.Append("\n");

            _quack.AddCommand("97");
            rightAnswer.Append("97");
            rightAnswer.Append("\n");

            _quack.AddCommand("52");
            rightAnswer.Append("52");
            rightAnswer.Append("\n");

            _quack.AddCommand("10");
            rightAnswer.Append("10");
            rightAnswer.Append("\n");

            _quack.AddCommand("67");
            rightAnswer.Append("67");
            rightAnswer.Append("\n");

            _quack.AddCommand("97");
            rightAnswer.Append("97");
            rightAnswer.Append("\n");

            _quack.AddCommand("10");
            rightAnswer.Append("10");
            rightAnswer.Append("\n");

            _quack.AddCommand("74");
            rightAnswer.Append("74");
            rightAnswer.Append("\n");

            _quack.AddCommand("51");
            rightAnswer.Append("51");
            rightAnswer.Append("\n");

            _quack.AddCommand("10");
            rightAnswer.Append("10");
            rightAnswer.Append("\n");

            _quack.AddCommand("58");
            rightAnswer.Append("58");
            rightAnswer.Append("\n");

            _quack.AddCommand("52");
            rightAnswer.Append("52");
            rightAnswer.Append("\n");

            _quack.AddCommand("10");
            rightAnswer.Append("10");
            rightAnswer.Append("\n");

            _quack.AddCommand("0");
            rightAnswer.Append("0");
            rightAnswer.Append("\n");

            _quack.AddCommand(":1");
            rightAnswer.Append(":1");
            rightAnswer.Append("\n");

            _quack.AddCommand(">a");
            rightAnswer.Append(">a");
            rightAnswer.Append("\n");

            _quack.AddCommand("Pa");
            rightAnswer.Append("Pa");
            rightAnswer.Append("\n");

            _quack.AddCommand("Za2");
            rightAnswer.Append("Za2");
            rightAnswer.Append("\n");

            _quack.AddCommand("<a");
            rightAnswer.Append("<a");
            rightAnswer.Append("\n");

            _quack.AddCommand("J1");
            rightAnswer.Append("J1");
            rightAnswer.Append("\n");

            _quack.AddCommand(":2");
            rightAnswer.Append(":2");
            rightAnswer.Append("\n");

            _quack.AddCommand("0");
            rightAnswer.Append("0");
            rightAnswer.Append("\n");

            _quack.AddCommand(":3");
            rightAnswer.Append(":3");
            rightAnswer.Append("\n");

            _quack.AddCommand(">a");
            rightAnswer.Append(">a");
            rightAnswer.Append("\n");

            _quack.AddCommand("Za4");
            rightAnswer.Append("Za4");
            rightAnswer.Append("\n");

            _quack.AddCommand("Ca");
            rightAnswer.Append("Ca");
            rightAnswer.Append("\n");

            _quack.AddCommand("J3");
            rightAnswer.Append("J3");
            rightAnswer.Append("\n");

            _quack.AddCommand(":4");
            rightAnswer.Append(":4");
            rightAnswer.Append("\n");

            #endregion

            _quack.Run();

            _writer.GetBuffer().Should().Be(rightAnswer.ToString());
        }
    }
}

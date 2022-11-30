using System;
using Moq;

namespace ConsoleApp1
{
    internal class Program
    {
        public static void Main()
        {
            // You can setup the behavior of any of a mock's overridable methods
            // using Setup, combined with e.g. Returns (so they return a value) or Throws (so they throw an exception):

            var mock = new Mock<IFoo>();
            mock.Setup(foo => foo.DoSomething("ping")).Returns(true);


            // out arguments
            var outString = "ack";
            // TryParse will return true, and the out argument will return "ack", lazy evaluated
            mock.Setup(foo => foo.TryParse("ping", out outString)).Returns(true);

            // ref arguments
            var instance = new Bar();
            // Only matches if the ref argument to the invocation is the same instance
            mock.Setup(foo => foo.Submit(ref instance)).Returns(true);

            mock.Setup(foo => foo.DoSomething("reset")).Throws<InvalidOperationException>();
            mock.Setup(foo => foo.DoSomething("")).Throws(new ArgumentException("command"));

            Console.WriteLine(mock.Object.DoSomething("ping"));
            Bar test = new Bar();
            Console.WriteLine(mock.Object.Submit(ref test));
            Console.WriteLine(mock.Object.Submit(ref instance));
            Console.WriteLine(mock.Object.TryParse("ping", out string temp));
            Console.WriteLine($"temp: {temp}");
        }
    }
}

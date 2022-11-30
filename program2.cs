using System;
using Moq;

namespace ConsoleApp1
{
    internal class Program
    {
        public static void Main()
        {
            var mock = new Mock<IFoo>();
           
            mock.Setup(foo => foo.Name).Returns("foo");
            Console.WriteLine($"Name: {mock.Object.Name}");

            mock.SetupSet(foo => foo.Name = "foo").Verifiable();
            mock.Object.Name = "foo";
            //mock.Object.Name = "bar"; // at the mock.Verify it will fail with an exception
            mock.Verify();

        }
    }
}

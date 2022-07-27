using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Text;
using System.Threading.Tasks;

namespace Example
{
    internal class StructEx
    {
        public struct User
        {
            //Конструктор без парамметров
            public User()
            {
            }
            public User(string name, int age)
            {
                Name = name;
                Age = age;
            }
            //Инициализаторы структуры
            public string Name { get; set; } = string.Empty;
            public int Age { get; set; } = 18;
        }

        public static void Test()
        {
            User myUser = new("DEMO", 21);
            User otherUser = myUser with { Name = "Tester" };
            Console.WriteLine(myUser.Name+otherUser.Name);
        }

        public static void Log(LogInterpolatedStringHandler Builder)
        {
            Console.WriteLine(Builder.GetFormattedText());
        }
    }

    [InterpolatedStringHandler]
    public ref struct LogInterpolatedStringHandler
    {
        StringBuilder builder;

        public LogInterpolatedStringHandler(int literalLength, int formattedCount)
        {
            builder = new StringBuilder(literalLength);
            Console.WriteLine($"\tliteral length: {literalLength}, formattedCount: {formattedCount}");
        }

        public void AppendLiteral(string s)
        {
            Console.WriteLine($"\tAppendLiteral called: {{{s}}}");

            builder.Append("*");
            Console.WriteLine($"\tAppended the literal string");
        }

        public void AppendFormatted<T>(T t)
        {
            Console.WriteLine($"\tAppendFormatted called: {{{t}}} is of type {typeof(T)}");

            builder.Append(t?.ToString());
            Console.WriteLine($"\tAppended the formatted object");
        }

        internal string GetFormattedText() => builder.ToString();
    }
}

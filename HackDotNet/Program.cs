/*
Thx to Friedrich von Never@ForNeVeR for idea and base implementation & Egor Bogatov@nagg for jokes =)
"(3:15:31 PM) nagg: Не дай бог придет такой наркоман на собес, ты у него спросишь чем отличается статик от не статик - а он: пфф... ничем. и у того и у того можно инстанс взять"
*/
using System;
using System.Reflection;

namespace HackDotNet
{
    class Program
    {
        static MethodInfo Allocate { get; } = typeof(RuntimeTypeHandle).GetMethod("Allocate", BindingFlags.NonPublic | BindingFlags.Static);
        static object VoidType { get; } = Allocate.Invoke(null, new[] { typeof(void) });
        private static void Main()
        {
            Console.WriteLine(VoidType.GetType()); // System.Void
            //Console.WriteLine(voidType is Void);  // True
            Console.WriteLine(ReturnMyVoid()); // System.Void
        }

        static object ReturnMyVoid() => VoidType;
    }
}
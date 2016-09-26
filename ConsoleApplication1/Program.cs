using System;
using System.Collections.Generic;
using System.Collections.Specialized;
using System.Diagnostics;
using System.IO;
using System.Linq;
using System.Linq.Expressions;
using System.Reflection;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using LinkNet.Common.Model;
using LinkNet.Model;
using Newtonsoft.Json;

namespace ConsoleApplication1
{

    class MyClass
    {
        public string GetString => "This is a new MyClass instance";
    }

    public class Program
    {
        private static PropertyInfo[] _infos = typeof(DBField).GetProperties(BindingFlags.Instance | BindingFlags.Public).Where(p => p.CanWrite).ToArray();

        private static void Main(string[] args)
        {
            var ctor = typeof(MyClass).GetConstructor(new Type[0]);
            if (ctor == null) return;

            var expression = Expression.New(ctor);
            var lambda = Expression.Lambda<Func<MyClass>>(expression);
            var myClass = lambda.Compile();

            var sw = new Stopwatch();
            Console.WriteLine("请输入循环次数");
            int max = int.Parse(Console.ReadLine());

            sw.Restart();
            for (var i = 0; i < max; i++)
            {
                var x = new MyClass();
            }
            sw.Stop();
            Console.WriteLine("直接创建耗时{0}ms,平均每次{1}ns", sw.ElapsedMilliseconds, sw.ElapsedMilliseconds * 1000000M / (decimal)max);

            sw.Restart();
            for (var i = 0; i < max; i++)
            {
                var x = myClass();
            }
            sw.Stop();
            Console.WriteLine("Expression.New方法创建耗时{0}ms,平均每次{1}ns", sw.ElapsedMilliseconds, sw.ElapsedMilliseconds * 1000000M / (decimal)max);

            Console.ReadLine();
        }

    }
}
